using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralConversion.Core
{
    public static class NumeralConverter
    {
        private static readonly Int16[] _denominations = new Int16[] { 1000, 500, 100, 50, 10, 5, 1 };
        private static readonly Char[] _numerals = new Char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

        /// <summary>
        /// Converts the input integer to the corresponding Roman Numeral representation
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Roman Numeral String Representation</returns>
        public static String ConvertToNumerals(Int32 input)
        {
            if (input < 0)
                throw new ArgumentOutOfRangeException("Conversion input must be positive");

            Int32 workingInput = input;
            StringBuilder build = new StringBuilder();

            for (int i = 0; i < _denominations.Length; i++)
            {
                //Test for multiples of 4 for the current denomination
                if (i > 0 && workingInput / _denominations[i] >= 4)
                {
                    build.Append(_numerals[i]);
                    build.Append(_numerals[i - 1]);
                    workingInput -= _denominations[i] * 4;
                }

                //Test for multiples of 9 of the next denomination
                if (i > 0 && i < _denominations.Length - 1 && workingInput / _denominations[i + 1] >= 9)
                {
                    build.Append(_numerals[i + 1]);
                    build.Append(_numerals[i - 1]);
                    workingInput -= _denominations[i + 1] * 9;
                }

                //resolve the remaining multiples of the current denomination
                var remaining = workingInput / _denominations[i];
                for (int j = 0; j < remaining; j++)
                {
                    build.Append(_numerals[i]);
                    
                }
                workingInput -= _denominations[i] * remaining;
            }

            return build.ToString();
        }
    }
}
