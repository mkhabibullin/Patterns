using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Closure
{
    [TestClass]
    public class UnitTest1
    {
        string myVar = " this is good";

        [TestMethod]
        public void TestDelegateClosure1()
        {
            Func<string, string> myFunc = delegate (string var1)
            {
                var resultConcat = var1 + myVar;
                myVar = "";
                return resultConcat;
            };

            var result = myFunc("Uran");
            Trace.WriteLine(result);

            var result2 = myFunc("Uran 237");
            Trace.WriteLine(result2);
        }

        [TestMethod]
        public void TestDelegateClosure2()
        {
            var actions = new List<Action>();

            for(var i = 0; i < 3; i ++)
            {
                //var tempI = i;
                actions.Add(() => Trace.WriteLine(i));
            }

            foreach(var a in actions)
            {
                a.Invoke();
            }
            // ------------------------------------------------
            // 3
            // 3
            // 3
            // ------------------------------------------------

            actions = new List<Action>();
            
            foreach (var num in Enumerable.Range(1, 3))
            {
              //var indx = num;
              actions.Add(() => Trace.WriteLine(num));
            }

            foreach (var a in actions)
            {
                a.Invoke();
            }
            // ------------------------------------------------
            // 1
            // 2
            // 3
            // ------------------------------------------------
        }
    }
}