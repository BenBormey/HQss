using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.currency
{
    public partial class guiCurency : XtraForm
    {
        private BindingList<CurrencyItem> _currencyList = new BindingList<CurrencyItem>();
        private readonly APIsController _api;
        private int? _editingId = null;

        public guiCurency()
        {
            InitializeComponent();
            _api = new APIsController();
        }

        private async void guiCurency_Load(object sender, EventArgs e)
        {
            await LoadCurrencyAsync();
        }

        private async Task LoadCurrencyAsync()
        {
            try
            {
                var list = await _api.GetCurrencyAsync();
                if (list == null)
                    _currencyList = new BindingList<CurrencyItem>();
                else
                    _currencyList = new BindingList<CurrencyItem>(list);

                gridControl1.DataSource = _currencyList;
                gridView1.BestFitColumns();
                lblCountRow.Text = $"Count Row: {_currencyList.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var api = new APIsController();

                var model = new CurrencyItem
                {
                    Id = _editingId ?? 0,
                    CurrencyCode = txtCurrencyCode.Text.Trim(),
                    CurrencyName = txtCurrencyName.Text.Trim(),
                    BuyRate = decimal.Parse(txtBuyRate.Text.Trim()),
                    SellRate = decimal.Parse(txtSellRate.Text.Trim()),
                    IsBase = chkIsBase.Checked,
                    Active = chkActive.Checked
                };

                bool success;
                if (isUpdateMode)
                    success = await _api.UpdateCurrencyAsync(model.Id, model);
                else
                    success = await _api.AddCurrencyAsync(model);

                if (success)
                {
                    await LoadCurrencyAsync();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtCurrencyCode.Text = string.Empty;
            txtCurrencyName.Text = string.Empty;
            txtBuyRate.Text = string.Empty;
            txtSellRate.Text = string.Empty;
            chkIsBase.Checked = false;
            chkActive.Checked = true;
            _editingId = null;
            txtCurrencyCode.Focus();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCurrencyCode.Text))
            {
                XtraMessageBox.Show("Currency code is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrencyCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCurrencyName.Text))
            {
                XtraMessageBox.Show("Currency name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrencyName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtBuyRate.Text.Trim(), out _))
            {
                XtraMessageBox.Show("Buy rate is invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuyRate.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSellRate.Text.Trim(), out _))
            {
                XtraMessageBox.Show("Sell rate is invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSellRate.Focus();
                return false;
            }

            return true;
        }
        private bool isUpdateMode = false;

        private void btnedit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

            isUpdateMode = true;
            btnSave.Text = "Update";
            //btnSave.Appearance.BackColor = Color.Orange;

            txtCurrencyCode.Focus();
        }

        private async void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as CurrencyItem;
            if (row == null) return;

            var confirm = XtraMessageBox.Show(
                $"Delete currency {row.CurrencyCode} ?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var success = await _api.DeleteCurrencyAsync(row.Id);
                if (success)
                {
                    XtraMessageBox.Show("Deleted successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCurrencyAsync();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Delete failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

