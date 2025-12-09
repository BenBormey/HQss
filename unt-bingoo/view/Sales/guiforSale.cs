using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using DevExpress.XtraEditors.TableLayout;

namespace unt_bingoo.view.Sales
{
    public partial class guiforSale : XtraForm
    {
        private BindingList<MenuItemVM> _menuList;
        private BindingList<OrderItemVM> _orderList;

        public guiforSale()
        {
            InitializeComponent();
            this.loadingCategory();
            this.Load += guiforSale_Load;

            // make sure ItemClick is only subscribed once
            this.tileMenu.ItemClick -= tileMenu_ItemClick;
            this.tileMenu.ItemClick += tileMenu_ItemClick;

            this.gvOrder.CellValueChanged += gvOrder_CellValueChanged;
            this.btnClearOrder.Click += btnClearOrder_Click;
        }

        private void guiforSale_Load(object sender, EventArgs e)
        {
            _menuList = new BindingList<MenuItemVM>()
            {
                new MenuItemVM(){ Name="Chicken Steak",   Price=3.20M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\ice.jpg") },
                new MenuItemVM(){ Name="Thai Milk Tea",  Price=2.00M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\1.jpg") },
                new MenuItemVM(){ Name="Hot Latte",      Price=2.50M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\2.jpg") },
                new MenuItemVM(){ Name="Ice Cappuccino", Price=2.30M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\3.jpg") },
                new MenuItemVM(){ Name="Nasi Goreng",    Price=3.80M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\4.jpg") },
                new MenuItemVM(){ Name="Green Tea",      Price=1.90M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\5.jpg") },

                new MenuItemVM(){ Name="Chicken Steak 2",   Price=3.20M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\6.jpg") },
                new MenuItemVM(){ Name="Thai Milk Teaw",    Price=2.00M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\7.jpg") },
                new MenuItemVM(){ Name="Hot Lattew",        Price=2.50M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\5.jpg") },
                new MenuItemVM(){ Name="Ice Cappuccinow",   Price=2.30M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\3.jpg") },
                new MenuItemVM(){ Name="Nasi Gorengw",      Price=3.80M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\2.jpg") },
                new MenuItemVM(){ Name="Green Teaw",        Price=1.90M, Img=Image.FromFile(@"C:\Users\HQ\Downloads\1.jpg") }
            };

            gridMenu.DataSource = _menuList;

            _orderList = new BindingList<OrderItemVM>();
            gridOrder.DataSource = _orderList;

            SetupTileView();
            RecalculateTotals();
        }

        private void SetupTileView()
        {
            tileMenu.BeginUpdate();

            tileMenu.OptionsTiles.ItemSize = new Size(220, 140);
            tileMenu.OptionsTiles.Padding = new Padding(5);

            tileMenu.TileTemplate.Clear();
            tileMenu.TileColumns.Clear();
            tileMenu.TileRows.Clear();
            tileMenu.TileSpans.Clear();

            var col = new TableColumnDefinition();
            tileMenu.TileColumns.Add(col);

            var rowImg = new TableRowDefinition();
            var rowName = new TableRowDefinition();
            var rowPrice = new TableRowDefinition();
            tileMenu.TileRows.Add(rowImg);
            tileMenu.TileRows.Add(rowName);
            tileMenu.TileRows.Add(rowPrice);

            var colImg = tileMenu.Columns["Img"];
            var colName = tileMenu.Columns["Name"];
            var colPrice = tileMenu.Columns["Price"];

            var elementImg = new TileViewItemElement();
            elementImg.Column = colImg;
            elementImg.ColumnIndex = 0;
            elementImg.RowIndex = 0;
            elementImg.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            elementImg.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside;
            elementImg.Text = string.Empty;

            var elementName = new TileViewItemElement();
            elementName.Column = colName;
            elementName.ColumnIndex = 0;
            elementName.RowIndex = 1;
            elementName.TextAlignment = TileItemContentAlignment.MiddleCenter;
            elementName.Appearance.Normal.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            var elementPrice = new TileViewItemElement();
            elementPrice.Column = colPrice;
            elementPrice.ColumnIndex = 0;
            elementPrice.RowIndex = 2;
            elementPrice.TextAlignment = TileItemContentAlignment.MiddleCenter;
            elementPrice.Text = "USD {0:0.00}";
            elementPrice.Appearance.Normal.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            tileMenu.TileTemplate.Add(elementImg);
            tileMenu.TileTemplate.Add(elementName);
            tileMenu.TileTemplate.Add(elementPrice);

            tileMenu.EndUpdate();
        }

        private void tileMenu_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            var row = tileMenu.GetRow(e.Item.RowHandle) as MenuItemVM;
            if (row == null) return;

            var existing = _orderList.FirstOrDefault(x => x.Item == row.Name);
            if (existing == null)
            {
                _orderList.Add(new OrderItemVM
                {
                    Item = row.Name,
                    Qty = 1,
                    Price = row.Price,
                    Amount = row.Price
                });
            }
            else
            {
                existing.Qty += 1;
                existing.Amount = existing.Qty * existing.Price;
                gvOrder.RefreshData();
            }

            RecalculateTotals();
        }

        private void gvOrder_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var row = gvOrder.GetRow(e.RowHandle) as OrderItemVM;
            if (row == null) return;

            if (e.Column.FieldName == "Qty" || e.Column.FieldName == "Price")
            {
                row.Amount = row.Qty * row.Price;
                gvOrder.RefreshRow(e.RowHandle);
                RecalculateTotals();
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            _orderList.Clear();
            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            decimal sub = _orderList.Sum(x => x.Amount);
            decimal discount = 0m;
            decimal total = sub - discount;

            lblSubTotal.Text = sub.ToString("0.00");
            lblDiscount.Text = discount.ToString("0.00");
            lblTotal.Text = total.ToString("0.00");
        }

    

        private void tileMenu_Click(object sender, EventArgs e)
        {
        }

        private void btnContinuePayment_Click(object sender, EventArgs e)
        {
            if (_orderList == null || _orderList.Count == 0)
            {
                XtraMessageBox.Show("No item selected!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = _orderList.Sum(x => x.Amount);
            decimal discount = 0m;
            decimal total = subtotal - discount;

            string note = XtraInputBox.Show(
                "Enter Note / Table / Customer:",
                "Order Note",
                ""
            );

            // ⬇️ pass _orderList to payment
            var pay = new frmPayment(_orderList, subtotal, discount, total, note);
            if (pay.ShowDialog() == DialogResult.OK)
            {
                _orderList.Clear();
                RecalculateTotals();
            }


        }
        private void loadingCategory()
        {
            categoryButtonsPanel.Controls.Clear();

            var categories = new[]
            {
                "All menu",
                "Coffee",
                "Non Coffee",
                "Food",
                "Snack",
                "Dessert"
            };

            foreach (var text in categories)
            {
                var btn = new DevExpress.XtraEditors.SimpleButton();
                btn.Text = text;
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                btn.Size = new Size(100, 40);
                btn.Margin = new Padding(0, 0, 8, 0);
                btn.Tag = text;
              //  btn.Click += CategoryButton_Click;

                categoryButtonsPanel.Controls.Add(btn);
            }
        }
            private void btnmainDecrease_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvOrder.FocusedRowHandle < 0) return;

            var row = gvOrder.GetRow(gvOrder.FocusedRowHandle) as OrderItemVM;
            if (row == null) return;

            if (row.Qty > 1)
            {
                row.Qty -= 1;
                row.Amount = row.Qty * row.Price;
            }
            else
            {
             
                _orderList.Remove(row);
            }

            gvOrder.RefreshData();
            RecalculateTotals();
        }

        private void btnCancel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvOrder.FocusedRowHandle < 0)
                return;
            var row = gvOrder.GetRow(gvOrder.FocusedRowHandle) as OrderItemVM;
            if (row == null)
                return;
            _orderList.Remove(row);
            gvOrder.RefreshData();
            RecalculateTotals();
        }
    }
}
