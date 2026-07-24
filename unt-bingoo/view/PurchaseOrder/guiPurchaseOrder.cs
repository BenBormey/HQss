using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using Excel = Microsoft.Office.Interop.Excel;

namespace unt_bingoo.view.PurchaseOrder
{
    public partial class guiPurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;
        private List<SupplierItem> _suppliers = new List<SupplierItem>();
        private List<ProductItem> _products = new List<ProductItem>();
        private List<PurchaseOrderModel> _allPOs = new List<PurchaseOrderModel>();
        private BindingList<PurchaseOrderItemModel> _currentLines = new BindingList<PurchaseOrderItemModel>();

        public guiPurchaseOrder()
        {
            InitializeComponent();

            _api = APIGlobals.Api;

            gridLines.DataSource = _currentLines;

            this.Load += guiPurchaseOrder_Load;
            btnAddItem.Click += btnAddItem_Click;
            btnSavePO.Click += btnSavePO_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private async void guiPurchaseOrder_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            dtpExpectedDate.Value = DateTime.Today.AddDays(7);

            await LoadSuppliers();
            await LoadProducts();
            await LoadPOList();
        }

        private async System.Threading.Tasks.Task LoadSuppliers()
        {
            try
            {
                _suppliers = await _api.GetAsync<List<SupplierItem>>("api/supplier") ?? new List<SupplierItem>();

                cboSupplier.DataSource = _suppliers;
                cboSupplier.DisplayMember = "SupplierName";
                cboSupplier.ValueMember = "SupplierID";
                cboSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadProducts()
        {
            try
            {
                _products = await _api.GetAsync<List<ProductItem>>("api/product") ?? new List<ProductItem>();

                cboProduct.DataSource = _products;
                cboProduct.DisplayMember = "ProName";
                cboProduct.ValueMember = "ProNumY";
                cboProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadPOList()
        {
            try
            {
                var list = await _api.GetAsync<List<PurchaseOrderModel>>("api/purchaseorder") ?? new List<PurchaseOrderModel>();

                foreach (var po in list)
                {
                    po.SupplierName = _suppliers.FirstOrDefault(s => s.SupplierID == po.SupplierID)?.SupplierName
                                       ?? $"#{po.SupplierID}";
                }

                _allPOs = list;

                ApplyFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading purchase orders: " + ex.Message);
            }
        }

        private void ApplyFilter()
        {
            var keyword = txtSearch.Text.Trim();

            var list = string.IsNullOrWhiteSpace(keyword)
                ? _allPOs
                : _allPOs.Where(p =>
                    (p.PurchaseOrderNo ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.SupplierName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.Status ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            gridPO.DataSource = list;
            gvPO.BestFitColumns();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPOList();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var product = cboProduct.SelectedItem as ProductItem;

            if (product == null)
            {
                XtraMessageBox.Show("Please select a product.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty <= 0)
            {
                XtraMessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!decimal.TryParse(txtUnitCost.Text.Trim(), out decimal unitCost) || unitCost < 0)
            {
                XtraMessageBox.Show("Please enter a valid unit cost.");
                return;
            }

            decimal.TryParse(txtDiscount.Text.Trim(), out decimal discountPercent);
            decimal.TryParse(txtTax.Text.Trim(), out decimal taxPercent);

            var subTotal = qty * unitCost;
            var discountAmount = subTotal * discountPercent / 100;
            var afterDiscount = subTotal - discountAmount;
            var taxAmount = afterDiscount * taxPercent / 100;
            var totalCost = afterDiscount + taxAmount;

            _currentLines.Add(new PurchaseOrderItemModel
            {
                ProNumY = product.ProNumY,
                ProductName = product.ProName,
                Quantity = qty,
                UnitCost = unitCost,
                DiscountPercent = discountPercent,
                DiscountAmount = discountAmount,
                TaxPercent = taxPercent,
                TaxAmount = taxAmount,
                SubTotal = subTotal,
                TotalCost = totalCost
            });

            RecalculateTotals();

            cboProduct.SelectedIndex = -1;
            txtQuantity.Text = "1";
            txtUnitCost.Text = "0";
            txtDiscount.Text = "0";
            txtTax.Text = "0";
        }

        private void btnRemoveLine_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var line = gvLines.GetFocusedRow() as PurchaseOrderItemModel;

            if (line == null)
                return;

            _currentLines.Remove(line);
            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            var subTotal = _currentLines.Sum(l => l.SubTotal);
            var discountAmount = _currentLines.Sum(l => l.DiscountAmount);
            var taxAmount = _currentLines.Sum(l => l.TaxAmount);
            var grandTotal = _currentLines.Sum(l => l.TotalCost);

            lblSubTotalValue.Text = subTotal.ToString("N2");
            lblGrandTotal.Text = "Grand Total : " + grandTotal.ToString("N2");
        }

        private async void btnSavePO_Click(object sender, EventArgs e)
        {
            var supplier = cboSupplier.SelectedItem as SupplierItem;

            if (supplier == null)
            {
                XtraMessageBox.Show("Please select a supplier.");
                return;
            }

            if (_currentLines.Count == 0)
            {
                XtraMessageBox.Show("Please add at least one line item.");
                return;
            }

            var dto = new
            {
                SupplierID = supplier.SupplierID,
                ExpectedDate = dtpExpectedDate.Value,
                Note = txtNote.Text.Trim(),
                Items = _currentLines.Select(l => new
                {
                    l.ProNumY,
                    l.Quantity,
                    l.UnitCost,
                    l.DiscountPercent,
                    l.TaxPercent
                }).ToList()
            };

            try
            {
                var ok = await _api.PostAsync("api/purchaseorder", dto);

                if (!ok)
                {
                    XtraMessageBox.Show("Save failed.");
                    return;
                }

                XtraMessageBox.Show(
                    "Purchase order saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                await LoadPOList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cboSupplier.SelectedIndex = -1;
            dtpExpectedDate.Value = DateTime.Today.AddDays(7);
            txtNote.Text = string.Empty;

            cboProduct.SelectedIndex = -1;
            txtQuantity.Text = "1";
            txtUnitCost.Text = "0";
            txtDiscount.Text = "0";
            txtTax.Text = "0";

            _currentLines.Clear();
            RecalculateTotals();
        }

        private void btnMainView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var po = gvPO.GetFocusedRow() as PurchaseOrderModel;

            if (po == null)
                return;

            var lines = po.PurchaseOrderItems.Select(i =>
            {
                var product = _products.FirstOrDefault(p => p.ProNumY == i.ProNumY);
                var name = product?.ProName ?? i.ProNumY;
                return $"{name}  x{i.Quantity}  @ {i.UnitCost:N2}  =  {i.TotalCost:N2}  (Received: {i.ReceivedQty}/{i.Quantity})";
            });

            var message = $"PO {po.PurchaseOrderNo}\nSupplier: {po.SupplierName}\nStatus: {po.Status}\n\n"
                          + string.Join("\n", lines)
                          + $"\n\nGrand Total: {po.GrandTotal:N2}";

            XtraMessageBox.Show(message, "Purchase Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnMainReceive_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var po = gvPO.GetFocusedRow() as PurchaseOrderModel;

            if (po == null)
                return;

            if (po.Status == "Received")
            {
                XtraMessageBox.Show("This purchase order has already been fully received.");
                return;
            }

            var remainingItems = po.PurchaseOrderItems
                .Where(i => i.Quantity - i.ReceivedQty > 0)
                .Select(i => new { PurchaseOrderItemID = i.PurchaseOrderItemID, ReceivedQty = i.Quantity - i.ReceivedQty })
                .ToList();

            if (remainingItems.Count == 0)
            {
                XtraMessageBox.Show("There is no remaining quantity to receive.");
                return;
            }

            if (MessageBox.Show(
                    $"Receive the full remaining quantity for PO {po.PurchaseOrderNo}?",
                    "Confirm Receive",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var dto = new { Items = remainingItems };

                var ok = await _api.PostAsync($"api/purchaseorder/receive/{po.PurchaseOrderID}", dto);

                if (!ok)
                {
                    XtraMessageBox.Show("Receive failed.");
                    return;
                }

                XtraMessageBox.Show(
                    "Purchase order received successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadPOList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnMainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var po = gvPO.GetFocusedRow() as PurchaseOrderModel;

            if (po == null)
                return;

            if (MessageBox.Show(
                    $"Are you sure you want to delete purchase order '{po.PurchaseOrderNo}'?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var ok = await _api.DeleteAsync($"api/purchaseorder/{po.PurchaseOrderID}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed.");
                    return;
                }

                await LoadPOList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPO.RowCount <= 0)
                {
                    MessageBox.Show(
                        "No data to export.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                Cursor = Cursors.WaitCursor;

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                int excelCol = 1;

                for (int col = 0; col < gvPO.Columns.Count; col++)
                {
                    var column = gvPO.Columns[col];

                    if (column == colPOView || column == colPOReceive || column == colPODelete)
                        continue;

                    worksheet.Cells[1, excelCol] = column.Caption;
                    ((Excel.Range)worksheet.Cells[1, excelCol]).Font.Bold = true;

                    excelCol++;
                }

                for (int row = 0; row < gvPO.RowCount; row++)
                {
                    excelCol = 1;

                    for (int col = 0; col < gvPO.Columns.Count; col++)
                    {
                        var column = gvPO.Columns[col];

                        if (column == colPOView || column == colPOReceive || column == colPODelete)
                            continue;

                        object value = gvPO.GetRowCellValue(row, column);

                        worksheet.Cells[row + 2, excelCol] = value?.ToString() ?? "";

                        excelCol++;
                    }
                }

                worksheet.Columns.AutoFit();

                Cursor = Cursors.Default;

                MessageBox.Show(
                    "Export completed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
