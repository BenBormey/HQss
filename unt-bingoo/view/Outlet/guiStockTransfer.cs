using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using Excel = Microsoft.Office.Interop.Excel;

namespace unt_bingoo.view.Outlet
{
    // "Real transfer" model, as opposed to guiAssignStock's absolute-set
    // override: this always moves stock FROM the HeadOffice warehouse
    // outlet TO a chosen destination outlet, debiting one side and
    // crediting the other atomically, and keeps a permanent before/after
    // history (api/IngredientStockTransfer) instead of just overwriting a
    // number.
    public partial class guiStockTransfer : XtraForm
    {
        private APIsController _api;
        private List<ProductItem> _ingredients = new List<ProductItem>();

        // Mirrors _ingredients minus whatever is already staged in
        // _pendingItems — this is what cboIngredient is actually bound to,
        // so a product picked once drops out of the dropdown until its
        // pending line is removed (instead of just being blocked by a
        // "already in the list" message after the user picks it again).
        private List<ProductItem> _availableIngredients = new List<ProductItem>();

        // True when the currently-selected destination outlet is a
        // franchise (a separate business paying for goods) rather than a
        // company-owned location — toggles the Unit Price/Total Amount
        // fields, which the backend also enforces independently.
        private bool _isFranchiseOutlet;

        // Held separately because the textboxes now display a unit suffix
        // ("5000 ML"), which is not parseable as a number.
        private decimal? _outletStockValue;
        private string _selectedUnit = "";

        // Staged items for the current batch — nothing here is saved until
        // "Save && Export All" runs. One outlet per batch (locked once the
        // first item is added) so the exported sheet has one clear header.
        private readonly BindingList<PendingTransferLine> _pendingItems = new BindingList<PendingTransferLine>();
        private DataGridView gridPending;
        private Button btnRemoveSelected;
        private Button btnSaveExportAll;

        public guiStockTransfer()
        {
            InitializeComponent();
        }

        private async void guiStockTransfer_Load(object sender, EventArgs e)
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

                if (!APIGlobals.HasPermission("OUTLET_STOCK"))
                {
                    XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                cboOutlet.SelectedIndexChanged += async (s, ev) =>
                {
                    await CheckFranchiseAsync();
                    await RefreshSnapshotAsync();
                };
                cboIngredient.SelectedIndexChanged += async (s, ev) => await RefreshSnapshotAsync();
                txtQty.TextChanged += (s, ev) => { UpdateAfterTransferDisplay(); UpdateTotalAmountDisplay(); };
                txtUnitPrice.TextChanged += (s, ev) => UpdateTotalAmountDisplay();

                EnsurePendingItemsUi();

                // Repurposed from an immediate one-item API call to staging
                // into _pendingItems — nothing is saved until "Save && Export
                // All" runs, so several ingredients can go to one outlet in
                // one batch instead of repeating outlet selection each time.
                btnTransfer.Text = "Add to List";
                btnTransfer.Click += BtnAddToList_Click;
                btnClear.Click += (s, ev) => ClearForm();

                await LoadLookupsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLookupsAsync()
        {
            var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet") ?? new List<OutletItem>();

            // The warehouse (HeadOffice) is the fixed source of every
            // transfer, never a valid destination — leave it out of both
            // pickers so it can't be selected by mistake.
            var destinationOutlets = outlets.Where(o => o.IsActive && !o.HeadOffice).ToList();

            cboOutlet.DataSource = destinationOutlets.ToList();
            cboOutlet.DisplayMember = "OutletName";
            cboOutlet.ValueMember = "Id";
            cboOutlet.SelectedIndex = -1;

            var products = await _api.GetAsync<List<ProductItem>>("api/product") ?? new List<ProductItem>();
            _ingredients = products.Where(p => p.IsIngredient).ToList();
            _availableIngredients = _ingredients.ToList();

            BindIngredientCombo();
        }

        // Rebinding (rather than mutating Items in place) is required because
        // cboIngredient is DataSource-bound — reassigning the same list
        // reference wouldn't refresh the dropdown after RemoveAll/Add.
        private void BindIngredientCombo()
        {
            cboIngredient.DataSource = null;
            cboIngredient.DataSource = _availableIngredients;
            cboIngredient.DisplayMember = "desiplyname";
            cboIngredient.ValueMember = "ProNumY";
            cboIngredient.SelectedIndex = -1;
        }

        private async Task RefreshSnapshotAsync()
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet) ||
                !(cboIngredient.SelectedItem is ProductItem ingredient))
            {
                txtWarehouseStock.Text = "—";
                txtOutletStock.Text = "—";
                _outletStockValue = null;
                _selectedUnit = "";
                UpdateAfterTransferDisplay();
                return;
            }

