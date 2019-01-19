using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace SealedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Worker>(
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .With(Job.Core)
                );

            Console.WriteLine("Done");

            Console.ReadLine();
        }

        public static void Print(IList<int> values)
        {
            foreach(var v in values)
            {
                Console.WriteLine(v);
            }
        }
    }
    
    public class Worker
    {
        private Sealed s = new Sealed();

        [Benchmark]
        public int Do100()
        {
            return s.Do(100);
        }

        [Benchmark]
        public int Do1000()
        {
            return s.Do(1000);
        }
    }

    public sealed class Sealed
    {
        public int Do(int i = 0)
        {
            return Fake(i);
        }

        private int Fake(int i)
        {
            double r = 0;
            for(var n = 0; n < i; n++)
            {
                r = r + 1 * 2;
            }
            return Convert.ToInt32(r);
        }
    }
}
