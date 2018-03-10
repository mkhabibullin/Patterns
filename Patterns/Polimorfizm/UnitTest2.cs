using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Polimorfizm
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Caller c = new NewCaller();
            Shape r = new Rectangle(10, 7);
            Shape t = new Triangle(10, 5);

            c.CallArea(r);
            c.CallArea(t);
            
        }
    }

    class Shape
    {
        protected int width, height;

        public Shape(int a = 0, int b = 0)
        {
            width = a;
            height = b;
        }
        public virtual int area(Caller c)
        {
            Trace.WriteLine("Parent class area :");
            return 0;
        }
        public virtual int area(NewCaller c)
        {
            Trace.WriteLine("New Parent class area :");
            return 0;
        }
    }
    class Rectangle : Shape
    {
        public Rectangle(int a = 0, int b = 0) : base(a, b)
        {

        }
        public override int area(Caller c)
        {
            c.PrintMe();
            Trace.WriteLine("Rectangle class area :");
            return (width * height);
        }
        public override int area(NewCaller c)
        {
            c.PrintMe();
            Trace.WriteLine("New Rectangle class area :");
            return (width * height);
        }
    }
    class Triangle : Shape
    {
        public Triangle(int a = 0, int b = 0) : base(a, b)
        {
        }
        public override int area(Caller c)
        {
            c.PrintMe();
            Trace.WriteLine("Triangle class area :");
            return (width * height / 2);
        }

        public override int area(NewCaller c)
        {
            c.PrintMe();
            Trace.WriteLine("New Rectangle class area :");
            return (width * height);
        }
    }
    class Caller
    {
        public virtual void CallArea(Shape sh)
        {
            int a;
            a = sh.area(this);
            Trace.WriteLine($"Area: {a.ToString()}");
        }
        public virtual void PrintMe()
        {
            Trace.WriteLine($"Type is: Caller");
        }
    }

    class NewCaller : Caller
    {
        public override void CallArea(Shape sh)
        {
            int a;
            a = sh.area(this);
            Trace.WriteLine($"Area: {a.ToString()}");
        }
    }
}
