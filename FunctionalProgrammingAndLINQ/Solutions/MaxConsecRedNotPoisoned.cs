﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class MaxConsecRedNotPoisoned
    {
        public int Result { get { return _result;  } }
        private int _result;
        public MaxConsecRedNotPoisoned(IEnumerable<Apple> apples, Methods method)
        {
            switch (method)
            {
                case Methods.LINQ:
                    _result = LinqMethod(apples);
                    break;
                case Methods.LINQ2:
                    _result = LinqMethod2(apples);
                    break;
                case Methods.LINQ3:
                    _result = LinqMethod3(apples);
                    break;
                case Methods.ForEach:
                    _result = ForEachMethod(apples);
                    break;
            }
            Console.WriteLine($"Max consec red not poisoned ({method.ToString()}): {_result}" );
        }

        public enum Methods
        {
            LINQ,
            LINQ2,
            LINQ3,
            ForEach
        }

        public int LinqMethod(IEnumerable<Apple> apples)
        {
            //Stores the initial indexes of the apples.
            //Filters out all of the apples that are red and not poisoned.
            //Finds the max difference between the original indexes.
            //Subtracts one to get the number of apples between the two.
            return apples.Select((n, i) => new { Apple = n, Index = i })
                         .Where(n => n.Apple.Colour != "Red" || n.Apple.Poisoned)
                         .Select((n, i) => new { oldIndex = n.Index, newIndex = i }).ToList()
                         .Skip(1)
                         .Max(n =>
                                 n.oldIndex - apples.Select((b, i) => new { Apple = b, Index = i })
                                 .Where(b => b.Apple.Colour != "Red" || b.Apple.Poisoned)
                                 .Select((b, i) => new { oldIndex = b.Index, newIndex = i }).ToList().ElementAt(n.newIndex - 1).oldIndex
                         ) - 1;
        }

        public int LinqMethod2(IEnumerable<Apple> apples)
        {
            int maxConsec = 0;
            int curConsec = 0;
            Byte isValid = 0;
            apples.ToList().ForEach(n=> maxConsec = Math.Max((curConsec = (curConsec + (isValid = Convert.ToByte(!n.Poisoned && n.Colour == "Red")) ) * isValid), maxConsec));

            return maxConsec;
        }

        public int LinqMethod3(IEnumerable<Apple> apples)
        {
            var result = apples.Aggregate(new { cur = 0, max = 0 },(acc, n) => new { cur = (acc.cur + 1) * Convert.ToByte(n.Colour == "Red" && !n.Poisoned),
                                                                                     max = Math.Max(acc.max, (acc.cur + 1) * Convert.ToByte(n.Colour == "Red" && !n.Poisoned)) });
            return result.max;
        }

        public int ForEachMethod(IEnumerable<Apple> apples)
        {
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
            return maxConsec;
        }
    }
}
