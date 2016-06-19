using SimpleBuilder.Data;

namespace SimpleBuilder.Domain
{
    public class MotoCycleBuilder : VehicleBuilder
    { 
        public MotoCycleBuilder() 
            : base(VehicleType.MotorCycle)
        {
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "NaN";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "500 cc";
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "MotoCycle Frame";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }
    }
}
