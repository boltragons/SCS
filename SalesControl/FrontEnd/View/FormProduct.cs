using System;
using System.Windows.Forms;
using SalesControl.BackEnd;
using SalesControl.BackEnd.Containers;
using SalesControl.BackEnd.Components;
using SalesControl.FrontEnd;
using System.Collections.Generic;

namespace SalesControl.FrontEnd.View {
    public partial class FormProduct : Form {

        private readonly Inventory inventory;

        private bool edit_component = false;

        public FormProduct() {
            // Back-end Instances
            inventory = BackEndAdapter.GetInventory();

            // Front-end Initialization
            InitializeComponent();

            // Front-end Adjusts
            UpdateIDField();

            list_txt.Text = inventory.ToString();
        }

        private void UpdateIDField() {
            id_txt.Text = inventory.GetCurrentId().ToString();
        }

        private void ClearFields() {
            name_txt.Text = "";
            price_txt.Text = "";
        }

        private void AddButtonClickEvent(object sender, EventArgs e) {
            try {
                uint id = Convert.ToUInt32(id_txt.Text);
                Product product = new Product(
                    id,
                    name_txt.Text,
                    Convert.ToDouble(price_txt.Text)
                );
                inventory.Add(product);

                if (edit_component) {
                    edit_component = false;
                    add_btn.Text = "Add";
                    list_txt.Text = inventory.ToString();
                    search_txt.Text = "";
                    FrontEndAdapter.SuccessPopUp("The product has been updated.");
                }
                else {
                    inventory.GetNextId();
                    list_txt.Text += product.ToString() + "\r\n";
                    FrontEndAdapter.SuccessPopUp("The product has been created.");
                }
                UpdateIDField();
                ClearFields();

                BackEndAdapter.SaveData();
            }
            catch (ArgumentException) {
                FrontEndAdapter.ErrorPopUp("Invalid name.");
            }
            catch (FormatException) {
                FrontEndAdapter.ErrorPopUp("Invalid price.");
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void RemoveButtonClickEvent(object sender, EventArgs e) {
            if (!edit_component) {
                FrontEndAdapter.WarningPopUp("First select a product.");
                return;
            }
            try {
                inventory.Remove(Convert.ToUInt32(id_txt.Text));

                // Build new products string
                list_txt.Text = inventory.ToString();

                ClearFields();
                edit_component = false;
                add_btn.Text = "Add";
                UpdateIDField();

                FrontEndAdapter.SuccessPopUp("The product has been deleted.");

                BackEndAdapter.SaveData();
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void SelectButtonClickEvent(object sender, EventArgs e) {
            try {
                uint id = Convert.ToUInt32(search_txt.Text);
                Product product = (Product)inventory.GetComponents()[id];
                id_txt.Text = search_txt.Text;
                name_txt.Text = product.GetName();
                price_txt.Text = product.GetPrice().ToString();

                search_txt.Text = "";
                edit_component = true;
                add_btn.Text = "Update";
            }
            catch (Exception ex) when (ex is FormatException || ex is KeyNotFoundException) {
                FrontEndAdapter.ErrorPopUp("Invalid ID.");
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }
    }
}
