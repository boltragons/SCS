using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SalesControl.BackEnd;
using SalesControl.BackEnd.Components;
using SalesControl.BackEnd.Containers;
using SalesControl.FrontEnd;

namespace SalesControl.FrontEnd.View {
    public partial class FormEmployee : Form {

        private readonly Staff employees;

        private bool edit_component = false;

        public FormEmployee() {
            employees = BackEndAdapter.GetEmployees();

            InitializeComponent();

            // Front-end Adjusts
            UpdateIDField();

            list_txt.Text = employees.ToString();

            position_cmb.SelectedIndex = 0;
        }

        private void UpdateIDField() {
            id_txt.Text = employees.GetCurrentId().ToString();
        }

        private void ClearFields() {
            name_txt.Text = "";
            phone_txt.Text = "";
            sin_txt.Text = "";
            position_cmb.SelectedIndex = 0;
            login_txt.Text = "";
            password_txt.Text = "";
        }

        private void AddButtonClickEvent(object sender, EventArgs e) {
            try {
                uint id = Convert.ToUInt32(id_txt.Text);
                Employee employee = new Employee(
                    id,
                    name_txt.Text,
                    phone_txt.Text,
                    sin_txt.Text,
                    Employee.StringToPosition(position_cmb.SelectedItem?.ToString())
                );

                if ((login_txt.Text.Length != 0 && password_txt.Text.Length == 0) ||
                    (login_txt.Text.Length == 0 && password_txt.Text.Length != 0)) {
                    throw new InvalidOperationException("To register a login or a password both must be filled.");
                }
                else if (login_txt.Text.Length != 0 && password_txt.Text.Length != 0) {
                    if (edit_component && password_txt.Text == new string('*', password_txt.Text.Length)) {
                        throw new InvalidOperationException("Insert a valid password.");
                    }
                    employee.SetUser(login_txt.Text, password_txt.Text);
                }

                employees.Add(employee);
                if (edit_component) {
                    edit_component = false;
                    add_btn.Text = "Add";
                    list_txt.Text = employees.ToString();
                    search_txt.Text = "";
                    FrontEndAdapter.SuccessPopUp("The employee has been updated.");
                }
                else {
                    employees.GetNextId();
                    list_txt.Text += employee.ToString() + "\r\n";
                    FrontEndAdapter.SuccessPopUp("The employee has been created.");
                }
                UpdateIDField();
                ClearFields();

                BackEndAdapter.SaveData();
            }
            catch (System.NullReferenceException) {
                FrontEndAdapter.ErrorPopUp("A valid position must be selected.");
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void RemoveButtonClickEvent(object sender, EventArgs e) {
            if (!edit_component) {
                FrontEndAdapter.WarningPopUp("First select an employee.");
                return;
            }
            try {
                employees.Remove(Convert.ToUInt32(id_txt.Text));

                // Build new products string
                list_txt.Text = employees.ToString();

                ClearFields();
                edit_component = false;
                add_btn.Text = "Add";
                UpdateIDField();

                FrontEndAdapter.SuccessPopUp("The employee has been deleted.");

                BackEndAdapter.SaveData();
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void SelectButtonClickEvent(object sender, EventArgs e) {
            try {
                uint id = Convert.ToUInt32(search_txt.Text);
                Employee employee = (Employee)employees.GetComponents()[id];
                id_txt.Text = search_txt.Text;
                name_txt.Text = employee.GetName();
                phone_txt.Text = employee.GetPhone();
                sin_txt.Text = employee.GetSocialNumber();
                position_cmb.SelectedIndex = (int)employee.GetPosition();

                if (employee.HasUser()) {
                    login_txt.Text = employee.GetUser().GetLogin();
                    password_txt.Text = new String('*', employee.GetUser().GetPasswordSize());
                }
                else {
                    login_txt.Text = "";
                    password_txt.Text = "";
                }

                edit_component = true;
                add_btn.Text = "Update";
                search_txt.Text = "";
            }
            catch (Exception ex) when (ex is FormatException || ex is KeyNotFoundException) {
                FrontEndAdapter.ErrorPopUp("Invalid ID.");
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void EnterPasswordFieldEvent(object sender, EventArgs e) {
            password_txt.Text = "";
        }
    }
}
