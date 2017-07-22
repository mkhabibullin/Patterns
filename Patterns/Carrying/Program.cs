using System;

namespace Carrying
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, Func<int, int>> curriedAdd = add.Curry();
            Func<int, int> inc = curriedAdd(1);

            Console.WriteLine(add(3, 4));            // 7
            Console.WriteLine(curriedAdd(3)(5));    // 8
            Console.WriteLine(inc(2));              // 3

            Console.Read();
        }
    }

    static class FuncExtensions
    {
        public static Func<A, Func<B, R>> Curry<A, B, R>(this Func<A, B, R> f)
        {
            return a => b => f(a, b);
        }
    }
}