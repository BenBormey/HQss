using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutlet : XtraForm
    {
        private APIsController _api;

        private BindingList<OutletItem> _outletList =
            new BindingList<OutletItem>();

        private int? _editingId = null;

        public guiOutlet()
        {
            InitializeComponent();

            // Grid setting
            if (gridViewOutlet is GridView view)
            {
                view.OptionsBehavior.Editable = true;
                view.OptionsBehavior.ReadOnly = false;
                view.OptionsView.ShowGroupPanel = false;
                view.OptionsBehavior.EditorShowMode =
                    DevExpress.Utils.EditorShowMode.Click;
            }
        }

        // ================= LOAD =================
        private async void guiOutlet_Load(object sender, EventArgs e)
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
                System.Collections.Generic.List<OutletItem>>("api/Outlet");

            _outletList = new BindingList<OutletItem>(list);

            gridControlOutlet.DataSource = _outletList;

            gridViewOutlet.BestFitColumns();

            lblCountRow.Text = $"Count Row: {_outletList.Count}";
        }

        // ================= EXPORT =================
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                gridControlOutlet.ExportToXlsx(sfd.FileName);

                XtraMessageBox.Show("Export success!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= ADD / UPDATE =================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok;

                // ========== ADD ==========
                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/Outlet", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add outlet failed!");
                        return;
                    }

                    XtraMessageBox.Show("Added successfully!");
                }
                // ========== UPDATE ==========
                else
                {
                    ok = await _api.PutAsync($"api/Outlet/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update outlet failed!");
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

        // ================= UPDATE BUTTON (GRID) =================
        private void btnUpdate_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewOutlet.GetFocusedRow() as OutletItem;

            if (row == null) return;

            txtOutletCode.Text = row.OutletCode;
            txtOutletName.Text = row.OutletName;
            txtAddress.Text = row.Province;
            txtPhone.Text = row.Phone;
            txtManager.Text = row.Manager;

            chkHeadOffice.Checked = row.HeadOffice;
            chkActive.Checked = row.IsActive;

            _editingId = row.Id;

            btnAdd.Text = "Update";
        }

        // ================= DELETE BUTTON (GRID) =================
        private async void btnmainDelete_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewOutlet.GetFocusedRow() as OutletItem;

            if (row == null) return;

            if (XtraMessageBox.Show(
                "Delete this outlet?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.DeleteAsync($"api/Outlet/{row.Id}");

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

        // ================= HELPER =================

        private OutletItem GetFormData()
        {
            return new OutletItem
            {
                Id = _editingId ?? 0,

                OutletCode = txtOutletCode.Text.Trim(),
                OutletName = txtOutletName.Text.Trim(),
                Province = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Manager = txtManager.Text.Trim(),

                HeadOffice = chkHeadOffice.Checked,
                IsActive = chkActive.Checked
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtOutletCode.Text))
            {
                XtraMessageBox.Show("Outlet Code is required!");
                txtOutletCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOutletName.Text))
            {
                XtraMessageBox.Show("Outlet Name is required!");
                txtOutletName.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtOutletCode.Text ="";
            txtOutletName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtManager.Text = "";

            chkHeadOffice.Checked = false;
            chkActive.Checked = true;

            _editingId = null;
            btnAdd.Text = "Add";
        }
    }
}
