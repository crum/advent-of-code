using Shared;
using System;

namespace _2019.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var low = 147981;
            var high = 691423;

            var count = 0;
            for (var i = low; i <= high; ++i)
            {
                if (Check(i))
                {
                    ++count;
                }
            }

            IO.WriteLine($"found {count}");
        }

        private static bool Check(int i)
        {
            var digits = new int[(int)Math.Ceiling(Math.Log10(i))];
            for (var j = 0; j < digits.Length; ++j)
            {
                digits[j] = i % 10;
                i /= 10;
            }
            Array.Reverse(digits);

            var repeats = new bool[digits.Length];
            for (var j = 1; j < digits.Length; ++j)
            {
                if (digits[j] == digits[j - 1])
                {
                    repeats[j] = true;
                }
            }
            var foundRepeating = false;
            var last = digits[0];
            var lastLast = -1;
            var foundDecreasing = false;
            for (var j = 1; j < digits.Length; ++j)
            {
                if (repeats[j] && (j == digits.Length - 1 || !repeats[j + 1]) && !repeats[j - 1])
                {
                    foundRepeating = true;
                }
                if (digits[j] < last)
                {
                    foundDecreasing = true;
                }
                lastLast = last;
                last = digits[j];
            }

            return foundRepeating && !foundDecreasing;
        }
    }
}
