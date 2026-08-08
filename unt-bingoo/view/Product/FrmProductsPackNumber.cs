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
using unt_bingoo.Declares;

namespace unt_bingoo.view.Product
{
    public partial class FrmProductsPackNumber : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api = APIGlobals.Api ?? new APIsController();

        public string RWord_Searching;
        public DataTable RProductList;
        public string RUnitNumber;
        public string RCurrentBarcode;
        public decimal RProId;
        private string SpecialCode;

        public mainForm mdi_ { get; set; }
        private bool lIsMainProducts { get; set; }
        private string lTblProductName { get; set; }

        public FrmProductsPackNumber(mainForm mdi_, bool lIsMainProducts)
        {
            InitializeComponent();
            this.mdi_ = mdi_;
            this.lIsMainProducts = lIsMainProducts;
            this.lTblProductName = "";

            if (!this.lIsMainProducts)
            {
                this.lTblProductName = "Consignment_";
            }
        }

        private void DataSources(
            System.Windows.Forms.ComboBox comboBoxName,
            DataTable dTable,
            string displayMember,
            string valueMember)
        {
            comboBoxName.DataSource = dTable;
            comboBoxName.DisplayMember = displayMember;
            comboBoxName.ValueMember = valueMember;
            comboBoxName.SelectedIndex = -1;
        }

        private async void BtnChange_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(TxtBarcode.Text))
            {
                MessageBox.Show(
                    "Please enter the barcode which you want to set.",
                    "Enter Barcode",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtBarcode.Focus();
                return;
            }

            string barcode = string.Format(
                "{0}{1:0000000000000}",
                SpecialCode,
                Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtBarcode.Text) ? "0" : TxtBarcode.Text.Trim()));

            var existing = await _api.GetAsync<ProductItem>($"api/product/barcode/{TxtBarcode.Text.Trim()}");

            if (existing != null)
            {
                MessageBox.Show(
                    "This barcode is existed already (Products)!",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // This dialog only verifies the barcode isn't already taken and
            // hands the value back to the caller (guiProductOutlet reads
            // Initialized.R_Barcode and puts it straight into TxtPackNumber).
            // Persisting it happens when the parent product form saves the
            // whole record — calling the pack-number PUT endpoint here
            // assumed RProId already existed as a saved product, which fails
            // with "Product not found" while a new product is still being
            // drafted and hasn't been saved yet.
            Initialized.R_Barcode = barcode;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void BtnClearPackNumber_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            if (MessageBox.Show(
                    $"Are you sure, you want to clear the pack number <{RCurrentBarcode}>?(Yes/No)",
                    "Confirm Clear Pack Number",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                await _api.PutAsync(
                    $"api/product/{RProId}/pack-number",
                    new { Value = (string)null });

                MessageBox.Show(
                    "Clearance pack number have been completed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Initialized.R_Barcode = "";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}