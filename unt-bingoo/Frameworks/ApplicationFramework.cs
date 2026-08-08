using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Diagnostics;

namespace unt_bingoo.Frameworks
{
    public class ApplicationFramework
    {
        public enum Rounds
        {
            RoundUp = 1,
            RoundDown = 2,
            RoundUp_RoundDown = 3
        }

        public double RoundUpAndDownKhmerCurrency(double RAmount, Rounds RoundValue = Rounds.RoundUp_RoundDown, int Digit = 2)
        {
            double RKhmerAmount = Math.Round(RAmount, 0);
            string RSplitAmount = RKhmerAmount.ToString();
            if (RSplitAmount.Length > Digit.ToString().Length)
            {
                RSplitAmount = RSplitAmount.Substring(RSplitAmount.Length - (Digit - 1), RSplitAmount.Length - (RSplitAmount.Length - (Digit - 1)));
                if (Convert.ToInt32(RSplitAmount) == 0)
                {
                    RSplitAmount = "0";
                }
                else
                {
                    if (RoundValue == Rounds.RoundUp_RoundDown)
                    {
                        if (Convert.ToInt32(RSplitAmount) < 50)
                        {
                            RSplitAmount = (-Convert.ToInt32(RSplitAmount)).ToString();
                        }
                        else
                        {
                            RSplitAmount = (100 - Convert.ToInt32(RSplitAmount)).ToString();
                        }
                    }
                    else if (RoundValue == Rounds.RoundUp)
                    {
                        RSplitAmount = (100 - Convert.ToInt32(RSplitAmount)).ToString();
                    }
                    else
                    {
                        RSplitAmount = (-Convert.ToInt32(RSplitAmount)).ToString();
                    }
                }
            }
            else
            {
                RSplitAmount = "0";
            }
            return RKhmerAmount + Convert.ToInt32(RSplitAmount);
        }
        public DataTable GetAllMonthInKhmerNumberUnicode()
        {
            DataTable RTableTemp = new DataTable();
            RTableTemp.Columns.Add("FullMonthName", typeof(string));
            RTableTemp.Columns.Add("MonthName", typeof(int));

            DataRow RRowTemp;
            for (int DIndex = 1; DIndex <= 10; DIndex++)
            {
                RRowTemp = RTableTemp.NewRow();
                if (DIndex == 1)
                {
                    RRowTemp["FullMonthName"] = string.Format("ក្នុង{0}កេស ({1} Carton)", ChangeMonthToKhmerNumberUnicode(DIndex), DIndex);
                    RRowTemp["MonthName"] = DIndex;
                }
                else
                {
                    RRowTemp["FullMonthName"] = string.Format("ក្នុង{0}កេស ({1} Cartons)", ChangeMonthToKhmerNumberUnicode(DIndex), DIndex);
                    RRowTemp["MonthName"] = DIndex;
                }
                RTableTemp.Rows.Add(RRowTemp);
            }

            RRowTemp = RTableTemp.NewRow();
            RRowTemp["FullMonthName"] = "-";
            RRowTemp["MonthName"] = 0;
            RTableTemp.Rows.Add(RRowTemp);

            for (int DIndex = 1; DIndex <= 12; DIndex++)
            {
                RRowTemp = RTableTemp.NewRow();
                if (DIndex == 1)
                {
                    RRowTemp["FullMonthName"] = string.Format("ក្នុង{0}ខែ ({1} Month)", ChangeMonthToKhmerNumberUnicode(DIndex), DIndex);
                }
                else
                {
                    RRowTemp["FullMonthName"] = string.Format("ក្នុង{0}ខែ ({1} Months)", ChangeMonthToKhmerNumberUnicode(DIndex), DIndex);
                }
                RRowTemp["MonthName"] = 10 + DIndex;
                RTableTemp.Rows.Add(RRowTemp);
            }

            return RTableTemp;
        }

        public string ChangeNumberToKhmerUnicode(string Value)
        {
            Value = Value.Replace("0", "០")
                         .Replace("1", "១")
                         .Replace("2", "២")
                         .Replace("3", "៣")
                         .Replace("4", "៤")
                         .Replace("5", "៥")
                         .Replace("6", "៦")
                         .Replace("7", "៧")
                         .Replace("8", "៨")
                         .Replace("9", "៩");
            return Value;
        }

        public DataTable GetAllMonthInKhmerUnicode()
        {
            DataTable RTableTemp = new DataTable();
            RTableTemp.Columns.Add("FullMonthName", typeof(string));
            RTableTemp.Columns.Add("MonthName", typeof(int));

            for (int DIndex = 1; DIndex <= 12; DIndex++)
            {
                DataRow RRowTemp = RTableTemp.NewRow();
                if (DIndex == 1)
                {
                    RRowTemp["FullMonthName"] = string.Format("{0} ខែ ({1} Month)", ChangeNumberToKhmerUnicode(DIndex.ToString()), DIndex);
                }
                else
                {
                    RRowTemp["FullMonthName"] = string.Format("{0} ខែ ({1} Months)", ChangeNumberToKhmerUnicode(DIndex.ToString()), DIndex);
                }
                RRowTemp["MonthName"] = DIndex;
                RTableTemp.Rows.Add(RRowTemp);
            }

            return RTableTemp;
        }

