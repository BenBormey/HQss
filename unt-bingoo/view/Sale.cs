using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view
{
    public partial class Sale : XtraForm
    {
        private APIsController _api;

        private BindingList<ProductItem> _products =
            new BindingList<ProductItem>();

        private BindingList<SaleItem> _cart =
            new BindingList<SaleItem>();


        public Sale()
        {
            InitializeComponent();
            _api = APIGlobals.Api;
        }


       
        private async void Sale_Load(object sender, EventArgs e)
        {
            try
            {
                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                await LoadProduct();

                gridProduct.DataSource = _products;
                gridCart.DataSource = _cart;

                gvProduct.DoubleClick += gvProduct_DoubleClick;

                txtSearch.EditValueChanged += txtSearch_EditValueChanged;

                btnClear.Click += btnClear_Click;
                btnPay.Click += btnPay_Click;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        // ================= LOAD PRODUCT =================

        private async Task LoadProduct()
        {
            var list =
                await _api.GetAsync<List<ProductItem>>("api/Product");

            _products =
                new BindingList<ProductItem>(list);
        }


        // ================= ADD TO CART =================

        private void gvProduct_DoubleClick(object sender, EventArgs e)
        {
            var row = gvProduct.GetFocusedRow() as ProductItem;

            if (row == null) return;

            AddToCart(row);
        }


        private void AddToCart(ProductItem p)
        {
            //var item =
            //    _cart.FirstOrDefault(x => x.ProductID == p.ProductID);

            //if (item != null)
            //{
            //    item.Qty++;
            //}
            //else
            //{
            //    _cart.Add(new SaleItem()
            //    {
            //        //ProductID = p.ProductID,
            //        //ProductName = p.ProductName,
            //        //Price = p.SellingPrice,
            //        //Qty = 1
            //    });
            //}

            gridCart.RefreshDataSource();

            CalculateTotal();
        }


        // ================= TOTAL =================

        private void CalculateTotal()
        {
            decimal sub = _cart.Sum(x => x.Total);

            decimal tax = sub * 0.1m; // 10%

            decimal total = sub + tax;

            lblSub.Text = "Subtotal : $" + sub.ToString("0.00");
            lblTax.Text = "Tax (10%) : $" + tax.ToString("0.00");
            lblTotal.Text = "Total : $" + total.ToString("0.00");
        }


        // ================= SEARCH =================

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            gvProduct.FindFilterText = txtSearch.Text;
        }


        // ================= CLEAR =================

        private void btnClear_Click(object sender, EventArgs e)
        {
            _cart.Clear();
            CalculateTotal();
        }


        // ================= PAY =================

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                XtraMessageBox.Show("Cart is empty!");
                return;
            }

            XtraMessageBox.Show("Payment Success!");

            _cart.Clear();

            CalculateTotal();
        }

    }
}
