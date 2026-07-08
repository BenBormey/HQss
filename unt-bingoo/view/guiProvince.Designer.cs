using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace unt_bingoo.view
{
    partial class guiProvince
    {
        private System.ComponentModel.IContainer components = null;

        // បញ្ជីសមាសភាគ (Components)
        private PanelControl panelHeader;

        private PanelControl panelDetail;
        private LabelControl lblProvinceId;
        private LabelControl lblProvinceKH;
        private LabelControl lblProvinceEN;
        private LabelControl lblCode;

        private TextEdit txtProvinceId;
        private TextEdit txtProvinceKH;
        private TextEdit txtProvinceEN;
        private TextEdit txtCode;

        private SimpleButton btnAdd;
        private SimpleButton btnCancel;

        private PanelControl panelGrid;
        private GridControl gridControlProvince;
        private GridView gridViewProvince;

        private PanelControl panelBottom;
        private LabelControl lblCountRow;
        private SimpleButton btnExport;
        private SimpleButton btnClose;

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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblBreadcrumb = new DevExpress.XtraEditors.LabelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridControlProvince = new DevExpress.XtraGrid.GridControl();
            this.gridViewProvince = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.provinceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.provinceNameKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.provinceNameEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelListHeader = new System.Windows.Forms.Panel();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.spacerMid = new System.Windows.Forms.Panel();
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.panelFields = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblProvinceId = new DevExpress.XtraEditors.LabelControl();
            this.txtProvinceId = new DevExpress.XtraEditors.TextEdit();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.lblProvinceKH = new DevExpress.XtraEditors.LabelControl();
            this.txtProvinceKH = new DevExpress.XtraEditors.TextEdit();
            this.lblProvinceEN = new DevExpress.XtraEditors.LabelControl();
            this.txtProvinceEN = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblFormTitle = new DevExpress.XtraEditors.LabelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.panelListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.panelFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.White;
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblBreadcrumb);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.btnAdd);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 80);
            this.panelHeader.TabIndex = 3;
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(22, 14);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(52, 52);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 4;
            this.PicSectionIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(88, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Province Management";
            // 
            // lblBreadcrumb
            // 
            this.lblBreadcrumb.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBreadcrumb.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBreadcrumb.Appearance.Options.UseFont = true;
            this.lblBreadcrumb.Appearance.Options.UseForeColor = true;
            this.lblBreadcrumb.Location = new System.Drawing.Point(90, 48);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(181, 15);
            this.lblBreadcrumb.TabIndex = 1;
            this.lblBreadcrumb.Text = "Home    ›    Province Management";
            // 
            // lblSystemName
            // 
            this.lblSystemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(706, 28);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(233, 22);
            this.lblSystemName.TabIndex = 3;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(492, -15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAdd.Size = new System.Drawing.Size(110, 36);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Save";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelBody.Controls.Add(this.panelGrid);
            this.panelBody.Controls.Add(this.spacerMid);
            this.panelBody.Controls.Add(this.panelDetail);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 80);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(24, 16, 24, 12);
            this.panelBody.Size = new System.Drawing.Size(1000, 526);
            this.panelBody.TabIndex = 5;
            // 
            // panelGrid
            // 
            this.panelGrid.Appearance.BackColor = System.Drawing.Color.White;
            this.panelGrid.Appearance.Options.UseBackColor = true;
            this.panelGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelGrid.Controls.Add(this.gridControlProvince);
            this.panelGrid.Controls.Add(this.panelListHeader);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(24, 250);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelGrid.Size = new System.Drawing.Size(952, 264);
            this.panelGrid.TabIndex = 0;
            // 
            // gridControlProvince
            // 
            this.gridControlProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProvince.Location = new System.Drawing.Point(20, 48);
            this.gridControlProvince.MainView = this.gridViewProvince;
            this.gridControlProvince.Name = "gridControlProvince";
            this.gridControlProvince.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gridControlProvince.Size = new System.Drawing.Size(912, 198);
            this.gridControlProvince.TabIndex = 0;
            this.gridControlProvince.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProvince});
            // 
            // gridViewProvince
            // 
            this.gridViewProvince.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.gridViewProvince.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewProvince.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.gridViewProvince.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gridViewProvince.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewProvince.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewProvince.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.gridViewProvince.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gridViewProvince.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.gridViewProvince.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewProvince.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewProvince.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewProvince.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridViewProvince.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gridViewProvince.Appearance.Row.Options.UseFont = true;
            this.gridViewProvince.Appearance.Row.Options.UseForeColor = true;
            this.gridViewProvince.ColumnPanelRowHeight = 36;
            this.gridViewProvince.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.provinceId,
            this.provinceNameKH,
            this.provinceNameEN,
            this.code,
            this.gridColumn1,
            this.gridColumn2});
            this.gridViewProvince.GridControl = this.gridControlProvince;
            this.gridViewProvince.Name = "gridViewProvince";
            this.gridViewProvince.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewProvince.OptionsView.ShowGroupPanel = false;
            this.gridViewProvince.OptionsView.ShowIndicator = false;
            this.gridViewProvince.RowHeight = 40;
            // 
            // provinceId
            // 
            this.provinceId.Caption = "Province ID";
            this.provinceId.FieldName = "provinceId";
            this.provinceId.Name = "provinceId";
            // 
            // provinceNameKH
            // 
            this.provinceNameKH.Caption = "Name (KH)";
            this.provinceNameKH.FieldName = "provinceNameKH";
            this.provinceNameKH.Name = "provinceNameKH";
            this.provinceNameKH.Visible = true;
            this.provinceNameKH.VisibleIndex = 0;
            // 
            // provinceNameEN
            // 
            this.provinceNameEN.Caption = "Name (EN)";
            this.provinceNameEN.FieldName = "provinceNameEN";
            this.provinceNameEN.Name = "provinceNameEN";
            this.provinceNameEN.Visible = true;
            this.provinceNameEN.VisibleIndex = 1;
            // 
            // code
            // 
            this.code.Caption = "Code";
            this.code.FieldName = "code";
            this.code.Name = "code";
            this.code.Visible = true;
            this.code.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Edit";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.FieldName = "Edit";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 25;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Delete";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumn2.FieldName = "Delete";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 25;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
            // 
            // panelListHeader
            // 
            this.panelListHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelListHeader.Controls.Add(this.txtSearch);
            this.panelListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListHeader.Location = new System.Drawing.Point(20, 18);
            this.panelListHeader.Name = "panelListHeader";
            this.panelListHeader.Size = new System.Drawing.Size(912, 30);
            this.panelListHeader.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.NullValuePrompt = "Search province...";
            this.txtSearch.Size = new System.Drawing.Size(330, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // spacerMid
            // 
            this.spacerMid.BackColor = System.Drawing.Color.Transparent;
            this.spacerMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacerMid.Location = new System.Drawing.Point(24, 240);
            this.spacerMid.Name = "spacerMid";
            this.spacerMid.Size = new System.Drawing.Size(952, 10);
            this.spacerMid.TabIndex = 2;
            // 
            // panelDetail
            // 
            this.panelDetail.Appearance.BackColor = System.Drawing.Color.White;
            this.panelDetail.Appearance.Options.UseBackColor = true;
            this.panelDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelDetail.Controls.Add(this.Panel3);
            this.panelDetail.Controls.Add(this.lblFormTitle);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(24, 16);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Padding = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.panelDetail.Size = new System.Drawing.Size(952, 224);
            this.panelDetail.TabIndex = 2;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.panelFields);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(24, 51);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.Panel3.Size = new System.Drawing.Size(904, 155);
            this.Panel3.TabIndex = 110;
            // 
            // panelFields
            // 
            this.panelFields.BackColor = System.Drawing.Color.Transparent;
            this.panelFields.Controls.Add(this.simpleButton1);
            this.panelFields.Controls.Add(this.lblProvinceId);
            this.panelFields.Controls.Add(this.txtProvinceId);
            this.panelFields.Controls.Add(this.lblCode);
            this.panelFields.Controls.Add(this.txtCode);
            this.panelFields.Controls.Add(this.lblProvinceKH);
            this.panelFields.Controls.Add(this.txtProvinceKH);
            this.panelFields.Controls.Add(this.lblProvinceEN);
            this.panelFields.Controls.Add(this.txtProvinceEN);
            this.panelFields.Controls.Add(this.btnCancel);
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(0, 8);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(904, 147);
            this.panelFields.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.simpleButton1.Location = new System.Drawing.Point(558, 106);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(100, 36);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "Add";
            this.simpleButton1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblProvinceId
            // 
            this.lblProvinceId.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvinceId.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblProvinceId.Appearance.Options.UseFont = true;
            this.lblProvinceId.Appearance.Options.UseForeColor = true;
            this.lblProvinceId.Location = new System.Drawing.Point(0, 0);
            this.lblProvinceId.Name = "lblProvinceId";
            this.lblProvinceId.Size = new System.Drawing.Size(62, 15);
            this.lblProvinceId.TabIndex = 0;
            this.lblProvinceId.Text = "Province ID";
            // 
            // txtProvinceId
            // 
            this.txtProvinceId.Location = new System.Drawing.Point(0, 20);
            this.txtProvinceId.Name = "txtProvinceId";
            this.txtProvinceId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProvinceId.Properties.Appearance.Options.UseFont = true;
            this.txtProvinceId.Properties.NullValuePrompt = "Auto-generated";
            this.txtProvinceId.Properties.ReadOnly = true;
            this.txtProvinceId.Size = new System.Drawing.Size(316, 24);
            this.txtProvinceId.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCode.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Appearance.Options.UseForeColor = true;
            this.lblCode.Location = new System.Drawing.Point(342, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(76, 15);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "Province Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(342, 20);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.NullValuePrompt = "Enter province code";
            this.txtCode.Size = new System.Drawing.Size(316, 24);
            this.txtCode.TabIndex = 7;
            // 
            // lblProvinceKH
            // 
            this.lblProvinceKH.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvinceKH.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblProvinceKH.Appearance.Options.UseFont = true;
            this.lblProvinceKH.Appearance.Options.UseForeColor = true;
            this.lblProvinceKH.Location = new System.Drawing.Point(0, 56);
            this.lblProvinceKH.Name = "lblProvinceKH";
            this.lblProvinceKH.Size = new System.Drawing.Size(59, 15);
            this.lblProvinceKH.TabIndex = 2;
            this.lblProvinceKH.Text = "Name (KH)";
            // 
            // txtProvinceKH
            // 
            this.txtProvinceKH.Location = new System.Drawing.Point(0, 76);
            this.txtProvinceKH.Name = "txtProvinceKH";
            this.txtProvinceKH.Properties.Appearance.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F);
            this.txtProvinceKH.Properties.Appearance.Options.UseFont = true;
            this.txtProvinceKH.Properties.NullValuePrompt = "បញ្ចូលឈ្មោះខេត្ត (ខ្មែរ)";
            this.txtProvinceKH.Size = new System.Drawing.Size(316, 30);
            this.txtProvinceKH.TabIndex = 3;
            // 
            // lblProvinceEN
            // 
            this.lblProvinceEN.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvinceEN.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblProvinceEN.Appearance.Options.UseFont = true;
            this.lblProvinceEN.Appearance.Options.UseForeColor = true;
            this.lblProvinceEN.Location = new System.Drawing.Point(342, 56);
            this.lblProvinceEN.Name = "lblProvinceEN";
            this.lblProvinceEN.Size = new System.Drawing.Size(58, 15);
            this.lblProvinceEN.TabIndex = 4;
            this.lblProvinceEN.Text = "Name (EN)";
            // 
            // txtProvinceEN
            // 
            this.txtProvinceEN.Location = new System.Drawing.Point(342, 76);
            this.txtProvinceEN.Name = "txtProvinceEN";
            this.txtProvinceEN.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProvinceEN.Properties.Appearance.Options.UseFont = true;
            this.txtProvinceEN.Properties.NullValuePrompt = "Enter province name (EN)";
            this.txtProvinceEN.Size = new System.Drawing.Size(316, 24);
            this.txtProvinceEN.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(459, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblFormTitle.Appearance.Options.UseFont = true;
            this.lblFormTitle.Appearance.Options.UseForeColor = true;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormTitle.Location = new System.Drawing.Point(24, 18);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.lblFormTitle.Size = new System.Drawing.Size(154, 33);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Province Information";
            // 
            // panelBottom
            // 
            this.panelBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.panelBottom.Appearance.Options.UseBackColor = true;
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 606);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(24, 8, 16, 8);
            this.panelBottom.Size = new System.Drawing.Size(1000, 54);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCountRow
            // 
            this.lblCountRow.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCountRow.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblCountRow.Appearance.Options.UseFont = true;
            this.lblCountRow.Appearance.Options.UseForeColor = true;
            this.lblCountRow.Location = new System.Drawing.Point(24, 19);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(77, 17);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Count Row: 0";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(784, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExport.Size = new System.Drawing.Size(110, 38);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(894, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guiProvince
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 660);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Name = "guiProvince";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Province Management";
            this.Load += new System.EventHandler(this.guiProvince_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.panelListHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.panelFields.ResumeLayout(false);
            this.panelFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraGrid.Columns.GridColumn provinceId;
        private DevExpress.XtraGrid.Columns.GridColumn provinceNameKH;
        private DevExpress.XtraGrid.Columns.GridColumn provinceNameEN;
        private DevExpress.XtraGrid.Columns.GridColumn code;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private LabelControl lblSystemName;

        // --- New controls added for the redesigned layout ---
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel spacerMid;
        private System.Windows.Forms.Panel panelFields;
        private System.Windows.Forms.Panel Panel3;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblBreadcrumb;
        private DevExpress.XtraEditors.LabelControl lblFormTitle;
        private System.Windows.Forms.Panel panelListHeader;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private SimpleButton simpleButton1;
    }
}