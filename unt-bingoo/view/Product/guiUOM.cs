using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Product
{
    public partial class guiUOM : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        public string editid = null;

        public guiUOM()
        {
            InitializeComponent();
        }

        private async void guiUOM_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            try
            {
                var list = await _api.GetAsync<List<UOMClass>>("api/uom") ?? new List<UOMClass>();

                grdUOM.DataSource = list;
                lblCount.Text = "Total Records: " + list.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUOMCode.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the UOM Code!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUOMCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUOMName.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the UOM Name!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUOMName.Focus();
                return;
            }

            string finalUOMCode = txtUOMCode.Text.Trim();
            string finalUOMName = txtUOMName.Text.Trim();
            bool isActive;

            if (chkstatus.Checked)
            {
                isActive = true;
            }
            else if (cheDeactive.Checked)
            {
                isActive = false;
            }
            else
            {
                MessageBox.Show("Please select Active or Inactive.");
                return;
            }

            var existing = await _api.GetAsync<List<UOMClass>>("api/uom") ?? new List<UOMClass>();

            bool duplicate = existing.Any(u =>
                string.Equals(u.UOMCode, finalUOMCode, StringComparison.OrdinalIgnoreCase) &&
                (string.IsNullOrEmpty(editid) || u.UOMId != Convert.ToInt32(editid)));

            if (duplicate)
            {
                XtraMessageBox.Show(
                    "UOM Code already exists!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUOMCode.Focus();
                return;
            }

            var uom = new UOMClass
            {
                UOMId = string.IsNullOrEmpty(editid) ? 0 : Convert.ToInt32(editid),
                UOMCode = finalUOMCode,
                UOMName = finalUOMName,
                IsActive = isActive
            };

            try
            {
                if (string.IsNullOrEmpty(editid))
                {
                    var ok = await _api.PostAsync("api/uom", uom);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Save failed.");
                        return;
                    }

                    XtraMessageBox.Show(
                        "Saved successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await _api.PutAsync($"api/uom/{editid}", uom);

                    XtraMessageBox.Show(
                        "Record updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    editid = null;
                    btnSave.Text = "SAVE";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
                return;
            }

            txtUOMCode.Text = string.Empty;
            txtUOMName.Text = string.Empty;
            chkstatus.Checked = true;

            await LoadData();
            txtUOMCode.Focus();
        }

        private void btnmainUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdUOM.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view != null && view.GetFocusedRowCellValue("UOMId") != null)
            {
                editid = view.GetFocusedRowCellValue("UOMId").ToString();

                txtUOMCode.Text = view.GetFocusedRowCellValue("UOMCode").ToString();
                txtUOMName.Text = view.GetFocusedRowCellValue("UOMName").ToString();
                chkstatus.Checked = Convert.ToBoolean(view.GetFocusedRowCellValue("IsActive"));

                btnSave.Text = "UPDATE";
                btnClear.Visible = true;
                txtUOMCode.Focus();
            }
            else
            {
                MessageBox.Show("Please select a valid record to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdUOM.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view == null) return;

            object idObj = view.GetFocusedRowCellValue("UOMId");

            if (idObj == null)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            editid = idObj.ToString();

            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = await _api.DeleteAsync($"api/uom/{editid}");

                    if (!ok)
                    {
                        MessageBox.Show("Delete failed.");
                        return;
                    }

                    await LoadData();
                    txtUOMCode.Text = string.Empty;
                    txtUOMName.Text = string.Empty;
                    chkstatus.Checked = true;
                    editid = null;
                    btnSave.Text = "SAVE";
                    btnClear.Visible = false;

                    MessageBox.Show("Record deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editid = null;

            txtUOMCode.Text = string.Empty;
            txtUOMName.Text = string.Empty;
            chkstatus.Checked = true;

            btnSave.Text = "SAVE";
            btnClear.Visible = false;

            txtUOMCode.Focus();
        }

        private void gvUOM_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.LightYellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightCyan;
                }
            }
        }

        private bool _changingStatus = false;

        private void chkstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (_changingStatus) return;

            _changingStatus = true;

            if (chkstatus.Checked)
            {
                cheDeactive.Checked = false;
            }
            else if (!cheDeactive.Checked)
            {
                chkstatus.Checked = true;
            }

            _changingStatus = false;
        }

        private void cheDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (_changingStatus) return;

            _changingStatus = true;

            if (cheDeactive.Checked)
            {
                chkstatus.Checked = false;
            }
            else if (!chkstatus.Checked)
            {
                cheDeactive.Checked = true;
            }

            _changingStatus = false;
        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
