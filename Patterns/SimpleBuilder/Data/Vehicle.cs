using System;
using System.Collections.Generic;

namespace SimpleBuilder.Data
{
    public class Vehicle
    {
        protected readonly VehicleType Type;

        protected readonly Dictionary<PartType, string> parts = new Dictionary<PartType, string>();

        public Vehicle(VehicleType type)
        {
            Type = type;
        }

        public string this[PartType key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n--------------{0}--------------------", Type.ToString().ToUpper());
            Console.WriteLine("Parts count - {0}", parts.Count);
            foreach(var key in parts.Keys)
            {
                Console.WriteLine("{0} - {1}", key, this[key]);
            }
        }
    }

    public enum PartType
    {
        Frame,
        Engine,
        Wheel,
        Door
    }

    public enum VehicleType
    {
        Car,
        Scooter,
        MotorCycle
    }
}
