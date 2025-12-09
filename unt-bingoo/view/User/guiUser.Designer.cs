using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace unt_bingoo.view.User
{
    partial class guiUser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.chkLocked = new DevExpress.XtraEditors.CheckEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtAddressKh = new DevExpress.XtraEditors.MemoEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtFullNameKh = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lblAddressKh = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblOutlet = new DevExpress.XtraEditors.LabelControl();
            this.lblRole = new DevExpress.XtraEditors.LabelControl();
            this.lblConfirmPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblFullNameKh = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.btnaddOutlet = new System.Windows.Forms.Button();
            this.btnaddRole = new System.Windows.Forms.Button();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridControlUser = new DevExpress.XtraGrid.GridControl();
            this.gridViewUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtaddress = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddressKh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullNameKh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtaddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(90, 25);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(392, 26);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Q\'s USER MANAGEMENT SYSTEM";
            // 
            // picLogo
            // 
            this.picLogo.EditValue = global::unt_bingoo.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(10, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(980, 80);
            this.panelHeader.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnCancel.Location = new System.Drawing.Point(847, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(745, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkLocked
            // 
            this.chkLocked.Location = new System.Drawing.Point(630, 225);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkLocked.Properties.Appearance.Options.UseFont = true;
            this.chkLocked.Properties.Caption = "Locked";
            this.chkLocked.Size = new System.Drawing.Size(75, 19);
            this.chkLocked.TabIndex = 17;
            // 
            // chkActive
            // 
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(550, 225);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(75, 19);
            this.chkActive.TabIndex = 16;
            // 
            // txtAddressKh
            // 
            this.txtAddressKh.Location = new System.Drawing.Point(593, 127);
            this.txtAddressKh.Name = "txtAddressKh";
            this.txtAddressKh.Properties.Appearance.Font = new System.Drawing.Font("Khmer OS Battambang", 9F);
            this.txtAddressKh.Properties.Appearance.Options.UseFont = true;
            this.txtAddressKh.Size = new System.Drawing.Size(344, 50);
            this.txtAddressKh.TabIndex = 23;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(593, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Size = new System.Drawing.Size(344, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(593, 57);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Size = new System.Drawing.Size(344, 20);
            this.txtPhone.TabIndex = 14;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(130, 162);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtConfirmPassword.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmPassword.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(303, 20);
            this.txtConfirmPassword.TabIndex = 12;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(130, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(303, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // txtFullNameKh
            // 
            this.txtFullNameKh.Location = new System.Drawing.Point(130, 92);
            this.txtFullNameKh.Name = "txtFullNameKh";
            this.txtFullNameKh.Properties.Appearance.Font = new System.Drawing.Font("Khmer OS Battambang", 9F);
            this.txtFullNameKh.Properties.Appearance.Options.UseFont = true;
            this.txtFullNameKh.Size = new System.Drawing.Size(303, 28);
            this.txtFullNameKh.TabIndex = 10;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(130, 57);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFullName.Properties.Appearance.Options.UseFont = true;
            this.txtFullName.Size = new System.Drawing.Size(303, 20);
            this.txtFullName.TabIndex = 9;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(130, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(303, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // lblAddressKh
            // 
            this.lblAddressKh.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAddressKh.Appearance.Options.UseFont = true;
            this.lblAddressKh.Location = new System.Drawing.Point(513, 130);
            this.lblAddressKh.Name = "lblAddressKh";
            this.lblAddressKh.Size = new System.Drawing.Size(75, 14);
            this.lblAddressKh.TabIndex = 22;
            this.lblAddressKh.Text = "Address (Kh):";
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Location = new System.Drawing.Point(513, 95);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(31, 14);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPhone.Appearance.Options.UseFont = true;
            this.lblPhone.Location = new System.Drawing.Point(513, 60);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(39, 14);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone:";
            // 
            // lblOutlet
            // 
            this.lblOutlet.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOutlet.Appearance.Options.UseFont = true;
            this.lblOutlet.Location = new System.Drawing.Point(513, 25);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(39, 14);
            this.lblOutlet.TabIndex = 5;
            this.lblOutlet.Text = "Outlet:";
            // 
            // lblRole
            // 
            this.lblRole.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRole.Appearance.Options.UseFont = true;
            this.lblRole.Location = new System.Drawing.Point(20, 200);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(27, 14);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Role:";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConfirmPassword.Appearance.Options.UseFont = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 165);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(100, 14);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // lblPassword
            // 
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPassword.Appearance.Options.UseFont = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(55, 14);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // lblFullNameKh
            // 
            this.lblFullNameKh.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFullNameKh.Appearance.Options.UseFont = true;
            this.lblFullNameKh.Location = new System.Drawing.Point(20, 95);
            this.lblFullNameKh.Name = "lblFullNameKh";
            this.lblFullNameKh.Size = new System.Drawing.Size(84, 14);
            this.lblFullNameKh.TabIndex = 21;
            this.lblFullNameKh.Text = "Full Name (Kh):";
            // 
            // lblFullName
            // 
            this.lblFullName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFullName.Appearance.Options.UseFont = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 60);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(56, 14);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Location = new System.Drawing.Point(20, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name:";
            // 
            // cboRole
            // 
            this.cboRole.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(130, 200);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(267, 22);
            this.cboRole.TabIndex = 20;
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.labelControl1);
            this.panelDetail.Controls.Add(this.txtaddress);
            this.panelDetail.Controls.Add(this.btnaddOutlet);
            this.panelDetail.Controls.Add(this.btnaddRole);
            this.panelDetail.Controls.Add(this.cboOutlet);
            this.panelDetail.Controls.Add(this.cboRole);
            this.panelDetail.Controls.Add(this.lblUserName);
            this.panelDetail.Controls.Add(this.lblFullName);
            this.panelDetail.Controls.Add(this.lblFullNameKh);
            this.panelDetail.Controls.Add(this.lblPassword);
            this.panelDetail.Controls.Add(this.lblConfirmPassword);
            this.panelDetail.Controls.Add(this.lblRole);
            this.panelDetail.Controls.Add(this.lblOutlet);
            this.panelDetail.Controls.Add(this.lblPhone);
            this.panelDetail.Controls.Add(this.lblEmail);
            this.panelDetail.Controls.Add(this.lblAddressKh);
            this.panelDetail.Controls.Add(this.txtUserName);
            this.panelDetail.Controls.Add(this.txtFullName);
            this.panelDetail.Controls.Add(this.txtFullNameKh);
            this.panelDetail.Controls.Add(this.txtPassword);
            this.panelDetail.Controls.Add(this.txtConfirmPassword);
            this.panelDetail.Controls.Add(this.txtPhone);
            this.panelDetail.Controls.Add(this.txtEmail);
            this.panelDetail.Controls.Add(this.txtAddressKh);
            this.panelDetail.Controls.Add(this.chkActive);
            this.panelDetail.Controls.Add(this.chkLocked);
            this.panelDetail.Controls.Add(this.btnAdd);
            this.panelDetail.Controls.Add(this.btnCancel);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(0, 80);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(980, 260);
            this.panelDetail.TabIndex = 2;
            // 
            // btnaddOutlet
            // 
            this.btnaddOutlet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnaddOutlet.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnaddOutlet.Location = new System.Drawing.Point(910, 19);
            this.btnaddOutlet.Name = "btnaddOutlet";
            this.btnaddOutlet.Size = new System.Drawing.Size(27, 26);
            this.btnaddOutlet.TabIndex = 169;
            this.btnaddOutlet.UseVisualStyleBackColor = false;
            // 
            // btnaddRole
            // 
            this.btnaddRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnaddRole.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnaddRole.Location = new System.Drawing.Point(406, 197);
            this.btnaddRole.Name = "btnaddRole";
            this.btnaddRole.Size = new System.Drawing.Size(27, 26);
            this.btnaddRole.TabIndex = 168;
            this.btnaddRole.UseVisualStyleBackColor = false;
            // 
            // cboOutlet
            // 
            this.cboOutlet.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(593, 22);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(305, 22);
            this.cboOutlet.TabIndex = 24;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnClose.Location = new System.Drawing.Point(898, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(818, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            // 
            // lblCountRow
            // 
            this.lblCountRow.Location = new System.Drawing.Point(10, 12);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(53, 13);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Count Row";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 580);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(980, 40);
            this.panelBottom.TabIndex = 1;
            // 
            // gridControlUser
            // 
            this.gridControlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUser.Location = new System.Drawing.Point(2, 2);
            this.gridControlUser.MainView = this.gridViewUser;
            this.gridControlUser.Name = "gridControlUser";
            this.gridControlUser.Size = new System.Drawing.Size(976, 236);
            this.gridControlUser.TabIndex = 0;
            this.gridControlUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUser,
            this.gridView1});
            // 
            // gridViewUser
            // 
            this.gridViewUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridViewUser.GridControl = this.gridControlUser;
            this.gridViewUser.Name = "gridViewUser";
            this.gridViewUser.OptionsBehavior.Editable = false;
            this.gridViewUser.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "User Name";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Full Name";
            this.gridColumn2.FieldName = "FullName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Full Name (Kh)";
            this.gridColumn9.FieldName = "FullNameKh";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Role";
            this.gridColumn3.FieldName = "RoleName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Outlet";
            this.gridColumn4.FieldName = "OutletName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Address (Kh)";
            this.gridColumn10.FieldName = "AddressKh";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Phone";
            this.gridColumn5.FieldName = "Phone";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Email";
            this.gridColumn6.FieldName = "Email";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Active";
            this.gridColumn7.FieldName = "IsActive";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Locked";
            this.gridColumn8.FieldName = "IsLocked";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlUser;
            this.gridView1.Name = "gridView1";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridControlUser);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 340);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(980, 240);
            this.panelGrid.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(513, 186);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 14);
            this.labelControl1.TabIndex = 170;
            this.labelControl1.Text = "Address :";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(593, 183);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Properties.Appearance.Font = new System.Drawing.Font("Khmer OS Battambang", 9F);
            this.txtaddress.Properties.Appearance.Options.UseFont = true;
            this.txtaddress.Size = new System.Drawing.Size(344, 36);
            this.txtaddress.TabIndex = 171;
            // 
            // guiUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.guiUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddressKh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullNameKh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtaddress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelControl lblSystemName;
        private PictureEdit picLogo;
        private PanelControl panelHeader;
        private SimpleButton btnCancel;
        private SimpleButton btnAdd;
        private CheckEdit chkLocked;
        private CheckEdit chkActive;
        private MemoEdit txtAddressKh;
        private TextEdit txtEmail;
        private TextEdit txtPhone;
        private TextEdit txtConfirmPassword;
        private TextEdit txtPassword;
        private TextEdit txtFullNameKh;
        private TextEdit txtFullName;
        private TextEdit txtUserName;
        private LabelControl lblAddressKh;
        private LabelControl lblEmail;
        private LabelControl lblPhone;
        private LabelControl lblOutlet;
        private LabelControl lblRole;
        private LabelControl lblConfirmPassword;
        private LabelControl lblPassword;
        private LabelControl lblFullNameKh;
        private LabelControl lblFullName;
        private LabelControl lblUserName;
        private System.Windows.Forms.ComboBox cboRole;
        private PanelControl panelDetail;
        private SimpleButton btnClose;
        private SimpleButton btnExport;
        private LabelControl lblCountRow;
        private PanelControl panelBottom;
        private GridControl gridControlUser;
        private GridView gridViewUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private GridView gridView1;
        private PanelControl panelGrid;
        private System.Windows.Forms.ComboBox cboOutlet;
        private Button btnaddOutlet;
        private Button btnaddRole;
        private LabelControl labelControl1;
        private MemoEdit txtaddress;
    }
}
