using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace unt_bingoo.view.Product
{
    partial class guiProduct
    {
        private System.ComponentModel.IContainer components = null;

        private PanelControl panelHeader;

        private PanelControl panelForm;
        private LabelControl lblCode;
        private LabelControl lblName;
        private LabelControl lblCategory;
        private LabelControl lblBrand;
        private LabelControl lblCost;
        private LabelControl lblSupplier;
        private LabelControl lblQty;
        private LabelControl lblPrice;
        private LabelControl lblRemark;
        private LabelControl lblSize;
        private LabelControl lblVAT;          // <- NEW

        private TextEdit txtCode;
        private TextEdit txtName;
        private TextEdit txtCost;
        private TextEdit txtPrice;
        private TextEdit txtQty;
        private MemoEdit txtRemark;
        private CheckEdit chkActive;
        private ComboBoxEdit txt;
        private TextEdit txtVAT;              // <- NEW

        private SimpleButton btnAdd;
        private SimpleButton btnCancel;

        private PanelControl panelGrid;

        private PanelControl panelBottom;
        private LabelControl lblCount;
        private SimpleButton btnExport;
        private SimpleButton btnClose;

        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboBrand;

        private PanelControl panelControl1;
        private PictureEdit picLogo;
        private LabelControl lblSystemName;

        internal PictureBox picCustomer;

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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.txt = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelForm = new DevExpress.XtraEditors.PanelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDiscound = new DevExpress.XtraEditors.TextEdit();
            this.cbosupplier = new System.Windows.Forms.ComboBox();
            this.btnaddBrand = new System.Windows.Forms.Button();
            this.btnaddCategory = new System.Windows.Forms.Button();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblCost = new DevExpress.XtraEditors.LabelControl();
            this.lblBrand = new DevExpress.XtraEditors.LabelControl();
            this.lblSupplier = new DevExpress.XtraEditors.LabelControl();
            this.lblQty = new DevExpress.XtraEditors.LabelControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.lblVAT = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCost = new DevExpress.XtraEditors.TextEdit();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtVAT = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridProduct = new DevExpress.XtraGrid.GridControl();
            this.gvProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BrandName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImageUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainupdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmaindelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForm)).BeginInit();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscound.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainupdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmaindelete)).BeginInit();
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
            this.panelHeader.Size = new System.Drawing.Size(1149, 84);
            this.panelHeader.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.picLogo);
            this.panelControl1.Controls.Add(this.lblSystemName);
            this.panelControl1.Controls.Add(this.txt);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1145, 82);
            this.panelControl1.TabIndex = 4;
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
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(570, 27);
            this.txt.Name = "txt";
            this.txt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Properties.Appearance.Options.UseFont = true;
            this.txt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txt.Size = new System.Drawing.Size(293, 20);
            this.txt.TabIndex = 160;
            this.txt.Visible = false;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.button1);
            this.panelForm.Controls.Add(this.txtDiscound);
            this.panelForm.Controls.Add(this.cbosupplier);
            this.panelForm.Controls.Add(this.btnaddBrand);
            this.panelForm.Controls.Add(this.btnaddCategory);
            this.panelForm.Controls.Add(this.picCustomer);
            this.panelForm.Controls.Add(this.cboBrand);
            this.panelForm.Controls.Add(this.cboCategory);
            this.panelForm.Controls.Add(this.lblCode);
            this.panelForm.Controls.Add(this.lblName);
            this.panelForm.Controls.Add(this.lblCategory);
            this.panelForm.Controls.Add(this.lblCost);
            this.panelForm.Controls.Add(this.lblBrand);
            this.panelForm.Controls.Add(this.lblSupplier);
            this.panelForm.Controls.Add(this.lblQty);
            this.panelForm.Controls.Add(this.lblPrice);
            this.panelForm.Controls.Add(this.lblRemark);
            this.panelForm.Controls.Add(this.lblSize);
            this.panelForm.Controls.Add(this.lblVAT);
            this.panelForm.Controls.Add(this.txtCode);
            this.panelForm.Controls.Add(this.txtName);
            this.panelForm.Controls.Add(this.txtCost);
            this.panelForm.Controls.Add(this.txtQty);
            this.panelForm.Controls.Add(this.txtPrice);
            this.panelForm.Controls.Add(this.txtVAT);
            this.panelForm.Controls.Add(this.txtRemark);
            this.panelForm.Controls.Add(this.chkActive);
            this.panelForm.Controls.Add(this.btnAdd);
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 84);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1149, 205);
            this.panelForm.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Image = global::unt_bingoo.Properties.Resources.add16;
            this.button1.Location = new System.Drawing.Point(876, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 26);
            this.button1.TabIndex = 171;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDiscound
            // 
            this.txtDiscound.Location = new System.Drawing.Point(610, 128);
            this.txtDiscound.Name = "txtDiscound";
            this.txtDiscound.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscound.Properties.Appearance.Options.UseFont = true;
            this.txtDiscound.Size = new System.Drawing.Size(293, 20);
            this.txtDiscound.TabIndex = 170;
            // 
            // cbosupplier
            // 
            this.cbosupplier.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbosupplier.FormattingEnabled = true;
            this.cbosupplier.Location = new System.Drawing.Point(610, 44);
            this.cbosupplier.Name = "cbosupplier";
            this.cbosupplier.Size = new System.Drawing.Size(255, 22);
            this.cbosupplier.TabIndex = 169;
            // 
            // btnaddBrand
            // 
            this.btnaddBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnaddBrand.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnaddBrand.Location = new System.Drawing.Point(876, 12);
            this.btnaddBrand.Name = "btnaddBrand";
            this.btnaddBrand.Size = new System.Drawing.Size(27, 26);
            this.btnaddBrand.TabIndex = 168;
            this.btnaddBrand.UseVisualStyleBackColor = false;
            this.btnaddBrand.Click += new System.EventHandler(this.btnaddBrand_Click);
            // 
            // btnaddCategory
            // 
            this.btnaddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnaddCategory.Image = global::unt_bingoo.Properties.Resources.add16;
            this.btnaddCategory.Location = new System.Drawing.Point(388, 68);
            this.btnaddCategory.Name = "btnaddCategory";
            this.btnaddCategory.Size = new System.Drawing.Size(27, 26);
            this.btnaddCategory.TabIndex = 167;
            this.btnaddCategory.UseVisualStyleBackColor = false;
            this.btnaddCategory.Click += new System.EventHandler(this.btnaddCategory_Click);
            // 
            // picCustomer
            // 
            this.picCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCustomer.Location = new System.Drawing.Point(939, 16);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.Size = new System.Drawing.Size(131, 135);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCustomer.TabIndex = 143;
            this.picCustomer.TabStop = false;
            this.picCustomer.DoubleClick += new System.EventHandler(this.picCustomer_DoubleClick);
            // 
            // cboBrand
            // 
            this.cboBrand.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(610, 16);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(255, 22);
            this.cboBrand.TabIndex = 24;
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(103, 70);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(277, 22);
            this.cboCategory.TabIndex = 23;
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Location = new System.Drawing.Point(17, 19);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 14);
            this.lblCode.TabIndex = 144;
            this.lblCode.Text = "Code:";
            // 
            // lblName
            // 
            this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Appearance.Options.UseFont = true;
            this.lblName.Location = new System.Drawing.Point(17, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 14);
            this.lblName.TabIndex = 145;
            this.lblName.Text = "Name:";
            // 
            // lblCategory
            // 
            this.lblCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Appearance.Options.UseFont = true;
            this.lblCategory.Location = new System.Drawing.Point(17, 74);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 14);
            this.lblCategory.TabIndex = 146;
            this.lblCategory.Text = "Category:";
            // 
            // lblCost
            // 
            this.lblCost.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Appearance.Options.UseFont = true;
            this.lblCost.Location = new System.Drawing.Point(17, 102);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(58, 14);
            this.lblCost.TabIndex = 147;
            this.lblCost.Text = "Cost Price:";
            // 
            // lblBrand
            // 
            this.lblBrand.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Appearance.Options.UseFont = true;
            this.lblBrand.Location = new System.Drawing.Point(516, 23);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 14);
            this.lblBrand.TabIndex = 148;
            this.lblBrand.Text = "Brand:";
            // 
            // lblSupplier
            // 
            this.lblSupplier.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Appearance.Options.UseFont = true;
            this.lblSupplier.Location = new System.Drawing.Point(516, 50);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(47, 14);
            this.lblSupplier.TabIndex = 149;
            this.lblSupplier.Text = "Supplier:";
            // 
            // lblQty
            // 
            this.lblQty.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Appearance.Options.UseFont = true;
            this.lblQty.Location = new System.Drawing.Point(516, 78);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(24, 14);
            this.lblQty.TabIndex = 150;
            this.lblQty.Text = "Qty:";
            // 
            // lblPrice
            // 
            this.lblPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Appearance.Options.UseFont = true;
            this.lblPrice.Location = new System.Drawing.Point(516, 106);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(68, 14);
            this.lblPrice.TabIndex = 151;
            this.lblPrice.Text = "Selling Price:";
            // 
            // lblRemark
            // 
            this.lblRemark.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Appearance.Options.UseFont = true;
            this.lblRemark.Location = new System.Drawing.Point(17, 130);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(44, 14);
            this.lblRemark.TabIndex = 152;
            this.lblRemark.Text = "Remark:";
            // 
            // lblSize
            // 
            this.lblSize.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Appearance.Options.UseFont = true;
            this.lblSize.Location = new System.Drawing.Point(516, 134);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(77, 14);
            this.lblSize.TabIndex = 153;
            this.lblSize.Text = "Discount (%):";
            // 
            // lblVAT
            // 
            this.lblVAT.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVAT.Appearance.Options.UseFont = true;
            this.lblVAT.Location = new System.Drawing.Point(516, 160);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(54, 14);
            this.lblVAT.TabIndex = 154;
            this.lblVAT.Text = "VAT (%):";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(103, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(312, 20);
            this.txtCode.TabIndex = 155;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 44);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(312, 20);
            this.txtName.TabIndex = 156;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(103, 99);
            this.txtCost.Name = "txtCost";
            this.txtCost.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Properties.Appearance.Options.UseFont = true;
            this.txtCost.Size = new System.Drawing.Size(312, 20);
            this.txtCost.TabIndex = 157;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(610, 75);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Properties.Appearance.Options.UseFont = true;
            this.txtQty.Size = new System.Drawing.Size(293, 20);
            this.txtQty.TabIndex = 159;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(610, 103);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Properties.Appearance.Options.UseFont = true;
            this.txtPrice.Size = new System.Drawing.Size(293, 20);
            this.txtPrice.TabIndex = 161;
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(610, 157);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.Properties.Appearance.Options.UseFont = true;
            this.txtVAT.Size = new System.Drawing.Size(80, 20);
            this.txtVAT.TabIndex = 162;
            this.txtVAT.ToolTip = "VAT percent (e.g. 10 for 10%)";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(103, 127);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Properties.Appearance.Options.UseFont = true;
            this.txtRemark.Size = new System.Drawing.Size(312, 37);
            this.txtRemark.TabIndex = 163;
            // 
            // chkActive
            // 
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(710, 157);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(60, 19);
            this.chkActive.TabIndex = 164;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Add_New_Bank_Book16;
            this.btnAdd.Location = new System.Drawing.Point(909, 176);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 23);
            this.btnAdd.TabIndex = 165;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(993, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 23);
            this.btnCancel.TabIndex = 166;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridProduct);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 289);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1149, 309);
            this.panelGrid.TabIndex = 0;
            // 
            // gridProduct
            // 
            this.gridProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProduct.Location = new System.Drawing.Point(2, 2);
            this.gridProduct.MainView = this.gvProduct;
            this.gridProduct.Name = "gridProduct";
            this.gridProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmainupdate,
            this.btnmaindelete});
            this.gridProduct.Size = new System.Drawing.Size(1145, 305);
            this.gridProduct.TabIndex = 0;
            this.gridProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProduct});
            // 
            // gvProduct
            // 
            this.gvProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductID,
            this.No,
            this.ProductCode,
            this.ProductName,
            this.CategoryName,
            this.BrandName,
            this.CostPrice,
            this.SellingPrice,
            this.TaxPercent,
            this.DiscountPercent,
            this.SupplierName,
            this.Status,
            this.ImageUrl,
            this.ProductImage,
            this.gridColumn1,
            this.gridColumn2});
            this.gvProduct.GridControl = this.gridProduct;
            this.gvProduct.Name = "gvProduct";
            this.gvProduct.OptionsView.ShowGroupPanel = false;
            this.gvProduct.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvProduct_RowCellStyle);
            this.gvProduct.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvProduct_CustomColumnDisplayText);
            // 
            // ProductID
            // 
            this.ProductID.Caption = "ProductID ";
            this.ProductID.Name = "ProductID";
            // 
            // No
            // 
            this.No.Caption = "No";
            this.No.FieldName = "No";
            this.No.Name = "No";
            this.No.Visible = true;
            this.No.VisibleIndex = 0;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "ProductCode";
            this.ProductCode.FieldName = "ProductCode";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 1;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Product Name";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 2;
            // 
            // CategoryName
            // 
            this.CategoryName.Caption = "Category";
            this.CategoryName.FieldName = "CategoryName";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Visible = true;
            this.CategoryName.VisibleIndex = 3;
            // 
            // BrandName
            // 
            this.BrandName.Caption = "Brand";
            this.BrandName.FieldName = "BrandName";
            this.BrandName.Name = "BrandName";
            this.BrandName.Visible = true;
            this.BrandName.VisibleIndex = 4;
            // 
            // CostPrice
            // 
            this.CostPrice.Caption = "Cost";
            this.CostPrice.FieldName = "CostPrice";
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.Visible = true;
            this.CostPrice.VisibleIndex = 5;
            // 
            // SellingPrice
            // 
            this.SellingPrice.Caption = "Price";
            this.SellingPrice.FieldName = "SellingPrice";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.Visible = true;
            this.SellingPrice.VisibleIndex = 6;
            // 
            // TaxPercent
            // 
            this.TaxPercent.Caption = "VAT (%)";
            this.TaxPercent.FieldName = "TaxPercent";
            this.TaxPercent.Name = "TaxPercent";
            this.TaxPercent.Visible = true;
            this.TaxPercent.VisibleIndex = 7;
            // 
            // DiscountPercent
            // 
            this.DiscountPercent.Caption = "DiscountPercent";
            this.DiscountPercent.FieldName = "DiscountPercent";
            this.DiscountPercent.Name = "DiscountPercent";
            this.DiscountPercent.Visible = true;
            this.DiscountPercent.VisibleIndex = 8;
            // 
            // SupplierName
            // 
            this.SupplierName.Caption = "Supplier";
            this.SupplierName.FieldName = "SupplierName";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.Visible = true;
            this.SupplierName.VisibleIndex = 9;
            // 
            // Status
            // 
            this.Status.Caption = "Active";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = true;
            this.Status.VisibleIndex = 10;
            // 
            // ImageUrl
            // 
            this.ImageUrl.Caption = "Image";
            this.ImageUrl.FieldName = "ImageUrl";
            this.ImageUrl.Name = "ImageUrl";
            // 
            // ProductImage
            // 
            this.ProductImage.Caption = "ProductImage";
            this.ProductImage.FieldName = "ProductImage";
            this.ProductImage.Name = "ProductImage";
            this.ProductImage.Visible = true;
            this.ProductImage.VisibleIndex = 11;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.ColumnEdit = this.btnmainupdate;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 12;
            // 
            // btnmainupdate
            // 
            this.btnmainupdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.update_16;
            this.btnmainupdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainupdate.Name = "btnmainupdate";
            this.btnmainupdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainupdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainupdate_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.ColumnEdit = this.btnmaindelete;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 13;
            // 
            // btnmaindelete
            // 
            this.btnmaindelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnmaindelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmaindelete.Name = "btnmaindelete";
            this.btnmaindelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmaindelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmaindelete_ButtonClick);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCount);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 598);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1149, 37);
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
            this.btnExport.Location = new System.Drawing.Point(1009, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 33);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(1078, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guiProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 635);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.guiProduct_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForm)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscound.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainupdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmaindelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnaddBrand;
        private Button btnaddCategory;
        private GridControl gridProduct;
        private GridView gvProduct;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn CategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn BrandName;
        private DevExpress.XtraGrid.Columns.GridColumn CostPrice;
        private DevExpress.XtraGrid.Columns.GridColumn SellingPrice;
        private DevExpress.XtraGrid.Columns.GridColumn TaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn DiscountPercent;
        private DevExpress.XtraGrid.Columns.GridColumn SupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn No;
        private DevExpress.XtraGrid.Columns.GridColumn ImageUrl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn ProductImage;
        private System.Windows.Forms.ComboBox cbosupplier;
        private TextEdit txtDiscound;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainupdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmaindelete;
        private Button button1;
    }
}
