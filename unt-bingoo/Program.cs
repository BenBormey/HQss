using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.view.User;
using unt_bingoo.view.Outlet;
using unt_bingoo.view.Product;
using unt_bingoo.view.Report;
using unt_bingoo.view.Sales;
using unt_bingoo.view;
using unt_bingoo.view.Branch;

namespace unt_bingoo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
