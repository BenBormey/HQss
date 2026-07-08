using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Supplier
{
    public partial class Form1 : Form
    {

        private APIsController _api;
        private ApplicationFramework app = new ApplicationFramework();
        private DatabaseFramework Data = new DatabaseFramework();

        private BindingList<SupplierItem> _supplierList =
            new BindingList<SupplierItem>();
        private BindingSource DataBindingSource;


        public string DatabaseName;



        private int? _editingId = null;

      
        public Form1()
        {
            InitializeComponent();
            DataBindingSource = new BindingSource();
            this.LoadingInitialized();



            gridViewSuppliers.OptionsView.ColumnAutoWidth = true;

            gridViewSuppliers.Appearance.HeaderPanel.BackColor = Color.DimGray;
            gridViewSuppliers.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridViewSuppliers.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gridViewSuppliers.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewSuppliers.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewSuppliers.Appearance.HeaderPanel.Options.UseFont = true;




        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, app);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }

        public void autoSupcode()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, app))))
                {
                    conn.Open();

                    string query = "SELECT ISNULL(MAX([SupplierID]), 0) + 1 FROM [DBJuJuBi].[dbo].[Suppliers]";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int nextId = Convert.ToInt32(cmd.ExecuteScalar());

                        TxtSupId.Text = string.Format("SUP-{0:0000}", nextId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Supplier Code: " + ex.Message);
            }
        }
        public void loadingTerm()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(
                    Data.ConnectionString(
                    Initialized.GetConnectionType(Data, app))))
                {
                    conn.Open();

                    string query = @"
            SELECT 
                Id,
                CAST(CountDay AS VARCHAR(10)) + ' Day' AS TermDay
            FROM [DBJuJuBi].[dbo].[tblTermDay]
            ORDER BY CountDay";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        CmbTerms.DataSource = dt;
                        CmbTerms.DisplayMember = "TermDay";
                        CmbTerms.ValueMember = "Id";
                        CmbTerms.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadData()
        {
            var list = await _api.GetAsync<
                System.Collections.Generic.List<SupplierItem>>
                ("api/Supplier");

            _supplierList = new BindingList<SupplierItem>(list);

            gridControlSuppliers.DataSource = _supplierList;

            gridViewSuppliers.BestFitColumns();
        }

        //private void InitializeController()
        //{
           
           

        //    BtnAddNew.Text = "&Add New";
     
        //}

        private async void Form1_Load(object sender, EventArgs e)
        {

            button2.Visible = false;
            chkActive.Checked = true;
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                await LoadData();
     
                this.autoSupcode();
                this.loadingTerm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            this.LoadData();
            //this.LoadingValueIntoField();
        }
        private void ClearForm()
        {
            TxtId.Clear();
            TxtSupId.Clear();
            TxtSupName.Clear();
            TxtContactName.Clear();

            TxtAddress.Clear();
            txtkhmeraddress.Clear();
            txtkhmername.Clear();

            TxtCountry.Clear();
            TxtVATNumber.Clear();

            TxtTelLine1.Clear();
            TxtTelLine2.Clear();
            TxtHPLine1.Clear();
            TxtHPLine2.Clear();

            TxtFaxLine1.Clear();
            TxtFaxLine2.Clear();

            TxtEmail.Clear();
            TxtWebsite.Clear();

            TxtLEAOTime.Clear();
            TxtChequeName.Clear();
            TxtNote.Clear();

            TxtSetDaysOrder.Clear();

            CmbTerms.SelectedIndex = -1;
            CmbCountryOfPurchase.SelectedIndex = -1;
            

            chkrequiredsetallitems.Checked = false;

            BtnAddNew.Text = "&Add New";



            _editingId = null;
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (BtnAddNew.Text == "&Add New")
            {
                //TxtSupId.Text = GetAutoNumber();

                //CmbStatus.SelectedIndex = 0;
                //cmbDistributor.SelectedIndex = -1;
                CmbCountryOfPurchase.SelectedIndex = -1;

                app.ClearController(
                    TxtId,
                    txtkhmername,
                    txtkhmeraddress,
                    TxtSupName,
                    TxtAddress,
                    TxtCountry,
                    TxtVATNumber,
                    TxtTelLine1,
                    TxtTelLine2,
                    TxtHPLine1,
                    TxtHPLine2,
                    TxtFaxLine1,
                    TxtFaxLine2,
                    TxtEmail,
                    TxtNote,
                    TxtContactName,
                    TxtWebsite,
                    TxtLEAOTime,
                    TxtChequeName,
                    CmbTerms,
                    TxtSetDaysOrder,
                    TxtCountry
                );

            

                //lblSupName.Text = "";
                chkrequiredsetallitems.Checked = false;
         

                BtnAddNew.Text = "&Save";
                BtnAddNew.Image = Properties.Resources.Save;
            }
            else
            {
                BtnUpdate_Click(BtnAddNew, EventArgs.Empty);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
           
      
        }
        private void LoadingValueIntoField()
        {
           


            foreach (Control ctl in this.Controls)
            {
                ctl.DataBindings.Clear();
            }

            TxtId.DataBindings.Add("Text", DataBindingSource, "SupplierID", true);
            TxtSupId.DataBindings.Add("Text", DataBindingSource, "SupplierCode", true);
            TxtSupName.DataBindings.Add("Text", DataBindingSource, "SupplierName", true);

            TxtVATNumber.DataBindings.Add("Text", DataBindingSource, "TaxNumber", true);
            TxtAddress.DataBindings.Add("Text", DataBindingSource, "Address", true);
            TxtCountry.DataBindings.Add("Text", DataBindingSource, "Country", true);

            TxtTelLine1.DataBindings.Add("Text", DataBindingSource, "Phone", true);

            TxtFaxLine2.DataBindings.Add("Text", DataBindingSource, "FaxLine2", true);

            TxtEmail.DataBindings.Add("Text", DataBindingSource, "Email", true);
            TxtWebsite.DataBindings.Add("Text", DataBindingSource, "Website", true);
            TxtLEAOTime.DataBindings.Add("Text", DataBindingSource, "LeaoTime", true);
            TxtNote.DataBindings.Add("Text", DataBindingSource, "Note", true);
            TxtContactName.DataBindings.Add("Text", DataBindingSource, "ContactName", true);
            TxtChequeName.DataBindings.Add("Text", DataBindingSource, "ChequeName", true);

            CmbTerms.DataBindings.Add("Text", DataBindingSource, "Term", true);
            CmbCountryOfPurchase.DataBindings.Add("Text", DataBindingSource, "CountryOfPurchase", true);

            TxtSetDaysOrder.DataBindings.Add("Text", DataBindingSource, "DayOrder", true);

            txtkhmeraddress.DataBindings.Add("Text", DataBindingSource, "KhmerSupAddress", true);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
        SearchAgain:

            Initialized.R_SearchValue = "";
            Initialized.R_IsCancel = true;

            //FrmSearch searchGUI = new FrmSearch(true);

            //searchGUI.RdbCustomerId.Text = "Supplier Id";
            //searchGUI.RdbCustomerName.Text = "Supplier Name";
            //searchGUI.rdbCustomerCode.Text = "Show Supplier In Name Card";

            //searchGUI.ShowDialog();

            //if (Initialized.R_IsCancel)
            //    return;

            //if (searchGUI.rdbCustomerCode.Checked ||
            //    !string.IsNullOrWhiteSpace(Initialized.R_SearchValue))
            //{
            //    if (DataBindingSource == null)
            //    {
            //        XtraMessageBox.Show("DataBindingSource is null");
            //        return;
            //    }

            //    if (searchGUI.RdbCustomerId.Checked)
            //    {
            //        DataBindingSource.Filter =
            //            $"SupplierCode = 'SUP{Convert.ToDecimal(Initialized.R_SearchValue):00000}'";
            //    }
            //    else if (searchGUI.RdbCustomerName.Checked)
            //    {
            //        DataBindingSource.Filter =
            //            $"SupplierName LIKE '%{Initialized.R_SearchValue}%'";
            //    }
            //    else if (searchGUI.rdbCustomerCode.Checked)
            //    {
            //        // បើ SupplierItem មិនមាន property នេះ សូម comment ចេញ
            //        DataBindingSource.Filter = "isShowNamCard = true";
            //    }

            //    if (DataBindingSource.Count <= 0)
            //    {
            //        XtraMessageBox.Show(
            //            "Searching the value is not found!",
            //            "Not Found",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);

            //        goto SearchAgain;
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show(
            //            $"Searching is {DataBindingSource.Count} found(s)!",
            //            "Found",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //}
        }

        private void MnuMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void BindingNavigatorCountItem_Click(object sender, EventArgs e)
        {

        }

        private void btnmainUpdateButton_ButtonClick(
      object sender,
      DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
        private async void btnmainDeletebutton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var row = gridViewSuppliers.GetFocusedRow() as SupplierItem;

                if (row == null)
                    return;

                var result = MessageBox.Show(
                    $"Are you sure you want to delete supplier '{row.SupplierName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string url = $"api/Supplier/{row.SupplierID}";

                bool status = await _api.DeleteAsync(url);

                if (status)
                {
                    MessageBox.Show(
                        "Supplier deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnmainUpdate1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var row = gridViewSuppliers.GetFocusedRow() as SupplierItem;

                if (row == null)
                    return;

                TxtId.Text = row.SupplierID.ToString();
                TxtSupId.Text = row.SupplierCode;
                TxtSupName.Text = row.SupplierName;
                TxtContactName.Text = row.ContactName;
                TxtTelLine1.Text = row.Phone;
                TxtEmail.Text = row.Email;
                TxtAddress.Text = row.Address;
                TxtVATNumber.Text = row.TaxNumber;
                txtkhmeraddress.Text = row.KhmerSupAddress;
                TxtCountry.Text = row.Country;
                TxtFaxLine1.Text = row.FaxLine2;
                TxtWebsite.Text = row.Website;
                TxtLEAOTime.Text = row.LeaoTime;
                TxtNote.Text = row.Note;
                TxtChequeName.Text = row.ChequeName;
                txtkhmername.Text = row.SupplierNamekh;
                //CmbTerms.Text = row.Term.ToString();
                CmbTerms.SelectedValue = row.TermId;
                TxtSetDaysOrder.Text = row.DayOrder.ToString();
                CmbCountryOfPurchase.Text = row.CountryOfPurchase;

                if (row.Status)
                {
                    chkActive.Checked = true;
                    chkDeactive.Checked = false;
                }
                else
                {
                    chkActive.Checked = false;
                    chkDeactive.Checked = true;
                }
                BtnAddNew.Text = "&Update";
                _editingId =row.SupplierID;
                gridControlSuppliers.Enabled = false;
                button2.Visible = true;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {

        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void BtnAddNew_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtSupName.Text))
                {
                    XtraMessageBox.Show("Please enter The Supplier name!");
                    TxtSupName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtAddress.Text))
                {
                    XtraMessageBox.Show("Please enter the address!");
                    TxtAddress.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(CmbCountryOfPurchase.Text))
                {
                    XtraMessageBox.Show("Please enter the Country Of Purchase!");
                    CmbCountryOfPurchase.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(CmbTerms.Text))
                {
                    XtraMessageBox.Show("Please enter the Terms!");
                    CmbTerms.Focus();
                    return;
                }
                if (!IsValidEmail(TxtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email address.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    TxtEmail.Focus();
                    return ;
                }

                //if (string.IsNullOrWhiteSpace(TxtSetDaysOrder.Text))
                //{
                //    XtraMessageBox.Show("Please enter the Days Order!");
                //    TxtSetDaysOrder.Focus();
                //    return;
                //}

                if (string.IsNullOrWhiteSpace(TxtCountry.Text))
                {
                    XtraMessageBox.Show("Please enter the country!");
                    TxtCountry.Focus();
                    return;
                }
           if (CmbTerms.SelectedIndex == -1)
{
    XtraMessageBox.Show("Please choose a term!");
    CmbTerms.Focus();
    return;
}

                if (string.IsNullOrWhiteSpace(TxtTelLine1.Text) &&
                    string.IsNullOrWhiteSpace(TxtTelLine2.Text) &&
                    string.IsNullOrWhiteSpace(TxtHPLine1.Text) &&
                    string.IsNullOrWhiteSpace(TxtHPLine2.Text))
                {
                    XtraMessageBox.Show("Please enter the phone number!");
                    TxtTelLine1.Focus();
                    return;
                }



                var supplier = new SupplierItem
                {
                    //SupplierID = Convert.ToInt32(TxtId.Text),
                    TermId = (int)CmbTerms.SelectedValue,
                    SupplierCode = TxtSupId.Text.Trim(),
                    SupplierName = TxtSupName.Text.Trim(),
                    ContactName = TxtContactName.Text.Trim(),
                    Phone = TxtTelLine1.Text.Trim(),
                    Email = TxtEmail.Text.Trim(),
                    Address = TxtAddress.Text.Trim(),
                    TaxNumber = TxtVATNumber.Text.Trim(),
                    KhmerSupAddress = txtkhmeraddress.Text.Trim(),
                    Country = TxtCountry.Text.Trim(),
                    FaxLine2 = TxtFaxLine1.Text.Trim(),
                    Website = TxtWebsite.Text.Trim(),
                    LeaoTime = TxtLEAOTime.Text.Trim(),
                    Note = TxtNote.Text.Trim(),
                    ChequeName = TxtChequeName.Text.Trim(),
                    Term = int.TryParse(CmbTerms.Text, out int term) ? term : 45,
                    SupplierNamekh = txtkhmername.Text.Trim(),
                   // DayOrder = int.TryParse(TxtSetDaysOrder.Text, out int dayOrder) ? dayOrder : 45,
                    CountryOfPurchase = CmbCountryOfPurchase.Text.Trim(),
                    SetPercentOrderLevel = 20.5m,
                    VatTemp = 10,
                    Status = chkActive.Checked
                };
                bool sucess = false; 

                if (_editingId == null)
                {
                       sucess=      await _api.PostAsync("api/Supplier", supplier);
                            XtraMessageBox.Show(
                         "The Supplier has been Save!",
                         "Success",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
          
                }
                else 
                {
                    sucess = await _api.PutAsync(
                              $"api/Supplier/{TxtId.Text.Trim()}",
                              supplier);
                                XtraMessageBox.Show(
                             "The Supplier has been updated!",
                             "Success",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                }



                if (sucess)
                {
                    await LoadData();
                    ClearForm();
                    gridControlSuppliers.Enabled = true;


                }
            
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            guiTerm gui = new guiTerm();
            gui.ShowDialog();
            this.loadingTerm();
        }

        private void txtkhmername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;



            if (e.KeyChar < 0x1780 || e.KeyChar > 0x17FF)
            {
                e.Handled = true;
            }
        }

        private void btngeneratevat_Click(object sender, EventArgs e)
        {

        }

        private void txtkhmername_Enter(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == "km-KH")
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }

        private void txtkhmername_Leave(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == "en-US")
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }

        private void TxtTelLine1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelLine2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtFaxLine1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtFaxLine2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtHPLine1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtHPLine2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtkhmeraddress_Enter(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == "km-KH")
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }

        private void txtkhmeraddress_Leave(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == "en-US")
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                chkDeactive.Checked = false;
            }
            else
            {
                // មិនអនុញ្ញាតឱ្យ Uncheck ទាំងអស់
                if (!chkDeactive.Checked)
                {
                    chkActive.Checked = true;
                }
            }
        }

        private void chkDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeactive.Checked)
            {
                chkActive.Checked = false;
            }
            else
            {
                // មិនអនុញ្ញាតឱ្យ Uncheck ទាំងអស់
                if (!chkActive.Checked)
                {
                    chkDeactive.Checked = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            button2.Visible = false;
            chkActive.Checked = true;
            gridControlSuppliers.Enabled = true;
            
           
        }

        private void TxtHPLine2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}