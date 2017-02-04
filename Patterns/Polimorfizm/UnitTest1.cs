using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polimorfizm
{
    using System.Diagnostics;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            B b = new B();
            A a = b;

            a.F();
            b.F();

            a.G();
            b.G();

            /*
            A.F
            B.F

            B.G
            B.G
             */
        }
    }

    public class A
    {
        public void F()
        {
            Trace.WriteLine("A.F");
        }

        public virtual void G()
        {
            Trace.WriteLine("A.G");
        }
    }

    public class B : A
    {
        public void F()
        {
            Trace.WriteLine("B.F");
        }

        public override void G()
        {
            Trace.WriteLine("B.G");
        }
    }
}
