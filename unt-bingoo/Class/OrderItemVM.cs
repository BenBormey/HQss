using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class OrderItemVM
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }

        public int ProductID { get; set; }

        public string Item { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
