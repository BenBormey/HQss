using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;

using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using unt_bingoo.view.Branch;
using unt_bingoo.view.Category;
using unt_bingoo.view.Supplier;

namespace unt_bingoo.view.Product
{
    public partial class guiProduct : XtraForm
    {
        private APIsController _api;

        private BindingList<ProductItem> _productList =
            new BindingList<ProductItem>();

        private int _selectedProductId = 0;
        private string _uploadedImageUrl = "";

        public guiProduct()
        {
            InitializeComponent();
            _api = APIGlobals.Api;
        }
        //private async void LoadingOutlet()
        //{
        //    try
        //    {
        //        //var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet");

        //        //cboOutlet.DataSource = outlets;
        //        //cboOutlet.DisplayMember = "OutletName";
        //        //cboOutlet.ValueMember = "Id";
        //        cboOutlet.SelectedIndex = -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
        //    }
        //}
        private async Task LoadingOutlet()
        {
            try
            {
                var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet");

                cboOutlet.DataSource = outlets;
                cboOutlet.DisplayMember = "OutletName";
                cboOutlet.ValueMember = "Id";
                cboOutlet.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }
        }
        private async void guiProduct_Load_1(object sender, EventArgs e)
        {
            try
            {
                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

       
                gvProduct.RowHeight = 90;

                RepositoryItemPictureEdit pic =
                    new RepositoryItemPictureEdit();

                pic.SizeMode =
                    DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;

                pic.NullText = "No Image";

                gridProduct.RepositoryItems.Add(pic);

                gvProduct.Columns["ProductImage"].ColumnEdit = pic;
                gvProduct.Columns["ProductImage"].Width = 100;

                gvProduct.FocusedRowChanged +=
                    gvProduct_FocusedRowChanged;


                await LoadingBrand();
                await LoadingCategory();
                await LoadingSupplier();
                 LoadingOutlet();

                await LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }



        public async Task LoadData()
        {
            var list =
                await _api.GetAsync<List<ProductItem>>("api/Product");

            //foreach (var item in list)
            //{
            //    if (!string.IsNullOrEmpty(item.ImageUrl) &&
            //        Uri.IsWellFormedUriString(item.ImageUrl,
            //        UriKind.Absolute))
            //    {
            //        item.ProductImage =
            //            await LoadImageFromUrl(item.ImageUrl);
            //    }
            //}

            _productList =
                new BindingList<ProductItem>(list);

            gridProduct.DataSource = _productList;
        }


        private async Task<Image> LoadImageFromUrl(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] data = await client.GetByteArrayAsync(url);

                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        using (Image temp = Image.FromStream(ms))
                        {
                            return new Bitmap(temp); // ✅ CLONE IMAGE (IMPORTANT)
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }



        public class UploadResult
        {
            public string imageUrl { get; set; }
        }


        private async Task<string> UploadImage(string filePath)
        {
            try
            {
                using (var client = new HttpClient())
                using (var form = new MultipartFormDataContent())
                {
                    byte[] data = File.ReadAllBytes(filePath);

                    var content =
                        new ByteArrayContent(data);

                    content.Headers.ContentType =
                        new System.Net.Http.Headers
                        .MediaTypeHeaderValue("image/png");

                    form.Add(content, "file",
                        Path.GetFileName(filePath));

                    var res = await client.PostAsync(
                        "http://192.168.1.99:8099/api/Product/upload",
                        form);

                    if (!res.IsSuccessStatusCode)
                        return null;

                    var json =
                        await res.Content.ReadAsStringAsync();

                    var obj =
      JsonConvert.DeserializeObject<UploadResult>(json);


                    return obj.imageUrl;
                }
            }
            catch
            {
                return null;
            }
        }


        // ================= SELECT IMAGE =================

        private async void picCustomer_DoubleClick(
            object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter =
                "Image|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;

                picCustomer.Image = Image.FromFile(path);

                string url = await UploadImage(path);

                if (!string.IsNullOrEmpty(url))
                {
                    _uploadedImageUrl = url;

                    XtraMessageBox.Show("Upload success!");
                }
                else
                {
                    XtraMessageBox.Show("Upload failed!");
                }
            }
        }

