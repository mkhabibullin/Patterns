using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBuilder.Domain
{
    public class Shop
    {
        protected VehicleBuilder Builder;

        public void Consturct(VehicleBuilder builder)
        {
            Builder = builder;

            Builder.BuildDoors();
            Builder.BuildEngine();
            Builder.BuildFrame();
            Builder.BuildWheels();
        }

        public void ShowVehicle()
        {
            Builder.Vehicle.Show();
        }
    }
}
