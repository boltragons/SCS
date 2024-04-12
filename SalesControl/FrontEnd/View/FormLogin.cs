using SalesControl.BackEnd;
using SalesControl.BackEnd.Components;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SalesControl.FrontEnd.View {
    public partial class FormLogin : Form {

        public FormLogin() {
            InitializeComponent();
            CenterToScreen();
        }

        private Employee VerifyUser(User user) {
            foreach (Employee employee in BackEndAdapter.GetEmployees().GetComponents().Values.Cast<Employee>()) {
                if (employee.GetUser() != null && employee.GetUser().Equals(user)) {
                    return employee;
                }
            }
            return null;
        }

        private void LoginButtonClickEvent(object sender, System.EventArgs e) {
            try {
                User user = new User(login_txt.Text, password_txt.Text);
                Employee employee = VerifyUser(user);
                if (employee == null) {
                    FrontEndAdapter.ErrorPopUp("Wrong login or password. Try again.");
                    return;
                }

                this.Hide(); /* Esconde o formulário */
                FormMain form = new FormMain(employee); /* Cria a tela principal */
                form.Closed += (s, args) => this.Close(); /* Fecha a tela login */
                form.Show(); /* Mostra a tela principal */
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }
    }
}
