using SimpleBuilder.Data;
using System;

namespace SimpleBuilder.Domain
{
    public class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder() 
            : base(VehicleType.Scooter)
        {
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "50 cc";
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Scooter Frame";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }
    }
}
