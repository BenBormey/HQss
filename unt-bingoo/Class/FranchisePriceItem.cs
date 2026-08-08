using System;

namespace unt_bingoo.Class
{
    public class FranchisePriceItem
    {
        public int Id { get; set; }

        public int OutletId { get; set; }
        public string OutletName { get; set; }

        public string ProNumY { get; set; }
        public string ProductName { get; set; }

        // Stocking unit the price is per (Product.ProUnit) — pcs, g, ml. Not a
        // case: transfers count in this unit, so the price has to as well.
        public string ProUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

    // Flat shape returned by GET api/FranchisePriceList/outlet/{id}.
    public class FranchisePriceLookupItem
    {
        public string ProNumY { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
