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
            for(int i = 0; i < 4; i++)
            {
                Run();
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Run()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(5000).ToList();

            var maxConsecRedNotPoisonedForEach = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.ForEach);
            var maxConsecRedNotPoisonedLinq = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.ForEach);
            var totalPoisoned = new TotalPoisoned(apples);
            var secondMostPopularColour = new SecondMostFrequentColour(apples);
            var numberOfTimesGreenSucceedsGreen = new NumberOfTimesGreenSucceedsGreen(apples);
        }
    }
}
