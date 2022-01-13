using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace DataFlowBroadcastBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            var broadcast = new BroadcastBlock<string>(cloningFunction: null);

            var consoleInRedBlock = new ActionBlock<string>(item =>
            {
                Thread.Sleep(2_000); // despite the Sleep, another action will be consume without waiting for current sleep ending
                var baseColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item);
                Console.ForegroundColor = baseColor;
            });

            var consoleInYellowBlock = new ActionBlock<string>(item =>
            {
                var baseColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item);
                Console.ForegroundColor = baseColor;
            });

            broadcast.LinkTo(consoleInRedBlock);
            broadcast.LinkTo(consoleInYellowBlock);

            while(true)
            {
                Console.Write("enter a value:");
                broadcast.Post(Console.ReadLine());
            }

            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
