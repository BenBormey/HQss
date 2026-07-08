using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;
using unt_bingoo.Class;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;
using DevExpress.XtraEditors;
using System.Linq;
using System.Drawing;
namespace unt_bingoo.view.Outlet
{
    public partial class guiFranchise : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private bool _suspendDateRules = false;
        public guiFranchise()
        {
            InitializeComponent();
            this.LoadingInitialized();
            _api = new APIsController();
       

            gridView1.Appearance.HeaderPanel.BackColor = Color.Silver;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;

        }

        private void guiFranchise_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

     
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveFranchise();
        }
        private async Task LoadFranchises()
        {
            try
            {
                btnSave.Enabled = false;

                // Load Franchise
                var franchises = await _api.GetAsync<List<Franchise>>("api/Franchise");

                // Load Outlet
                var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet");

                if (franchises != null)
                {
                    foreach (var franchise in franchises)
                    {
                        bool isUsed = outlets != null &&
                                      outlets.Any(o => o.FranchiseId == franchise.franchiseId);

                        franchise.Status = isUsed;
                    }

                    gridControl1.DataSource = franchises;
                    gridView1.BestFitColumns();
                    gridView1.RefreshData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Load Error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                loadingOutletcode();
            }
        }
        private async Task SaveFranchise()
        {
            try
            {
                btnSave.Enabled = false;

                if (string.IsNullOrWhiteSpace(txtOutletName.Text))
                {
                    MessageBox.Show("Please enter franchise name");
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbooutletCode.Text))
                {
                    MessageBox.Show("Please enter franchise code");
                    return;
                }

                if (cboFranchiseType.SelectedValue == null)
                {
                    MessageBox.Show("Please select franchise type");
                    return;
                }
                DateTime? agreementDate = dtpAgreementDate.Checked
    ? dtpAgreementDate.Value
    : (DateTime?)null;

                DateTime? expirationDate = dtpExpirationDate.Checked
                    ? dtpExpirationDate.Value
                    : (DateTime?)null;

                DateTime? afterDate = dtpAfterDate.Checked
                    ? dtpAfterDate.Value
                    : (DateTime?)null;

                var model = new
                {
                    franchiseId = _editingFranchiseId,
                    outlet = cbooutletCode.Text.Trim(),
                    outletName = txtOutletName.Text.Trim(),
                    franchiseInformation = txtFranchiseInfo.Text?.Trim(),
                    franchiseTypeId = Convert.ToInt32(cboFranchiseType.SelectedValue),
                    typeName = cboFranchiseType.Text,
                    agreementDate = agreementDate,
                    expirationDate = expirationDate,
                    afterDate = afterDate

                };

                bool result = false;

                if (_editingFranchiseId == 0)
                {
                  
                    result = await _api.PostAsync("api/Franchise", model);
                }
                else
                {
                  
                    result = await _api.PutAsync(
                        $"api/Franchise/{_editingFranchiseId}",
                        model);
                }

                if (result)
                {
                    MessageBox.Show(
                        _editingFranchiseId == 0
                            ? "Franchise saved successfully!"
                            : "Franchise updated successfully!");

                    ClearForm();

                    await LoadFranchises();

                    _editingFranchiseId = 0;
                    btnSave.Text = "Save";
                }
                else
                {
                    MessageBox.Show(
                        _editingFranchiseId == 0
                            ? "Failed to save franchise!"
                            : "Failed to update franchise!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void ClearForm()
        {
            _editingFranchiseId = 0;

            txtOutletName.Text = "";
            txtFranchiseInfo.Text = "";

            cbooutletCode.SelectedIndex = -1;
            cboFranchiseType.SelectedIndex = -1;

            btnSave.Text = "Save";
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel changes?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }
        private string DatabaseName;
        private void LoadingInitialized()
    {
        Initialized.LoadingInitialized(Data, App);
        DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
    }
    private async void guiFranchise_Load_1(object sender, EventArgs e)
        {
            await LoadFranchises();
            this.loadingOutletcode();
            this.LoadingFranchiseType();
        }
        public async Task LoadingFranchiseType() // ប្តូរទៅជា async Task ដើម្បីប្រើប្រាស់ await បានរលូន
        {
            try
            {
                // ហៅទៅកាន់ API ទាញយកប្រភេទ Franchise ទាំងអស់
                var data = await _api.GetAsync<List<FranchiseTypeItem>>("api/FranchiseType");

                if (data != null)
                {
                  
                    cboFranchiseType.DataSource = data;
                    cboFranchiseType.DisplayMember = "TypeName";
                    cboFranchiseType.ValueMember = "Id";    

             
                    cboFranchiseType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading franchise types:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            franchise_type gui = new franchise_type();

            // បើកបង្ហាញ Form ជាផ្ទាំង Pop-up (Modal) 
            gui.ShowDialog();
            this.LoadingFranchiseType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle < 0)
            {
                MessageBox.Show("Please select a franchise to delete.");
                return;
            }

            // 2. Extract the ID (Assuming your column field name is "franchiseId")
            var id = gridView1.GetRowCellValue(rowHandle, "franchiseId");

            if (id == null) return;

            // 3. Confirm deletion
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
               

                
                    bool result = await _api.DeleteAsync("api/Franchise/" + id);

                    if (result)
                    {
                        MessageBox.Show("Deleted successfully!");
                        await LoadFranchises(); // Refresh the grid
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guiOutletCode gui = new guiOutletCode();

  
            gui.ShowDialog();
            this.loadingOutletcode();
        }
        public void loadingOutletcode()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();

                    string query = @"SELECT Id, OutletCode
                             FROM [DBJuJuBi].[dbo].[OutletCode]
							 where OutletCode  not in (select outlet from DBJuJuBi.dbo.franchise)
                             ORDER BY Id DESC
";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

             
                    da.Fill(dt);

                    cbooutletCode.DataSource = dt;
                    cbooutletCode.DisplayMember = "OutletCode";
                    cbooutletCode.ValueMember = "Id";


                    cbooutletCode.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;

            if (rowHandle < 0)
                return;

            _editingFranchiseId = Convert.ToInt32(
                gridView1.GetRowCellValue(rowHandle, "franchiseId"));

            cbooutletCode.Text =
                gridView1.GetRowCellValue(rowHandle, "outlet")?.ToString();

            txtOutletName.Text =
                gridView1.GetRowCellValue(rowHandle, "outletName")?.ToString();

            txtFranchiseInfo.Text =
                gridView1.GetRowCellValue(rowHandle, "franchiseInformation")?.ToString();

            var franchiseTypeId =
                gridView1.GetRowCellValue(rowHandle, "franchiseTypeId");

            

            if (franchiseTypeId != null)
                cboFranchiseType.SelectedValue = franchiseTypeId;

            btnSave.Text = "Update";
        }

        private int _editingFranchiseId = 0;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtpAgreementDate_ValueChanged(object sender, EventArgs e)
        {
            //dtpExpirationDate.MinDate = dtpAgreementDate.Value.Date;
            dtpExpirationDate.Value = dtpAgreementDate.Value.AddYears(1);
           
        }

        private void dtpExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            if (_suspendDateRules) return;

            // Auto-suggest Alert Date = 1 month after Expiration.
            // User can still change it after this.
            dtpAfterDate.Value = dtpExpirationDate.Value.AddMonths(-1);
        }

        private void cbooutletCode_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }
    }
}