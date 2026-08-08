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
    public partial class FrmProductsCaseNumber : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api = APIGlobals.Api ?? new APIsController();

        public string RWord_Searching;
        public DataTable RProductList;
        public string RUnitNumber;
        public string RCurrentBarcode;
        public long RProId;

        private string SpecialCode;

        public mainForm mdi_ { get; set; }

        private bool lIsMainProducts { get; set; }

        private string lTblProductName { get; set; }
        public FrmProductsCaseNumber(mainForm mdi  , bool lIsMainProducts)
        {
            InitializeComponent();
            this.mdi_ = mdi;
            this.lIsMainProducts = lIsMainProducts;
        }

        private void FrmProductsCaseNumber_Load(object sender, EventArgs e)
        {
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
                Convert.ToInt64(TxtBarcode.Text.Trim())
            );

            var existing = await _api.GetAsync<ProductItem>($"api/product/barcode/{barcode}");

            if (existing != null)
            {
                MessageBox.Show(
                    $"Barcode [{barcode}] already exists!",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // This dialog only verifies the barcode isn't already taken and
            // hands the value back to the caller (guiProductOutlet reads
            // Initialized.R_Barcode into TxtCaseNumber). Persisting happens
            // when the parent product form saves the whole record — RUnitNumber
            // being non-blank doesn't mean the product has actually been saved
            // yet (RProId), so calling the case-number PUT endpoint here failed
            // with "Product not found" for a still-unsaved product.
            Initialized.R_Barcode = barcode;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void BtnClearPackNumber_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            if (MessageBox.Show(
                    $"Are you sure, you want to clear the case number <{RCurrentBarcode}> ?",
                    "Confirm Clear Case Number",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                await _api.PutAsync(
                    $"api/product/{RProId}/case-number",
                    new { CaseNumber = (string)null });

                MessageBox.Show(
                    "Clearance case number have been completed!",
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
                    MessageBoxIcon.Error);
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                TxtBarcode.Text = Clipboard.GetText();
                TxtBarcode.SelectionStart = TxtBarcode.TextLength;
                TxtBarcode.Focus();
            }
        }

        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            //App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, "", 25);
        }
    }
}