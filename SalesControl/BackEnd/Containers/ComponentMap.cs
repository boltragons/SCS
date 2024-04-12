using System;
using System.Collections.Generic;
using SalesControl.BackEnd.Components;

namespace SalesControl.BackEnd.Containers {

    [Serializable]
    public class ComponentMap {
        private uint current_id = 1;

        protected readonly Dictionary<uint, Component> components;

        public ComponentMap() {
            components = new Dictionary<uint, Component>();
        }

        public Dictionary<uint, Component> GetComponents() {
            return components;
        }

        public virtual void Add(Component component) {
            if (component == null) {
                throw new System.ArgumentException("Component object cannot be null.");
            }
            components[component.GetId()] = component;
        }

        public virtual void Remove(uint component_id) {
            if (component_id == 0) {
                throw new System.ArgumentException("Component ID must be a non-zero value.");
            }
            components.Remove(component_id);
        }

        public uint GetCurrentId() {
            return current_id;
        }

        public uint GetNextId() {
            return current_id++;
        }

        public override string ToString() {
            string component_str = "";
            foreach (var component in components.Values) {
                component_str += component.ToString() + "\r\n";
            }
            return component_str;
        }
    }
}
