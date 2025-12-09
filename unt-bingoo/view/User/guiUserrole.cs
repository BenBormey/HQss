using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;

namespace unt_bingoo.view.User
{
    public partial class guiUserrole : DevExpress.XtraEditors.XtraForm
    {
        public guiUserrole()
        {
            InitializeComponent();
        }
        private BindingList<RoleItem> _roleList = new BindingList<RoleItem>();


        private void guiUserrole_Load(object sender, EventArgs e)
        {
            gridControlRole.DataSource = _roleList;

            // Add Sample Data for Testing
            _roleList.Add(new RoleItem
            {
                RoleCode = "ADM",
                RoleName = "Administrator",
                Description = "Full access to system",
                SystemRole = true,
                Active = true
            });

            _roleList.Add(new RoleItem
            {
                RoleCode = "USR",
                RoleName = "Normal User",
                Description = "Limited access",
                SystemRole = false,
                Active = true
            });

            // Auto fit columns
            gridViewRole.BestFitColumns();

            // Count Row show at the bottom
            lblCountRow.Text = $"Count Row : {_roleList.Count}";
        }
    }
}