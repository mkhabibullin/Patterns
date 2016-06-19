using FluentBuilder.Domain;
using FluentBuilder.Data;
using System;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new VehicleBuilder(VehicleType.Car)
                .WithDoors("5")
                .WithFrame("Car Frame")
                .WithEngine("25000 cc")
                .WithWheels("4");

            vehicle.Show();

            Console.ReadLine();
        }
    }
}
