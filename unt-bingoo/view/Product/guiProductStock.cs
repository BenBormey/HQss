using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Product
{
    public partial class guiProductStock : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;

        public guiProductStock()
        {
            InitializeComponent();
            this._api = new APIsController();
            _product = new BindingList<ProductStockModel>();

        }

        private async void guiProductStock_Load(object sender, EventArgs e)
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

                await LoadData();
                LoadingBranch();
                LoadingOutlet();
                LoadingProduct();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }
        private BindingList<ProductStockModel> _product =
        new BindingList<ProductStockModel>();
        private async Task LoadData()
        {
            var list =
                  await _api.GetAsync<System.Collections.Generic.List<ProductStockModel>>(
                      "api/ProductStock");

            _product = new BindingList<ProductStockModel>(list);

            gridProduct.DataSource = _product;

      

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
        private async Task LoadingProduct()
        {
            try
            {
                var outlets = await _api.GetAsync<List<ProductItem>>("api/Product");

                cboProduct.DataSource = outlets;
                cboProduct.DisplayMember = "ProductName";
                cboProduct.ValueMember = "ProductID";
                cboProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }
        }

        private async Task LoadingBranch()
        {
            try
            {
                var outlets = await _api.GetAsync<List<BranchItem>>("api/Brand");

                //cboBranch.DataSource = outlets;
                //cboBranch.DisplayMember = "BranchName";
                //cboBranch.ValueMember = "Id";
                //cboBranch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }
        
        }
        private void ClearForm()
        {
            _editingId = -1;

            cboProduct.SelectedIndex = -1;
            //cboBranch.SelectedIndex = -1;
            cboOutlet.SelectedIndex = -1;

            txtQty.Clear();

            btnAdd.Text = "Add";
        }

        private bool ValidateForm()
        {
            if (cboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Product");
                return false;
            }

            //if (cboBranch.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please select Branch");
            //    return false;
            //}

            return true;
        }

        private int _editingId = -1;

        private ProductStockModel GetFormData() 
        {
            return new ProductStockModel()
            {
                StockID = _editingId == -1 ? 0 : _editingId,

                ProductID = Convert.ToInt32(cboProduct.SelectedValue),
                //BranchId = Convert.ToInt32(cboBranch.SelectedValue),
                OutletId = Convert.ToInt32(cboOutlet.SelectedValue),

                StockQty = int.TryParse(txtQty.Text, out int qty) ? qty : 0
            };
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                bool ok;

      
                if (_editingId == -1)
                {
                    ok = await _api.PostAsync("api/ProductStock", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    _product.Add(model);

                    XtraMessageBox.Show("Added!");
                }

                else
                {
                    ok = await _api.PutAsync($"api/ProductStock/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    var item = _product.FirstOrDefault(x => x.ProductID == _editingId);

                    if (item != null)
                    {
                        item.ProductID = model.ProductID;
                        item.BranchId = model.BranchId;
                        item.StockQty = model.StockQty;
                        item.OutletId = model.OutletId;
                    }

                    gvProduct.RefreshData();

                    XtraMessageBox.Show("Updated!");
                }

                UpdateRowCount();
                LoadData();
                ClearForm();

            } 
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void UpdateRowCount()
        {
           lblCountRow.Text = $"Total: {_product.Count}";
        }
      

        private void gvProduct_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
      
        }

        private void btnmainUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvProduct.GetFocusedRow() as ProductStockModel;

            if (row == null) return;

            _editingId = row.StockID;

            cboProduct.SelectedValue = row.ProductID;
            //cboBranch.SelectedValue = row.BranchId;
            cboOutlet.SelectedValue = row.OutletId;

            txtQty.Text = row.StockQty.ToString();

            btnAdd.Text = "Update";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.Title = "Export to Excel";
                sfd.FileName = "ProductStock_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
             
                    gvProduct.ExportToXlsx(sfd.FileName);

                    XtraMessageBox.Show("Export successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

               
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export failed: " + ex.Message);
            }

        }

        private void gvProduct_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "No")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void gvProduct_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.White;
            }
            else
            {
                e.Appearance.BackColor = Color.LightGray;
            }
            if (e.Column.FieldName == "StockQty")
            {
                int qty = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "StockQty"));

                if (qty < 20)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
           
        }
    }
}