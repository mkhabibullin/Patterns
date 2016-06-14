using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            new A().Print();
            new B().Print();

            Console.ReadLine();
        }
    }

    public abstract class Base
    {
        public virtual void Print()
        {
            Console.WriteLine("Type is '{0}'", this.GetType().Name);
        }
    }

    public class A : Base { }

    public class B : Base { }
}
