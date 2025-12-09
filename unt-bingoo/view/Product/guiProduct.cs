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
using unt_bingoo.view.Branch;
using unt_bingoo.view.Category;

namespace unt_bingoo.view.Product
{
    public partial class guiProduct : DevExpress.XtraEditors.XtraForm
    {
        public guiProduct()
        {
            InitializeComponent();
        }

        private void guiProduct_Load(object sender, EventArgs e)
        {

        }

        private void picCustomer_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Filter to allow image files
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
              
                string filePath = openFileDialog.FileName;

      
                picCustomer.ImageLocation = filePath;



            }
        }

        private void btnaddBrand_Click(object sender, EventArgs e)
        {
            using (var f = new guiCategory())        
            {
                f.StartPosition = FormStartPosition.CenterParent;
                var result = f.ShowDialog(this);   

              
                if (result == DialogResult.OK)
                {
                   // LoadCategoryCombo();            
                }
            }
        }

        private void btnaddCategory_Click(object sender, EventArgs e)
        {
            using (var f = new guiBranch())       
            {
                f.StartPosition = FormStartPosition.CenterParent;
                var result = f.ShowDialog(this);    


                if (result == DialogResult.OK)
                {
                         
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private BindingList<ProductItem> _productList = new BindingList<ProductItem>();

    

        private void guiProduct_Load_1(object sender, EventArgs e)
        {
            gridProduct.DataSource = _productList;
            _productList.Add(new ProductItem
            {
                ProductCode = "P001",
                ProductName = "Coca Cola",
                Category = "Drink",
                Brand = "Coca Cola",
                Size = "330ml",
                Cost = 1500,
                Price = 2000,
                VatPercent = 10,
                Qty = 50,
                Supplier = "Supplier A",
                Active = true
            });

            _productList.Add(new ProductItem
            {
                ProductCode = "P002",
                ProductName = "Snack Chips",
                Category = "Snack",
                Brand = "Lays",
                Size = "50g",
                Cost = 1000,
                Price = 1500,
                VatPercent = 10,
                Qty = 80,
                Supplier = "Supplier B",
                Active = true
            });

            gvProduct.BestFitColumns();
            lblCount.Text = $"Count : {_productList.Count}";
        }

    }
    
}