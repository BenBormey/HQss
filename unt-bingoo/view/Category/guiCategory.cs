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

namespace unt_bingoo.view.Category
{
    public partial class guiCategory : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<CategoryItem> _categoryList = new BindingList<CategoryItem>();

        public guiCategory()
        {
            InitializeComponent();

            // ចង datasource ម្តង
            gridCategory.DataSource = _categoryList;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void guiCategory_Load(object sender, EventArgs e)
        {
            _categoryList.Add(new CategoryItem
            {
                CategoryCode = "C001",
                CategoryName = "Beverage",
                Remark = "Drink items",
                Active = true
            });

            _categoryList.Add(new CategoryItem
            {
                CategoryCode = "C002",
                CategoryName = "Snack",
                Remark = "Snack items",
                Active = true
            });

            gvCategory.BestFitColumns();
        }
    }
    
}