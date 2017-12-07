using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class TotalPoisoned
    {
        public TotalPoisoned(IEnumerable<Apple> apples)
        {
            Console.Write("Total Poisoned: ");
            GetTotalPoisonedLinq(apples);
        }

        private void GetTotalPoisonedLinq(IEnumerable<Apple> apples)
        {
            Console.WriteLine(apples.Count(n => n.Poisoned));
        }
    }
}
