using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralConversion.Tests
{
    [TestClass]
    public class NumeralConverterTests
    {
        [TestMethod]
        public void ConvertToNumerals()
        {
            Int32[] numsToTest =
                new Int32[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                            11, 12, 13, 14, 15, 16, 17, 18,
                            19, 20, 32, 43, 49, 59, 63, 76, 88, 
                            94, 99, 100, 449, 501, 530, 550, 707,
                            890, 900, 1499, 1500, 1800, 1990, 2015};

            String[] correctConversions =
                new String[]{"I", "II", "III", "IV", "V", "VI",
                            "VII", "VIII", "IX", "X", "XI", "XII", "XIII",
                            "XIV", "XV", "XVI", "XVII", "XVIII",
                            "XIX", "XX", "XXXII", "XLIII", "XLIX", "LIX",
                            "LXIII", "LXXVI", "LXXXVIII", "XCIV",
                            "XCIX", "C", "CDXLIX", "DI", "DXXX", "DL", "DCCVII",
                            "DCCCXC", "CM", "MCDXCIX", "MD", "MDCCC", 
                            "MCMXC", "MMXV"};

            Assert.AreEqual(numsToTest.Length, correctConversions.Length,
                "Length of numbers to test array and correct conversions array should be the same");

            for (int i = 0; i < numsToTest.Length; i++)
            {
                Assert.AreEqual(correctConversions[i], NumeralConversion.Core.NumeralConverter.ConvertToNumerals(numsToTest[i]),
                    String.Format("Num Tested {0} Should Have Converted To {1}", numsToTest[i], correctConversions[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConvertToNumerals_OutOfRange()
        {
            NumeralConversion.Core.NumeralConverter.ConvertToNumerals(-1);
        }
    }
}
