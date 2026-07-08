using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Product
{
    public partial class guiUOM : DevExpress.XtraEditors.XtraForm
    {
        private string DatabaseName;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        public string editid = null;

        public guiUOM()
        {
            InitializeComponent();
            this.LoadingInitialized();
        }

        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();
                    string query = @"
                        SELECT UOMId, UOMCode, UOMName, IsActive
                        FROM [DBJuJuBi].[dbo].[UOM]
                        ORDER BY UOMCode ASC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<UOMClas> list = new List<UOMClas>();
                            while (reader.Read())
                            {
                                list.Add(new UOMClas
                                {
                                    UOMId = Convert.ToInt32(reader["UOMId"]),
                                    UOMCode = reader["UOMCode"].ToString(),
                                    UOMName = reader["UOMName"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                });
                            }

                            grdUOM.DataSource = list;
                            lblCount.Text = "Total Records: " + list.Count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUOMCode.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the UOM Code!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUOMCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUOMName.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the UOM Name!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUOMName.Focus();
                return;
            }

            string finalUOMCode = txtUOMCode.Text.Trim();
            string finalUOMName = txtUOMName.Text.Trim();
            bool isActive;

            if (chkstatus.Checked)
            {
                isActive = true;
            }
            else if (cheDeactive.Checked)
            {
                isActive = false;
            }
            else
            {
                MessageBox.Show("Please select Active or Inactive.");
                return;
            }




            using (SqlConnection conn = new SqlConnection(
                Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
            {
                conn.Open();

                string checkQuery;

                if (string.IsNullOrEmpty(editid))
                {
                    // Add New
                    checkQuery = @"
                        SELECT COUNT(*)
                        FROM [DBJuJuBi].[dbo].[UOM]
                        WHERE UPPER(UOMCode) = UPPER(@UOMCode)";
                }
                else
                {
                    // Edit
                    checkQuery = @"
                        SELECT COUNT(*)
                        FROM [DBJuJuBi].[dbo].[UOM]
                        WHERE UPPER(UOMCode) = UPPER(@UOMCode)
                        AND UOMId <> @Id";
                }

                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UOMCode", finalUOMCode);

                    if (!string.IsNullOrEmpty(editid))
                    {
                        cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(editid));
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        XtraMessageBox.Show(
                            "UOM Code already exists!",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtUOMCode.Focus();
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(editid))
            {
                string insertQuery = @"
                    INSERT INTO [DBJuJuBi].[dbo].[UOM]
                    (
                        UOMCode,
                        UOMName,
                        IsActive
                    )
                    VALUES
                    (
                        @UOMCode,
                        @UOMName,
                        @IsActive
                    )";

                ExecuteNonQuery(insertQuery, new Dictionary<string, object>
                {
                    { "@UOMCode", finalUOMCode },
                    { "@UOMName", finalUOMName },
                    { "@IsActive", isActive }
                });

                XtraMessageBox.Show(
                    "Saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                string updateQuery = @"
                    UPDATE [DBJuJuBi].[dbo].[UOM]
                    SET UOMCode = @UOMCode,
                        UOMName = @UOMName,
                        IsActive = @IsActive
                    WHERE UOMId = @Id";

                ExecuteNonQuery(updateQuery, new Dictionary<string, object>
                {
                    { "@UOMCode", finalUOMCode },
                    { "@UOMName", finalUOMName },
                    { "@IsActive", isActive },
                    { "@Id", Convert.ToInt32(editid) }
                });

                XtraMessageBox.Show(
                    "Record updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                editid = null;
                btnSave.Text = "SAVE";
            }

            txtUOMCode.Text = string.Empty;
            txtUOMName.Text = string.Empty;
            chkstatus.Checked = true;

            LoadData();
            txtUOMCode.Focus();
        }

        private void btnmainUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdUOM.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view != null && view.GetFocusedRowCellValue("UOMId") != null)
            {
                editid = view.GetFocusedRowCellValue("UOMId").ToString();

                txtUOMCode.Text = view.GetFocusedRowCellValue("UOMCode").ToString();
                txtUOMName.Text = view.GetFocusedRowCellValue("UOMName").ToString();
                chkstatus.Checked = Convert.ToBoolean(view.GetFocusedRowCellValue("IsActive"));

                btnSave.Text = "UPDATE";
                btnClear.Visible = true;
                txtUOMCode.Focus();
            }
            else
            {
                MessageBox.Show("Please select a valid record to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = grdUOM.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view == null) return;

            object idObj = view.GetFocusedRowCellValue("UOMId");

            if (idObj == null)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            editid = idObj.ToString();

            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM [DBJuJuBi].[dbo].[UOM] WHERE UOMId = @Id";
                    ExecuteNonQuery(query, new Dictionary<string, object> { { "@Id", editid } });

                    LoadData();
                    txtUOMCode.Text = string.Empty;
                    txtUOMName.Text = string.Empty;
                    chkstatus.Checked = true;
                    editid = null;
                    btnSave.Text = "SAVE";
                    btnClear.Visible = false;

                    MessageBox.Show("Record deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
            }
        }

        private void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guiUOM_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editid = null;

            txtUOMCode.Text = string.Empty;
            txtUOMName.Text = string.Empty;
            chkstatus.Checked = true;

            btnSave.Text = "SAVE";
            btnClear.Visible = false;

            txtUOMCode.Focus();
        }

        private void gvUOM_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.LightYellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightCyan;
                }
            }
        }

        private bool _changingStatus = false;

        private void chkstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (_changingStatus) return;

            _changingStatus = true;

            if (chkstatus.Checked)
            {
                cheDeactive.Checked = false;
            }
            else if (!cheDeactive.Checked)
            {
                chkstatus.Checked = true;
            }

            _changingStatus = false;
        }

        private void cheDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (_changingStatus) return;

            _changingStatus = true;

            if (cheDeactive.Checked)
            {
                chkstatus.Checked = false;
            }
            else if (!chkstatus.Checked)
            {
                cheDeactive.Checked = true;
            }

            _changingStatus = false;
        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
