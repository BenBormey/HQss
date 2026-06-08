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
        private LabelControl lblOutletCode;
        private LabelControl lblProvince;
        private LabelControl lblAddress;
        private LabelControl lblPhone;
        private LabelControl lblManager;
        private LabelControl lblEmail;
        private MemoEdit txtAddress;
        private TextEdit txtPhone;
        private TextEdit txtManager;
        private TextEdit txtEmail;
        private CheckEdit chkActive;

        private System.Windows.Forms.ComboBox cboBrand;
        private Button btnaddCategory;
        private PictureBox picCustomer;

        private SimpleButton btnAdd;
        private SimpleButton btnCancel;
        private SimpleButton btnAddPhoto;

        // Grid panel
        private PanelControl panelGrid;
        private DevExpress.XtraGrid.GridControl gridControlOutlet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOutlet;

        // Grid Columns
        private DevExpress.XtraGrid.Columns.GridColumn OutletCode;
        private DevExpress.XtraGrid.Columns.GridColumn OutletName;
        private DevExpress.XtraGrid.Columns.GridColumn Province;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn Phone;
        private DevExpress.XtraGrid.Columns.GridColumn PhotoPath;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn Update;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit gridImage;

        private FlowLayoutPanel flpPhotos;
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
            this.Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhotoPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.position = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grandOpeningDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Update = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.txtfrandtype = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dtpOpening = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtposition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutletCode = new DevExpress.XtraEditors.TextEdit();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbFranchise = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblOutletCode = new DevExpress.XtraEditors.LabelControl();
            this.lblProvince = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblManager = new DevExpress.XtraEditors.LabelControl();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtManager = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtvatNumber = new DevExpress.XtraEditors.TextEdit();
            this.btnaddCategory = new System.Windows.Forms.Button();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtfrandtype.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtposition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvatNumber.Properties)).BeginInit();
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
            this.gridControlOutlet.Location = new System.Drawing.Point(2, 2);
            this.gridControlOutlet.MainView = this.gridViewOutlet;
            this.gridControlOutlet.Name = "gridControlOutlet";
            this.gridControlOutlet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemButtonEdit3});
            this.gridControlOutlet.Size = new System.Drawing.Size(1417, 292);
            this.gridControlOutlet.TabIndex = 0;
            this.gridControlOutlet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOutlet,
            this.gridView1});
            // 
            // gridViewOutlet
            // 
            this.gridViewOutlet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OutletCode,
            this.OutletName,
            this.typeName,
            this.Province,
            this.Phone,
            this.gridColumn6,
            this.ProductImage,
            this.PhotoPath,
            this.position,
            this.grandOpeningDate,
            this.Update,
            this.Delete,
            this.gridColumn1});
            this.gridViewOutlet.GridControl = this.gridControlOutlet;
            this.gridViewOutlet.Name = "gridViewOutlet";
            this.gridViewOutlet.OptionsBehavior.Editable = false;
            this.gridViewOutlet.OptionsView.ShowGroupPanel = false;
            this.gridViewOutlet.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewOutlet_RowCellStyle);
            this.gridViewOutlet.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridViewOutlet_MasterRowExpanded);
            this.gridViewOutlet.MasterRowGetLevelDefaultView += new DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventHandler(this.gridViewOutlet_MasterRowGetLevelDefaultView);
            this.gridViewOutlet.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridViewOutlet_MasterRowGetChildList);
            // 
            // OutletCode
            // 
            this.OutletCode.Caption = "OutletCode";
            this.OutletCode.FieldName = "OutletCode";
            this.OutletCode.Name = "OutletCode";
            this.OutletCode.Visible = true;
            this.OutletCode.VisibleIndex = 0;
            // 
            // OutletName
            // 
            this.OutletName.Caption = "OutletName";
            this.OutletName.FieldName = "OutletName";
            this.OutletName.Name = "OutletName";
            this.OutletName.Visible = true;
            this.OutletName.VisibleIndex = 1;
            // 
            // typeName
            // 
            this.typeName.Caption = "Franchise type";
            this.typeName.FieldName = "typeName";
            this.typeName.Name = "typeName";
            this.typeName.Visible = true;
            this.typeName.VisibleIndex = 2;
            // 
            // Province
            // 
            this.Province.Caption = "Province/City";
            this.Province.FieldName = "Province";
            this.Province.Name = "Province";
            this.Province.Visible = true;
            this.Province.VisibleIndex = 3;
            // 
            // Phone
            // 
            this.Phone.Caption = "Phone";
            this.Phone.FieldName = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.Visible = true;
            this.Phone.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Manager";
            this.gridColumn6.FieldName = "Manager";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // ProductImage
            // 
            this.ProductImage.Caption = "ProductImage";
            this.ProductImage.FieldName = "ProductImage";
            this.ProductImage.Name = "ProductImage";
            // 
            // PhotoPath
            // 
            this.PhotoPath.Caption = "Main Photo";
            this.PhotoPath.FieldName = "PhotoPath";
            this.PhotoPath.Name = "PhotoPath";
            // 
            // position
            // 
            this.position.Caption = "position";
            this.position.FieldName = "position";
            this.position.Name = "position";
            this.position.Visible = true;
            this.position.VisibleIndex = 6;
            // 
            // grandOpeningDate
            // 
            this.grandOpeningDate.Caption = "grandOpeningDate";
            this.grandOpeningDate.FieldName = "grandOpeningDate";
            this.grandOpeningDate.Name = "grandOpeningDate";
            this.grandOpeningDate.Visible = true;
            this.grandOpeningDate.VisibleIndex = 7;
            // 
            // Update
            // 
            this.Update.Caption = "Action";
            this.Update.ColumnEdit = this.repositoryItemButtonEdit1;
            this.Update.Name = "Update";
            this.Update.Visible = true;
            this.Update.VisibleIndex = 8;
            this.Update.Width = 40;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnUpdate_ButtonClick);
            // 
            // Delete
            // 
            this.Delete.Caption = " ";
            this.Delete.ColumnEdit = this.repositoryItemButtonEdit2;
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 9;
            this.Delete.Width = 40;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Deleted16;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainDelete_ButtonClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Details";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit3;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
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
            this.panelDetail.Controls.Add(this.txtfrandtype);
            this.panelDetail.Controls.Add(this.labelControl5);
            this.panelDetail.Controls.Add(this.dtpOpening);
            this.panelDetail.Controls.Add(this.panel1);
            this.panelDetail.Controls.Add(this.labelControl4);
            this.panelDetail.Controls.Add(this.checkEdit1);
            this.panelDetail.Controls.Add(this.labelControl3);
            this.panelDetail.Controls.Add(this.txtposition);
            this.panelDetail.Controls.Add(this.labelControl2);
            this.panelDetail.Controls.Add(this.txtOutletCode);
            this.panelDetail.Controls.Add(this.button2);
            this.panelDetail.Controls.Add(this.cmbFranchise);
            this.panelDetail.Controls.Add(this.button1);
            this.panelDetail.Controls.Add(this.cboBrand);
            this.panelDetail.Controls.Add(this.lblOutletCode);
            this.panelDetail.Controls.Add(this.lblProvince);
            this.panelDetail.Controls.Add(this.lblPhone);
            this.panelDetail.Controls.Add(this.lblManager);
            this.panelDetail.Controls.Add(this.lblAddress);
            this.panelDetail.Controls.Add(this.lblEmail);
            this.panelDetail.Controls.Add(this.txtPhone);
            this.panelDetail.Controls.Add(this.txtManager);
            this.panelDetail.Controls.Add(this.txtEmail);
            this.panelDetail.Controls.Add(this.txtAddress);
            this.panelDetail.Controls.Add(this.chkActive);
            this.panelDetail.Controls.Add(this.btnAdd);
            this.panelDetail.Controls.Add(this.btnCancel);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(0, 90);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1421, 209);
            this.panelDetail.TabIndex = 2;
            // 
            // txtfrandtype
            // 
            this.txtfrandtype.Enabled = false;
            this.txtfrandtype.Location = new System.Drawing.Point(291, 76);
            this.txtfrandtype.Name = "txtfrandtype";
            this.txtfrandtype.Size = new System.Drawing.Size(119, 20);
            this.txtfrandtype.TabIndex = 182;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(191, 79);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(77, 13);
            this.labelControl5.TabIndex = 181;
            this.labelControl5.Text = "Franchise Type:";
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
            // dtpOpening
            // 
            this.dtpOpening.CustomFormat = "dd-MM-yyyy";
            this.dtpOpening.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOpening.Location = new System.Drawing.Point(552, 169);
            this.dtpOpening.Name = "dtpOpening";
            this.dtpOpening.Size = new System.Drawing.Size(299, 21);
            this.dtpOpening.TabIndex = 179;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpPhotos);
            this.panel1.Controls.Add(this.btnAddPhoto);
            this.panel1.Location = new System.Drawing.Point(870, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 148);
            this.panel1.TabIndex = 178;
            // 
            // flpPhotos
            // 
            this.flpPhotos.AutoScroll = true;
            this.flpPhotos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPhotos.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpPhotos.Location = new System.Drawing.Point(0, 0);
            this.flpPhotos.Name = "flpPhotos";
            this.flpPhotos.Size = new System.Drawing.Size(400, 131);
            this.flpPhotos.TabIndex = 144;
            this.flpPhotos.Paint += new System.Windows.Forms.PaintEventHandler(this.flpPhotos_Paint);
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddPhoto.Location = new System.Drawing.Point(0, 129);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(400, 19);
            this.btnAddPhoto.TabIndex = 145;
            this.btnAddPhoto.Text = "Add Photo\r\n\r\n";
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(430, 175);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(105, 13);
            this.labelControl4.TabIndex = 176;
            this.labelControl4.Text = "Grand Opening Date :";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(210, 7);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "DiActive";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 175;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 175);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 173;
            this.labelControl3.Text = "Position";
            // 
            // txtposition
            // 
            this.txtposition.Location = new System.Drawing.Point(120, 172);
            this.txtposition.Name = "txtposition";
            this.txtposition.Size = new System.Drawing.Size(290, 20);
            this.txtposition.TabIndex = 174;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 172;
            this.labelControl2.Text = "Outlet Name:";
            // 
            // txtOutletCode
            // 
            this.txtOutletCode.Enabled = false;
            this.txtOutletCode.Location = new System.Drawing.Point(120, 76);
            this.txtOutletCode.Name = "txtOutletCode";
            this.txtOutletCode.Size = new System.Drawing.Size(47, 20);
            this.txtOutletCode.TabIndex = 171;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button2.Location = new System.Drawing.Point(383, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 26);
            this.button2.TabIndex = 170;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbFranchise
            // 
            this.cmbFranchise.Location = new System.Drawing.Point(120, 47);
            this.cmbFranchise.Name = "cmbFranchise";
            this.cmbFranchise.Size = new System.Drawing.Size(247, 21);
            this.cmbFranchise.TabIndex = 169;
            this.cmbFranchise.SelectedIndexChanged += new System.EventHandler(this.cmbFranchise_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button1.Location = new System.Drawing.Point(824, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 26);
            this.button1.TabIndex = 168;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboBrand
            // 
            this.cboBrand.Location = new System.Drawing.Point(552, 97);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(266, 21);
            this.cboBrand.TabIndex = 0;
            // 
            // lblOutletCode
            // 
            this.lblOutletCode.Location = new System.Drawing.Point(20, 79);
            this.lblOutletCode.Name = "lblOutletCode";
            this.lblOutletCode.Size = new System.Drawing.Size(62, 13);
            this.lblOutletCode.TabIndex = 4;
            this.lblOutletCode.Text = "Outlet Code:";
            // 
            // lblProvince
            // 
            this.lblProvince.Location = new System.Drawing.Point(467, 100);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(68, 13);
            this.lblProvince.TabIndex = 6;
            this.lblProvince.Text = "Province/City:";
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(20, 106);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(34, 13);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Phone:";
            // 
            // lblManager
            // 
            this.lblManager.Location = new System.Drawing.Point(20, 141);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(72, 13);
            this.lblManager.TabIndex = 8;
            this.lblManager.Text = "Cantact Name:";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(471, 11);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 13);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(507, 135);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(28, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 103);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(290, 20);
            this.txtPhone.TabIndex = 13;
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(120, 138);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(290, 20);
            this.txtManager.TabIndex = 14;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(552, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(299, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(552, 9);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(299, 72);
            this.txtAddress.TabIndex = 16;
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(120, 7);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(75, 19);
            this.chkActive.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(870, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 35);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Save (F5)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnCancel.Location = new System.Drawing.Point(967, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 35);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(729, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 175;
            this.labelControl1.Text = "VAT Number:";
            this.labelControl1.Visible = false;
            // 
            // txtvatNumber
            // 
            this.txtvatNumber.Location = new System.Drawing.Point(830, 39);
            this.txtvatNumber.Name = "txtvatNumber";
            this.txtvatNumber.Size = new System.Drawing.Size(290, 20);
            this.txtvatNumber.TabIndex = 176;
            this.txtvatNumber.Visible = false;
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
            this.panelGrid.Location = new System.Drawing.Point(0, 299);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1421, 296);
            this.panelGrid.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelControl1);
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Controls.Add(this.simpleButton1);
            this.panelHeader.Controls.Add(this.txtvatNumber);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.chkHeadOffice);
            this.panelHeader.Controls.Add(this.btnaddCategory);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1421, 90);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(5, 6);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(89, 78);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 2;
            this.PicSectionIcon.TabStop = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(100, 42);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // chkHeadOffice
            // 
            this.chkHeadOffice.Location = new System.Drawing.Point(1196, 30);
            this.chkHeadOffice.Name = "chkHeadOffice";
            this.chkHeadOffice.Properties.Caption = "Head Office";
            this.chkHeadOffice.Size = new System.Drawing.Size(75, 19);
            this.chkHeadOffice.TabIndex = 1;
            this.chkHeadOffice.Visible = false;
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
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(1339, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(1239, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblCountRow
            // 
            this.lblCountRow.Location = new System.Drawing.Point(10, 12);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(74, 13);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Total Record: 0";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 595);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1421, 40);
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
            this.ClientSize = new System.Drawing.Size(1421, 635);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiOutlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create OutLet";
            this.Load += new System.EventHandler(this.guiOutlet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtfrandtype.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtposition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutletCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvatNumber.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private Button button1;
        private System.Windows.Forms.ComboBox cmbFranchise;
        private Button button2;
        private LabelControl labelControl2;
        private TextEdit txtOutletCode;
        private LabelControl labelControl3;
        private TextEdit txtposition;
        private LabelControl labelControl1;
        private TextEdit txtvatNumber;
        private GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DetailImage;
        private DevExpress.XtraGrid.Columns.GridColumn Url;
        private CheckEdit checkEdit1;
        private LabelControl labelControl4;
        private Panel panel1;
        private DateTimePicker dtpOpening;
        private DevExpress.XtraGrid.Columns.GridColumn position;
        private DevExpress.XtraGrid.Columns.GridColumn grandOpeningDate;
        private SimpleButton simpleButton1;
        private PictureBox PicSectionIcon;
        private LabelControl lblSystemName;
        private TextEdit txtfrandtype;
        private LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn typeName;
    }
}