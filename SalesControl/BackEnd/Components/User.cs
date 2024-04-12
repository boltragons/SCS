using System;

namespace SalesControl.BackEnd.Components {

    [Serializable]
    public class User {
        private string login;
        private int password_hash;
        private int password_size;

        public User(string login, string password) {
            SetLogin(login);
            SetPasswordHash(password);
        }

        public string GetLogin() {
            return login;
        }

        public void SetLogin(string login) {
            if (login.Length < 6) {
                throw new ArgumentException("Invalid User login. Must have at least 6 characters.");
            }
            this.login = login;
        }

        public int GetPasswordSize() {
            return password_size;
        }

        public int GetPasswordHash() {
            return password_hash;
        }

        public void SetPasswordHash(string password) {
            if (password.Length < 6) {
                throw new ArgumentException("Invalid User password. Must have at least 6 characters.");
            }
            password_size = password.Length;
            password_hash = password.GetHashCode();
        }

        public override int GetHashCode() {
            return login.GetHashCode() ^ password_hash;
        }

        public override bool Equals(object user) {
            if (user == null) {
                return false;
            }
            if (ReferenceEquals(user, this)) {
                return true;
            }
            if (this.GetType() != user.GetType()) {
                return false;
            }
            User other_user = user as User;

            return this.login == other_user.login &&
                this.password_hash == other_user.password_hash;
        }

        public override string ToString() {
            return login;
        }
    }
}
