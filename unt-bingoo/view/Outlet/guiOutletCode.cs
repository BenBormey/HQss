using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutletCode : DevExpress.XtraEditors.XtraForm
    {
        private  APIsController _api = new APIsController();

        public string editid = null;

        public guiOutletCode()
        {
            InitializeComponent();
        }

   
        private async Task LoadDataAsync()
        {
            var list = await _api.GetAsync<List<OutletcodeClas>>("api/outletcode");

       
            grdOutlet.DataSource = list ?? new List<OutletcodeClas>();
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOutletCode.Text))
            {
                XtraMessageBox.Show("Please enter the Outlet Code!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOutletCode.Focus();
                return;
            }

            var payload = new OutletcodeClas
            {
                OutletCode = txtOutletCode.Text.Trim(),
                IsActive = chkstatus.Checked
            };

            bool ok;

            if (string.IsNullOrEmpty(editid))
            {
                // Add New -> POST
                ok = await _api.PostAsync("api/outletcode", payload);
            }
            else
            {
                // Edit -> PUT
                payload.Id = Convert.ToInt32(editid);

                try
                {
                    ok = await _api.PutAsync($"api/outletcode/{editid}", payload);
                }
                catch (Exception ex)
                {
                    // PutAsync throw (មិន SafeCall) -> ចាប់ត្រង់នេះ
                    XtraMessageBox.Show(ex.Message, "Update failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!ok) return;   // error message បង្ហាញ​ក្នុង controller រួច

            XtraMessageBox.Show(
                string.IsNullOrEmpty(editid) ? "Saved successfully!" : "Record updated successfully!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            editid = null;
            btnSave.Text = "SAVE";
            btnClear.Visible = false;

            txtOutletCode.Clear();
            chkstatus.Checked = true;

            await LoadDataAsync();
            await LoadNextIdAsync();
        }

        // ================= UPDATE button (fill form) =================
        private void btnmainUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdOutlet.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view != null && view.GetFocusedRowCellValue("Id") != null)
            {
                editid = view.GetFocusedRowCellValue("Id").ToString();

                txtOutletCode.Text = view.GetFocusedRowCellValue("OutletCode").ToString();
                chkstatus.Checked = Convert.ToBoolean(view.GetFocusedRowCellValue("IsActive"));

                btnSave.Text = "UPDATE";
                btnClear.Visible = true;
                txtOutletCode.Focus();
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record to update.",
                    "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================= DELETE =================
        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdOutlet.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            object idObj = view.GetFocusedRowCellValue("Id");
            if (idObj == null)
            {
                XtraMessageBox.Show("Please select a row to delete!");
                return;
            }

            string id = idObj.ToString();

            if (XtraMessageBox.Show("Are you sure you want to delete this record?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/outletcode/{id}");
                if (!ok) return;

                await LoadDataAsync();
                txtOutletCode.Clear();
                editid = null;

                XtraMessageBox.Show("Record deleted successfully!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error deleting record: " + ex.Message);
            }
        }

        // ================= NEXT ID =================
        // ដក MAX(Id) ចេញ ព្រោះ client លែង hit database ផ្ទាល់។
        // pull list ពី API មក compute next id។
        public async Task LoadNextIdAsync()
        {
            var list = await _api.GetAsync<List<OutletcodeClas>>("api/outletcode");
            if (list == null) return;

            int nextId = 1;
            foreach (var item in list)
                if (item.Id >= nextId) nextId = item.Id + 1;

            txtOutletCode.Text = string.Format("UNT-{0}", nextId);
        }

        // ================= events =================
        private async void guiOutletCode_Load(object sender, EventArgs e)
        {
            _api = APIGlobals.Api;
            await LoadDataAsync();
            // await LoadNextIdAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editid = null;
            txtOutletCode.Clear();
            btnSave.Text = "SAVE";
            txtOutletCode.Focus();
            btnClear.Visible = false;
        }

        private void gvOutlet_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Appearance.BackColor = (e.RowHandle % 2 == 0)
                    ? Color.LightYellow : Color.LightCyan;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }
    }
}