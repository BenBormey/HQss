using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using unt_bingoo.Class;

namespace unt_bingoo.view.PurchaseOrder
{
    /// <summary>
    /// The printable purchase order — the document that goes to the supplier.
    ///
    /// Built in code rather than from a .repx so the whole layout is reviewable
    /// in one file and moves with the model: rename a property and this stops
    /// compiling, where a designer file would silently print blanks.
    ///
    /// WHAT IT DELIBERATELY DOES NOT PRINT
    /// No CTN / PCS split and no "total cartons". Those need a verified
    /// quantity per carton, and the legacy data contradicts itself on exactly
    /// that — DRK-COKE records ProQtyPCase = 22 beside a ProPacksize reading
    /// "24 can case". The receiving side already refuses to guess a packaging
    /// factor; printing one on a document a supplier will act on would undo
    /// that in the worst possible place. Quantities print in the unit the
    /// buyer actually ordered in, which is what the supplier invoiced anyway.
    /// </summary>
    public class rptPurchaseOrder : XtraReport
    {
        private const float Left = 0f;
        private const float Width = 780f;          // usable width at 100 dpi, A4 portrait

        // Column geometry, declared once so the header row and the detail row
        // cannot drift apart.
        private static readonly float[] ColWidths = { 34f, 96f, 118f, 224f, 62f, 46f, 90f, 110f };
        private static readonly string[] ColTitles =
            { "N°", "CODE", "BARCODE", "DESCRIPTION", "QTY", "UOM", "UNIT COST", "LINE TOTAL" };

        public rptPurchaseOrder(
            PurchaseOrderModel po,
            SupplierItem supplier,
            OutletItem warehouse,
            IDictionary<string, ProductItem> productsByCode)
        {
            if (po == null) throw new ArgumentNullException(nameof(po));

            PaperKind = System.Drawing.Printing.PaperKind.A4;
            Landscape = false;
            Margins = new System.Drawing.Printing.Margins(40, 40, 40, 40);
            Font = new Font("Tahoma", 8f);

            var lines = po.PurchaseOrderItems ?? new List<PurchaseOrderItemModel>();

            // Barcode and packaging text live on the product, not the order
            // line, so they are looked up rather than duplicated onto the PO.
            var rows = lines.Select((l, i) =>
            {
                ProductItem p = null;
                if (l.ProNumY != null) productsByCode.TryGetValue(l.ProNumY, out p);

                return new PrintRow
                {
                    No = i + 1,
                    Code = l.ProNumY,
                    Barcode = FirstNonEmpty(p?.ProNumYP, p?.ProNumYC),
                    Description = string.IsNullOrWhiteSpace(l.ProductName) ? p?.ProName : l.ProductName,
                    Qty = l.Quantity,
                    Uom = l.UOMCode,
                    UnitCost = l.UnitCost,
                    LineTotal = l.TotalCost
                };
            }).ToList();

            DataSource = rows;

            Bands.AddRange(new Band[]
            {
                BuildReportHeader(po, supplier, warehouse),
                BuildPageHeader(),
                BuildDetail(),
                BuildReportFooter(po, rows),
                BuildPageFooter()
            });
        }

