using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class SecondMostFrequentColour
    {
        public SecondMostFrequentColour(IEnumerable<Apple> apples)
        {
            Console.Write("Second most frequent colour: ");
            GetSecondMostFrequentColour(apples);
        }

        private void GetSecondMostFrequentColour(IEnumerable<Apple> apples)
        {
            Console.WriteLine(apples.Where(n => n.Poisoned && n.Colour != "Red")
                                    .GroupBy(n => n.Colour)
                                    .OrderByDescending(n => n.Count())
                                    .First()
                                    .Key);
        }
    }
}
