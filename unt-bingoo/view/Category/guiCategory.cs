using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using ClosedXML.Excel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using System.Drawing;
namespace unt_bingoo.view.Category
{
    public partial class guiCategory : XtraForm
    {
        private APIsController _api; 
        private BindingList<CategoryItem> _list =
            new BindingList<CategoryItem>();

        private int? _editingId = null;

        public guiCategory()
        {
            InitializeComponent();

            gvCategory.OptionsView.ShowFilterPanelMode =
         DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;


            gvCategory.Appearance.HeaderPanel.BackColor = Color.DimGray;
            gvCategory.Appearance.HeaderPanel.ForeColor = Color.Black;
            gvCategory.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gvCategory.Appearance.HeaderPanel.Options.UseBackColor = true;
            gvCategory.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvCategory.Appearance.HeaderPanel.Options.UseFont = true;
        }

        private async void guiCategory_Load(object sender, EventArgs e)
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

                await LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task LoadData()
        {
            var data =
                await _api.GetAsync<System.Collections.Generic.List<CategoryItem>>(
                    "api/category");

            _list.Clear();

            foreach (var item in data)
                _list.Add(item);


            gridCategory.DataSource = _list;
            lblCount.Text = $"Count : {_list.Count}";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;


            if (_editingId == null && CheckDuplicateCategory())
                return;
            var model = GetFormData();

            try
            {
                bool ok;


                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/category", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    _list.Add(model);

                    XtraMessageBox.Show("Added!");
                }

                else
                {
                    ok = await _api.PutAsync($"api/category/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    var item = _list.First(x => x.Id == _editingId);

                    item.CategoryCode = model.CategoryCode;
                    item.CategoryName = model.CategoryName;
                    item.Remark = model.Remark;
                    item.Active = model.Active;

                    gvCategory.RefreshData();

                    XtraMessageBox.Show("Updated!");
                }
                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        private async void btnMainDelete_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCategory.GetFocusedRow() as CategoryItem;

            if (row == null) return;

            if (XtraMessageBox.Show("Do you want to delete?",
                "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/category/{row.Id}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed!");
                    return;
                }

                _list.Remove(row);

                lblCount.Text = $"Count : {_list.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        private void btnMainupdate_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCategory.GetFocusedRow() as CategoryItem;

            if (row == null) return;

            //txtCode.Text = row.CategoryCode;
            txtName.Text = row.CategoryName;
            txtRemark.Text = row.Remark;
            TxtKhmerName.Text = row.khmerCategoryName;

            //chkActive.Checked = row.Active;

            _editingId = row.Id;

            BtnAdd.Text = "Update";
        }


        private bool ValidateForm()
        {
            //if (string.IsNullOrWhiteSpace(txtCode.Text))
            //{
            //    XtraMessageBox.Show("Category Code required!");
            //    return false;
            //}

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Category Name required!");
                return false;
            }

            return true;
        }

        private CategoryItem GetFormData()
        {
            return new CategoryItem
            {
                Id = _editingId ?? 0,
                CategoryCode ="",
                CategoryName = txtName.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                khmerCategoryName = TxtKhmerName.Text.Trim()
                //Active = chkActive.Checked
            };
        }

