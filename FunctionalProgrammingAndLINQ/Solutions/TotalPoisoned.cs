using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class TotalPoisoned
    {
        public int Result { get { return _result; } }
        private int _result;

        public TotalPoisoned(IEnumerable<Apple> apples)
        {
            _result = GetTotalPoisonedLinq(apples);
            Console.WriteLine("Total Poisoned: " + _result);
        }

        private int GetTotalPoisonedLinq(IEnumerable<Apple> apples)
        {
            return apples.Count(n => n.Poisoned);
        }
    }
}
