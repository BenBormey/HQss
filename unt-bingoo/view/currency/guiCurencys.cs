using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.currency
{
    public partial class guiCurencys : XtraForm
    {
        private APIsController _api;
        private BindingList<CurrencyItem> _list = new BindingList<CurrencyItem>();
        private int? _editingId = null;

        // item សម្រាប់ ComboBox supplier (រក្សា Id + Name)
        private class ComboItem
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public guiCurencys()
        {
            InitializeComponent();

            gridViewCurrency.Appearance.HeaderPanel.BackColor = Color.DimGray;
            gridViewCurrency.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridViewCurrency.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridViewCurrency.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewCurrency.Appearance.HeaderPanel.Options.UseFont = true;
        }

        private async void guiCurencys_Load(object sender, EventArgs e)
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

                await LoadSuppliers();
                await LoadData();
                await GenerateNextNo();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task LoadSuppliers()
        {
            try
            {
                var suppliers = await _api.GetAsync<List<SupplierItem>>("api/Supplier");

                cmbSupplier.Items.Clear();
                // ជម្រើសទី១ = all suppliers (Id = null)
                cmbSupplier.Items.Add(new ComboItem { Id = null, Name = "( all suppliers )" });

                if (suppliers != null)
                {
                    foreach (var s in suppliers)
                    {
                        cmbSupplier.Items.Add(new ComboItem { Id = s.SupplierID, Name = s.SupplierName });
                    }
                }

                cmbSupplier.SelectedIndex = 0; // default = all suppliers
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load suppliers error: " + ex.Message);
            }
        }

        private async Task LoadData()
        {
            try
            {
                var data = await _api.GetAsync<List<CurrencyItem>>("api/Currency");
                if (data == null) return;

                _list = new BindingList<CurrencyItem>(data);
                gridControlCurrency.DataSource = _list;
                gridViewCurrency.BestFitColumns();

                lblCountRow.Text = $"Count Row : {_list.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // generate CUR00001, CUR00002... ស្វ័យប្រវត្តិ
        private async Task GenerateNextNo()
        {
            try
            {
                var data = await _api.GetAsync<List<CurrencyItem>>("api/Currency");
                int next = 1;
                if (data != null && data.Any())
                {
                    int maxNum = data
                        .Select(c => ExtractNumber(c.CurrencyNo))
                        .DefaultIfEmpty(0)
                        .Max();
                    next = maxNum + 1;
                }
                txtCurrencyNo.Text = "CUR" + next.ToString("D5"); // D5 = 00001
            }
            catch
            {
                txtCurrencyNo.Text = "CUR00001";
            }
        }

        private int ExtractNumber(string currencyNo)
        {
            if (string.IsNullOrEmpty(currencyNo)) return 0;
            string digits = new string(currencyNo.Where(char.IsDigit).ToArray());
            return int.TryParse(digits, out int n) ? n : 0;
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
                    ok = await _api.PostAsync("api/Currency", model);
                    if (ok) XtraMessageBox.Show("Saved successfully!");
                }
                else
                {
                    ok = await _api.PutAsync($"api/Currency/{_editingId}", model);
                    if (ok) XtraMessageBox.Show("Updated successfully!");
                }

                if (ok)
                {
                    await LoadData();
                    await GenerateNextNo();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Operation failed!");
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var row = gridViewCurrency.GetFocusedRow() as CurrencyItem;
            if (row == null)
            {
                XtraMessageBox.Show("Please select a currency to delete.");
                return;
            }

            var result = XtraMessageBox.Show(
                $"Are you sure you want to delete '{row.CurrencyName}' ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/Currency/{row.Id}");
                if (ok)
                {
                    XtraMessageBox.Show("Deleted successfully!");
                    await LoadData();
                    await GenerateNextNo();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Delete failed.");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to delete: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void btnClose_Click(object sender, EventArgs e) => Close();

        // ចុច row → បំពេញ form ឱ្យ edit
        private void gridViewCurrency_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var row = gridViewCurrency.GetFocusedRow() as CurrencyItem;
            if (row == null) return;

            _editingId = row.Id;
            txtCurrencyNo.Text = row.CurrencyNo;
            txtCurrencyName.Text = row.CurrencyName;
            txtCurrencyCode.Text = row.CurrencyCode;
            txtRate.Text = row.BuyRate.ToString();   // Rate តែមួយ → យកពី BuyRate
            chkIsBase.Checked = row.IsBase;
            chkActive.Checked = row.Active;

            SelectSupplierInCombo(row.SupplierId);

            btnAdd.Text = "Update";
        }

        private void SelectSupplierInCombo(int? supplierId)
        {
            for (int i = 0; i < cmbSupplier.Items.Count; i++)
            {
                if (cmbSupplier.Items[i] is ComboItem ci && ci.Id == supplierId)
                {
                    cmbSupplier.SelectedIndex = i;
                    return;
                }
            }
            cmbSupplier.SelectedIndex = 0; // បើរកមិនឃើញ → all suppliers
        }

        private CurrencyItem GetFormData()
        {
            decimal.TryParse(txtRate.Text, out decimal rate);

            int? supplierId = null;
            if (cmbSupplier.SelectedItem is ComboItem ci)
                supplierId = ci.Id;

            return new CurrencyItem
            {
                Id = _editingId ?? 0,
                CurrencyNo = txtCurrencyNo.Text.Trim(),
                CurrencyCode = txtCurrencyCode.Text.Trim().ToUpper(),
                CurrencyName = txtCurrencyName.Text.Trim(),
                BuyRate = rate,    // Rate តែមួយ → ដាក់ស្មើគ្នាទាំង Buy និង Sell
                SellRate = rate,
                SupplierId = supplierId,
                IsBase = chkIsBase.Checked,
                Active = chkActive.Checked
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCurrencyName.Text))
            {
                XtraMessageBox.Show("Description is required.");
                txtCurrencyName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCurrencyCode.Text))
            {
                XtraMessageBox.Show("Currency code is required.");
                txtCurrencyCode.Focus();
                return false;
            }
            if (!decimal.TryParse(txtRate.Text, out _))
            {
                XtraMessageBox.Show("Rate must be a number.");
                txtRate.Focus();
                return false;
            }
            return true;
        }

        private async void ClearForm()
        {
            _editingId = null;
            txtCurrencyName.Text = "";
            txtCurrencyCode.Text = "";
            txtRate.Text = "";
            cmbSupplier.SelectedIndex = 0; // all suppliers
            chkIsBase.Checked = false;
            chkActive.Checked = true;
            btnAdd.Text = "Save";
            await GenerateNextNo();
        }

        private void btnmainEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewCurrency.GetFocusedRow() as CurrencyItem;
            if (row == null) return;

            _editingId = row.Id;

            txtCurrencyNo.Text = row.CurrencyNo;
            txtCurrencyName.Text = row.CurrencyName;
            txtCurrencyCode.Text = row.CurrencyCode;
            txtRate.Text = row.BuyRate.ToString();

            chkIsBase.Checked = row.IsBase;
            chkActive.Checked = row.Active;

            SelectSupplierInCombo(row.SupplierId);

            btnAdd.Text = "Update";

            txtCurrencyName.Focus();
        }

        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewCurrency.GetFocusedRow() as CurrencyItem;
            if (row == null)
            {
                XtraMessageBox.Show("Please select a currency.");
                return;
            }

            DialogResult result = XtraMessageBox.Show(
                $"Are you sure you want to delete '{row.CurrencyName}' ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.DeleteAsync($"api/Currency/{row.Id}");

                if (ok)
                {
                    XtraMessageBox.Show("Deleted successfully.");

                    await LoadData();
                    await GenerateNextNo();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Delete failed.");
                }
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
    }
}