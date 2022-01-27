using System;
using System.Collections.Generic;
using System.Diagnostics;
using Otus.Multithreaded.Services;


namespace Otus.Multithreaded
{
    class Program
    {
        private static readonly int[] _counts = {100000, 1000000, 10000000};

        private static void Main()
        {
            foreach (var count in _counts)
            {
                var list = GeneratorService.GenerateIntList(count);

                WriteLine(list);
                WriteLineParallel(list);
                WriteLineParallelLinq(list);

                Console.WriteLine();
            }
        }

        private static void WriteLine(List<int> list)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var sum = new SumService().GetSum(list);

            stopwatch.Stop();

            Console.WriteLine($"Обычное: {sum}; Milliseconds: {stopwatch.ElapsedMilliseconds}");
        }

        private static void WriteLineParallel(List<int> list)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var sum = new ParallelSumService().GetSum(list);

            stopwatch.Stop();

            Console.WriteLine($"Параллельное: {sum}; Milliseconds: {stopwatch.ElapsedMilliseconds}");
        }

        private static void WriteLineParallelLinq(List<int> list)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var sum = new ParallelLinqSumService().GetSum(list);

            stopwatch.Stop();

            Console.WriteLine($"Параллельное с помощью LINQ: {sum}; Milliseconds: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
