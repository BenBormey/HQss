namespace unt_bingoo.view
{
    partial class Sale
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraEditors.PanelControl panelBottom;

        private DevExpress.XtraEditors.TextEdit txtSearch;

        private DevExpress.XtraGrid.GridControl gridProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProduct;

        private DevExpress.XtraGrid.GridControl gridCart;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCart;

        private DevExpress.XtraEditors.LabelControl lblSub;
        private DevExpress.XtraEditors.LabelControl lblTax;
        private DevExpress.XtraEditors.LabelControl lblTotal;

        private DevExpress.XtraEditors.SimpleButton btnPay;
        private DevExpress.XtraEditors.SimpleButton btnClear;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();

            this.txtSearch = new DevExpress.XtraEditors.TextEdit();

            this.gridProduct = new DevExpress.XtraGrid.GridControl();
            this.gvProduct = new DevExpress.XtraGrid.Views.Grid.GridView();

            this.gridCart = new DevExpress.XtraGrid.GridControl();
            this.gvCart = new DevExpress.XtraGrid.Views.Grid.GridView();

            this.lblSub = new DevExpress.XtraEditors.LabelControl();
            this.lblTax = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();

            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();


            // ================= TOP =================

            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;

            this.txtSearch.Location = new System.Drawing.Point(20, 18);
            this.txtSearch.Width = 350;
         //   this.txtSearch.NullText = "Search product...";

            this.panelTop.Controls.Add(this.txtSearch);


            // ================= LEFT =================

            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 650;


            this.gridProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProduct.MainView = this.gvProduct;

            this.panelLeft.Controls.Add(this.gridProduct);


            // ================= PRODUCT GRID =================

        // this.gvProduct.OptionsView.RowHeight = 90;
            this.gvProduct.OptionsView.ShowGroupPanel = false;
            this.gvProduct.OptionsBehavior.Editable = false;


            // ================= RIGHT =================

            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;


            this.gridCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridCart.Height = 350;
            this.gridCart.MainView = this.gvCart;

            this.panelRight.Controls.Add(this.gridCart);


            // ================= CART GRID =================

            this.gvCart.OptionsView.ShowGroupPanel = false;
            this.gvCart.OptionsBehavior.Editable = false;


            // ================= TOTAL =================

            this.lblSub.Location = new System.Drawing.Point(20, 370);
            this.lblSub.Text = "Subtotal : $0.00";

            this.lblTax.Location = new System.Drawing.Point(20, 400);
            this.lblTax.Text = "Tax (10%) : $0.00";

            this.lblTotal.Appearance.Font =
                new System.Drawing.Font("Segoe UI", 14,
                System.Drawing.FontStyle.Bold);

            this.lblTotal.Location = new System.Drawing.Point(20, 430);
            this.lblTotal.Text = "Total : $0.00";


            // ================= BUTTON =================

            this.btnPay.Location = new System.Drawing.Point(20, 480);
            this.btnPay.Size = new System.Drawing.Size(180, 45);
            this.btnPay.Text = "PAY";


            this.btnClear.Location = new System.Drawing.Point(220, 480);
            this.btnClear.Size = new System.Drawing.Size(180, 45);
            this.btnClear.Text = "CLEAR";


            this.panelRight.Controls.Add(this.lblSub);
            this.panelRight.Controls.Add(this.lblTax);
            this.panelRight.Controls.Add(this.lblTotal);

            this.panelRight.Controls.Add(this.btnPay);
            this.panelRight.Controls.Add(this.btnClear);


            // ================= BOTTOM =================

            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 25;


            // ================= FORM =================

            this.ClientSize = new System.Drawing.Size(1300, 720);

            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Coffee POS System";

        }

        #endregion
    }
}
