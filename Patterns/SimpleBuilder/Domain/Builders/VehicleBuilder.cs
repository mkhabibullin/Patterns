using SimpleBuilder.Data;
using System;

namespace SimpleBuilder.Domain
{
    public abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; set; }

        protected VehicleBuilder(VehicleType type)
        {
            Vehicle = new Vehicle(type);
        }

        public abstract void BuildDoors();
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
    }
}
