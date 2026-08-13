using System;
using System.Collections.Generic;

namespace unt_bingoo.Class
{
    /// <summary>
    /// One delivery event against a Purchase Order, as returned by
    /// GET api/GoodsReceiptNote/{id}, GET api/GoodsReceiptNote/purchase-order/{id},
    /// and inline as part of POST api/purchaseorder/receive/{id}'s response.
    /// A PO received across several partial deliveries has one of these per
    /// delivery, not one growing record.
    /// </summary>
    public class GoodsReceiptNoteModel
    {
        public int GRNId { get; set; }
        public string GRNNo { get; set; }
        public int PurchaseOrderID { get; set; }
        public int OutletID { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime ReceivedAt { get; set; }
        public string Note { get; set; }
        public List<GoodsReceiptNoteItemModel> Items { get; set; } = new List<GoodsReceiptNoteItemModel>();

        public string PurchaseOrderNo { get; set; }
        public string OutletName { get; set; }
    }

    public class GoodsReceiptNoteItemModel
    {
        public int GRNItemId { get; set; }
        public int GRNId { get; set; }
        public int PurchaseOrderItemID { get; set; }
        public string ProNumY { get; set; }
        public decimal ReceivedQty { get; set; }
        public string UOMCode { get; set; }
        public string LotNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? UnitCost { get; set; }
        public string ProName { get; set; }
    }

    /// <summary>The shape of POST api/purchaseorder/receive/{id}'s response body.</summary>
    public class ReceivePurchaseOrderResponseModel
    {
        public string Message { get; set; }
        public PurchaseOrderModel PurchaseOrder { get; set; }
        public GoodsReceiptNoteModel GoodsReceiptNote { get; set; }
    }
}
