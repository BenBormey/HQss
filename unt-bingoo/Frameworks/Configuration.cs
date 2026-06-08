using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Frameworks
{
    public abstract class Configuration
    {
        public string PrefixDatabase { get; set; } = "DB";
        public string PrefixTable { get; set; } = "Tbl";
        public string PrefixProcedure { get; set; } = "Pro";
        public string PrefixView { get; set; } = "Vie";
        public string PrefixFunction { get; set; } = "Fun";
    }


    public class Configurations : Configuration
    {
        private ApplicationFramework App = new ApplicationFramework();

        private static string Folder = "MAIN_SERVER";
        public static string FolderName
        {
            get { return Folder; }
            set { Folder = value; }
        }

        private static string SelectedDB = "BMS";
        public static string SelectedDatabase
        {
            get { return SelectedDB; }
            set { SelectedDB = value; }
        }

        public string GetComputerName
        {
            get { return Dns.GetHostName(); }
        }

        private readonly string DefaultIPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();

        public string GetIPAddress
        {
            get { return DefaultIPAddress; }
        }

        private string R_DatabaseName = ApplicationFramework.GetRegistry(ApplicationFramework.RegistryKeyName.DatabaseName, FolderName);
        public string DatabaseName
        {
            get { return R_DatabaseName; }
            set { R_DatabaseName = value; }
        }

        private string R_PublicIPAddress = ApplicationFramework.GetRegistry(ApplicationFramework.RegistryKeyName.PublicIPAddress, FolderName);
        public string PublicIPAddress
        {
            get { return R_PublicIPAddress; }
            set { R_PublicIPAddress = value; }
        }

        private string R_IPAddress = ApplicationFramework.GetRegistry(ApplicationFramework.RegistryKeyName.IPAddress, FolderName);
        public string IPAddress
        {
            get { return R_IPAddress; }
            set { R_IPAddress = value; }
        }

        private string R_UserConnection = ApplicationFramework.GetRegistry(ApplicationFramework.RegistryKeyName.UserConnection, FolderName);
        public string UserConnection
        {
            get { return R_UserConnection; }
            set { R_UserConnection = value; }
        }

        private string R_Password = ApplicationFramework.GetRegistry(ApplicationFramework.RegistryKeyName.PasswordConnection, FolderName);
        public string Password
        {
            get { return R_Password; }
            set { R_Password = value; }
        }

        private string R_PortNumber = ApplicationFramework.GetRegistry(ApplicationFramework.RegistryKeyName.PortNumber, FolderName);
        public string PortNumber
        {
            get { return R_PortNumber; }
            set { R_PortNumber = value; }
        }

        public enum ConnectionType
        {
            INTERNET,
            NETWORK
        }

        public string ConnectionString(ConnectionType type = ConnectionType.NETWORK, bool isPrefixDatabase = true)
        {
            string R_Connection = "";

            if (type == ConnectionType.NETWORK)
            {
                if (string.IsNullOrWhiteSpace(DatabaseName))
                {
                    R_Connection = string.Format("Server={0};uid={1};pwd={2};", IPAddress, UserConnection, Password);
                }
                else
                {
                    R_Connection = string.Format(
                        "Server={0};Initial Catalog={1};uid={2};pwd={3};",
                        IPAddress,
                        isPrefixDatabase ? $"{PrefixDatabase}{DatabaseName}" : DatabaseName,
                        UserConnection,
                        Password
                    );
                }
            }
            else // ConnectionType.INTERNET
            {
                if (string.IsNullOrWhiteSpace(DatabaseName))
                {
                    R_Connection = string.Format(
                        "Network Library=DBMSSOCN;Data Source={0}{1};uid={2};pwd={3};",
                        PublicIPAddress,
                        string.IsNullOrWhiteSpace(PortNumber) ? "" : $",{PortNumber}",
                        UserConnection,
                        Password
                    );
                }
                else
                {
                    R_Connection = string.Format(
                        "Network Library=DBMSSOCN;Data Source={0}{1};Initial Catalog={2};uid={3};pwd={4};",
                        PublicIPAddress,
                        string.IsNullOrWhiteSpace(PortNumber) ? "" : $",{PortNumber}",
                        isPrefixDatabase ? $"{PrefixDatabase}{DatabaseName}" : DatabaseName,
                        UserConnection,
                        Password
                    );
                }
            }

            return R_Connection;
        }
    }
}
