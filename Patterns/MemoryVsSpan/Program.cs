using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Buffers;

namespace MemoryVsSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            //IMemoryOwner<string> memoryOwner = MemoryPool<string>.Shared.Rent();

            //try
            //{
            //    var value = Console.ReadLine();

            //    var memory = memoryOwner.Memory;

            //    WriteToBuffer(value, memory);

            //    DisplayBuffer(memory);
            //}
            //catch
            //{
            //    memoryOwner?.Dispose();
            //}

            Console.WriteLine("Done!");
        }

        static void WriteToBuffer(string value, Memory<string> buffer)
        {
            var span = buffer.Span;

            span[0] = value;
        }

        static void DisplayBuffer(Memory<string> buffer)
        {
            Console.WriteLine(buffer.Span[0]);
        }
    }

    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class SpanBenchmark
    {
        private const string FullName = "Mr. John Doe";

        private string GetLastNameBySubstring(string fullName)
        {
            var lastNameIndex = fullName.LastIndexOf(" ");

            var lastName = fullName.Substring(lastNameIndex);

            return lastName;
        }

        private ReadOnlySpan<char> GetLastNameBySpan(ReadOnlySpan<char> fullName)
        {
            var lastNameIndex = fullName.LastIndexOf(" ");

            var lastName = fullName.Slice(lastNameIndex);

            return lastName;
        }

        private ReadOnlySpan<char> GetLastNameBySpanAsSpan(string fullName)
        {
            var lastNameIndex = fullName.LastIndexOf(" ");

            var lastName = fullName.AsSpan(lastNameIndex);

            return lastName;
        }

        private string GetLastNameBySpanToString(ReadOnlySpan<char> fullName)
        {
            var lastNameIndex = fullName.LastIndexOf(" ");

            var lastName = fullName.Slice(lastNameIndex);

            return lastName.ToString();
        }

        [Benchmark]
        public void GetLastNameBySubstring()
        {
            GetLastNameBySubstring(FullName);
        }

        [Benchmark(Baseline = true)]
        public void GetLastNameBySpan()
        {
            GetLastNameBySpan(FullName);
        }

        [Benchmark]
        public void GetLastNameBySpanAsSpan()
        {
            GetLastNameBySpanAsSpan(FullName);
        }

        [Benchmark]
        public void GetLastNameBySpanToString()
        {
            GetLastNameBySpanToString(FullName);
        }
    }
}
