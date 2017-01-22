namespace Invariance
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class DelegateVariative
    {
        public class First
        {
        }

        public class Second : First
        {
        }

        public delegate First SampleDelegate(Second a);

        public delegate R SampleGenericDelegate<A, R>(A a);

        // Matching signature.
        public static First ASecondRFirst(Second first)
        {
            return new First();
        }

        // The return type is more derived.
        public static Second ASecondRSecond(Second second)
        {
            return new Second();
        }

        // The argument type is less derived.
        public static First AFirstRFirst(First first)
        {
            return new First();
        }

        // The return type is more derived 
        // and the argument type is less derived.
        public static Second AFirstRSecond(First first)
        {
            return new Second();
        }

        /// <summary>
        /// поддержка вариативности при сопоставлении сигнатур методов с типами делегатов
        /// </summary>
        [TestMethod]
        public void NonGeneric()
        {
            // Assigning a method with a matching signature 
            // to a non-generic delegate. No conversion is necessary.
            SampleDelegate dNonGeneric = ASecondRFirst;
            // Assigning a method with a more derived return type 
            // and less derived argument type to a non-generic delegate.
            // The implicit conversion is used.
            SampleDelegate dNonGenericConversion = AFirstRSecond;

            // Assigning a method with a matching signature to a generic delegate.
            // No conversion is necessary.
            SampleGenericDelegate<Second, First> dGeneric = ASecondRFirst;
            // Assigning a method with a more derived return type 
            // and less derived argument type to a generic delegate.
            // The implicit conversion is used.
            SampleGenericDelegate<Second, First> dGenericConversion = AFirstRSecond;

            SampleGenericDelegate<Second, Second> dGenericConversion2 = AFirstRSecond;

            // in A, out T
            // 1
            //dGenericConversion = dGenericConversion2;

            // 2
            //var genList = new List<SampleGenericDelegate<Second, First>>();
            //genList.Add(dGenericConversion);
            //genList.Add(dGenericConversion2);

        }

        public delegate T SampleGenericDelegate<out T>();

        /// <summary>
        /// неявное преобразование между делегатами, которое позволит универсальным методам-делегатам, имеющим разные типы, указанные параметрами универсального типа, быть назначенными друг другу, если типы наследуются друг от друга
        /// </summary>
        [TestMethod]
        public void Generic()
        {
            SampleGenericDelegate<string> dString = () => " ";

            // You can assign delegates to each other,
            // because the type T is declared covariant.

            // Если убрать Out, то не будет рабоать
            SampleGenericDelegate<object> dObject = dString;


            var genList = new List<SampleGenericDelegate<object>>();

            genList.Add(dString);
            genList.Add(dObject);
        }
    }
}