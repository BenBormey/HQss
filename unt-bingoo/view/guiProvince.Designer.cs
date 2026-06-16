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
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblProvinceId = new DevExpress.XtraEditors.LabelControl();
            this.txtProvinceId = new DevExpress.XtraEditors.TextEdit();
            this.lblProvinceKH = new DevExpress.XtraEditors.LabelControl();
            this.txtProvinceKH = new DevExpress.XtraEditors.TextEdit();
            this.lblProvinceEN = new DevExpress.XtraEditors.LabelControl();
            this.txtProvinceEN = new DevExpress.XtraEditors.TextEdit();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridControlProvince = new DevExpress.XtraGrid.GridControl();
            this.gridViewProvince = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.provinceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.provinceNameKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.provinceNameEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 91);
            this.panelHeader.TabIndex = 3;
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.lblProvinceId);
            this.panelDetail.Controls.Add(this.txtProvinceId);
            this.panelDetail.Controls.Add(this.lblProvinceKH);
            this.panelDetail.Controls.Add(this.txtProvinceKH);
            this.panelDetail.Controls.Add(this.lblProvinceEN);
            this.panelDetail.Controls.Add(this.txtProvinceEN);
            this.panelDetail.Controls.Add(this.lblCode);
            this.panelDetail.Controls.Add(this.txtCode);
            this.panelDetail.Controls.Add(this.btnAdd);
            this.panelDetail.Controls.Add(this.btnCancel);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(0, 91);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1000, 160);
            this.panelDetail.TabIndex = 2;
            this.panelDetail.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProvinceId
            // 
            this.lblProvinceId.Location = new System.Drawing.Point(30, 30);
            this.lblProvinceId.Name = "lblProvinceId";
            this.lblProvinceId.Size = new System.Drawing.Size(59, 13);
            this.lblProvinceId.TabIndex = 0;
            this.lblProvinceId.Text = "Province ID:";
            // 
            // txtProvinceId
            // 
            this.txtProvinceId.Location = new System.Drawing.Point(150, 27);
            this.txtProvinceId.Name = "txtProvinceId";
            this.txtProvinceId.Properties.ReadOnly = true;
            this.txtProvinceId.Size = new System.Drawing.Size(250, 20);
            this.txtProvinceId.TabIndex = 1;
            // 
            // lblProvinceKH
            // 
            this.lblProvinceKH.Location = new System.Drawing.Point(30, 65);
            this.lblProvinceKH.Name = "lblProvinceKH";
            this.lblProvinceKH.Size = new System.Drawing.Size(55, 13);
            this.lblProvinceKH.TabIndex = 2;
            this.lblProvinceKH.Text = "Name (KH):";
            // 
            // txtProvinceKH
            // 
            this.txtProvinceKH.Location = new System.Drawing.Point(150, 62);
            this.txtProvinceKH.Name = "txtProvinceKH";
            this.txtProvinceKH.Size = new System.Drawing.Size(250, 20);
            this.txtProvinceKH.TabIndex = 3;
            // 
            // lblProvinceEN
            // 
            this.lblProvinceEN.Location = new System.Drawing.Point(30, 100);
            this.lblProvinceEN.Name = "lblProvinceEN";
            this.lblProvinceEN.Size = new System.Drawing.Size(55, 13);
            this.lblProvinceEN.TabIndex = 4;
            this.lblProvinceEN.Text = "Name (EN):";
            // 
            // txtProvinceEN
            // 
            this.txtProvinceEN.Location = new System.Drawing.Point(150, 97);
            this.txtProvinceEN.Name = "txtProvinceEN";
            this.txtProvinceEN.Size = new System.Drawing.Size(250, 20);
            this.txtProvinceEN.TabIndex = 5;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(450, 30);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(73, 13);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "Province Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(550, 27);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(200, 20);
            this.txtCode.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(550, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(650, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridControlProvince);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 251);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1000, 309);
            this.panelGrid.TabIndex = 0;
            // 
            // gridControlProvince
            // 
            this.gridControlProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProvince.Location = new System.Drawing.Point(2, 2);
            this.gridControlProvince.MainView = this.gridViewProvince;
            this.gridControlProvince.Name = "gridControlProvince";
            this.gridControlProvince.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gridControlProvince.Size = new System.Drawing.Size(996, 305);
            this.gridControlProvince.TabIndex = 0;
            this.gridControlProvince.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProvince});
            // 
            // gridViewProvince
            // 
            this.gridViewProvince.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.provinceId,
            this.provinceNameKH,
            this.provinceNameEN,
            this.code,
            this.gridColumn1,
            this.gridColumn2});
            this.gridViewProvince.GridControl = this.gridControlProvince;
            this.gridViewProvince.Name = "gridViewProvince";
            this.gridViewProvince.OptionsView.ShowGroupPanel = false;
            // 
            // provinceId
            // 
            this.provinceId.Caption = "provinceId";
            this.provinceId.FieldName = "provinceId";
            this.provinceId.Name = "provinceId";
            // 
            // provinceNameKH
            // 
            this.provinceNameKH.Caption = "provinceNameKH";
            this.provinceNameKH.FieldName = "provinceNameKH";
            this.provinceNameKH.Name = "provinceNameKH";
            this.provinceNameKH.Visible = true;
            this.provinceNameKH.VisibleIndex = 0;
            // 
            // provinceNameEN
            // 
            this.provinceNameEN.Caption = "provinceNameEN";
            this.provinceNameEN.FieldName = "provinceNameEN";
            this.provinceNameEN.Name = "provinceNameEN";
            this.provinceNameEN.Visible = true;
            this.provinceNameEN.VisibleIndex = 1;
            // 
            // code
            // 
            this.code.Caption = "code";
            this.code.FieldName = "code";
            this.code.Name = "code";
            this.code.Visible = true;
            this.code.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 560);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 40);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCountRow
            // 
            this.lblCountRow.Location = new System.Drawing.Point(15, 12);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(66, 13);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Count Row: 0";
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Excel;
            this.btnExport.Location = new System.Drawing.Point(798, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(898, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(3, 2);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(89, 78);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 4;
            this.PicSectionIcon.TabStop = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(98, 38);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 3;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // guiProvince
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiProvince";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Province Management";
            this.Load += new System.EventHandler(this.guiProvince_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
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
    }
}