using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace unt_bingoo.Class
{
    // Plain data model matching the BankSetup table / repository.
    public class BankSetup
    {
        public int BankId { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankType { get; set; }
        public string MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string CallbackUrl { get; set; }
        public string Currency { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}