using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class CartResponseVM
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int OutletID { get; set; }

        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CartItemVM> CartItems { get; set; }
    }
}
