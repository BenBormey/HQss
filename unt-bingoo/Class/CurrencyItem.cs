using System;

namespace unt_bingoo.Class
{
    public class CurrencyItem
    {
        public int Id { get; set; }
        public string CurrencyNo { get; set; }       // CUR00001
        public string CurrencyCode { get; set; }     // USD, KHM, THB
        public string CurrencyName { get; set; }     // United State Dollar
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public int? SupplierId { get; set; }         // nullable → NULL = all suppliers
        public bool IsBase { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime? UpdatedAt { get; set; }  // nullable
    }
}
