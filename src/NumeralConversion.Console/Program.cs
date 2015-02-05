using NumeralConversion.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralConversion.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Char[] validChars = new Char[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            System.Console.WriteLine("Please enter a number to convert or press escape to exit");

            StringBuilder input = new StringBuilder();
            Boolean loop = true;

            while(loop)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    loop = false;
                }

                if(key.Key == ConsoleKey.Enter && input.Length > 0)
                {
                    var toConvert = Convert.ToInt32(input.ToString());
                    System.Console.WriteLine("\r\n{0} Converts To {1}", input, NumeralConverter.ConvertToNumerals(toConvert));
                    input.Clear();
                    System.Console.WriteLine("Enter another number or press escape to exit");
                }

                for (int i = 0; i < validChars.Length; i++)
                {
                    if(key.KeyChar == validChars[i])
                    {
                        System.Console.Write(key.KeyChar);
                        input.Append(key.KeyChar);
                        break;
                    }
                }
            }
        }
    }
}
