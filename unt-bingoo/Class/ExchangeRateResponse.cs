using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace unt_bingoo.Class
{
  public  class ExchangeRateResponse
    {

        public string ExternalSystemName { get; set; }


        public List<ExchangeRateItem> Items { get; set; }
    }
    public class ExchangeRateItem
    {
        
        public string Date { get; set; }


        public string Key { get; set; }

        public int Unit { get; set; }

       
        public decimal Bid { get; set; }

        
        public decimal Ask { get; set; }

        public decimal Average { get; set; }
    }
}
