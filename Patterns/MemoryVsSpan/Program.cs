using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;

namespace SpanPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }

    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class SpanVsStringBenchmark
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
