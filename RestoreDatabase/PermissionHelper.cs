using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Management;

namespace RestoreDatabase
{
    static class PermissionHelper
    {
        public static string GetServiceUser(string serviceName)
        {
            var queryString = string.Format("select name, startname from Win32_Service where name = '{0}'", serviceName);
            var query = new SelectQuery(queryString);
            using (var searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject service in searcher.Get())
                {
                    return (string)service["Name"];
                    //Console.WriteLine(string.Format("Name: {0} - Logon : {1} ", service["Name"], service["startname"]));
                }
            }

            return null;
        }

        public static string GetSqlServiceName(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT @@SERVICENAME";
                    var serviceName = Convert.ToString(command.ExecuteScalar());
                    return serviceName;
                }
            }
        }

        public static bool GiveUserReadAccessToFolder(string user, DirectoryInfo folder)
        {
            var rights = FileSystemRights.Read;

            // *** Add Access Rule to the actual directory itself
            var accessRule = new FileSystemAccessRule(user, rights, 
                                        InheritanceFlags.None,
                                        PropagationFlags.NoPropagateInherit,
                                        AccessControlType.Allow);

            var security = folder.GetAccessControl(AccessControlSections.Access);

            bool result = false;
            security.ModifyAccessRule(AccessControlModification.Set, accessRule, out result);

            if (!result)
                return false;

            // *** Always allow objects to inherit on a directory
            var iFlags = InheritanceFlags.ObjectInherit;
            iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

            // *** Add Access rule for the inheritance
            accessRule = new FileSystemAccessRule(user, rights,
                                        iFlags,
                                        PropagationFlags.InheritOnly,
                                        AccessControlType.Allow);
            result = false;
            security.ModifyAccessRule(AccessControlModification.Add, accessRule, out result);

            if (!result)
                return false;

            folder.SetAccessControl(security);

            return true;
        }
    }
}
