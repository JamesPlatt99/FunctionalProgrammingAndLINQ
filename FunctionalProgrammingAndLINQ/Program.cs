using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionalProgrammingAndLINQ.Solutions;

namespace FunctionalProgrammingAndLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Avg Execution Times");
            GetAverageExecutionTimes();
            //Run();
            //for (int i = 0; i < 10; i++)
            //{
            //    Run(false);
            //    Console.WriteLine();
            //    Console.WriteLine("-------------------------");
            //    Console.WriteLine();
            //}
            Console.ReadLine();
        }

        private static void Run(bool random = false)
        {
            var apples = GetApples(10000, false);
            var timer = new Stopwatch();
            var maxConsecRedNotPoisonedForEach = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.ForEach);
            var maxConsecRedNotPoisonedLinq = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ);
            var maxConsecRedNotPoisonedLinq2 = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ2);
            var maxConsecRedNotPoisonedLinq3 = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ3);
            var totalPoisoned = new TotalPoisoned(apples);
            var secondMostPopularColour = new SecondMostFrequentColour(apples);
            var numberOfTimesGreenSucceedsGreenForEach = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.ForEach);
            var numberOfTimesGreenSucceedsGreenLinq = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.LINQ);
        }

        private static List<Apple> GetApples(int count, bool random)
        {
            var applePicker = new ApplePicker(random);
            return applePicker.PickApples().Take(count).ToList();
        }

        private static void GetAverageExecutionTimes()
        {
            List<Apple> apples = GetApples(100000, false);
            int runsPerSolution = 10;
            decimal LINQ2 = GetAvgTimeForSolution(MaxConsecRedNotPoisoned.Methods.LINQ2, apples, runsPerSolution);
            Console.WriteLine($"LINQ2 {LINQ2}");
            decimal LINQ3 = GetAvgTimeForSolution(MaxConsecRedNotPoisoned.Methods.LINQ3, apples, runsPerSolution);
            Console.WriteLine($"LINQ3 {LINQ3}");
            decimal ForEach = GetAvgTimeForSolution(MaxConsecRedNotPoisoned.Methods.ForEach, apples, runsPerSolution);
            Console.WriteLine($"ForEach {ForEach}");
            decimal LINQ = GetAvgTimeForSolution(MaxConsecRedNotPoisoned.Methods.LINQ, apples, runsPerSolution);
            Console.WriteLine($"LINQ {LINQ}");
        }

        private static decimal GetAvgTimeForSolution(MaxConsecRedNotPoisoned.Methods method, List<Apple> apples, int runs)
        {
            long sum = 0;
            for(int i = 0; i< runs; i++)
            {
                sum += GetRunTimeForSolution(method, apples);
            }
            return sum / runs;
        }
        private static long GetRunTimeForSolution(MaxConsecRedNotPoisoned.Methods method, List<Apple> apples)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            new MaxConsecRedNotPoisoned(apples, method);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
