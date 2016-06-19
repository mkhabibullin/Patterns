using FluentBuilder.Data;

namespace FluentBuilder.Domain
{
    public class VehicleBuilder // TODO: Interface
    {
        protected Vehicle Vehicle { get; set; }

        #region Constructor

        public VehicleBuilder(VehicleType type)
        {
            switch(type)
            {
                case VehicleType.Car:
                    Vehicle = new Car();
                    break;
                case VehicleType.MotorCycle:
                    Vehicle = new MotoCycle();
                    break;
                case VehicleType.Scooter:
                    Vehicle = new Scooter();
                    break;
            }
        }

        public VehicleBuilder(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        #endregion

        public VehicleBuilder WithFrame(string name)
        {
            Vehicle[PartType.Frame] = name;
            return this;
        }
        public VehicleBuilder WithDoors(string count)
        {
            Vehicle[PartType.Door] = count;
            return this;
        }
        public VehicleBuilder WithEngine(string name)
        {
            Vehicle[PartType.Engine] = name;
            return this;
        }
        public VehicleBuilder WithWheels(string count)
        {
            Vehicle[PartType.Wheel] = count;
            return this;
        }
        
        // CONVERSION OPERATOR
        public static implicit operator Vehicle(VehicleBuilder builder)
        {
            return builder.Vehicle;
        }
    }
}
