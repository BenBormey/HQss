using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Branch
{
    public partial class guiBranch : XtraForm
    {
        private APIsController _api;

        private BindingList<BranchItem> _branchList =
            new BindingList<BranchItem>();

        private int? _editingId = null;

        public guiBranch()
        {
            InitializeComponent();

     
            if (gridViewBranch is GridView view)
            {
                view.OptionsBehavior.Editable = true;
                view.OptionsBehavior.ReadOnly = false;
                view.OptionsView.ShowGroupPanel = false;
                view.OptionsBehavior.EditorShowMode =
                    DevExpress.Utils.EditorShowMode.Click;
            }
        }


        private async void guiBranch_Load(object sender, EventArgs e)
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


        private async Task LoadData()
        {
            var list = await _api.GetAsync<
                System.Collections.Generic.List<BranchItem>>("api/Branch");

            _branchList = new BindingList<BranchItem>(list);

            gridBranch.DataSource = _branchList;

            gridViewBranch.BestFitColumns();

            UpdateRowCount();
        }

        private void UpdateRowCount()
        {
            lblCountRow.Text = $"Count Row : {_branchList.Count}";
        }


        private void ClearForm()
        {
            txtBranchCode.Text = "";
            txtBranchName.Text = "";
            chkActive.Checked = true;
            txtRemark.Text = "";

            _editingId = null;

            btnAdd.Text = "Add";
        }

        private BranchItem GetFormData()
        {
            return new BranchItem
            {
                Id = _editingId ?? 0,
                Remark = txtRemark.Text.Trim(),

                BranchCode = txtBranchCode.Text.Trim(),
                BranchName = txtBranchName.Text.Trim(),

                

                Active = chkActive.Checked
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBranchCode.Text))
            {
                XtraMessageBox.Show("Branch Code required!");
                txtBranchCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBranchName.Text))
            {
                XtraMessageBox.Show("Branch Name required!");
                txtBranchName.Focus();
                return false;
            }

            return true;
        }

      
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok;

        
                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/Branch", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    XtraMessageBox.Show("Added successfully!");
                }
              
                else
                {
                    ok = await _api.PutAsync($"api/Branch/{_editingId}", model);

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


        private void repositoryItemButtonEdit1_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewBranch.GetFocusedRow() as BranchItem;

            if (row == null) return;

            txtBranchCode.Text = row.BranchCode;
            txtBranchName.Text = row.BranchName;
            chkActive.Checked = row.Active;

            _editingId = row.Id;

            btnAdd.Text = "Update";
        }

        private async void btnmainDelete_ButtonClick_1(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewBranch.GetFocusedRow() as BranchItem;

            if (row == null) return;

            if (XtraMessageBox.Show(
                "Delete this branch?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.DeleteAsync($"api/Branch/{row.Id}");

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
            
                var row = gridViewBranch.GetFocusedRow() as BranchItem;

                if (row == null)
                {
                    XtraMessageBox.Show("Please select a row first!");
                    return;
                }

             
                if (XtraMessageBox.Show(
                    "Do you want to delete this branch?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                try
                {
                    Cursor = Cursors.WaitCursor;

                    
                    bool ok = await _api.DeleteAsync($"api/Branch/{row.Id}");

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

        private void btnupdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewBranch.GetFocusedRow() as BranchItem;

            if (row == null)
            {
                XtraMessageBox.Show("Please select a row first!");
                return;
            }

      
            txtBranchCode.Text = row.BranchCode;
            txtBranchName.Text = row.BranchName;
            chkActive.Checked = row.Active;
            txtRemark.Text = row.Remark;

       
            _editingId = row.Id;

            btnAdd.Text = "Update";

           
            txtBranchCode.Focus();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Export Branch";
                dialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                dialog.FileName = "Branch_List.xlsx";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

       
                gridViewBranch.Columns["Edit"].Visible = false;
                gridViewBranch.Columns["Delete"].Visible = false;

        
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.ExportType = ExportType.WYSIWYG;
                options.SheetName = "Branch List";
                options.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;

       
                gridViewBranch.ExportToXlsx(dialog.FileName, options);

 
                gridViewBranch.Columns["Edit"].Visible = true;
                gridViewBranch.Columns["Delete"].Visible = true;

                System.Diagnostics.Process.Start(dialog.FileName);

                XtraMessageBox.Show(
                    "Export successful!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Export failed: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }
    }
}
