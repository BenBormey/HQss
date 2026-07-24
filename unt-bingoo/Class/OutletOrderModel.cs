using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace unt_bingoo.Class
{
    public class OutletOrderModel
    {
        public int OutletOrderID { get; set; }
        public string OutletOrderNo { get; set; }
        public int OutletID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Browsable(false)]
        public List<OutletOrderItemModel> OutletOrderItems { get; set; } = new List<OutletOrderItemModel>();

        // Filled client-side from api/Outlet
        public string OutletName { get; set; }
    }

    public class OutletOrderItemModel
    {
        public int OutletOrderItemID { get; set; }
        public int OutletOrderID { get; set; }
        public string ProNumY { get; set; }
        public int RequestedQty { get; set; }
        public int FulfilledQty { get; set; }

        // Filled client-side from api/Product
        public string ProductName { get; set; }

        public int RemainingQty
        {
            get { return RequestedQty - FulfilledQty; }
        }

        // Qty the approver wants to send in this fulfillment round
        public int FulfillQty { get; set; }
    }

    public class FulfillOutletOrderRequest
    {
        public List<FulfillOutletOrderItemRequest> Items { get; set; } = new List<FulfillOutletOrderItemRequest>();
    }

    public class FulfillOutletOrderItemRequest
    {
        public int OutletOrderItemID { get; set; }
        public int FulfilledQty { get; set; }
    }
}
