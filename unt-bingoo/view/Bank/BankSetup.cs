using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using unt_bingoo.Controller;
using unt_bingoo.Declares;

using BankModel = unt_bingoo.Class.BankSetup;

namespace unt_bingoo.view.Bank
{
    public partial class BankSetup : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        private int _currentBankId = 0; // 0 = new record

        public BankSetup()
        {
            InitializeComponent();
        }

        private void BankSetup_Load(object sender, EventArgs e)
        {
            _api = APIGlobals.Api;

            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            LoadCurrencyOptions();
            LoadBankTypeOptions();
            LoadGrid();
            ClearForm();
        }

        private void LoadCurrencyOptions()
        {
            cmbCurrency.Properties.Items.Clear();
            cmbCurrency.Properties.Items.AddRange(new object[] { "USD", "KHR", "EUR" });
        }

        private void LoadBankTypeOptions()
        {
            cmbBankType.Properties.Items.Clear();
            cmbBankType.Properties.Items.AddRange(new object[] { "Bank", "E-Wallet", "Payment Gateway" });
        }

        private async void LoadGrid()
        {
            try
            {
                var list = await _api.GetAsync<List<BankModel>>("api/BankSetup");

                gridControlBank.DataSource = list;
                gridViewBank.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Keep Active / Deactive mutually exclusive, like a two-option radio group.
        private bool _suppressStatusEvents;

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressStatusEvents) return;
            _suppressStatusEvents = true;
            if (chkActive.Checked)
                chkDeactive.Checked = false;
            _suppressStatusEvents = false;
        }

        private void chkDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressStatusEvents) return;
            _suppressStatusEvents = true;
            if (chkDeactive.Checked)
                chkActive.Checked = false;
            _suppressStatusEvents = false;
        }

        private void gridControlBank_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewBank.FocusedRowHandle < 0)
                return;

            if (!(gridViewBank.GetRow(gridViewBank.FocusedRowHandle) is BankModel row))
                return;

            LoadIntoForm(row);
        }

        private void LoadIntoForm(BankModel bank)
        {
            _currentBankId = bank.BankId;

            txtBankCode.Text = bank.BankCode;
            txtBankName.Text = bank.BankName;
            cmbBankType.Text = bank.BankType;
            txtMerchantId.Text = bank.MerchantId;
            txtMerchantName.Text = bank.MerchantName;
            txtApiUrl.Text = bank.ApiUrl;
            txtApiKey.Text = bank.ApiKey;
            txtApiSecret.Text = bank.ApiSecret;
            txtCallbackUrl.Text = bank.CallbackUrl;
            cmbCurrency.Text = bank.Currency;
            chkIsDefault.Checked = bank.IsDefault;

            chkActive.Checked = bank.IsActive;
            chkDeactive.Checked = !bank.IsActive;
        }

        private void ClearForm()
        {
            _currentBankId = 0;

            txtBankCode.Text = "";
            txtBankName.Text = "";
            cmbBankType.SelectedIndex = -1;
            txtMerchantId.Text = "";
            txtMerchantName.Text = "";
            txtApiUrl.Text = "";
            txtApiKey.Text = "";
            txtApiSecret.Text = "";
            txtCallbackUrl.Text = "";
            cmbCurrency.SelectedIndex = -1;
            chkIsDefault.Checked = false;

            chkActive.Checked = true;
            chkDeactive.Checked = false;

            txtBankCode.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBankCode.Text))
            {
                XtraMessageBox.Show("Please enter Bank Code.", "Bank Code",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBankCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBankName.Text))
            {
                XtraMessageBox.Show("Please enter Bank Name.", "Bank Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBankName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCurrency.Text))
            {
                XtraMessageBox.Show("Please select Currency.", "Currency",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCurrency.Focus();
                return false;
            }

            return true;
        }

        private BankModel GetFormData()
        {
            return new BankModel
            {
                BankId = _currentBankId,
                BankCode = txtBankCode.Text.Trim(),
                BankName = txtBankName.Text.Trim(),
                BankType = cmbBankType.Text.Trim(),
                MerchantId = txtMerchantId.Text.Trim(),
                MerchantName = txtMerchantName.Text.Trim(),
                ApiUrl = txtApiUrl.Text.Trim(),
                ApiKey = txtApiKey.Text.Trim(),
                ApiSecret = txtApiSecret.Text.Trim(),
                CallbackUrl = txtCallbackUrl.Text.Trim(),
                Currency = cmbCurrency.Text.Trim(),
                IsDefault = chkIsDefault.Checked,
                IsActive = chkActive.Checked
            };
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var bank = GetFormData();
                bool success;

                if (_currentBankId == 0)
                {
                    // CREATE: POST api/BankSetup
                    success = await _api.PostAsync("api/BankSetup", bank);
                }
                else
                {
                
                    success = await _api.PutAsync($"api/BankSetup/{_currentBankId}", bank);
                }

                if (success)
                {
                    XtraMessageBox.Show("Save Success", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadGrid();
                }
                else
                {
                    XtraMessageBox.Show("Save failed. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentBankId == 0)
            {
                XtraMessageBox.Show("Please select a bank from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show("Are you sure you want to delete this bank?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // DELETE: DELETE api/BankSetup/{id}
                // NOTE: adjust to match your APIsController's actual delete method name.
                bool success = await _api.DeleteAsync($"api/BankSetup/{_currentBankId}");

                if (success)
                {
                    XtraMessageBox.Show("Deleted successfully.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadGrid();
                }
                else
                {
                    XtraMessageBox.Show("Delete failed. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}