using SimpleBuilder.Domain;
using System;

namespace SimpleBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.Consturct(new ScooterBuilder());
            shop.ShowVehicle();

            shop.Consturct(new CarBuilder());
            shop.ShowVehicle();

            shop.Consturct(new MotoCycleBuilder());
            shop.ShowVehicle();

            Console.ReadLine();
        }
    }
}
