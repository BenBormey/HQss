namespace unt_bingoo.view.Product
{
    partial class guiCreateProduct
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblPicHint = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblKhmerName = new System.Windows.Forms.Label();
            this.txtKhmerName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.chkIsIngredient = new System.Windows.Forms.CheckBox();
            this.lblNextStepHint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGoToOutletMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblListHeader = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gridProducts = new DevExpress.XtraGrid.GridControl();
            this.gvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhmer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRowEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRowDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(261, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Products — Create / Update";
            // 
            // grpProduct
            // 
            this.grpProduct.Controls.Add(this.picProduct);
            this.grpProduct.Controls.Add(this.lblPicHint);
            this.grpProduct.Controls.Add(this.lblBarcode);
            this.grpProduct.Controls.Add(this.txtBarcode);
            this.grpProduct.Controls.Add(this.lblProductName);
            this.grpProduct.Controls.Add(this.txtProductName);
            this.grpProduct.Controls.Add(this.lblKhmerName);
            this.grpProduct.Controls.Add(this.txtKhmerName);
            this.grpProduct.Controls.Add(this.lblCategory);
            this.grpProduct.Controls.Add(this.cboCategory);
            this.grpProduct.Controls.Add(this.lblUnit);
            this.grpProduct.Controls.Add(this.cboUnit);
            this.grpProduct.Controls.Add(this.lblCostPrice);
            this.grpProduct.Controls.Add(this.txtCostPrice);
            this.grpProduct.Controls.Add(this.chkIsIngredient);
            this.grpProduct.Location = new System.Drawing.Point(20, 60);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(560, 285);
            this.grpProduct.TabIndex = 1;
            this.grpProduct.TabStop = false;
            this.grpProduct.Text = "Product details";
            // 
            // picProduct
            // 
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(420, 28);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(120, 120);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 11;
            this.picProduct.TabStop = false;
            this.picProduct.DoubleClick += new System.EventHandler(this.picProduct_DoubleClick);
            // 
            // lblPicHint
            // 
            this.lblPicHint.AutoSize = true;
            this.lblPicHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPicHint.Location = new System.Drawing.Point(417, 151);
            this.lblPicHint.Name = "lblPicHint";
            this.lblPicHint.Size = new System.Drawing.Size(113, 26);
            this.lblPicHint.TabIndex = 12;
            this.lblPicHint.Text = "Double-click to choose\r\n(optional)";
            this.lblPicHint.Visible = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(20, 33);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(81, 13);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode / Code";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBarcode.Location = new System.Drawing.Point(150, 30);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(240, 21);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Click += new System.EventHandler(this.txtBarcode_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(20, 68);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 13);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Product Name (EN)";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(150, 65);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(240, 21);
            this.txtProductName.TabIndex = 3;
            // 
            // lblKhmerName
            // 
            this.lblKhmerName.AutoSize = true;
            this.lblKhmerName.Location = new System.Drawing.Point(20, 103);
            this.lblKhmerName.Name = "lblKhmerName";
            this.lblKhmerName.Size = new System.Drawing.Size(67, 13);
            this.lblKhmerName.TabIndex = 4;
            this.lblKhmerName.Text = "Khmer Name";
            // 
            // txtKhmerName
            // 
            this.txtKhmerName.Location = new System.Drawing.Point(150, 100);
            this.txtKhmerName.Name = "txtKhmerName";
            this.txtKhmerName.Size = new System.Drawing.Size(240, 21);
            this.txtKhmerName.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 138);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(150, 135);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(240, 21);
            this.cboCategory.TabIndex = 7;
            //
            // lblUnit
            //
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(20, 173);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 13);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "Unit";
            //
            // cboUnit
            //
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(150, 170);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(150, 21);
            this.cboUnit.TabIndex = 9;
            //
            // lblCostPrice
            //
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Location = new System.Drawing.Point(20, 208);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(104, 13);
            this.lblCostPrice.TabIndex = 10;
            this.lblCostPrice.Text = "Cost Price (optional)";
            //
            // txtCostPrice
            //
            this.txtCostPrice.Location = new System.Drawing.Point(150, 205);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(240, 21);
            this.txtCostPrice.TabIndex = 11;
            this.txtCostPrice.Text = "0";
            //
            // chkIsIngredient
            //
            this.chkIsIngredient.AutoSize = true;
            this.chkIsIngredient.Location = new System.Drawing.Point(150, 240);
            this.chkIsIngredient.Name = "chkIsIngredient";
            this.chkIsIngredient.Size = new System.Drawing.Size(229, 17);
            this.chkIsIngredient.TabIndex = 12;
            this.chkIsIngredient.Text = "Ingredient (raw material, not sold directly)";
            this.chkIsIngredient.UseVisualStyleBackColor = true;
            // 
            // lblNextStepHint
            // 
            this.lblNextStepHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblNextStepHint.Location = new System.Drawing.Point(20, 355);
            this.lblNextStepHint.Name = "lblNextStepHint";
            this.lblNextStepHint.Size = new System.Drawing.Size(560, 40);
            this.lblNextStepHint.TabIndex = 2;
            this.lblNextStepHint.Text = "This only creates the product. To make it sellable at a POS, go to Setup > Outlet" +
    " Menu next and add it there with a price.";
            this.lblNextStepHint.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(20, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Create Product";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(190, 410);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 36);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "New / Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Location = new System.Drawing.Point(300, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 36);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGoToOutletMenu
            // 
            this.btnGoToOutletMenu.Location = new System.Drawing.Point(410, 410);
            this.btnGoToOutletMenu.Name = "btnGoToOutletMenu";
            this.btnGoToOutletMenu.Size = new System.Drawing.Size(170, 36);
            this.btnGoToOutletMenu.TabIndex = 7;
            this.btnGoToOutletMenu.Text = "Go to Outlet Menu →";
            this.btnGoToOutletMenu.UseVisualStyleBackColor = true;
            this.btnGoToOutletMenu.Visible = false;
            this.btnGoToOutletMenu.Click += new System.EventHandler(this.btnGoToOutletMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(590, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 455);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(660, 36);
            this.lblStatus.TabIndex = 6;
            // 
            // lblListHeader
            // 
            this.lblListHeader.AutoSize = true;
            this.lblListHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblListHeader.Location = new System.Drawing.Point(20, 501);
            this.lblListHeader.Name = "lblListHeader";
            this.lblListHeader.Size = new System.Drawing.Size(298, 19);
            this.lblListHeader.TabIndex = 9;
            this.lblListHeader.Text = "All products — double-click a row to edit it";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 529);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 526);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 21);
            this.txtSearch.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(345, 524);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 24);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridProducts
            // 
            this.gridProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProducts.Location = new System.Drawing.Point(20, 556);
            this.gridProducts.MainView = this.gvProducts;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRowEdit,
            this.btnRowDelete});
            this.gridProducts.Size = new System.Drawing.Size(940, 300);
            this.gridProducts.TabIndex = 13;
            this.gridProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducts});
            // 
            // gvProducts
            // 
            this.gvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colKhmer,
            this.colType,
            this.colUnit,
            this.colCost,
            this.colEdit,
            this.colDelete});
            this.gvProducts.GridControl = this.gridProducts;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "ProNumY";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 150;
            // 
            // colName
            // 
            this.colName.Caption = "Product Name";
            this.colName.FieldName = "ProName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 220;
            // 
            // colKhmer
            // 
            this.colKhmer.Caption = "Khmer Name";
            this.colKhmer.FieldName = "KhmerName";
            this.colKhmer.Name = "colKhmer";
            this.colKhmer.Visible = true;
            this.colKhmer.VisibleIndex = 2;
            this.colKhmer.Width = 180;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "ProductType";
            this.colType.Name = "colType";
            this.colType.UnboundExpression = "iif(IsIngredient, \'Ingredient\', \'Sellable\')";
            this.colType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            // Was "ProductScale.UOMCode" — a nested object that is null for
            // every product without a scale row, so the column rendered blank
            // even though the unit was set. ProUnit is what the rest of this
            // form reads and writes (see cboUnit handling in the code file).
            this.colUnit.FieldName = "ProUnit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 3;
            this.colUnit.Width = 70;
            // 
            // colCost
            // 
            this.colCost.Caption = "Cost";
            this.colCost.DisplayFormat.FormatString = "0.####";
            this.colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.FieldName = "ProImpPri";
            this.colCost.Name = "colCost";
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 4;
            this.colCost.Width = 90;
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Edit";
            this.colEdit.ColumnEdit = this.btnRowEdit;
            this.colEdit.Name = "colEdit";
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 5;
            this.colEdit.Width = 60;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnRowEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnRowEdit.Name = "btnRowEdit";
            this.btnRowEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRowEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRowEdit_ButtonClick);
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Delete";
            this.colDelete.ColumnEdit = this.btnRowDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 6;
            this.colDelete.Width = 60;
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Deleted16;
            this.btnRowDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRowDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRowDelete_ButtonClick);
            // 
            // guiCreateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 875);
            this.Controls.Add(this.gridProducts);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblListHeader);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGoToOutletMenu);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNextStepHint);
            this.Controls.Add(this.grpProduct);
            this.Controls.Add(this.lblTitle);
            this.Name = "guiCreateProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products — Create / Update";
            this.Load += new System.EventHandler(this.guiCreateProduct_Load);
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpProduct;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblPicHint;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblKhmerName;
        private System.Windows.Forms.TextBox txtKhmerName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label lblNextStepHint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkIsIngredient;
        private System.Windows.Forms.Label lblListHeader;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private DevExpress.XtraGrid.GridControl gridProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducts;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colKhmer;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowDelete;
        private System.Windows.Forms.Button btnGoToOutletMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
    }
}
