using System;
using System.Text.RegularExpressions;

namespace SalesControl.BackEnd.Components {

    [Serializable]
    public class Person : Component {
        private string name;
        private string phone;
        private string social_number;

        public Person(uint id, string name, string phone, string social_number) : base(id) {
            SetName(name);
            SetPhone(phone);
            SetSocialNumber(social_number);
        }

        public string GetName() {
            return name;
        }

        public void SetName(string name) {
            if (name.Length == 0) {
                throw new System.ArgumentException("Person name cannot be empty.");
            }
            this.name = name;
        }

        public string GetPhone() {
            return phone;
        }

        public void SetPhone(string phone) {
            if (phone.Length != 12 && !Regex.IsMatch(phone, "^[0-9]{3} [0-9]{3} [0-9]{4}$")) {
                throw new System.ArgumentException("Invalid Person phone. Use the format NPA XXX XXXX.");
            }
            this.phone = phone;
        }

        public string GetSocialNumber() {
            return social_number;
        }
        public void SetSocialNumber(string social_number) {
            if (social_number.Length != 9 && !Regex.IsMatch(social_number, "^[0-9]{3} [0-9]{3} [0-9]{3}$")) {
                throw new System.ArgumentException("Invalid Person social number. Use the format XXX XXX XXX.");
            }
            this.social_number = social_number;
        }

        public Person Clone() {
            return (Person)MemberwiseClone();
        }

        public override string ToString() {
            return string.Format(
                "[{0}] {1} ({2}) - Contact: {3}",
                id,
                name,
                social_number,
                phone
            );
        }
    }
}
