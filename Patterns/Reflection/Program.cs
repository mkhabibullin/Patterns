using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(TestWrapper);

            var methods = type.GetMethods().Where(m => m.GetCustomAttributes().Any(a => a.GetType() == typeof(TestMethodAttribute)))
                .ToList();

            if (methods != null)
            {
                var classInstance = Activator.CreateInstance(type, null);

                foreach (var m in methods)
                {
                    m.Invoke(classInstance, null);
                }
            }
            
            Console.WriteLine("Done");
            Console.Read();
        }
    }

    public class TestWrapper
    {
        [TestMethod]
        public void Do()
        {
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Do is done");
        }
    }
}
