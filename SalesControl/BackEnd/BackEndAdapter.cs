using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using SalesControl.BackEnd.Components;
using SalesControl.BackEnd.Containers;
using SalesControl.FrontEnd;

namespace SalesControl.BackEnd {

    [Serializable]
    internal class BackEndContainers {
        public Inventory inventory = new Inventory();
        public Staff employees = new Staff();
    } 

    public class BackEndAdapter {
        private const string default_database_file = "database.scs";

        private static BackEndContainers containers = new BackEndContainers();

        public static void Init() {
            LoadData();

            /* If no user exists, create a admin user */
            if (containers.employees.GetComponents().Count == 0) {
                Employee admin = new Employee(containers.employees.GetNextId(), "Administrator", "000 000 0000", "000 000 000", Position.kManager);
                admin.SetUser("admin1", "123456");
                containers.employees.Add(admin);
                SaveData();
            }
        }

        public static Inventory GetInventory() {
            return containers.inventory;
        }
        public static Staff GetEmployees() {
            return containers.employees;
        }

        public static void SaveData() {
            SaveData(default_database_file);
        }

        public static void SaveData(string file_name) {
            try {
                SerializeObject(containers, file_name);
            }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        public static void LoadData() {
            LoadData(default_database_file);
        }

        public static void LoadData(string file_name) {
            try {
                containers = (BackEndContainers)DeserializeObject(file_name);
            }
            catch (FileNotFoundException) { }
            catch (Exception ex) {
                FrontEndAdapter.ErrorPopUp(ex.Message);
            }
        }

        private static void SerializeObject(object obj, string file_name) {
            var formatter = new BinaryFormatter();
            var file = new FileStream(file_name, FileMode.Create);
            formatter.Serialize(file, obj);
            file.Close();
        }

        private static object DeserializeObject(string file_name) {
            var formatter = new BinaryFormatter();
            var file = new FileStream(file_name, FileMode.Open);
            object obj = formatter.Deserialize(file);
            file.Close();

            return obj;
        }
    }
}
