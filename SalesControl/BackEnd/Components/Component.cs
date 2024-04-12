using System;

namespace SalesControl.BackEnd.Components {

    [Serializable]
    public class Component {
        protected readonly uint id;

        public Component(uint id) {
            if (id == 0) {
                throw new System.ArgumentException("Component ID must be a non-zero value.");
            }
            this.id = id;
        }

        public uint GetId() {
            return id;
        }
    }
}
