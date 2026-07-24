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

            // Dashboard menu — added in code so the Designer stays untouched.
            // Visible to any logged-in user; the api/Report/dashboard endpoint
            // itself requires a valid token.
            //var mnuDashboard = new ToolStripMenuItem("Dashboard");
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
                toolStripMenuItem2.Visible = Has("PRODUCT");        // "Create Product" item
                toolStripMenuItem3.Visible = Has("USER");           // "Create User" item
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
                purchaseOrderToolStripMenuItem.Visible = Has("PURCHASE_ORDER") || Has("OUTLET_ORDER");

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
            var frm = new unt_bingoo.view.Product.cboProduct { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
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

        private void vatSittingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiVateSetting { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
            
        }
    }
}
