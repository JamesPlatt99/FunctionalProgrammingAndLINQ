using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class NumberOfTimesGreenSucceedsGreen
    {
        public NumberOfTimesGreenSucceedsGreen(IEnumerable<Apple> apples)
        {
            Console.Write("Number of times green succeeds green: ");
            GetNumberOfTimesGreenSucceedsGreen(apples);
        }

        private void GetNumberOfTimesGreenSucceedsGreen(IEnumerable<Apple> apples)
        {
            Console.WriteLine(apples
                                    .Take(apples.Count() - 1)
                                    .Where((n, i) => n.Colour == apples
                                                                       .ElementAt(i + 1).Colour)
                                    .Count());
        }
    }
}
