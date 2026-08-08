using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using unt_bingoo.Declares;

namespace unt_bingoo.view.Product
{
    // Small alternative to the 50-field guiProductOutlet form: only asks for
    // the handful of Product fields the system actually reads downstream
    // (name, khmer name, category, image, cost, ingredient flag), and lists
    // existing products so they can be edited or removed from the same place.
    // It never touches MenuItem — use Setup > Outlet Menu to price an item
    // and make it sellable at a POS.
    public partial class guiCreateProduct : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;

        private byte[] _imageBytes;
        private string _imageFileName;

        // Bumped every time a product is loaded for editing. The photo is
        // fetched over the network, so clicking Edit on one product and then
        // quickly on another leaves two downloads in flight — without this the
        // slower one wins and the form ends up showing the wrong photo.
        private int _imageLoadToken;

        // Full list kept in memory so the search box can filter without
        // re-fetching on every keystroke.
        private List<ProductItem> _allProducts = new List<ProductItem>();

        // The product currently loaded for editing; null means the form is
        // in "create new" mode.
        private ProductItem _editing;

        public guiCreateProduct()
        {
            InitializeComponent();
            _api = APIGlobals.Api ?? new APIsController();

            // Set here rather than in the designer: VS re-serialises the
            // designer file and strips EditorButton captions, so they'd
            // silently disappear the next time the form is opened in it.
            btnRowEdit.Buttons[0].Caption = "✎";
            btnRowEdit.Buttons[0].ToolTip = "Edit this product";
            btnRowDelete.Buttons[0].Caption = "✕";
            btnRowDelete.Buttons[0].ToolTip = "Delete this product";

            // Two things that aren't obvious from the labels alone: the code
            // is permanent, and Cost Price quietly feeds Recipe's margin
            // math for ingredients. Tooltips explain both without needing
            // any layout changes.
            var hints = new ToolTip();
            hints.SetToolTip(txtBarcode, "Cannot be changed after the product is saved.");
            hints.SetToolTip(txtCostPrice,
                "Used to calculate Recipe cost/margin when this product is an Ingredient. " +
                "Leave at 0 only if it's never used as an ingredient.");
            hints.SetToolTip(cboUnit,
                "The unit Recipe quantities, Outlet Stock, and Stock Transfers are all " +
                "expressed in for this product (e.g. kg, L, pcs). Required for Ingredients.");
        }

        private static decimal ParseDecimal(string s)
            => decimal.TryParse((s ?? "").Trim(), out decimal v) ? v : 0;

        private async void guiCreateProduct_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            txtSearch.TextChanged += (s, ev) => ApplyFilter();

