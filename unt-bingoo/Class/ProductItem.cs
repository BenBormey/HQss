using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class ProductItem
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal VatPercent { get; set; }
        public decimal Qty { get; set; }
        public string Supplier { get; set; }
        public bool Active { get; set; }
    }

}