            var snapshot = await _api.GetAsync<StockSnapshot>(
                $"api/IngredientStockTransfer/snapshot?proNumY={Uri.EscapeDataString(ingredient.ProNumY)}&outletId={outlet.Id}");

            // Quantities here are in the ingredient's stocking unit (g, ml, pcs) —
            // Product.ProUnit, the same unit Recipe/OutletStock/IngredientStockTransfer
            // quantities are expressed in. NOT ProductScale.UOMCode, which is the
            // purchasing/logistics packaging unit (CTN, PLT) and is unrelated to how
            // this stock is counted. Showing the correct unit stops "150" being read
            // as 150 servings when the recipe actually consumes 150 grams per drink.
            _selectedUnit = ingredient.ProUnit ?? "";
            var suffix = string.IsNullOrWhiteSpace(_selectedUnit) ? "" : " " + _selectedUnit;

            _outletStockValue = snapshot?.OutletStock;

            txtWarehouseStock.Text = snapshot != null ? snapshot.WarehouseStock.ToString("0.####") + suffix : "—";
            txtOutletStock.Text = snapshot != null ? snapshot.OutletStock.ToString("0.####") + suffix : "—";

            lblQty.Text = string.IsNullOrWhiteSpace(_selectedUnit)
                ? "Transfer Qty :"
                : "Transfer Qty (" + _selectedUnit + ") :";

            await TryPrefillPriceAsync(outlet.Id, ingredient.ProNumY);

