using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataFlowJoinBlock
{
    class Program
    {
        static BufferBlock<string> FirstSource = new BufferBlock<string>();
        static BufferBlock<string> SecondSource = new BufferBlock<string>();

        static void Main(string[] args)
        {
            var joinTwoSourceBlock = new JoinBlock<string, string>(
                new GroupingDataflowBlockOptions
                {
                    Greedy = false
                });

            var actionOverTwoResources = new ActionBlock<Tuple<string, string>>(
                data =>
                {
                    Console.WriteLine($"Two resources are gotten: \n1 - \"{data.Item1}\" \n2 - \"{data.Item2}\".");

                    Console.WriteLine("Starting the work over resources ...");
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    Console.WriteLine("End of the work.");
                });

            FirstSource.LinkTo(joinTwoSourceBlock.Target1);
            SecondSource.LinkTo(joinTwoSourceBlock.Target2);

            joinTwoSourceBlock.LinkTo(actionOverTwoResources);

            FirstSource.Post("1 - A");
            FirstSource.Post("1 - B");
            FirstSource.Post("1 - C");

            Task.Run(SecondSourceGenerator);
            Task.Run(PrintGreedyEffect);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void SecondSourceGenerator()
        {
            while (true)
            {
                SecondSource.Post(Console.ReadLine());
            }
        }

        static void PrintGreedyEffect()
        {
            while (true)
            {
                //  In greedy mode, if one join block reads from the first source and the second join block reads from the second source,
                //  the application might deadlock because both join blocks mutually wait for the other to release its resource.
                //  In non-greedy mode, each join block reads from its sources only when all data is available, and therefore,
                //  the risk of deadlock is eliminated.
                Console.WriteLine($"Buffered items: {FirstSource.Count}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
