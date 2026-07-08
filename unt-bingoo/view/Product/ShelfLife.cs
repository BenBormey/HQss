using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Product
{
    public partial class ShelfLife : XtraForm
    {
        private string DatabaseName;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();

        public string editid = null;

        public ShelfLife()
        {
            InitializeComponent();

            LoadingInitialized();

            gvShelfLife.Appearance.HeaderPanel.BackColor = Color.DimGray;
            gvShelfLife.Appearance.HeaderPanel.ForeColor = Color.Black;
            gvShelfLife.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gvShelfLife.Appearance.HeaderPanel.Options.UseBackColor = true;
            gvShelfLife.Appearance.HeaderPanel.Options.UseForeColor = true;
            gvShelfLife.Appearance.HeaderPanel.Options.UseFont = true;
        }

        private void ShelfLife_Load(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(
                Data,
                App);

            DatabaseName = string.Format(
                "{0}{1}",
                Data.PrefixDatabase,
                Data.DatabaseName);
        }

        private void txtShelfLifeValue_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(
                        Data.ConnectionString(
                            Initialized.GetConnectionType(
                                Data,
                                App))))
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        ShelfLifeId,
                        ShelfLifeName,
                        IsActive,
                        ShelfLifeValue,
                        ShelfLifeUnit
                    FROM [DBJuJuBi].[dbo].[ShelfLife]
                    ORDER BY ShelfLifeId DESC";

                    SqlCommand cmd =
                        new SqlCommand(
                            query,
                            conn);

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    List<ShelfLifeClass> list =
                        new List<ShelfLifeClass>();

                    while (reader.Read())
                    {
                        list.Add(
                            new ShelfLifeClass
                            {
                                Id =
                                    Convert.ToInt32(
                                        reader["ShelfLifeId"]),

                                ShelfLifeName =
                                    reader["ShelfLifeName"]
                                    .ToString(),

                                IsActive =
                                    Convert.ToBoolean(
                                        reader["IsActive"]),

                                ShelfLifeValue =
                                    Convert.ToInt32(
                                        reader["ShelfLifeValue"]),

                                ShelfLifeUnit =
                                    reader["ShelfLifeUnit"]
                                    .ToString()
                            });
                    }

                    grdShelfLife.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message);
            }
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(
                //    txtShelfLife.Text))
                //{
                //    XtraMessageBox.Show(
                //        "Please enter Shelf Life Name");

                //    txtShelfLife.Focus();
                //    return;
                //}

                if (string.IsNullOrWhiteSpace(
                    txtShelfLifeValue.Text))
                {
                    XtraMessageBox.Show(
                        "Please enter Shelf Life Value");

                    txtShelfLifeValue.Focus();
                    return;
                }

                string name =
                   null;

                int value =
                    Convert.ToInt32(
                        txtShelfLifeValue.Text);

                string unit =
                    cmbShelfLifeUnit.Text.Trim();

                bool isActive =
                    chkIsActive.Checked;

                if (string.IsNullOrEmpty(
                    editid))
                {
                    string query = @"
                    INSERT INTO [DBJuJuBi].[dbo].[ShelfLife]
                    (
                        ShelfLifeName,
                        IsActive,
                        ShelfLifeValue,
                        ShelfLifeUnit
                    )
                    VALUES
                    (
                        @ShelfLifeName,
                        @IsActive,
                        @ShelfLifeValue,
                        @ShelfLifeUnit
                    )";

                    ExecuteNonQuery(
                        query,
                        new Dictionary<string, object>
                        {
                            {
                                "@ShelfLifeName",
                                ""
                            },
                            {
                                "@IsActive",
                                isActive
                            },
                            {
                                "@ShelfLifeValue",
                                value
                            },
                            {
                                "@ShelfLifeUnit",
                                unit
                            }
                        });

                    XtraMessageBox.Show(
                        "Saved Successfully");
                }
                else
                {
                    string query = @"
                    UPDATE [DBJuJuBi].[dbo].[ShelfLife]
                    SET
                        ShelfLifeName = @ShelfLifeName,
                        IsActive = @IsActive,
                        ShelfLifeValue = @ShelfLifeValue,
                        ShelfLifeUnit = @ShelfLifeUnit
                    WHERE ShelfLifeId = @ShelfLifeId";

                    ExecuteNonQuery(
                        query,
                        new Dictionary<string, object>
                        {
                            {
                                "@ShelfLifeId",
                                Convert.ToInt32(editid)
                            },
                            {
                                "@ShelfLifeName",
                                ""
                            },
                            {
                                "@IsActive",
                                isActive
                            },
                            {
                                "@ShelfLifeValue",
                                value
                            },
                            {
                                "@ShelfLifeUnit",
                                unit
                            }
                        });

                    XtraMessageBox.Show(
                        "Updated Successfully");

                    editid = null;

                    btnSave.Text = "Save";
                }

                ClearControl();

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message);
            }
        }

        private void ExecuteNonQuery(
            string query,
            Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(
                        Data.ConnectionString(
                            Initialized.GetConnectionType(
                                Data,
                                App))))
                {
                    conn.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            query,
                            conn);

                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(
                            item.Key,
                            item.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message);
            }
        }

        private void ClearControl()
        {
            txtShelfLife.Clear();

            txtShelfLifeValue.Clear();

            cmbShelfLifeUnit.SelectedIndex = -1;

            chkIsActive.Checked = true;
            btnClear.Visible = false;
            txtShelfLife.Focus();
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearControl();

            editid = null;

            btnSave.Text = "ADD";
            btnClear.Visible = false;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShelfLifeClass item = gvShelfLife.GetFocusedRow() as ShelfLifeClass;

            if (item == null)
                return;

            editid = item.Id.ToString();

            txtShelfLife.Text = item.ShelfLifeName;
            txtShelfLifeValue.Text = item.ShelfLifeValue.ToString();
            cmbShelfLifeUnit.Text = item.ShelfLifeUnit;
            chkIsActive.Checked = item.IsActive;

            btnSave.Text = "Update";
            txtShelfLife.Focus();
            btnClear.Visible = true;

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShelfLifeClass item = gvShelfLife.GetFocusedRow() as ShelfLifeClass;

            if (item == null)
                return;

            DialogResult result = XtraMessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string query = @"
            DELETE FROM [DBJuJuBi].[dbo].[ShelfLife]
            WHERE ShelfLifeId = @ShelfLifeId";

                ExecuteNonQuery(
                    query,
                    new Dictionary<string, object>
                    {
                { "@ShelfLifeId", item.Id }
                    });

                XtraMessageBox.Show("Deleted Successfully");

                LoadData();
                ClearControl();

                editid = null;
                btnSave.Text = "Save";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }

    public class ShelfLifeClass
    {
        public int Id { get; set; }

        public string ShelfLifeName { get; set; }

        public bool IsActive { get; set; }

        public int ShelfLifeValue { get; set; }

        public string ShelfLifeUnit { get; set; }
    }
}