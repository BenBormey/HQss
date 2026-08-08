using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using Excel = Microsoft.Office.Interop.Excel;

namespace unt_bingoo.view.Outlet
{
    public partial class guiAssignStock : XtraForm
    {
        private APIsController _api;
        private List<ProductItem> _products = new List<ProductItem>();

        // Products whose sale is resolved through an active Recipe. Checkout
        // never reads their own OutletStock — it deducts their ingredients —
        // so assigning stock to one is a silent no-op and it has no business
        // being offered as a stockable item.
        private HashSet<string> _recipeProducts =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Staged lines. Assign writes an ABSOLUTE quantity (OutletStockQueries.
        // AssignStock does SET StockQty = @Quantity), so the old one-click flow
        // overwrote a stock figure irreversibly per product with no document to
        // check afterwards. Nothing here reaches the API until Save && Print —
        // the same staging model as guiStockTransfer.
        private readonly BindingList<PendingAssignLine> _pendingItems =
            new BindingList<PendingAssignLine>();

        private DevExpress.XtraEditors.PanelControl pnlPending;
        private DevExpress.XtraGrid.GridControl gridPending;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPending;
        private Button btnSavePrint;
        private Button btnClearList;
        private DevExpress.XtraEditors.LabelControl lblPendingHeader;

        // Rebinding cboProduct.DataSource raises SelectedIndexChanged, which
        // would otherwise fire a recipe lookup against a selection the user
        // never made.
        private bool _suppressProductChanged;

        public guiAssignStock()
        {
            InitializeComponent();

            // Wired here rather than in Load: Load bails out early when the
            // user lacks OUTLET_STOCK, and Back has to work regardless.
            btnBack.Click += (s, ev) => Close();
        }

        private async void guiAssignStock_Load(object sender, EventArgs e)
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

                cboOutlet.SelectedIndexChanged += cboOutlet_SelectedIndexChanged;
                rdoIngredients.CheckedChanged += ProductFilterChanged;
                rdoSellable.CheckedChanged += ProductFilterChanged;
                rdoAll.CheckedChanged += ProductFilterChanged;

                cboProduct.SelectedIndexChanged += async (s, ev) =>
                {
                    if (_suppressProductChanged) return;

                    UpdateCurrentStockDisplay();

                    // Jump straight to the quantity box — picking a product is
                    // always followed by typing one.
                    txtQuantity.Focus();

                    await CheckRecipeWarningAsync();
                };

                // Keeps the "Value After Assign" figure in step with what's
                // being typed, so the cost is visible before the write.
                txtQuantity.TextChanged += (s, ev) => UpdateProductInfoDisplay();
                txtQuantity.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode != Keys.Enter) return;

                    ev.Handled = true;
                    ev.SuppressKeyPress = true;
                    btnAssign.PerformClick();
                };

                EnsurePendingUi();

                btnAssign.Click += btnAssign_Click;
                btnRefresh.Click += async (s, ev) => await LoadStockGridAsync();

                // Stock with no price list is the failure this screen can't
                // otherwise show: the quantity looks healthy, and the cashier
                // is the one who discovers the item can't be rung up.
                gvStock.CustomColumnDisplayText += gvStock_CustomColumnDisplayText;
                gvStock.RowCellStyle += gvStock_RowCellStyle;

                await LoadLookupsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLookupsAsync()
        {
            var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet") ?? new List<OutletItem>();
            var activeOutlets = outlets.Where(o => o.IsActive == true).ToList();

            cboOutlet.DataSource = activeOutlets;
            cboOutlet.DisplayMember = "OutletName";
            cboOutlet.ValueMember = "Id";
            cboOutlet.SelectedIndex = -1;

            // Every product is a candidate here — an outlet can be assigned
            // stock of a sellable item or an ingredient (ingredients still
            // need their own stock; a Recipe just decides what to deduct
            // from at checkout, it doesn't hold stock itself). The radio
            // buttons only narrow the view; nothing is permanently hidden.
            _products = await _api.GetAsync<List<ProductItem>>("api/product") ?? new List<ProductItem>();

            // One call for the whole recipe book rather than one per product —
            // GET api/recipe returns each recipe with its items already loaded.
            var recipes = await _api.GetAsync<List<RecipeInfo>>("api/recipe") ?? new List<RecipeInfo>();

            _recipeProducts = new HashSet<string>(
                recipes.Where(r => r.IsActive && r.RecipeItems != null && r.RecipeItems.Count > 0)
                       .Select(r => r.ProNumY),
                StringComparer.OrdinalIgnoreCase);

            ApplyProductFilter();
        }

