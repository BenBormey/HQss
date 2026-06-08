namespace unt_bingoo.view.Product
{
    partial class guiProductStock
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQty;

        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.Label lblRemark;

        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ComboBox cboOutlet;

        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtRemark;

        private System.Windows.Forms.Panel panelBottom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gridProduct = new DevExpress.XtraGrid.GridControl();
            this.gvProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StockQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmaindelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmaindelete)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(31, 32);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(100, 23);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Product:";
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(31, 63);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(100, 23);
            this.lblQty.TabIndex = 5;
            this.lblQty.Text = "Stock Qty:";
            // 
            // lblOutlet
            // 
            this.lblOutlet.Location = new System.Drawing.Point(31, 90);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(100, 23);
            this.lblOutlet.TabIndex = 7;
            this.lblOutlet.Text = "Outlet:";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(31, 120);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(100, 23);
            this.lblRemark.TabIndex = 9;
            this.lblRemark.Text = "Remark:";
            // 
            // cboProduct
            // 
            this.cboProduct.Location = new System.Drawing.Point(131, 27);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(369, 21);
            this.cboProduct.TabIndex = 2;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            this.cboProduct.SelectedValueChanged += new System.EventHandler(this.cboProduct_SelectedValueChanged);
            // 
            // cboOutlet
            // 
            this.cboOutlet.Location = new System.Drawing.Point(131, 85);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(369, 21);
            this.cboOutlet.TabIndex = 8;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(131, 58);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(369, 21);
            this.txtQty.TabIndex = 6;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(131, 115);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(369, 60);
            this.txtRemark.TabIndex = 10;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Gainsboro;
            this.panelBottom.Controls.Add(this.panelControl1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 644);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(851, 50);
            this.panelBottom.TabIndex = 14;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblCountRow);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(851, 50);
            this.panelControl1.TabIndex = 2;
            // 
            // lblCountRow
            // 
            this.lblCountRow.Location = new System.Drawing.Point(10, 12);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(53, 13);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Count Row";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.Location = new System.Drawing.Point(689, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 46);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Export";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Location = new System.Drawing.Point(769, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(80, 46);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Close";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 644);
            this.panel1.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 208);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(851, 436);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.gridProduct);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(851, 436);
            this.panel6.TabIndex = 14;
            // 
            // gridProduct
            // 
            this.gridProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProduct.Location = new System.Drawing.Point(0, 0);
            this.gridProduct.MainView = this.gvProduct;
            this.gridProduct.Name = "gridProduct";
            this.gridProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmaindelete,
            this.btnmainUpdate});
            this.gridProduct.Size = new System.Drawing.Size(851, 436);
            this.gridProduct.TabIndex = 1;
            this.gridProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProduct});
            // 
            // gvProduct
            // 
            this.gvProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StockID,
            this.gridColumn8,
            this.ProductName,
            this.OutletName,
            this.StockQty,
            this.gridColumn2,
            this.gridColumn3});
            this.gvProduct.GridControl = this.gridProduct;
            this.gvProduct.Name = "gvProduct";
            this.gvProduct.OptionsView.ShowGroupPanel = false;
            this.gvProduct.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvProduct_RowClick);
            this.gvProduct.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvProduct_RowCellStyle);
            this.gvProduct.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvProduct_CustomColumnDisplayText);
            // 
            // StockID
            // 
            this.StockID.Caption = "StockID";
            this.StockID.FieldName = "StockID";
            this.StockID.Name = "StockID";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "No";
            this.gridColumn8.FieldName = "No";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 45;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "ProductName";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            this.ProductName.Width = 156;
            // 
            // OutletName
            // 
            this.OutletName.Caption = "OutletName";
            this.OutletName.FieldName = "OutletName";
            this.OutletName.Name = "OutletName";
            this.OutletName.Visible = true;
            this.OutletName.VisibleIndex = 2;
            this.OutletName.Width = 156;
            // 
            // StockQty
            // 
            this.StockQty.Caption = "StockQty";
            this.StockQty.FieldName = "StockQty";
            this.StockQty.Name = "StockQty";
            this.StockQty.Visible = true;
            this.StockQty.VisibleIndex = 3;
            this.StockQty.Width = 156;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Update";
            this.gridColumn2.ColumnEdit = this.btnmainUpdate;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 156;
            // 
            // btnmainUpdate
            // 
            this.btnmainUpdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.update_16;
            this.btnmainUpdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainUpdate.Name = "btnmainUpdate";
            this.btnmainUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainUpdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainUpdate_ButtonClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Delete";
            this.gridColumn3.ColumnEdit = this.btnmaindelete;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 164;
            // 
            // btnmaindelete
            // 
            this.btnmaindelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Deleted16;
            this.btnmaindelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmaindelete.Name = "btnmaindelete";
            this.btnmaindelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmaindelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmaindelete_ButtonClick);
            this.btnmaindelete.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmaindelete_ButtonPressed);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.lblProduct);
            this.panel4.Controls.Add(this.btnAdd);
            this.panel4.Controls.Add(this.cboProduct);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.lblOutlet);
            this.panel4.Controls.Add(this.txtQty);
            this.panel4.Controls.Add(this.cboOutlet);
            this.panel4.Controls.Add(this.lblQty);
            this.panel4.Controls.Add(this.lblRemark);
            this.panel4.Controls.Add(this.txtRemark);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(851, 208);
            this.panel4.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button2.Location = new System.Drawing.Point(516, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 24);
            this.button2.TabIndex = 171;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnAdd.Location = new System.Drawing.Point(516, 148);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnCancel.Location = new System.Drawing.Point(618, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guiProductStock
            // 
            this.ClientSize = new System.Drawing.Size(851, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Name = "guiProductStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Stock Management";
            this.Load += new System.EventHandler(this.guiProductStock_Load);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmaindelete)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraGrid.GridControl gridProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProduct;
        private DevExpress.XtraGrid.Columns.GridColumn StockID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn OutletName;
        private DevExpress.XtraGrid.Columns.GridColumn StockQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmaindelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainUpdate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblCountRow;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Button button2;
    }
}
