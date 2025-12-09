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
using unt_bingoo.view.Report;
using unt_bingoo.view.Category;
using unt_bingoo.view.Branch;
using unt_bingoo.view.Sales;
using unt_bingoo.view.Customer;

namespace unt_bingoo.view
{
    public partial class mainForm : Form
    {
        private int childFormNumber = 0;

        public mainForm()
        {
            InitializeComponent();
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
            var frm = new guiProduct() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void outLetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiOutlet() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
            
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           var frm = new guiCurency() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
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
            

                  var frm = new guiReportSale() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var frm = new guiCategory() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void guiBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new guiBranch() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void salerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

                var frm = new guiforSale() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }

        private void customerFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                var frm = new guiCustomer() { MdiParent = this, WindowState = FormWindowState.Maximized, StartPosition = FormStartPosition.CenterScreen };
            frm.Show();
        }
    }
}
