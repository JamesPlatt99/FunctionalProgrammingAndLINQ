using System;
using System.Collections.Generic;
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
            Run();
            for (int i = 0; i < 4; i++)
            {
                Run(true);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Run(bool random = false)
        {
            var applePicker = new ApplePicker(random);
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var maxConsecRedNotPoisonedForEach = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.ForEach);
            var maxConsecRedNotPoisonedLinq = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ);
            var maxConsecRedNotPoisonedLinq2 = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ2);
            var totalPoisoned = new TotalPoisoned(apples);
            var secondMostPopularColour = new SecondMostFrequentColour(apples);
            var numberOfTimesGreenSucceedsGreenForEach = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.ForEach);
            var numberOfTimesGreenSucceedsGreenLinq = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.LINQ);
        }
    }
}
