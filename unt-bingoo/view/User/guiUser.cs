using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
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
using unt_bingoo.view.Outlet;

namespace unt_bingoo.view.User
{
    public partial class guiUser : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        private BindingList<UserItem> _user =
            new BindingList<UserItem>();

        private int? _editingId = null;
        public guiUser()
        {
            InitializeComponent();
        }


        private async void guiUser_Load(object sender, EventArgs e)
        {
        
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            //ApplyModernUI();

        }
        public async Task LoadData()
        {
            var list =
              await _api.GetAsync<System.Collections.Generic.List<UserItem>>(
                  "api/users");

            _user = new BindingList<UserItem>(list);

           gridControlUser.DataSource = _user;

            UpdateRowCount();
            LoadingOutlet();
            LoadingRole();

        }
        private void UpdateRowCount()
        {
            lblCountRow.Text = $"Count : {_user.Count}";
        }
      
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    XtraMessageBox.Show("Username is required.");
                    return;
                }

                if (_editingId != null &&
                    txtPassword.Text != txtConfirmPassword.Text)
                {
                    XtraMessageBox.Show("Password does not match.");
                    return;
                }
                if (cboRole.SelectedValue == null ||
                    cboOutlet.SelectedValue == null)
                {
                    XtraMessageBox.Show("Please select Role and Outlet.");
                    return;
                }

          
                var data = new
                {
                    Id = _editingId,

                    Username = txtUserName.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    FullNameKh = txtFullNameKh.Text.Trim(),

                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),

                    AddressKh = txtAddressKh.Text.Trim(),
                    Address = txtaddress.Text.Trim(),

                    RoleId = (int)cboRole.SelectedValue,
                    OutletId = (int)cboOutlet.SelectedValue,

                    IsActive = chkActive.Checked,
                    IsLocked = chkLocked.Checked,

                    Password = string.IsNullOrWhiteSpace(txtPassword.Text)
                               ? null
                               : txtPassword.Text
                };

                bool result;

            
                if (_editingId == null)
                {
                
                    result = await _api.PostAsync("api/users", data);
                }
                else
                {
                    result = await _api.PutAsync($"api/users/{_editingId}", data);

                }

                if (!result)
                {
                    XtraMessageBox.Show("Save failed.");
                    return;
                }

      
                await LoadData();
                ClearForm();

                XtraMessageBox.Show("Saved successfully.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnaddRole_Click(object sender, EventArgs e)
        {
            guiUserrole gui_ = new guiUserrole();
            gui_.ShowDialog();
        }

        private void gridViewUser_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "No")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void gridViewUser_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0) 
            {
                if (e.RowHandle % 2 == 0)
                {
                 
                    e.Appearance.BackColor = Color.White;
                }
                else
                {
                   
                    e.Appearance.BackColor = Color.Gainsboro; 
                }
            }
        }
        private async Task LoadingOutlet()
        {
            try
            {
                var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet");

                cboOutlet.DataSource = outlets;
                cboOutlet.DisplayMember = "OutletName"; 
                cboOutlet.ValueMember = "Id";         
                cboOutlet.SelectedIndex = -1;        
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }
        }
        private async Task LoadingRole()
        {
            try
            {
                var outlets = await _api.GetAsync<List<RoleItem>>("api/role");

                cboRole.DataSource = outlets;
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "Id";
                cboRole.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }

        }
        private void ClearForm()
        {
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtFullNameKh.Text = "";

            txtPhone.Text = "";
            txtEmail.Text = "";

            txtAddressKh.Text = "";
            txtaddress.Text = "";

            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            cboRole.SelectedIndex = -1;
            cboOutlet.SelectedIndex = -1;

            chkActive.Checked = true;
            chkLocked.Checked = false;

            _editingId = null;

            btnAdd.Text = "Add";
        }


        private async void btnmaindelete_ButtonClick(
       object sender,
       DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {

                var row = gridViewUser.GetFocusedRow();

                if (row == null)
                {
                    XtraMessageBox.Show("Please select a user first.");
                    return;
                }

                var user = (UserItem)row;

           
                var confirm = XtraMessageBox.Show(
                    $"Do you want to delete user: {user.Username} ?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

    
                var result = await _api.DeleteAsync($"api/users/{user.Id}");

                if (!result)
                {
                    XtraMessageBox.Show("Delete failed.");
                    return;
                }


                await LoadData();


                XtraMessageBox.Show("User deleted successfully.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnmainChangepassword_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
         
        }
        private async void btnmainUpdate_ButtonClick(
    object sender,
    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
            
                var row = gridViewUser.GetFocusedRow();

                if (row == null)
                {
                    XtraMessageBox.Show("Please select a user first.");
                    return;
                }

                var user = (UserItem)row;

         
                txtUserName.Text = user.Username;
                txtFullName.Text = user.FullName;
                txtFullNameKh.Text = user.FullNameKh;

                txtPhone.Text = user.Phone;
                txtEmail.Text = user.Email;

                txtAddressKh.Text = user.addressKh;
                txtaddress.Text = user.address;

                cboRole.SelectedValue = user.RoleId;
                cboOutlet.SelectedValue = user.outLetId;

                chkActive.Checked = user.IsActive;
           
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                
                _editingId = user.Id;

               
                btnAdd.Text = "Update";



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnaddOutlet_Click(object sender, EventArgs e)
        {
            guiOutlet gui_ = new guiOutlet();
            gui_.ShowDialog();
            this.LoadingOutlet();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Export Users to Excel";
                saveFileDialog.FileName = "Users.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var options = new XlsxExportOptionsEx
                    {
                        ExportType = ExportType.WYSIWYG,
                        SheetName = "Users"
                    };

                    gridControlUser.ExportToXlsx(saveFileDialog.FileName, options);

                    XtraMessageBox.Show("Export successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export failed: " + ex.Message);
            }
        }
        private void ApplyModernUI()
        {
            // Form
            //this.BackColor = Color.FromArgb(245, 247, 250);
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.MaximizeBox = false;

            // Header
            panelHeader.Appearance.BackColor = Color.FromArgb(144, 238, 144);
            panelHeader.Appearance.Options.UseBackColor = true;
            panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            lblSystemName.Appearance.ForeColor = Color.White;
            lblSystemName.Appearance.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            // Detail Panel
            panelDetail.Appearance.BackColor = Color.White;
            panelDetail.Appearance.Options.UseBackColor = true;
            panelDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            // Bottom
            panelBottom.Appearance.BackColor = Color.WhiteSmoke;
            panelBottom.Appearance.Options.UseBackColor = true;

            // Buttons
            StyleButton(btnAdd, Color.FromArgb(76, 175, 80));
            StyleButton(btnCancel, Color.FromArgb(244, 67, 54));
            StyleButton(btnExport, Color.FromArgb(255, 152, 0));
            StyleButton(btnClose, Color.FromArgb(96, 125, 139));

            // Grid
            //gridViewUser.Appearance.HeaderPanel.BackColor = Color.FromArgb(63, 81, 181);
            //gridViewUser.Appearance.HeaderPanel.ForeColor = Color.White;
            //gridViewUser.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            //gridViewUser.Appearance.Row.Font = new Font("Segoe UI", 9);
            //gridViewUser.RowHeight = 35;

            //gridViewUser.OptionsView.EnableAppearanceEvenRow = true;
            //gridViewUser.Appearance.EvenRow.BackColor = Color.FromArgb(248, 249, 252);

            // TextEdit style
            StyleEditors();
        }

        private void StyleButton(SimpleButton btn, Color color)
        {
            btn.Appearance.BackColor = color;
            btn.Appearance.ForeColor = Color.White;
            btn.Appearance.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;
            btn.LookAndFeel.UseDefaultLookAndFeel = false;
        }

        private void StyleEditors()
        {
            TextEdit[] edits =
            {
        txtUserName, txtFullName, txtFullNameKh,
        txtPassword, txtConfirmPassword,
        txtPhone, txtEmail
    };

            foreach (var txt in edits)
            {
                txt.Properties.Appearance.Font = new Font("Segoe UI", 10);
                txt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            }

            txtAddressKh.Properties.Appearance.Font = new Font("Segoe UI", 10);
            txtaddress.Properties.Appearance.Font = new Font("Segoe UI", 10);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}