            UpdateAfterTransferDisplay();
        }

        // Pre-fills a standing price from the Franchise Price List, same
        // source guiOutletOrderApproval's Ship Now stage reads. Only touches
        // the field when it's still empty, so it never overwrites a value
        // the user already typed for a one-off exception.
        private async Task TryPrefillPriceAsync(int outletId, string proNumY)
        {
            if (!_isFranchiseOutlet || !string.IsNullOrWhiteSpace(txtUnitPrice.Text))
                return;

            var prices = await _api.GetAsync<List<FranchisePriceLookupItem>>(
                $"api/FranchisePriceList/outlet/{outletId}") ?? new List<FranchisePriceLookupItem>();

            var match = prices.FirstOrDefault(p =>
                string.Equals(p.ProNumY, proNumY, StringComparison.OrdinalIgnoreCase));

            if (match != null)
                txtUnitPrice.Text = match.UnitPrice.ToString("0.####");
        }

        private async Task CheckFranchiseAsync()
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                _isFranchiseOutlet = false;
                SetPriceFieldsVisible(false);
                return;
            }

            var response = await _api.GetAsync<FranchiseCheckResult>(
                $"api/IngredientStockTransfer/is-franchise?outletId={outlet.Id}");

            _isFranchiseOutlet = response?.IsFranchise ?? false;
            SetPriceFieldsVisible(_isFranchiseOutlet);
            UpdateTotalAmountDisplay();
        }

        private void SetPriceFieldsVisible(bool visible)
        {
            lblUnitPrice.Visible = visible;
            txtUnitPrice.Visible = visible;
            lblTotalAmount.Visible = visible;
            txtTotalAmount.Visible = visible;

            if (!visible)
                txtUnitPrice.Text = string.Empty;
        }

        private void UpdateTotalAmountDisplay()
        {
            if (!_isFranchiseOutlet)
            {
                txtTotalAmount.Text = "—";
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal unitPrice) ||
                !decimal.TryParse(txtQty.Text.Trim(), out decimal qty))
            {
                txtTotalAmount.Text = "—";
                return;
            }

            txtTotalAmount.Text = "$" + (unitPrice * qty).ToString("0.00");
        }

        private void UpdateAfterTransferDisplay()
        {
            if (_outletStockValue == null)
            {
                txtAfterTransfer.Text = "—";
                return;
            }

            var suffix = string.IsNullOrWhiteSpace(_selectedUnit) ? "" : " " + _selectedUnit;
            decimal current = _outletStockValue.Value;

            if (!decimal.TryParse(txtQty.Text.Trim(), out decimal qty))
            {
                txtAfterTransfer.Text = current.ToString("0.####") + suffix;
                return;
            }

            txtAfterTransfer.Text = (current + qty).ToString("0.####") + suffix;
        }

        // Stages one line into _pendingItems — no API call here. Validates
        // exactly what the old immediate-submit path validated (destination,
        // ingredient, qty > 0, franchise unit price), just without writing
        // anything yet.
        private void BtnAddToList_Click(object sender, EventArgs e)
        {
            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                XtraMessageBox.Show("Please select a destination outlet.");
                return;
            }

            if (!(cboIngredient.SelectedItem is ProductItem ingredient))
            {
                XtraMessageBox.Show("Please select an ingredient.");
                return;
            }

            if (!decimal.TryParse(txtQty.Text.Trim(), out decimal qty) || qty <= 0)
            {
                XtraMessageBox.Show("Please enter a valid transfer quantity greater than 0.");
                txtQty.Focus();
                return;
            }

            if (_pendingItems.Any(p => p.ProNumY == ingredient.ProNumY))
            {
                XtraMessageBox.Show("'" + ingredient.ProName + "' is already in the list — remove it first to change the quantity.");
                return;
            }

            decimal? unitPrice = null;

            if (_isFranchiseOutlet)
            {
                if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal price) || price <= 0)
                {
                    XtraMessageBox.Show("'" + outlet.OutletName + "' is a franchise outlet — please enter a unit price greater than 0.");
                    txtUnitPrice.Focus();
                    return;
                }

                unitPrice = price;
            }

            _pendingItems.Add(new PendingTransferLine
            {
                ProNumY = ingredient.ProNumY,
                IngredientName = ingredient.ProName,
                Qty = qty,
                Unit = _selectedUnit,
                Reason = cboReason.Text.Trim(),
                Note = txtNote.Text.Trim(),
                UnitPrice = unitPrice
            });

            // Outlet stays locked for the rest of this batch — every line
            // in one "Save && Export All" goes to the same destination, so
            // the exported sheet can have one unambiguous header.
            cboOutlet.Enabled = false;

            // Drop it from the picker now that it's staged — resets the
            // selection to -1 as part of rebinding.
            _availableIngredients.RemoveAll(p => p.ProNumY == ingredient.ProNumY);
            BindIngredientCombo();

            txtQty.Text = string.Empty;
            cboReason.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;

            lblStatus.Appearance.ForeColor = Color.FromArgb(14, 122, 56);
            lblStatus.Text = $"Added '{ingredient.ProName}' — {_pendingItems.Count} item(s) in the list.";
        }

        // Commits every staged line — one atomic call per line to the same
        // endpoint the old single-item flow used (stock guard + franchise
        // price rules already enforced server-side there), then exports the
        // lines that actually succeeded to Excel. A line failing (e.g. stock
        // ran out between staging and saving) doesn't roll back lines that
        // already succeeded — each POST is its own transaction.
        private async void BtnSaveExportAll_Click(object sender, EventArgs e)
        {
            if (_pendingItems.Count == 0)
            {
                XtraMessageBox.Show("Add at least one item to the list first.");
                return;
            }

            if (!(cboOutlet.SelectedItem is OutletItem outlet))
            {
                XtraMessageBox.Show("Please select a destination outlet.");
                return;
            }

            if (XtraMessageBox.Show(
                    $"Save and transfer {_pendingItems.Count} item(s) from the warehouse to '{outlet.OutletName}'?",
                    "Confirm Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            btnSaveExportAll.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var succeeded = new List<TransferHistoryRow>();
            var failed = new List<string>();

            try
            {
                foreach (var line in _pendingItems.ToList())
                {
                    var dto = new
                    {
                        OutletId = outlet.Id,
                        ProNumY = line.ProNumY,
                        Qty = line.Qty,
                        Reason = line.Reason,
                        Note = line.Note,
                        TransferredBy = APIGlobals.UserName,
                        UnitPrice = line.UnitPrice
                    };

                    var result = await _api.PostAsync<TransferHistoryRow>("api/IngredientStockTransfer", dto);

                    if (result != null)
                    {
                        succeeded.Add(result);
                        _pendingItems.Remove(line);
                    }
                    else
                    {
                        failed.Add($"{line.IngredientName} ({line.Qty:0.####} {line.Unit})");
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSaveExportAll.Enabled = true;
            }

            if (succeeded.Count > 0)
            {
                // Recompute from the master list rather than adding items
                // back one-by-one: anything that saved is gone from
                // _pendingItems and should be selectable again; anything
                // that failed is still staged and should stay excluded.
                _availableIngredients = _ingredients
                    .Where(p => !_pendingItems.Any(x => x.ProNumY == p.ProNumY))
                    .ToList();
                BindIngredientCombo();

                // The database save above already committed — a PDF failure
                // here (Excel missing, temp file locked, no PDF exporter on
                // an old Excel install) must not look like the transfer
                // itself failed, and must not crash this async void handler.
                try
                {
                    ExportBatchToPdf(outlet.OutletName, succeeded);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"Saved {succeeded.Count} item(s) successfully, but the PDF could not be generated:\n\n{ex.Message}",
                        "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                await RefreshSnapshotAsync();
            }

            if (_pendingItems.Count == 0)
                cboOutlet.Enabled = true;

            if (failed.Count == 0)
            {
                lblStatus.Appearance.ForeColor = Color.FromArgb(14, 122, 56);
                lblStatus.Text = $"Transferred {succeeded.Count} item(s) to '{outlet.OutletName}'.";
            }
            else
            {
                lblStatus.Appearance.ForeColor = Color.Red;
                lblStatus.Text = $"{succeeded.Count} succeeded, {failed.Count} failed — see the list still on screen.";
                XtraMessageBox.Show(
                    $"These items could not be transferred (check available stock/price and try again):\n\n{string.Join("\n", failed)}",
                    "Some Transfers Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Builds the same letterhead-style layout as the company's printed
        // request forms (company header, bordered table, grand total,
        // sign-off line) via Excel Interop — same approach guiExchange's
        // "Export To Excel" already uses, no new dependency — then saves
        // straight to PDF with Excel's own exporter instead of leaving the
        // workbook open on screen.
        private void ExportBatchToPdf(string outletName, List<TransferHistoryRow> rows)
        {
            Excel.Application excelApp = new Excel.Application { Visible = false, DisplayAlerts = false };
            Excel.Workbook workbook = null;

            try
            {
                workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = (Excel.Worksheet)workbook.ActiveSheet;

                const int lastCol = 11; // No, Transfer No, Ingredient, Qty, Unit, Before Stock, After Stock, Reason, Note, Unit Price, Total

                void Merge(int row, int colFrom, int colTo)
                {
                    ws.Range[ws.Cells[row, colFrom], ws.Cells[row, colTo]].Merge();
                }

                ws.Cells[1, 1] = "UNT WHOLESALE CO., LTD.";
                Merge(1, 1, lastCol);
                ((Excel.Range)ws.Cells[1, 1]).Font.Bold = true;
                ((Excel.Range)ws.Cells[1, 1]).Font.Size = 14;

                ws.Cells[2, 1] = "No. 891, Phum Toulpongror, Sangkat Chorm Chao, Khan Por Sen Chey, Phnom Penh.";
                Merge(2, 1, lastCol);
                ((Excel.Range)ws.Cells[2, 1]).Font.Size = 9;

                ws.Cells[3, 1] = "Tel: 023 995 900, 012 702 000";
                Merge(3, 1, lastCol);
                ((Excel.Range)ws.Cells[3, 1]).Font.Size = 9;

                ws.Cells[5, 1] = "Ingredient Stock Transfer";
                Merge(5, 1, lastCol);
                ((Excel.Range)ws.Cells[5, 1]).Font.Bold = true;
                ((Excel.Range)ws.Cells[5, 1]).Font.Size = 13;
                ((Excel.Range)ws.Cells[5, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Cells[7, 1] = "Transferred By:";
                ((Excel.Range)ws.Cells[7, 1]).Font.Bold = true;
                ws.Cells[7, 2] = APIGlobals.UserName ?? "";
                ws.Cells[7, 7] = "Outlet:";
                ((Excel.Range)ws.Cells[7, 7]).Font.Bold = true;
                ws.Cells[7, 8] = outletName;

                ws.Cells[8, 1] = "Date:";
                ((Excel.Range)ws.Cells[8, 1]).Font.Bold = true;
                ws.Cells[8, 2] = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                string[] headers =
                {
                    "No", "Transfer No", "Ingredient", "Qty", "Unit", "Before Stock",
                    "After Stock", "Reason", "Note", "Unit Price", "Total"
                };

                int headerRow = 10;
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = (Excel.Range)ws.Cells[headerRow, i + 1];
                    cell.Value = headers[i];
                    cell.Font.Bold = true;
                    cell.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(241, 242, 245));
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                int r = headerRow + 1;
                int no = 1;
                decimal grandTotal = 0m;

                foreach (var row in rows)
                {
                    // TransferHistoryRow (the server's response shape) has no
                    // per-line unit — look it up from the same ingredient
                    // list the picker uses, same field ProUnit fix as the
                    // "Transfer Qty" label (see RefreshSnapshotAsync).
                    string unit = _ingredients.FirstOrDefault(p => p.ProNumY == row.ProNumY)?.ProUnit ?? "";

                    ws.Cells[r, 1] = no++;
                    ws.Cells[r, 2] = row.TransferNo;
                    ws.Cells[r, 3] = row.IngredientName;
                    ws.Cells[r, 4] = row.Qty;
                    ws.Cells[r, 5] = unit;
                    ws.Cells[r, 6] = row.BeforeOutletStock;
                    ws.Cells[r, 7] = row.AfterOutletStock;
                    ws.Cells[r, 8] = row.Reason;
                    ws.Cells[r, 9] = row.Note;
                    ws.Cells[r, 10] = row.UnitPrice.HasValue ? (object)row.UnitPrice.Value : "";
                    ws.Cells[r, 11] = row.TotalAmount ?? 0m;

                    if (row.TotalAmount.HasValue)
                        grandTotal += row.TotalAmount.Value;

                    r++;
                }

                int lastDataRow = r - 1;

                var tableRange = ws.Range[ws.Cells[headerRow, 1], ws.Cells[lastDataRow, lastCol]];
                tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                tableRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                int totalRow = lastDataRow + 2;
                Merge(totalRow, 8, 10);
                ws.Cells[totalRow, 8] = "Grand Total:";
                ((Excel.Range)ws.Cells[totalRow, 8]).Font.Bold = true;
                ((Excel.Range)ws.Cells[totalRow, 8]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                ws.Cells[totalRow, 11] = grandTotal;
                ((Excel.Range)ws.Cells[totalRow, 11]).Font.Bold = true;

                // Sign-off line — same three-signature layout as the
                // company's other printed request forms.
                int signRow = totalRow + 4;
                Merge(signRow, 2, 3);
                ws.Cells[signRow, 2] = "Transferred By";
                ((Excel.Range)ws.Cells[signRow, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Merge(signRow, 6, 7);
                ws.Cells[signRow, 6] = "Received By";
                ((Excel.Range)ws.Cells[signRow, 6]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Merge(signRow, 10, 11);
                ws.Cells[signRow, 10] = "Approved By";
                ((Excel.Range)ws.Cells[signRow, 10]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Columns[1].ColumnWidth = 5;
                ws.Columns[2].ColumnWidth = 14;
                ws.Columns[3].ColumnWidth = 26;
                ws.Columns[4].ColumnWidth = 9;
                ws.Columns[5].ColumnWidth = 9;
                ws.Columns[6].ColumnWidth = 11;
                ws.Columns[7].ColumnWidth = 11;
                ws.Columns[8].ColumnWidth = 16;
                ws.Columns[9].ColumnWidth = 22;
                ws.Columns[10].ColumnWidth = 11;
                ws.Columns[11].ColumnWidth = 11;

                ws.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                ws.PageSetup.Zoom = false;
                ws.PageSetup.FitToPagesWide = 1;
                ws.PageSetup.FitToPagesTall = false;

                string pdfFile = Path.Combine(
                    Path.GetTempPath(),
                    $"StockTransfer_{outletName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfFile);

                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfFile,
                    UseShellExecute = true
                });
            }
            finally
            {
                workbook?.Close(false);
                excelApp.Quit();
            }
        }

        // Built in code rather than the Designer — grows pnlEntry to make
        // room for the staged-items grid instead of hand-editing the
        // generated Designer layout.
        private void EnsurePendingItemsUi()
        {
            pnlEntry.Height = 486;

            // Thin rule separating the entry fields from the staged-items
            // list below, so the two sections read as distinct groups
            // instead of one long run of controls.
            var divider = new Panel
            {
                Location = new Point(24, 254),
                Size = new Size(1342, 1),
                BackColor = Color.FromArgb(230, 231, 235)
            };
            pnlEntry.Controls.Add(divider);

            var lblPendingTitle = new LabelControl
            {
                Text = "Items to Transfer",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(24, 266),
                AutoSize = true
            };
            pnlEntry.Controls.Add(lblPendingTitle);

            gridPending = new DataGridView
            {
                Location = new Point(24, 292),
                Size = new Size(1342, 142),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(235, 236, 239),
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 34,
                RowTemplate = { Height = 28 },
                Font = new Font("Segoe UI", 9F)
            };
            gridPending.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(241, 242, 245),
                ForeColor = Color.FromArgb(60, 64, 72),
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.FromArgb(241, 242, 245),
                SelectionForeColor = Color.FromArgb(60, 64, 72),
                Padding = new Padding(6, 0, 0, 0)
            };
            gridPending.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 37, 41),
                SelectionBackColor = Color.FromArgb(224, 240, 229),
                SelectionForeColor = Color.FromArgb(33, 37, 41),
                Padding = new Padding(6, 0, 0, 0)
            };
            gridPending.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 250, 251)
            };
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "IngredientName", HeaderText = "Ingredient", Width = 280 });
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Qty", HeaderText = "Qty", Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.####", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Unit", HeaderText = "Unit", Width = 70 });
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Reason", HeaderText = "Reason", Width = 180 });
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Note", HeaderText = "Note", Width = 250 });
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice", HeaderText = "Unit Price", Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.####", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            gridPending.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount", HeaderText = "Total", Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            gridPending.DataSource = _pendingItems;
            pnlEntry.Controls.Add(gridPending);

            btnRemoveSelected = new Button
            {
                Text = "Remove Selected",
                Location = new Point(24, 448),
                Size = new Size(150, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(241, 242, 245),
                ForeColor = Color.FromArgb(60, 64, 72),
                Font = new Font("Segoe UI", 9F)
            };
            btnRemoveSelected.FlatAppearance.BorderSize = 0;
            btnRemoveSelected.Click += (s, e) =>
            {
                if (gridPending.CurrentRow?.DataBoundItem is PendingTransferLine line)
                {
                    _pendingItems.Remove(line);
                    if (_pendingItems.Count == 0)
                        cboOutlet.Enabled = true;

                    // Give the ingredient back to the picker now that its
                    // staged line is gone.
                    var restored = _ingredients.FirstOrDefault(p => p.ProNumY == line.ProNumY);
                    if (restored != null && !_availableIngredients.Any(p => p.ProNumY == line.ProNumY))
                    {
                        _availableIngredients.Add(restored);
                        BindIngredientCombo();
                    }
                }
            };
            pnlEntry.Controls.Add(btnRemoveSelected);

            btnSaveExportAll = new Button
            {
                Text = "Save && Export All",
                Location = new Point(1216, 448),
                Size = new Size(150, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(21, 128, 61),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnSaveExportAll.FlatAppearance.BorderSize = 0;
            btnSaveExportAll.Click += BtnSaveExportAll_Click;
            pnlEntry.Controls.Add(btnSaveExportAll);
        }

        private void ClearForm()
        {
            _pendingItems.Clear();
            _availableIngredients = _ingredients.ToList();
            BindIngredientCombo();
            cboOutlet.Enabled = true;
            cboOutlet.SelectedIndex = -1;
            txtQty.Text = string.Empty;
            cboReason.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtWarehouseStock.Text = "—";
            txtOutletStock.Text = "—";
            txtAfterTransfer.Text = "—";
            txtUnitPrice.Text = string.Empty;
            _outletStockValue = null;
            _selectedUnit = "";
            lblQty.Text = "Transfer Qty :";
            _isFranchiseOutlet = false;
            SetPriceFieldsVisible(false);
            lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(124, 133, 158);
            lblStatus.Text = "Pick an outlet, add each ingredient to the list, then Save && Export All.";
        }
    }

    // One staged, not-yet-saved line in the current batch.
    public class PendingTransferLine
    {
        public string ProNumY { get; set; } = string.Empty;
        public string IngredientName { get; set; } = string.Empty;
        public decimal Qty { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount => UnitPrice.HasValue ? UnitPrice.Value * Qty : (decimal?)null;
    }

    // Shape of GET api/IngredientStockTransfer/snapshot
    public class StockSnapshot
    {
        public decimal WarehouseStock { get; set; }
        public decimal OutletStock { get; set; }
    }

    // Shape of GET api/IngredientStockTransfer/is-franchise
    public class FranchiseCheckResult
    {
        public bool IsFranchise { get; set; }
    }

    // Shape of GET api/IngredientStockTransfer/history rows and the
    // POST api/IngredientStockTransfer response.
    public class TransferHistoryRow
    {
        public int TransferId { get; set; }
        public string TransferNo { get; set; } = string.Empty;
        public int OutletId { get; set; }
        public string OutletName { get; set; } = string.Empty;
        public string ProNumY { get; set; } = string.Empty;
        public string IngredientName { get; set; } = string.Empty;
        public string CategoryName { get; set; }
        public decimal Qty { get; set; }
        public decimal BeforeWarehouseStock { get; set; }
        public decimal AfterWarehouseStock { get; set; }
        public decimal BeforeOutletStock { get; set; }
        public decimal AfterOutletStock { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        public string TransferredBy { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
