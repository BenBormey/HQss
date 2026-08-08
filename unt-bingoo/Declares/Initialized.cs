using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Declares
{
    public class Initialized
    {

        public static string R_KeyPassword { get; set; } = "";

        public static Image R_Logo { get; set; } = null;//unt_bingoo.Properties.Resources.Logo;
        public long R_CompanyCode { get; set; } = 10001;

        //public static Image R_Logo { get; set; } = Unt_Admin.Properties.Resources.Logo;
        // public long R_CompanyCode { get; set; } = 10001;

        public static string R_Barcode { get; set; }

        public static int RProId { get; set; }
        public static string RCurrentBarcode { get; set; }

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

    }
}
