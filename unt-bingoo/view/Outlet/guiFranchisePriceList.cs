using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    // Standing prices for a franchise outlet's products, so Outlet Order Ship
    // Now (guiOutletOrderApproval) and Ingredient Transfer (guiStockTransfer)
    // can pre-fill UnitPrice instead of it being retyped every transaction.
    // The pre-filled value stays editable at the point of use — this is a
    // default, not a locked rate.
    public partial class guiFranchisePriceList : XtraForm
    {
        private APIsController _api;
        private List<FranchisePriceItem> _allPrices = new List<FranchisePriceItem>();

        // Real franchise outlets only — no "All" sentinel — so the bulk-apply
        // path in btnSave_Click has something to loop over.
        private List<OutletItem> _franchiseOutlets = new List<OutletItem>();

        // Synthetic entry prepended to cboOutlet. Id 0 can't collide with a
        // real Outlet.Id (identity columns start at 1), so btnSave_Click uses
        // that as the "apply to every franchise outlet" signal.
        private const int AllOutletsId = 0;

        // editid null = "ADD" mode; otherwise the Id of the row being edited.
        private int? editId = null;

        public guiFranchisePriceList()
        {
            InitializeComponent();
        }

        private async void guiFranchisePriceList_Load(object sender, EventArgs e)
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

                await LoadLookupsAsync();

                cboProduct.SelectedIndexChanged += (s, ev) => UpdateProductFields();

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task LoadLookupsAsync()
        {
            var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet") ?? new List<OutletItem>();

            // api/Franchise doesn't expose the real numeric OutletId (only a
            // separate legacy "outlet code" field), so franchise-ness is
            // joined here by OutletName against api/Outlet's real Id — the
            // same rule the backend uses (FranchiseTypeId == 7), just applied
            // client-side since there's no "list franchise outlets" endpoint.
            var franchises = await _api.GetAsync<List<Franchise>>("api/Franchise") ?? new List<Franchise>();
            var franchiseOutletNames = franchises
                .Where(f => f.franchiseTypeId == 7)
                .Select(f => f.outletName)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            _franchiseOutlets = outlets
                .Where(o => franchiseOutletNames.Contains(o.OutletName))
                .ToList();

            var outletChoices = new List<OutletItem>
            {
                new OutletItem { Id = AllOutletsId, OutletName = "-- All Franchise Outlets --" }
            };
            outletChoices.AddRange(_franchiseOutlets);

            cboOutlet.DataSource = outletChoices;
            cboOutlet.DisplayMember = "OutletName";
            cboOutlet.ValueMember = "Id";
            cboOutlet.SelectedIndex = -1;

            var products = await _api.GetAsync<List<ProductItem>>("api/Product") ?? new List<ProductItem>();

            // A recipe-made drink (Cappuccino, Iced Americano, Ice Latte) is
            // assembled at the outlet from ingredients that are shipped — the
            // drink itself never moves, so there is nothing to charge a
            // franchise for and it has no business being priced here.
            // RecipeInfo is declared by guiAssignStock in this same namespace.
            var recipes = await _api.GetAsync<List<RecipeInfo>>("api/recipe") ?? new List<RecipeInfo>();

            var recipeProducts = new HashSet<string>(
                recipes.Where(r => r.IsActive && r.RecipeItems != null && r.RecipeItems.Count > 0)
                       .Select(r => r.ProNumY),
                StringComparer.OrdinalIgnoreCase);

            products = products
                .Where(p => !recipeProducts.Contains(p.ProNumY))
                .ToList();

            cboProduct.DataSource = products;
            cboProduct.DisplayMember = "desiplyname";
            cboProduct.ValueMember = "ProNumY";
            cboProduct.SelectedIndex = -1;
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            _allPrices = await _api.GetAsync<List<FranchisePriceItem>>("api/FranchisePriceList")
                         ?? new List<FranchisePriceItem>();

            grdPrice.DataSource = _allPrices;
            lblCount.Text = "Total Records: " + _allPrices.Count;
        }

        // Fills the read-only context for the product being priced. "0.63" on
        // its own doesn't say per can or per case, and it doesn't say what the
        // item cost either — both are known the moment a product is picked, so
        // there's no reason to make the price be set blind.
        private void UpdateProductFields()
        {
            var product = cboProduct.SelectedItem as ProductItem;

            var unit = product?.ProUnit;
            txtUnit.Text = string.IsNullOrWhiteSpace(unit) ? string.Empty : unit;

            lblUnitPrice.Text = string.IsNullOrWhiteSpace(unit)
                ? "Unit Price"
                : "Unit Price (per " + unit + ")";

            if (product == null)
            {
                txtCostPrice.Text = string.Empty;
                return;
            }

            // តម្លៃទិញចូល — Total Buyin (ProFinBuyin) as shown on Product
            // Management, falling back to the raw Buyin (ProImpPri). NOT
            // ProUPriBY: every product save path writes that column as a
            // literal 0, so it always read 0.00 here.
            //
            // A zero is still called out rather than shown as a clean 0.00 — it
            // means no buy-in price was entered, not that the item is free, and
            // a franchise price set against it would be guesswork.
            var cost = product.ProFinBuyin ?? 0m;
            if (cost == 0m) cost = product.ProImpPri ?? 0m;

            txtCostPrice.Text = cost > 0
                ? cost.ToString("0.0000")
                : "0.00  (not set)";

            txtCostPrice.Properties.Appearance.ForeColor = cost > 0
                ? System.Drawing.Color.FromArgb(17, 24, 39)
                : System.Drawing.Color.FromArgb(180, 83, 9);

            txtCostPrice.Properties.Appearance.Options.UseForeColor = true;
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                XtraMessageBox.Show("Please select a franchise outlet.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboOutlet.Focus();
                return;
            }

            if (!(cboProduct.SelectedItem is ProductItem product))
            {
                XtraMessageBox.Show("Please select a product.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProduct.Focus();
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                XtraMessageBox.Show("Please enter a valid Unit Price greater than 0.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitPrice.Focus();
                return;
            }

            if (outlet.Id == AllOutletsId)
            {
                // "All Outlets" is a create-time bulk action, not a single
                // row — doesn't make sense combined with editing one.
                if (editId != null)
                {
                    XtraMessageBox.Show(
                        "Cannot apply 'All Franchise Outlets' while editing a single row. Clear the form first.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await SaveForAllOutletsAsync(product, price);
                return;
            }

            // Client-side duplicate check first (fast feedback); the server
            // re-checks the same rule as a backstop and returns Conflict if
            // this ever gets out of sync. In ADD mode an INACTIVE existing
            // row isn't a conflict — the server reactivates it instead — so
            // only an ACTIVE one blocks here. In EDIT mode the unique
            // constraint applies regardless of active status (moving a row
            // onto an already-occupied key is never allowed), so any other
            // row at that key blocks, active or not.
            bool duplicate = _allPrices.Any(p =>
                p.OutletId == outlet.Id &&
                string.Equals(p.ProNumY, product.ProNumY, StringComparison.OrdinalIgnoreCase) &&
                (editId == null || p.Id != editId.Value) &&
                (editId != null || p.IsActive));

            if (duplicate)
            {
                XtraMessageBox.Show(
                    $"A price already exists for '{outlet.OutletName}' and '{product.ProName}'. Edit that row instead.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (editId == null)
                {
                    var payload = new
                    {
                        OutletId = outlet.Id,
                        ProNumY = product.ProNumY,
                        UnitPrice = price,
                        UpdatedBy = APIGlobals.UserName
                    };

                    var ok = await _api.PostAsync("api/FranchisePriceList", payload);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Save failed.");
                        return;
                    }

                    XtraMessageBox.Show("Saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var payload = new
                    {
                        Id = editId.Value,
                        OutletId = outlet.Id,
                        ProNumY = product.ProNumY,
                        UnitPrice = price,
                        UpdatedBy = APIGlobals.UserName
                    };

                    var ok = await _api.PutAsync($"api/FranchisePriceList/{editId.Value}", payload);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed.");
                        return;
                    }

                    XtraMessageBox.Show("Record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
                return;
            }

            ClearForm();
            await LoadDataAsync();
        }

        // One POST per franchise outlet, same product + price. The server's
        // Create logic (not a client-side pre-check — it needs to be
        // authoritative here) skips outlets that already have an ACTIVE
        // price for this product rather than overwriting it — Edit is the
        // path for changing an existing one — but reactivates an inactive
        // one with this price, which counts as "added" here.
        private async System.Threading.Tasks.Task SaveForAllOutletsAsync(ProductItem product, decimal price)
        {
            if (_franchiseOutlets.Count == 0)
            {
                XtraMessageBox.Show("No franchise outlets found.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int added = 0, skipped = 0, failed = 0;

            foreach (var fOutlet in _franchiseOutlets)
            {
                bool activeDuplicate = _allPrices.Any(p =>
                    p.OutletId == fOutlet.Id &&
                    p.IsActive &&
                    string.Equals(p.ProNumY, product.ProNumY, StringComparison.OrdinalIgnoreCase));

                if (activeDuplicate)
                {
                    skipped++;
                    continue;
                }

                try
                {
                    var payload = new
                    {
                        OutletId = fOutlet.Id,
                        ProNumY = product.ProNumY,
                        UnitPrice = price,
                        UpdatedBy = APIGlobals.UserName
                    };

                    var ok = await _api.PostAsync("api/FranchisePriceList", payload);

                    if (ok)
                        added++;
                    else
                        failed++;
                }
                catch
                {
                    failed++;
                }
            }

            XtraMessageBox.Show(
                $"Added {added} price(s) for '{product.ProName}'.\n" +
                $"Skipped {skipped} outlet(s) that already had a price." +
                (failed > 0 ? $"\n{failed} failed." : ""),
                "All Outlets", MessageBoxButtons.OK,
                failed > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

            ClearForm();
            await LoadDataAsync();
        }

        private void btnRowUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdPrice.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view?.GetFocusedRow() is FranchisePriceItem row)
            {
                editId = row.Id;

                cboOutlet.SelectedValue = row.OutletId;
                cboProduct.SelectedValue = row.ProNumY;
                txtUnitPrice.Text = row.UnitPrice.ToString("0.####");

                btnSave.Text = "UPDATE";
                btnClear.Visible = true;
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record to update.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Deactivate/Reactivate, not a hard delete — the row (and its
        // UpdatedAt/By history) stays put. Ship Now / Ingredient Transfer /
        // the outlet order-request pre-fill all skip an inactive price as if
        // it didn't exist. Re-adding the same outlet+product from this
        // screen's ADD form also reactivates it, so this button is really
        // just the quick path for the common case.
        private async void btnRowToggleActive_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdPrice.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (!(view?.GetFocusedRow() is FranchisePriceItem row))
            {
                XtraMessageBox.Show("Please select a row.");
                return;
            }

            bool activating = !row.IsActive;
            string action = activating ? "Reactivate" : "Deactivate";

            if (XtraMessageBox.Show(
                    $"{action} the price for '{row.OutletName}' / '{row.ProductName}'?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var payload = new { IsActive = activating, UpdatedBy = APIGlobals.UserName };
                var ok = await _api.PutAsync($"api/FranchisePriceList/{row.Id}/active", payload);

                if (!ok)
                {
                    XtraMessageBox.Show(action + " failed.");
                    return;
                }

                if (editId == row.Id)
                    ClearForm();

                await LoadDataAsync();

                XtraMessageBox.Show(action + "d successfully!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            editId = null;

            cboOutlet.SelectedIndex = -1;
            cboProduct.SelectedIndex = -1;
            txtUnitPrice.Text = string.Empty;

            UpdateProductFields();

            btnSave.Text = "ADD";
            btnClear.Visible = false;
        }
    }
}
