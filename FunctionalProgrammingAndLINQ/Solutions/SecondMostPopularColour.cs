using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class SecondMostFrequentColour
    {
        public string Result { get { return _result; } }
        private string _result;
        public SecondMostFrequentColour(IEnumerable<Apple> apples)
        {
            _result = GetSecondMostFrequentColour(apples);
            Console.WriteLine("Second most frequent colour: " + _result);
        }

        private String GetSecondMostFrequentColour(IEnumerable<Apple> apples)
        {
            return apples.Where(n => n.Poisoned && n.Colour != "Red")
                         .GroupBy(n => n.Colour)
                         .OrderByDescending(n => n.Count())
                         .First()
                         .Key;
        }
    }
}
