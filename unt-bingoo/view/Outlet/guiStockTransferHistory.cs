using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    // Split out of guiStockTransfer, which was getting crowded once the
    // batch "Items to Transfer" list was added — this is just the
    // search/filter + history grid half of that screen, standing alone.
    // TransferHistoryRow is declared in guiStockTransfer.cs (same namespace).
    public partial class guiStockTransferHistory : XtraForm
    {
        private APIsController _api;

        public guiStockTransferHistory()
        {
            InitializeComponent();
        }

        private async void guiStockTransferHistory_Load(object sender, EventArgs e)
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

                if (!APIGlobals.HasPermission("OUTLET_STOCK"))
                {
                    XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                btnRefresh.Click += async (s, ev) => await LoadHistoryAsync();
                cboFilterOutlet.SelectedIndexChanged += async (s, ev) => await LoadHistoryAsync();
                cboFilterCategory.SelectedIndexChanged += async (s, ev) => await LoadHistoryAsync();
                txtSearch.KeyDown += async (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter)
                    {
                        ev.SuppressKeyPress = true;
                        await LoadHistoryAsync();
                    }
                };

                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;

                await LoadFilterLookupsAsync();
                await LoadHistoryAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadFilterLookupsAsync()
        {
            var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet") ?? new List<OutletItem>();

            // Same rule as the transfer form: the warehouse (HeadOffice)
            // is never a transfer destination, so it never shows up here.
            var destinationOutlets = outlets.Where(o => o.IsActive && !o.HeadOffice).ToList();

            var filterOutlets = new List<OutletItem> { new OutletItem { Id = 0, OutletName = "All Outlets" } };
            filterOutlets.AddRange(destinationOutlets);
            cboFilterOutlet.DataSource = filterOutlets;
            cboFilterOutlet.DisplayMember = "OutletName";
            cboFilterOutlet.ValueMember = "Id";
            cboFilterOutlet.SelectedIndex = 0;

            var categories = await _api.GetAsync<List<CategoryItem>>("api/category") ?? new List<CategoryItem>();
            var filterCategories = new List<CategoryItem> { new CategoryItem { Id = 0, CategoryName = "All Categories" } };
            filterCategories.AddRange(categories);
            cboFilterCategory.DataSource = filterCategories;
            cboFilterCategory.DisplayMember = "CategoryName";
            cboFilterCategory.ValueMember = "Id";
            cboFilterCategory.SelectedIndex = 0;
        }

        private async Task LoadHistoryAsync()
        {
            try
            {
                int? outletId = (cboFilterOutlet.SelectedItem as OutletItem)?.Id;
                if (outletId == 0) outletId = null;

                int? categoryId = (cboFilterCategory.SelectedItem as CategoryItem)?.Id;
                if (categoryId == 0) categoryId = null;

                var url = "api/IngredientStockTransfer/history"
                    + $"?fromDate={dtpFrom.Value:yyyy-MM-dd}"
                    + $"&toDate={dtpTo.Value:yyyy-MM-dd}";

                if (outletId.HasValue)
                    url += $"&outletId={outletId.Value}";

                if (categoryId.HasValue)
                    url += $"&categoryId={categoryId.Value}";

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    url += $"&search={Uri.EscapeDataString(txtSearch.Text.Trim())}";

                var rows = await _api.GetAsync<List<TransferHistoryRow>>(url) ?? new List<TransferHistoryRow>();

                gridHistory.DataSource = rows;
                lblCount.Text = $"Total Records: {rows.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
