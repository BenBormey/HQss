namespace unt_bingoo.view.Product
{
    partial class guiUOM
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private DevExpress.XtraEditors.PanelControl panelHeader;

        // Input card
        private DevExpress.XtraEditors.PanelControl pnlInput;
        private DevExpress.XtraEditors.LabelControl lblUOMCode;
        private DevExpress.XtraEditors.TextEdit txtUOMCode;
        private DevExpress.XtraEditors.LabelControl lblUOMName;
        private DevExpress.XtraEditors.TextEdit txtUOMName;
        private DevExpress.XtraEditors.CheckEdit chkstatus;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClear;

        // Grid
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl grdUOM;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colUOMCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUOMName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riDelete;

        // Footer
        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.LabelControl lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

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
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.pnlInput = new DevExpress.XtraEditors.PanelControl();
            this.cheDeactive = new DevExpress.XtraEditors.CheckEdit();
            this.lblUOMCode = new DevExpress.XtraEditors.LabelControl();
            this.txtUOMCode = new DevExpress.XtraEditors.TextEdit();
            this.lblUOMName = new DevExpress.XtraEditors.LabelControl();
            this.txtUOMName = new DevExpress.XtraEditors.TextEdit();
            this.chkstatus = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.grdUOM = new DevExpress.XtraGrid.GridControl();
            this.gvUOM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUOMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUOMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInput)).BeginInit();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cheDeactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUOMCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUOMName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(820, 76);
            this.panelHeader.TabIndex = 3;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSystemName.Location = new System.Drawing.Point(98, 50);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 184;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.PicSectionIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(0, 0);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(98, 76);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 183;
            this.PicSectionIcon.TabStop = false;
            // 
            // pnlInput
            // 
            this.pnlInput.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlInput.Appearance.Options.UseBackColor = true;
            this.pnlInput.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlInput.Controls.Add(this.cheDeactive);
            this.pnlInput.Controls.Add(this.lblUOMCode);
            this.pnlInput.Controls.Add(this.txtUOMCode);
            this.pnlInput.Controls.Add(this.lblUOMName);
            this.pnlInput.Controls.Add(this.txtUOMName);
            this.pnlInput.Controls.Add(this.chkstatus);
            this.pnlInput.Controls.Add(this.btnSave);
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 76);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(820, 173);
            this.pnlInput.TabIndex = 2;
            this.pnlInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // cheDeactive
            // 
            this.cheDeactive.Location = new System.Drawing.Point(130, 6);
            this.cheDeactive.Name = "cheDeactive";
            this.cheDeactive.Properties.Caption = "Deactive";
            this.cheDeactive.Size = new System.Drawing.Size(120, 19);
            this.cheDeactive.TabIndex = 7;
            this.cheDeactive.CheckedChanged += new System.EventHandler(this.cheDeactive_CheckedChanged);
            // 
            // lblUOMCode
            // 
            this.lblUOMCode.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUOMCode.Appearance.Options.UseFont = true;
            this.lblUOMCode.Location = new System.Drawing.Point(24, 40);
            this.lblUOMCode.Name = "lblUOMCode";
            this.lblUOMCode.Size = new System.Drawing.Size(66, 17);
            this.lblUOMCode.TabIndex = 0;
            this.lblUOMCode.Text = "UOM Code";
            // 
            // txtUOMCode
            // 
            this.txtUOMCode.Location = new System.Drawing.Point(24, 63);
            this.txtUOMCode.Name = "txtUOMCode";
            this.txtUOMCode.Properties.MaxLength = 20;
            this.txtUOMCode.Size = new System.Drawing.Size(200, 20);
            this.txtUOMCode.TabIndex = 1;
            // 
            // lblUOMName
            // 
            this.lblUOMName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUOMName.Appearance.Options.UseFont = true;
            this.lblUOMName.Location = new System.Drawing.Point(255, 40);
            this.lblUOMName.Name = "lblUOMName";
            this.lblUOMName.Size = new System.Drawing.Size(71, 17);
            this.lblUOMName.TabIndex = 2;
            this.lblUOMName.Text = "UOM Name";
            // 
            // txtUOMName
            // 
            this.txtUOMName.Location = new System.Drawing.Point(255, 62);
            this.txtUOMName.Name = "txtUOMName";
            this.txtUOMName.Properties.MaxLength = 100;
            this.txtUOMName.Size = new System.Drawing.Size(360, 20);
            this.txtUOMName.TabIndex = 3;
            // 
            // chkstatus
            // 
            this.chkstatus.EditValue = true;
            this.chkstatus.Location = new System.Drawing.Point(24, 6);
            this.chkstatus.Name = "chkstatus";
            this.chkstatus.Properties.Caption = "Active";
            this.chkstatus.Size = new System.Drawing.Size(110, 19);
            this.chkstatus.TabIndex = 4;
            this.chkstatus.CheckedChanged += new System.EventHandler(this.chkstatus_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(24, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ADD";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnClear.Appearance.Options.UseBackColor = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.btnClear.Location = new System.Drawing.Point(140, 107);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Appearance.Options.UseBackColor = true;
            this.pnlGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlGrid.Controls.Add(this.grdUOM);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 249);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrid.Size = new System.Drawing.Size(820, 313);
            this.pnlGrid.TabIndex = 0;
            // 
            // grdUOM
            // 
            this.grdUOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUOM.Location = new System.Drawing.Point(16, 12);
            this.grdUOM.MainView = this.gvUOM;
            this.grdUOM.Name = "grdUOM";
            this.grdUOM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riUpdate,
            this.riDelete});
            this.grdUOM.Size = new System.Drawing.Size(788, 289);
            this.grdUOM.TabIndex = 0;
            this.grdUOM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUOM});
            // 
            // gvUOM
            // 
            this.gvUOM.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gvUOM.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvUOM.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvUOM.Appearance.Row.Options.UseFont = true;
            this.gvUOM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUOMCode,
            this.colUOMName,
            this.colIsActive,
            this.colUpdate,
            this.colDelete});
            this.gvUOM.GridControl = this.grdUOM;
            this.gvUOM.Name = "gvUOM";
            this.gvUOM.OptionsView.EnableAppearanceEvenRow = true;
            this.gvUOM.OptionsView.ShowGroupPanel = false;
            this.gvUOM.RowHeight = 30;
            this.gvUOM.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvUOM_RowCellStyle);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "UOMId";
            this.colId.Name = "colId";
            // 
            // colUOMCode
            // 
            this.colUOMCode.Caption = "UOM Code";
            this.colUOMCode.FieldName = "UOMCode";
            this.colUOMCode.Name = "colUOMCode";
            this.colUOMCode.OptionsColumn.ReadOnly = true;
            this.colUOMCode.Visible = true;
            this.colUOMCode.VisibleIndex = 0;
            this.colUOMCode.Width = 160;
            // 
            // colUOMName
            // 
            this.colUOMName.Caption = "UOM Name";
            this.colUOMName.FieldName = "UOMName";
            this.colUOMName.Name = "colUOMName";
            this.colUOMName.OptionsColumn.ReadOnly = true;
            this.colUOMName.Visible = true;
            this.colUOMName.VisibleIndex = 1;
            this.colUOMName.Width = 320;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Active";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.OptionsColumn.ReadOnly = true;
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 2;
            this.colIsActive.Width = 90;
            // 
            // colUpdate
            // 
            this.colUpdate.Caption = "Edit";
            this.colUpdate.ColumnEdit = this.riUpdate;
            this.colUpdate.FieldName = "Update";
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUpdate.Visible = true;
            this.colUpdate.VisibleIndex = 3;
            this.colUpdate.Width = 80;
            // 
            // riUpdate
            // 
            this.riUpdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.riUpdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.riUpdate.Name = "riUpdate";
            this.riUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.riUpdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainUpdate_ButtonClick);
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Delete";
            this.colDelete.ColumnEdit = this.riDelete;
            this.colDelete.FieldName = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 4;
            this.colDelete.Width = 80;
            // 
            // riDelete
            // 
            this.riDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Deleted16;
            this.riDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.riDelete.Name = "riDelete";
            this.riDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.riDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainDelete_ButtonClick);
            // 
            // panelFooter
            // 
            this.panelFooter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.panelFooter.Appearance.Options.UseBackColor = true;
            this.panelFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFooter.Controls.Add(this.lblCount);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 562);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(820, 38);
            this.panelFooter.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCount.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblCount.Appearance.Options.UseFont = true;
            this.lblCount.Appearance.Options.UseForeColor = true;
            this.lblCount.Location = new System.Drawing.Point(24, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(85, 15);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Total Records: 0";
            // 
            // guiUOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiUOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNIT MEASURE MANAGEMENT";
            this.Load += new System.EventHandler(this.guiUOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInput)).EndInit();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cheDeactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUOMCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUOMName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private DevExpress.XtraEditors.CheckEdit cheDeactive;
    }
}
