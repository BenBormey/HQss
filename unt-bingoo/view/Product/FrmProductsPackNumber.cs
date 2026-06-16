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
    public partial class FrmProductsPackNumber : DevExpress.XtraEditors.XtraForm
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
        public decimal RProId;
        private string SpecialCode;

        public mainForm mdi_ { get; set; }
        private bool lIsMainProducts { get; set; }
        private string lTblProductName { get; set; }

        public FrmProductsPackNumber(mainForm mdi_, bool lIsMainProducts)
        {
            InitializeComponent();
            LoadingInitialized();
            this.mdi_ = mdi_;
            this.lIsMainProducts = lIsMainProducts;
            this.lTblProductName = "";

            if (!this.lIsMainProducts)
            {
                this.lTblProductName = "Consignment_";
            }
        }

        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);

            DatabaseName = string.Format("{0}{1}",
                Data.PrefixDatabase,
                Data.DatabaseName);

            //int ilength = RUnitNumber.Length;

            //if (ilength > 13)
            //{
            //    ilength = ilength - 13;
            //    SpecialCode = RUnitNumber.Substring(0, ilength).Trim();
            //}
            //else
            //{
            //    SpecialCode = "";
            //}
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
                Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtBarcode.Text) ? "0" : TxtBarcode.Text.Trim()));

            using (SqlConnection conn =
                new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
            {
                conn.Open();

                // Check barcode exists
                string query = @"
            DECLARE @Barcode NVARCHAR(MAX) = @BarcodeValue;

            SELECT ProID AS Id,
                   ProNumY AS Barcode,
                   N'Products' AS Status
            FROM [DBJuJuBi].[dbo].[TPRProducts]
            WHERE ISNULL(ProNumY, '') = @Barcode

            UNION ALL

            SELECT ProID AS Id,
                   ProNumYP AS Barcode,
                   N'Products' AS Status
            FROM [DBJuJuBi].[dbo].[TPRProducts]
            WHERE ISNULL(ProNumYP, '') = @Barcode

            UNION ALL

            SELECT ProID AS Id,
                   ProNumYC AS Barcode,
                   N'Products' AS Status
            FROM [DBJuJuBi].[dbo].[TPRProducts]
            WHERE ISNULL(ProNumYC, '') = @Barcode;";

                DataTable lists = new DataTable();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BarcodeValue", TxtBarcode.Text.Trim());

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(lists);
                    }
                }

                if (lists.Rows.Count > 0)
                {
                    string status = lists.Rows[0]["Status"]?.ToString().Trim() ?? "";

                    if (status == "Products")
                    {
                        MessageBox.Show(
                            "This barcode is existed already (Products)!",
                            "Existed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else if (status == "Products Deactivated")
                    {
                        MessageBox.Show(
                            "This barcode is existed already (Products Deactivated)!",
                            "Existed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "This barcode is existed already (Products Old Code)!",
                            "Existed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    return;
                }

                if (string.IsNullOrWhiteSpace(RUnitNumber))
                {
                    Initialized.R_Barcode = barcode;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                if (string.IsNullOrWhiteSpace(RCurrentBarcode))
                {
                    if (MessageBox.Show(
                        $"Are you sure, you want to set the barcode <{barcode}>?(Yes/No)",
                        "Confirm Change Barcode",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show(
                        $"Are you sure, you want to change the barcode <{RCurrentBarcode}> to <{barcode}>?(Yes/No)",
                        "Confirm Change Barcode",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string updateQuery = @"
                    UPDATE [DBJuJuBi].[dbo].[TPRProducts]
                    SET ProNumYP = @Barcode
                    WHERE ProID = @ProId";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Barcode", barcode);
                            cmd.Parameters.AddWithValue("@ProId", RProId);

                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();

                        MessageBox.Show(
                            "Changing barcode has been completed!",
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
        }
        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, "", 25);
        }

        private void BtnClearPackNumber_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            string barcode = string.Format(
                "{0}{1:0000000000000}",
                SpecialCode,
                Convert.ToDecimal(string.IsNullOrWhiteSpace(TxtBarcode.Text) ? "0" : TxtBarcode.Text.Trim()));

            if (MessageBox.Show(
                    $"Are you sure, you want to clear the pack number <{RCurrentBarcode}>?(Yes/No)",
                    "Confirm Clear Pack Number",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string query = @"
UPDATE [DBJuJuBi].[dbo].[TPRProducts]
SET ProNumYP = NULL
WHERE ProID = @ProId";

            RCon = new SqlConnection(Data.strConnection);
            RCon.Open();

            RTran = RCon.BeginTransaction();

            try
            {
                RCom = new SqlCommand(query, RCon, RTran);

                RCom.Parameters.AddWithValue("@ProId", RProId);

                RCom.ExecuteNonQuery();

                RTran.Commit();
                RCon.Close();

                MessageBox.Show(
                    "Clearance pack number have been completed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Initialized.R_Barcode = "";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                RTran.Rollback();
                RCon.Close();

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RTran.Rollback();
                RCon.Close();

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}