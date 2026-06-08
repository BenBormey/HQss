using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unt_bingoo.Frameworks;
using static unt_bingoo.Frameworks.DatabaseFramework;

namespace unt_bingoo.Declares
{
    public class Initialized
    {

        public static string R_KeyPassword { get; set; } = "";

        public static Image R_Logo { get; set; } = null;//unt_bingoo.Properties.Resources.Logo;
        public long R_CompanyCode { get; set; } = 10001;

        //public static Image R_Logo { get; set; } = Unt_Admin.Properties.Resources.Logo;
        // public long R_CompanyCode { get; set; } = 10001;

        public static string R_CompanyName { get; set; }
        public static string R_CompanyAddress { get; set; }

        public static string R_PrefixDatabase { get; set; } = "DB";
        public static string R_PublicIPAddress { get; set; }
        public static string R_IPAddress { get; set; } = "192.168.1.111";
        public static string R_IPAddress_Temp { get; set; } = "192.168.100.49";
        public static string R_UserConnection { get; set; } = "UserConnection";
        public static string R_PasswordConnection { get; set; } = "123";
        public static string R_DatabaseName { get; set; }

        public static string R_MainDatabaseName { get; set; } = "Company Setup";
        public static string R_PortConnection { get; set; }
        public static string RJounalDatabaseName { get; set; } = "Journal";
        public static string RJounalTableName { get; set; } = "Journal";
        public static string REmployeeDatabaseName { get; set; } = "Employee";
        public static string vDBEmployee { get; set; } = "DBEmployeeUNTWHOLESALECOLTD";

        public static bool R_CorrectPassword { get; set; }
        public static string R_PermissionPassword { get; set; }
        public static bool R_IsCancel { get; set; }
        public static bool R_SearchCustomerId { get; set; }
        public static string R_SearchValue { get; set; }
        public static bool R_AllUnpaid { get; set; }
        public DateTime R_DateFrom { get; set; }
        public DateTime R_DateTo { get; set; }
        public string R_IndexString { get; set; }
        public double R_SelectedAmount { get; set; }
        public bool R_IsFullPayment { get; set; }
        public string R_CollectorName { get; set; }
        public string R_SelectedAccount { get; set; }
        public bool R_AllStatus { get; set; }
        public bool R_WaitingStatus { get; set; }
        public bool R_ProcessingStatus { get; set; }
        public bool R_StopStatus { get; set; }
        public double R_ExchangeRate { get; set; }

     //   public const string lIdentityURL = "http://206.189.154.158:55499"; // IDENTITY SERVER
                                                                           //  public const string CreatcustomerURL = "http://206.189.154.158:55415/";//customert

        public const string username_ = "untadmin";
        public const string password_ = "tnac89";
        public const string login_ = "/User/login";

        public enum ViewJournalReport
        {
            All_Journal,
            All_Journal_Completed,
            All_Journal_Not_Completed
        }
        public ViewJournalReport R_JournalSelected { get; set; }

        //*******
        private DataTable DTable;

        public bool CheckCompaniesExistOrNot(DatabaseFramework data, ApplicationFramework app)
        {
            bool RExisted = false;
            var dic = new Dictionary<string, object>
                    {
                        { "CompanyCode", R_CompanyCode }
                    };

            data.DatabaseName = "CompanySetup";
            DTable = (DataTable)data.Selects("Companies", null, dic, false, SeparatorList.Is_And, null, null, GetConnectionType(data, app));
            //  DTable = data.Selects("Companies", null, dic, false, SeparatorList.Is_And, null, null, GetConnectionType(data, app)
            // ) ;

            // DTable = data.Selects("Companies", null, dic,false , SeparatorList.Is_And, null,null , GetConnectionType(data, app));

            if (DTable != null && DTable.Rows.Count > 0)
            {

                Initialized.R_CompanyName = (DTable.Rows[0]["ComName"] == DBNull.Value ? "" : DTable.Rows[0]["ComName"].ToString())
                           .ToUpper()
                           .Replace("&", "&&");

                //     Initialized.R_CompanyName = Replace(StrConv(dTable.Rows[0]["ComName"] == DBNull.Value ? "" : dTable.Rows[0]["ComName"].ToString(), VbStrConv.Uppercase), "&", "&&");
                Initialized.R_CompanyAddress = DTable.Rows[0]["ComAddress"] == DBNull.Value ? "" : DTable.Rows[0]["ComAddress"].ToString().Trim();
                Initialized.R_CompanyAddress += string.IsNullOrWhiteSpace(DTable.Rows[0]["ComTelephone"] == DBNull.Value ? "" : DTable.Rows[0]["ComTelephone"].ToString().Trim())
                                                ? ""
                                                : $"\r\nTel: {DTable.Rows[0]["ComTelephone"]}";
                RExisted = true;
            }
            else
            {

                Initialized.R_CompanyName = "";
                Initialized.R_CompanyAddress = "";
                RExisted = false;
            }

            Initialized.R_DatabaseName = Initialized.R_CompanyName;
            data.DatabaseName = app.MergeObject(Initialized.R_CompanyName);
            RJounalDatabaseName = string.Format("Journal{0}", app.MergeObject(Initialized.R_CompanyName));
            RJounalTableName = string.Format("Journal{0}", app.MergeObject(Initialized.R_CompanyName));

            return RExisted;
        }


        public static Configurations.ConnectionType GetConnectionType(DatabaseFramework Data, ApplicationFramework App)
        {

            App = new ApplicationFramework();

            if (App.CheckConnectionByPing(Data.PublicIPAddress) == true)
            {
                return Configurations.ConnectionType.INTERNET;
            }
            else
            {
                if (App.CheckConnectionByPing(Data.IPAddress) == false)
                {
                    if (App.CheckConnectionByPing(Initialized.R_IPAddress_Temp) == false)
                    {
                        Data.IPAddress = Initialized.R_IPAddress;
                    }
                    else
                    {
                        Data.IPAddress = Initialized.R_IPAddress_Temp;
                    }
                }
                return Configurations.ConnectionType.NETWORK;
            }
        }

        public static void LoadingInitialized(DatabaseFramework data, ApplicationFramework app)
        {
            data.PrefixDatabase = Initialized.R_PrefixDatabase;
            data.PublicIPAddress = Initialized.R_PublicIPAddress;
            data.IPAddress = Initialized.R_IPAddress;
            data.UserConnection = Initialized.R_UserConnection;
            data.Password = Initialized.R_PasswordConnection;
            data.DatabaseName = app.MergeObject(Initialized.R_CompanyName);
            data.PortNumber = Initialized.R_PortConnection;
        }



    }
}