        private void ProductFilterChanged(object sender, EventArgs e)
        {
            // CheckedChanged fires twice per switch (one off, one on) — only
            // rebuild the list for the button that just came on.
            if (sender is RadioButton rdo && !rdo.Checked) return;

            ApplyProductFilter();
        }

        // Ingredients are what gets assigned nearly every time, so that is the
        // default view. Sellable stays reachable because a product with no
        // Recipe deducts its own OutletStock at checkout (OrderRepository.
        // ResolveStockDeductionsAsync) and would otherwise have no way to be
        // stocked from this screen.
        private void ApplyProductFilter()
        {
            // "Sellable" means sellable *and* stock-bearing: a drink built from
            // a Recipe is sellable but holds no stock of its own, so listing it
            // would only offer the user a write that does nothing. Ingredients
            // keep their own stock even when they have a recipe, because
            // checkout expands one level only and never recurses into them.
            var filtered = _products.Where(p =>
                    rdoAll.Checked
                    || (rdoIngredients.Checked && p.IsIngredient)
                    || (rdoSellable.Checked && !p.IsIngredient && !_recipeProducts.Contains(p.ProNumY)))
                .ToList();

            _suppressProductChanged = true;
            try
            {
                cboProduct.DataSource = filtered;
                cboProduct.DisplayMember = "desiplyname";
                cboProduct.ValueMember = "ProNumY";
                cboProduct.SelectedIndex = -1;
            }
            finally
            {
                _suppressProductChanged = false;
            }

            pnlRecipeWarning.Visible = false;
            UpdateCurrentStockDisplay();

            var hiddenRecipeCount = rdoSellable.Checked
                ? _products.Count(p => !p.IsIngredient && _recipeProducts.Contains(p.ProNumY))
                : 0;

            lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(124, 133, 158);
            lblStatus.Text = filtered.Count == 0
                ? "No products match this filter."
                : $"{filtered.Count} product(s) listed. Pick one to see its price and current stock."
                  + (hiddenRecipeCount > 0
                      ? $"  ({hiddenRecipeCount} recipe-made product(s) hidden — they deduct ingredients, not their own stock.)"
                      : string.Empty);
        }

