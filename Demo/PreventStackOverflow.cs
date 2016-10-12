using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class PreventStackOverflow
    {
        public void Demo()
        {
            RecursiveFactorial(int.MaxValue); // will terminate process
        }

        int RecursiveFactorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * RecursiveFactorial(n - 1);
        }

        int IterativeFactorial(int n)
        {
            int result = 1, index = 1;
            do
            {
                result *= index;
            }
            while (++index <= n);

            return result;
        }

        private static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException(nameof(number), "insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException(nameof(number), "something bad happened");
        }

        private KeyValuePair<int, string>[] numberToLetter = new []
        {
             new KeyValuePair<int, string>(1000, "M"),
             new KeyValuePair<int, string>(900, "CM"),
             new KeyValuePair<int, string>(500, "D"),
             new KeyValuePair<int, string>(400, "CD"),
             new KeyValuePair<int, string>(100, "C"),
             new KeyValuePair<int, string>(90, "XC"),
             new KeyValuePair<int, string>(50, "L"),
             new KeyValuePair<int, string>(40, "XL"),
             new KeyValuePair<int, string>(10, "X"),
             new KeyValuePair<int, string>(9, "IX"),
             new KeyValuePair<int, string>(5, "V"),
             new KeyValuePair<int, string>(4, "IV"),
             new KeyValuePair<int, string>(1, "I"),
        };

        private string TailToRoman(int number)
        {
            var buffer = new StringBuilder();

            start:            
                if (number < 1) goto end;
                foreach (var mapping in numberToLetter)
                    if (number >= mapping.Key)
                    {
                        buffer.Append(mapping.Value);
                        number = number - mapping.Key;
                        goto start;
                    }

            end:
            return buffer.ToString();
        }
    }
}