        private void ClearForm()
        {
            //txtCode.Text = "";
            txtName.Text = "";
            txtRemark.Text = "";

            //chkActive.Checked = true;

            _editingId = null;

            BtnAdd.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCategory.DataRowCount <= 0)
                {
                    XtraMessageBox.Show("No data to export.", "Export Excel",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 1) យកតែ column ដែលមាន data (រំលង Edit/Delete buttons)
                var cols = gvCategory.VisibleColumns
                                     .Cast<GridColumn>()
                                     .Where(c => !string.IsNullOrEmpty(c.FieldName))
                                     .ToList();

                // 2) save ទៅ Temp ដោយស្វ័យប្រវត្តិ (មិនបាច់សួរ Save)
                string path = Path.Combine(
                    Path.GetTempPath(),
                    "Category_List_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");

                BuildPrettyWorkbook(cols, path);

                // 3) បើកភ្លាមៗ
                if (File.Exists(path))
                {
                    Process.Start(new ProcessStartInfo() { FileName = path, UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildPrettyWorkbook(List<GridColumn> cols, string path)
        {
            var navy = XLColor.FromArgb(31, 58, 95);
            var bandB = XLColor.FromArgb(238, 243, 250);
            var white = XLColor.White;
            var dark = XLColor.FromArgb(27, 39, 51);
            var grid = XLColor.FromArgb(201, 211, 223);
            var line = XLColor.FromArgb(143, 168, 196);
            const string FONT = "Calibri";

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Category List");
                ws.ShowGridLines = false;

                int nCols = cols.Count + 1; 
                var headers = new List<string> { "No." };
                headers.AddRange(cols.Select(c => string.IsNullOrEmpty(c.Caption) ? c.FieldName : c.Caption));

         
                ws.Column(1).Width = 6;
                for (int c = 0; c < cols.Count; c++)
                {
                    string cap = headers[c + 1].ToLower();
                    double w = 22;
                    if (cap.Contains("description") || cap.Contains("remark")) w = 45;
                    else if (cap.Contains("khmer")) w = 24;
                    else if (cap.Contains("date")) w = 16;
                    ws.Column(c + 2).Width = w;
                }

                // Title
                ws.Range(1, 1, 1, nCols).Merge();
                var t = ws.Cell(1, 1);
                t.Value = "CATEGORY  LIST";
                t.Style.Font.SetBold(true); t.Style.Font.FontColor = white;
                t.Style.Font.FontSize = 16; t.Style.Font.FontName = FONT;
                t.Style.Fill.BackgroundColor = navy;
                t.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                t.Style.Alignment.Indent = 1;
                ws.Row(1).Height = 32;

                // Subtitle
                ws.Range(2, 1, 2, nCols).Merge();
                var s = ws.Cell(2, 1);
                s.Value = "Exported: " + DateTime.Now.ToString("dd MMM yyyy  HH:mm") +
                          "     |     " + gvCategory.DataRowCount + " records";
                s.Style.Font.Italic = true; s.Style.Font.FontSize = 9.5;
                s.Style.Font.FontColor = XLColor.FromArgb(91, 107, 123);
                s.Style.Fill.BackgroundColor = XLColor.FromArgb(244, 247, 251);
                s.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                s.Style.Alignment.Indent = 1;
                ws.Row(2).Height = 18;

                // Header (row 4)
                int headerRow = 4;
                for (int c = 0; c < nCols; c++)
                {
                    var h = ws.Cell(headerRow, c + 1);
                    h.Value = headers[c];
                    h.Style.Font.SetBold(true); h.Style.Font.FontColor = white;
                    h.Style.Font.FontName = FONT; h.Style.Font.FontSize = 10.5;
                    h.Style.Fill.BackgroundColor = navy;
                    h.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    h.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    h.Style.Alignment.WrapText = true;
                }
                ws.Row(headerRow).Height = 26;

                // Data
                int row = headerRow + 1;
                int dataCount = gvCategory.DataRowCount;
                for (int r = 0; r < dataCount; r++)
                {
                    var band = (r % 2 == 1) ? bandB : white;

                    // No.
                    var no = ws.Cell(row, 1);
                    no.Value = r + 1;
                    no.Style.Font.FontName = FONT; no.Style.Font.FontSize = 10;
                    no.Style.Font.FontColor = dark;
                    no.Style.Fill.BackgroundColor = band;
                    no.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    no.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                    for (int c = 0; c < cols.Count; c++)
                    {
                        string text = gvCategory.GetRowCellDisplayText(r, cols[c]) ?? "";
                        var cell = ws.Cell(row, c + 2);
                        cell.Value = text;
                        cell.Style.Font.FontName = FONT; cell.Style.Font.FontSize = 10;
                        cell.Style.Font.FontColor = dark;
                        cell.Style.Fill.BackgroundColor = band;
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        string cap = headers[c + 1].ToLower();
                        if (cap.Contains("description") || cap.Contains("remark") ||
                            cap.Contains("name") || cap.Contains("khmer"))
                        {
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            cell.Style.Alignment.WrapText = true;
                            cell.Style.Alignment.Indent = 1;
                        }
                        else cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    ws.Row(row).Height = 20;
                    row++;
                }
                int dataEnd = row - 1;

                // Borders
                var dr = ws.Range(headerRow, 1, dataEnd, nCols);
                dr.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                dr.Style.Border.InsideBorderColor = grid;
                dr.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                dr.Style.Border.OutsideBorderColor = line;
                ws.Range(headerRow, 1, headerRow, nCols).Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                ws.Range(headerRow, 1, headerRow, nCols).Style.Border.BottomBorderColor = line;

                // Freeze header + AutoFilter
                ws.SheetView.FreezeRows(headerRow);
                ws.Range(headerRow, 1, dataEnd, nCols).SetAutoFilter();

                wb.SaveAs(path);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TxtKhmerName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage =
           InputLanguage.FromCulture(new CultureInfo("km-KH"));

        }

        private void TxtKhmerName_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage =
       InputLanguage.FromCulture(new CultureInfo("en-US"));
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == null ? "" : txtSearch.Text.Trim();
            gvCategory.ApplyFindFilter(keyword);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            TxtKhmerName.Text = "";
            BtnAdd.Text = "Add";
        }
        private bool CheckDuplicateCategory()
        {
            string categoryName = txtName.Text.Trim();

            var existRow = _list.FirstOrDefault(x =>
                x.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            if (existRow != null)
            {
                XtraMessageBox.Show(
                    $"Category '{categoryName}' already exists!",
                    "Duplicate Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Search textbox
                txtSearch.Text = "";

                // Filter ដូចក្នុងរូប
                gvCategory.ActiveFilterString =
                    $"[CategoryName] = '{categoryName.Replace("'", "''")}'";

                // Focus Row
                int rowHandle = gvCategory.LocateByValue("CategoryName", categoryName);

                if (rowHandle >= 0)
                {
                    gvCategory.FocusedRowHandle = rowHandle;
                    gvCategory.MakeRowVisible(rowHandle);
                }

                txtName.Focus();
                txtName.SelectAll();

                return true;
            }

            // បើមិនមាន Duplicate ដក Filter ចេញ
            gvCategory.ActiveFilter.Clear();

            return false;
        }
    }
}
