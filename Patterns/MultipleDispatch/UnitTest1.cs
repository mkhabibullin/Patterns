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
            var asteroid = new Program.Asteroid();
            var spaceship = new Program.Spaceship();
            Program.CollideWith(asteroid, spaceship);
            Program.CollideWith(spaceship, spaceship);
        }
    }

    public class Program
    {
        public class Thing
        {
        }

        public class Asteroid : Thing
        {
        }

        public class Spaceship : Thing
        {
        }

        public static void CollideWithImpl(Asteroid x, Asteroid y)
        {
            Console.WriteLine("Asteroid collides with Asteroid");
        }

        public static void CollideWithImpl(Asteroid x, Spaceship y)
        {
            Console.WriteLine("Asteroid collides with Spaceship");
        }

        public static void CollideWithImpl(Spaceship x, Asteroid y)
        {
            Console.WriteLine("Spaceship collides with Asteroid");
        }

        public static void CollideWithImpl(Spaceship x, Spaceship y)
        {
            Console.WriteLine("Spaceship collides with Spaceship");
        }

        public static void CollideWithImpl(Thing x, Thing y)
        {
            Console.WriteLine("Thing collides with Thing");
        }

        public static void CollideWith(Thing x, Thing y)
        {
            dynamic a = x;
            dynamic b = y;
            Program.CollideWithImpl(a, b);

            Program.CollideWithImpl(x, y);
        }
    }
}
