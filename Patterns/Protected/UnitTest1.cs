using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Protected
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/protected-internal
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            A a = new A();
            //a.x = 22; // Compile time exception
            B b = new B();
            //b.x = 22;// The same - Compile time exception

            Internal.A iA = new Internal.B();
            iA.x = 22; // Compile time exception
        }
    }

    class A
    {
        protected int x = 10;
    }

    class B : A
    {
        public B()
        {
            x = 11;
        }
    }
}
