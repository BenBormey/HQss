using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.view.Product;
using unt_bingoo.view.Outlet;
using unt_bingoo.view.currency;
using unt_bingoo.view.User;

using unt_bingoo.view.Category;
using unt_bingoo.view.Branch;
using unt_bingoo.view.Customer;
using unt_bingoo.view.Supplier;
using unt_bingoo.Controller;
using DevExpress.XtraEditors;
using unt_bingoo.Class;
using unt_bingoo.view.Vat;

namespace unt_bingoo.view
{
    public partial class mainForm : Form
    {
        private int childFormNumber = 0;
        private readonly APIsController _api;
        public mainForm()
        {
            InitializeComponent();
            this._api = APIGlobals.Api ?? new APIsController();
            ApplyMenuIcons();

            // Dashboard menu — added in code so the Designer stays untouched.
            //
            // Left disabled on purpose: the dashboard screen is not in use yet.
            // Note before enabling it — api/Report/dashboard only requires
            // [Authorize], while api/Report/sales requires the SALE_REPORT
            // permission, so any logged-in user could read the revenue figures
            // this screen shows. Gate the endpoint first, then uncomment.
            //var mnuDashboard = new ToolStripMenuItem("Dashboard");
            //mnuDashboard.Image = MenuIcons.BarChart(Color.FromArgb(39, 174, 96));
            //mnuDashboard.Click += (s, e) =>
            //{
            //    var frm = new Dashboard.guiDashboard()
            //    {
            //        MdiParent = this,
            //        WindowState = FormWindowState.Maximized,
            //        StartPosition = FormStartPosition.CenterScreen
            //    };
            //    frm.Show();
            //};
            //menuStrip.Items.Insert(1, mnuDashboard);
        }