        // ---- header ------------------------------------------------------
        private Band BuildReportHeader(PurchaseOrderModel po, SupplierItem supplier, OutletItem warehouse)
        {
            var band = new ReportHeaderBand { HeightF = 226f };

            // Company identity, taken from the receiving warehouse: it is the
            // outlet the goods are billed and shipped to, so its own details
            // are the ones a supplier needs.
            band.Controls.Add(Label(0, 0, 470, 18, WarehouseName(warehouse),
                bold: true, size: 13f));
            band.Controls.Add(Label(0, 20, 470, 44, JoinLines(
                warehouse?.Address,
                Labelled("Tel", warehouse?.OutletPhone ?? warehouse?.FrancisePhone),
                Labelled("Email", warehouse?.Email),
                Labelled("VAT", warehouse?.VATNumber)), size: 7.5f));

            // Title block, boxed like the sample.
            var title = Label(Width - 300, 0, 300, 26, "PURCHASE ORDER",
                bold: true, size: 14f, align: TextAlignment.MiddleCenter);
            title.BackColor = Color.FromArgb(232, 232, 232);
            title.Borders = BorderSide.All;
            band.Controls.Add(title);

            band.Controls.Add(Label(Width - 300, 28, 300, 46, JoinLines(
                "PURCHASE ORDER NO : " + Dash(po.PurchaseOrderNo),
                "DATE : " + Date(po.OrderDate),
                "EXPECTED DATE : " + (po.ExpectedDate.HasValue ? Date(po.ExpectedDate.Value) : "-")),
                size: 8f, align: TextAlignment.TopRight));

            // Two boxed parties, side by side.
            const float boxTop = 86f;
            const float boxW = (Width - 12f) / 2f;

            band.Controls.Add(BoxHeading(0, boxTop, boxW, "SUPPLIER"));
            band.Controls.Add(BoxBody(0, boxTop + 18f, boxW, JoinLines(
                supplier?.SupplierName,
                supplier?.Address,
                Labelled("Tel", supplier?.Phone),
                Labelled("Email", supplier?.Email),
                Labelled("Tax", supplier?.TaxNumber))));

            band.Controls.Add(BoxHeading(boxW + 12f, boxTop, boxW, "SHIP & NOTIFY TO"));
            band.Controls.Add(BoxBody(boxW + 12f, boxTop + 18f, boxW, JoinLines(
                WarehouseName(warehouse),
                warehouse?.Address,
                Labelled("Tel", warehouse?.OutletPhone ?? warehouse?.FrancisePhone),
                Labelled("Attn", warehouse?.Manager))));

            if (!string.IsNullOrWhiteSpace(po.Note))
                band.Controls.Add(Label(0, 200, Width, 22, "Note : " + po.Note.Trim(), size: 8f));

            return band;
        }

        // ---- column headings, repeated on every page ---------------------
        private Band BuildPageHeader()
        {
            var band = new PageHeaderBand { HeightF = 22f };
            float x = Left;

            for (int i = 0; i < ColTitles.Length; i++)
            {
                var cell = Label(x, 0, ColWidths[i], 22, ColTitles[i],
                    bold: true, size: 8f,
                    align: i >= 4 ? TextAlignment.MiddleRight : TextAlignment.MiddleLeft);

                cell.BackColor = Color.FromArgb(232, 232, 232);
                cell.Borders = BorderSide.All;
                cell.Padding = new PaddingInfo(3, 3, 0, 0);
                band.Controls.Add(cell);

                x += ColWidths[i];
            }

            return band;
        }

        private Band BuildDetail()
        {
            var band = new DetailBand { HeightF = 18f };
            string[] fields = { "No", "Code", "Barcode", "Description", "Qty", "Uom", "UnitCost", "LineTotal" };
            string[] formats = { null, null, null, null, "{0:N4}", null, "{0:N4}", "{0:N2}" };
            float x = Left;

            for (int i = 0; i < fields.Length; i++)
            {
                var cell = Label(x, 0, ColWidths[i], 18, string.Empty,
                    size: 8f,
                    align: i >= 4 ? TextAlignment.MiddleRight : TextAlignment.MiddleLeft);

                cell.Borders = BorderSide.All;
                cell.Padding = new PaddingInfo(3, 3, 0, 0);
                cell.CanGrow = true;

                if (formats[i] != null)
                    cell.TextFormatString = formats[i];

                // Bound rather than written: the row objects carry the values,
                // so a renamed property breaks the build instead of the print.
                cell.DataBindings.Add("Text", null, fields[i]);

                band.Controls.Add(cell);
                x += ColWidths[i];
            }

            return band;
        }

        // ---- totals and signatures ---------------------------------------
        private Band BuildReportFooter(PurchaseOrderModel po, List<PrintRow> rows)
        {
            var band = new ReportFooterBand { HeightF = 150f };

            float labelW = 110f;
            float valueW = 110f;
            float x = Width - labelW - valueW;

            // The line count is a genuine total; a carton count is not, so it
            // is absent rather than approximated.
            band.Controls.Add(Label(0, 4, 260, 16,
                rows.Count + " line(s)", size: 8f, bold: true));

            AddTotal(band, x, 4, labelW, valueW, "Sub Total :", po.SubTotal, false);
            AddTotal(band, x, 22, labelW, valueW, "Discount :", -po.DiscountAmount, false);
            AddTotal(band, x, 40, labelW, valueW, "Tax :", po.TaxAmount, false);
            AddTotal(band, x, 58, labelW, valueW, "GRAND TOTAL :", po.GrandTotal, true);

            // Signature strip, the reason a PO gets printed at all.
            const float sigTop = 108f;
            float sigW = (Width - 40f) / 3f;
            string[] captions = { "Prepared By", "Approved By", "Supplier Acknowledgement" };

            for (int i = 0; i < captions.Length; i++)
            {
                float sx = i * (sigW + 20f);
                var line = new XRLine
                {
                    LocationF = new PointF(sx, sigTop),
                    WidthF = sigW,
                    HeightF = 2f,
                    LineWidth = 1
                };
                band.Controls.Add(line);
                band.Controls.Add(Label(sx, sigTop + 4, sigW, 14, captions[i],
                    size: 7.5f, align: TextAlignment.TopCenter));
            }

            return band;
        }

