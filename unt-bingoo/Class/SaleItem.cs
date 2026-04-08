using System;

namespace unt_bingoo.Class
{
    public class SaleItem   // must be public
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        // Auto calculate
        public decimal Total
        {
            get { return Price * Qty; }
        }
    }
}