            try
            {
                var categories = await _api.GetAsync<List<CategoryItem>>("api/category")
                                  ?? new List<CategoryItem>();

                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "Id";
                cboCategory.SelectedIndex = -1;

                var uoms = await _api.GetAsync<List<UOMClass>>("api/uom")
                           ?? new List<UOMClass>();

                cboUnit.DataSource = uoms.Where(u => u.IsActive).ToList();
                cboUnit.DisplayMember = "UOMName";
                cboUnit.ValueMember = "UOMCode";
                cboUnit.SelectedIndex = -1;

                await LoadProductsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed to load form data: " + ex.Message);
            }
        }

        private async Task LoadProductsAsync()
        {
            _allProducts = await _api.GetAsync<List<ProductItem>>("api/product")
                           ?? new List<ProductItem>();

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var keyword = txtSearch.Text.Trim();

            // Sellable items only. Ingredients are raw materials managed
            // through Recipe/BOM and stock screens, not sold at a POS, so
            // listing them here would only invite editing the wrong thing.
            var sellable = _allProducts.Where(p => !p.IsIngredient);

            var list = string.IsNullOrWhiteSpace(keyword)
                ? sellable.ToList()
                : sellable.Where(p =>
                    (p.ProNumY ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.ProName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.KhmerName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                  .ToList();

            gridProducts.DataSource = list;
            lblListHeader.Text = "Products for sale  (" + list.Count + ")";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private void gvProducts_DoubleClick(object sender, EventArgs e)
        {
            if (gvProducts.GetFocusedRow() is ProductItem row)
                LoadForEdit(row);
        }

        private void btnRowEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvProducts.GetFocusedRow() is ProductItem row)
                LoadForEdit(row);
        }

        private async void btnRowDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!(gvProducts.GetFocusedRow() is ProductItem row))
                return;

            // Deletes the row directly — no need to load it into the form
            // first just to remove it.
            await DeleteProductAsync(row);
            //if (_editing == null)
            //    return;

            //await DeleteProductAsync(_editing);
        }

        private void LoadForEdit(ProductItem p)
        {
            _editing = p;

            txtBarcode.Text = p.ProNumY;
            txtProductName.Text = p.ProName;
            txtKhmerName.Text = p.KhmerName;
            txtCostPrice.Text = (p.ProImpPri ?? 0m).ToString("0.####");
            chkIsIngredient.Checked = p.IsIngredient;

            if (!string.IsNullOrWhiteSpace(p.ProUnit))
                cboUnit.SelectedValue = p.ProUnit;
            else
                cboUnit.SelectedIndex = -1;

            if (int.TryParse(p.ProCat, out int catId))
                cboCategory.SelectedValue = catId;
            else
                cboCategory.SelectedIndex = -1;

            // A new image is only UPLOADED if the user picks one; otherwise the
            // product keeps whatever it already had. That is why these stay
            // null — they mean "nothing new to send", not "no photo".
            //
            // The two were conflated before: the picture box was blanked here
            // and never refilled, so opening a product for editing always
            // showed an empty frame even when it had a photo. It looked like
            // the image had been lost, and re-picking the same file was the
            // only way to make the form look right.
            _imageBytes = null;
            _imageFileName = null;

            picProduct.Image?.Dispose();
            picProduct.Image = null;

            // Fetched in the background so the rest of the form is usable
            // immediately; a slow or missing image must not block editing.
            var token = ++_imageLoadToken;
            _ = ShowExistingImageAsync(p.ProImage, token);

            SetEditMode(true);

            lblStatus.ForeColor = SystemColors.ControlText;
            lblStatus.Text = "Editing '" + p.ProName + "'. Change what you need, then Update Product.";
        }

        // Loads the photo a product already has into the preview box.
        //
        // Purely visual: it never touches _imageBytes/_imageFileName, so
        // saving without picking a new file still sends the existing ProImage
        // path back unchanged (see BuildUpdatePayload) rather than re-uploading
        // what the server already has.
        //
        // Uses TryGetBytesAsync, not GetBytesAsync. The latter routes through
        // SafeCall, which shows a modal "Connection Error" box on failure —
        // and most rows in this database still point their ProImage at
        // http://localhost:5189, a server that is not running, so every product
        // opened for editing threw one dialog up. Opening several in a row
        // stacked them.
        //
        // ResolveImageUrl re-bases the stored path onto the API this client is
        // actually pointed at, which is what makes those rows load at all.
        private async Task ShowExistingImageAsync(string imagePath, int token)
        {
            var url = _api.ResolveImageUrl(imagePath);

            if (string.IsNullOrWhiteSpace(url))
                return;

            // Silent by design: a missing or unreachable image is not a reason
            // to interrupt someone editing a product. The box stays empty,
            // every other field still works, and saving keeps the stored path.
            byte[] bytes = await _api.TryGetBytesAsync(url);

            // Another product was loaded while this was downloading. Dropping
            // the result is the whole point of the token.
            if (token != _imageLoadToken || bytes == null || bytes.Length == 0)
                return;

            if (IsDisposed || picProduct.IsDisposed)
                return;

            try
            {
                using (var ms = new MemoryStream(bytes))
                using (var loaded = Image.FromStream(ms))
                {
                    // Copied into a Bitmap because Image.FromStream keeps a
                    // reference to the stream, and the using block above closes
                    // it — drawing the control afterwards would throw.
                    var copy = new Bitmap(loaded);

                    // Re-checked after the decode: the user may have picked a
                    // new file in the meantime, and that choice must win over
                    // what was already on the server.
                    if (token != _imageLoadToken)
                    {
                        copy.Dispose();
                        return;
                    }

                    picProduct.Image?.Dispose();
                    picProduct.Image = copy;
                }
            }
            catch
            {
                // Corrupt or unsupported image data. Same reasoning as above.
            }
        }

        private void SetEditMode(bool editing)
        {
            btnSave.Text = editing ? "Update Product" : "Create Product";
            btnDelete.Visible = editing;

            // The code is the key every MenuItem, Recipe and stock row joins
            // on — changing it on an existing product would silently orphan
            // all of them, so it's locked once the product exists.
            txtBarcode.ReadOnly = editing;
            txtBarcode.BackColor = editing ? SystemColors.Control : SystemColors.Window;

            grpProduct.Text = editing ? "Product details — editing existing" : "Product details — new";
        }

        // Reuses the same barcode dialog guiProductOutlet uses: it checks
        // GET api/product/barcode/{code} itself and shows "This barcode
        // already exists!" without closing if it's a duplicate, so nothing
        // extra is needed here beyond reading back the result.
        private void txtBarcode_Click(object sender, EventArgs e)
        {
            // Locked while editing — see SetEditMode.
            if (_editing != null)
                return;

            Initialized.R_Barcode = "";

            var dlg = new FrmProductsBarcode(this.MdiParent as mainForm, false)
            {
                RCurrentBarcode = txtBarcode.Text.Trim()
            };

            if (dlg.ShowDialog(this) == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(Initialized.R_Barcode))
            {
                txtBarcode.Text = Initialized.R_Barcode.Trim();
            }

            Initialized.R_Barcode = "";
        }

        private void picProduct_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select Product Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    byte[] bytes = File.ReadAllBytes(dlg.FileName);

                    // Invalidates any existing-photo download still in flight.
                    // The file just chosen is what the user wants to see, and
                    // a slower fetch of the old image must not replace it.
                    _imageLoadToken++;

                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (Image temp = Image.FromStream(ms))
                    {
                        picProduct.Image?.Dispose();
                        picProduct.Image = new Bitmap(temp);
                    }

                    _imageBytes = bytes;
                    _imageFileName = Path.GetFileName(dlg.FileName);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Could not load image: " + ex.Message,
                        "Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                XtraMessageBox.Show("Please enter a barcode / product code.");
                txtBarcode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                XtraMessageBox.Show("Please enter the product name.");
                txtProductName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKhmerName.Text))
            {
                XtraMessageBox.Show("Please enter the khmer name.");
                txtKhmerName.Focus();
                return false;
            }

            if (cboCategory.SelectedValue == null)
            {
                XtraMessageBox.Show("Please select a category.");
                cboCategory.Focus();
                return false;
            }

            // Recipe.Qty, OutletStock.StockQty and IngredientStockTransfer.Qty are all
            // just plain decimals with no unit attached — this is the only place that
            // unit gets recorded, so an ingredient without one means every number
            // downstream is ambiguous (kg? g? pcs?).
            if (chkIsIngredient.Checked && cboUnit.SelectedValue == null)
            {
                XtraMessageBox.Show("Please select a Unit for this ingredient (used by Recipe, Outlet Stock, and Stock Transfer).");
                cboUnit.Focus();
                return false;
            }

            // Cost Price silently feeds Recipe's cost/margin calculation —
            // leaving it at 0 for an actual ingredient doesn't error anywhere,
            // it just makes every recipe using it look cheaper than it is.
            if (chkIsIngredient.Checked && ParseDecimal(txtCostPrice.Text) == 0)
            {
                var confirm = XtraMessageBox.Show(
                    "Cost Price is 0 for this ingredient. Any recipe using it will show " +
                    "$0.00 cost, which makes food-cost % and margin wrong. Continue anyway?",
                    "Cost Price is 0", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                {
                    txtCostPrice.Focus();
                    return false;
                }
            }

            return true;
        }

        // Minimal POST api/Product payload. Field names/types are taken
        // directly from CreateProductDto.cs (the server-side ground truth —
        // NOT guiProductOutlet.GetPostPayload's doc comment, which turned
        // out to be wrong about several types: ProQtyPPack/ProPckPri are
        // string, Promotion is int?, ProAllowDisW/U are float?, WHcode/
        // Sampling are decimal?, ShelfLifeOfProduct is string). Everything
        // not read anywhere else in the system is left at a safe default.
        // IsIngredient is omitted entirely so the API's default (false)
        // applies.
        private object BuildProductPayload(string barcode, string imagePath)
        {
            return new
            {
                id = 0,
                proNumY = barcode,
                proNumS = "",
                proNumYP = "",
                proNumYC = "",
                sup1 = "",
                sup2 = "",
                proName = txtProductName.Text.Trim(),
                khmerNameUnicode = txtKhmerName.Text.Trim(),
                proDes = "",
                proCat = cboCategory.SelectedValue?.ToString() ?? "",
                proPacksize = "",
                proCurr = "",
                proImpPri = ParseDecimal(txtCostPrice.Text),
                proRecLev = 0m,
                proRecOrder = 0m,
                khmerName = txtKhmerName.Text.Trim(),
                proRem = "",
                auto = "",
                profitAuto = "",
                proTotQty = 0,
                proMadein = "",
                proQtyPCase = 1m,
                proQtyPPack = "1",
                proPckPri = "0",
                proPckDis = 0f,
                proPckAllDis = 0f,
                proRecomLev = 0m,
                promotion = 0,
                formDLanded = 0m,
                proUPriBY = 0m,
                proAllowDisW = 0f,
                proAllowDisU = 0f,
                proDis = 0f,
                exciseTax = 0d,
                publicLightingTax = 0d,
                proVAT = 0f,
                proFinBuyin = 0m,
                proUPrSE = 0m,
                proProPer = 0f,
                proUPriSeH = 0m,
                proHolesaleper = 0f,
                proHoleSalePP = 0f,
                proRecPer = 0f,
                proSKU = barcode,
                average = 0m,
                birthDate = DateTime.Now,
                averSalePmonth = 0m,
                wHcode = 0m,
                sampling = 0m,
                factoryCurrency = "",
                foB_CIF = "",
                fobcifCost = 0m,
                shelfLifeOfProduct = "",
                vop = 0m,
                proImage = imagePath ?? "",
                isIngredient = chkIsIngredient.Checked,
                proUnit = cboUnit.SelectedValue?.ToString() ?? ""
            };
        }

        // PUT api/Product/{id} binds UpdateProductDto, which requires ProID
        // to match the route id. Rather than hand-build the whole payload
        // again, start from the row the list already holds and overwrite
        // only the fields this form exposes — everything else keeps its
        // stored value instead of being reset to a default.
        private object BuildUpdatePayload(string imagePath)
        {
            return new
            {
                proID = _editing.ProID,
                proNumY = _editing.ProNumY,
                proNumS = _editing.ProNumS ?? "",
                proNumYP = _editing.ProNumYP ?? "",
                proNumYC = _editing.ProNumYC ?? "",
                sup1 = _editing.Sup1 ?? "",
                sup2 = _editing.Sup2 ?? "",
                proName = txtProductName.Text.Trim(),
                khmerNameUnicode = txtKhmerName.Text.Trim(),
                khmerName = txtKhmerName.Text.Trim(),
                proDes = _editing.ProDes ?? "",
                proCat = cboCategory.SelectedValue?.ToString() ?? "",
                proPacksize = _editing.ProPacksize ?? "",
                proCurr = _editing.ProCurr ?? "",
                proImpPri = ParseDecimal(txtCostPrice.Text),
                proRecLev = _editing.ProRecLev ?? 0m,
                proRecOrder = _editing.ProRecOrder ?? 0m,
                proRem = _editing.ProRem ?? "",
                auto = "",
                profitAuto = "",
                proTotQty = _editing.ProTotQty ?? 0,
                proMadein = _editing.ProMadein ?? "",
                proQtyPCase = _editing.ProQtyPCase ?? 1m,
                proQtyPPack = _editing.ProQtyPPack ?? "1",
                proPckPri = _editing.ProPckPri ?? "0",
                proPckDis = _editing.ProPckDis ?? 0f,
                proPckAllDis = _editing.ProPckAllDis ?? 0f,
                proRecomLev = _editing.ProRecomLev ?? 0m,
                promotion = _editing.Promotion ?? 0,
                formDLanded = _editing.FormDLanded ?? 0m,
                proUPriBY = _editing.ProUPriBY ?? 0m,
                proAllowDisW = 0f,
                proAllowDisU = 0f,
                proDis = _editing.ProDis ?? 0f,
                exciseTax = _editing.ExciseTax ?? 0d,
                publicLightingTax = _editing.PublicLightingTax ?? 0d,
                proVAT = _editing.ProVAT ?? 0f,
                proFinBuyin = _editing.ProFinBuyin ?? 0m,
                proUPrSE = _editing.ProUPrSE ?? 0m,
                proProPer = _editing.ProProPer ?? 0f,
                proUPriSeH = _editing.ProUPriSeH ?? 0m,
                proHolesaleper = _editing.ProHolesaleper ?? 0f,
                proHoleSalePP = _editing.ProHoleSalePP ?? 0f,
                proRecPer = _editing.ProRecPer ?? 0f,
                proSKU = _editing.ProSKU ?? _editing.ProNumY,
                average = _editing.Average ?? 0m,
                birthDate = _editing.BirthDate ?? DateTime.Now,
                averSalePmonth = _editing.AverSalePmonth ?? 0m,
                wHcode = _editing.WHcode ?? 0m,
                sampling = _editing.Sampling ?? 0m,
                factoryCurrency = _editing.FactoryCurrency ?? "",
                foB_CIF = _editing.FOB_CIF ?? "",
                fobcifCost = _editing.FOBCIFCost ?? 0m,
                shelfLifeOfProduct = _editing.ShelfLifeOfProduct ?? "",
                vop = _editing.VOP ?? 0m,
                proImage = string.IsNullOrWhiteSpace(imagePath) ? (_editing.ProImage ?? "") : imagePath,
                isIngredient = chkIsIngredient.Checked,
                proUnit = cboUnit.SelectedValue?.ToString() ?? ""
            };
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            string barcode = txtBarcode.Text.Trim();

            btnSave.Enabled = false;
            Cursor = Cursors.WaitCursor;
            lblStatus.ForeColor = SystemColors.ControlText;
            lblStatus.Text = "Saving...";

            try
            {
                string imagePath = "";
                if (_imageBytes != null && _imageBytes.Length > 0)
                {
                    imagePath = await _api.UploadFileAsync(
                        "api/Product/upload", _imageBytes, _imageFileName ?? "product.jpg", "file");
                    imagePath = (imagePath ?? "").Trim('"');
                }

                if (_editing == null)
                {
                    bool saved = await _api.PostAsync("api/Product", BuildProductPayload(barcode, imagePath));

                    if (!saved)
                    {
                        lblStatus.ForeColor = Color.Firebrick;
                        lblStatus.Text = "Could not create the product. Check the barcode isn't already used.";
                        return;
                    }

                    lblStatus.ForeColor = Color.SeaGreen;
                    lblStatus.Text = $"'{txtProductName.Text.Trim()}' created. " +
                                      "Go to Setup > Outlet Menu to add it to an outlet and set its price.";

                    btnGoToOutletMenu.Visible = true;
                }
                else
                {
                    bool updated = await _api.PutAsync(
                        $"api/Product/{_editing.ProID}", BuildUpdatePayload(imagePath));

                    if (!updated)
                    {
                        lblStatus.ForeColor = Color.Firebrick;
                        lblStatus.Text = "Update failed.";
                        return;
                    }

                    lblStatus.ForeColor = Color.SeaGreen;
                    lblStatus.Text = $"'{txtProductName.Text.Trim()}' updated.";
                }

                ClearForm();
                await LoadProductsAsync();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Firebrick;
                lblStatus.Text = "Error: " + ex.Message;
            }
            finally
            {
                btnSave.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void ClearForm()
        {
            _editing = null;
            SetEditMode(false);

            txtBarcode.Text = "";
            txtProductName.Text = "";
            txtKhmerName.Text = "";
            txtCostPrice.Text = "0";
            cboCategory.SelectedIndex = -1;
            cboUnit.SelectedIndex = -1;
            chkIsIngredient.Checked = false;

            // Same reason as in the file picker: a photo still downloading for
            // the product that was open must not appear on the blank form.
            _imageLoadToken++;

            picProduct.Image?.Dispose();
            picProduct.Image = null;
            _imageBytes = null;
            _imageFileName = null;

            txtBarcode.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblStatus.Text = "";
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
          
        }

        private async Task DeleteProductAsync(ProductItem product)
        {
            // The API rejects the delete if the product is still referenced
            // (menu item, recipe, stock…), so a failure here is usually
            // "it's still in use" rather than a genuine error.
            if (XtraMessageBox.Show(
                    $"Delete '{product.ProName}' ({product.ProNumY})?\n\n" +
                    "This cannot be undone. It will fail if the product is still " +
                    "used on a menu, in a recipe, or has stock recorded.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                btnDelete.Enabled = false;
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.DeleteAsync($"api/Product/{product.ProID}");

                if (!ok)
                {
                    lblStatus.ForeColor = Color.Firebrick;
                    lblStatus.Text = "Could not delete — the product is probably still in use.";
                    return;
                }

                lblStatus.ForeColor = Color.SeaGreen;
                lblStatus.Text = $"'{product.ProName}' deleted.";

                // Only reset the form if the row just deleted is the one
                // currently loaded in it — deleting a different row from the
                // grid shouldn't disturb an in-progress edit.
                if (_editing?.ProID == product.ProID)
                    ClearForm();

                await LoadProductsAsync();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Firebrick;
                lblStatus.Text = "Error: " + ex.Message;
            }
            finally
            {
                btnDelete.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
