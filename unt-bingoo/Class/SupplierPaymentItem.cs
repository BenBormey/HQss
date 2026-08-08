using System;

namespace unt_bingoo.Class
{
    // Shape of api/SupplierPayment. Doubles as the create-payment request body,
    // the same way SupplierItem does for api/Supplier — the extra read-only
    // fields (SupplierPaymentId, Status, CreatedAt, joined names) are simply
    // left at their defaults when posting a new one.
    public class SupplierPaymentItem
    {
        public int SupplierPaymentId { get; set; }

        public string PaymentNo { get; set; }

        public string SupplierCode { get; set; }

        /// <summary>Optional — null for a general payment not tied to one PO.</summary>
        public int? PurchaseOrderId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public string ReferenceNo { get; set; }

        public string Status { get; set; }

        public string Remark { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string SupplierName { get; set; }

        public string PurchaseOrderNo { get; set; }

        public string CreatedByName { get; set; }
    }

    /// <summary>Shape of GET api/SupplierPayment/outstanding/{supplierCode}.</summary>
    public class SupplierOutstandingResponse
    {
        public string SupplierCode { get; set; }
        public decimal Outstanding { get; set; }
    }
}
