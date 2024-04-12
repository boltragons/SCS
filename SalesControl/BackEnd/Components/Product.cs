using System;

namespace SalesControl.BackEnd.Components {

    [Serializable]
    public class Product : Component {
        private string name;
        private double price;

        public Product(uint id, string name, double price) : base(id) {
            SetName(name);
            SetPrice(price);
        }

        public string GetName() {
            return name;
        }

        public void SetName(string name) {
            if (name.Length == 0) {
                throw new System.ArgumentException("Product name cannot be empty.");
            }
            this.name = name;
        }

        public double GetPrice() {
            return price;
        }

        public void SetPrice(double price) {
            if (price <= 0) {
                throw new System.ArgumentException("Product price must be a positive value.");
            }
            this.price = price;
        }

        public Product Clone() {
            return (Product) MemberwiseClone();
        }

        public override string ToString() {
            return string.Format("[{0}] {1}: ${2:0.00}", id, name, price);
        }
    }
}