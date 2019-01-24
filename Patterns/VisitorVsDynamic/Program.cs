using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;

namespace VisitorVsDynamic
{
    class Program
    {
        public static Shape[] Shapes = 
            new Shape[] { new Circle(1, 1), new Rectangle(2, 2) };

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>(
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .With(Job.Core.WithIterationCount(150)));
        }
    }

    public class Benchmark
    {
        [Benchmark]
        public void DoVisitor()
        {
            var maker = new Maker();
            var printer = new Printer();

            //foreach (var shape in Program.Shapes)
            foreach (var shape in new Shape[] { new Circle(1, 1), new Rectangle(2, 2) })
            {
                shape.Do(maker);
                shape.Do(printer);
            }
        }

        [Benchmark]
        public void DoDynamic()
        {
            var maker = new Maker();
            var printer = new Printer();

            //foreach (var shape in Program.Shapes)
            foreach (var shape in new Shape[] { new Circle(1, 1), new Rectangle(2, 2) })
            {
                maker.Do((dynamic)shape);
                printer.Do((dynamic)shape);
            }
        }
    }

    public abstract class Shape
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Shape(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Do(IVisitor visitor);
    }

    public class Circle : Shape
    {
        public Circle(int x, int y) : base(x, y)
        {

        }

        public override void Do(IVisitor visitor)
        {
            visitor.Do(this);
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(int x, int y) : base(x, y)
        {

        }

        public override void Do(IVisitor visitor)
        {
            visitor.Do(this);
        }
    }

    public interface IVisitor
    {
        void Do(Circle circle);
        void Do(Rectangle rectangle);
    }

    public class Maker : IVisitor
    {
        public void Do(Circle shape)
        {
            shape.X += shape.X;
            shape.Y += shape.Y;
        }

        public void Do(Rectangle rectangle)
        {
            rectangle.X += rectangle.X;
            rectangle.Y += rectangle.Y;
        }
    }

    public class Printer : IVisitor
    {
        public void Do(Circle circle)
        {
            Trace.WriteLine($"{circle.X}:{circle.Y}");
        }

        public void Do(Rectangle rectangle)
        {
            Trace.WriteLine($"{rectangle.X}:{rectangle.Y}");
        }
    }
}
