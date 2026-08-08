using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    // Answers one question the rest of the system leaves the user to work
    // out for themselves: "why can't this outlet sell this?"
    //
    // Being on a menu, having a recipe, and having stock are three separate
    // things, and missing any one of them makes a product unsellable — but
    // the POS only shows the end result (a greyed-out tile), never the
    // cause. This lists the cause and the fix, per product.
    public partial class guiOutletReadiness : XtraForm
    {
        private APIsController _api;

        public guiOutletReadiness()
        {
            InitializeComponent();
        }

        private async void guiOutletReadiness_Load(object sender, EventArgs e)
        {
            _api = APIGlobals.Api;

            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            cboOutlet.SelectedIndexChanged += async (s, ev) => await AnalyseAsync();

            try
            {
                var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet") ?? new List<OutletItem>();

                cboOutlet.DataSource = outlets.Where(o => o.IsActive).ToList();
                cboOutlet.DisplayMember = "OutletName";
                cboOutlet.ValueMember = "Id";
                cboOutlet.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not load outlets: " + ex.Message);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await AnalyseAsync();
        }

        private async Task AnalyseAsync()
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                var menu = await _api.GetAsync<List<MenuItems>>("api/MenuItem/outlet/" + outlet.Id)
                           ?? new List<MenuItems>();
                var recipes = await _api.GetAsync<List<RecipeModel>>("api/recipe")
                              ?? new List<RecipeModel>();
                var stock = await _api.GetAsync<List<OutletStockRow>>("api/OutletStock/outlet/" + outlet.Id)
                            ?? new List<OutletStockRow>();
                var products = await _api.GetAsync<List<ProductItem>>("api/product")
                               ?? new List<ProductItem>();

                var stockBy = new Dictionary<string, decimal>();
                foreach (var s in stock)
                    stockBy[s.ProNumY] = s.StockQty;

                var productBy = new Dictionary<string, ProductItem>();
                foreach (var p in products)
                    if (!productBy.ContainsKey(p.ProNumY)) productBy.Add(p.ProNumY, p);

                var rows = new List<ReadinessRow>();

                foreach (var m in menu.OrderBy(x => x.ProductName))
                    rows.Add(Evaluate(m, recipes, stockBy, productBy));

                gridItems.DataSource = rows;
                gvItems.BestFitColumns();

                int ready = rows.Count(r => r.CanSell);
                int blocked = rows.Count - ready;

                if (rows.Count == 0)
                {
                    lblSummary.ForeColor = Color.Firebrick;
                    lblSummary.Text = "This outlet has no products on its menu at all — nothing can be sold. "
                                    + "Add products in Setup > Outlet Menu.";
                }
                else if (blocked == 0)
                {
                    lblSummary.ForeColor = Color.SeaGreen;
                    lblSummary.Text = $"All {ready} product(s) can be sold right now.";
                }
                else
                {
                    lblSummary.ForeColor = Color.Firebrick;
                    lblSummary.Text = $"{blocked} of {rows.Count} product(s) CANNOT be sold. See 'What to do' below.";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Check failed: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private ReadinessRow Evaluate(
            MenuItems m,
            List<RecipeModel> recipes,
            Dictionary<string, decimal> stockBy,
            Dictionary<string, ProductItem> productBy)
        {
            var row = new ReadinessRow
            {
                ProductName = m.ProductName,
                ProNumY = m.ProNumY,
                Price = m.SellingPrice
            };

            if (!m.IsActive)
            {
                row.Kind = "-";
                row.CanSell = false;
                row.Problem = "The menu entry is marked inactive.";
                row.Action = "Setup > Outlet Menu: tick Active for this product.";
                return row;
            }

            if (m.SellingPrice <= 0)
            {
                row.Kind = "-";
                row.CanSell = false;
                row.Problem = "No selling price has been set.";
                row.Action = "Setup > Outlet Menu: set a selling price greater than 0.";
                return row;
            }

            var recipe = recipes.FirstOrDefault(r => r.ProNumY == m.ProNumY && r.IsActive);

            // No recipe -> sold as-is, so it needs stock of itself.
            if (recipe == null || recipe.RecipeItems == null || recipe.RecipeItems.Count == 0)
            {
                row.Kind = "Ready-made";

                decimal own = stockBy.ContainsKey(m.ProNumY) ? stockBy[m.ProNumY] : 0m;
                row.Available = own;

                if (own > 0)
                {
                    row.CanSell = true;
                    row.Problem = "";
                    row.Action = "";
                }
                else
                {
                    row.CanSell = false;
                    row.Problem = "No stock of this product at this outlet.";
                    row.Action = "Stock Transfer (from warehouse) or Assign Stock, for "
                               + m.ProductName + ".";
                }

                return row;
            }

            // Recipe-based -> its own stock is irrelevant; what matters is
            // whether every ingredient has enough for at least one unit.
            row.Kind = "From recipe";

            decimal makeable = decimal.MaxValue;
            var shortages = new List<string>();

            foreach (var item in recipe.RecipeItems)
            {
                decimal have = stockBy.ContainsKey(item.IngredientProNumY) ? stockBy[item.IngredientProNumY] : 0m;

                string name = productBy.ContainsKey(item.IngredientProNumY)
                    ? productBy[item.IngredientProNumY].ProName
                    : item.IngredientProNumY;

                string unit = productBy.ContainsKey(item.IngredientProNumY)
                    ? (productBy[item.IngredientProNumY].ProductScale?.UOMCode ?? "")
                    : "";

                if (!productBy.ContainsKey(item.IngredientProNumY))
                {
                    // The recipe points at a code with no product behind it —
                    // usually a barcode that was changed after the recipe was built.
                    makeable = 0;
                    shortages.Add($"'{item.IngredientProNumY}' no longer exists as a product");
                    continue;
                }

                decimal units = item.Qty > 0 ? Math.Floor(have / item.Qty) : 0m;

                if (units < makeable)
                    makeable = units;

                if (units < 1)
                    shortages.Add($"{name}: needs {item.Qty:0.####}{unit} per unit, only {have:0.####}{unit} in stock");
            }

            row.Available = makeable == decimal.MaxValue ? 0m : makeable;

            if (shortages.Count == 0)
            {
                row.CanSell = true;
                row.Problem = "";
                row.Action = "";
            }
            else
            {
                row.CanSell = false;
                row.Problem = string.Join("; ", shortages);
                row.Action = "Add stock for the ingredient(s) above — Stock Transfer or Assign Stock. "
                           + "Check the unit: quantities are per the ingredient's own unit (g, ml, pcs).";
            }

            return row;
        }

        // Red/green the whole row so a problem is visible at a glance rather
        // than needing the text read first.
        private void gvItems_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (!(gvItems.GetRow(e.RowHandle) is ReadinessRow row))
                return;

            if (row.CanSell)
            {
                e.Appearance.BackColor = Color.FromArgb(232, 245, 233);
                e.Appearance.ForeColor = Color.FromArgb(20, 90, 50);
            }
            else
            {
                e.Appearance.BackColor = Color.FromArgb(253, 235, 235);
                e.Appearance.ForeColor = Color.FromArgb(150, 30, 30);
            }
        }
    }

    public class ReadinessRow
    {
        public string ProductName { get; set; }
        public string ProNumY { get; set; }
        public decimal Price { get; set; }

        // "Ready-made" (needs its own stock) or "From recipe" (needs ingredients).
        public string Kind { get; set; }

        public bool CanSell { get; set; }
        public string CanSellText { get { return CanSell ? "YES" : "NO"; } }

        public decimal Available { get; set; }

        public string Problem { get; set; }
        public string Action { get; set; }
    }
}
