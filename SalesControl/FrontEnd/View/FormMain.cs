using SalesControl.FrontEnd.View;
using System;
using System.Windows.Forms;
using SalesControl.BackEnd.Components;
using SalesControl.BackEnd;
using static System.Net.Mime.MediaTypeNames;

namespace SalesControl.FrontEnd.View {
    public partial class FormMain : Form {

        private readonly Employee employee;

        public FormMain(Employee employee) {
            this.employee = employee;

            InitializeComponent();

            /* Build the Welcome label */
            user_lbl.Text = "Welcome " + employee.GetName() + "!";
            if (employee.IsManager()) {
                user_lbl.Text += " (Manager)";
            }

            /* If not a manager, the user cannot modify the system database */
            else {
                employees_btn.Enabled = false;
                products_btn.Enabled = false;
                restore_backup_btn.Enabled = false;
            }
        }

        private void EmployeesButtonClickEvent(object sender, EventArgs e) {
            FormEmployee form = new FormEmployee();
            this.AddOwnedForm(form);
            form.Show();
        }

        private void ProductsButtonClickEvent(object sender, EventArgs e) {
            FormProduct form = new FormProduct();
            this.AddOwnedForm(form);
            form.Show();
        }

        private void CartButtonClickEvent(object sender, EventArgs e) {
            FormCart form = new FormCart();
            this.AddOwnedForm(form);
            form.Show();
        }

        private void QuitSessionButtonClickEvent(object sender, EventArgs e) {
            this.Hide();
            FormLogin form = new FormLogin();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void MakeBackupButtonClickEvent(object sender, EventArgs e) {
            SaveFileDialog file_dialog = new SaveFileDialog {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Title = "Select the file to save the backup",
                DefaultExt = "scs",
                CheckPathExists = true,
                Filter = "scs files (*.scs)|*.scs|All files (*.*)|*.*",
                FilterIndex = 1
            };

            if (file_dialog.ShowDialog() == DialogResult.OK) {
                BackEndAdapter.SaveData(file_dialog.FileName);
            }
        }

        private void RestoreBackupButtonClickEvent(object sender, EventArgs e) {
            OpenFileDialog file_dialog = new OpenFileDialog {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Title = "Select the file to restore the backup",
                DefaultExt = "scs",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "scs files (*.scs)|*.scs|All files (*.*)|*.*",
                FilterIndex = 1
            };
            if (file_dialog.ShowDialog() == DialogResult.OK) {
                BackEndAdapter.LoadData(file_dialog.FileName);
            }
        }

        private void AboutBtnClickEvent(object sender, EventArgs e) {
            FormAbout form = new FormAbout();
            this.AddOwnedForm(form);
            form.Show();
        }
    }
}
