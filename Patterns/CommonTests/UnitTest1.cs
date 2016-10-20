using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IEnumerable<int> nums1 = Enumerable.Range(0, Int32.MaxValue);

            // Запустить секундомер
            Stopwatch sw = Stopwatch.StartNew();

            // Выполнить запрос LINQ
            int sum1 = (from n in nums1
                        where n % 2 == 0
                        select n).Count();

            Trace.WriteLine("Результат последовательного выполнения: " + sum1 +
                "\nВремя: " + sw.ElapsedMilliseconds + " мс\n");

            // Создаем параллельный диапазон чисел
            IEnumerable<int> nums2 = ParallelEnumerable.Range(0, Int32.MaxValue);

            // Перезапускаем секундомер
            sw.Restart();

            // Выполняем параллельный запрос LINQ
            int sum2 = (from n in nums2.AsParallel()
                        where n % 2 == 0
                        select n).Count();

            Trace.WriteLine("Результат параллельного выполнения: " + sum2 +
                "\nВремя: " + sw.ElapsedMilliseconds + " мс");
        }
    }
}
