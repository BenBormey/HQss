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
    }

    public class PurchaseOrderItemModel
    {
        public int PurchaseOrderItemID { get; set; }
        public int PurchaseOrderID { get; set; }
        public string ProNumY { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalCost { get; set; }
        public int ReceivedQty { get; set; }
        public DateTime CreatedAt { get; set; }

        public string ProductName { get; set; }
    }
}
