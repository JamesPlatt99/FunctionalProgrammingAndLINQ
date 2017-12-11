using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ.Solutions
{
    public class NumberOfTimesGreenSucceedsGreen
    {
        public int Result { get { return _result; } }
        private int _result;

        public NumberOfTimesGreenSucceedsGreen(IEnumerable<Apple> apples, Methods method)
        {
            switch (method)
            {
                case Methods.ForEach:
                    _result = GetNumberOfTimesGreenSucceedsGreenForEach(apples);
                    break;
                case Methods.LINQ:
                    _result = GetNumberOfTimesGreenSucceedsGreenLinq(apples);
                    break;
            }
            Console.WriteLine($"Number of times green succeeds green ({method.ToString()}): {_result}");
        }

        public enum Methods
        {
            LINQ,
            ForEach
        }

        private int GetNumberOfTimesGreenSucceedsGreenLinq(IEnumerable<Apple> apples)
        {
            return apples.Take(apples.Count() - 1)
                         .Where((n, i) => (n.Colour == "Green") && (n.Colour == apples.ElementAt(i + 1).Colour))
                         .Count();
        }
        private int GetNumberOfTimesGreenSucceedsGreenForEach(IEnumerable<Apple> apples)
        {
            int result = 0;
            Apple prevApple = null;
            foreach(Apple apple in apples)
            {
                if(prevApple?.Colour == "Green" && apple.Colour == "Green")
                {
                    result++;
                }
                prevApple = apple;
            }
            return result;
        }
    }
}
