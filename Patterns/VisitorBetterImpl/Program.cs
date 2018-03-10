/*
 * https://oncodedesign.com/the-visitor-pattern-a-better-implementation/
 */
using System;

namespace VisitorBetterImpl
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CommandsManager();

            Console.WriteLine();
            Console.WriteLine("PrettyPrint");
            client.PrettyPrint();

            Console.WriteLine();
            Console.WriteLine("ApproveAll");
            client.ApproveAll();

            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
