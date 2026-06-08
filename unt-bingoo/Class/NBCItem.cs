using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  public  class NBCItem
    {
        public string currency { get; set; }
        public decimal buy { get; set; }   // Bid
        public decimal sell { get; set; }  // Ask
    }
}
