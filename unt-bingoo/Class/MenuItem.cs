using System;

namespace unt_bingoo.Class
{
    public class MenuItems
    {
        public int MenuItemId { get; set; }

        public int OutletId { get; set; }
        public string OutletName { get; set; }

        public string ProNumY { get; set; }
        public int ProID { get; set; }
        public string ProductName { get; set; }

        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }

        public decimal SellingPrice { get; set; }

        public bool IsPromotion { get; set; }

        public decimal? Discount { get; set; }

        public decimal? PromotionPrice { get; set; }

        public DateTime? PromoStartDate { get; set; }

        public DateTime? PromoEndDate { get; set; }

        public bool IsActive { get; set; }

        public string ImageFileName { get; set; }

        public string Remark { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Display Number
        public int No { get; set; }

        public MenuItems()
        {
            OutletName = string.Empty;
            ProNumY = string.Empty;
            ProductName = string.Empty;
            CurrencyCode = string.Empty;
            CurrencyName = string.Empty;
            ImageFileName = string.Empty;
            Remark = string.Empty;
            CreatedBy = string.Empty;
            UpdatedBy = string.Empty;
        }
    }
}