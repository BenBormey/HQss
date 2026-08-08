using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Product
{
    public partial class guiRecipes : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;
        private List<ProductItem> _products = new List<ProductItem>();
        private List<RecipeModel> _allRecipes = new List<RecipeModel>();
        private BindingList<RecipeItemModel> _currentItems = new BindingList<RecipeItemModel>();

        // ProNumY -> best-known selling price, from any outlet's MenuItem.
        // Recipes aren't outlet-scoped, so this is a best-effort estimate for
        // the cost/margin summary, not an authoritative per-outlet price.
        private Dictionary<string, decimal> _menuPrices = new Dictionary<string, decimal>();

        // null = creating a new recipe; otherwise the RecipeId currently loaded for edit.
        private int? _editingRecipeId = null;

        // The ProNumY of the recipe currently being edited, if any — kept
        // visible in cboProduct even though it "already has a recipe" (itself).
        private string _editingProNumY = null;

        private static readonly Color ColorOk = Color.FromArgb(234, 247, 238);
        private static readonly Color ColorOkText = Color.FromArgb(14, 122, 56);
        private static readonly Color ColorWarn = Color.FromArgb(255, 246, 228);
        private static readonly Color ColorWarnText = Color.FromArgb(138, 65, 6);
        private static readonly Color ColorErr = Color.FromArgb(253, 236, 236);
        private static readonly Color ColorErrText = Color.FromArgb(176, 30, 30);

        public guiRecipes()
        {
            InitializeComponent();

            _api = APIGlobals.Api;

            gridIngredients.DataSource = _currentItems;
            _currentItems.ListChanged += (s, e) => RenumberAndRefresh();

            // Set here rather than in the Designer: the WinForms designer's
            // serializer doesn't reliably round-trip a custom Caption on an
            // EditorButton set via an object initializer in InitializeComponent.
            if (btnDuplicateIngredient.Buttons.Count > 0)
                btnDuplicateIngredient.Buttons[0].Caption = "Copy";

            // The API's ProNumY key can't be changed after a recipe is created,
            // and IsActive is only ever changed through the dedicated button
            // (a separate PATCH endpoint), so it's shown but not hand-edited.
            chkActive.Enabled = false;

            this.Load += guiRecipes_Load;
            btnAddIngredient.Click += btnAddIngredient_Click;
            btnDuplicateIngredient.ButtonClick += btnDuplicateIngredient_ButtonClick;
            btnRemoveIngredient.ButtonClick += btnRemoveIngredient_ButtonClick;
            btnSaveRecipe.Click += btnSaveRecipe_Click;
            btnNewRecipe.Click += btnNewRecipe_Click;
            btnToggleActive.Click += btnToggleActive_Click;
            btnRefresh.Click += btnRefresh_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            gvRecipes.DoubleClick += gvRecipes_DoubleClick;
            btnGridDelete.ButtonClick += btnGridDelete_ButtonClick;
            gvIngredients.CellValueChanged += GvIngredients_CellValueChanged;
            cboProduct.SelectedIndexChanged += (s, e) => RefreshSummary();
            txtSearchAllProducts.TextChanged += (s, e) => ApplyAllProductsFilter();
        }

        private async void guiRecipes_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            await LoadProducts();
            await LoadMenuPrices();
            await LoadRecipes();
            ClearForm();
        }

        private async Task LoadProducts()
        {
            try
            {
                _products = await _api.GetAsync<List<ProductItem>>("api/product") ?? new List<ProductItem>();

                // Only products flagged as raw materials belong here — not
                // the whole catalog (e.g. "coca cola" isn't an ingredient of
                // anything). Also a separate list instance so the two combos
                // don't share one BindingContext position (they'd otherwise
                // move in lockstep).
                cboIngredient.DataSource = _products.Where(p => p.IsIngredient).ToList();
                cboIngredient.DisplayMember = "desiplyname";
                cboIngredient.ValueMember = "ProNumY";
                cboIngredient.SelectedIndex = -1;

                // Reference list: every product, ingredient or sellable, so
                // the whole catalog is visible at a glance while a recipe is
                // being built (colAllProdType shows which is which).
                ApplyAllProductsFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void ApplyAllProductsFilter()
        {
            var keyword = txtSearchAllProducts.Text.Trim();

            var list = string.IsNullOrWhiteSpace(keyword)
                ? _products
                : _products.Where(p =>
                    (p.ProNumY ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.ProName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            gridAllProducts.DataSource = list;
            gvAllProducts.BestFitColumns();
        }

        // Best-effort selling price per product, used only for the cost/
        // margin summary. A recipe has no outlet of its own, so this takes
        // whichever active MenuItem price turns up first across outlets —
        // it's an estimate, and the summary labels it as such.
        private async Task LoadMenuPrices()
        {
            try
            {
                var items = await _api.GetAsync<List<MenuItems>>("api/MenuItem") ?? new List<MenuItems>();

                _menuPrices = items
                    .Where(m => m.IsActive && m.SellingPrice > 0)
                    .GroupBy(m => m.ProNumY)
                    .ToDictionary(g => g.Key, g => g.First().SellingPrice);
            }
            catch
            {
                // Non-fatal: the summary just shows "—" for selling price/margin
                // if this couldn't be loaded. Recipe editing itself doesn't need it.
                _menuPrices = new Dictionary<string, decimal>();
            }
        }

        private async Task LoadRecipes()
        {
            try
            {
                var list = await _api.GetAsync<List<RecipeModel>>("api/recipe") ?? new List<RecipeModel>();

                foreach (var r in list)
                {
                    r.ProductName = _products.FirstOrDefault(p => p.ProNumY == r.ProNumY)?.ProName ?? r.ProNumY;

                    // The list endpoint only returns headers — fetch each
                    // recipe's ingredients too so the grid's auto-detail
                    // expander (the "+") actually has rows to show.
                    var full = await _api.GetAsync<RecipeModel>($"api/recipe/{r.RecipeId}");

                    if (full != null)
                    {
                        r.RecipeItems = full.RecipeItems;

                        // The API only returns IngredientProNumY (a bare
                        // code) — resolve it to a display name here, same
                        // as ProductName above, so the detail grid doesn't
                        // just show cryptic codes like "TEST-SUGAR". Cost
                        // is missing for the same reason (Unit Cost/Subtotal
                        // showed as 0.0000 for every row).
                        foreach (var item in r.RecipeItems)
                        {
                            item.IngredientName = _products
                                .FirstOrDefault(p => p.ProNumY == item.IngredientProNumY)?.ProName
                                ?? item.IngredientProNumY;
                            item.UnitCost = CostOf(item.IngredientProNumY);
                            item.Unit = UnitOf(item.IngredientProNumY);
                        }
                    }
                }

                _allRecipes = list;

                PopulateProductCombo();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading recipes: " + ex.Message);
            }
        }

        // A product can only have one recipe (the server rejects a second),
        // so once it has one, hide it here — trying to pick it again would
        // just fail on Save. The recipe currently loaded for edit is the one
        // exception: its own product must stay selectable/visible.
        private void PopulateProductCombo()
        {
            var takenProNumYs = _allRecipes
                .Where(r => r.ProNumY != _editingProNumY)
                .Select(r => r.ProNumY)
                .ToHashSet();

            var available = _products
                .Where(p => !p.IsIngredient && !takenProNumYs.Contains(p.ProNumY))
                .ToList();

            cboProduct.DataSource = available;
            cboProduct.DisplayMember = "desiplyname";
            cboProduct.ValueMember = "ProNumY";
            cboProduct.SelectedIndex = -1;
        }

        private void ApplyFilter()
        {
            var keyword = txtSearch.Text.Trim();

            var list = string.IsNullOrWhiteSpace(keyword)
                ? _allRecipes
                : _allRecipes.Where(r =>
                    (r.ProNumY ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (r.ProductName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (r.Name ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            gridRecipes.DataSource = list;

            // RecipeModel exposes RecipeItems as a public list, which DevExpress
            // auto-detects and turns into an unformatted "+" detail grid (raw
            // column names, blank Ingredient Name — it's never populated for
            // rows other than the one currently loaded for edit). Double-clicking
            // a row already opens a properly formatted ingredient list above,
            // so this auto-generated one is just clutter — remove it.
            gridRecipes.LevelTree.Nodes.Clear();

            gvRecipes.BestFitColumns();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadMenuPrices();
            await LoadRecipes();
            RefreshSummary();
        }

        // Same approach as SetupOutletMenu's "Export Excel" — a true print
        // preview (Print/PDF/etc. in one dialog) needs DevExpress's Reports
        // engine, which this project doesn't reference. Exporting the grid
        // as it's currently shown (respects the active search filter) is
        // the equivalent this project already has proven working elsewhere.
        private void btnPrintRecipes_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel File (*.xlsx)|*.xlsx",
                    Title = "Export Recipes to Excel",
                    FileName = "Recipes.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var options = new XlsxExportOptionsEx
                    {
                        ExportType = ExportType.WYSIWYG,
                        SheetName = "Recipes"
                    };

                    gridRecipes.ExportToXlsx(saveFileDialog.FileName, options);

                    XtraMessageBox.Show("Export successful!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CostOf(string proNumY)
        {
            return _products.FirstOrDefault(p => p.ProNumY == proNumY)?.ProImpPri ?? 0m;
        }

        private string UnitOf(string proNumY)
        {
            return _products.FirstOrDefault(p => p.ProNumY == proNumY)?.ProductScale?.UOMCode ?? "";
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            var ingredient = cboIngredient.SelectedItem as ProductItem;

            if (ingredient == null)
            {
                XtraMessageBox.Show("Please select an ingredient.");
                return;
            }

            var product = cboProduct.SelectedItem as ProductItem;

            if (product != null && ingredient.ProNumY == product.ProNumY)
            {
                XtraMessageBox.Show("A product cannot be its own ingredient.");
                return;
            }

            if (!decimal.TryParse(txtQty.Text.Trim(), out decimal qty) || qty <= 0)
            {
                XtraMessageBox.Show("Please enter a valid quantity greater than zero.");
                return;
            }

            if (_currentItems.Any(i => i.IngredientProNumY == ingredient.ProNumY))
            {
                XtraMessageBox.Show("This ingredient is already in the list. Remove it first to change the quantity.");
                return;
            }

            _currentItems.Add(new RecipeItemModel
            {
                IngredientProNumY = ingredient.ProNumY,
                IngredientName = ingredient.ProName,
                Qty = qty,
                Remark = txtIngRemark.Text.Trim(),
                UnitCost = ingredient.ProImpPri ?? 0m,
                Unit = ingredient.ProductScale?.UOMCode ?? ""
            });

            cboIngredient.SelectedIndex = -1;
            txtQty.Text = string.Empty;
            txtIngRemark.Text = string.Empty;
        }

        // Deliberately unguarded against duplicates — this is the one place a
        // duplicate ingredient can be created on purpose (e.g. wanting the
        // same ingredient at a different quantity for a variant), and the
        // validation banner below is what catches and flags it immediately.
        private void btnDuplicateIngredient_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var line = gvIngredients.GetFocusedRow() as RecipeItemModel;

            if (line == null)
                return;

            _currentItems.Add(new RecipeItemModel
            {
                IngredientProNumY = line.IngredientProNumY,
                IngredientName = line.IngredientName,
                Qty = line.Qty,
                Remark = line.Remark,
                UnitCost = line.UnitCost,
                Unit = line.Unit
            });
        }

        private void btnRemoveIngredient_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var line = gvIngredients.GetFocusedRow() as RecipeItemModel;

            if (line == null)
                return;

            _currentItems.Remove(line);
        }

        private void GvIngredients_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // Qty is the only inline-editable column; recompute live the
            // moment it changes rather than waiting for focus to leave the cell.
            gvIngredients.RefreshData();
            RefreshSummary();
            RefreshValidationBanner();
        }

        private void RenumberAndRefresh()
        {
            for (int i = 0; i < _currentItems.Count; i++)
                _currentItems[i].RowNo = i + 1;

            RefreshSummary();
            RefreshValidationBanner();
        }

        // ---- Live cost calculation (Section 3 / 7 of the design brief) ----
        private void RefreshSummary()
        {
            var totalCost = _currentItems.Sum(i => i.Subtotal);
            lblKpiCountVal.Text = _currentItems.Count.ToString();
            lblKpiCostVal.Text = "$" + totalCost.ToString("0.00");

            var product = cboProduct.SelectedItem as ProductItem;
            decimal? price = null;

            if (product != null && _menuPrices.TryGetValue(product.ProNumY, out var p))
                price = p;

            if (price.HasValue && price.Value > 0)
            {
                var foodCostPct = totalCost / price.Value * 100m;
                var profit = price.Value - totalCost;
                var margin = profit / price.Value * 100m;

                lblKpiPriceVal.Text = "$" + price.Value.ToString("0.00");
                lblKpiFoodCostVal.Text = foodCostPct.ToString("0.0") + "%";
                lblKpiProfitVal.Text = "$" + profit.ToString("0.00");
                lblKpiMarginVal.Text = margin.ToString("0.0") + "%";

                var goodColor = Color.FromArgb(14, 122, 56);
                var warnColor = Color.FromArgb(138, 65, 6);
                var badColor = Color.FromArgb(176, 30, 30);

                lblKpiFoodCostVal.Appearance.ForeColor =
                    foodCostPct <= 30 ? goodColor : (foodCostPct <= 40 ? warnColor : badColor);
                lblKpiProfitVal.Appearance.ForeColor = profit >= 0 ? goodColor : badColor;
                lblKpiMarginVal.Appearance.ForeColor = margin >= 0 ? goodColor : badColor;
            }
            else
            {
                lblKpiPriceVal.Text = "—";
                lblKpiFoodCostVal.Text = "—";
                lblKpiProfitVal.Text = "—";
                lblKpiMarginVal.Text = "—";
                var neutral = Color.FromArgb(16, 27, 51);
                lblKpiFoodCostVal.Appearance.ForeColor = neutral;
                lblKpiProfitVal.Appearance.ForeColor = neutral;
                lblKpiMarginVal.Appearance.ForeColor = neutral;
            }
        }

        // ---- Live validation (Section 4 / 8) ----
        // Runs continuously, not just on Save — duplicate ingredients and
        // zero quantities can only be created here through the Duplicate Row
        // button or by editing Qty inline in the grid to 0, so this is the
        // safety net that actually catches them.
        private void RefreshValidationBanner()
        {
            var seen = new Dictionary<string, int>();
            foreach (var i in _currentItems)
            {
                seen.TryGetValue(i.IngredientProNumY, out var count);
                seen[i.IngredientProNumY] = count + 1;
            }

            var messages = new List<string>();
            bool hasError = false;

            foreach (var item in _currentItems)
            {
                if (seen[item.IngredientProNumY] > 1)
                {
                    messages.Add($"{item.IngredientName}: duplicate ingredient (row #{item.RowNo})");
                    hasError = true;
                }

                if (item.Qty <= 0)
                {
                    messages.Add($"{item.IngredientName}: quantity must be greater than 0 (row #{item.RowNo})");
                    hasError = true;
                }
            }

            if (hasError)
            {
                pnlValidation.BackColor = ColorErr;
                lblBanner.Appearance.ForeColor = ColorErrText;
                lblBanner.Text = "Cannot save — " + messages.Count + " issue(s): " + string.Join("  |  ", messages);
            }
            else if (_currentItems.Count == 0)
            {
                pnlValidation.BackColor = ColorWarn;
                lblBanner.Appearance.ForeColor = ColorWarnText;
                lblBanner.Text = "No ingredients yet — add at least one before saving.";
            }
            else
            {
                pnlValidation.BackColor = ColorOk;
                lblBanner.Appearance.ForeColor = ColorOkText;
                lblBanner.Text = _currentItems.Count + " ingredient(s) verified — no duplicates, no zero quantities. Ready to save.";
            }

            btnSaveRecipe.Enabled = !hasError && _currentItems.Count > 0;
        }

        private async void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            var product = cboProduct.SelectedItem as ProductItem;

            if (product == null)
            {
                XtraMessageBox.Show("Please select the product this recipe makes.");
                return;
            }

            if (_currentItems.Count == 0)
            {
                XtraMessageBox.Show("Please add at least one ingredient.");
                return;
            }

            var items = _currentItems.Select(i => new
            {
                IngredientProNumY = i.IngredientProNumY,
                i.Qty,
                i.Remark
            }).ToList();

            try
            {
                bool ok;

                if (_editingRecipeId == null)
                {
                    var dto = new
                    {
                        ProNumY = product.ProNumY,
                        Name = txtName.Text.Trim(),
                        Remark = txtRemark.Text.Trim(),
                        CreatedBy = APIGlobals.UserName,
                        Items = items
                    };

                    ok = await _api.PostAsync("api/recipe", dto);
                }
                else
                {
                    var dto = new
                    {
                        Name = txtName.Text.Trim(),
                        Remark = txtRemark.Text.Trim(),
                        Items = items
                    };

                    ok = await _api.PutAsync($"api/recipe/{_editingRecipeId}", dto);
                }

                if (!ok)
                {
                    XtraMessageBox.Show("Save failed.");
                    return;
                }

                XtraMessageBox.Show(
                    "Recipe saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnGoToOutletMenu.Visible = true;

                ClearForm();
                await LoadRecipes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnNewRecipe_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (_editingRecipeId == null)
            {
                XtraMessageBox.Show("Load an existing recipe first (double-click a row in the list below).");
                return;
            }

            var newActive = !chkActive.Checked;

            try
            {
                var ok = await _api.PatchAsync(
                    $"api/recipe/{_editingRecipeId}/active?isActive={(newActive ? "true" : "false")}");

                if (!ok)
                {
                    XtraMessageBox.Show("Update failed.");
                    return;
                }

                chkActive.Checked = newActive;

                await LoadRecipes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void gvRecipes_DoubleClick(object sender, EventArgs e)
        {
            var recipe = gvRecipes.GetFocusedRow() as RecipeModel;

            if (recipe == null)
                return;

            try
            {
                var full = await _api.GetAsync<RecipeModel>($"api/recipe/{recipe.RecipeId}");

                if (full == null)
                {
                    XtraMessageBox.Show("Failed to load recipe details.");
                    return;
                }

                LoadRecipeIntoForm(full);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadRecipeIntoForm(RecipeModel full)
        {
            _editingRecipeId = full.RecipeId;
            _editingProNumY = full.ProNumY;
            PopulateProductCombo();

            // The product a recipe makes is its identity on the server side
            // (unique per ProNumY) and can't be changed via update.
            cboProduct.Enabled = false;
            SelectComboByValue(cboProduct, full.ProNumY);

            txtRecipeCode.Text = "RCP-" + full.RecipeId.ToString("0000");
            txtName.Text = full.Name;
            txtRemark.Text = full.Remark;
            chkActive.Checked = full.IsActive;

            _currentItems.Clear();

            foreach (var item in full.RecipeItems)
            {
                item.IngredientName =
                    _products.FirstOrDefault(p => p.ProNumY == item.IngredientProNumY)?.ProName
                    ?? item.IngredientProNumY;

                item.UnitCost = CostOf(item.IngredientProNumY);
                item.Unit = UnitOf(item.IngredientProNumY);

                _currentItems.Add(item);
            }

            RefreshSummary();
        }

        private void SelectComboByValue(System.Windows.Forms.ComboBox combo, string proNumY)
        {
            combo.SelectedIndex = -1;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is ProductItem p && p.ProNumY == proNumY)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        private async void btnGridDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var recipe = gvRecipes.GetFocusedRow() as RecipeModel;

            if (recipe == null)
                return;

            if (MessageBox.Show(
                    $"Are you sure you want to delete the recipe for '{recipe.ProductName ?? recipe.ProNumY}'?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var ok = await _api.DeleteAsync($"api/recipe/{recipe.RecipeId}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed.");
                    return;
                }

                if (_editingRecipeId == recipe.RecipeId)
                    ClearForm();

                await LoadRecipes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            _editingRecipeId = null;
            _editingProNumY = null;
            PopulateProductCombo();

            cboProduct.Enabled = true;
            txtRecipeCode.Text = "Auto";
            txtName.Text = string.Empty;
            txtRemark.Text = string.Empty;
            chkActive.Checked = true;

            cboIngredient.SelectedIndex = -1;
            txtQty.Text = string.Empty;
            txtIngRemark.Text = string.Empty;

            _currentItems.Clear();
            RefreshSummary();
            RefreshValidationBanner();
        }

        private void guiRecipes_Load_1(object sender, EventArgs e)
        {

        }

        private void btnGoToOutletMenu_Click(object sender, EventArgs e)
        {
            var frm = new SetupOutletMenu
            {
                MdiParent = this.MdiParent,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }
    }
}
