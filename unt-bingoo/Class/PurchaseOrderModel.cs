using System;
using System.Collections.Generic;

namespace unt_bingoo.Class
{
    public class PurchaseOrderModel
    {
        public int PurchaseOrderID { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SupplierID { get; set; }
        public int OutletID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<PurchaseOrderItemModel> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItemModel>();

        public string SupplierName { get; set; }
        public string OutletName { get; set; }
    }

    public class PurchaseOrderItemModel
    {
        public int PurchaseOrderItemID { get; set; }
        public int PurchaseOrderID { get; set; }
        public string ProNumY { get; set; }

        // Decimal, not int: a supplier sells 2.5 KG of coffee, and an int
        // silently refused it. Matches PurchaseOrderItems.Quantity
        // decimal(18,4) on the server.
        public decimal Quantity { get; set; }

        // The unit Quantity and UnitCost are BOTH in — the supplier's, the one
        // printed on the invoice. "5 KG @ $12" is stored exactly like that;
        // the server converts to the product's stocking unit on receipt.
        public string UOMCode { get; set; }

        public decimal UnitCost { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalCost { get; set; }

        // In purchase units, like Quantity. Receive 2 of a 5 KG order and this
        // is 2, not 2000.
        public decimal ReceivedQty { get; set; }

        public DateTime CreatedAt { get; set; }

        // ---- what the purchase became in stock, filled in by the server ----
        public string BaseUOMCode { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal ReceivedBaseQty { get; set; }

        public string ProductName { get; set; }

        // Set locally from the picked purchase unit so the grid can show the
        // effect before the line is ever sent. Not part of the API contract.
        public decimal LocalFactor { get; set; } = 1m;
        public string LocalBaseUOMCode { get; set; }

        // How much of this line is still outstanding — the number the buyer
        // actually needs when deciding whether to chase a supplier, rather
        // than mentally subtracting Received from Qty on every row.
        public decimal RemainingQty
        {
            get { return Quantity - ReceivedQty; }
        }

        // What ordering this line will actually put on the shelf. Buying
        // coffee in KG when it is stocked in G is correct and normal, but the
        // 1000x gap between the two numbers is worth showing rather than
        // leaving the buyer to trust it.
        public string StockEffect
        {
            get
            {
                var baseCode = BaseUOMCode ?? LocalBaseUOMCode;
                var factor = ConversionFactor ?? LocalFactor;

                if (string.IsNullOrWhiteSpace(baseCode) || factor <= 0m)
                    return "-";

                // Same unit in and out: saying "= 100 PCS" next to "100 PCS"
                // is noise, so only the interesting case is spelled out.
                if (string.Equals(baseCode, UOMCode, StringComparison.OrdinalIgnoreCase))
                    return string.Empty;

                return "= " + (Quantity * factor).ToString("N0") + " " + baseCode;
            }
        }
    }
}
