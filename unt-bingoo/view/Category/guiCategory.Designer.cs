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
        private LabelControl lblCode;
        private LabelControl lblName;
        private LabelControl lblRemark;

        private TextEdit txtCode;
        private TextEdit txtName;
        private MemoEdit txtRemark;
        private CheckEdit chkActive;

        private SimpleButton btnAdd;
        private SimpleButton btnCancel;

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
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.panelForm = new DevExpress.XtraEditors.PanelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCategory = new DevExpress.XtraGrid.GridControl();
            this.gvCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainupdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForm)).BeginInit();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainupdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelControl1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(729, 79);
            this.panelHeader.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.picLogo);
            this.panelControl1.Controls.Add(this.lblSystemName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(725, 80);
            this.panelControl1.TabIndex = 4;
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
            // panelForm
            // 
            this.panelForm.Controls.Add(this.lblCode);
            this.panelForm.Controls.Add(this.lblName);
            this.panelForm.Controls.Add(this.lblRemark);
            this.panelForm.Controls.Add(this.txtCode);
            this.panelForm.Controls.Add(this.txtName);
            this.panelForm.Controls.Add(this.txtRemark);
            this.panelForm.Controls.Add(this.chkActive);
            this.panelForm.Controls.Add(this.btnAdd);
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 79);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(729, 160);
            this.panelForm.TabIndex = 2;
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Location = new System.Drawing.Point(17, 19);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(85, 14);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Category Code:";
            // 
            // lblName
            // 
            this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Appearance.Options.UseFont = true;
            this.lblName.Location = new System.Drawing.Point(17, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 14);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Category Name:";
            // 
            // lblRemark
            // 
            this.lblRemark.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Appearance.Options.UseFont = true;
            this.lblRemark.Location = new System.Drawing.Point(17, 74);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(44, 14);
            this.lblRemark.TabIndex = 2;
            this.lblRemark.Text = "Remark:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(123, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(361, 20);
            this.txtCode.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(123, 44);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(387, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(123, 71);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Properties.Appearance.Options.UseFont = true;
            this.txtRemark.Size = new System.Drawing.Size(447, 37);
            this.txtRemark.TabIndex = 5;
            // 
            // chkActive
            // 
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(123, 114);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(64, 19);
            this.chkActive.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(388, 131);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(481, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridCategory);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 239);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(729, 216);
            this.panelGrid.TabIndex = 0;
            // 
            // gridCategory
            // 
            this.gridCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCategory.Location = new System.Drawing.Point(2, 2);
            this.gridCategory.MainView = this.gvCategory;
            this.gridCategory.Name = "gridCategory";
            this.gridCategory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnMainDelete,
            this.btnMainupdate});
            this.gridCategory.Size = new System.Drawing.Size(725, 212);
            this.gridCategory.TabIndex = 0;
            this.gridCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCategory});
            // 
            // gvCategory
            // 
            this.gvCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CategoryCode,
            this.CategoryName,
            this.Remark,
            this.Active,
            this.Edit,
            this.Delete});
            this.gvCategory.DetailHeight = 325;
            this.gvCategory.GridControl = this.gridCategory;
            this.gvCategory.Name = "gvCategory";
            this.gvCategory.OptionsView.ShowGroupPanel = false;
            // 
            // CategoryCode
            // 
            this.CategoryCode.Caption = "Category Code";
            this.CategoryCode.FieldName = "CategoryCode";
            this.CategoryCode.MinWidth = 17;
            this.CategoryCode.Name = "CategoryCode";
            this.CategoryCode.Visible = true;
            this.CategoryCode.VisibleIndex = 0;
            this.CategoryCode.Width = 64;
            // 
            // CategoryName
            // 
            this.CategoryName.Caption = "Category Name";
            this.CategoryName.FieldName = "CategoryName";
            this.CategoryName.MinWidth = 17;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Visible = true;
            this.CategoryName.VisibleIndex = 1;
            this.CategoryName.Width = 64;
            // 
            // Remark
            // 
            this.Remark.Caption = "Remark";
            this.Remark.FieldName = "Remark";
            this.Remark.MinWidth = 17;
            this.Remark.Name = "Remark";
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 2;
            this.Remark.Width = 64;
            // 
            // Active
            // 
            this.Active.Caption = "Active";
            this.Active.FieldName = "Active";
            this.Active.MinWidth = 17;
            this.Active.Name = "Active";
            this.Active.Visible = true;
            this.Active.VisibleIndex = 3;
            this.Active.Width = 64;
            // 
            // Edit
            // 
            this.Edit.Caption = "Edit";
            this.Edit.ColumnEdit = this.btnMainupdate;
            this.Edit.Name = "Edit";
            this.Edit.Visible = true;
            this.Edit.VisibleIndex = 4;
            // 
            // btnMainupdate
            // 
            this.btnMainupdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.update_blue;
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
            this.Delete.VisibleIndex = 5;
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
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCount);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 455);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(729, 37);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(9, 11);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(45, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count : 0";
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(566, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(83, 33);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnClose.Location = new System.Drawing.Point(649, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            // 
            // guiCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 492);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATEGORY MANAGEMENT";
            this.Load += new System.EventHandler(this.guiCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForm)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainupdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).EndInit();
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
        private PictureEdit picLogo;
        private LabelControl lblSystemName;
    }
}
