using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using unt_bingoo.Frameworks;
using unt_bingoo.Declares;
// TODO: replace with the real namespace for DatabaseFramework / ApplicationFramework / Initialized
// using unt_bingoo.Frameworks; 

namespace unt_bingoo.view.Product
{
    public partial class FrmProductsBuyinNQtyPCase : DevExpress.XtraEditors.XtraForm
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
        private BindingSource DataBindingSource = new BindingSource();
        private string DatabaseName;
        private long RJournalNumber;
        private DataTable vList;
        private string vQuery;

        public double vBuyin { get; set; }
        public decimal vQtyPerCase { get; set; }
        public bool vDefaultBuyinFocus { get; set; }

        public FrmProductsBuyinNQtyPCase()
        {
            InitializeComponent();
        }

        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
            TxtBuyin.Text = vBuyin.ToString("N2");
            TxtQtyPerCase.Text = vQtyPerCase.ToString("N0");
        }

        private void FrmProductsBuyinNQtyPCase_Load(object sender, EventArgs e)
        {
            LoadingInitialized();
        }

        private void FrmProductsBuyinNQtyPCase_Activated(object sender, EventArgs e)
        {
            if (vDefaultBuyinFocus)
                TxtNewBuyin.Focus();
            else
                TxtNewQtyPerCase.Focus();
        }

        private void TxtNewBuyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                TxtNewBuyin.Text = Clipboard.GetText();
                TxtNewBuyin.SelectionStart = TxtNewBuyin.Text.Length;
                TxtNewBuyin.Focus();
            }
        }

        private void TxtBuyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 25);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            vBuyin = string.IsNullOrEmpty(TxtNewBuyin.Text.Trim()) ? 0 : Convert.ToDouble(TxtNewBuyin.Text.Trim());
            vQtyPerCase = string.IsNullOrEmpty(TxtNewQtyPerCase.Text.Trim()) ? 0 : Convert.ToDecimal(TxtNewQtyPerCase.Text.Trim());

            if (vBuyin == 0)
                vBuyin = string.IsNullOrEmpty(TxtBuyin.Text.Trim()) ? 0 : Convert.ToDouble(TxtBuyin.Text.Trim());

            if (vQtyPerCase == 0)
                vQtyPerCase = string.IsNullOrEmpty(TxtQtyPerCase.Text.Trim()) ? 1 : Convert.ToDecimal(TxtQtyPerCase.Text.Trim());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}