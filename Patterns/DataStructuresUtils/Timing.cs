using System;
using System.Diagnostics;

namespace DataStructuresUtils
{
    public sealed class Timing : IDisposable
    {
        TimeSpan startingTime;
        TimeSpan duration;
        string description;

        public Timing(string description)
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
            this.description = description;

            StartTime();
        }
        public void StopTime()
        {
            duration =
            Process.GetCurrentProcess().Threads[0].UserProcessorTime.
            Subtract(startingTime);
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }

        public void Dispose()
        {
            StopTime();
            Console.WriteLine($"END: ***** {description} : {Result().TotalMilliseconds} *****");
        }

        public static Timing Create(string description)
        {
            Console.WriteLine($"{Environment.NewLine}START: ***** {description} *****");
            return new Timing(description);
        }
    }
}
