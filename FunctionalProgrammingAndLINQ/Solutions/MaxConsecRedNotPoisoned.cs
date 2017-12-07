using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class MaxConsecRedNotPoisoned
    {
        public MaxConsecRedNotPoisoned(IEnumerable<Apple> apples, Methods method)
        {
            Console.Write("Max consec red not poisoned: ");
            switch (method)
            {
                case Methods.LINQ:
                    LinqMethod(apples);
                    break;
                case Methods.LINQ2:
                    LinqMethod2(apples);
                    break;
                case Methods.ForEach:
                    ForEachMethod(apples);
                    break;
            }
        }

        public enum Methods
        {
            LINQ,
            LINQ2,
            ForEach
        }

        public void LinqMethod(IEnumerable<Apple> apples)
        {
            int answer =  apples.Select((n, i) => new { Apple = n, Index = i })
                                .Where(n => n.Apple.Colour != "Red" || n.Apple.Poisoned)
                                .Select((n, i) => new { oldIndex = n.Index, newIndex = i }).ToList()
                                .Skip(1)
                                .Max(n =>
                                        n.oldIndex - apples.Select((b, i) => new { Apple = b, Index = i })
                                        .Where(b => b.Apple.Colour != "Red" || b.Apple.Poisoned)
                                        .Select((b, i) => new { oldIndex = b.Index, newIndex = i }).ToList().ElementAt(n.newIndex - 1).oldIndex
                                ) - 1;
            Console.WriteLine(answer);
        }

        public void LinqMethod2(IEnumerable<Apple> apples)
        {
            int maxConsec = 0;
            int curConsec = 0;
            apples.ToList().ForEach(n=> maxConsec = Math.Max((curConsec = (curConsec + Convert.ToInt32(!n.Poisoned && n.Colour == "Red") ) * Convert.ToInt32((!n.Poisoned && n.Colour == "Red"))), maxConsec));

            Console.WriteLine(maxConsec);
        }

        public void ForEachMethod(IEnumerable<Apple> apples)
        {
            ApplePicker applePicker = new ApplePicker();
            int curConsec = 0;
            int maxConsec = 0;

            foreach (Apple apple in apples)
            {
                if (apple.Colour == "Red" && !apple.Poisoned)
                {
                    curConsec++;
                    maxConsec = Math.Max(curConsec, maxConsec);
                    continue;
                }
                curConsec = 0;
            }
            Console.WriteLine(maxConsec);
        }
    }
}
