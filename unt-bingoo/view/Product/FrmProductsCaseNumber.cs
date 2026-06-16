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
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Product
{
    public partial class FrmProductsCaseNumber : DevExpress.XtraEditors.XtraForm
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
        private DataTable DTable;
        private long RJournalNumber;

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
            LoadingInitialized();
           

            //App.SetEnableController(
            //    !string.IsNullOrWhiteSpace(RCurrentBarcode),
            //    BtnSetAsOldCode);
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);

            DatabaseName = string.Format(
                "{0}{1}",
                Data.PrefixDatabase,
                Data.DatabaseName);

     
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


        private void BtnChange_Click(object sender, EventArgs e)
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

            string searchQuery = $@"
SELECT ProID
FROM [DBJuJuBi].[dbo].[TPRProducts]
WHERE ProNumY = '{barcode}'
   OR ProNumYP = '{barcode}'
   OR ProNumYC = '{barcode}'";

            DataTable lists = new DataTable();

            using (SqlConnection con = new SqlConnection(Data.strConnection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(searchQuery, con))
                {
                    lists.Load(cmd.ExecuteReader());
                }
            }

            if (lists.Rows.Count > 0)
            {
                MessageBox.Show(
                    $"Barcode [{barcode}] already exists!",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // If no UnitNumber => Return Barcode Only
            if (string.IsNullOrWhiteSpace(RUnitNumber))
            {
                Initialized.R_Barcode = barcode;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            DialogResult result;

            if (string.IsNullOrWhiteSpace(RCurrentBarcode))
            {
                result = MessageBox.Show(
                    $"Are you sure you want to set barcode [{barcode}] ?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }
            else
            {
                result = MessageBox.Show(
                    $"Are you sure you want to change barcode [{RCurrentBarcode}] to [{barcode}] ?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }

            if (result == DialogResult.No)
                return;

            string updateQuery = $@"
        UPDATE [DBJuJuBi].[dbo].[TPRProducts]
        SET ProNumYC = '{barcode}'
        WHERE ProID = {RProId}";

            using (SqlConnection con = new SqlConnection(Data.strConnection))
            {
                con.Open();

                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();

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
                    tran.Rollback();

                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClearPackNumber_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            string barcode = string.Format(
                "{0}{1:0000000000000}",
                SpecialCode,
                Convert.ToInt64(string.IsNullOrWhiteSpace(TxtBarcode.Text) ? "0" : TxtBarcode.Text.Trim())
            );

            if (MessageBox.Show(
                    $"Are you sure, you want to clear the case number <{RCurrentBarcode}> ?",
                    "Confirm Clear Case Number",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string query = $@"
        UPDATE [DBJuJuBi].[dbo].[TPRProducts]
        SET ProNumYC = NULL
        WHERE ProID = {RProId};
    ";

            using (SqlConnection con = new SqlConnection(Data.strConnection))
            {
                con.Open();

                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();

                    MessageBox.Show(
                        "Clearance case number have been completed!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Initialized.R_Barcode = "";

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    tran.Rollback();

                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
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
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, "", 25);
        }
    }
}