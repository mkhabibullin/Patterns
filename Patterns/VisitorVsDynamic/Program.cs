using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace VisitorVsDynamic
{
    class Program
    {
        public static Shape[] Shapes;
        static void Main(string[] args)
        {
            Shapes = new Shape[] { new Circle(1, 1), new Rectangle(2, 2) };

            var summary = BenchmarkRunner.Run<Benchmark>(
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .With(Job.Core));

            Console.WriteLine("Done!");
            Console.Read();
        }
    }

    public class Benchmark
    {
        [ParamsSource(nameof(Values))]
        public Shape shape;

        public IEnumerable<Shape> Values => Program.Shapes;

        [Benchmark]
        public void DoVisitor()
        {
            var maker = new Maker();
            var printer = new Printer();

            shape.Do(maker);
            shape.Do(printer);
        }

        [Benchmark]
        public void DoDynamic()
        {
            var maker = new Maker();
            var printer = new Printer();

            maker.Do((dynamic)shape);
            printer.Do((dynamic)shape);
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
            Console.WriteLine($"{circle.X}:{circle.Y}");
        }

        public void Do(Rectangle rectangle)
        {
            Console.WriteLine($"{rectangle.X}:{rectangle.Y}");
        }
    }
}
