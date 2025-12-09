namespace unt_bingoo.view.Sales
{
    partial class guiSale
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlOrder;

        private System.Windows.Forms.Label lblMenuCategory;
        private System.Windows.Forms.FlowLayoutPanel flowCategories;
        private System.Windows.Forms.Button btnCatAll;
        private System.Windows.Forms.Button btnCatCoffee;
        private System.Windows.Forms.Button btnCatNonCoffee;
        private System.Windows.Forms.Button btnCatFood;
        private System.Windows.Forms.Button btnCatSnack;
        private System.Windows.Forms.Button btnCatDessert;

        private System.Windows.Forms.Label lblAllMenu;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;

        private System.Windows.Forms.Label lblOrderTitle;
        private System.Windows.Forms.Panel pnlOrderType;
        private System.Windows.Forms.Button btnDineIn;
        private System.Windows.Forms.Button btnTakeAway;

        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Panel pnlOrderActions;

        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Label lblSubTotalText;
        private System.Windows.Forms.Label lblSubTotalValue;
        private System.Windows.Forms.Label lblTaxText;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnContinuePayment;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAllMenu = new System.Windows.Forms.Label();
            this.flowCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMenuCategory = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.btnContinuePayment = new System.Windows.Forms.Button();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTaxText = new System.Windows.Forms.Label();
            this.lblSubTotalValue = new System.Windows.Forms.Label();
            this.lblSubTotalText = new System.Windows.Forms.Label();
            this.pnlOrderActions = new System.Windows.Forms.Panel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.pnlOrderType = new System.Windows.Forms.Panel();
            this.btnDineIn = new System.Windows.Forms.Button();
            this.btnTakeAway = new System.Windows.Forms.Button();
            this.lblOrderTitle = new System.Windows.Forms.Label();
            this.btnCatAll = new System.Windows.Forms.Button();
            this.btnCatCoffee = new System.Windows.Forms.Button();
            this.btnCatNonCoffee = new System.Windows.Forms.Button();
            this.btnCatFood = new System.Windows.Forms.Button();
            this.btnCatSnack = new System.Windows.Forms.Button();
            this.btnCatDessert = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableMain.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.flowCategories.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.pnlOrderType.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableMain.Controls.Add(this.pnlMenu, 0, 0);
            this.tableMain.Controls.Add(this.pnlOrder, 1, 0);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 1;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Size = new System.Drawing.Size(1200, 718);
            this.tableMain.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.pnlMenu.Controls.Add(this.lblMenuCategory);
            this.pnlMenu.Controls.Add(this.flowProducts);
            this.pnlMenu.Controls.Add(this.lblAllMenu);
            this.pnlMenu.Controls.Add(this.flowCategories);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMenu.Size = new System.Drawing.Size(774, 712);
            this.pnlMenu.TabIndex = 0;
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProducts.Location = new System.Drawing.Point(20, 147);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowProducts.Size = new System.Drawing.Size(734, 545);
            this.flowProducts.TabIndex = 0;
            // 
            // lblAllMenu
            // 
            this.lblAllMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAllMenu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAllMenu.ForeColor = System.Drawing.Color.White;
            this.lblAllMenu.Location = new System.Drawing.Point(20, 108);
            this.lblAllMenu.Name = "lblAllMenu";
            this.lblAllMenu.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.lblAllMenu.Size = new System.Drawing.Size(734, 39);
            this.lblAllMenu.TabIndex = 1;
            this.lblAllMenu.Text = "All Menu";
            // 
            // flowCategories
            // 
            this.flowCategories.AutoScroll = true;
            this.flowCategories.Controls.Add(this.label1);
            this.flowCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowCategories.Location = new System.Drawing.Point(20, 20);
            this.flowCategories.Name = "flowCategories";
            this.flowCategories.Padding = new System.Windows.Forms.Padding(0, 30, 0, 10);
            this.flowCategories.Size = new System.Drawing.Size(734, 88);
            this.flowCategories.TabIndex = 2;
            this.flowCategories.WrapContents = false;
            // 
            // lblMenuCategory
            // 
            this.lblMenuCategory.AutoSize = true;
            this.lblMenuCategory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMenuCategory.ForeColor = System.Drawing.Color.White;
            this.lblMenuCategory.Location = new System.Drawing.Point(16, -3);
            this.lblMenuCategory.Name = "lblMenuCategory";
            this.lblMenuCategory.Size = new System.Drawing.Size(117, 20);
            this.lblMenuCategory.TabIndex = 3;
            this.lblMenuCategory.Text = "Menu Category";
            // 
            // pnlOrder
            // 
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.pnlOrder.Controls.Add(this.pnlTotals);
            this.pnlOrder.Controls.Add(this.pnlOrderActions);
            this.pnlOrder.Controls.Add(this.dgvOrder);
            this.pnlOrder.Controls.Add(this.pnlOrderType);
            this.pnlOrder.Controls.Add(this.lblOrderTitle);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.Location = new System.Drawing.Point(783, 3);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Padding = new System.Windows.Forms.Padding(20);
            this.pnlOrder.Size = new System.Drawing.Size(414, 712);
            this.pnlOrder.TabIndex = 1;
            // 
            // pnlTotals
            // 
            this.pnlTotals.Controls.Add(this.btnContinuePayment);
            this.pnlTotals.Controls.Add(this.lblTotalValue);
            this.pnlTotals.Controls.Add(this.lblTotalText);
            this.pnlTotals.Controls.Add(this.lblTaxValue);
            this.pnlTotals.Controls.Add(this.lblTaxText);
            this.pnlTotals.Controls.Add(this.lblSubTotalValue);
            this.pnlTotals.Controls.Add(this.lblSubTotalText);
            this.pnlTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotals.Location = new System.Drawing.Point(20, 420);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlTotals.Size = new System.Drawing.Size(374, 272);
            this.pnlTotals.TabIndex = 0;
            // 
            // btnContinuePayment
            // 
            this.btnContinuePayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(76)))), ((int)(((byte)(245)))));
            this.btnContinuePayment.FlatAppearance.BorderSize = 0;
            this.btnContinuePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuePayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinuePayment.ForeColor = System.Drawing.Color.White;
            this.btnContinuePayment.Location = new System.Drawing.Point(0, -74);
            this.btnContinuePayment.Name = "btnContinuePayment";
            this.btnContinuePayment.Size = new System.Drawing.Size(404, 40);
            this.btnContinuePayment.TabIndex = 0;
            this.btnContinuePayment.Text = "Continue Payment";
            this.btnContinuePayment.UseVisualStyleBackColor = false;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalValue.Location = new System.Drawing.Point(160, 55);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(43, 19);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "Rp. 0";
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalText.ForeColor = System.Drawing.Color.Silver;
            this.lblTotalText.Location = new System.Drawing.Point(0, 55);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(42, 19);
            this.lblTotalText.TabIndex = 2;
            this.lblTotalText.Text = "Total";
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.AutoSize = true;
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaxValue.ForeColor = System.Drawing.Color.White;
            this.lblTaxValue.Location = new System.Drawing.Point(160, 25);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.Size = new System.Drawing.Size(35, 15);
            this.lblTaxValue.TabIndex = 3;
            this.lblTaxValue.Text = "Rp. 0";
            // 
            // lblTaxText
            // 
            this.lblTaxText.AutoSize = true;
            this.lblTaxText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxText.ForeColor = System.Drawing.Color.Silver;
            this.lblTaxText.Location = new System.Drawing.Point(0, 25);
            this.lblTaxText.Name = "lblTaxText";
            this.lblTaxText.Size = new System.Drawing.Size(24, 15);
            this.lblTaxText.TabIndex = 4;
            this.lblTaxText.Text = "Tax";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.AutoSize = true;
            this.lblSubTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblSubTotalValue.Location = new System.Drawing.Point(160, 0);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(35, 15);
            this.lblSubTotalValue.TabIndex = 5;
            this.lblSubTotalValue.Text = "Rp. 0";
            // 
            // lblSubTotalText
            // 
            this.lblSubTotalText.AutoSize = true;
            this.lblSubTotalText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTotalText.ForeColor = System.Drawing.Color.Silver;
            this.lblSubTotalText.Location = new System.Drawing.Point(0, 0);
            this.lblSubTotalText.Name = "lblSubTotalText";
            this.lblSubTotalText.Size = new System.Drawing.Size(54, 15);
            this.lblSubTotalText.TabIndex = 6;
            this.lblSubTotalText.Text = "Sub total";
            // 
            // pnlOrderActions
            // 
            this.pnlOrderActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderActions.Location = new System.Drawing.Point(20, 360);
            this.pnlOrderActions.Name = "pnlOrderActions";
            this.pnlOrderActions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlOrderActions.Size = new System.Drawing.Size(374, 60);
            this.pnlOrderActions.TabIndex = 1;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrder.Location = new System.Drawing.Point(20, 80);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.Size = new System.Drawing.Size(374, 280);
            this.dgvOrder.TabIndex = 2;
            // 
            // pnlOrderType
            // 
            this.pnlOrderType.Controls.Add(this.btnDineIn);
            this.pnlOrderType.Controls.Add(this.btnTakeAway);
            this.pnlOrderType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderType.Location = new System.Drawing.Point(20, 20);
            this.pnlOrderType.Name = "pnlOrderType";
            this.pnlOrderType.Padding = new System.Windows.Forms.Padding(0, 25, 0, 5);
            this.pnlOrderType.Size = new System.Drawing.Size(374, 60);
            this.pnlOrderType.TabIndex = 3;
            // 
            // btnDineIn
            // 
            this.btnDineIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.btnDineIn.FlatAppearance.BorderSize = 0;
            this.btnDineIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDineIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDineIn.ForeColor = System.Drawing.Color.White;
            this.btnDineIn.Location = new System.Drawing.Point(0, 20);
            this.btnDineIn.Name = "btnDineIn";
            this.btnDineIn.Size = new System.Drawing.Size(90, 30);
            this.btnDineIn.TabIndex = 0;
            this.btnDineIn.Text = "Dine in";
            this.btnDineIn.UseVisualStyleBackColor = false;
            // 
            // btnTakeAway
            // 
            this.btnTakeAway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(72)))), ((int)(((byte)(88)))));
            this.btnTakeAway.FlatAppearance.BorderSize = 0;
            this.btnTakeAway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeAway.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTakeAway.ForeColor = System.Drawing.Color.White;
            this.btnTakeAway.Location = new System.Drawing.Point(100, 20);
            this.btnTakeAway.Name = "btnTakeAway";
            this.btnTakeAway.Size = new System.Drawing.Size(90, 30);
            this.btnTakeAway.TabIndex = 1;
            this.btnTakeAway.Text = "Take away";
            this.btnTakeAway.UseVisualStyleBackColor = false;
            // 
            // lblOrderTitle
            // 
            this.lblOrderTitle.AutoSize = true;
            this.lblOrderTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderTitle.ForeColor = System.Drawing.Color.White;
            this.lblOrderTitle.Location = new System.Drawing.Point(5, 5);
            this.lblOrderTitle.Name = "lblOrderTitle";
            this.lblOrderTitle.Size = new System.Drawing.Size(71, 20);
            this.lblOrderTitle.TabIndex = 4;
            this.lblOrderTitle.Text = "Order #1";
            // 
            // btnCatAll
            // 
            this.btnCatAll.Location = new System.Drawing.Point(0, 0);
            this.btnCatAll.Name = "btnCatAll";
            this.btnCatAll.Size = new System.Drawing.Size(75, 23);
            this.btnCatAll.TabIndex = 0;
            // 
            // btnCatCoffee
            // 
            this.btnCatCoffee.Location = new System.Drawing.Point(0, 0);
            this.btnCatCoffee.Name = "btnCatCoffee";
            this.btnCatCoffee.Size = new System.Drawing.Size(75, 23);
            this.btnCatCoffee.TabIndex = 0;
            // 
            // btnCatNonCoffee
            // 
            this.btnCatNonCoffee.Location = new System.Drawing.Point(0, 0);
            this.btnCatNonCoffee.Name = "btnCatNonCoffee";
            this.btnCatNonCoffee.Size = new System.Drawing.Size(75, 23);
            this.btnCatNonCoffee.TabIndex = 0;
            // 
            // btnCatFood
            // 
            this.btnCatFood.Location = new System.Drawing.Point(0, 0);
            this.btnCatFood.Name = "btnCatFood";
            this.btnCatFood.Size = new System.Drawing.Size(75, 23);
            this.btnCatFood.TabIndex = 0;
            // 
            // btnCatSnack
            // 
            this.btnCatSnack.Location = new System.Drawing.Point(0, 0);
            this.btnCatSnack.Name = "btnCatSnack";
            this.btnCatSnack.Size = new System.Drawing.Size(75, 23);
            this.btnCatSnack.TabIndex = 0;
            // 
            // btnCatDessert
            // 
            this.btnCatDessert.Location = new System.Drawing.Point(0, 0);
            this.btnCatDessert.Name = "btnCatDessert";
            this.btnCatDessert.Size = new System.Drawing.Size(75, 23);
            this.btnCatDessert.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Price";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "&ALL";
            // 
            // guiSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 718);
            this.Controls.Add(this.tableMain);
            this.Name = "guiSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS Sale";
            this.tableMain.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.flowCategories.ResumeLayout(false);
            this.flowCategories.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlTotals.ResumeLayout(false);
            this.pnlTotals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.pnlOrderType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
    }
}
