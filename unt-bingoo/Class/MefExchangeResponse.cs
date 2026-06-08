using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class MefExchangeResponse
    {
        public MefData data { get; set; }
    }

    public class MefData
    {
        public string valid_date { get; set; }
        public string currency_id { get; set; }
        public string symbol { get; set; }
        public decimal bid { get; set; }
        public decimal average { get; set; }
        public string currency { get; set; }
        public int unit { get; set; }
        public decimal Ask { get; set; }
    }
}
