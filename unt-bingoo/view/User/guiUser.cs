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
    public partial class guiUser : DevExpress.XtraEditors.XtraForm
    {
        public guiUser()
        {
            InitializeComponent();
        }
        private BindingList<UserItem> _userList = new BindingList<UserItem>();

        private void guiUser_Load(object sender, EventArgs e)
        {
            gridControlUser.DataSource = _userList;

            // Sample Data for Testing UI
            _userList.Add(new UserItem
            {
                UserName = "admin",
                FullName = "Administrator",
                FullNameKh = "អេដមីន",
                Role = "Admin",
                Outlet = "Phnom Penh",
                Address = "Street 123",
                AddressKh = "ផ្លូវ ១២៣",
                Phone = "012345678",
                Email = "admin@gmail.com",
                Active = true,
                Locked = false
            });

            _userList.Add(new UserItem
            {
                UserName = "cash001",
                FullName = "Cashier",
                FullNameKh = "អ្នកគិតលុយ",
                Role = "Cashier",
                Outlet = "Kampot",
                Address = "Road 33",
                AddressKh = "ផ្លូវ ៣៣",
                Phone = "098765432",
                Email = "cash@gmail.com",
                Active = true,
                Locked = false
            });

            gridViewUser.BestFitColumns();
            lblCountRow.Text = $"Count : {_userList.Count}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _userList.Add(new UserItem
            {
                UserName = txtUserName.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                FullNameKh = txtFullNameKh.Text.Trim(),
                Role = cboRole.Text.Trim(),
                Outlet = cboOutlet.Text.Trim(),
                Address = txtaddress.Text.Trim(),
                AddressKh = txtAddressKh.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Active = chkActive.Checked,
                Locked = chkLocked.Checked
            });

            gridViewUser.BestFitColumns();
            lblCountRow.Text = $"Count : {_userList.Count}";
        }
    }
}