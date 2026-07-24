using System.Collections.Generic;

namespace unt_bingoo.Class
{
    public class PosCheckoutRequest
    {
        public int UserId { get; set; }
        public int OutletId { get; set; }
        public List<PosCheckoutLine> Items { get; set; } = new List<PosCheckoutLine>();
        public string PaymentMethod { get; set; }
        public int? ShiftId { get; set; }
        public int? CustomerId { get; set; }
        public int RedeemPoints { get; set; }
        public decimal RedeemValue { get; set; }
    }

    public class PosCheckoutLine
    {
        public string ProNumY { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Note { get; set; }
    }

    public class PosCheckoutResult
    {
        public int OrderID { get; set; }
        public string InvoiceNo { get; set; }
        public int PointsEarned { get; set; }
        public int PointsRedeemed { get; set; }
        public int PointsBalance { get; set; }
    }
}
