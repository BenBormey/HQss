using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.PurchaseOrder
{
    // One line of the receiving grid: a PurchaseOrderItemModel plus the
    // editable fields this delivery adds (how much actually arrived, and
    // optionally which lot / when it expires). Kept separate from
    // PurchaseOrderItemModel itself so this UI-only state can't leak into
    // the model the master-detail grid on the main PO screen binds to.
    public class ReceiveLineModel
    {
        public int PurchaseOrderItemID { get; set; }
        public string ProductName { get; set; }
        public string OrderedDisplay { get; set; }
        public decimal ReceivedSoFar { get; set; }
        public decimal RemainingQty { get; set; }
        public string UOMCode { get; set; }

        // Defaults to RemainingQty (full receive, same default the old
        // one-click "Receive" button always used) — reduce it for a partial
        // delivery, or clear it to 0 to skip the line entirely.
        public decimal ReceiveQty { get; set; }

        public string LotNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    // Replaces the old single Yes/No "receive everything" confirm with a
    // per-line screen: how much of each item actually arrived, and — new —
    // which lot it came in and when it expires. Both are optional per line,
    // so a delivery nobody bothers tracking lots for still receives in one
    // pass exactly like before.
    public class FrmReceivePurchaseOrder : XtraForm
    {
        private readonly APIsController _api;
        private readonly PurchaseOrderModel _po;
        private readonly BindingList<ReceiveLineModel> _lines = new BindingList<ReceiveLineModel>();

        private GridControl _grid;
        private GridView _gridView;
        private TextEdit _txtNote;
        private LabelControl _lblSummary;
        private SimpleButton _btnConfirm;
        private SimpleButton _btnCancel;

        /// <summary>Set once Confirm succeeds, so the caller can show/log the GRN number.</summary>
        public GoodsReceiptNoteModel CreatedGrn { get; private set; }

        public FrmReceivePurchaseOrder(PurchaseOrderModel po, APIsController api)
        {
            _po = po;
            _api = api;

            BuildLines();
            Build();
        }

        private void BuildLines()
        {
            var remaining = _po.PurchaseOrderItems
                .Where(i => i.Quantity - i.ReceivedQty > 0)
                .ToList();

            foreach (var item in remaining)
            {
                _lines.Add(new ReceiveLineModel
                {
                    PurchaseOrderItemID = item.PurchaseOrderItemID,
                    ProductName = string.IsNullOrWhiteSpace(item.ProductName) ? item.ProNumY : item.ProductName,
                    OrderedDisplay = item.Quantity.ToString("0.####") + " " + item.UOMCode,
                    ReceivedSoFar = item.ReceivedQty,
                    RemainingQty = item.RemainingQty,
                    UOMCode = item.UOMCode,
                    ReceiveQty = item.RemainingQty,
                    LotNumber = null,
                    ExpiryDate = null
                });
            }
        }

        private void Build()
        {
            Text = "Receive Purchase Order " + (_po.PurchaseOrderNo ?? "");
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(860, 590);
            Font = new Font("Segoe UI", 9F);

            var lblTitle = new LabelControl
            {
                Text = "Receive " + (_po.PurchaseOrderNo ?? ""),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(20, 16),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(500, 28)
            };
            Controls.Add(lblTitle);

            var lblSubtitle = new LabelControl
            {
                Text = (_po.SupplierName ?? "Unknown supplier") + "  →  " + (_po.OutletName ?? "Unknown outlet"),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray,
                Location = new Point(21, 46),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(500, 20)
            };
            Controls.Add(lblSubtitle);

            var lblHelp = new LabelControl
            {
                Text = "Receive Qty defaults to the full remaining quantity — reduce it for a partial delivery, " +
                       "or set it to 0 to skip a line. Lot Number and Expiry Date are optional.",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                Location = new Point(21, 74),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(818, 32),
                Appearance = { TextOptions = { WordWrap = DevExpress.Utils.WordWrap.Wrap } }
            };
            Controls.Add(lblHelp);

            BuildGrid();
            Controls.Add(_grid);

            var lblNote = new LabelControl
            {
                Text = "Delivery note (optional)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(21, 420),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(200, 18)
            };
            Controls.Add(lblNote);

            _txtNote = new TextEdit
            {
                Location = new Point(21, 440),
                Size = new Size(817, 24)
            };
            _txtNote.Properties.MaxLength = 500;
            _txtNote.Properties.NullValuePrompt = "e.g. one box arrived damaged, truck was late...";
            _txtNote.Properties.NullValuePromptShowForEmptyValue = true;
            Controls.Add(_txtNote);

            _lblSummary = new LabelControl
            {
                Location = new Point(21, 478),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(500, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray
            };
            Controls.Add(_lblSummary);
            UpdateSummary();

            _btnCancel = new SimpleButton
            {
                Text = "Cancel",
                Size = new Size(100, 32),
                Location = new Point(658, 540),
                DialogResult = DialogResult.Cancel
            };
            Controls.Add(_btnCancel);

            _btnConfirm = new SimpleButton
            {
                Text = "Confirm Receive",
                Size = new Size(140, 32),
                Location = new Point(764, 540),
                Appearance = { Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };
            _btnConfirm.Click += BtnConfirm_Click;
            Controls.Add(_btnConfirm);

            CancelButton = _btnCancel;
            AcceptButton = null; // Confirm posts to the server; Enter must never trigger it by accident.
        }

        private void BuildGrid()
        {
            _grid = new GridControl
            {
                Location = new Point(20, 110),
                Size = new Size(818, 300),
                DataSource = _lines
            };

            _gridView = new GridView(_grid) { OptionsView = { ShowGroupPanel = false } };
            _grid.MainView = _gridView;
            _grid.ViewCollection.Add(_gridView);

            _gridView.OptionsBehavior.Editable = true;
            _gridView.OptionsSelection.EnableAppearanceFocusedCell = false;

            _gridView.Columns.Clear();

            AddReadOnlyColumn("ProductName", "Product", 220);
            AddReadOnlyColumn("OrderedDisplay", "Ordered", 100);

            var colReceived = AddReadOnlyColumn("ReceivedSoFar", "Received", 80);
            colReceived.DisplayFormat.FormatType = FormatType.Numeric;
            colReceived.DisplayFormat.FormatString = "0.####";

            var colRemaining = AddReadOnlyColumn("RemainingQty", "Remaining", 90);
            colRemaining.DisplayFormat.FormatType = FormatType.Numeric;
            colRemaining.DisplayFormat.FormatString = "0.####";

            // ---- editable columns ----

            var repoReceiveQty = new RepositoryItemSpinEdit
            {
                MinValue = 0,
                MaxValue = decimal.MaxValue, // per-row max is enforced in CellValueChanged below (RemainingQty differs per line)
                Increment = 1,
                IsFloatValue = true,
                DisplayFormat = { FormatType = FormatType.Numeric, FormatString = "0.####" },
                EditFormat = { FormatType = FormatType.Numeric, FormatString = "0.####" }
            };
            _grid.RepositoryItems.Add(repoReceiveQty);

            var colReceiveQty = _gridView.Columns.AddVisible("ReceiveQty", "Receive Qty");
            colReceiveQty.Width = 110;
            colReceiveQty.ColumnEdit = repoReceiveQty;
            colReceiveQty.AppearanceCell.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            var repoLot = new RepositoryItemTextEdit { MaxLength = 50 };
            _grid.RepositoryItems.Add(repoLot);

            var colLot = _gridView.Columns.AddVisible("LotNumber", "Lot Number");
            colLot.Width = 140;
            colLot.ColumnEdit = repoLot;

            var repoExpiry = new RepositoryItemDateEdit
            {
                DisplayFormat = { FormatType = FormatType.DateTime, FormatString = "yyyy-MM-dd" },
                EditFormat = { FormatType = FormatType.DateTime, FormatString = "yyyy-MM-dd" }
            };
            _grid.RepositoryItems.Add(repoExpiry);

            var colExpiry = _gridView.Columns.AddVisible("ExpiryDate", "Expiry Date");
            colExpiry.Width = 110;
            colExpiry.ColumnEdit = repoExpiry;

            _gridView.CellValueChanged += GridView_CellValueChanged;
            _gridView.BestFitColumns();
        }

        private GridColumn AddReadOnlyColumn(string fieldName, string caption, int width)
        {
            var column = _gridView.Columns.AddVisible(fieldName, caption);
            column.Width = width;
            column.OptionsColumn.AllowEdit = false;
            return column;
        }

        // Clamps a Receive Qty edit to that row's own RemainingQty — the
        // repository item's MaxValue above is shared by every row, so the
        // per-row ceiling has to be enforced here instead.
        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "ReceiveQty")
            {
                if (e.Column.FieldName == "ExpiryDate" || e.Column.FieldName == "LotNumber")
                    UpdateSummary();
                return;
            }

            var row = _gridView.GetRow(e.RowHandle) as ReceiveLineModel;
            if (row == null)
                return;

            if (row.ReceiveQty < 0)
                row.ReceiveQty = 0;
            else if (row.ReceiveQty > row.RemainingQty)
                row.ReceiveQty = row.RemainingQty;

            _gridView.RefreshRow(e.RowHandle);
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            var linesToReceive = _lines.Count(l => l.ReceiveQty > 0);
            var linesWithLot = _lines.Count(l => l.ReceiveQty > 0 && !string.IsNullOrWhiteSpace(l.LotNumber));

            _lblSummary.Text = linesToReceive == 0
                ? "No lines will be received — set a Receive Qty above zero on at least one item."
                : $"{linesToReceive} of {_lines.Count} line(s) will be received" +
                  (linesWithLot > 0 ? $", {linesWithLot} with a lot number recorded." : ".");
        }

        private async void BtnConfirm_Click(object sender, EventArgs e)
        {
            _gridView.CloseEditor();
            _gridView.UpdateCurrentRow();

            var toReceive = _lines.Where(l => l.ReceiveQty > 0).ToList();

            if (toReceive.Count == 0)
            {
                XtraMessageBox.Show(
                    "Set a Receive Qty above zero on at least one item before confirming.",
                    "Nothing to receive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _btnConfirm.Enabled = false;
            _btnCancel.Enabled = false;

            try
            {
                var note = string.IsNullOrWhiteSpace(_txtNote.Text) ? null : _txtNote.Text.Trim();

                var dto = new
                {
                    Items = toReceive.Select(l => new
                    {
                        PurchaseOrderItemID = l.PurchaseOrderItemID,
                        ReceivedQty = l.ReceiveQty,
                        LotNumber = string.IsNullOrWhiteSpace(l.LotNumber) ? null : l.LotNumber.Trim(),
                        ExpiryDate = l.ExpiryDate
                    }),
                    Note = note
                };

                var result = await _api.PostAsync<ReceivePurchaseOrderResponseModel>(
                    $"api/purchaseorder/receive/{_po.PurchaseOrderID}", dto);

                // null means the call failed — APIsController.SafeCall already
                // showed the error MessageBox, so the dialog just stays open
                // for another try rather than double-reporting it.
                if (result == null)
                    return;

                CreatedGrn = result.GoodsReceiptNote;

                var grnLine = CreatedGrn != null
                    ? $"\n\nGoods Receipt Note: {CreatedGrn.GRNNo}"
                    : "";

                XtraMessageBox.Show(
                    $"Purchase order received successfully.{grnLine}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            finally
            {
                _btnConfirm.Enabled = true;
                _btnCancel.Enabled = true;
            }
        }
    }
}
