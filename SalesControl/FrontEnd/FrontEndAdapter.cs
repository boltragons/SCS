using System.Windows.Forms;

namespace SalesControl.FrontEnd {
    public class FrontEndAdapter {

        public static void WarningPopUp(string text) {
            MessageBox.Show(
                text,
                "Invalid Operation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void SuccessPopUp(string text) {
            MessageBox.Show(
                text,
                "Successful Operation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        public static void ErrorPopUp(string text) {
            MessageBox.Show(
                text,
                "An error has occurred",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
