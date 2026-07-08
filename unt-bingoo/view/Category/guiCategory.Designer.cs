using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace unt_bingoo.view.Category
{
    partial class guiCategory
    {
        private System.ComponentModel.IContainer components = null;

        private PanelControl panelHeader;
        private PanelControl panelForm;
        private PanelControl panelGrid;
        private GridControl gridCategory;
        private GridView gvCategory;

        private PanelControl panelBottom;
        private LabelControl lblCount;
        private SimpleButton btnExport;
        private SimpleButton btnClose;

        /// <summary>
        /// Required method for Designer support
        /// </summary>
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCategory = new DevExpress.XtraGrid.GridControl();
            this.gvCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.khmerCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainupdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelListHeader = new System.Windows.Forms.Panel();
            this.lblListTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.spacerMid = new System.Windows.Forms.Panel();
            this.panelForm = new DevExpress.XtraEditors.PanelControl();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.panelFields = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.TxtKhmerName = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.lblFormTitle = new DevExpress.XtraEditors.LabelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainupdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).BeginInit();
            this.panelListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForm)).BeginInit();
            this.panelForm.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.panelFields.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel8.SuspendLayout();
            this.Panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.White;
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.panelControl1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(992, 76);
            this.panelHeader.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.PicSectionIcon);
            this.panelControl1.Controls.Add(this.BtnUpdate);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(992, 76);
            this.panelControl1.TabIndex = 4;
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(22, 12);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(50, 50);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 4;
            this.PicSectionIcon.TabStop = false;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdate.BackColor = System.Drawing.Color.White;
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.BtnUpdate.ForeColor = System.Drawing.Color.Black;
            this.BtnUpdate.Location = new System.Drawing.Point(672, 12);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(110, 38);
            this.BtnUpdate.TabIndex = 7;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSystemName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 76);
            this.panel1.TabIndex = 8;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(78, 40);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(233, 22);
            this.lblSystemName.TabIndex = 3;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelBody.Controls.Add(this.panelGrid);
            this.panelBody.Controls.Add(this.spacerMid);
            this.panelBody.Controls.Add(this.panelForm);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 76);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(24, 16, 24, 12);
            this.panelBody.Size = new System.Drawing.Size(992, 630);
            this.panelBody.TabIndex = 5;
            // 
            // panelGrid
            // 
            this.panelGrid.Appearance.BackColor = System.Drawing.Color.White;
            this.panelGrid.Appearance.Options.UseBackColor = true;
            this.panelGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelGrid.Controls.Add(this.gridCategory);
            this.panelGrid.Controls.Add(this.panelListHeader);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(24, 314);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelGrid.Size = new System.Drawing.Size(944, 304);
            this.panelGrid.TabIndex = 0;
            // 
            // gridCategory
            // 
            this.gridCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCategory.Location = new System.Drawing.Point(20, 47);
            this.gridCategory.MainView = this.gvCategory;
            this.gridCategory.Name = "gridCategory";
            this.gridCategory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnMainDelete,
            this.btnMainupdate});
            this.gridCategory.Size = new System.Drawing.Size(904, 239);
            this.gridCategory.TabIndex = 0;
            this.gridCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCategory});
            // 
            // gvCategory
            // 
            this.gvCategory.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.gvCategory.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvCategory.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.gvCategory.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gvCategory.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvCategory.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvCategory.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.gvCategory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gvCategory.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.gvCategory.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvCategory.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvCategory.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvCategory.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gvCategory.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gvCategory.Appearance.Row.Options.UseFont = true;
            this.gvCategory.Appearance.Row.Options.UseForeColor = true;
            this.gvCategory.ColumnPanelRowHeight = 36;
            this.gvCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CategoryCode,
            this.CategoryName,
            this.Remark,
            this.Active,
            this.khmerCategoryName,
            this.Edit,
            this.Delete});
            this.gvCategory.DetailHeight = 325;
            this.gvCategory.GridControl = this.gridCategory;
            this.gvCategory.Name = "gvCategory";
            this.gvCategory.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCategory.OptionsView.ShowGroupPanel = false;
            this.gvCategory.OptionsView.ShowIndicator = false;
            this.gvCategory.RowHeight = 40;
            this.gvCategory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CategoryName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // CategoryCode
            // 
            this.CategoryCode.Caption = "Category Code";
            this.CategoryCode.FieldName = "CategoryCode";
            this.CategoryCode.MinWidth = 17;
            this.CategoryCode.Name = "CategoryCode";
            this.CategoryCode.OptionsColumn.ReadOnly = true;
            this.CategoryCode.Width = 50;
            // 
            // CategoryName
            // 
            this.CategoryName.Caption = "Category Name";
            this.CategoryName.FieldName = "CategoryName";
            this.CategoryName.MinWidth = 17;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.OptionsColumn.ReadOnly = true;
            this.CategoryName.Visible = true;
            this.CategoryName.VisibleIndex = 0;
            this.CategoryName.Width = 245;
            // 
            // Remark
            // 
            this.Remark.Caption = "Remark";
            this.Remark.FieldName = "Remark";
            this.Remark.MinWidth = 17;
            this.Remark.Name = "Remark";
            this.Remark.OptionsColumn.ReadOnly = true;
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 2;
            this.Remark.Width = 267;
            // 
            // Active
            // 
            this.Active.Caption = "Active";
            this.Active.FieldName = "Active";
            this.Active.MinWidth = 17;
            this.Active.Name = "Active";
            this.Active.OptionsColumn.ReadOnly = true;
            this.Active.Width = 40;
            // 
            // khmerCategoryName
            // 
            this.khmerCategoryName.Caption = "Khmer Name";
            this.khmerCategoryName.FieldName = "khmerCategoryName";
            this.khmerCategoryName.Name = "khmerCategoryName";
            this.khmerCategoryName.OptionsColumn.ReadOnly = true;
            this.khmerCategoryName.Visible = true;
            this.khmerCategoryName.VisibleIndex = 1;
            this.khmerCategoryName.Width = 337;
            // 
            // Edit
            // 
            this.Edit.Caption = "Edit";
            this.Edit.ColumnEdit = this.btnMainupdate;
            this.Edit.Name = "Edit";
            this.Edit.Visible = true;
            this.Edit.VisibleIndex = 3;
            this.Edit.Width = 22;
            // 
            // btnMainupdate
            // 
            this.btnMainupdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnMainupdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainupdate.Name = "btnMainupdate";
            this.btnMainupdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainupdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainupdate_ButtonClick);
            // 
            // Delete
            // 
            this.Delete.Caption = "Delete";
            this.Delete.ColumnEdit = this.btnMainDelete;
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 4;
            this.Delete.Width = 31;
            // 
            // btnMainDelete
            // 
            this.btnMainDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnMainDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainDelete.Name = "btnMainDelete";
            this.btnMainDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainDelete_ButtonClick);
            // 
            // panelListHeader
            // 
            this.panelListHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelListHeader.Controls.Add(this.lblListTitle);
            this.panelListHeader.Controls.Add(this.txtSearch);
            this.panelListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListHeader.Location = new System.Drawing.Point(20, 18);
            this.panelListHeader.Name = "panelListHeader";
            this.panelListHeader.Size = new System.Drawing.Size(904, 29);
            this.panelListHeader.TabIndex = 1;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblListTitle.Appearance.Options.UseFont = true;
            this.lblListTitle.Appearance.Options.UseForeColor = true;
            this.lblListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(96, 21);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Category List";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.NullValuePrompt = "Search category...";
            this.txtSearch.Size = new System.Drawing.Size(330, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Visible = false;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // spacerMid
            // 
            this.spacerMid.BackColor = System.Drawing.Color.Transparent;
            this.spacerMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacerMid.Location = new System.Drawing.Point(24, 298);
            this.spacerMid.Name = "spacerMid";
            this.spacerMid.Size = new System.Drawing.Size(944, 16);
            this.spacerMid.TabIndex = 2;
            // 
            // panelForm
            // 
            this.panelForm.Appearance.BackColor = System.Drawing.Color.White;
            this.panelForm.Appearance.Options.UseBackColor = true;
            this.panelForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelForm.Controls.Add(this.Panel3);
            this.panelForm.Controls.Add(this.lblFormTitle);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(24, 16);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.panelForm.Size = new System.Drawing.Size(944, 282);
            this.panelForm.TabIndex = 2;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.panelFields);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(24, 51);
            this.Panel3.Name = "Panel3";
            this.Panel3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.Panel3.Size = new System.Drawing.Size(896, 213);
            this.Panel3.TabIndex = 110;
            // 
            // panelFields
            // 
            this.panelFields.BackColor = System.Drawing.Color.Transparent;
            this.panelFields.Controls.Add(this.Panel2);
            this.panelFields.Controls.Add(this.Panel8);
            this.panelFields.Controls.Add(this.Panel5);
            this.panelFields.Controls.Add(this.btnClear);
            this.panelFields.Controls.Add(this.BtnCancel);
            this.panelFields.Controls.Add(this.BtnAdd);
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(0, 8);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(896, 205);
            this.panelFields.TabIndex = 0;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.txtName);
            this.Panel2.Controls.Add(this.Label2);
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(316, 56);
            this.Panel2.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(0, 22);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 30);
            this.txtName.TabIndex = 0;
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(316, 22);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Category Name ";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel8
            // 
            this.Panel8.BackColor = System.Drawing.Color.Transparent;
            this.Panel8.Controls.Add(this.TxtKhmerName);
            this.Panel8.Controls.Add(this.Label11);
            this.Panel8.Location = new System.Drawing.Point(334, 0);
            this.Panel8.Name = "Panel8";
            this.Panel8.Size = new System.Drawing.Size(316, 56);
            this.Panel8.TabIndex = 1;
            // 
            // TxtKhmerName
            // 
            this.TxtKhmerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtKhmerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtKhmerName.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKhmerName.Location = new System.Drawing.Point(0, 22);
            this.TxtKhmerName.MaxLength = 150;
            this.TxtKhmerName.Name = "TxtKhmerName";
            this.TxtKhmerName.Size = new System.Drawing.Size(316, 30);
            this.TxtKhmerName.TabIndex = 1;
            this.TxtKhmerName.Enter += new System.EventHandler(this.TxtKhmerName_Enter);
            this.TxtKhmerName.Leave += new System.EventHandler(this.TxtKhmerName_Leave);
            // 
            // Label11
            // 
            this.Label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.Label11.Location = new System.Drawing.Point(0, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(316, 22);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "Khmer Name";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel5
            // 
            this.Panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel5.BackColor = System.Drawing.Color.Transparent;
            this.Panel5.Controls.Add(this.txtRemark);
            this.Panel5.Controls.Add(this.Label3);
            this.Panel5.Location = new System.Drawing.Point(0, 68);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(896, 92);
            this.Panel5.TabIndex = 2;
            // 
            // txtRemark
            // 
            this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(0, 22);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(896, 70);
            this.txtRemark.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(896, 22);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Description";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnClear.Location = new System.Drawing.Point(674, 170);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 38);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "CanCel";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.BtnCancel.Location = new System.Drawing.Point(674, 170);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 38);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Visible = false;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.White;
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.BtnAdd.ForeColor = System.Drawing.Color.Black;
            this.BtnAdd.Location = new System.Drawing.Point(786, 170);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(110, 38);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.lblFormTitle.Size = new System.Drawing.Size(158, 33);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Category Information";
            // 
            // panelBottom
            // 
            this.panelBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.panelBottom.Appearance.Options.UseBackColor = true;
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Controls.Add(this.lblCount);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 706);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(24, 8, 16, 8);
            this.panelBottom.Size = new System.Drawing.Size(992, 54);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCount.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblCount.Appearance.Options.UseFont = true;
            this.lblCount.Appearance.Options.UseForeColor = true;
            this.lblCount.Location = new System.Drawing.Point(24, 19);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(52, 17);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count : 0";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(776, 8);
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
            this.btnClose.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnClose.Location = new System.Drawing.Point(886, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guiCategory
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 760);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(880, 660);
            this.Name = "guiCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATEGORY MANAGEMENT";
            this.Load += new System.EventHandler(this.guiCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainupdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).EndInit();
            this.panelListHeader.ResumeLayout(false);
            this.panelListHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForm)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.panelFields.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel8.ResumeLayout(false);
            this.Panel8.PerformLayout();
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraGrid.Columns.GridColumn CategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn CategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraGrid.Columns.GridColumn Active;
        private DevExpress.XtraGrid.Columns.GridColumn Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainupdate;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainDelete;
        private PanelControl panelControl1;
        internal Panel Panel3;
        internal Panel Panel8;
        internal TextBox TxtKhmerName;
        internal Label Label11;
        internal Panel Panel2;
        internal TextBox txtName;
        internal Label Label2;
        internal Panel Panel5;
        internal TextBox txtRemark;
        internal Label Label3;
        internal Button BtnAdd;
        internal Button BtnUpdate;
        internal Button BtnCancel;
        private PictureBox PicSectionIcon;
        private LabelControl lblSystemName;
        private DevExpress.XtraGrid.Columns.GridColumn khmerCategoryName;

        // --- New controls added for the redesigned layout ---
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel spacerMid;
        private System.Windows.Forms.Panel panelFields;
        private DevExpress.XtraEditors.LabelControl lblFormTitle;
        private DevExpress.XtraEditors.LabelControl lblListTitle;
        private System.Windows.Forms.Panel panelListHeader;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        internal Button btnClear;
        private Panel panel1;
    }
}