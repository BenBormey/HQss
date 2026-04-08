using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class SupplierItem
    {
        public int SupplierID { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string TaxNumber { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
