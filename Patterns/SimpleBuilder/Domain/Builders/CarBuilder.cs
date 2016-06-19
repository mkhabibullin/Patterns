using SimpleBuilder.Data;
using System;

namespace SimpleBuilder.Domain
{
    public class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
            : base(VehicleType.Car)
        { }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "4";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "2500 cc";
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Car Frame";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "4";
        }
    }
}
