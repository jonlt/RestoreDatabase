using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Windows.Forms;

namespace RestoreDatabase
{
    public partial class Form1 : Form
    {
        public Form1(string file)
        {
            InitializeComponent();
            tbDBLocation.Text = GetDbLocation();
            lbWorkIndicator.Text = "";

            if (!string.IsNullOrEmpty(file))
            {
                tbSelectedFile.Text = file;
            }
        }

        private string GetDatabaseNameFromSelectedFile()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "RESTORE FILELISTONLY FROM DISK = @File";
                    var file = GetSelectedFiles().First();
                    command.Parameters.AddWithValue("@File", file);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToChar(reader["Type"]) == 'D')
                            {
                                return Convert.ToString(reader["LogicalName"]);
                            }
                        }
                    }
                }
            }
            return null;

        }

        private string GetDbLocation()
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT physical_name FROM sys.master_files";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var file = Convert.ToString(reader["physical_name"]);
                                return Path.GetDirectoryName(file);
                            }
                        }
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (ofdSelectFile.ShowDialog() == DialogResult.OK)
            {
                SetSelectedFiles(ofdSelectFile.FileNames);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

            lbWorkIndicator.Text = "Working...";
            this.Update();

            var server = tbServer.Text;
            var databaseName = tbDatabaseName.Text;
            var file = tbSelectedFile.Text;
            var dblocation = tbDBLocation.Text;

            var connectionString = GetConnectionString();
    
            HandleRestore(connectionString, databaseName, file, dblocation);

            
            lbWorkIndicator.Text = "";
        }

        private string GetConnectionString()
        {
            var connectionString = string.Format("Data Source={0}; Integrated Security=True;", tbServer.Text);

            if (!string.IsNullOrEmpty(tbSqlUser.Text) && !string.IsNullOrEmpty(tbSqlPassword.Text))
            {
                connectionString = string.Format("Data Source={0}; User ID={1}; Password={2};", tbServer.Text, tbSqlUser.Text, tbSqlPassword.Text);
            }
            return connectionString;
        }

        private void HandleRestore(string connectionString, string databaseName, string file, string dblocation)
        {
            try
            {
                RestoreDatabase(connectionString, databaseName, file, dblocation);
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.ToLower().Contains("access is denied"))
                {
                    var folder = Path.GetDirectoryName(file);
                    var dir = new DirectoryInfo(folder);
                    var service = PermissionHelper.GetSqlServiceName(connectionString);
                    var user = PermissionHelper.GetServiceUser(service);
                    var msgResult = MessageBox.Show(string.Format("Looks like there is a permission error. Give the user '{0}' read access to '{1}' and try again?", user, folder), "Permission error", MessageBoxButtons.YesNo);
                    if (msgResult == DialogResult.Yes)
                    {
                        PermissionHelper.GiveUserReadAccessToFolder(user, dir);
                        HandleRestore(connectionString, databaseName, file, dblocation);
                    }
                }
                else if (sqlEx.Message.ToLower().Contains("is not part of database"))
                {
                    MessageBox.Show("looks like the database provided is not present in the backup file. Please provide the correct 'original' database name");
                }
                else
                {
                    MessageBox.Show(sqlEx.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void RestoreDatabase(string connectionString, string databaseName, string file, string dblocation)
        {
            var mdfFile = GetMdfFile(databaseName, dblocation);
            if (File.Exists(mdfFile))
            {
                var replace = MessageBox.Show("Database already exists, continue and replace?", "Database already exists", MessageBoxButtons.YesNo);
                if (replace == DialogResult.No)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(databaseName) && !string.IsNullOrEmpty(file))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        var sql = tbSql.Text;
                        command.CommandTimeout = 3600;


                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Restored!");
            }
            else
            {
                MessageBox.Show("Missing some input");
            }
        }

        private static bool GenerateSQL(string databaseName, string originalDatabaseName, string[] files, string dblocation, string newuser, string newpassword, out string sql)
        {
            if (!files.Any())
            {
                sql = null;
                return false;
            }


            var fromDatabase = originalDatabaseName;

            var mdfFile = Path.Combine(dblocation, databaseName + ".mdf");
            var logFile = Path.Combine(dblocation, databaseName + ".ldf");

            var sqlFormat = ReadCreateScript();

            if (!string.IsNullOrEmpty(newuser) && !string.IsNullOrEmpty(newpassword))
            {
                sqlFormat += ReadCreateUserScript();
            }

            var disk = string.Join(Environment.NewLine+",", files.Select(f => string.Format("DISK = '{0}'", f)).ToArray());

            if (!string.IsNullOrEmpty(sqlFormat))
            {
                sql = string.Format(sqlFormat, databaseName, disk, fromDatabase, mdfFile, logFile, newuser, newpassword);
                return true;
            }
            else
            {
                sql = null;
                return false;
            }
        }

        public string GetMdfFile(string databaseName, string dblocation)
        {
            var mdfFile = Path.Combine(dblocation, databaseName + ".mdf");
            return mdfFile;
        }

        public void UpdateSql()
        {
            string sql;
            tbDBLocation.Text = GetDbLocation();
            var files = GetSelectedFiles();
            if (GenerateSQL(tbDatabaseName.Text, tbOrgDatabaseName.Text, files, tbDBLocation.Text, tbNewSqlUser.Text, tbNewSqlPassword.Text, out sql))
            {
                tbSql.Text = sql;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbdDBLocation.ShowDialog() == DialogResult.OK)
            {
                var folder = fbdDBLocation.SelectedPath;
                tbDBLocation.Text = folder;
            }
        }

        private void tbDBLocation_TextChanged(object sender, EventArgs e)
        {
            var folder = tbDBLocation.Text;
            UpdateSql();
        }

        private void tbSelectedFile_TextChanged(object sender, EventArgs e)
        {
            string databasename = null;
            try
            {
                databasename = GetDatabaseNameFromSelectedFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (databasename != null)
            {
                tbOrgDatabaseName.Text = databasename;
            }
            UpdateSql();

        }

        private void tbServer_TextChanged(object sender, EventArgs e)
        {
            UpdateSql();
        }

        private void tbDatabaseName_TextChanged(object sender, EventArgs e)
        {
            tbNewSqlUser.Text = tbDatabaseName.Text;
            tbNewSqlPassword.Text = tbDatabaseName.Text;
            UpdateSql();
        }

        private void tbOrgDatabaseName_TextChanged(object sender, EventArgs e)
        {
            UpdateSql();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbSqlPassword.PasswordChar = cbShowSqlPassword.Checked ? '\0' : '*';
        }

        private void cbShowNewSqlPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbNewSqlPassword.PasswordChar = cbShowNewSqlPassword.Checked ? '\0' : '*';
        }

        private static string ReadCreateScript()
        {
            return ReadEmbeddedScript("RestoreDatabase.CreateScript.sql");
        }

        private static string ReadCreateUserScript()
        {
            return ReadEmbeddedScript("RestoreDatabase.CreateUserScript.sql");
        }

        private static string ReadEmbeddedScript(string script)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = script;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();
                        return result;
                    }
                }
            }

            return null;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.All(f => string.Equals(Path.GetExtension(f), ".bak", StringComparison.InvariantCultureIgnoreCase)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            SetSelectedFiles(files);
        }

        private void SetSelectedFiles(string[] files)
        {
            tbSelectedFile.Text = string.Join(Environment.NewLine, files);
        }

        private string[] GetSelectedFiles()
        {
            return tbSelectedFile.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void tbNewSqlUser_TextChanged(object sender, EventArgs e)
        {
            UpdateSql();
        }

        private void tbNewSqlPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateSql();
        }
    }
}
