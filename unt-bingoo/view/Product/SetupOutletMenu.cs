using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using unt_bingoo.view.currency;

namespace unt_bingoo.view.Product
{
    public partial class cboProduct : DevExpress.XtraEditors.XtraForm
    {
        private APIsController api_;

        private byte[] _productImageBytes;
        private string _productImageFileName;

        private MenuItems _editingItem = null;

        private BindingList<MenuItems> _menuItems = new BindingList<MenuItems>();

        private bool _loadingProduct = false;
        private bool _bindingEditForm = false;

        public cboProduct()
        {
            InitializeComponent();

            this.api_ = APIGlobals.Api ?? new APIsController();

            SetupGrid();

            chkActive.Checked = true;
            ApplyPromotionState();
        }

        private void SetupGrid()
        {
            var view = gridViewMenu;

            view.OptionsView.ShowGroupPanel = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DrawFocusRectStyle.RowFocus;
        }

        private void AddCol(GridView view, string field, string caption, int width, string format = null)
        {
            var col = view.Columns.AddVisible(field, caption);
            col.Width = width;

            if (format == "n2")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "n2";
            }
            else if (format == "d")
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                col.DisplayFormat.FormatString = "dd/MM/yyyy";
            }
        }

        public async Task loadingProduct()
        {
            try
            {
                _loadingProduct = true;

                var products = await api_.GetAsync<List<ProductItem>>("api/Product");

                cboOutlets.DataSource = null;
                cboOutlets.DisplayMember = "desiplyname";
                cboOutlets.ValueMember = "ProNumY";
                cboOutlets.DataSource = products ?? new List<ProductItem>();

                cboOutlets.SelectedIndex = -1;
            }
            finally
            {
                _loadingProduct = false;
            }
        }

        public async Task loadingOutlet()
        {
            try
            {
                var outlets = await api_.GetAsync<List<OutletItem>>("api/Outlet");
                var activeOutlets = (outlets ?? new List<OutletItem>())
                    .Where(x => x.IsActive == true)
                    .ToList();

                cboProducts.DataSource = activeOutlets;
                cboProducts.DisplayMember = "OutletName";
                cboProducts.ValueMember = "Id";
                cboProducts.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }
        }

        public async Task loadingCurrency()
        {
            try
            {
                var currencies = await api_.GetAsync<List<CurrencyItem>>("api/Currency");
                cboCurrency.DataSource = currencies ?? new List<CurrencyItem>();
                cboCurrency.DisplayMember = "CurrencyCode";
                cboCurrency.ValueMember = "Id";
                cboCurrency.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Currency Error: " + ex.Message);
            }
        }

        private async void MenuItem_Load(object sender, EventArgs e)
        {
            try
            {
                api_ = APIGlobals.Api;

                if (api_ == null || !api_.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                // Load data AFTER the token is confirmed, and await it.
                await loadingOutlet();
                await loadingProduct();
                await loadingCurrency();
                await LoadMenuItems(0);

                chkActive.Checked = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboOutlets.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Please select Product!");
                    return;
                }
                if (cboProducts.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Please select Outlet!");
                    return;
                }
                if (cboCurrency.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Please select Currency!");
                    return;
                }
                if (!decimal.TryParse(txtsellingPrice.Text.Trim(), out decimal sellingPrice) || sellingPrice <= 0)
                {
                    XtraMessageBox.Show("Invalid selling price!");
                    txtsellingPrice.Focus();
                    return;
                }

                decimal discount = 0;
                decimal? promotionPrice = null;
                DateTime? promoStart = null;
                DateTime? promoEnd = null;

                if (chkPromotion.Checked)
                {
                    if (!decimal.TryParse(txtDiscount.Text.Trim(), out discount) || discount <= 0)
                    {
                        XtraMessageBox.Show("Invalid discount!");
                        txtDiscount.Focus();
                        return;
                    }

                    promoStart = dtpOpening.Value.Date;
                    promoEnd = dateTimePicker1.Value.Date;

                    if (promoEnd < promoStart)
                    {
                        XtraMessageBox.Show("End date must be after start date!");
                        return;
                    }

                    // FIX: was an invalid cast (decimal)txtPromotionPrice.Text — now parsed safely.
                    if (!decimal.TryParse(txtPromotionPrice.Text.Trim(), out decimal promoPriceValue) || promoPriceValue <= 0)
                    {
                        XtraMessageBox.Show("Invalid promotion price!");
                        txtPromotionPrice.Focus();
                        return;
                    }
                    promotionPrice = Convert.ToDecimal(txtPromotionPrice.Text.Trim());
                }

                int proId = Convert.ToInt32(cboOutlets.SelectedValue is string s ? 0 : cboOutlets.SelectedValue);
                int outletId = Convert.ToInt32(cboProducts.SelectedValue);

                // Exclude the row we are editing from the duplicate check.
                // FIX: compare by MenuItemId, not ReferenceEquals — after a grid
                // reload the list contains new objects and ReferenceEquals fails.
                string selectedProNumY = cboOutlets.SelectedValue?.ToString();
                int editingId = _editingItem?.MenuItemId ?? 0;

                bool duplicate = _menuItems.Any(x =>
                    x.ProNumY == selectedProNumY &&
                    x.OutletId == outletId &&
                    x.MenuItemId != editingId);

                if (duplicate)
                {
                    XtraMessageBox.Show("This product already exists in the list!");
                    return;
                }

                string text = cboOutlets.Text.Trim();
                int index = text.IndexOf(' ');

                string proNumY = "";
                string productName = "";

                if (index > 0)
                {
                    proNumY = text.Substring(0, index).Trim();
                    productName = text.Substring(index).Trim();
                }
                else
                {
                    proNumY = selectedProNumY ?? text;
                }

                // FIX: upload the selected image before saving, so the file actually exists on the server.
                if (_productImageBytes != null && _productImageBytes.Length > 0)
                {
                    string uploadedName = await UploadProductImageAsync();
                    if (!string.IsNullOrWhiteSpace(uploadedName))
                        _productImageFileName = uploadedName;
                }

                if (_editingItem == null)
                {
                    var request = new
                    {
                        OutletId = outletId,
                        ProNumY = proNumY,
                        CurrencyId = cboCurrency.SelectedValue,
                        SellingPrice = sellingPrice,
                        IsPromotion = chkPromotion.Checked,
                        Discount = chkPromotion.Checked ? discount : (decimal?)null,
                        PromotionPrice = promotionPrice,
                        PromoStartDate = promoStart,
                        PromoEndDate = promoEnd,
                        IsActive = chkActive.Checked,
                        ImageFileName = _productImageFileName,
                        Remark = txtRemark.Text.Trim(),
                        CreatedBy = ""
                    };

                    // FIX: was PostAsync<MenuItem> (WinForms type) — must be our model MenuItems.
                    var result = await api_.PostAsync<MenuItems>("api/MenuItem", request);

                    if (result != null)
                    {
                        XtraMessageBox.Show("Saved Successfully.");
                        await LoadMenuItems(outletId);
                        ClearForm();
                    }
                }
                else
                {
                    var request = new
                    {
                        MenuItemId = _editingItem.MenuItemId,
                        OutletId = outletId,
                        ProNumY = proNumY,
                        CurrencyId = cboCurrency.SelectedValue,
                        SellingPrice = sellingPrice,
                        IsPromotion = chkPromotion.Checked,
                        Discount = chkPromotion.Checked ? discount : (decimal?)null,
                        PromotionPrice = promotionPrice,
                        PromoStartDate = promoStart,
                        PromoEndDate = promoEnd,
                        IsActive = chkActive.Checked,
                        ImageFileName = string.IsNullOrWhiteSpace(_productImageFileName)
                                            ? _editingItem.ImageFileName
                                            : _productImageFileName,
                        Remark = txtRemark.Text.Trim(),
                        UpdatedBy = ""
                    };

                    bool success = await api_.PutAsync(
                        $"api/MenuItem/{_editingItem.MenuItemId}",
                        request);

                    if (success)
                    {
                        XtraMessageBox.Show("Updated Successfully.");
                        await LoadMenuItems(outletId);
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Add Error: " + ex.Message);
            }
        }

        private async Task LoadMenuItems(int outletid)
        {
            // FIX: decide based on outlet id instead of SelectedValue?.ToString() == null,
            // which was never reliable.
            List<MenuItems> data;

            if (outletid <= 0 || cboProducts.SelectedValue == null)
            {
                data = await api_.GetAsync<List<MenuItems>>("api/MenuItem");
            }
            else
            {
                data = await api_.GetAsync<List<MenuItems>>($"api/MenuItem/outlet/{outletid}");
            }

            _menuItems.Clear();

            int no = 1;
            foreach (var item in data ?? new List<MenuItems>())
            {
                item.No = no++;
                _menuItems.Add(item);
            }

            gridControlMenu.DataSource = _menuItems;
            gridViewMenu.RefreshData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var item = gridViewMenu.GetFocusedRow() as MenuItems;

            if (item == null)
            {
                XtraMessageBox.Show("Please select a row to remove!");
                return;
            }

            _menuItems.Remove(item);
            RenumberRows();
        }

        private void RenumberRows()
        {
            for (int i = 0; i < _menuItems.Count; i++)
                _menuItems[i].No = i + 1;

            gridViewMenu.RefreshData();
        }

        private void ClearForm()
        {
            txtsellingPrice.Clear();
            txtDiscount.Clear();
            cboOutlets.SelectedIndex = -1;
            cboProducts.SelectedIndex = -1;
            cboCurrency.SelectedIndex = -1;
            picPreview.Image?.Dispose();
            picPreview.Image = null;
            _productImageBytes = null;
            _productImageFileName = null;
            txtsellingPrice.Text = "";
            txtPromotionPrice.Text = "";
            txtRemark.Text = "";

            _editingItem = null;
            btnAdd.Text = "Add";

            // FIX: restore edit-mode UI state (was left disabled/visible after Update).
            btncancel.Visible = false;
            cboProducts.Enabled = true;
            gridControlMenu.Enabled = true;
        }

        // FIX: promotion enable/disable logic was duplicated in two handlers —
        // now both call this single method (and it also toggles txtPromotionPrice).
        private void ApplyPromotionState()
        {
            bool on = chkPromotion.Checked;
            txtDiscount.Enabled = on;
            txtPromotionPrice.Enabled = on;
            dtpOpening.Enabled = on;
            dateTimePicker1.Enabled = on;

            if (!on)
            {
                txtDiscount.Clear();
                txtPromotionPrice.Text = "";
            }
        }

        private void chkPromotion_CheckedChanged(object sender, EventArgs e)
        {
            ApplyPromotionState();
        }

        private void chkPromotion_CheckedChanged_1(object sender, EventArgs e)
        {
            ApplyPromotionState();
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                chkDeactive.Checked = false;
            }
            else
            {
                if (!chkDeactive.Checked)
                    chkActive.Checked = true;
            }
        }

        private void chkDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeactive.Checked)
            {
                chkActive.Checked = false;
            }
            else
            {
                if (!chkActive.Checked)
                    chkDeactive.Checked = true;
            }
        }

        private async Task<string> UploadProductImageAsync()
        {
            if (_productImageBytes == null || _productImageBytes.Length == 0)
                return null;

            string fileName = string.IsNullOrWhiteSpace(_productImageFileName)
                ? "product.jpg" : _productImageFileName;

            return await this.api_.UploadFileAsync("api/Product/upload", _productImageBytes, fileName, "file");
        }

        private void picPreview_DoubleClick(object sender, EventArgs e)
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

                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (Image temp = Image.FromStream(ms))
                    {
                        picPreview.Image?.Dispose();
                        picPreview.Image = new Bitmap(temp);
                    }

                    _productImageBytes = bytes;
                    _productImageFileName = Path.GetFileName(dlg.FileName);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Could not load image: " + ex.Message,
                        "Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboOutlet_SelectedIndexChanged(object sender, EventArgs e) { }

        private async void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bindingEditForm || _editingItem != null)
                return;

            if (!int.TryParse(cboProducts.SelectedValue?.ToString(), out int outletId))
                return;

            // Load MenuItems របស់ Outlet ដែលបានជ្រើស
            await LoadMenuItems(outletId);

            // Load Product ទាំងអស់
            var products = await api_.GetAsync<List<ProductItem>>("api/Product");

            // Product ដែលមានរួចក្នុង Outlet
            var existingProducts = _menuItems
                .Select(x => x.ProNumY)
                .ToHashSet();

            // ដក Product ដែលមានរួចចេញ
            var availableProducts = products
                .Where(p => !existingProducts.Contains(p.ProNumY))
                .ToList();

         
            cboOutlets.DataSource = null;
            cboOutlets.DisplayMember = "desiplyname";
            cboOutlets.ValueMember = "ProNumY";
            cboOutlets.DataSource = availableProducts;
            cboOutlets.SelectedIndex = -1;
            if (_bindingEditForm || _editingItem != null)
                return;

        
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            guiHourOpration gui = new guiHourOpration();
            gui.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            guiCurencys gui = new guiCurencys();
            gui.ShowDialog();
        }

        private void btnMainEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var item = gridViewMenu.GetFocusedRow() as MenuItems;
            if (item == null) return;

            _editingItem = item;

            // FIX: block SelectedIndexChanged reloads while filling the form.
            _bindingEditForm = true;
            try
            {
                // ដាក់តម្លៃចូល form វិញ
                cboOutlets.SelectedValue = item.ProNumY;
                cboProducts.SelectedValue = item.OutletId;
                cboCurrency.SelectedValue = item.CurrencyId;
                txtsellingPrice.Text = item.SellingPrice.ToString();
                txtRemark.Text = item.Remark;
                txtPromotionPrice.Text = item.PromotionPrice?.ToString() ?? "";

                chkPromotion.Checked = item.IsPromotion;
                if (item.IsPromotion)
                {
                    txtDiscount.Text = item.Discount?.ToString() ?? "";
                    if (item.PromoStartDate.HasValue) dtpOpening.Value = item.PromoStartDate.Value;
                    if (item.PromoEndDate.HasValue) dateTimePicker1.Value = item.PromoEndDate.Value;
                }

                chkActive.Checked = item.IsActive;
                chkDeactive.Checked = !item.IsActive;
            }
            finally
            {
                _bindingEditForm = false;
            }
            gridControlMenu.Enabled = false;
            btncancel.Visible = true;
            cboProducts.Enabled = false;
            btnAdd.Text = "Update";
        }

        private async void btnMainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var item = gridViewMenu.GetFocusedRow() as MenuItems;
            if (item == null) return;

            var confirm = XtraMessageBox.Show(
                "Are you sure you want to delete \"" + item.ProductName + "\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // FIX: delete on the server too — before, the row only disappeared
                // from the grid and came back after reload.
                bool success = await api_.DeleteAsync($"api/MenuItem/{item.MenuItemId}");

                if (!success)
                {
                    XtraMessageBox.Show("Delete failed on server!");
                    return;
                }

                // If we delete the row currently being edited, leave edit mode.
                if (ReferenceEquals(item, _editingItem))
                    ClearForm();

                _menuItems.Remove(item);
                RenumberRows();

                XtraMessageBox.Show("Deleted Successfully.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private async void cboOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingProduct)
                return;

            if (cboOutlets.SelectedIndex < 0)
                return;

            var product = cboOutlets.SelectedItem as ProductItem;
            if (product == null)
                return;

            try
            {
                var detail = await api_.GetAsync<ProductItem>($"api/Product/{product.ProID}");
                if (detail == null)
                {
                    picPreview.Image?.Dispose();
                    picPreview.Image = null;
                    return;
                }

                if (!string.IsNullOrWhiteSpace(detail.ProImage))
                {
                    byte[] bytes = await api_.GetBytesAsync(detail.ProImage);

                    if (bytes != null)
                    {
                        using (var ms = new MemoryStream(bytes))
                        {
                            picPreview.Image?.Dispose();
                            picPreview.Image = new Bitmap(Image.FromStream(ms));
                        }
                    }
                    else
                    {
                        picPreview.Image?.Dispose();
                        picPreview.Image = null;
                    }
                }
                else
                {
                    picPreview.Image?.Dispose();
                    picPreview.Image = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void cboOutlets_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && (sender as Control).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void txtsellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericOnly_KeyPress(sender, e);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericOnly_KeyPress(sender, e);
        }

        private void txtPromotionPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericOnly_KeyPress(sender, e);
        }

        private void dtpOpening_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dtpOpening.Value.AddDays(7);
        }

        private void cboOutlets_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private async void btncancel_Click(object sender, EventArgs e)
        {
            int outletId = 0;
            int.TryParse(cboProducts.SelectedValue?.ToString(), out outletId);

            ClearForm();

            await LoadMenuItems(outletId);
        }
    }
}