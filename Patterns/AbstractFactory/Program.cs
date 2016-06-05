using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.ContinentFactories;
using AbstractFactory.Services;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var africa = new AnimalWorld<Africa>();
            africa.RunFoodChain();

            var america = new AnimalWorld<America>();
            america.RunFoodChain();

            Console.ReadKey();
        }
    }
}
