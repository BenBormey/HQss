using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  public  class Franchise
    {
        public int franchiseId { get; set; }
        public string outletName { get; set; }
        public string outlet { get; set; }
        public string franchiseInformation { get; set; }
        public string typeName { get; set; }
        public int franchiseTypeId { get; set; }
        public DateTime? AgreementDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? AfterDate { get; set; }
        public bool Status { get; set; }
    }
}
