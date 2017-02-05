using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchConsole
{
    class Program
    {
        class Thing { }
        class Asteroid : Thing { }
        class Spaceship : Thing { }

        static void CollideWithImpl(Asteroid x, Asteroid y)
        {
            Console.WriteLine("Asteroid collides with Asteroid");
        }

        static void CollideWithImpl(Asteroid x, Spaceship y)
        {
            Console.WriteLine("Asteroid collides with Spaceship");
        }

        static void CollideWithImpl(Spaceship x, Asteroid y)
        {
            Console.WriteLine("Spaceship collides with Asteroid");
        }

        static void CollideWithImpl(Spaceship x, Spaceship y)
        {
            Console.WriteLine("Spaceship collides with Spaceship");
        }

        static void CollideWith(Thing x, Thing y)
        {
            dynamic a = x;
            dynamic b = y;
            CollideWithImpl(a, b);
        }

        static void Main(string[] args)
        {
            var asteroid = new Asteroid();
            var spaceship = new Spaceship();
            CollideWith(asteroid, spaceship);
            CollideWith(spaceship, spaceship);
            
            Console.Read();
        }
    }
}
