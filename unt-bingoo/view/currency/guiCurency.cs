using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.currency
{
    public partial class guiCurency : XtraForm
    {
        private APIsController _api; // Shared session
        private BindingList<CurrencyItem> _list =
            new BindingList<CurrencyItem>();

        private int? _editingId = null;

        public guiCurency()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private async void guiCurency_Load(object sender, EventArgs e)
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
            var data =
                await _api.GetAsync<System.Collections.Generic.List<CurrencyItem>>(
                    "api/currency");

            _list = new BindingList<CurrencyItem>(data);

            gridControl1.DataSource = _list;

            gridView1.BestFitColumns();

            lblCountRow.Text = $"Count : {_list.Count}";
        }

        // ================= SAVE =================
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                bool ok;

                // ============ ADD ============
                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/currency", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    _list.Add(model);

                    XtraMessageBox.Show("Added!");
                }
                // ============ UPDATE ============
                else
                {
                    ok = await _api.PutAsync($"api/currency/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    var item = _list.FirstOrDefault(x => x.Id == _editingId);

                    if (item != null)
                    {
                        item.CurrencyCode = model.CurrencyCode;
                        item.CurrencyName = model.CurrencyName;
                        item.BuyRate = model.BuyRate;
                        item.SellRate = model.SellRate;
                        item.IsBase = model.IsBase;
                        item.Active = model.Active;
                    }

                    gridView1.RefreshData();

                    XtraMessageBox.Show("Updated!");
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= DELETE =================
        private async void btnDelete_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as CurrencyItem;

            if (row == null) return;

            if (XtraMessageBox.Show("Delete?",
                "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/currency/{row.Id}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed!");
                    return;
                }

                _list.Remove(row);

                lblCountRow.Text = $"Count : {_list.Count}";

                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= EDIT =================
        private void btnedit_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as CurrencyItem;

            if (row == null) return;

            _editingId = row.Id;

            txtCurrencyCode.Text = row.CurrencyCode;
            txtCurrencyName.Text = row.CurrencyName;
            txtBuyRate.Text = row.BuyRate.ToString();
            txtSellRate.Text = row.SellRate.ToString();

            chkIsBase.Checked = row.IsBase;
            chkActive.Checked = row.Active;

            btnSave.Text = "Update";
        }

        // ================= HELPER =================

        private CurrencyItem GetFormData()
        {
            return new CurrencyItem
            {
                Id = _editingId ?? 0,

                CurrencyCode = txtCurrencyCode.Text.Trim(),
                CurrencyName = txtCurrencyName.Text.Trim(),

                BuyRate = decimal.Parse(txtBuyRate.Text.Trim()),
                SellRate = decimal.Parse(txtSellRate.Text.Trim()),

                IsBase = chkIsBase.Checked,
                Active = chkActive.Checked
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCurrencyCode.Text))
            {
                XtraMessageBox.Show("Currency Code required!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCurrencyName.Text))
            {
                XtraMessageBox.Show("Currency Name required!");
                return false;
            }

            if (!decimal.TryParse(txtBuyRate.Text, out _))
            {
                XtraMessageBox.Show("Invalid Buy Rate!");
                return false;
            }

            if (!decimal.TryParse(txtSellRate.Text, out _))
            {
                XtraMessageBox.Show("Invalid Sell Rate!");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtCurrencyCode.Text = "";
            txtCurrencyName.Text = "";
            txtBuyRate.Text = "";
            txtSellRate.Text = "";

            chkIsBase.Checked = false;
            chkActive.Checked = true;

            _editingId = null;

            btnSave.Text = "Save";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
