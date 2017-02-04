using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultipleDispatch
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var asteroid = new Asteroid();
            var spaceship = new Spaceship();
            CollideWith(asteroid, spaceship);
            CollideWith(spaceship, spaceship);
        }
    }

    public class Program
    {
        class Thing
        {
        }

        class Asteroid : Thing
        {
        }

        class Spaceship : Thing
        {
        }

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
            Program.CollideWithImpl(a, b);
        }
    }
}
