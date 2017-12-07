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
            Random random = new Random();
            int colourIndex = 1;
            int poisonIndex = 7;
            while (true)
            {
                yield return new Apple
                {
                    Colour = GetColour(colourIndex),
                    Poisoned = poisonIndex % 41 == 0
                };

                if (_random)
                {
                    colourIndex += random.Next(1, 100) * 2;
                    poisonIndex += random.Next(1, 100) * 13;
                }
                colourIndex += 5;
                poisonIndex += 37;
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
