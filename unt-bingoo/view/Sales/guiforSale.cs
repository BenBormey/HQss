using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using unt_bingoo.view.Report;

namespace unt_bingoo.view.Sales
{
    public partial class guiforSale : XtraForm
    {
        private APIsController _api;

        private BindingList<ProductPosDto> _productList =
            new BindingList<ProductPosDto>();

        private BindingList<OrderItemVM> _orderList =
            new BindingList<OrderItemVM>();

        private int? _currentCategoryId = null;
        private int _currentCartId = 0;

        public guiforSale()
        {
            InitializeComponent();

            this.Load += guiforSale_Load;
         
            gvOrder.CellValueChanged += gvOrder_CellValueChanged;
            btnClearOrder.Click += btnClearOrder_Click;
        }

    

        private async void guiforSale_Load(object sender, EventArgs e)
        {
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                await LoadCategory();
                await LoadProducts();

                gridMenu.DataSource = _productList;
                gridOrder.DataSource = _orderList;

                SetupTileView();
                RecalculateTotals();
                await LoadingCart();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

  

        private async Task LoadCategory()
        {
            var categories =
                await _api.GetAsync<List<CategoryItem>>("api/category");

            categoryButtonsPanel.Controls.Clear();

            CreateCategoryButton("All Menu", null);

            foreach (var c in categories)
            {
                CreateCategoryButton(c.CategoryName, c.Id);
            }
        }

        private void CreateCategoryButton(string text, int? categoryId)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Width = 130;
            btn.Height = 45;
            btn.Tag = categoryId;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Click += Category_Click;

            categoryButtonsPanel.Controls.Add(btn);
        }

        private async void Category_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            _currentCategoryId = btn.Tag as int?;
            HighlightCategory(btn);
            await LoadProducts();
        }

        private void HighlightCategory(Button selected)
        {
            foreach (Control c in categoryButtonsPanel.Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.BackColor = Color.White;
                    b.ForeColor = Color.Black;
                }
            }