        public string ChangeDateToKhmerUnicode(DateTime Value)
        {

            string khmerMonth = "";

            switch (Value.Month)
            {
                case 1: khmerMonth = "មករា"; break;
                case 2: khmerMonth = "កុម្ភះ"; break;
                case 3: khmerMonth = "មិនា"; break;
                case 4: khmerMonth = "មេសា"; break;
                case 5: khmerMonth = "ឧសភា"; break;
                case 6: khmerMonth = "មិថុនា"; break;
                case 7: khmerMonth = "កក្កដា"; break;
                case 8: khmerMonth = "សីហា"; break;
                case 9: khmerMonth = "កញ្ញា"; break;
                case 10: khmerMonth = "តុលា"; break;
                case 11: khmerMonth = "វិច្ឆិកា"; break;
                case 12: khmerMonth = "ធ្នូ"; break;
                default: khmerMonth = ""; break;
            }

            string formattedDate = string.Format("{0:dd}-{1}-{0:yy}", Value, khmerMonth);

            // Assuming ChangeNumberToKhmerUnicode is another method you have defined
            return ChangeNumberToKhmerUnicode(formattedDate);



        }
        public string ChangeMonthToKhmerUnicode(int Value)
        {
            string RKhmerMonth = "";

            switch (Value)
            {
                case 1: RKhmerMonth = "មករា"; break;
                case 2: RKhmerMonth = "កុម្ភះ"; break;
                case 3: RKhmerMonth = "មិនា"; break;
                case 4: RKhmerMonth = "មេសា"; break;
                case 5: RKhmerMonth = "ឧសភា"; break;
                case 6: RKhmerMonth = "មិថុនា"; break;
                case 7: RKhmerMonth = "កក្កដា"; break;
                case 8: RKhmerMonth = "សីហា"; break;
                case 9: RKhmerMonth = "កញ្ញា"; break;
                case 10: RKhmerMonth = "តុលា"; break;
                case 11: RKhmerMonth = "វិច្ឆិកា"; break;
                case 12: RKhmerMonth = "ធ្នូ"; break;
                default: RKhmerMonth = ""; break;
            }

            return RKhmerMonth;
        }

        public string ChangeMonthToKhmerNumberUnicode(int Value)
        {
            string RKhmerMonth = "";
            switch (Value)
            {
                case 1: RKhmerMonth = "មួយ"; break;
                case 2: RKhmerMonth = "ពីរ"; break;
                case 3: RKhmerMonth = "បី"; break;
                case 4: RKhmerMonth = "បួន"; break;
                case 5: RKhmerMonth = "ប្រាំ"; break;
                case 6: RKhmerMonth = "ប្រាំមួយ"; break;
                case 7: RKhmerMonth = "ប្រាំពីរ"; break;
                case 8: RKhmerMonth = "ប្រាំបី"; break;
                case 9: RKhmerMonth = "ប្រាំបួន"; break;
                case 10: RKhmerMonth = "ដប់"; break;
                case 11: RKhmerMonth = "ដប់មួយ"; break;
                case 12: RKhmerMonth = "ដប់ពីរ"; break;
                default: RKhmerMonth = ""; break;
            }
            return RKhmerMonth;
        }

        public DataTable GetKhmerProvince()
        {
            DataTable rTableTemp = new DataTable();

            rTableTemp.Columns.Add("FullProvinceName", typeof(string));
            rTableTemp.Columns.Add("ProvinceName", typeof(string));


            DataRow rRowTemp;

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ភ្នំពេញ (Phnom Penh)";
            rRowTemp["ProvinceName"] = "Phnom Penh";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "បន្ទាយមានជ័យ (Banteay Meanchey)";
            rRowTemp["ProvinceName"] = "Banteay Meanchey";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "បាត់ដំបង (Battambang)";
            rRowTemp["ProvinceName"] = "Battambang";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កំពង់ចាម (Kampong Cham)";
            rRowTemp["ProvinceName"] = "Kampong Cham";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កំពង់ឆ្នាំង (Kampong Chhnang)";
            rRowTemp["ProvinceName"] = "Kampong Chhnang";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កំពង់ស្ពឺ (Kampong Speu)";
            rRowTemp["ProvinceName"] = "Kampong Speu";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កំពង់ធំ (Kampong Thom)";
            rRowTemp["ProvinceName"] = "Kampong Thom";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កំពត (Kampot)";
            rRowTemp["ProvinceName"] = "Kampot";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កណ្តាល (Kandal)";
            rRowTemp["ProvinceName"] = "Kandal";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កោះកុង (Koh Kong)";
            rRowTemp["ProvinceName"] = "Koh Kong";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "កែប (Kep)";
            rRowTemp["ProvinceName"] = "Kep";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ក្រចេះ (Kratié)";
            rRowTemp["ProvinceName"] = "Kratié";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "មណ្ឌលគីរី (Mondulkiri)";
            rRowTemp["ProvinceName"] = "Mondulkiri";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ឧត្តរមានជ័យ (Oddar Meanchey)";
            rRowTemp["ProvinceName"] = "Oddar Meanchey";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "បៃលិន (Pailin)";
            rRowTemp["ProvinceName"] = "Pailin";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ព្រះសីហនុ (Preah Sihanouk)";
            rRowTemp["ProvinceName"] = "Preah Sihanouk";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ព្រះវិហារ (Preah Vihear)";
            rRowTemp["ProvinceName"] = "Preah Vihear";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ពោធិ៍សាត់ (Pursat)";
            rRowTemp["ProvinceName"] = "Pursat";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ព្រៃវែង (Prey Veng)";
            rRowTemp["ProvinceName"] = "Prey Veng";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "រតនគីរី (Ratanakiri)";
            rRowTemp["ProvinceName"] = "Ratanakiri";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "សៀមរាប (Siem Reap)";
            rRowTemp["ProvinceName"] = "Siem Reap";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ស្ទឹងត្រែង (Stung Treng)";
            rRowTemp["ProvinceName"] = "Stung Treng";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ស្វាយរៀង (Svay Rieng)";
            rRowTemp["ProvinceName"] = "Svay Rieng";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "តាកែវ (Takéo)";
            rRowTemp["ProvinceName"] = "Takéo";
            rTableTemp.Rows.Add(rRowTemp);

            rRowTemp = rTableTemp.NewRow();
            rRowTemp["FullProvinceName"] = "ត្បូងឃ្មុំ (Tboung Khmum)";
            rRowTemp["ProvinceName"] = "Tboung Khmum";
            rTableTemp.Rows.Add(rRowTemp);

            return rTableTemp;

        }

