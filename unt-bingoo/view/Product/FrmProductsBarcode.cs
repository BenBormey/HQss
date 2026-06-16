using DevExpress.DocumentServices.ServiceModel.DataContracts;
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
    public partial class FrmProductsBarcode : DevExpress.XtraEditors.XtraForm
    {

        private DatabaseFramework Data = new DatabaseFramework();

        private ApplicationFramework App = new ApplicationFramework();

        private DateTime Todate;

        private PrintToPrinter Printer = new PrintToPrinter();

        private SqlConnection RCon;

        private SqlCommand RCom = new SqlCommand();

        private SqlTransaction RTran;

        private LocalReport Report;

        private DevExpress.DocumentServices.ServiceModel.DataContracts.ReportParameter RParameter;

        private BindingSource DataBindingSource = new BindingSource();

        private string DatabaseName;

        private DataTable DTable;

        private long RJournalNumber;

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
            LoadingInitialized();

            App.SetEnableController(
                !string.IsNullOrWhiteSpace(RCurrentBarcode),
                BtnSetAsOldCode);
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);

            DatabaseName = string.Format(
                "{0}{1}",
                Data.PrefixDatabase,
                Data.DatabaseName);

            if (BtnSetAsOldCode.Enabled == false)
            {
                BtnChange.Text = "&Set";
            }
            else
            {
                BtnChange.Text = "&Change";
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

        private void BtnSetAsOldCode_Click(object sender, EventArgs e)
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

            string query = string.Empty;
            DataTable lists = null;

            query = @"
DECLARE @Barcode NVARCHAR(50) = 'YOUR_BARCODE';

SELECT
    ProID,
    BarcodeType,
    Barcode
FROM
(
    SELECT ProID, 'ProNumY'  AS BarcodeType, ProNumY  AS Barcode
    FROM [DBJuJuBi].[dbo].[TPRProducts]
    WHERE ISNULL(ProNumY,'') = @Barcode

    UNION ALL

    SELECT ProID, 'ProNumYP', ProNumYP
    FROM [DBJuJuBi].[dbo].[TPRProducts]
    WHERE ISNULL(ProNumYP,'') = @Barcode

    UNION ALL

    SELECT ProID, 'ProNumYC', ProNumYC
    FROM [DBJuJuBi].[dbo].[TPRProducts]
    WHERE ISNULL(ProNumYC,'') = @Barcode
) A;
";

            query = string.Format(
                query,
                DatabaseName,
                this.lTblProductName,
                barcode);

            lists = (DataTable)Data.Selects(query);

            if (lists != null)
            {
                if (lists.Rows.Count > 0)
                {
                    string status =
                        Convert.IsDBNull(lists.Rows[0]["Status"])
                            ? ""
                            : lists.Rows[0]["Status"].ToString().Trim();

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
            }
            if (MessageBox.Show(
                  $"Are you sure, you want to add the old barcode <{barcode}> for the new barcode <{RCurrentBarcode.Trim()}>?(Yes/No)",
                  "Confirm Set As Old Code",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string querys = @"
    DECLARE @ProId DECIMAL(18,0) = {0};
    DECLARE @OldBarcode NVARCHAR(MAX) = N'{1}';

    UPDATE [DBJuJuBi].[dbo].[TPRProducts]
    SET OldProNumY = @OldBarcode
    WHERE ProID = @ProId;
";

            querys = string.Format(
                querys,
                RProId,
                barcode);

            using (SqlConnection con = new SqlConnection(Data.strConnection))
            {
                con.Open();

                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(querys, con, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();

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
                    tran.Rollback();

                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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

            string barcode = $"{CmbSpecial.Text.Trim()}{Convert.ToInt64(TxtBarcode.Text.Trim()):0000000000000}";

            string query = @"
SELECT TOP 1 ProID
FROM [DBJuJuBi].[dbo].[TPRProducts]
WHERE ProNumY = @Barcode
   OR ProNumYP = @Barcode
   OR ProNumYC = @Barcode";

            using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show(
                            "This barcode already exists!",
                            "Existed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return;
                    }
                }
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

            string updateQuery = $@"
    UPDATE [DBJuJuBi].[dbo].[TPRProducts]
    SET ProNumY = '{barcode}'
    WHERE ProID = {RProId}";

            Data.ExecuteCommand(updateQuery);

            MessageBox.Show(
                "Changing barcode completed!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Initialized.R_Barcode = barcode;
            this.DialogResult = DialogResult.OK;
            this.Close();
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