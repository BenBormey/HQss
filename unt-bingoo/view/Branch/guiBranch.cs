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

namespace unt_bingoo.view.Branch
{
    public partial class guiBranch : DevExpress.XtraEditors.XtraForm
    {
     
        private BindingList<BranchItem> _branchList = new BindingList<BranchItem>();

        public guiBranch()
        {
            InitializeComponent();

            // ចង DataSource ម្តង នៅ constructor
            gridBranch.DataSource = _branchList;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guiBranch_Load(object sender, EventArgs e)
        {
            _branchList.Add(new BranchItem
            {
                BranchCode = "B001",
                BranchName = "Phnom Penh Branch",
                Phone = "012345678",
                Province = "Phnom Penh",
                Address = "Street 123",
                MainBranch = true,
                Active = true,
                Remark = "Head office"
            });

            _branchList.Add(new BranchItem
            {
                BranchCode = "B002",
                BranchName = "Kampot Branch",
                Phone = "098765432",
                Province = "Kampot",
                Address = "Road 33",
                MainBranch = false,
                Active = true,
                Remark = "New branch"
            });

            gvBranch.BestFitColumns();
        }
    }
    
}