        public bool IsNotAllowBlank(object[] controlNames, ErrorProvider providerName, string message = "Cannot Zero!",
    ErrorIconAlignment alignment = ErrorIconAlignment.MiddleRight, ErrorBlinkStyle style = ErrorBlinkStyle.NeverBlink,
    bool conditionIsZero = false)
        {
            bool rReturn = false;
            bool rIsBlank = false;

            foreach (var item in controlNames)
            {
                if (item is TextBox || item is ComboBox || item is MaskedTextBox)
                {
                    if (conditionIsZero)
                    {
                        if (item is Control control && control.Text.Trim() == "0")
                        {
                            rIsBlank = true;
                        }
                        else
                        {
                            rIsBlank = false;
                        }
                    }
                    else
                    {
                        if (item is Control control && string.IsNullOrEmpty(control.Text))
                        {
                            rIsBlank = true;
                        }
                        else
                        {
                            rIsBlank = false;
                        }
                    }
                }
                else if (item is CheckBox checkBox)
                {
                    rIsBlank = !checkBox.Checked;
                }
                else if (item is RadioButton radioButton)
                {
                    rIsBlank = !radioButton.Checked;
                }
                else if (item is PictureBox pictureBox)
                {
                    rIsBlank = pictureBox.Image == null;
                }

                if (rIsBlank)
                {
                    if (item is Control control)
                    {
                        providerName.SetError(control, message);
                        providerName.SetIconAlignment(control, alignment);
                        providerName.BlinkStyle = style;
                        rReturn = true;
                    }
                }
                else
                {
                    if (item is Control control)
                    {
                        providerName.SetError(control, null);
                    }
                }
            }

            return rReturn;
        }
        private KeyPressEventArgs key;
        public enum TypeKeyPress
        {
            Format_Number,
            Format_Float,
            Format_Amount,
            Format_UppercaseText,
            Format_LowercaseText,
            Normal
        }
        public void KeyPress(object sender, KeyPressEventArgs e, TypeKeyPress type = TypeKeyPress.Format_Number, string allowCharacter = "", int length = 100)
        {
            if (allowCharacter == null)
                allowCharacter = "";

            var control = sender as TextBox;
            if (control == null)
                return;

            if (control.Text.Length >= length && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            if (type == TypeKeyPress.Normal)
            {
                if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                    e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
                else
                {
                    if (!allowCharacter.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (type == TypeKeyPress.Format_UppercaseText)
            {
                if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                    e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
                {
                    if (e.KeyChar >= 'a' && e.KeyChar <= 'z' && e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Back)
                    {
                        e.KeyChar = char.ToUpper(e.KeyChar);
                    }
                    return;
                }
                else
                {
                    if (!allowCharacter.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (type == TypeKeyPress.Format_LowercaseText)
            {
                if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                    e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
                {
                    if (e.KeyChar >= 'A' && e.KeyChar <= 'Z' && e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Back)
                    {
                        e.KeyChar = char.ToLower(e.KeyChar);
                    }
                    return;
                }
                else
                {
                    if (!allowCharacter.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (type == TypeKeyPress.Format_Number)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
                else
                {
                    if (!allowCharacter.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (type == TypeKeyPress.Format_Float)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back || e.KeyChar == '.')
                {
                    if (e.KeyChar == '.' && control.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                    return;
                }
                else
                {
                    if (!allowCharacter.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (type == TypeKeyPress.Format_Amount)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back || e.KeyChar == '.')
                {
                    if (e.KeyChar == '.' && control.Text.Contains("."))
                    {
                        e.Handled = true;
                        return;
                    }

                    if (control.Text.Contains("."))
                    {
                        return;
                    }

                    key = e;
                    KP = true;
                    control.TextChanged += KeyTextChanged;
                    return;
                }
                else
                {
                    if (!allowCharacter.Contains(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private long Index;
        private string R_Text;
        private bool KP;

        private void KeyTextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Contains("."))
                return;

            try
            {
                if (KP == true)
                {
                    Index = ((TextBox)sender).SelectionStart == 0 ? Index : ((TextBox)sender).SelectionStart;
                    R_Text = string.Format("{0:#,###,###,###,###,###,###,###,##0}", Convert.ToDecimal(((TextBox)sender).Text));

                    // Uncomment if needed: int R_More = R_Text.Count(c => c == ',');

                    if (key.KeyChar == (char)Keys.Back)
                    {
                        Index -= 1;
                    }
                    else
                    {
                        Index += 1;
                    }

                    KP = false;
                    ((TextBox)sender).Text = R_Text;
                }

                KP = false;
                ((TextBox)sender).SelectionStart = (int)Index;
            }
            catch (Exception ex)
            {
                // Malformed intermediate text while typing (Convert.ToDecimal) is the
                // expected case; the textbox just keeps whatever it already had.
                CrashLogger.Log(ex, CrashSource.UiThread, CrashSeverity.Recoverable, "Recoverable - amount formatting skipped for this keystroke");
            }
        }
        public byte[] ImagetoByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image BytetoImage(byte[] byt)
        {
            using (MemoryStream ms = new MemoryStream(byt))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public Image ResizeImage(Image img)
        {
            Bitmap bitSource = new Bitmap(img);  // Convert image to bitmap for manipulation
            Bitmap bitDesign = new Bitmap((int)(bitSource.Width * 0.7), (int)(bitSource.Height * 0.7), System.Drawing.Imaging.PixelFormat.Format24bppRgb);  // Resized bitmap
            bitDesign.MakeTransparent(bitDesign.GetPixel(1, 1));  // Set transparency based on a pixel color
            using (Graphics graDesign = Graphics.FromImage(bitDesign))  // Create graphics object from the new image
            {
                graDesign.DrawImage(bitSource, 0, 0, bitDesign.Width, bitDesign.Height);  // Resize and draw the image onto the new bitmap
            }
            img = bitDesign;  // Assign resized image to img
            return img;  // Return the resized image
        }
        public Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;

            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = Math.Min(percentWidth, percentHeight);
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
        public int GetDayPerMonth(DateTime dates)
        {
            switch (dates.Month)
            {
                case 1: return 31;
                case 2:
                    if (DateTime.IsLeapYear(dates.Year))
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: return 0;
            }
        }
        public string ConvertTextToPassword(string password, string key = "")
        {
            string encryptionKey = string.IsNullOrWhiteSpace(key) ? "26M0S6R1I9T8H91" : key;
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);

            using (Aes encryptor = Aes.Create())
            {
                byte[] salt = new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
                var pdb = new Rfc2898DeriveBytes(encryptionKey, salt);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    password = Convert.ToBase64String(ms.ToArray());
                    // password = "7nbUhg2myMU1amJ3jZ50H/QC/O+HFR/u4MRkq3LhhnQ=";
                }
            }

            return password;
        }


        public string ConvertPasswordToText(string password, string key = "")
        {
            string encryptionKey = string.IsNullOrWhiteSpace(key) ? "26M0S6R1I9T8H91" : key;
            byte[] cipherBytes = Convert.FromBase64String(password);

            using (Aes encryptor = Aes.Create())
            {
                byte[] salt = new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
                var pdb = new Rfc2898DeriveBytes(encryptionKey, salt);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return password;
        }
        public void SetEnableController(bool statusValue, params Control[] controlName)
        {
            foreach (var control in controlName)
            {
                control.Enabled = statusValue;
            }
        }
        public void SetVisibleController(bool statusValue, params Control[] controlName)
        {
            foreach (var control in controlName)
            {
                control.Visible = statusValue;
            }
        }
        public void SetReadOnlyController(bool statusValue, params TextBox[] controlName)
        {
            foreach (var control in controlName)
            {
                control.ReadOnly = statusValue;
            }
        }

        public void ClearController(Form formName, params Control[] exceptionControlName)
        {
            foreach (Control c in formName.Controls)
            {
                if (exceptionControlName.Length > 0)
                {
                    foreach (var e in exceptionControlName)
                    {
                        if (c.Name.Equals(e.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            goto OverStep;
                        }
                    }
                }

                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)c;
                    if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
                    {
                        comboBox.Text = "";
                    }
                    else if (comboBox.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }

                OverStep:
                continue;
            }
        }
        public void ClearController(params Control[] controlName)
        {
            foreach (Control c in controlName)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)c;
                    if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
                    {
                        comboBox.Text = "";
                    }
                    else if (comboBox.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }
            }
        }
        public void ReleaseObject(ref object o)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
                {
                }
            }
            catch
            {
                // Optional: Add logging or handling here if necessary.
            }
            finally
            {
                o = null;
            }
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }

            }
            catch
            {
                return false;
            }
        }

    }




    public class SwitchKeyboardLanguage
    {
        // Declare the external functions from user32.dll using DllImport
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern long GetKeyboardLayoutName(StringBuilder pwszKLID);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern long LoadKeyboardLayout(string pwszKLID, long flags);

        // Constant for KLF_ACTIVATE flag
        public const long KLF_ACTIVATE = 0x00000001;


        public enum Type_Of_Language
        {
            LANG_ENGLISH,
            LANG_FRENCH,
            LANG_ARABIC,
            LANG_GREEK,
            LANG_KHMER,
            LANG_ITALIAN,
            LANG_GERMAN
        }

        public bool SwitchKeyboardLang(Type_Of_Language language)
        {
            string keyboardLanguage = "";

            switch (language)
            {
                case Type_Of_Language.LANG_ARABIC:
                    keyboardLanguage = "00000401";
                    break;
                case Type_Of_Language.LANG_ENGLISH:
                    keyboardLanguage = "00000409";
                    break;
                case Type_Of_Language.LANG_FRENCH:
                    keyboardLanguage = "0000040C";
                    break;
                case Type_Of_Language.LANG_GERMAN:
                    keyboardLanguage = "00000407";
                    break;
                case Type_Of_Language.LANG_GREEK:
                    keyboardLanguage = "00000408";
                    break;
                case Type_Of_Language.LANG_ITALIAN:
                    keyboardLanguage = "00000400";
                    break;
                case Type_Of_Language.LANG_KHMER:
                    keyboardLanguage = "a0000403";
                    break;
                default:
                    return false; // Invalid language
            }

            StringBuilder strRet = new StringBuilder(9);
            // Get current keyboard layout name
            GetKeyboardLayoutName(strRet);

            // If already set to the desired language, return true
            if (strRet.ToString() == keyboardLanguage + "\0")
            {
                return true;
            }
            else
            {
                // Load the new keyboard layout
                LoadKeyboardLayout(keyboardLanguage + "\0", KLF_ACTIVATE);
            }

            // Test if the layout switch was successful
            strRet.Clear();
            GetKeyboardLayoutName(strRet);
            if (strRet.ToString() == keyboardLanguage)
            {
                return true; // Success
            }

            return false; // Failed t

        }

    }


    public class PrintToPrinter : IDisposable
    {
        private int R_CurrentPageIndex;
        private IList<Stream> R_Streams;
        private PrintDocument R_Printdoc;
        private PrintDialog R_PrintDialogs;

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            R_Streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport Report, int Width, int Height)
        {
            string deviceInfo = "<DeviceInfo>" +
                                "<OutputFormat>EMF</OutputFormat>" +
                                "<PageWidth>" + (Width / 100) + "in</PageWidth>" +
                                "<PageHeight>" + (Height / 100) + "in</PageHeight>" +
                                "<MarginTop>0.0in</MarginTop>" +
                                "<MarginLeft>0.0in</MarginLeft>" +
                                "<MarginRight>0.0in</MarginRight>" +
                                "<MarginBottom>0.0in</MarginBottom>" +
                                "</DeviceInfo>";
            Microsoft.Reporting.WinForms.Warning[] warnings;
            R_Streams = new List<Stream>();
            Report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in R_Streams)
            {
                stream.Position = 0;
            }
        }
        public void Print(int copies = 1)
        {
            if (R_Streams == null || R_Streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }

            if (!R_Printdoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }

            // Subscribe to the PrintPage event to handle page printing
            R_Printdoc.PrintPage += PrintPage;

            // Set the number of copies
            R_Printdoc.PrinterSettings.Copies = (short)copies;

            // Reset the current page index and start printing
            R_CurrentPageIndex = 0;
            R_Printdoc.Print();
        }


        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(R_Streams[R_CurrentPageIndex]);
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            R_CurrentPageIndex++;
            ev.HasMorePages = (R_CurrentPageIndex < R_Streams.Count);
        }



        public void PrintReport(ref LocalReport Report, int Copies = 1, PaperKind PaperKind = PaperKind.A4, bool IsLandscap = false, string PrinterName = null, bool PrintDialogs = false)
        {
            int w, h;
            R_Printdoc = new PrintDocument();

            if (!string.IsNullOrWhiteSpace(PrinterName))
                R_Printdoc.PrinterSettings.PrinterName = PrinterName;

            if (!R_Printdoc.PrinterSettings.IsValid)
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize Paper = new PaperSize();

                if (PaperKind == PaperKind.A4)
                {
                    Paper = new PaperSize("A4", R_Printdoc.DefaultPageSettings.PaperSize.Width, R_Printdoc.DefaultPageSettings.PaperSize.Height);
                    Paper.RawKind = (int)PaperKind.A4;
                    R_Printdoc.DefaultPageSettings.PaperSize = Paper;
                }
                else
                {
                    bool PagekindFound = false;
                    for (int i = 0; i < R_Printdoc.PrinterSettings.PaperSizes.Count; i++)
                    {
                        if (string.Compare(R_Printdoc.PrinterSettings.PaperSizes[i].Kind.ToString(), PaperKind.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            Paper = R_Printdoc.PrinterSettings.PaperSizes[i];
                            R_Printdoc.DefaultPageSettings.PaperSize = Paper;
                            PagekindFound = true;
                            break;
                        }
                    }
                    if (!PagekindFound)
                    {
                        throw new Exception("Paper size is invalid!");
                    }
                }

                R_Printdoc.DefaultPageSettings.Margins.Top = 100;
                R_Printdoc.DefaultPageSettings.Margins.Bottom = 100;
                R_Printdoc.DefaultPageSettings.Margins.Left = 100;
                R_Printdoc.DefaultPageSettings.Margins.Right = 100;

                if (R_Printdoc.DefaultPageSettings.Landscape)
                {
                    w = R_Printdoc.DefaultPageSettings.PaperSize.Height;
                    h = R_Printdoc.DefaultPageSettings.PaperSize.Width;
                }
                else
                {
                    w = R_Printdoc.DefaultPageSettings.PaperSize.Width;
                    h = R_Printdoc.DefaultPageSettings.PaperSize.Height;
                }

                R_Printdoc.DefaultPageSettings.Landscape = IsLandscap;

                Export(Report, w, h);

                if (PrintDialogs)
                {
                    R_PrintDialogs = new PrintDialog { Document = R_Printdoc };
                    if (R_PrintDialogs.ShowDialog() == DialogResult.OK)
                        Print(Copies);
                }
                else
                {
                    Print(Copies);
                }
            }
        }



        #region "IDisposable Support"
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                }

                // Dispose unmanaged resources (if any).
            }
            disposedValue = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            if (R_Streams != null)
            {
                foreach (Stream stream in R_Streams)
                {
                    stream.Close();
                }
                R_Streams = null;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class Printers
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private PrintDocument printdoc;
        private PrintDialog PrintDialogs;

        public void PrintToPrinterDefault(ref LocalReport report, int pageWidth, int pageHeight, bool islandscap = false, string printerName = null)
        {
            printdoc = new PrintDocument();

            if (printerName != null)
            {
                printdoc.PrinterSettings.PrinterName = printerName;
            }

            if (!printdoc.PrinterSettings.IsValid) // Detect if the printer exists
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps = new PaperSize("Custom", pageWidth, pageHeight);
                printdoc.DefaultPageSettings.PaperSize = ps;
                printdoc.DefaultPageSettings.Landscape = islandscap;

                Export(report);
                Print();
            }
        }
        public void PrintToPrinterPrintDialog(ref LocalReport report, int pageWidth, int pageHeight, bool islandscap = false, string printerName = null)
        {
            printdoc = new PrintDocument();
            PrintDialogs = new PrintDialog();

            if (printerName != null)
            {
                printdoc.PrinterSettings.PrinterName = printerName;
            }

            if (!printdoc.PrinterSettings.IsValid) // Detect if the printer exists
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps = new PaperSize("Custom", pageWidth, pageHeight);
                printdoc.DefaultPageSettings.PaperSize = ps;
                printdoc.DefaultPageSettings.Landscape = islandscap;

                Export(report);
                PrintDialogs.Document = printdoc;

                if (PrintDialogs.ShowDialog() == DialogResult.OK)
                {
                    Print();
                }
            }
        }
        public void PrintToPrinterDefault(LocalReport report, int printCopies = 1, string paperKind = "A4", bool islandscap = false, string printerName = null)
        {
            printdoc = new PrintDocument();

            if (printerName != null)
            {
                printdoc.PrinterSettings.PrinterName = printerName;
            }

            if (!printdoc.PrinterSettings.IsValid) // Detect if the printer exists
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps = null;
                bool pageKindFound = false;

                for (int i = 0; i < printdoc.PrinterSettings.PaperSizes.Count; i++)
                {
                    if (printdoc.PrinterSettings.PaperSizes[i].Kind.ToString() == paperKind)
                    {
                        ps = printdoc.PrinterSettings.PaperSizes[i];
                        printdoc.DefaultPageSettings.PaperSize = ps;
                        pageKindFound = true;
                        break;
                    }
                }

                if (!pageKindFound)
                {
                    throw new Exception("Paper size is invalid");
                }

                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                Print(printCopies);
            }
        }
        public void PrintToPrinterPrintDialog(LocalReport report, string paperKind = "A4", bool islandscap = false, string printerName = null)
        {
            printdoc = new PrintDocument();
            PrintDialogs = new PrintDialog();

            if (printerName != null)
            {
                printdoc.PrinterSettings.PrinterName = printerName;
            }

            if (!printdoc.PrinterSettings.IsValid) // Detect if the printer exists
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps = null;
                bool pageKindFound = false;

                for (int i = 0; i < printdoc.PrinterSettings.PaperSizes.Count; i++)
                {
                    if (printdoc.PrinterSettings.PaperSizes[i].Kind.ToString() == paperKind)
                    {
                        ps = printdoc.PrinterSettings.PaperSizes[i];
                        printdoc.DefaultPageSettings.PaperSize = ps;
                        pageKindFound = true;
                        break;
                    }
                }

                if (!pageKindFound)
                {
                    throw new Exception("Paper size is invalid");
                }

                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                PrintDialogs.Document = printdoc;

                if (PrintDialogs.ShowDialog() == DialogResult.OK)
                {
                    Print();
                }
            }
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            int w, h;

            if (printdoc.DefaultPageSettings.Landscape)
            {
                w = printdoc.DefaultPageSettings.PaperSize.Height;
                h = printdoc.DefaultPageSettings.PaperSize.Width;
            }
            else
            {
                w = printdoc.DefaultPageSettings.PaperSize.Width;
                h = printdoc.DefaultPageSettings.PaperSize.Height;
            }

            string deviceInfo = "<DeviceInfo>" +
                "<OutputFormat>EMF</OutputFormat>" +
                "<PageWidth>" + (w / 100) + "in</PageWidth>" +
                "<PageHeight>" + (h / 100) + "in</PageHeight>" +
                "<MarginTop>0.0in</MarginTop>" +
                "<MarginLeft>0.0in</MarginLeft>" +
                "<MarginRight>0.0in</MarginRight>" +
                "<MarginBottom>0.0in</MarginBottom>" +
                "</DeviceInfo>";

            Microsoft.Reporting.WinForms.Warning[] warnings = null;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                                                   ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                                                   ev.PageBounds.Width,
                                                   ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print(int printCopies = 1)
        {
            if (m_streams == null || m_streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }

            printdoc.PrintPage += new PrintPageEventHandler(PrintPage);
            m_currentPageIndex = 0;
            printdoc.PrinterSettings.Copies = (short)printCopies;
            printdoc.Print();
        }
    }
    public class Properties
    {
        private float R_PageWidth;
        public float PageWidth
        {
            get { return R_PageWidth; }
            set { R_PageWidth = value; }
        }

        private float R_PageHeight;
        public float PageHeight
        {
            get { return R_PageHeight; }
            set { R_PageHeight = value; }
        }

        private float R_MarginTop;
        public float MarginTop
        {
            get { return R_MarginTop; }
            set { R_MarginTop = value; }
        }

        private float R_MarginLeft;
        public float MarginLeft
        {
            get { return R_MarginLeft; }
            set { R_MarginLeft = value; }
        }

        private float R_MarginRight;
        public float MarginRight
        {
            get { return R_MarginRight; }
            set { R_MarginRight = value; }
        }

        private float R_MarginBottom;
        public float MarginBottom
        {
            get { return R_MarginBottom; }
            set { R_MarginBottom = value; }
        }
    }
    public class ConvertReport : Properties
    {
        public enum Type_Converter
        {
            PDF,
            Excel
        }
        public void Save(ReportViewer viewer, string SavePath = "", Type_Converter Convert = Type_Converter.PDF, bool IsOpen = false)
        {
            if (string.IsNullOrWhiteSpace(SavePath))
            {
                SaveFileDialog SaveDialog = new SaveFileDialog();
                if (Convert == Type_Converter.PDF)
                {
                    SaveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                }
                else
                {
                    SaveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                }
                SaveDialog.FilterIndex = 2;
                SaveDialog.RestoreDirectory = true;
                if (SaveDialog.ShowDialog() == DialogResult.Cancel) return;
                SavePath = SaveDialog.FileName;
            }

            string deviceInfo = null;
            if (Convert == Type_Converter.PDF)
            {
                deviceInfo = $"<DeviceInfo>" +
                             $"<OutputFormat>PDF</OutputFormat>" +
                             $"<PageWidth>{PageWidth}in</PageWidth>" +
                             $"<PageHeight>{PageHeight}in</PageHeight>" +
                             $"<MarginTop>{MarginTop}in</MarginTop>" +
                             $"<MarginLeft>{MarginLeft}in</MarginLeft>" +
                             $"<MarginRight>{MarginRight}in</MarginRight>" +
                             $"<MarginBottom>{MarginBottom}in</MarginBottom>" +
                             $"</DeviceInfo>";
            }

            Microsoft.Reporting.WinForms.Warning[] warnings = null;
            string[] streamIds = null;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = viewer.LocalReport.Render(Convert.ToString(), deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream stream = new FileStream(SavePath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            if (IsOpen)
            {
                System.Diagnostics.Process.Start(SavePath);
            }
        }


        public enum TypeLocationReport
        {
            ReportEmbeddedResource,
            ReportPath
        }
        public void Save(TypeLocationReport Type, string FullPathReport, string SavePath = "", Type_Converter Convert = Type_Converter.PDF, bool IsOpen = false)
        {
            ReportViewer viewer = new ReportViewer();

            if (Type == TypeLocationReport.ReportEmbeddedResource)
            {
                viewer.LocalReport.ReportEmbeddedResource = FullPathReport;
            }
            else
            {
                viewer.LocalReport.ReportPath = FullPathReport;
            }

            viewer.RefreshReport();

            if (string.IsNullOrWhiteSpace(SavePath))
            {
                SaveFileDialog SaveDialog = new SaveFileDialog();
                if (Convert == Type_Converter.PDF)
                {
                    SaveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                }
                else
                {
                    SaveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                }
                SaveDialog.FilterIndex = 2;
                SaveDialog.RestoreDirectory = true;
                if (SaveDialog.ShowDialog() == DialogResult.Cancel) return;
                SavePath = SaveDialog.FileName;
            }

            string deviceInfo = null;
            if (Convert == Type_Converter.PDF)
            {
                deviceInfo = $"<DeviceInfo>" +
                             $"<OutputFormat>PDF</OutputFormat>" +
                             $"<PageWidth>{PageWidth}in</PageWidth>" +
                             $"<PageHeight>{PageHeight}in</PageHeight>" +
                             $"<MarginTop>{MarginTop}in</MarginTop>" +
                             $"<MarginLeft>{MarginLeft}in</MarginLeft>" +
                             $"<MarginRight>{MarginRight}in</MarginRight>" +
                             $"<MarginBottom>{MarginBottom}in</MarginBottom>" +
                             $"</DeviceInfo>";
            }

            Microsoft.Reporting.WinForms.Warning[] warnings = null;
            string[] streamIds = null;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = viewer.LocalReport.Render(Convert.ToString(), deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream stream = new FileStream(SavePath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            if (IsOpen)
            {
                System.Diagnostics.Process.Start(SavePath);
            }
        }
    }
    public class ConvertNumberToWord
    {
        private string[] mOnesArray = new string[9];
        private string[] mOneTensArray = new string[10];
        private string[] mTensArray = new string[8];
        private string[] mPlaceValues = new string[5];

        public ConvertNumberToWord()
        {
            mOnesArray[0] = "one";
            mOnesArray[1] = "two";
            mOnesArray[2] = "three";
            mOnesArray[3] = "four";
            mOnesArray[4] = "five";
            mOnesArray[5] = "six";
            mOnesArray[6] = "seven";
            mOnesArray[7] = "eight";
            mOnesArray[8] = "nine";

            mOneTensArray[0] = "ten";
            mOneTensArray[1] = "eleven";
            mOneTensArray[2] = "twelve";
            mOneTensArray[3] = "thirteen";
            mOneTensArray[4] = "fourteen";
            mOneTensArray[5] = "fifteen";
            mOneTensArray[6] = "sixteen";
            mOneTensArray[7] = "seventeen";
            mOneTensArray[8] = "eighteen";
            mOneTensArray[9] = "nineteen";

            mTensArray[0] = "twenty";
            mTensArray[1] = "thirty";
            mTensArray[2] = "forty";
            mTensArray[3] = "fifty";
            mTensArray[4] = "sixty";
            mTensArray[5] = "seventy";
            mTensArray[6] = "eighty";
            mTensArray[7] = "ninety";

            mPlaceValues[0] = "hundred";
            mPlaceValues[1] = "thousand";
            mPlaceValues[2] = "million";
            mPlaceValues[3] = "billion";
            mPlaceValues[4] = "trillion";
        }

        protected string GetOnes(int OneDigit)
        {
            if (OneDigit == 0)
                return "";
            return mOnesArray[OneDigit - 1];
        }

        protected string GetTens(int TensDigit)
        {
            if (TensDigit == 0 || TensDigit == 1)
                return "";
            return mTensArray[TensDigit - 2];
        }

        public enum Currencies
        {
            RIEL,
            USD
        }

        public string ConvertNumberToWords(string NumberValue, Currencies Currency = Currencies.USD)
        {
            string mNumberValue = "";
            string mFraction = "";
            double j;

            if (!double.TryParse(NumberValue, out j))
            {
                return "Invalid input.";
            }

            if (!NumberValue.Contains("."))
            {
                mNumberValue = NumberValue;
            }
            else
            {
                mNumberValue = NumberValue.Substring(0, NumberValue.IndexOf("."));
                mFraction = NumberValue.Substring(NumberValue.IndexOf(".") + 1);
                mFraction = Math.Round(Convert.ToDouble("0." + mFraction), 2).ToString(CultureInfo.InvariantCulture).Substring(2);

                if (Convert.ToInt32(mFraction) != 0)
                {
                    mFraction = $"{Currency.ToString()} And Cent {GetWord(mFraction.ToCharArray())}";
                }
            }

            string mNumWord = GetWord(mNumberValue.ToCharArray());
            return (mNumWord.Trim() + " " + (string.IsNullOrEmpty(mFraction) ? Currency.ToString() : mFraction) + " ONLY").ToUpper();
        }

        private string GetWord(char[] mNumbers)
        {
            string Delimiter = " ";
            string TensDelimiter = " ";
            string[] mNumberStack = new string[mNumbers.Length];
            bool mOneTens = false;
            string mNumWord = "";

            int i = 0;
            for (int j = mNumbers.Length - 1; j >= 0; j--)
            {
                mNumberStack[i++] = mNumbers[j].ToString();
            }

            for (int j = mNumbers.Length - 1; j >= 0; j--)
            {
                switch (j)
                {
                    case 0:
                    case 3:
                    case 6:
                    case 9:
                    case 12:
                        if (!mOneTens)
                        {
                            mNumWord += GetOnes(int.Parse(mNumberStack[j])) + Delimiter;
                        }

                        if (j == 3) mNumWord += mPlaceValues[1] + Delimiter;
                        if (j == 6) mNumWord += mPlaceValues[2] + Delimiter;
                        if (j == 9) mNumWord += mPlaceValues[3] + Delimiter;
                        if (j == 12) mNumWord += mPlaceValues[4] + Delimiter;
                        break;

                    case 1:
                    case 4:
                    case 7:
                    case 10:
                    case 13:
                        if (int.Parse(mNumberStack[j]) == 0)
                        {
                            mNumWord += GetOnes(int.Parse(mNumberStack[j - 1])) + Delimiter;
                            mOneTens = true;
                            break;
                        }

                        if (int.Parse(mNumberStack[j]) == 1)
                        {
                            mNumWord += mOneTensArray[int.Parse(mNumberStack[j - 1])] + Delimiter;
                            mOneTens = true;
                            break;
                        }

                        mNumWord += GetTens(int.Parse(mNumberStack[j]));

                        if (int.Parse(mNumberStack[j - 1]) != 0)
                        {
                            mNumWord += TensDelimiter;
                        }
                        mOneTens = false;
                        break;

                    default:
                        mNumWord += GetOnes(int.Parse(mNumberStack[j])) + Delimiter;
                        if (int.Parse(mNumberStack[j]) != 0)
                        {
                            mNumWord += mPlaceValues[0] + Delimiter;
                        }
                        break;
                }
            }

            return mNumWord;
        }
    }
}
