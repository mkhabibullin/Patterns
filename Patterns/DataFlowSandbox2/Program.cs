using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataFlowSandbox2
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseDataFlow.Process(
                "1 2 3 4 5 6 7 8 9 0 11 22 33 44 55 66 77 88 99 00",
                Environment.ProcessorCount);

            //BenchmarkRunner.Run<Benchmark>();

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }

    public static class ParseDataFlow
    {
        public static void Process(
            string input,
            int maxDegreeOfParallelism,
            bool logging = true,
            TimeSpan? delay = null)
        {
            var parseBlock = new TransformManyBlock<string, string>(input =>
            {
                return input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            });

            var manualBlock = new TransformManyBlock<string, string>(ConsoleSource);

            var timerBlock = new TransformManyBlock<int, string>(TimerSource);

            var processBlock = new ActionBlock<string>(async token =>
            {
                if (delay != null)
                {
                    await Task.Delay(delay.Value);
                }
                if (logging)
                {
                    Console.WriteLine($"Token: {token}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                }
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = maxDegreeOfParallelism
            });

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            parseBlock.LinkTo(processBlock, linkOptions);
            manualBlock.LinkTo(processBlock, linkOptions);
            timerBlock.LinkTo(processBlock, linkOptions);

            parseBlock.Post(input);
            manualBlock.Post("");
            timerBlock.Post(5000);

            parseBlock.Completion.Wait();
        }

        private static IEnumerable<string> ConsoleSource(string _)
        {
            while(true)
            {
                yield return Console.ReadLine();
            }
        }

        private static IEnumerable<string> TimerSource(int delay)
        {
            var i = 0;
            while (true)
            {
                Thread.Sleep(delay);
                yield return (i++).ToString();
            }
        }
    }

    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 10)]
    public class Benchmark
    {
        [Benchmark]
        public void NoParallel() => ParseDataFlow.Process(
            input: "1 2 3 4 5 6 7 8 9 0 11 22 33 44 55 66 77 88 99 00",
            maxDegreeOfParallelism: 1,
            logging: false,
            delay: TimeSpan.FromMilliseconds(100));

        [Benchmark]
        public void Parallel() => ParseDataFlow.Process(
            input: "1 2 3 4 5 6 7 8 9 0 11 22 33 44 55 66 77 88 99 00",
            maxDegreeOfParallelism: Environment.ProcessorCount,
            logging: false,
            delay: TimeSpan.FromMilliseconds(100));
    }
}
