using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplePicker applePicker = new ApplePicker();

            int poisonedAppleCount = applePicker.PickApples()
                                    .Take(10000)
                                    .Count(n => n.Poisoned);

            String secondMostPoisonedColour = applePicker.PickApples()
                                            .Take(10000)
                                            .Where(n => n.Poisoned && n.Colour != "Red")
                                            .GroupBy(n => n.Colour)
                                            .OrderByDescending(n => n.Count())
                                            .First()
                                            .Key;



            List<int> maxConsecutiveNonPoisonedRedApples = applePicker.PickApples()
                                                            .Take(10000)
                                                            .Select((n, i) => new { Apple = n, Index = i })
                                                            .Where(n => n.Apple.Colour != "Red" || n.Apple.Poisoned)
                                                            .Select(n => n.Index).ToList();

            int numberOfTimesGreenAppleSucceedsAnother = applePicker.PickApples()
                                                        .Take(9999)
                                                        .Where((n, i) => n.Colour == applePicker.PickApples()
                                                                                                .Take(10000)
                                                                                                .ElementAt(i + 1).Colour)
                                                        .Count();

            Console.WriteLine(poisonedAppleCount);
            Console.WriteLine(secondMostPoisonedColour);
            //Console.WriteLine(maxSuccessiveRedsToNotBePoisoned);
            Console.WriteLine(numberOfTimesGreenAppleSucceedsAnother);
            Console.ReadLine();
        }        
    }
}
