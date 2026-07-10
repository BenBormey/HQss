using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Product
{
    public partial class ShelfLife : XtraForm
    {
        private readonly APIsController _api = APIGlobals.Api;

        public string editid = null;

        public ShelfLife()
        {
            InitializeComponent();

            gvShelfLife.Appearance.HeaderPanel.BackColor = Color.DimGray;
            gvShelfLife.Appearance.HeaderPanel.ForeColor = Color.Black;
            gvShelfLife.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gvShelfLife.Appearance.HeaderPanel.Options.UseBackColor = true;
            gvShelfLife.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvShelfLife.Appearance.HeaderPanel.Options.UseFont = true;
        }

        private async void ShelfLife_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void txtShelfLifeValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }


        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<ShelfLifeClass>>("api/shelflife");
            grdShelfLife.DataSource = list ?? new List<ShelfLifeClass>();
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtShelfLifeValue.Text))
                {
                    XtraMessageBox.Show("Please enter Shelf Life Value");
                    txtShelfLifeValue.Focus();
                    return;
                }

                var payload = new ShelfLifeClass
                {
                    ShelfLifeName = "",
                    IsActive = chkIsActive.Checked,
                    ShelfLifeValue = Convert.ToInt32(txtShelfLifeValue.Text),
                    ShelfLifeUnit = cmbShelfLifeUnit.Text.Trim()
                };

                bool ok;

                if (string.IsNullOrEmpty(editid))
                {
                    // Add -> POST
                    ok = await _api.PostAsync("api/shelflife", payload);
                }
                else
                {
                    // Update -> PUT
                    payload.Id = Convert.ToInt32(editid);

                    try
                    {
                        ok = await _api.PutAsync($"api/shelflife/{editid}", payload);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                        return;
                    }
                }

                if (!ok) return;

                XtraMessageBox.Show(
                    string.IsNullOrEmpty(editid) ? "Saved Successfully" : "Updated Successfully");

                editid = null;
                btnSave.Text = "Save";

                ClearControl();
                await LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void ClearControl()
        {
            txtShelfLife.Clear();
            txtShelfLifeValue.Clear();
            cmbShelfLifeUnit.SelectedIndex = -1;
            chkIsActive.Checked = true;
            btnClear.Visible = false;
            txtShelfLife.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
            editid = null;
            btnSave.Text = "ADD";
            btnClear.Visible = false;
        }


        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShelfLifeClass item = gvShelfLife.GetFocusedRow() as ShelfLifeClass;
            if (item == null) return;

            editid = item.Id.ToString();

            txtShelfLife.Text = item.ShelfLifeName;
            txtShelfLifeValue.Text = item.ShelfLifeValue.ToString();
            cmbShelfLifeUnit.Text = item.ShelfLifeUnit;
            chkIsActive.Checked = item.IsActive;

            btnSave.Text = "Update";
            txtShelfLife.Focus();
            btnClear.Visible = true;
        }

        private async void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShelfLifeClass item = gvShelfLife.GetFocusedRow() as ShelfLifeClass;
            if (item == null) return;

            DialogResult result = XtraMessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/shelflife/{item.Id}");
                if (!ok) return;

                XtraMessageBox.Show("Deleted Successfully");

                await LoadData();
                ClearControl();

                editid = null;
                btnSave.Text = "Save";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }

   
}