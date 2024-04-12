using SalesControl.BackEnd;
using SalesControl.BackEnd.Components;
using SalesControl.BackEnd.Containers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesControl.FrontEnd {
    public partial class FormCart : Form {

        private Cart cart;

        private readonly Inventory inventory;

        private Product current_product;

        private bool edit_component = false;

        public FormCart() {
            inventory = BackEndAdapter.GetInventory();

            InitializeComponent();

            foreach (Product product in inventory.GetComponents().Values.Cast<Product>()) {
                product_cmb.Items.Add(product.ToString());
            }
            product_cmb.SelectedIndex = 0;

            total_sale_txt.Text = "0.00";
        }

        private void ClearFields() {
            product_cmb.SelectedIndex = 0;
            name_txt.Text = "";
            price_txt.Text = "";
            quantity_txt.Text = "";
            total_item_txt.Text = "0.00";
        }

        private Product ObtainProductFromString(string product_str) {
            int start_id = product_str.IndexOf('[');
            int end_id = product_str.IndexOf(']');

            if (start_id == -1 || end_id == -1 || end_id <= start_id) {
                return null;
            }

            string numeroTexto = product_str.Substring(start_id + 1, end_id - start_id - 1);
            uint id = Convert.ToUInt32(numeroTexto);
            return (Product) inventory.GetComponents()[id];
        }

        private void AddBtnClickEvent(object sender, EventArgs e) {
            try {
                if (cart is null) {
                    cart = new Cart(DateTime.Now);
                }
                Item item = new Item(
                    current_product,
                    Convert.ToDouble(quantity_txt.Text)
                );
                cart.Add(item);

                if (edit_component) {
                    edit_component = false;
                    add_btn.Text = "Add";
                    search_txt.Text = "";
                    FrontEndAdapter.SuccessPopUp("The item has been updated.");
                }

                total_sale_txt.Text = cart.GetTotalPrice().ToString("F2");
                list_txt.Text = cart.ToString();

                ClearFields();

                BackEndAdapter.SaveData();
            }
            catch (FormatException) {
                FrontEndAdapter.ErrorPopUp("Invalid quantity.");
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void SelectBtnClickEvent(object sender, EventArgs e) {
            try {
                uint id = Convert.ToUInt32(search_txt.Text);
                Item item = (Item) cart.GetComponents()[id];

                int index = 1;
                foreach (Product product in inventory.GetComponents().Values.Cast<Product>()) {
                    if (product.GetId() == item.GetId()) {
                        current_product = product;
                        product_cmb.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
                search_txt.Text = "";
                name_txt.Text = current_product.GetName();
                price_txt.Text = current_product.GetPrice().ToString();
                quantity_txt.Text = item.GetQuantity().ToString();
                total_item_txt.Text = item.GetTotalPrice().ToString();

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

        private void RemoveBtnClickEvent(object sender, EventArgs e) {
            if (!edit_component) {
                FrontEndAdapter.WarningPopUp("First select a item.");
                return;
            }
            try {
                cart.Remove(current_product.GetId());

                // Build new products string
                list_txt.Text = cart.ToString();

                ClearFields();
                edit_component = false;
                add_btn.Text = "Add";

                total_sale_txt.Text = cart.GetTotalPrice().ToString("F2");

                FrontEndAdapter.SuccessPopUp("The item has been deleted.");

                BackEndAdapter.SaveData();
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void ProductCmbSelectedIndexChangedEvent(object sender, EventArgs e) {
            if (product_cmb.SelectedIndex == 0) {
                return;
            }
            try {
                current_product = ObtainProductFromString(product_cmb.SelectedItem.ToString());
                if (current_product is null) {
                    throw new InvalidOperationException("There was an error in selecting the product.");
                }
                name_txt.Text = current_product.GetName();
                price_txt.Text = current_product.GetPrice().ToString("F2");
                total_item_txt.Text = "0.00";
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private void QuantityTxtTextChangedEvent(object sender, EventArgs e) {
            try {
                double price = Convert.ToDouble(price_txt.Text);
                double quantity = Convert.ToDouble(quantity_txt.Text);
                double total = price * quantity;
                total_item_txt.Text = total.ToString("F2");
            }
            catch(Exception) { }
        }

        private void FinishBtnClickEvent(object sender, EventArgs e) {
            try {
                if (cart.GetComponents().Count == 0) {
                    throw new InvalidOperationException("You have not added any item to the cart.");
                }
                FrontEndAdapter.SuccessPopUp("The cart's total price is $" + cart.GetTotalPrice().ToString("F2") + ".");
                cart = null;
                ClearFields();
                list_txt.Text = "";
                total_sale_txt.Text = "0.00";
            }
            catch(NullReferenceException) {
                FrontEndAdapter.ErrorPopUp("You have not added any item to the cart.");
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }
    }
}