        private async void cboOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentStockDisplay();
            await LoadStockGridAsync();
        }

        private List<OutletStockRow> _currentOutletStock = new List<OutletStockRow>();

        // The selected outlet's price list. Reloaded with the grid so the entry
        // card can show a price for a product that has no OutletStock row yet.
        private List<MenuPriceInfo> _outletMenu = new List<MenuPriceInfo>();

        private async Task LoadStockGridAsync()
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                gridStock.DataSource = null;
                _currentOutletStock = new List<OutletStockRow>();
                _outletMenu = new List<MenuPriceInfo>();
                return;
            }

            try
            {
                var rows = await _api.GetAsync<List<OutletStockRow>>($"api/OutletStock/outlet/{outlet.Id}")
                           ?? new List<OutletStockRow>();

                _outletMenu = await _api.GetAsync<List<MenuPriceInfo>>($"api/MenuItem/outlet/{outlet.Id}")
                              ?? new List<MenuPriceInfo>();

                _currentOutletStock = rows;
                gridStock.DataSource = rows;
                gvStock.BestFitColumns();

                UpdateCurrentStockDisplay();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCurrentStockDisplay()
        {
            if (!(cboProduct.SelectedItem is ProductItem product))
            {
                txtCurrentStock.Text = "—";
                lblQuantity.Text = "New Quantity";
                UpdateProductInfoDisplay();
                return;
            }

            var row = _currentOutletStock.FirstOrDefault(r => r.ProNumY == product.ProNumY);

            // Show the unit alongside the number. Without it "10" reads as
            // "10 servings" when it may actually mean 10 grams — which is
            // how an outlet ends up unable to make a single drink despite
            // looking stocked.
            //
            // ProUnit, not ProductScale.UOMCode: StockQty is counted in the
            // stocking unit (g/ml/pcs), while UOMCode is the purchasing
            // packaging unit (CTN, PLT) and would label a gram figure "CTN".
            var unit = product.ProUnit;
            var suffix = string.IsNullOrWhiteSpace(unit) ? "" : " " + unit;

            txtCurrentStock.Text = row != null
                ? row.StockQty.ToString("0.####") + suffix
                : "0 (not yet set)";

            lblQuantity.Text = string.IsNullOrWhiteSpace(unit)
                ? "New Quantity"
                : "New Quantity (" + unit + ")";

            UpdateProductInfoDisplay();
        }

        private void gvStock_CustomColumnDisplayText(object sender,
            DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column != colStockSellPrice) return;

            var row = StockRowAt(e.ListSourceRowIndex);
            if (row == null) return;

            // A blank price on an ingredient is correct — it is never sold on
            // its own — so only a sellable product is worth flagging.
            e.DisplayText = row.IsIngredient
                ? "—"
                : row.HasPriceList ? e.DisplayText : "no price list";
        }

        private void gvStock_RowCellStyle(object sender,
            DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column != colStockSellPrice) return;

            if (!(gvStock.GetRow(e.RowHandle) is OutletStockRow row)) return;

            if (!row.IsIngredient && !row.HasPriceList)
                e.Appearance.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
        }

        private OutletStockRow StockRowAt(int listSourceRowIndex)
        {
            return listSourceRowIndex >= 0 && listSourceRowIndex < _currentOutletStock.Count
                ? _currentOutletStock[listSourceRowIndex]
                : null;
        }

        // Cost and sell price live on the product master, so both are known the
        // moment a product is picked — no reason to make someone assign first
        // and discover the value afterwards.
        private void UpdateProductInfoDisplay()
        {
            var dark = System.Drawing.Color.FromArgb(17, 24, 39);
            var amber = System.Drawing.Color.FromArgb(180, 83, 9);
            var red = System.Drawing.Color.FromArgb(185, 28, 28);

            if (!(cboProduct.SelectedItem is ProductItem product))
            {
                lblInfoCodeVal.Text = "—";
                lblInfoUnitVal.Text = "—";
                lblInfoCostVal.Text = "—";
                lblInfoPriceVal.Text = "—";
                lblInfoValueVal.Text = "—";
                lblInfoAfterVal.Text = "—";
                lblInfoCostVal.Appearance.ForeColor = dark;
                lblInfoPriceVal.Appearance.ForeColor = dark;
                return;
            }

            var unit = product.ProUnit;

            // តម្លៃទិញចូល — Total Buyin (ProFinBuyin) from Product Management,
            // falling back to the raw Buyin (ProImpPri). NOT ProUPriBY: every
            // product save path writes that column as a literal 0.
            var cost = product.ProFinBuyin ?? 0m;
            if (cost == 0m) cost = product.ProImpPri ?? 0m;
            var price = product.ProUPrSE ?? 0m;
            var currentQty = _currentOutletStock
                .FirstOrDefault(r => r.ProNumY == product.ProNumY)?.StockQty ?? 0m;

            lblInfoCodeVal.Text = product.ProNumY;
            lblInfoUnitVal.Text = string.IsNullOrWhiteSpace(unit) ? "—" : unit;

            // Call out a missing cost instead of showing a bare 0.00 — zero here
            // means nobody set a buy price on the product, not that the stock is
            // genuinely worthless.
            // 4 decimals, not 2: an ingredient is priced per gram or millilitre,
            // so a real buy-in like 0.0018/ML rounds to "0.00" at two places and
            // reads as free. Stock Value gives it away (100 ML showing 0.18
            // against a 0.00 unit price), but the unit price is where it has to
            // be legible in the first place.
            lblInfoCostVal.Text = cost > 0 ? cost.ToString("N4") : "0.0000  (not set)";
            lblInfoCostVal.Appearance.ForeColor = cost > 0 ? dark : amber;

            // The outlet's MenuItem price, not the catalogue's ProUPrSE — that is
            // what checkout charges, and its absence is what makes stock
            // unsellable no matter how much of it the outlet is holding.
            var menu = _outletMenu.FirstOrDefault(m =>
                m.IsActive && string.Equals(m.ProNumY, product.ProNumY, StringComparison.OrdinalIgnoreCase));

            if (product.IsIngredient)
            {
                lblInfoPriceVal.Text = "—";
                lblInfoPriceVal.Appearance.ForeColor = dark;
            }
            else if (menu != null)
            {
                lblInfoPriceVal.Text = menu.SellingPrice.ToString("N2");
                lblInfoPriceVal.Appearance.ForeColor = dark;
            }
            else
            {
                lblInfoPriceVal.Text = "no price list";
                lblInfoPriceVal.Appearance.ForeColor = red;
            }

            lblInfoValueVal.Text = (currentQty * cost).ToString("N2");

            lblInfoAfterVal.Text =
                decimal.TryParse(txtQuantity.Text.Trim(), out decimal newQty) && newQty >= 0
                    ? (newQty * cost).ToString("N2")
                    : "—";
        }

        // A recipe-based product's own OutletStock is never read at
        // checkout — Checkout resolves the sale through GetRecipeItems and
        // deducts the ingredients instead (see OrderRepository.
        // ResolveStockDeductionsAsync). Assigning stock directly to a
        // product that has an active recipe is therefore a silent no-op,
        // so warn and point at the ingredients that actually need stock.
        private async Task CheckRecipeWarningAsync()
        {
            if (!(cboProduct.SelectedItem is ProductItem product))
            {
                pnlRecipeWarning.Visible = false;
                return;
            }

            var warnings = new List<string>();

            var bulkWarning = BulkUnitWarning(product);
            if (bulkWarning != null)
                warnings.Add(bulkWarning);

            var recipe = await _api.GetAsync<RecipeInfo>($"api/recipe/product/{product.ProNumY}");

            if (recipe?.RecipeItems == null || recipe.RecipeItems.Count == 0)
            {
                lblRecipeWarning.Text = string.Join("\n", warnings);
                pnlRecipeWarning.Visible = warnings.Count > 0;
                return;
            }

            var ingredientNames = recipe.RecipeItems
                .Select(ri => _products.FirstOrDefault(p => p.ProNumY == ri.IngredientProNumY)?.ProName
                              ?? ri.IngredientProNumY)
                .ToList();

            warnings.Add(
                $"⚠ '{product.ProName}' is made via Recipe — assigning stock here has no effect at checkout.\n" +
                $"Assign stock to its ingredients instead: {string.Join(", ", ingredientNames)}");

            lblRecipeWarning.Text = string.Join("\n", warnings);
            pnlRecipeWarning.Visible = true;
        }

        // Built in code rather than the designer, following guiStockTransfer's
        // EnsurePendingItemsUi — keeps the staging list beside the screen it
        // belongs to instead of spreading it across a second designer file.
        private void EnsurePendingUi()
        {
            btnAssign.Text = "Add to List";

            pnlPending = new DevExpress.XtraEditors.PanelControl
            {
                Dock = DockStyle.Top,
                Height = 210,
                Padding = new Padding(18, 16, 18, 16),
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            };
            pnlPending.Appearance.BackColor = Color.White;
            pnlPending.Appearance.Options.UseBackColor = true;

            var header = new Panel { Dock = DockStyle.Top, Height = 42, BackColor = Color.Transparent };

            lblPendingHeader = new DevExpress.XtraEditors.LabelControl
            {
                Location = new Point(0, 6),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(420, 19),
                Text = "Items to assign — 0 in the list"
            };
            lblPendingHeader.Appearance.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblPendingHeader.Appearance.ForeColor = Color.FromArgb(17, 24, 39);
            lblPendingHeader.Appearance.Options.UseFont = true;
            lblPendingHeader.Appearance.Options.UseForeColor = true;

            btnSavePrint = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(21, 94, 60),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Size = new Size(150, 30),
                Text = "Save && Print",
                UseVisualStyleBackColor = false
            };
            btnSavePrint.FlatAppearance.BorderSize = 0;

            btnClearList = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.75F),
                ForeColor = Color.FromArgb(55, 65, 81),
                Cursor = Cursors.Hand,
                Size = new Size(110, 30),
                Text = "Clear List",
                UseVisualStyleBackColor = false
            };
            btnClearList.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);

            header.Controls.Add(btnSavePrint);
            header.Controls.Add(btnClearList);
            header.Controls.Add(lblPendingHeader);

            header.Resize += (s, e) =>
            {
                btnSavePrint.Location = new Point(header.Width - btnSavePrint.Width, 2);
                btnClearList.Location = new Point(btnSavePrint.Left - btnClearList.Width - 8, 2);
            };

            gvPending = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridPending = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
            gridPending.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvPending });
            gridPending.MainView = gvPending;
            gvPending.GridControl = gridPending;

            gvPending.OptionsBehavior.Editable = false;
            gvPending.OptionsView.ShowGroupPanel = false;
            gvPending.OptionsView.ShowIndicator = false;
            gvPending.OptionsView.EnableAppearanceEvenRow = true;
            gvPending.RowHeight = 30;
            gvPending.ColumnPanelRowHeight = 34;
            gvPending.Appearance.EvenRow.BackColor = Color.FromArgb(249, 250, 251);
            gvPending.Appearance.EvenRow.Options.UseBackColor = true;
            gvPending.Appearance.HeaderPanel.BackColor = Color.FromArgb(248, 249, 251);
            gvPending.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 9F);
            gvPending.Appearance.HeaderPanel.Options.UseBackColor = true;
            gvPending.Appearance.HeaderPanel.Options.UseFont = true;
            gvPending.Appearance.Row.Font = new Font("Segoe UI", 9.75F);
            gvPending.Appearance.Row.Options.UseFont = true;

            gridPending.DataSource = _pendingItems;

            pnlPending.Controls.Add(gridPending);
            pnlPending.Controls.Add(header);

            var spacer = new Panel { Dock = DockStyle.Top, Height = 12, BackColor = Color.Transparent };

            // Docking is applied in reverse of the Controls order, so these two
            // must sit below spacerMid/panelEntry in the collection to land
            // between the entry card and the current-stock grid.
            panelBody.Controls.Add(spacer);
            panelBody.Controls.SetChildIndex(spacer, 1);
            panelBody.Controls.Add(pnlPending);
            panelBody.Controls.SetChildIndex(pnlPending, 2);

            btnSavePrint.Click += BtnSavePrint_Click;
            btnClearList.Click += (s, e) =>
            {
                if (_pendingItems.Count == 0) return;

                if (XtraMessageBox.Show($"Discard {_pendingItems.Count} staged item(s)?", "Clear List",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                _pendingItems.Clear();
                RefreshPendingHeader();
            };

            _pendingItems.ListChanged += (s, e) => RefreshPendingHeader();

            RefreshPendingHeader();
        }

        private void RefreshPendingHeader()
        {
            if (lblPendingHeader == null) return;

            var total = _pendingItems.Sum(p => p.NewValue);

            lblPendingHeader.Text = _pendingItems.Count == 0
                ? "Items to assign — 0 in the list"
                : $"Items to assign — {_pendingItems.Count} in the list, value {total:N2}";
        }

        // Packaging units, as opposed to the units stock is actually counted
        // in. ProductScale.UOMCode is where these belong.
        private static readonly HashSet<string> BulkUnits =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            { "CTN", "PLT", "CASE", "BOX", "PACK", "DOZ" };

        // Checkout subtracts the quantity sold from StockQty 1:1 — there is no
        // case-to-piece conversion anywhere in the sale path (OrderQueries.
        // TryDeductOutletStock is a plain "StockQty - @Quantity", and
        // ProQtyPCase is never read there). So stock counted in cartons drifts
        // by the whole case size on the very first sale, silently and with no
        // error. Catch it at entry, where it is still cheap to fix.
        private string BulkUnitWarning(ProductItem product)
        {
            var unit = product.ProUnit?.Trim();

            if (string.IsNullOrWhiteSpace(unit) || !BulkUnits.Contains(unit))
                return null;

            return $"⚠ '{product.ProName}' is stocked in '{unit}' — a packaging unit, not a selling unit.\n" +
                   $"Checkout subtracts 1 per item sold with no {unit}-to-piece conversion, so this stock will " +
                   $"drift. Set the product's Stock Unit to what you actually sell (CAN / PCS) and store the " +
                   $"buy-in per that unit.";
        }

        // Stages one line — no API call. The write happens once, in
        // BtnSavePrint_Click, so a mis-typed quantity can still be removed from
        // the list instead of having already overwritten real stock.
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                XtraMessageBox.Show("Please select an outlet.");
                return;
            }

            if (!(cboProduct.SelectedItem is ProductItem product))
            {
                XtraMessageBox.Show("Please select a product.");
                return;
            }

            if (!decimal.TryParse(txtQuantity.Text.Trim(), out decimal quantity) || quantity < 0)
            {
                XtraMessageBox.Show("Please enter a valid quantity (0 or more).");
                txtQuantity.Focus();
                return;
            }

            // One line per product: Assign sets an absolute quantity, so two
            // lines for the same product would mean the second silently wins.
            var existing = _pendingItems.FirstOrDefault(p =>
                string.Equals(p.ProNumY, product.ProNumY, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                if (XtraMessageBox.Show(
                        $"'{product.ProName}' is already in the list at {existing.Quantity:0.####}.\n" +
                        $"Replace it with {quantity:0.####}?",
                        "Already Staged", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                _pendingItems.Remove(existing);
            }

            var cost = product.ProFinBuyin ?? 0m;
            if (cost == 0m) cost = product.ProImpPri ?? 0m;

            var current = _currentOutletStock
                .FirstOrDefault(r => r.ProNumY == product.ProNumY)?.StockQty ?? 0m;

            _pendingItems.Add(new PendingAssignLine
            {
                ProNumY = product.ProNumY,
                ProductName = product.ProName,
                Unit = product.ProUnit ?? "",
                CurrentQty = current,
                Quantity = quantity,
                BuyinPrice = cost,
                NewValue = quantity * cost
            });

            lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(14, 122, 56);
            lblStatus.Text = $"Added '{product.ProName}' to the list — nothing is saved until Save && Print.";

            txtQuantity.Text = string.Empty;
            txtQuantity.Focus();
        }

        // The only place this screen writes. Each line is its own POST to the
        // same endpoint the one-click flow used, so the server-side product and
        // outlet checks still apply; a line that fails leaves the successful
        // ones committed and stays in the list to be retried.
        private async void BtnSavePrint_Click(object sender, EventArgs e)
        {
            if (_pendingItems.Count == 0)
            {
                XtraMessageBox.Show("Add at least one item to the list first.");
                return;
            }

            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                XtraMessageBox.Show("Please select an outlet.");
                return;
            }

            if (XtraMessageBox.Show(
                    $"Save {_pendingItems.Count} item(s) to '{outlet.OutletName}'?\n\n" +
                    "Each line REPLACES the quantity currently on record — it does not add to it.",
                    "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            btnSavePrint.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var saved = new List<PendingAssignLine>();
            var failed = new List<string>();

            try
            {
                foreach (var line in _pendingItems.ToList())
                {
                    // ExpectedQty is the figure captured when the line was
                    // staged. Assign is an absolute SET, so without it a sale
                    // made while the list was being built would be erased
                    // silently; with it the server refuses that line instead.
                    var dto = new
                    {
                        OutletId = outlet.Id,
                        ProNumY = line.ProNumY,
                        Quantity = line.Quantity,
                        ExpectedQty = line.CurrentQty,
                        UpdatedBy = APIGlobals.UserName
                    };

                    if (await _api.PostAsync("api/OutletStock/assign", dto))
                    {
                        saved.Add(line);
                        _pendingItems.Remove(line);
                    }
                    else
                    {
                        failed.Add($"{line.ProductName} ({line.Quantity:0.####} {line.Unit})");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSavePrint.Enabled = true;
            }

            if (saved.Count > 0)
            {
                // The saves above are already committed — a printing failure
                // (no Excel, temp file locked) must not read as the assignment
                // itself having failed, nor crash this async void handler.
                try
                {
                    ExportAssignmentToPdf(outlet.OutletName, saved);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"Saved {saved.Count} item(s), but the document could not be produced:\n\n{ex.Message}",
                        "Print Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                await LoadStockGridAsync();
            }

            lblStatus.Appearance.ForeColor = failed.Count > 0
                ? System.Drawing.Color.FromArgb(185, 28, 28)
                : System.Drawing.Color.FromArgb(14, 122, 56);

            lblStatus.Text = failed.Count > 0
                ? $"Saved {saved.Count}, failed {failed.Count}: {string.Join(", ", failed)}"
                : $"Saved {saved.Count} item(s) to '{outlet.OutletName}' and produced the document.";

            RefreshPendingHeader();
        }

        private void ExportAssignmentToPdf(string outletName, List<PendingAssignLine> rows)
        {
            var excelApp = new Excel.Application { Visible = false, DisplayAlerts = false };
            Excel.Workbook workbook = null;

            try
            {
                workbook = excelApp.Workbooks.Add(Type.Missing);
                var ws = (Excel.Worksheet)workbook.ActiveSheet;

                const int lastCol = 7; // No, Code, Product, Unit, Previous, Assigned, Value

                void Merge(int row, int from, int to) =>
                    ws.Range[ws.Cells[row, from], ws.Cells[row, to]].Merge();

                ws.Cells[1, 1] = "UNT WHOLESALE CO., LTD.";
                Merge(1, 1, lastCol);
                ((Excel.Range)ws.Cells[1, 1]).Font.Bold = true;
                ((Excel.Range)ws.Cells[1, 1]).Font.Size = 14;

                ws.Cells[3, 1] = "Stock Assignment to Outlet";
                Merge(3, 1, lastCol);
                ((Excel.Range)ws.Cells[3, 1]).Font.Bold = true;
                ((Excel.Range)ws.Cells[3, 1]).Font.Size = 13;
                ((Excel.Range)ws.Cells[3, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Cells[5, 1] = "Outlet:";
                ((Excel.Range)ws.Cells[5, 1]).Font.Bold = true;
                ws.Cells[5, 2] = outletName;

                ws.Cells[5, 5] = "Assigned By:";
                ((Excel.Range)ws.Cells[5, 5]).Font.Bold = true;
                ws.Cells[5, 6] = APIGlobals.UserName ?? "";

                ws.Cells[6, 1] = "Date:";
                ((Excel.Range)ws.Cells[6, 1]).Font.Bold = true;
                ws.Cells[6, 2] = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                // "Previous" is on the document on purpose: Assign replaces the
                // figure rather than adding to it, so the value it overwrote is
                // the one thing a reader cannot reconstruct afterwards.
                string[] headers = { "No", "Code", "Product", "Unit", "Previous Qty", "Assigned Qty", "Value" };

                const int headerRow = 8;
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = (Excel.Range)ws.Cells[headerRow, i + 1];
                    cell.Value = headers[i];
                    cell.Font.Bold = true;
                    cell.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(241, 242, 245));
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                int r = headerRow + 1;
                decimal grandTotal = 0;

                for (int i = 0; i < rows.Count; i++)
                {
                    var line = rows[i];

                    ws.Cells[r, 1] = i + 1;
                    ws.Cells[r, 2] = line.ProNumY;
                    ws.Cells[r, 3] = line.ProductName;
                    ws.Cells[r, 4] = line.Unit;
                    ws.Cells[r, 5] = line.CurrentQty;
                    ws.Cells[r, 6] = line.Quantity;
                    ws.Cells[r, 7] = line.NewValue;

                    grandTotal += line.NewValue;
                    r++;
                }

                int lastDataRow = r - 1;

                var table = ws.Range[ws.Cells[headerRow, 1], ws.Cells[lastDataRow, lastCol]];
                table.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                table.Borders.Weight = Excel.XlBorderWeight.xlThin;

                int totalRow = lastDataRow + 2;
                Merge(totalRow, 5, 6);
                ws.Cells[totalRow, 5] = "Total Value:";
                ((Excel.Range)ws.Cells[totalRow, 5]).Font.Bold = true;
                ((Excel.Range)ws.Cells[totalRow, 5]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                ws.Cells[totalRow, 7] = grandTotal;
                ((Excel.Range)ws.Cells[totalRow, 7]).Font.Bold = true;

                int signRow = totalRow + 4;
                Merge(signRow, 1, 2);
                ws.Cells[signRow, 1] = "Assigned By";
                ((Excel.Range)ws.Cells[signRow, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Merge(signRow, 4, 5);
                ws.Cells[signRow, 4] = "Received By";
                ((Excel.Range)ws.Cells[signRow, 4]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Merge(signRow, 6, 7);
                ws.Cells[signRow, 6] = "Approved By";
                ((Excel.Range)ws.Cells[signRow, 6]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Columns[1].ColumnWidth = 5;
                ws.Columns[2].ColumnWidth = 16;
                ws.Columns[3].ColumnWidth = 30;
                ws.Columns[4].ColumnWidth = 9;
                ws.Columns[5].ColumnWidth = 14;
                ws.Columns[6].ColumnWidth = 14;
                ws.Columns[7].ColumnWidth = 14;

                ws.PageSetup.Zoom = false;
                ws.PageSetup.FitToPagesWide = 1;
                ws.PageSetup.FitToPagesTall = false;

                var pdfFile = Path.Combine(
                    Path.GetTempPath(),
                    $"StockAssignment_{outletName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfFile);

                Process.Start(new ProcessStartInfo(pdfFile) { UseShellExecute = true });
            }
            finally
            {
                workbook?.Close(false);
                excelApp.Quit();
            }
        }
    }

    // One staged assignment line. CurrentQty is captured at staging time so the
    // printed document can show what the new figure replaced.
    public class PendingAssignLine
    {
        public string ProNumY { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal CurrentQty { get; set; }
        public decimal Quantity { get; set; }
        public decimal BuyinPrice { get; set; }
        public decimal NewValue { get; set; }
    }

    // Shape of GET api/OutletStock/outlet/{id} — kept local to this screen
    // since nothing else in the client needs it yet.
    public class OutletStockRow
    {
        public int Id { get; set; }
        public int OutletId { get; set; }
        public string ProNumY { get; set; } = string.Empty;
        public string ProName { get; set; } = string.Empty;
        public bool IsIngredient { get; set; }
        public decimal StockQty { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? SellPrice { get; set; }
        public bool HasPriceList { get; set; }
        public decimal StockValue { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

    // Shape of GET api/MenuItem/outlet/{id} — only the price fields this screen
    // needs. MenuItem is the real per-outlet price list; TPRProducts.ProUPrSE is
    // just a catalogue default and is not what checkout charges.
    public class MenuPriceInfo
    {
        public string ProNumY { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public bool IsActive { get; set; }
    }

    // Shape of GET api/recipe/product/{proNumY} — only the fields this
    // screen needs (ingredient codes) to build the warning message.
    public class RecipeInfo
    {
        public int RecipeId { get; set; }
        public string ProNumY { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<RecipeItemInfo> RecipeItems { get; set; } = new List<RecipeItemInfo>();
    }

    public class RecipeItemInfo
    {
        public string IngredientProNumY { get; set; } = string.Empty;
        public decimal Qty { get; set; }
    }
}
