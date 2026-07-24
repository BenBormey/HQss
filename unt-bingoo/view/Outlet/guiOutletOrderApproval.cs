using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutletOrderApproval : XtraForm
    {
        private APIsController _api;
        private List<OutletOrderModel> _allOrders = new List<OutletOrderModel>();
        private Dictionary<int, string> _outletNames = new Dictionary<int, string>();
        private Dictionary<string, string> _productNames = new Dictionary<string, string>();

        public guiOutletOrderApproval()
        {
            InitializeComponent();
        }

        private async void guiOutletOrderApproval_Load(object sender, EventArgs e)
        {
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                if (!APIGlobals.HasPermission("OUTLET_ORDER"))
                {
                    XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                cboStatus.SelectedIndex = 1; // default filter: Requested (waiting for approval)

                await LoadLookupsAsync();
                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLookupsAsync()
        {
            var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet")
                          ?? new List<OutletItem>();
            _outletNames = outlets.ToDictionary(o => o.Id, o => o.OutletName);

            var products = await _api.GetAsync<List<ProductItem>>("api/Product")
                           ?? new List<ProductItem>();
            _productNames = products
                .Where(p => !string.IsNullOrEmpty(p.ProNumY))
                .GroupBy(p => p.ProNumY)
                .ToDictionary(g => g.Key, g => g.First().ProName);
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await _api.GetAsync<List<OutletOrderModel>>("api/OutletOrder")
                             ?? new List<OutletOrderModel>();

                foreach (var o in orders)
                {
                    o.OutletName = _outletNames.TryGetValue(o.OutletID, out var name)
                        ? name
                        : $"Outlet #{o.OutletID}";
                }

                _allOrders = orders;

                ApplyStatusFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyStatusFilter()
        {
            string status = cboStatus.SelectedItem?.ToString() ?? "All";

            var list = status == "All"
                ? _allOrders
                : _allOrders.Where(o => o.Status == status).ToList();

            gridControlOrders.DataSource = list;
            gridViewOrders.BestFitColumns();
            lblCountRow.Text = list.Count.ToString("N0");

            gridControlItems.DataSource = null;
        }

        private OutletOrderModel FocusedOrder()
        {
            return gridViewOrders.GetFocusedRow() as OutletOrderModel;
        }

        private async void gridViewOrders_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            await LoadItemsForFocusedOrderAsync();
        }

        private async Task LoadItemsForFocusedOrderAsync()
        {
            var order = FocusedOrder();

            if (order == null)
            {
                gridControlItems.DataSource = null;
                return;
            }

            try
            {
                // GetById returns the order with its items populated.
                var full = await _api.GetAsync<OutletOrderModel>($"api/OutletOrder/{order.OutletOrderID}");

                var items = full?.OutletOrderItems ?? new List<OutletOrderItemModel>();

                foreach (var it in items)
                {
                    it.ProductName = _productNames.TryGetValue(it.ProNumY, out var name)
                        ? name
                        : "";
                    it.FulfillQty = it.RemainingQty; // default: send everything remaining
                }

                gridControlItems.DataSource = items;
                gridViewItems.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private async void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_allOrders.Count > 0 || cboStatus.Focused)
                ApplyStatusFilter();
            await Task.CompletedTask;
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            var order = FocusedOrder();

            if (order == null)
            {
                XtraMessageBox.Show("Please select an order first.");
                return;
            }

            if (order.Status != "Requested")
            {
                XtraMessageBox.Show(
                    $"Only orders with status 'Requested' can be approved.\nThis order is '{order.Status}'.",
                    "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                    $"Approve order '{order.OutletOrderNo}' for outlet '{order.OutletName}'?",
                    "Confirm Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await UpdateStatusAsync(order.OutletOrderID, "Approved");
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            var order = FocusedOrder();

            if (order == null)
            {
                XtraMessageBox.Show("Please select an order first.");
                return;
            }

            if (order.Status != "Requested")
            {
                XtraMessageBox.Show(
                    $"Only orders with status 'Requested' can be rejected.\nThis order is '{order.Status}'.",
                    "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                    $"Reject order '{order.OutletOrderNo}' for outlet '{order.OutletName}'?",
                    "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await UpdateStatusAsync(order.OutletOrderID, "Rejected");
        }

        private async Task UpdateStatusAsync(int orderId, string status)
        {
            try
            {
                bool ok = await _api.PutAsync(
                    $"api/OutletOrder/status/{orderId}?status={status}",
                    new { });

                if (!ok)
                {
                    XtraMessageBox.Show("Update failed.");
                    return;
                }

                XtraMessageBox.Show($"Order {status.ToLower()} successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFulfill_Click(object sender, EventArgs e)
        {
            var order = FocusedOrder();

            if (order == null)
            {
                XtraMessageBox.Show("Please select an order first.");
                return;
            }

            if (order.Status != "Approved" && order.Status != "PartiallyFulfilled")
            {
                XtraMessageBox.Show(
                    $"Only 'Approved' or 'PartiallyFulfilled' orders can be processed.\nThis order is '{order.Status}'.\n\nApprove the order first.",
                    "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            gridViewItems.PostEditor();
            gridViewItems.UpdateCurrentRow();

            var items = (gridControlItems.DataSource as List<OutletOrderItemModel>)
                        ?? new List<OutletOrderItemModel>();

            var toSend = items.Where(i => i.FulfillQty > 0).ToList();

            if (toSend.Count == 0)
            {
                XtraMessageBox.Show("Enter a 'Fulfill Now' quantity for at least one item.");
                return;
            }

            var invalid = toSend.FirstOrDefault(i => i.FulfillQty > i.RemainingQty);
            if (invalid != null)
            {
                XtraMessageBox.Show(
                    $"'{invalid.ProNumY}' — Fulfill Now ({invalid.FulfillQty}) cannot exceed Remaining ({invalid.RemainingQty}).",
                    "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                    $"Process {toSend.Count} item(s) for order '{order.OutletOrderNo}'?\n" +
                    "Stock will move from the Warehouse to the outlet.",
                    "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var dto = new FulfillOutletOrderRequest
                {
                    Items = toSend.Select(i => new FulfillOutletOrderItemRequest
                    {
                        OutletOrderItemID = i.OutletOrderItemID,
                        FulfilledQty = i.FulfillQty
                    }).ToList()
                };

                bool ok = await _api.PostAsync($"api/OutletOrder/fulfill/{order.OutletOrderID}", dto);

                if (!ok)
                    return; // error message already shown by PostAsync

                XtraMessageBox.Show("Order processed successfully. Stock has been transferred.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
