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
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Product
{
    public partial class FrmProductsBarcode : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api = new APIsController();

        private ApplicationFramework App = new ApplicationFramework();

        public string RWord_Searching { get; set; }

        public DataTable RProductList { get; set; }

        public string RCurrentBarcode { get; set; }

        public long RProId { get; set; }



        private bool lIsMainProducts { get; set; }

        private string lTblProductName { get; set; }
        private  mainForm mdi;

        public FrmProductsBarcode(mainForm mdi , bool lIsMainProducts)
        {
            InitializeComponent();
            this.mdi = mdi;
            this.lIsMainProducts = lIsMainProducts;
        }

        private void FrmProductsBarcode_Load(object sender, EventArgs e)
        {
            App.SetEnableController(
                !string.IsNullOrWhiteSpace(RCurrentBarcode),
                BtnSetAsOldCode);

            if (BtnSetAsOldCode.Enabled == false)
            {
                BtnChange.Text = "&Set";
            }
            else
            {
                BtnChange.Text = "&Ok";
            }
            TxtBarcode.Focus();
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

        private async void BtnSetAsOldCode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            if (string.IsNullOrWhiteSpace(TxtBarcode.Text))
            {
                MessageBox.Show(
                    "Please enter the old code which you want to set.",
                    "Enter Old Code",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtBarcode.Focus();
                return;
            }

            string barcode = string.Format(
                "{0}{1:0000000000000}",
                CmbSpecial.Text.Trim(),
                Convert.ToDecimal(TxtBarcode.Text.Trim()));

            var existing = await _api.GetAsync<ProductItem>($"api/product/barcode/{barcode}");

            if (existing != null)
            {
                MessageBox.Show(
                    "This barcode already exists!",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (MessageBox.Show(
                  $"Are you sure, you want to add the old barcode <{barcode}> for the new barcode <{RCurrentBarcode.Trim()}>?(Yes/No)",
                  "Confirm Set As Old Code",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                await _api.PutAsync(
                    $"api/product/{RProId}/old-barcode",
                    new { Value = barcode });

                MessageBox.Show(
                    "Setting as old code have been completed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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

            string barcode = $"{CmbSpecial.Text.Trim()}{Convert.ToInt64(TxtBarcode.Text.Trim()):0000000000000}";

            var existing = await _api.GetAsync<ProductItem>($"api/product/barcode/{barcode}");

            if (existing != null)
            {
                MessageBox.Show(
                    "This barcode already exists!",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (string.IsNullOrWhiteSpace(RCurrentBarcode))
            {
                Initialized.R_Barcode = barcode;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (MessageBox.Show(
                    $"Are you sure you want to change barcode <{RCurrentBarcode}> to <{barcode}> ?",
                    "Confirm Change Barcode",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                await _api.PutAsync(
                    $"api/product/{RProId}/barcode",
                    new { Value = barcode });

                MessageBox.Show(
                    "Changing barcode completed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Initialized.R_Barcode = barcode;
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

        private void TxtBarcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBarcode.Text))
            {
                return;
            }

            TxtBarcode.Text = string.Format(
                "{0:0000000000000}",
                Convert.ToInt64(TxtBarcode.Text.Trim()));
        }

        private void TxtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnChange_Click(BtnChange, EventArgs.Empty);
            }
        }

        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}