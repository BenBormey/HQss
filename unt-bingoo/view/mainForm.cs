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

namespace unt_bingoo.view
{
    public partial class mainForm : Form
    {
        private int childFormNumber = 0;
        private readonly APIsController _api;
        public mainForm()
        {
            InitializeComponent();
            this._api = new APIsController();
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
       
            var frm = new guiChangePassword() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
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
            var frm = new guiProductStock() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();

        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Sale() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
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
       
        bool login_=    await _api.LoginAsync("admin", "123");
            if (!login_)
            {
                await _api.LoginAsync("bormey", "12345678");
            }

       


            APIGlobals.Api = _api;
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
            var frm = new unt_bingoo.view.Supplier.Form1() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void createUserProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
