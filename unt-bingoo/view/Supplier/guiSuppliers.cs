using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Supplier
{
    public partial class guiSuppliers : XtraForm
    {
        private APIsController _api;

        private BindingList<SupplierItem> _supplierList =
            new BindingList<SupplierItem>();

        private int? _editingId = null;

        public guiSuppliers()
        {
            InitializeComponent();

            if (gridViewSuppliers is GridView view)
            {
                view.OptionsBehavior.Editable = false;
                view.OptionsView.ShowGroupPanel = false;
            }
            gridViewSuppliers.OptionsView.ColumnAutoWidth = true;
        }


        private async void guiSuppliers_Load(object sender, EventArgs e)
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
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= LOAD DATA =================

        private async Task LoadData()
        {
            var list = await _api.GetAsync<
                System.Collections.Generic.List<SupplierItem>>
                ("api/Supplier");

            _supplierList = new BindingList<SupplierItem>(list);

            gridControlSuppliers.DataSource = _supplierList;

            gridViewSuppliers.BestFitColumns();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok;

                // ADD
                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/Supplier", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    XtraMessageBox.Show("Added successfully!");
                }
                // UPDATE
                else
                {
                    ok = await _api.PutAsync(
                        $"api/Supplier/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    XtraMessageBox.Show("Updated successfully!");
                }

                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ================= DELETE =================

        private async void btnDelete_Click(object sender, EventArgs e)
        {
      
        }

        // ================= GRID CLICK =================

        private void gridViewSuppliers_RowClick(
            object sender,
            DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
          
        }



        private SupplierItem GetFormData()
        {
            return new SupplierItem
            {
                SupplierID = _editingId ?? 0,

                SupplierCode = txtSupplierCode.Text.Trim(),
                SupplierName = txtSupplierName.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                TaxNumber = txtTaxNumber.Text.Trim(),

                Status = chkStatus.Checked
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text))
            {
                XtraMessageBox.Show("Supplier Code required!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                XtraMessageBox.Show("Supplier Name required!");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
            txtContactName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtTaxNumber.Text = "";

            chkStatus.Checked = true;

            _editingId = null;

            btnAdd.Text = "Add";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_editingId == null)
            {
                XtraMessageBox.Show("Please select supplier to update!");
                return;
            }

            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.PutAsync(
                    $"api/Supplier/{_editingId}", model);

                if (!ok)
                {
                    XtraMessageBox.Show("Update failed!");
                    return;
                }

                XtraMessageBox.Show("Updated successfully!");

                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnmainDeletebutton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var row = gridViewSuppliers.GetFocusedRow()
           as SupplierItem;

            if (row == null) return;

            if (XtraMessageBox.Show(
                "Delete this supplier?",
                "Confirm",
                MessageBoxButtons.YesNo)
                != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.DeleteAsync(
                    $"api/Supplier/{row.SupplierID}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed!");
                    return;
                }

                await LoadData();
                ClearForm();

                XtraMessageBox.Show("Deleted successfully!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnmainUpdateButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewSuppliers.GetFocusedRow()
              as SupplierItem;

            if (row == null) return;

            txtSupplierCode.Text = row.SupplierCode;
            txtSupplierName.Text = row.SupplierName;
            txtContactName.Text = row.ContactName;
            txtPhone.Text = row.Phone;
            txtEmail.Text = row.Email;
            txtAddress.Text = row.Address;
            txtTaxNumber.Text = row.TaxNumber;

            chkStatus.Checked = row.Status;

            _editingId = row.SupplierID;

            btnAdd.Text = "Update";
        }
    }
}
