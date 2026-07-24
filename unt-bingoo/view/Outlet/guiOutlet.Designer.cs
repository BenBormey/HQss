using System;
using System.Drawing;
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
        private Button btnaddCategory;
        private PictureBox picCustomer;
        // Grid panel
        private PanelControl panelGrid;
        private DevExpress.XtraGrid.GridControl gridControlOutlet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOutlet;
        // Grid Columns
        private DevExpress.XtraGrid.Columns.GridColumn OutletCode;
        private DevExpress.XtraGrid.Columns.GridColumn OutletName;
        private DevExpress.XtraGrid.Columns.GridColumn Province;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn FrancisePhone;
        private DevExpress.XtraGrid.Columns.GridColumn PhotoPath;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn Update;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit gridImage;
        private PanelControl panelHeader;
        private CheckEdit chkHeadOffice;
        private PictureEdit picLogo;
        private SimpleButton btnClose;
        private SimpleButton btnExport;
        private LabelControl lblCountRow;
        private PanelControl panelBottom;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiOutlet));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DetailImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Url = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlOutlet = new DevExpress.XtraGrid.GridControl();
            this.gridViewOutlet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OutletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.typeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Province = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FrancisePhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhotoPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.position = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HourOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grandOpeningDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProvinceNameEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Is24Hours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Update = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.provinceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel23 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.panel24 = new System.Windows.Forms.Panel();
            this.flpPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.dtpOpening = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.cboHourOperation = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.txtoutletphon = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtposition = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtManager = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtfrandtype = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.txtOutletCode = new DevExpress.XtraEditors.TextEdit();
            this.Label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbFranchise = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtvatNumber = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.chkDeactive = new DevExpress.XtraEditors.CheckEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnaddCategory = new System.Windows.Forms.Button();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.chkHeadOffice = new DevExpress.XtraEditors.CheckEdit();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnmainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridImage = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtoutletphon.Properties)).BeginInit();
            this.panel19.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtposition.Properties)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtfrandtype.Properties)).BeginInit();
            this.Panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletCode.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvatNumber.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHeadOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DetailImage,
            this.Url});
            this.gridView1.GridControl = this.gridControlOutlet;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            // 
            // DetailImage
            // 
            this.DetailImage.Caption = "DetailImage";
            this.DetailImage.FieldName = "DetailImage";
            this.DetailImage.Name = "DetailImage";
            this.DetailImage.Visible = true;
            this.DetailImage.VisibleIndex = 0;
            // 
            // Url
            // 
            this.Url.Caption = "Url";
            this.Url.FieldName = "Url";
            this.Url.Name = "Url";
            // 
            // gridControlOutlet
            // 
            this.gridControlOutlet.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlOutlet.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlOutlet.Location = new System.Drawing.Point(22, 10);
            this.gridControlOutlet.MainView = this.gridViewOutlet;
            this.gridControlOutlet.Name = "gridControlOutlet";
            this.gridControlOutlet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemButtonEdit3});
            this.gridControlOutlet.Size = new System.Drawing.Size(1569, 353);
            this.gridControlOutlet.TabIndex = 0;
            this.gridControlOutlet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOutlet,
            this.gridView1});
            this.gridControlOutlet.Click += new System.EventHandler(this.gridControlOutlet_Click);
            // 
            // gridViewOutlet
            // 
            this.gridViewOutlet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gridViewOutlet.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewOutlet.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gridViewOutlet.Appearance.Row.Options.UseFont = true;
            this.gridViewOutlet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OutletCode,
            this.OutletName,
            this.typeName,
            this.Province,
            this.FrancisePhone,
            this.gridColumn6,
            this.ProductImage,
            this.PhotoPath,
            this.position,
            this.HourOperation,
            this.gridColumn1,
            this.grandOpeningDate,
            this.ProvinceNameEN,
            this.Email,
            this.Address,
            this.IsActive,
            this.Is24Hours,
            this.Update,
            this.Delete,
            this.provinceId});
            this.gridViewOutlet.GridControl = this.gridControlOutlet;
            this.gridViewOutlet.Name = "gridViewOutlet";
            this.gridViewOutlet.OptionsBehavior.ReadOnly = true;
            this.gridViewOutlet.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewOutlet.OptionsView.ShowGroupPanel = false;
            this.gridViewOutlet.RowHeight = 30;
            this.gridViewOutlet.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewOutlet_RowCellClick);
            this.gridViewOutlet.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewOutlet_RowCellStyle);
            this.gridViewOutlet.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridViewOutlet_MasterRowExpanded);
            this.gridViewOutlet.MasterRowGetLevelDefaultView += new DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventHandler(this.gridViewOutlet_MasterRowGetLevelDefaultView);
            this.gridViewOutlet.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridViewOutlet_MasterRowGetChildList);
            this.gridViewOutlet.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gridViewOutlet_MasterRowGetRelationCount_1);
            // 
            // OutletCode
            // 
            this.OutletCode.Caption = "Outlet Code";
            this.OutletCode.FieldName = "OutletCode";
            this.OutletCode.Name = "OutletCode";
            this.OutletCode.OptionsColumn.ReadOnly = true;
            this.OutletCode.Visible = true;
            this.OutletCode.VisibleIndex = 0;
            this.OutletCode.Width = 27;
            // 
            // OutletName
            // 
            this.OutletName.Caption = "Outlet Name";
            this.OutletName.FieldName = "OutletName";
            this.OutletName.Name = "OutletName";
            this.OutletName.Visible = true;
            this.OutletName.VisibleIndex = 2;
            this.OutletName.Width = 186;
            // 
            // typeName
            // 
            this.typeName.Caption = "Franchise type";
            this.typeName.FieldName = "typeName";
            this.typeName.Name = "typeName";
            this.typeName.Visible = true;
            this.typeName.VisibleIndex = 3;
            this.typeName.Width = 127;
            // 
            // Province
            // 
            this.Province.Caption = "Province/City";
            this.Province.FieldName = "Province";
            this.Province.Name = "Province";
            this.Province.OptionsColumn.ReadOnly = true;
            this.Province.Width = 188;
            // 
            // FrancisePhone
            // 
            this.FrancisePhone.Caption = "Francise Phone";
            this.FrancisePhone.FieldName = "FrancisePhone";
            this.FrancisePhone.Name = "FrancisePhone";
            this.FrancisePhone.OptionsColumn.ReadOnly = true;
            this.FrancisePhone.Visible = true;
            this.FrancisePhone.VisibleIndex = 4;
            this.FrancisePhone.Width = 101;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Manager";
            this.gridColumn6.FieldName = "Manager";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 76;
            // 
            // ProductImage
            // 
            this.ProductImage.Caption = "ProductImage";
            this.ProductImage.FieldName = "ProductImage";
            this.ProductImage.Name = "ProductImage";
            this.ProductImage.OptionsColumn.ReadOnly = true;
            // 
            // PhotoPath
            // 
            this.PhotoPath.Caption = "Main Photo";
            this.PhotoPath.FieldName = "PhotoPath";
            this.PhotoPath.Name = "PhotoPath";
            this.PhotoPath.OptionsColumn.ReadOnly = true;
            // 
            // position
            // 
            this.position.Caption = "position";
            this.position.FieldName = "position";
            this.position.Name = "position";
            this.position.Visible = true;
            this.position.VisibleIndex = 6;
            this.position.Width = 128;
            // 
            // HourOperation
            // 
            this.HourOperation.Caption = "HourOperation";
            this.HourOperation.FieldName = "hourOperation";
            this.HourOperation.Name = "HourOperation";
            this.HourOperation.Visible = true;
            this.HourOperation.VisibleIndex = 8;
            this.HourOperation.Width = 132;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // grandOpeningDate
            // 
            this.grandOpeningDate.Caption = "Grand Opening Date";
            this.grandOpeningDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.grandOpeningDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grandOpeningDate.FieldName = "grandOpeningDate";
            this.grandOpeningDate.Name = "grandOpeningDate";
            this.grandOpeningDate.OptionsColumn.ReadOnly = true;
            this.grandOpeningDate.Visible = true;
            this.grandOpeningDate.VisibleIndex = 7;
            this.grandOpeningDate.Width = 79;
            // 
            // ProvinceNameEN
            // 
            this.ProvinceNameEN.Caption = "Province ";
            this.ProvinceNameEN.FieldName = "ProvinceNameEN";
            this.ProvinceNameEN.Name = "ProvinceNameEN";
            this.ProvinceNameEN.Visible = true;
            this.ProvinceNameEN.VisibleIndex = 10;
            this.ProvinceNameEN.Width = 93;
            // 
            // Email
            // 
            this.Email.Caption = "Email";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 11;
            this.Email.Width = 226;
            // 
            // Address
            // 
            this.Address.Caption = "Address";
            this.Address.FieldName = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.VisibleIndex = 12;
            this.Address.Width = 54;
            // 
            // IsActive
            // 
            this.IsActive.Caption = "Is Active";
            this.IsActive.FieldName = "IsActive";
            this.IsActive.MinWidth = 18;
            this.IsActive.Name = "IsActive";
            this.IsActive.OptionsColumn.ReadOnly = true;
            this.IsActive.Visible = true;
            this.IsActive.VisibleIndex = 1;
            this.IsActive.Width = 50;
            // 
            // Is24Hours
            // 
            this.Is24Hours.Caption = "Is24Hours";
            this.Is24Hours.FieldName = "Is24Hours";
            this.Is24Hours.Name = "Is24Hours";
            this.Is24Hours.Visible = true;
            this.Is24Hours.VisibleIndex = 9;
            this.Is24Hours.Width = 50;
            // 
            // Update
            // 
            this.Update.Caption = "Edit";
            this.Update.ColumnEdit = this.repositoryItemButtonEdit1;
            this.Update.FieldName = "Update";
            this.Update.Name = "Update";
            this.Update.Visible = true;
            this.Update.VisibleIndex = 13;
            this.Update.Width = 55;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.Click += new System.EventHandler(this.btnUpdate_ButtonClick);
            // 
            // Delete
            // 
            this.Delete.Caption = " Delete";
            this.Delete.ColumnEdit = this.repositoryItemButtonEdit2;
            this.Delete.FieldName = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 14;
            this.Delete.Width = 167;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Deleted16;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.Click += new System.EventHandler(this.btnmainDelete_ButtonClick);
            // 
            // provinceId
            // 
            this.provinceId.Caption = "provinceId";
            this.provinceId.FieldName = "provinceId";
            this.provinceId.Name = "provinceId";
            // 
            // repositoryItemButtonEdit3
            // 
            this.repositoryItemButtonEdit3.AutoHeight = false;
            editorButtonImageOptions3.Image = global::unt_bingoo.Properties.Resources.estimate;
            this.repositoryItemButtonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit3.Name = "repositoryItemButtonEdit3";
            this.repositoryItemButtonEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit3_ButtonClick);
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.panel20);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(0, 84);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Padding = new System.Windows.Forms.Padding(20, 18, 20, 14);
            this.panelDetail.Size = new System.Drawing.Size(1613, 256);
            this.panelDetail.TabIndex = 2;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.panel21);
            this.panel20.Controls.Add(this.panel4);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(22, 20);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(1569, 227);
            this.panel20.TabIndex = 225;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel25);
            this.panel21.Controls.Add(this.panel12);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(415, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(1154, 227);
            this.panel21.TabIndex = 223;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.panel22);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(359, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(795, 227);
            this.panel25.TabIndex = 224;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel3);
            this.panel22.Controls.Add(this.panel23);
            this.panel22.Controls.Add(this.panel24);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.panel22.Size = new System.Drawing.Size(795, 227);
            this.panel22.TabIndex = 225;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(416, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 227);
            this.panel3.TabIndex = 148;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 34);
            this.panel2.TabIndex = 183;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton2.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.simpleButton2.Location = new System.Drawing.Point(95, 0);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(95, 34);
            this.simpleButton2.TabIndex = 19;
            this.simpleButton2.Text = "Cancel";
            this.simpleButton2.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel23.Controls.Add(this.flowLayoutPanel1);
            this.panel23.Controls.Add(this.simpleButton4);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(220, 0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel23.Size = new System.Drawing.Size(196, 227);
            this.panel23.TabIndex = 147;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(193, 193);
            this.flowLayoutPanel1.TabIndex = 144;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton4.Location = new System.Drawing.Point(3, 193);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(193, 34);
            this.simpleButton4.TabIndex = 145;
            this.simpleButton4.Text = "Add Citizenship";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.flpPhotos);
            this.panel24.Controls.Add(this.btnAddPhoto);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(8, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(212, 227);
            this.panel24.TabIndex = 146;
            // 
            // flpPhotos
            // 
            this.flpPhotos.AutoScroll = true;
            this.flpPhotos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPhotos.Location = new System.Drawing.Point(0, 0);
            this.flpPhotos.Name = "flpPhotos";
            this.flpPhotos.Size = new System.Drawing.Size(212, 193);
            this.flpPhotos.TabIndex = 144;
            this.flpPhotos.Paint += new System.Windows.Forms.PaintEventHandler(this.flpPhotos_Paint_1);
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddPhoto.Location = new System.Drawing.Point(0, 193);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(212, 34);
            this.btnAddPhoto.TabIndex = 145;
            this.btnAddPhoto.Text = "Add ShopPhoto";
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            this.btnAddPhoto.DoubleClick += new System.EventHandler(this.simpleButton5_DoubleClick);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.groupBox2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(359, 227);
            this.panel12.TabIndex = 223;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel18);
            this.groupBox2.Controls.Add(this.panel17);
            this.groupBox2.Controls.Add(this.panel16);
            this.groupBox2.Controls.Add(this.panel15);
            this.groupBox2.Controls.Add(this.panel14);
            this.groupBox2.Controls.Add(this.panel19);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.dtpOpening);
            this.panel18.Controls.Add(this.label12);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(3, 173);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2);
            this.panel18.Size = new System.Drawing.Size(353, 26);
            this.panel18.TabIndex = 15;
            // 
            // dtpOpening
            // 
            this.dtpOpening.CustomFormat = "dd-MM-yyyy";
            this.dtpOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpOpening.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOpening.Location = new System.Drawing.Point(119, 2);
            this.dtpOpening.Name = "dtpOpening";
            this.dtpOpening.Size = new System.Drawing.Size(232, 21);
            this.dtpOpening.TabIndex = 213;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(2, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "Grand Opening:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.cboProvince);
            this.panel17.Controls.Add(this.label11);
            this.panel17.Controls.Add(this.button1);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(3, 147);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2);
            this.panel17.Size = new System.Drawing.Size(353, 26);
            this.panel17.TabIndex = 14;
            // 
            // cboProvince
            // 
            this.cboProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboProvince.Location = new System.Drawing.Point(119, 2);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(208, 21);
            this.cboProvince.TabIndex = 203;
            this.cboProvince.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBrand_KeyPress);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(2, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Province/City:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button1.Location = new System.Drawing.Point(327, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 22);
            this.button1.TabIndex = 202;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.txtEmail);
            this.panel16.Controls.Add(this.label10);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(3, 121);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(2);
            this.panel16.Size = new System.Drawing.Size(353, 26);
            this.panel16.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(119, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(232, 20);
            this.txtEmail.TabIndex = 200;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(2, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "Email:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.cboHourOperation);
            this.panel15.Controls.Add(this.label8);
            this.panel15.Controls.Add(this.button3);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(3, 95);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(2);
            this.panel15.Size = new System.Drawing.Size(353, 26);
            this.panel15.TabIndex = 12;
            // 
            // cboHourOperation
            // 
            this.cboHourOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboHourOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHourOperation.Location = new System.Drawing.Point(119, 2);
            this.cboHourOperation.Name = "cboHourOperation";
            this.cboHourOperation.Size = new System.Drawing.Size(208, 21);
            this.cboHourOperation.TabIndex = 219;
            this.cboHourOperation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboHourOperation_KeyPress);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Hour Of Operation:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button3.Location = new System.Drawing.Point(327, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 22);
            this.button3.TabIndex = 219;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.txtoutletphon);
            this.panel14.Controls.Add(this.label7);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(3, 69);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(2);
            this.panel14.Size = new System.Drawing.Size(353, 26);
            this.panel14.TabIndex = 11;
            // 
            // txtoutletphon
            // 
            this.txtoutletphon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtoutletphon.Location = new System.Drawing.Point(119, 2);
            this.txtoutletphon.Name = "txtoutletphon";
            this.txtoutletphon.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoutletphon.Properties.Appearance.Options.UseFont = true;
            this.txtoutletphon.Size = new System.Drawing.Size(232, 20);
            this.txtoutletphon.TabIndex = 217;
            this.txtoutletphon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtoutletphon_KeyPress);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(2, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Outlet Phone:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.panel13);
            this.panel19.Controls.Add(this.label14);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(3, 17);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2);
            this.panel19.Size = new System.Drawing.Size(353, 52);
            this.panel19.TabIndex = 4;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.txtAddress);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(119, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(232, 48);
            this.panel13.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(0, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(232, 48);
            this.txtAddress.TabIndex = 201;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(2, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 48);
            this.label14.TabIndex = 0;
            this.label14.Text = "Address:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.GroupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 227);
            this.panel4.TabIndex = 222;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.panel11);
            this.GroupBox1.Controls.Add(this.panel10);
            this.GroupBox1.Controls.Add(this.panel8);
            this.GroupBox1.Controls.Add(this.panel7);
            this.GroupBox1.Controls.Add(this.Panel9);
            this.GroupBox1.Controls.Add(this.panel6);
            this.GroupBox1.Controls.Add(this.panel5);
            this.GroupBox1.Controls.Add(this.panel1);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(415, 256);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Detail";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtposition);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 199);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2);
            this.panel11.Size = new System.Drawing.Size(409, 26);
            this.panel11.TabIndex = 18;
            // 
            // txtposition
            // 
            this.txtposition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtposition.Location = new System.Drawing.Point(127, 2);
            this.txtposition.Name = "txtposition";
            this.txtposition.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition.Properties.Appearance.Options.UseFont = true;
            this.txtposition.Size = new System.Drawing.Size(280, 20);
            this.txtposition.TabIndex = 209;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(2, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Position:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtPhone);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 173);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2);
            this.panel10.Size = new System.Drawing.Size(409, 26);
            this.panel10.TabIndex = 17;
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Location = new System.Drawing.Point(127, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Size = new System.Drawing.Size(280, 20);
            this.txtPhone.TabIndex = 198;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(2, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Frranchise Phone :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtManager);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 147);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2);
            this.panel8.Size = new System.Drawing.Size(409, 26);
            this.panel8.TabIndex = 16;
            // 
            // txtManager
            // 
            this.txtManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtManager.Location = new System.Drawing.Point(127, 2);
            this.txtManager.Name = "txtManager";
            this.txtManager.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManager.Properties.Appearance.Options.UseFont = true;
            this.txtManager.Size = new System.Drawing.Size(280, 20);
            this.txtManager.TabIndex = 199;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Franchise Name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtfrandtype);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 121);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(2);
            this.panel7.Size = new System.Drawing.Size(409, 26);
            this.panel7.TabIndex = 15;
            // 
            // txtfrandtype
            // 
            this.txtfrandtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtfrandtype.Enabled = false;
            this.txtfrandtype.Location = new System.Drawing.Point(127, 2);
            this.txtfrandtype.Name = "txtfrandtype";
            this.txtfrandtype.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfrandtype.Properties.Appearance.Options.UseFont = true;
            this.txtfrandtype.Size = new System.Drawing.Size(280, 20);
            this.txtfrandtype.TabIndex = 215;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Franchise Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Panel9
            // 
            this.Panel9.Controls.Add(this.txtOutletCode);
            this.Panel9.Controls.Add(this.Label9);
            this.Panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel9.Location = new System.Drawing.Point(3, 95);
            this.Panel9.Name = "Panel9";
            this.Panel9.Padding = new System.Windows.Forms.Padding(2);
            this.Panel9.Size = new System.Drawing.Size(409, 26);
            this.Panel9.TabIndex = 12;
            // 
            // txtOutletCode
            // 
            this.txtOutletCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutletCode.Enabled = false;
            this.txtOutletCode.Location = new System.Drawing.Point(127, 2);
            this.txtOutletCode.Name = "txtOutletCode";
            this.txtOutletCode.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutletCode.Properties.Appearance.Options.UseFont = true;
            this.txtOutletCode.Size = new System.Drawing.Size(280, 20);
            this.txtOutletCode.TabIndex = 206;
            // 
            // Label9
            // 
            this.Label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(2, 2);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(125, 22);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "Outlet Code:";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmbFranchise);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 69);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(409, 26);
            this.panel6.TabIndex = 14;
            // 
            // cmbFranchise
            // 
            this.cmbFranchise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFranchise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFranchise.Location = new System.Drawing.Point(127, 2);
            this.cmbFranchise.Name = "cmbFranchise";
            this.cmbFranchise.Size = new System.Drawing.Size(256, 21);
            this.cmbFranchise.TabIndex = 225;
            this.cmbFranchise.SelectedIndexChanged += new System.EventHandler(this.cmbFranchise_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Outlet Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button2.Location = new System.Drawing.Point(383, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 22);
            this.button2.TabIndex = 204;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtvatNumber);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 43);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(409, 26);
            this.panel5.TabIndex = 13;
            // 
            // txtvatNumber
            // 
            this.txtvatNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtvatNumber.Location = new System.Drawing.Point(127, 2);
            this.txtvatNumber.Name = "txtvatNumber";
            this.txtvatNumber.Size = new System.Drawing.Size(280, 20);
            this.txtvatNumber.TabIndex = 222;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "VAT Number:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkActive);
            this.panel1.Controls.Add(this.chkDeactive);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(409, 26);
            this.panel1.TabIndex = 11;
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(127, 2);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(61, 19);
            this.chkActive.TabIndex = 227;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // chkDeactive
            // 
            this.chkDeactive.Location = new System.Drawing.Point(194, 2);
            this.chkDeactive.Name = "chkDeactive";
            this.chkDeactive.Properties.Caption = "Deactive";
            this.chkDeactive.Size = new System.Drawing.Size(85, 19);
            this.chkDeactive.TabIndex = 228;
            this.chkDeactive.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(2, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 22);
            this.label13.TabIndex = 0;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(1190, 55);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 25);
            this.simpleButton1.TabIndex = 180;
            this.simpleButton1.Text = "Refresh ";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnaddCategory
            // 
            this.btnaddCategory.Location = new System.Drawing.Point(622, 12);
            this.btnaddCategory.Name = "btnaddCategory";
            this.btnaddCategory.Size = new System.Drawing.Size(75, 23);
            this.btnaddCategory.TabIndex = 1;
            this.btnaddCategory.Visible = false;
            // 
            // picCustomer
            // 
            this.picCustomer.Location = new System.Drawing.Point(0, 0);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.Size = new System.Drawing.Size(100, 50);
            this.picCustomer.TabIndex = 0;
            this.picCustomer.TabStop = false;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridControlOutlet);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 340);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(20, 8, 20, 0);
            this.panelGrid.Size = new System.Drawing.Size(1613, 365);
            this.panelGrid.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Controls.Add(this.simpleButton1);
            this.panelHeader.Controls.Add(this.chkHeadOffice);
            this.panelHeader.Controls.Add(this.btnaddCategory);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1613, 84);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(106, 54);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 182;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.PicSectionIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(2, 2);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(98, 80);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 181;
            this.PicSectionIcon.TabStop = false;
            // 
            // chkHeadOffice
            // 
            this.chkHeadOffice.Location = new System.Drawing.Point(1196, 30);
            this.chkHeadOffice.Name = "chkHeadOffice";
            this.chkHeadOffice.Properties.Caption = "Warehouse (Head Office)";
            this.chkHeadOffice.Size = new System.Drawing.Size(160, 19);
            this.chkHeadOffice.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 96);
            this.picLogo.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(1531, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 2, 16, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.White;
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(1431, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblCountRow
            // 
            this.lblCountRow.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCountRow.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblCountRow.Appearance.Options.UseFont = true;
            this.lblCountRow.Appearance.Options.UseForeColor = true;
            this.lblCountRow.Location = new System.Drawing.Point(20, 14);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(80, 15);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Total Record: 0";
            // 
            // panelBottom
            // 
            this.panelBottom.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.panelBottom.Appearance.Options.UseBackColor = true;
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 705);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1613, 40);
            this.panelBottom.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Name = "btnUpdate";
            // 
            // btnmainDelete
            // 
            this.btnmainDelete.Name = "btnmainDelete";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // gridImage
            // 
            this.gridImage.Name = "gridImage";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Name = "gridColumn4";
            // 
            // guiOutlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 745);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "guiOutlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OUTLET MANAGEMENT";
            this.Load += new System.EventHandler(this.guiOutlet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtoutletphon.Properties)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtposition.Properties)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtManager.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtfrandtype.Properties)).EndInit();
            this.Panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletCode.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtvatNumber.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHeadOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImage)).EndInit();
            this.ResumeLayout(false);

        }
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn ProductImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DetailImage;
        private DevExpress.XtraGrid.Columns.GridColumn Url;
        private DevExpress.XtraGrid.Columns.GridColumn position;
        private DevExpress.XtraGrid.Columns.GridColumn grandOpeningDate;
        private SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn typeName;
        private DevExpress.XtraGrid.Columns.GridColumn IsActive;
        private LabelControl lblSystemName;
        private PictureBox PicSectionIcon;
        private DevExpress.XtraGrid.Columns.GridColumn HourOperation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Is24Hours;
        private DevExpress.XtraGrid.Columns.GridColumn ProvinceNameEN;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn provinceId;
        private Panel panel20;
        private Panel panel21;
        private Panel panel25;
        private Panel panel22;
        private SimpleButton simpleButton2;
        private SimpleButton btnAdd;
        private Panel panel23;
        private FlowLayoutPanel flowLayoutPanel1;
        private SimpleButton simpleButton4;
        private Panel panel24;
        private FlowLayoutPanel flpPhotos;
        private SimpleButton btnAddPhoto;
        private Panel panel12;
        internal GroupBox groupBox2;
        internal Panel panel18;
        private DateTimePicker dtpOpening;
        internal Label label12;
        internal Panel panel17;
        private System.Windows.Forms.ComboBox cboProvince;
        internal Label label11;
        private Button button1;
        internal Panel panel16;
        private TextEdit txtEmail;
        internal Label label10;
        internal Panel panel15;
        private System.Windows.Forms.ComboBox cboHourOperation;
        internal Label label8;
        private Button button3;
        internal Panel panel14;
        private TextEdit txtoutletphon;
        internal Label label7;
        internal Panel panel19;
        private Panel panel13;
        private MemoEdit txtAddress;
        internal Label label14;
        private Panel panel4;
        internal GroupBox GroupBox1;
        internal Panel panel11;
        private TextEdit txtposition;
        internal Label label6;
        internal Panel panel10;
        private TextEdit txtPhone;
        internal Label label5;
        internal Panel panel8;
        private TextEdit txtManager;
        internal Label label4;
        internal Panel panel7;
        private TextEdit txtfrandtype;
        internal Label label3;
        internal Panel Panel9;
        private TextEdit txtOutletCode;
        internal Label Label9;
        internal Panel panel6;
        private System.Windows.Forms.ComboBox cmbFranchise;
        internal Label label2;
        private Button button2;
        internal Panel panel5;
        private TextEdit txtvatNumber;
        internal Label label1;
        internal Panel panel1;
        private CheckEdit chkActive;
        private CheckEdit chkDeactive;
        internal Label label13;
        private Panel panel3;
        private Panel panel2;
    }
}