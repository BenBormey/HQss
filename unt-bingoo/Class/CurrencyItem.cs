using System;

namespace unt_bingoo.Class
{
    public class CurrencyItem
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public bool IsBase { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
