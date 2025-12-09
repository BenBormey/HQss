using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace unt_bingoo.view.Outlet
{
    partial class guiOutlet
    {
        private System.ComponentModel.IContainer components = null;

        // Top detail panel
        private PanelControl panelDetail;
        private LabelControl lblOutletCode;
        private LabelControl lblOutletName;
        private LabelControl lblProvince;
        private LabelControl lblAddress;
        private LabelControl lblPhone;
        private LabelControl lblManager;

        private TextEdit txtOutletCode;
        private TextEdit txtOutletName;
        private ComboBoxEdit cboProvince;
        private MemoEdit txtAddress;
        private TextEdit txtPhone;
        private TextEdit txtManager;

        private CheckEdit chkHeadOffice;
        private CheckEdit chkActive;

        private SimpleButton btnAdd;
        private SimpleButton btnCancel;

        // Grid panel
        private PanelControl panelGrid;
        private GridControl gridControlOutlet;
        private GridView gridViewOutlet;

        // Bottom panel
        private PanelControl panelBottom;
        private LabelControl lblCountRow;
        private SimpleButton btnExport;
        private SimpleButton btnClose;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblOutletCode = new DevExpress.XtraEditors.LabelControl();
            this.lblOutletName = new DevExpress.XtraEditors.LabelControl();
            this.lblProvince = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblManager = new DevExpress.XtraEditors.LabelControl();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.txtOutletCode = new DevExpress.XtraEditors.TextEdit();
            this.txtOutletName = new DevExpress.XtraEditors.TextEdit();
            this.cboProvince = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtManager = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
            this.chkHeadOffice = new DevExpress.XtraEditors.CheckEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridControlOutlet = new DevExpress.XtraGrid.GridControl();
            this.gridViewOutlet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHeadOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.lblOutletCode);
            this.panelDetail.Controls.Add(this.lblOutletName);
            this.panelDetail.Controls.Add(this.lblProvince);
            this.panelDetail.Controls.Add(this.lblPhone);
            this.panelDetail.Controls.Add(this.lblManager);
            this.panelDetail.Controls.Add(this.lblAddress);
            this.panelDetail.Controls.Add(this.txtOutletCode);
            this.panelDetail.Controls.Add(this.txtOutletName);
            this.panelDetail.Controls.Add(this.cboProvince);
            this.panelDetail.Controls.Add(this.txtPhone);
            this.panelDetail.Controls.Add(this.txtManager);
            this.panelDetail.Controls.Add(this.txtAddress);
            this.panelDetail.Controls.Add(this.chkHeadOffice);
            this.panelDetail.Controls.Add(this.chkActive);
            this.panelDetail.Controls.Add(this.btnAdd);
            this.panelDetail.Controls.Add(this.btnCancel);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(0, 90);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(950, 200);
            this.panelDetail.TabIndex = 2;
            // 
            // lblOutletCode
            // 
            this.lblOutletCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutletCode.Appearance.Options.UseFont = true;
            this.lblOutletCode.Location = new System.Drawing.Point(20, 25);
            this.lblOutletCode.Name = "lblOutletCode";
            this.lblOutletCode.Size = new System.Drawing.Size(71, 14);
            this.lblOutletCode.TabIndex = 0;
            this.lblOutletCode.Text = "Outlet Code:";
            // 
            // lblOutletName
            // 
            this.lblOutletName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutletName.Appearance.Options.UseFont = true;
            this.lblOutletName.Location = new System.Drawing.Point(20, 60);
            this.lblOutletName.Name = "lblOutletName";
            this.lblOutletName.Size = new System.Drawing.Size(74, 14);
            this.lblOutletName.TabIndex = 1;
            this.lblOutletName.Text = "Outlet Name:";
            // 
            // lblProvince
            // 
            this.lblProvince.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvince.Appearance.Options.UseFont = true;
            this.lblProvince.Location = new System.Drawing.Point(20, 95);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(75, 14);
            this.lblProvince.TabIndex = 2;
            this.lblProvince.Text = "Province/City:";
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Appearance.Options.UseFont = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 130);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(39, 14);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone:";
            // 
            // lblManager
            // 
            this.lblManager.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManager.Appearance.Options.UseFont = true;
            this.lblManager.Location = new System.Drawing.Point(20, 165);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(50, 14);
            this.lblManager.TabIndex = 4;
            this.lblManager.Text = "Manager:";
            // 
            // lblAddress
            // 
            this.lblAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Appearance.Options.UseFont = true;
            this.lblAddress.Location = new System.Drawing.Point(430, 25);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(47, 14);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address:";
            // 
            // txtOutletCode
            // 
            this.txtOutletCode.Location = new System.Drawing.Point(120, 22);
            this.txtOutletCode.Name = "txtOutletCode";
            this.txtOutletCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutletCode.Properties.Appearance.Options.UseFont = true;
            this.txtOutletCode.Size = new System.Drawing.Size(260, 20);
            this.txtOutletCode.TabIndex = 6;
            // 
            // txtOutletName
            // 
            this.txtOutletName.Location = new System.Drawing.Point(120, 57);
            this.txtOutletName.Name = "txtOutletName";
            this.txtOutletName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutletName.Properties.Appearance.Options.UseFont = true;
            this.txtOutletName.Size = new System.Drawing.Size(290, 20);
            this.txtOutletName.TabIndex = 7;
            // 
            // cboProvince
            // 
            this.cboProvince.Location = new System.Drawing.Point(120, 92);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvince.Properties.Appearance.Options.UseFont = true;
            this.cboProvince.Properties.Items.AddRange(new object[] {
            "Phnom Penh",
            "Kandal",
            "Kampong Cham",
            "Kampong Speu",
            "Kampong Thom",
            "Kampot",
            "Koh Kong",
            "Takeo",
            "Other"});
            this.cboProvince.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProvince.Size = new System.Drawing.Size(220, 20);
            this.cboProvince.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 127);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Size = new System.Drawing.Size(220, 20);
            this.txtPhone.TabIndex = 9;
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(120, 162);
            this.txtManager.Name = "txtManager";
            this.txtManager.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManager.Properties.Appearance.Options.UseFont = true;
            this.txtManager.Size = new System.Drawing.Size(290, 20);
            this.txtManager.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(500, 22);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Properties.Appearance.Options.UseFont = true;
            this.txtAddress.Size = new System.Drawing.Size(300, 80);
            this.txtAddress.TabIndex = 11;
            // 
            // chkHeadOffice
            // 
            this.chkHeadOffice.Location = new System.Drawing.Point(500, 115);
            this.chkHeadOffice.Name = "chkHeadOffice";
            this.chkHeadOffice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeadOffice.Properties.Appearance.Options.UseFont = true;
            this.chkHeadOffice.Properties.Caption = "Head Office";
            this.chkHeadOffice.Size = new System.Drawing.Size(75, 19);
            this.chkHeadOffice.TabIndex = 12;
            // 
            // chkActive
            // 
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(500, 140);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(75, 19);
            this.chkActive.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(700, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 25);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(790, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridControlOutlet);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 290);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(950, 270);
            this.panelGrid.TabIndex = 0;
            // 
            // gridControlOutlet
            // 
            this.gridControlOutlet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOutlet.Location = new System.Drawing.Point(2, 2);
            this.gridControlOutlet.MainView = this.gridViewOutlet;
            this.gridControlOutlet.Name = "gridControlOutlet";
            this.gridControlOutlet.Size = new System.Drawing.Size(946, 266);
            this.gridControlOutlet.TabIndex = 0;
            this.gridControlOutlet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOutlet});
            // 
            // gridViewOutlet
            // 
            this.gridViewOutlet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridViewOutlet.GridControl = this.gridControlOutlet;
            this.gridViewOutlet.Name = "gridViewOutlet";
            this.gridViewOutlet.OptionsBehavior.Editable = false;
            this.gridViewOutlet.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Outlet Code";
            this.gridColumn1.FieldName = "OutletCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Outlet Name";
            this.gridColumn2.FieldName = "OutletName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Province/City";
            this.gridColumn3.FieldName = "Province";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Address";
            this.gridColumn4.FieldName = "Address";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Phone";
            this.gridColumn5.FieldName = "Phone";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Manager";
            this.gridColumn6.FieldName = "Manager";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Head Office";
            this.gridColumn7.FieldName = "IsHeadOffice";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Active";
            this.gridColumn8.FieldName = "IsActive";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 560);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(950, 40);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCountRow
            // 
            this.lblCountRow.Location = new System.Drawing.Point(10, 12);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(53, 13);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Count Row";
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(788, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnClose.Location = new System.Drawing.Point(868, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(100, 30);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(427, 26);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Q\'s OUTLET MANAGEMENT SYSTEM";
            // 
            // picLogo
            // 
            this.picLogo.EditValue = global::unt_bingoo.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(10, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLogo.Size = new System.Drawing.Size(70, 70);
            this.picLogo.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 90);
            this.panelHeader.TabIndex = 3;
            // 
            // guiOutlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiOutlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.guiOutlet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHeadOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private LabelControl lblSystemName;
        private PictureEdit picLogo;
        private PanelControl panelHeader;
    }
}
