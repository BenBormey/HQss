using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class ExchangeRateModel
    {
        public int id { get; set; }
        public string currencyCode { get; set; }
        public decimal rate { get; set; }
        public decimal ask { get; set; }
        public decimal bid { get; set; }
        public decimal average { get; set; }
        public DateTime rateDate { get; set; }
        public string note { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
    }
}
