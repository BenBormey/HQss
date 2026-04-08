using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class CartVM
    {
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public int OutletId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TaxPercent { get; set; }
    }
}
