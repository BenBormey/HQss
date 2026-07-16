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
    public partial class guiHourOpration : DevExpress.XtraEditors.XtraForm
    {
        private int? _editingId = null;
        private APIsController _api;
        private BindingList<HourOperationItem> _list =
          new BindingList<HourOperationItem>();
        
        public guiHourOpration()
        {
            InitializeComponent();
      
        }
        private bool ValidateForm()
        {
          
            if (!chk24Hours.Checked)
            {
                if (string.IsNullOrWhiteSpace(cboOpenTime.Text))
                {
                    XtraMessageBox.Show("Please select Open Time.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cboOpenTime.Focus();
                    return false;
                }

                if (cboOpenTime.EditValue == null)
                {
                    XtraMessageBox.Show("Please select Open Time.");
                    cboOpenTime.Focus();
                    return false;
                }

                if (cboCloseTime.EditValue == null)
                {
                    XtraMessageBox.Show("Please select Close Time.");
                    cboCloseTime.Focus();
                    return false;
                }

                TimeSpan openTime = ((DateTime)cboOpenTime.EditValue).TimeOfDay;
                TimeSpan closeTime = ((DateTime)cboCloseTime.EditValue).TimeOfDay;

                if (closeTime <= openTime)
                {
                    XtraMessageBox.Show("Close Time must be greater than Open Time.");
                    cboCloseTime.Focus();
                    return false;
                }
            }

            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var model = GetData();
                bool exists = _list.Any(x =>
    x.OpenTime == model.OpenTime &&
    x.CloseTime == model.CloseTime &&
    (_editingId == null || x.Id != _editingId));

                if (exists)
                {
                    XtraMessageBox.Show(
                        "This operating time already exists.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                bool result;

                if (_editingId == null)
                {
                    // Create
                    result = await _api.PostAsync("api/HourOperation", model);

                    if (result)
                    {
                        XtraMessageBox.Show("Saved successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Save failed.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Update
                    result = await _api.PutAsync("api/HourOperation", model);

                    if (result)
                    {
                        XtraMessageBox.Show("Updated successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Update failed.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private HourOperationItem GetData()
        {
            TimeSpan openTime;
            TimeSpan closeTime;

            if (chk24Hours.Checked)
            {
                openTime = TimeSpan.Zero;                 // 00:00
                closeTime = new TimeSpan(23, 59, 0);      // 23:59
            }
            else
            {
                openTime = ((DateTime)cboOpenTime.EditValue).TimeOfDay;
                closeTime = ((DateTime)cboCloseTime.EditValue).TimeOfDay;
            }

            return new HourOperationItem
            {
                Id = _editingId ?? 0,
                OpenTime = openTime,
                CloseTime = closeTime,
                Is24Hours = chk24Hours.Checked,
                Status = chkActive.Checked
            };
        }
        private async void guiHourOpration_Load(object sender, EventArgs e)
        {
            this.btnClose.Visible = true;
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
            cboOpenTime.Time = DateTime.Today.AddHours(6);
        }
        private void ClearForm()
        {
            _editingId = null;

        

            chk24Hours.Checked = false;

            cboOpenTime.Text = "08:00";
            cboCloseTime.Text = "21:00";

            chkActive.Checked = true;
            chkDeactive.Checked = false;

            btnSave.Text = "ADD";

            ApplyIs24HoursState();
            this.btnClose.Visible = false;
    
        }
        private void ApplyIs24HoursState()
        {
            bool enable = !chk24Hours.Checked;

            cboOpenTime.Enabled = enable;
            cboCloseTime.Enabled = enable;
        }
        private async Task LoadData()
        {
            try
            {
                var data = await _api.GetAsync<List<HourOperationItem>>("api/HourOperation");

                if (data == null)
                    data = new List<HourOperationItem>();

                _list = new BindingList<HourOperationItem>(data);

                gridControlHour.DataSource = _list;

                gridViewHour.BestFitColumns();

                lblTotalRecords.Text = $"Total Records : {_list.Count}";
                lblRecordInfo.Text = _list.Count == 0
                    ? "0 - 0 of 0 records"
                    : $"1 - {_list.Count} of {_list.Count} records";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void repo24Check_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewHour.GetFocusedRow() as HourOperationItem;

            if (row == null)
            {
                XtraMessageBox.Show("Please select a record.");
                return;
            }

            _editingId = row.Id;
     

            cboOpenTime.Text = row.OpenTime.ToString(@"hh\:mm");
            cboCloseTime.Text = row.CloseTime.ToString(@"hh\:mm");

            chk24Hours.Checked = row.Is24Hours;

            chkActive.Checked = row.Status;
            chkDeactive.Checked = !row.Status;

            ApplyIs24HoursState();
            btnClose.Visible = true;
            btnSave.Text = "Update";
         
        }

        private async void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewHour.GetFocusedRow() as HourOperationItem;

            if (row == null)
            {
                XtraMessageBox.Show("Please select a record.");
                return;
            }

            var result = XtraMessageBox.Show(
                $"Are you sure you want to delete ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/HourOperation/{row.Id}");

                if (ok)
                {
                    XtraMessageBox.Show(
                        "Deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadData();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Delete failed.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
   
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                chkDeactive.Checked = false;
            }
            else
            {
                // កុំឱ្យអត់ជ្រើសទាំងពីរ
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
                // កុំឱ្យអត់ជ្រើសទាំងពីរ
                if (!chkActive.Checked)
                    chkDeactive.Checked = true;
            }
        }

        private void chk24Hours_CheckedChanged(object sender, EventArgs e)
        {
            if (chk24Hours.Checked)
            {
                // Check if 24 Hours already exists
                bool exists24 = _list.Any(x =>
                    x.Is24Hours &&
                    (_editingId == null || x.Id != _editingId));

                if (exists24)
                {
                    XtraMessageBox.Show(
                        "24 Hours already exists.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    chk24Hours.Checked = false;
                    return;
                }

                // Set 24 Hours time
                cboOpenTime.EditValue = DateTime.Today; // 00:00
                cboCloseTime.EditValue = DateTime.Today.AddHours(23).AddMinutes(59); // 23:59
            }
            else
            {
                // Default time when unchecked
                cboOpenTime.EditValue = DateTime.Today.AddHours(8);   // 08:00
                cboCloseTime.EditValue = DateTime.Today.AddHours(21); // 21:00
            }

            // Enable/Disable controls
            ApplyIs24HoursState();
        }
    }
}