        // Added in code so the Designer stays untouched — assigns a small
        // GDI+-drawn icon (Class/MenuIcons.cs) to every top-level and
        // sub-menu item. Drawn shapes rather than an icon-font glyph:
        // a wrong/guessed font codepoint renders as an empty box on a
        // machine without that exact font, shapes always render the same.
        private void ApplyMenuIcons()
        {
            var blue = Color.FromArgb(0, 120, 215);
            var gray = Color.FromArgb(108, 117, 125);
            var orange = Color.FromArgb(230, 126, 34);
            var green = Color.FromArgb(39, 174, 96);
            var brown = Color.FromArgb(139, 94, 52);
            var gold = Color.FromArgb(200, 155, 15);
            var purple = Color.FromArgb(142, 68, 173);
            var steelBlue = Color.FromArgb(52, 152, 219);
            var indigo = Color.FromArgb(94, 66, 204);
            var red = Color.FromArgb(192, 57, 43);
            var amber = Color.FromArgb(211, 146, 0);
            var teal = Color.FromArgb(22, 160, 133);
            var magenta = Color.FromArgb(194, 24, 91);
            var navy = Color.FromArgb(44, 62, 80);
            var cyan = Color.FromArgb(0, 151, 167);
            var slate = Color.FromArgb(96, 125, 139);
            var darkRed = Color.FromArgb(211, 47, 47);
            var cocoa = Color.FromArgb(121, 85, 72);

            // Top-level menu bar
            mnufile.Image = MenuIcons.Folder(blue);
            menuItemToolStripMenuItem.Image = MenuIcons.Gear(gray);
            purchaseOrderToolStripMenuItem.Image = MenuIcons.Cart(orange);
            reportToolStripMenuItem.Image = MenuIcons.BarChart(green);
            stockTransferToolStripMenuItem.Image = MenuIcons.Box(brown);

            // File
            toolStripMenuItem6.Image = MenuIcons.Coin(gold);          // Exchange Rate
            toolStripSeparator2.Image = MenuIcons.Coin(gold);         // Create Currency (misnamed field — it's a menu item, not a separator)
            vatSittingToolStripMenuItem.Image = MenuIcons.Coin(gold); // VatSetting
            paymentToolStripMenuItem.Image = MenuIcons.Tag(purple);   // Create Category
            supplierToolStripMenuItem.Image = MenuIcons.Truck(steelBlue); // Create Supplier
            toolStripMenuItem2.Image = MenuIcons.Box(brown);          // Create Product
            toolStripMenuItem3.Image = MenuIcons.Person(indigo);      // Create User
            toolStripMenuItem7.Image = MenuIcons.Tag(purple);         // Brand
            toolStripMenuItem8.Image = MenuIcons.Truck(steelBlue);    // Suppliers
            mnuPermission.Image = MenuIcons.Shield(red);              // Permission
            mnuchangepassword.Image = MenuIcons.Key(amber);           // Change Password
            reciptToolStripMenuItem.Image = MenuIcons.Box(brown);     // Create Product (Sell)
            mnuSaleReport.Image = MenuIcons.BarChart(green);          // Sale Report
            mnuOutletOrderApproval.Image = MenuIcons.Store(teal);     // Outlet Order Approval
            mnuFranchisePriceList.Image = MenuIcons.Tag(purple);      // Franchise Price List
            createUserProfileToolStripMenuItem.Image = MenuIcons.Person(indigo); // Create User Profile
            mnuexit.Image = MenuIcons.ExitDoor(darkRed);              // Exit

            // Setup
            setupOutletMenuToolStripMenuItem.Image = MenuIcons.Store(teal); // Outlet Menu
            setupBankMenuToolStripMenuItem.Image = MenuIcons.Bank(navy);    // Bank Menu
            outLetToolStripMenuItem.Image = MenuIcons.Store(teal);         // OutLet
            customerToolStripMenuItem1.Image = MenuIcons.PeopleGroup(magenta); // Customer

            // Purchase Order
            createPurchaseOrderToolStripMenuItem.Image = MenuIcons.Cart(orange); // Purchase Order
            createRecipeToolStripMenuItem.Image = MenuIcons.Recipe(cocoa);       // Recipe / BOM

            // Report
            supplierReportToolStripMenuItem.Image = MenuIcons.BarChart(green); // Supplier Report

            // Stock
            setProductToOutletToolStripMenuItem1.Image = MenuIcons.ArrowsExchange(cyan); // SetProductTo_Outlet
            stockTransferToolStripMenuItem1.Image = MenuIcons.ArrowsExchange(cyan);      // Stock Transfer
            stockTransferHistoryToolStripMenuItem.Image = MenuIcons.Clock(slate);        // Stock Transfer History
            readinessCheckToolStripMenuItem.Image = MenuIcons.Check(green);              // Readiness Check
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmProductsSearch(this) { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void outLetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiOutlet() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
            
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           var frm = new guiExchange() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiUser() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void userRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiUserrole() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void reportSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

          
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var frm = new guiUser() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void guiBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiBranch() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void salerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void customerFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                var frm = new guiCustomer() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void mnuchangepassword_Click(object sender, EventArgs e)
        {
       
            var frm = new guiChangePassword() { StartPosition = FormStartPosition.CenterScreen };
            frm.Show();

        }

        private void mnuexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new guiProductStock() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            //frm.Show();

        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new Sale() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            //frm.Show();
        }

        private void reportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

                  var frm = new guiSuppliers() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();

        }

