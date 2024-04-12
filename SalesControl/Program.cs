using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using SalesControl.BackEnd;
using SalesControl.FrontEnd.View;

namespace SalesControl {
    internal static class Program {

        [STAThread]
        static void Main() {
            // Set culture to USA
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* Initialize the Back-end */
            BackEndAdapter.Init();

            Application.Run(new FormLogin());

            /* Ensure data persistence */
            BackEndAdapter.SaveData();
        }
    }
}
