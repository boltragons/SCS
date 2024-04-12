using System;
using System.Linq;
using SalesControl.BackEnd.Components;

namespace SalesControl.BackEnd.Containers {


    public class Cart : ComponentMap {
        private double total_price;
        private readonly DateTime date;

        public Cart(DateTime date) : base() {
            this.date = date;
            total_price = 0;
        }

        public void RecalculatePrice() {
            total_price = 0;
            foreach (Item item in GetComponents().Values.Cast<Item>()) {
                total_price += item.GetTotalPrice();
            }
        }

        public double GetTotalPrice() {
            return total_price;
        }

        public DateTime GetDate() {
            return date;
        }

        public override void Add(Component component) {
            base.Add(component);
            RecalculatePrice();
        }

        public override void Remove(uint component_id) {
            components.Remove(component_id);
            RecalculatePrice();
        }
    }
}