        private Band BuildPageFooter()
        {
            var band = new PageFooterBand { HeightF = 20f };

            band.Controls.Add(Label(0, 0, 300, 16,
                "Printed " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), size: 7f));

            band.Controls.Add(new XRPageInfo
            {
                LocationF = new PointF(Width - 200, 0),
                WidthF = 200,
                HeightF = 16,
                PageInfo = PageInfo.NumberOfTotal,
                Format = "Page {0} of {1}",
                TextAlignment = TextAlignment.TopRight,
                Font = new Font("Tahoma", 7f)
            });

            return band;
        }

        // ---- small builders ----------------------------------------------
        private static void AddTotal(Band band, float x, float y, float labelW, float valueW,
                                     string caption, decimal value, bool emphasise)
        {
            band.Controls.Add(Label(x, y, labelW, 16, caption,
                bold: emphasise, size: emphasise ? 9f : 8f, align: TextAlignment.MiddleRight));

            var v = Label(x + labelW, y, valueW, 16, value.ToString("N2"),
                bold: emphasise, size: emphasise ? 9f : 8f, align: TextAlignment.MiddleRight);

            if (emphasise)
            {
                v.Borders = BorderSide.Top | BorderSide.Bottom;
                v.ForeColor = Color.FromArgb(0, 100, 0);
            }

            band.Controls.Add(v);
        }

        private static XRLabel BoxHeading(float x, float y, float w, string text)
        {
            var l = Label(x, y, w, 18, text, bold: true, size: 8f);
            l.BackColor = Color.FromArgb(232, 232, 232);
            l.Borders = BorderSide.All;
            l.Padding = new PaddingInfo(4, 2, 0, 0);
            return l;
        }

        private static XRLabel BoxBody(float x, float y, float w, string text)
        {
            var l = Label(x, y, w, 74, text, size: 7.5f);
            l.Borders = BorderSide.All;
            l.Padding = new PaddingInfo(4, 4, 3, 3);
            l.CanGrow = false;
            return l;
        }

        private static XRLabel Label(float x, float y, float w, float h, string text,
                                     bool bold = false, float size = 8f,
                                     TextAlignment align = TextAlignment.TopLeft)
        {
            return new XRLabel
            {
                LocationF = new PointF(x, y),
                WidthF = w,
                HeightF = h,
                Text = text ?? string.Empty,
                Font = new Font("Tahoma", size, bold ? FontStyle.Bold : FontStyle.Regular),
                TextAlignment = align,
                Multiline = true
            };
        }

        private static string WarehouseName(OutletItem w) =>
            string.IsNullOrWhiteSpace(w?.OutletName) ? "JuJuBi" : w.OutletName.Trim();

        private static string Labelled(string caption, string value) =>
            string.IsNullOrWhiteSpace(value) ? null : caption + " : " + value.Trim();

        private static string FirstNonEmpty(params string[] values) =>
            values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v))?.Trim() ?? string.Empty;

        private static string JoinLines(params string[] parts) =>
            string.Join(Environment.NewLine,
                parts?.Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p.Trim())
                ?? Enumerable.Empty<string>());

        private static string Dash(string v) => string.IsNullOrWhiteSpace(v) ? "-" : v.Trim();

        private static string Date(DateTime d) => d == default(DateTime) ? "-" : d.ToString("dd-MMM-yyyy");

        /// <summary>
        /// One printed line. Flattened from the order line plus the product it
        /// points at, so the report binds to plain properties and never has to
        /// reach back into a lookup while rendering.
        /// </summary>
        private class PrintRow
        {
            public int No { get; set; }
            public string Code { get; set; }
            public string Barcode { get; set; }
            public string Description { get; set; }
            public decimal Qty { get; set; }
            public string Uom { get; set; }
            public decimal UnitCost { get; set; }
            public decimal LineTotal { get; set; }
        }
    }
}