            selected.BackColor = Color.DodgerBlue;
            selected.ForeColor = Color.White;
        }



        private async Task LoadProducts()
        {
            string url = "api/Product/pos";

            if (_currentCategoryId != null)
                url += "?categoryId=" + _currentCategoryId;

            var list =
                await _api.GetAsync<List<ProductPosDto>>(url);

            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.ImageUrl) &&
                    Uri.IsWellFormedUriString(item.ImageUrl, UriKind.Absolute))
                {
                    item.ProductImage =
                        await LoadImage(item.ImageUrl);
                }
            }

            _productList =
                new BindingList<ProductPosDto>(list);

            gridMenu.DataSource = _productList;
        }

        private async Task<Image> LoadImage(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] data =
                        await client.GetByteArrayAsync(url);

                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                return null;
            }
        }



        private void SetupTileView()
        {
            tileMenu.BeginUpdate();

            // ===== SIZE (square) =====
            tileMenu.OptionsTiles.ItemSize = new Size(150, 150);
            tileMenu.OptionsTiles.RowCount = 3;

            tileMenu.OptionsTiles.Padding = new Padding(5);
            tileMenu.OptionsTiles.IndentBetweenItems = 5;

            // ===== CLEAR =====
            tileMenu.TileTemplate.Clear();
            tileMenu.TileRows.Clear();
            tileMenu.TileColumns.Clear();

            // ===== DEFINE LAYOUT (NO Percent ❌) =====
            tileMenu.TileColumns.Add(
                new DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
            );

            // Image row
            tileMenu.TileRows.Add(
                new DevExpress.XtraEditors.TableLayout.TableRowDefinition()
                {
                    Length = new DevExpress.XtraEditors.TableLayout.TableDefinitionLength(80)
                });

            // Name row
            tileMenu.TileRows.Add(
                new DevExpress.XtraEditors.TableLayout.TableRowDefinition()
                {
                    Length = new DevExpress.XtraEditors.TableLayout.TableDefinitionLength(35)
                });

            // Price row
            tileMenu.TileRows.Add(
                new DevExpress.XtraEditors.TableLayout.TableRowDefinition()
                {
                    Length = new DevExpress.XtraEditors.TableLayout.TableDefinitionLength(30)
                });

            // ===== IMAGE =====
            TileViewItemElement img = new TileViewItemElement();
            img.Column = tileMenu.Columns["ProductImage"];
            img.RowIndex = 0;
            img.ColumnIndex = 0;
            img.ImageOptions.ImageScaleMode =
                DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            img.ImageAlignment =
                DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;

            // ===== NAME =====
            TileViewItemElement name = new TileViewItemElement();
            name.Column = tileMenu.Columns["ProductName"];
            name.RowIndex = 1;
            name.ColumnIndex = 0;
            name.TextAlignment =
                DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            name.Appearance.Normal.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            // ===== PRICE =====
            TileViewItemElement price = new TileViewItemElement();
            price.Column = tileMenu.Columns["SellingPrice"];
            price.RowIndex = 2;
            price.ColumnIndex = 0;
            price.Text = "USD {0:0.00}";
            price.TextAlignment =
                DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            price.Appearance.Normal.ForeColor = Color.Green;
            price.Appearance.Normal.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            // ===== ADD TO TEMPLATE =====
            tileMenu.TileTemplate.Add(img);
            tileMenu.TileTemplate.Add(name);
            tileMenu.TileTemplate.Add(price);

            tileMenu.EndUpdate();
        }
        private async void tileMenu_ItemClick(
            object sender,
            TileViewItemClickEventArgs e)
        {
            ProductPosDto row =
                tileMenu.GetRow(e.Item.RowHandle) as ProductPosDto;

            if (row == null) return;

            OrderItemVM exist =
                _orderList.FirstOrDefault(x => x.ProductID == row.ProductID);


            if (exist != null)
            {
                int newQty = exist.Qty + 1;

                var updateReq = new
                {
                    cartId = exist.CartID,
                    productId = row.ProductID,
                    quantity = newQty
                };

                bool okUpdate = await _api.PutAsync(
                    "api/Cart/update",
                    updateReq);

                if (!okUpdate)
                {
                    XtraMessageBox.Show("Update cart failed!");
                    return;
                }
            }

            else
            {
                CartVM req = new CartVM
                {
                    UserId = APIGlobals.UserId,
                    OutletId = APIGlobals.OutletId,
                    ProductId = row.ProductID,
                    Quantity = 1,
                    UnitPrice = row.SellingPrice,
                    DiscountPercent = row.DiscountPercent,
                    TaxPercent = row.TaxPercent
                };

                bool okAdd = await _api.PostAsync(
                    "api/Cart/add",
                    req);

                if (!okAdd)
                {
                    XtraMessageBox.Show("Cannot add to cart!");
                    return;
                }
            }

            await LoadingCart();
        }

        public async Task LoadingCart()
        {
            var cart =
                await _api.GetAsync<CartResponseVM>(
                    "api/Cart/" + APIGlobals.UserId);

            _orderList.Clear();

            if (cart == null || cart.CartItems == null)
                return;

            foreach (var i in cart.CartItems)
            {
                var p =
                    _productList.FirstOrDefault(
                        x => x.ProductID == i.ProductID);

                _orderList.Add(new OrderItemVM
                {
                    CartID = i.CartID,
                    CartItemID = i.CartItemID,
                    ProductID = i.ProductID,
                    Item = p != null ? p.ProductName : "Unknown",
                    Qty = i.Quantity,
                    Price = i.UnitPrice,
                    Amount = i.TotalPrice
                });
            }

            gridOrder.RefreshDataSource();

            lblSubTotal.Text = cart.SubTotal.ToString("0.00");
            lblDiscount.Text = cart.DiscountAmount.ToString("0.00");
            lblTotal.Text = cart.GrandTotal.ToString("0.00");
        }

        private async void btnmainDecrease_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OrderItemVM row =
                    gvOrder.GetFocusedRow() as OrderItemVM;

                if (row == null)
                {
                    XtraMessageBox.Show("Please select item first!");
                    return;
                }

                int newQty = row.Qty - 1;
                if (newQty < 0) return;

                var req = new
                {
                    cartId = row.CartID,
                    productId = row.ProductID,
                    quantity = newQty
                };

                bool ok = await _api.PutAsync(
                    "api/Cart/update", req);

                if (!ok)
                {
                    XtraMessageBox.Show("Update failed!");
                    return;
                }

                if (newQty == 0)
                {
                    _orderList.Remove(row);
                }
                else
                {
                    row.Qty = newQty;
                    row.Amount = row.Qty * row.Price;
                }

                gvOrder.RefreshData();
                RecalculateTotals();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        private async void btnCancel_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvOrder.FocusedRowHandle < 0)
                return;

            OrderItemVM row =
                gvOrder.GetRow(gvOrder.FocusedRowHandle) as OrderItemVM;

            if (row == null)
                return;

            bool ok = await _api.DeleteAsync(
                "api/Cart/remove/" + row.CartItemID);

            if (!ok)
            {
                XtraMessageBox.Show("Failed to remove item");
                return;
            }

            _orderList.Remove(row);
            gvOrder.RefreshData();
            await LoadingCart();
            RecalculateTotals();
        }



        private void gvOrder_CellValueChanged(
            object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;

            OrderItemVM row =
                gvOrder.GetRow(e.RowHandle) as OrderItemVM;

            if (row == null) return;

            row.Amount = row.Qty * row.Price;
            gvOrder.RefreshRow(e.RowHandle);
            RecalculateTotals();
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            _orderList.Clear();
            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            decimal sub = _orderList.Sum(x => x.Amount);

            lblSubTotal.Text = sub.ToString("0.00");
            lblDiscount.Text = "0.00";
            lblTotal.Text = sub.ToString("0.00");
        }

        private async void btnContinuePayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderList.Count == 0)
                {
                    XtraMessageBox.Show("Cart is empty!");
                    return;
                }

                decimal subtotal = decimal.Parse(lblSubTotal.Text);
                decimal discount = decimal.Parse(lblDiscount.Text);
                decimal total = decimal.Parse(lblTotal.Text);

                var paymentForm = new frmPayment(
                    _orderList,
                    subtotal,
                    discount,
                    total,
                    ""
                );

                var result = paymentForm.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                string paymentMethod = paymentForm.PaymentMethod;
                decimal cashReceived = paymentForm.CashReceived;

                int cartId = _orderList.First().CartID;

          
                var checkout = await _api.PostAsync<CheckoutResponse>(
                    "api/Order/checkout/" + cartId,
                    new { });

                if (checkout == null)
                {
                    XtraMessageBox.Show("Checkout failed!");
                    return;
                }

                int orderId = checkout.OrderId;

                bool paymentSuccess = false;

             
                if (paymentMethod == "Cash")
                {
                    var paymentReq = new CashPaymentDto
                    {
                        OrderId = orderId,
                        Amount = total,
                        CashReceived = cashReceived
                    };

                    paymentSuccess = await _api.PostAsync(
                        "api/Payment/cash",
                        paymentReq);
                }

        
                if (paymentMethod == "KHQR")
                {
                    var qr = await _api.PostAsync<QrResponse>(
                        "api/Payment/khqr",
                        new KHQRRequestDto
                        {
                            OrderId = orderId,
                            Amount = total
                        });

                    if (qr == null)
                    {
                        XtraMessageBox.Show("Cannot generate QR");
                        return;
                    }

                
                    frmQR qrForm = new frmQR(qr.QR);
                    qrForm.ShowDialog();

                    paymentSuccess = await _api.PostAsync(
                        "api/Payment/qr/confirm",
                        new QrConfirmDto
                        {
                            OrderId = orderId,
                            Amount = total,
                            TransactionNo = Guid.NewGuid().ToString()
                        });
                }

                if (!paymentSuccess)
                {
                    XtraMessageBox.Show("Payment failed!");
                    return;
                }

                decimal change = cashReceived - total;

                XtraMessageBox.Show("Payment success!");

                PrintReceipt(
                    orderId.ToString(),
                    subtotal,
                    discount,
                    total,
                    cashReceived,
                    change,
                    paymentMethod
                );

                _orderList.Clear();
                gridOrder.RefreshDataSource();

                lblSubTotal.Text = "0.00";
                lblDiscount.Text = "0.00";
                lblTotal.Text = "0.00";

                await LoadingCart();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void PrintReceipt(
    string invoiceNo,
    decimal subtotal,
    decimal discount,
    decimal total,
    decimal cash,
    decimal change,
    string paymentMethod)
        {
            try
            {
                rptReceipt rpt = new rptReceipt();

        
                rpt.SetData(
                    invoiceNo,
                    subtotal,
                    discount,
                    total,
                    cash,
                    change,
                    paymentMethod
                );

          
                foreach (var item in _orderList)
                {
                    rpt.AddItem(
                        item.Item,
                        item.Qty,
                        item.Price,
                        item.Amount
                    );
                }

 
                ReportPrintTool tool = new ReportPrintTool(rpt);

                tool.ShowPreview();

   
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