        private void mnuSupplierPayment_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.Purchase.guiSupplierPayments
            { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private async void mainForm_Load(object sender, EventArgs e)
        {
            await ApplyPermissionsAsync();
        }

        // Hide menu items the logged-in user's role has no permission for.
        // MD (ADMIN) always sees everything.
        private async Task ApplyPermissionsAsync()
        {
            try
            {
                if (APIGlobals.RoleCode == "ADMIN")
                    return;

                var permissions = await _api.GetMyPermissionsAsync();
                APIGlobals.Permissions = permissions;

                bool Has(string code) => permissions.Contains(code);

                // File menu
                toolStripMenuItem6.Visible = Has("EXCHANGE_RATE");
                toolStripSeparator2.Visible = Has("CURRENCY");      // "Create Currency" item
                vatSittingToolStripMenuItem.Visible = Has("VAT_SETTING");
                paymentToolStripMenuItem.Visible = Has("CATEGORY"); // "Create Category" item
                supplierToolStripMenuItem.Visible = Has("SUPPLIER");
                // Both product screens sit behind the same PRODUCT permission.
                // "Products" was ungated while "Products (Advanced Details)"
                // was, so a user without PRODUCT still saw a way in.
                toolStripMenuItem2.Visible = Has("PRODUCT");        // "Products (Advanced Details)"
                reciptToolStripMenuItem.Visible = Has("PRODUCT");   // "Products"
                toolStripMenuItem3.Visible = Has("USER");           // "Users" item
                mnuPermission.Visible = Has("PERMISSION");

                // Setup menu
                setupOutletMenuToolStripMenuItem.Visible = Has("OUTLET_MENU");
                setupBankMenuToolStripMenuItem.Visible = Has("BANK_MENU");
                outLetToolStripMenuItem.Visible = Has("OUTLET");
                customerToolStripMenuItem1.Visible = Has("CUSTOMER");
                menuItemToolStripMenuItem.Visible =
                    Has("OUTLET_MENU") || Has("BANK_MENU") || Has("OUTLET") || Has("CUSTOMER");

                // Purchase Order menu
                createPurchaseOrderToolStripMenuItem.Visible = Has("PURCHASE_ORDER");
                mnuOutletOrderApproval.Visible = Has("OUTLET_ORDER");
                mnuFranchisePriceList.Visible = Has("OUTLET_ORDER");
                // The RECIPE permission has existed since add_recipe_permission.sql
                // but nothing was ever wired to it, so "Recipes (BOM)" showed for
                // everyone regardless.
                createRecipeToolStripMenuItem.Visible = Has("RECIPE");
                //setProductToOutletToolStripMenuItem.Visible = Has("OUTLET_STOCK");
                // RECIPE included, or a user granted only that would have the
                // item hidden behind a parent menu they can't see.
                purchaseOrderToolStripMenuItem.Visible = Has("PURCHASE_ORDER") || Has("OUTLET_ORDER")
                                                      || Has("OUTLET_STOCK") || Has("RECIPE");

                // Report menu
                supplierReportToolStripMenuItem.Visible = Has("SUPPLIER_REPORT");
                mnuSaleReport.Visible = Has("SALE_REPORT");
                reportToolStripMenuItem.Visible = Has("SUPPLIER_REPORT") || Has("SALE_REPORT");
            }
            catch
            {
                // If permissions can't load, leave menus as-is rather than locking the user out.
            }
        }

        private void mnuOutletOrderApproval_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiOutletOrderApproval() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void mnuFranchisePriceList_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiFranchisePriceList() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void setProductToOutletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiAssignStock() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiStockTransfer() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void stockTransferHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiStockTransferHistory() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void outletReadinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Outlet.guiOutletReadiness() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void mnuSaleReport_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.Report.guiSaleReport() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void mnuPermission_Click(object sender, EventArgs e)
        {
            if (APIGlobals.RoleCode != "ADMIN")
            {
                XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new guiPermission() { StartPosition = FormStartPosition.CenterScreen };
            frm.ShowDialog(this);
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guiFranchiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

                     var frm = new guiFranchise() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new guiCategory() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();


        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.Supplier.guiSupplierSetup() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void createUserProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.User.guiUserProfile() { StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {
            var frm = new guiCurencys { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void menuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

               
        }

        private void setupOutletMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.Product.SetupOutletMenu { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void createSellProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.Product.guiCreateProduct { MdiParent = this };
            frm.Show();
        }

        private void setupBankMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var frm = new unt_bingoo.view.Bank.BankSetup { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void supplierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiSupplier { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
            
        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiCustomer { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();

        }

        private void createPurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.PurchaseOrder.guiPurchaseOrder { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void createRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new unt_bingoo.view.Product.guiRecipes { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void vatSittingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiVateSetting { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
            
        }

        private void reciptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
