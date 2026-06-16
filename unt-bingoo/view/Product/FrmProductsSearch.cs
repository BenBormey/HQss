using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class FrmProductsSearch : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseFramework Data = new DatabaseFramework();

        private ApplicationFramework App = new ApplicationFramework();

        private DateTime Todate;

        private PrintToPrinter Printer = new PrintToPrinter();

        private SqlConnection RCon;

        private SqlCommand RCom = new SqlCommand();

        private SqlTransaction RTran;

        private LocalReport Report;

        private ReportParameter RParameter;

        private string DatabaseName;

        private DataTable DTable;

        private long RJournalNumber;

        private APIsController _api;
        public mainForm mdi_ { get; set; }
        public FrmProductsSearch(mainForm mdi)
        {
            InitializeComponent();
            this.mdi_ = mdi;
            this.LoadingInitialized();
            _api = APIGlobals.Api;
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
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}",
                Data.PrefixDatabase,
                Data.DatabaseName);
        }
    
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            this.Close();

            bool lIsMainProducts = this.rdbmainproducts.Checked;

            guiProductOutlet frm = new guiProductOutlet(this.mdi_, lIsMainProducts)
            {
                //RWord_Searching = string.Empty,
                //RProductList = null,
                MdiParent = this.mdi_,
                WindowState = FormWindowState.Maximized
                //RNewPriceEffective = 0
            };

            frm.PanelAccept.Visible = false;
            frm.Show();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                XtraMessageBox.Show(
                    LblDescription.Text,
                    "Need Value To Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtSearch.Focus();
                return;
            }

            string keyword = TxtSearch.Text.Trim();

            if (RdbBarcode.Checked)
            {
                if (keyword.Length <= 13)
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
            }

            List<ProductItem> products;

            if (RdbBarcode.Checked)
            {
                products = await _api.GetAsync<List<ProductItem>>(
                    $"api/Product");


            }
            else if (RdbItemcodes.Checked)
            {
                products = await _api.GetAsync<List<ProductItem>>(
                    $"api/Product/search-sku/{keyword}");
            }
            else
            {
                products = await _api.GetAsync<List<ProductItem>>(
                    $"api/Product/search-name/{keyword}");
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
    }
}