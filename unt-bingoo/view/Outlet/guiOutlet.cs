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

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutlet : DevExpress.XtraEditors.XtraForm
    {
        public guiOutlet()
        {
            InitializeComponent();
        }
        private BindingList<OutletItem> _outletList = new BindingList<OutletItem>();

        private void guiOutlet_Load(object sender, EventArgs e)
        {
            gridControlOutlet.DataSource = _outletList;
            _outletList.Add(new OutletItem
            {
                OutletCode = "O001",
                OutletName = "Phnom Penh Outlet",
                ProvinceCity = "Phnom Penh",
                Address = "Street 123",
                Phone = "012345678",
                Manager = "Mr. A",
                HeadOffice = true,
                Active = true
            });

            _outletList.Add(new OutletItem
            {
                OutletCode = "O002",
                OutletName = "Kampot Outlet",
                ProvinceCity = "Kampot",
                Address = "Road 33",
                Phone = "098765432",
                Manager = "Ms. B",
                HeadOffice = false,
                Active = true
            });

            gridViewOutlet.BestFitColumns();
            lblCountRow.Text = $"Count Row: {_outletList.Count}";
        }
    }
}