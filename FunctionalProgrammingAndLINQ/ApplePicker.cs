using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingAndLINQ
{
    public class ApplePicker
    {
        public ApplePicker(Boolean random = false)
        {
            _random = random;
        }

        private Boolean _random;

        public IEnumerable<Apple> PickApples()
        {
            if (_random)
            {
                return PickApplesRand();
            }
            return PickApplesDefault();
        }

        private IEnumerable<Apple> PickApplesDefault()
        {
            int colourIndex = 1;
            int poisonIndex = 7;

            while (true)
            {
                yield return new Apple
                {
                    Colour = GetColour(colourIndex),
                    Poisoned = poisonIndex % 41 == 0
                };

                colourIndex += 5;
                poisonIndex += 37;
            }
        }
        private IEnumerable<Apple> PickApplesRand()
        {
            while (true)
            {
                yield return new Apple
                {
                    Colour = GetRandColour(),
                    Poisoned = (new Random().Next(0, 100) % 4 == 0)
                };
                
            }
        }

        private string GetRandColour()
        {
            int rand = new Random().Next(1, 4);
            switch (rand)
            {
                case 1:
                    return "Yellow";
                case 2:
                    return "Green";
                default:
                    return "Red";
            }
        }

        private string GetColour(int colourIndex)
        {
            if (colourIndex % 13 == 0 || colourIndex % 29 == 0)
            {
                return "Green";
            }

            if (colourIndex % 11 == 0 || colourIndex % 19 == 0)
            {
                return "Yellow";
            }

            return "Red";
        }        
    }
}