        private void gvProduct_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base
            .FocusedRowChangedEventArgs e)
        {
            
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int brandId = int.TryParse(cboBrand.SelectedValue?.ToString(), out int b) ? b : 0;
                int categoryId = int.TryParse(cboCategory.SelectedValue?.ToString(), out int c) ? c : 0;
                int supplierId = int.TryParse(cbosupplier.SelectedValue?.ToString(), out int s) ? s : 0;

                decimal costPrice = decimal.TryParse(txtCost.Text, out decimal cp) ? cp : 0;
                decimal sellingPrice = decimal.TryParse(txtPrice.Text, out decimal sp) ? sp : 0;
                decimal vat = decimal.TryParse(txtVAT.Text, out decimal v) ? v : 0;
                decimal discount = decimal.TryParse(txtDiscound.Text, out decimal d) ? d : 0;

                ProductItem model = new ProductItem()
                {
                    //ProductID = _selectedProductId,

                    //ProductCode = txtCode.Text.Trim(),
                    //ProductName = txtName.Text.Trim(),

                    //BrandID = brandId,
                    //CategoryId = categoryId,
                    //SupplierId = supplierId,

                    //CostPrice = costPrice,
                    //SellingPrice = sellingPrice,
                    //TaxPercent = vat,

                    //ImageUrl = _uploadedImageUrl,

                    //Status = chkActive.Checked,
                    //DiscountPercent = discount
                };

                if (_selectedProductId == 0)
                {
                    await _api.PostAsync("api/Product", model);

                    XtraMessageBox.Show("Added successfully!");
                }
                else
                {
                    await _api.PutAsync(
                        $"api/Product/{_selectedProductId}",
                        model);

                    XtraMessageBox.Show("Updated successfully!");
                }

                ClearForm();

                await LoadData();
                cboOutlet.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void ClearForm()
        {
            _selectedProductId = 0;
            _uploadedImageUrl = "";

            txtCode.Text = "";
            txtName.Text = "";
            txtCost.Text = "";
            txtPrice.Text = "";
            txtVAT.Text = "";
            txtDiscound.Text = "";


            cboBrand.SelectedIndex = -1;
            cboCategory.SelectedIndex = -1;
            cbosupplier.SelectedIndex = -1;
            cboOutlet.SelectedIndex = -1;
            txtQty.Text = "";
            
            


            chkActive.Checked = true;

            picCustomer.Image = null;
         
            btnAdd.Text = "Add";
        }


     private async Task LoadingCategory()
        {
            var list =
                await _api.GetAsync<List<CategoryItem>>("api/Category");

            cboCategory.DataSource = list;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = -1;
        }


        private async Task LoadingBrand()
        {
            var list =
                await _api.GetAsync<List<BranchItem>>("api/Brand");

            cboBrand.DataSource = list;
            cboBrand.DisplayMember = "BranchName";
            cboBrand.ValueMember = "Id";
            cboBrand.SelectedIndex = -1;
        }


        private async Task LoadingSupplier()
        {
            var list =
                await _api.GetAsync<List<SupplierItem>>("api/Supplier");

            cbosupplier.DataSource = list;
            cbosupplier.DisplayMember = "SupplierName";
            cbosupplier.ValueMember = "SupplierID";
            cbosupplier.SelectedIndex = -1;
        }


        private void gvProduct_CustomColumnDisplayText(
            object sender,
            DevExpress.XtraGrid.Views.Base
            .CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "No")
            {
                e.DisplayText =
                    (e.ListSourceRowIndex + 1).ToString();
            }
        }


        private void gvProduct_RowCellStyle(
            object sender,
            DevExpress.XtraGrid.Views.Grid
            .RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.RowHandle % 2 == 0)
                e.Appearance.BackColor = Color.White;
            else
                e.Appearance.BackColor = Color.AliceBlue;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnaddCategory_Click(object sender, EventArgs e)
        {
            guiCategory gui = new guiCategory();
            gui.ShowDialog();
            this.LoadingCategory();
        }

        private void btnmainupdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //var row =
            //    gvProduct.GetFocusedRow() as ProductItem;

            //if (row == null) return;

            //_selectedProductId = row.ProductID;

            //txtCode.Text = row.ProductCode;
            //txtName.Text = row.ProductName;
            //txtCost.Text = row.CostPrice.ToString();
            //txtPrice.Text = row.SellingPrice.ToString();
            //txtVAT.Text = row.TaxPercent.ToString();
            //cboBrand.SelectedValue = row.BrandID;
            //cboCategory.SelectedValue = row.CategoryId;
            //cbosupplier.SelectedValue = row.SupplierId;
            //txtDiscound.Text = row.DiscountPercent.ToString();

            //cboOutlet.SelectedValue = row.outletId;
            //txtQty.Text = row.stockQty.ToString();
            //chkActive.Checked = row.Status;
            //_uploadedImageUrl = row.ImageUrl;
            //if (row.ProductImage != null)
            //    picCustomer.Image = row.ProductImage;
            //btnAdd.Text = "Update";
        }
       
        private void btnaddBrand_Click(object sender, EventArgs e)
        {
            guiBranch gui = new guiBranch();
            gui.ShowDialog();
            this.LoadingBrand();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guiSuppliers gui = new guiSuppliers();
            gui.ShowDialog();
            this.LoadingSupplier();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = "Excel File (*.xlsx)|*.xlsx";
                dlg.Title = "Export Product to Excel";
                dlg.FileName = "ProductList.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridProduct.ExportToXlsx(dlg.FileName);

                    XtraMessageBox.Show("Export successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnmaindelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //try
            //{
       
            //    var row = gvProduct.GetFocusedRow() as ProductItem;

            //    if (row == null)
            //    {
            //        XtraMessageBox.Show("Please select a product!");
            //        return;
            //    }

          
            //    DialogResult result = XtraMessageBox.Show(
            //        $"Are you sure you want to delete [{row.ProductName}]?",
            //        "Confirm Delete",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Warning
            //    );

            //    if (result != DialogResult.Yes)
            //        return;

       
            //    var response = await _api.DeleteAsync($"api/Product/{row.ProductID}");

              
            //    if (response == null)
            //    {
            //        XtraMessageBox.Show("Delete failed!");
            //        return;
            //    }

             
            //    _productList.Remove(row);

            //    XtraMessageBox.Show("Deleted successfully!");
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message);
            //}
        }

        private void picCustomer_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void productStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guiProductStock frm = new guiProductStock();
            frm.ShowDialog();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

