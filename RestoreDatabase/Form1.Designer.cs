namespace RestoreDatabase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbSelectedFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDatabaseName = new System.Windows.Forms.TextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.ofdSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDBLocation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fbdDBLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSql = new System.Windows.Forms.TextBox();
            this.tbOrgDatabaseName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbWorkIndicator = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSqlUser = new System.Windows.Forms.TextBox();
            this.tbSqlPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbShowSqlPassword = new System.Windows.Forms.CheckBox();
            this.cbShowNewSqlPassword = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNewSqlPassword = new System.Windows.Forms.TextBox();
            this.tbNewSqlUser = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSelectedFile
            // 
            this.tbSelectedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSelectedFile.Location = new System.Drawing.Point(12, 12);
            this.tbSelectedFile.Name = "tbSelectedFile";
            this.tbSelectedFile.ReadOnly = true;
            this.tbSelectedFile.Size = new System.Drawing.Size(616, 20);
            this.tbSelectedFile.TabIndex = 0;
            this.tbSelectedFile.TextChanged += new System.EventHandler(this.tbSelectedFile_TextChanged);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(12, 38);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(616, 35);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server:";
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.Location = new System.Drawing.Point(12, 92);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(616, 20);
            this.tbServer.TabIndex = 20;
            this.tbServer.Text = "localhost";
            this.tbServer.TextChanged += new System.EventHandler(this.tbServer_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Database Name:";
            // 
            // tbDatabaseName
            // 
            this.tbDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDatabaseName.Location = new System.Drawing.Point(12, 188);
            this.tbDatabaseName.Name = "tbDatabaseName";
            this.tbDatabaseName.Size = new System.Drawing.Size(616, 20);
            this.tbDatabaseName.TabIndex = 30;
            this.tbDatabaseName.TextChanged += new System.EventHandler(this.tbDatabaseName_TextChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(11, 590);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(616, 51);
            this.btnRestore.TabIndex = 80;
            this.btnRestore.Text = "Run SQL";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // ofdSelectFile
            // 
            this.ofdSelectFile.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "New Database file location:";
            // 
            // tbDBLocation
            // 
            this.tbDBLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDBLocation.Location = new System.Drawing.Point(12, 319);
            this.tbDBLocation.Name = "tbDBLocation";
            this.tbDBLocation.Size = new System.Drawing.Size(616, 20);
            this.tbDBLocation.TabIndex = 50;
            this.tbDBLocation.TextChanged += new System.EventHandler(this.tbDBLocation_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(616, 31);
            this.button1.TabIndex = 60;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSql
            // 
            this.tbSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSql.Location = new System.Drawing.Point(12, 398);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.Size = new System.Drawing.Size(616, 186);
            this.tbSql.TabIndex = 70;
            // 
            // tbOrgDatabaseName
            // 
            this.tbOrgDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrgDatabaseName.Location = new System.Drawing.Point(12, 228);
            this.tbOrgDatabaseName.Name = "tbOrgDatabaseName";
            this.tbOrgDatabaseName.Size = new System.Drawing.Size(616, 20);
            this.tbOrgDatabaseName.TabIndex = 40;
            this.tbOrgDatabaseName.TextChanged += new System.EventHandler(this.tbOrgDatabaseName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Original Database Name (if different from filename):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "SQL:";
            // 
            // lbWorkIndicator
            // 
            this.lbWorkIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbWorkIndicator.AutoSize = true;
            this.lbWorkIndicator.Location = new System.Drawing.Point(8, 647);
            this.lbWorkIndicator.Name = "lbWorkIndicator";
            this.lbWorkIndicator.Size = new System.Drawing.Size(70, 13);
            this.lbWorkIndicator.TabIndex = 15;
            this.lbWorkIndicator.Text = "workindicator";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "DB login Credentials (if different from \'Integrated\')";
            // 
            // tbSqlUser
            // 
            this.tbSqlUser.Location = new System.Drawing.Point(53, 139);
            this.tbSqlUser.Name = "tbSqlUser";
            this.tbSqlUser.Size = new System.Drawing.Size(242, 20);
            this.tbSqlUser.TabIndex = 21;
            // 
            // tbSqlPassword
            // 
            this.tbSqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSqlPassword.Location = new System.Drawing.Point(363, 139);
            this.tbSqlPassword.Name = "tbSqlPassword";
            this.tbSqlPassword.PasswordChar = '*';
            this.tbSqlPassword.Size = new System.Drawing.Size(200, 20);
            this.tbSqlPassword.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "User:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Password:";
            // 
            // cbShowSqlPassword
            // 
            this.cbShowSqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowSqlPassword.AutoSize = true;
            this.cbShowSqlPassword.Location = new System.Drawing.Point(569, 141);
            this.cbShowSqlPassword.Name = "cbShowSqlPassword";
            this.cbShowSqlPassword.Size = new System.Drawing.Size(59, 17);
            this.cbShowSqlPassword.TabIndex = 23;
            this.cbShowSqlPassword.Text = "Show?";
            this.cbShowSqlPassword.UseVisualStyleBackColor = true;
            this.cbShowSqlPassword.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbShowNewSqlPassword
            // 
            this.cbShowNewSqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowNewSqlPassword.AutoSize = true;
            this.cbShowNewSqlPassword.Location = new System.Drawing.Point(569, 277);
            this.cbShowNewSqlPassword.Name = "cbShowNewSqlPassword";
            this.cbShowNewSqlPassword.Size = new System.Drawing.Size(59, 17);
            this.cbShowNewSqlPassword.TabIndex = 86;
            this.cbShowNewSqlPassword.Text = "Show?";
            this.cbShowNewSqlPassword.UseVisualStyleBackColor = true;
            this.cbShowNewSqlPassword.CheckedChanged += new System.EventHandler(this.cbShowNewSqlPassword_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 83;
            this.label9.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 82;
            this.label10.Text = "User:";
            // 
            // tbNewSqlPassword
            // 
            this.tbNewSqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewSqlPassword.Location = new System.Drawing.Point(363, 275);
            this.tbNewSqlPassword.Name = "tbNewSqlPassword";
            this.tbNewSqlPassword.PasswordChar = '*';
            this.tbNewSqlPassword.Size = new System.Drawing.Size(200, 20);
            this.tbNewSqlPassword.TabIndex = 85;
            // 
            // tbNewSqlUser
            // 
            this.tbNewSqlUser.Location = new System.Drawing.Point(53, 275);
            this.tbNewSqlUser.Name = "tbNewSqlUser";
            this.tbNewSqlUser.Size = new System.Drawing.Size(242, 20);
            this.tbNewSqlUser.TabIndex = 84;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "New login Credentials:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 669);
            this.Controls.Add(this.cbShowNewSqlPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbNewSqlPassword);
            this.Controls.Add(this.tbNewSqlUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbShowSqlPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSqlPassword);
            this.Controls.Add(this.tbSqlUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbWorkIndicator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbOrgDatabaseName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSql);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbDBLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.tbDatabaseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.tbSelectedFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SQL .bak Restore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSelectedFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.OpenFileDialog ofdSelectFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDBLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog fbdDBLocation;
        private System.Windows.Forms.TextBox tbSql;
        private System.Windows.Forms.TextBox tbOrgDatabaseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbWorkIndicator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSqlUser;
        private System.Windows.Forms.TextBox tbSqlPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbShowSqlPassword;
        private System.Windows.Forms.CheckBox cbShowNewSqlPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNewSqlPassword;
        private System.Windows.Forms.TextBox tbNewSqlUser;
        private System.Windows.Forms.Label label11;

    }
}

