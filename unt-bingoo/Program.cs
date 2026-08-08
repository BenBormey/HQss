using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.view.User;
using unt_bingoo.view.Outlet;
using unt_bingoo.view.Product;

using unt_bingoo.view;
using unt_bingoo.view.Branch;
using unt_bingoo.Diagnostics;

namespace unt_bingoo
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            CrashLogger.Initialize();
            GlobalExceptionHandler.Install();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new guiLogin());
            }
            catch (Exception ex)
            {
                // guiLogin's constructor builds APIsController, which can throw
                // before the message loop starts (e.g. appsettings.json missing
                // ApiBaseUrl). GlobalExceptionHandler's hooks are for exceptions
                // during/after the message loop and do not reliably see this, so
                // this is the last chance to show something actionable instead of
                // a bare Windows crash dialog.
                CrashLogger.Log(ex, CrashSource.NonUiThread, CrashSeverity.Fatal, "Fatal - startup aborted");
                MessageBox.Show(ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
