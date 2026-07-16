using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Product
{
    public partial class FrmProductsSearch : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        public mainForm mdi_ { get; set; }

        public FrmProductsSearch(mainForm mdi)
        {
            InitializeComponent();
            this.mdi_ = mdi;
            _api = APIGlobals.Api;
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            this.Close();

            bool lIsMainProducts = this.rdbmainproducts.Checked;

            guiProductOutlet frm = new guiProductOutlet(this.mdi_, lIsMainProducts)
            {
                MdiParent = this.mdi_,
                WindowState = FormWindowState.Maximized
            };

            frm.PanelAccept.Visible = false;
            frm.Show();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            List<ProductItem> products;
            string keyword;
            if (string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                XtraMessageBox.Show(
                    "Please enter a search keyword.",
                    "Search Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                TxtSearch.Focus();
                return;
            }

            //if (string.IsNullOrWhiteSpace(TxtSearch.Text))
            //{

            //    var answer = XtraMessageBox.Show(
            //        "Do you want to search all products?",
            //        "Confirm Search",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question);

            //    if (answer == DialogResult.No)
            //    {
            //        TxtSearch.Focus();
            //        return;
            //    }


            //    keyword = string.Empty;

            //    products = await _api.GetAsync<List<ProductItem>>(
            //        "api/Product");
            //}
            else
            {
                keyword = TxtSearch.Text.Trim();

           
                if (RdbBarcode.Checked && keyword.Length <= 13)
                {
                    char firstChar = keyword[0];
                    string prefix = "";
                    long numberPart = 0;

                    if (char.IsDigit(firstChar))
                    {
                        long.TryParse(keyword, out numberPart);
                    }
                    else
                    {
                        prefix = firstChar.ToString();
                        long.TryParse(
                            keyword.Substring(1),
                            out numberPart);
                    }

                    keyword = $"{prefix}{numberPart:0000000000000}";
                }

                if (RdbBarcode.Checked)
                {
                    var product = await _api.GetAsync<ProductItem>(
                        $"api/Product/barcode/{keyword}");

                    products = product != null
                        ? new List<ProductItem> { product }
                        : new List<ProductItem>();
                }
                else if (RdbItemcodes.Checked)
                {
                  

                    products = await _api.GetAsync<List<ProductItem>>(
                        $"api/Product/search-sku?sku={Uri.EscapeDataString(keyword)}");
                }
                else
                {
                    products = await _api.GetAsync<List<ProductItem>>(
                          $"api/Product/search?name={Uri.EscapeDataString(keyword)}");
                }
            }

            if (products == null || products.Count == 0)
            {
                XtraMessageBox.Show(
                    "Not found!",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtSearch.SelectAll();
                TxtSearch.Focus();
                return;
            }

            this.Close();

            guiProductOutlet frm =
                new guiProductOutlet(this.mdi_, true);

            frm.RWord_Searching = keyword;
            frm.RProductList = products;

            frm.MdiParent = this.mdi_;
            frm.WindowState = FormWindowState.Maximized;

            frm.Show();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;                 // បិទសំឡេង "ding" របស់ Windows
                BtnSearch_Click(sender, e);       // ហៅ search ដូចចុច button
            }
        }

        private void FrmProductsSearch_Load(object sender, EventArgs e)
        {
            RdbBarcode.Checked = true;
            this.ActiveControl = TxtSearch;
        }
    }
}