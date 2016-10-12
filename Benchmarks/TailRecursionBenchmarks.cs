using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class TailRecursionBenchmarks
    {
        [Params(1, 10, 100, 1000, 10000, 100000)]
        public int N;

        [Benchmark(Baseline = true)]
        public string Recursion() => ToRoman(N);

        [Benchmark]
        public string TailRecursion() => TailToRoman(N);

        private static string ToRoman(int number)
        {
            if ((number < 0) /*|| (number > 3999) */) throw new ArgumentOutOfRangeException(nameof(number));
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

        private static readonly StringBuilder buffer = new StringBuilder();

        private string TailToRoman(int number)
        {
            buffer.Length = 0;   

            start:
            if (number < 1) goto end;
            if (number >= 1000) { buffer.Append('M'); number -=  1000; goto start; }
            if (number >= 900) { buffer.Append("CM"); number -=  900; goto start; }
            if (number >= 500) { buffer.Append('D'); number -=  500; goto start; }
            if (number >= 400) { buffer.Append("CD"); number -=  400; goto start; }
            if (number >= 100) { buffer.Append('C'); number -=  100; goto start; }
            if (number >= 90) { buffer.Append("XC"); number -=  90; goto start; }
            if (number >= 50) { buffer.Append('L'); number -=  50; goto start; }
            if (number >= 40) { buffer.Append("XL"); number -=  40; goto start; }
            if (number >= 10) { buffer.Append('X'); number -=  10; goto start; }
            if (number >= 9) { buffer.Append("IX"); number -=  9; goto start; }
            if (number >= 5) { buffer.Append('V'); number -=  5; goto start; }
            if (number >= 4) { buffer.Append("IV"); number -=  4; goto start; }
            if (number >= 1) { buffer.Append('I'); number -=  1; goto start; }

            end:
            return buffer.ToString();
        }
    }
}