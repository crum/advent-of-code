using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialState = "##.#...#.#.#....###.#.#....##.#...##.##.###..#.##.###..####.#..##..#.##..#.......####.#.#..#....##.#";
            var rules = new[]
            {                
                "..... => .",
                "....# => .",
                "...#. => .",
                "...## => #",
                "..#.. => .",
                "..#.# => .",
                "..##. => .",
                "..### => #",
                ".#... => #",
                ".#..# => #",
                ".#.#. => .",
                ".#.## => #",
                ".##.. => .",
                ".##.# => .",
                ".###. => .",
                ".#### => .",
                "#.... => .",
                "#...# => .",
                "#..#. => .",
                "#..## => #",
                "#.#.. => .",
                "#.#.# => #",
                "#.##. => #",
                "#.### => .",
                "##... => #",
                "##..# => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #",
                "##### => .",
            };

            // testing
            //initialState = "#..#.#..##......###...###";
            //rules = new[]
            //{
            //    "..... => .",
            //    "....# => .",
            //    "...#. => .",
            //    "...## => #",
            //    "..#.. => #",
            //    "..#.# => .",
            //    "..##. => .",
            //    "..### => .",
            //    ".#... => #",
            //    ".#..# => .",
            //    ".#.#. => #",
            //    ".#.## => #",
            //    ".##.. => #",
            //    ".##.# => .",
            //    ".###. => .",
            //    ".#### => #",
            //    "#.... => .",
            //    "#...# => .",
            //    "#..#. => .",
            //    "#..## => .",
            //    "#.#.. => .",
            //    "#.#.# => #",
            //    "#.##. => .",
            //    "#.### => #",
            //    "##... => .",
            //    "##..# => .",
            //    "##.#. => #",
            //    "##.## => #",
            //    "###.. => #",
            //    "###.# => #",
            //    "####. => #",
            //    "##### => .",
            //};

            var rulesDict = new Dictionary<string, bool>();
            foreach (var r in rules)
            {
                var split = r.Split(new[] { ' ', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                rulesDict[split[0]] = (split[1] == "#");
            }

            var ba = new BitArray(initialState.Length * 1001);
            for (var i = 0; i < initialState.Length; ++i)
            {
                if (initialState[i] == '#')
                {
                    ba[i + initialState.Length * 501] = true;
                }
            }

            IO.WriteLine($"round 0");
            PrettyPrint(ba, initialState.Length);

            var round = 0L;
            for (round = 0L; round < 50_000_000_000L; ++round)
            {
                var stepBa = new BitArray(ba.Length);
                for (var i = 2; i < ba.Length - 2; ++i)
                {
                    var keyChars = new char[5];
                    for (var j = 0; j < keyChars.Length; ++j)
                    {
                        keyChars[j] = (ba[i - 2 + j] ? '#' : '.');
                    }
                    var key = new string(keyChars);
                    stepBa[i] = rulesDict[key];
                }
                if (IsShiftedOneToRight(ba, stepBa))
                {
                    ba = stepBa;
                    break;
                }
                ba = stepBa;
                IO.WriteLine($"round {round + 1}");
                PrettyPrint(ba, initialState.Length);
            }

            var sum = 0L;
            for (var i = 0; i < ba.Length; ++i)
            {
                if (ba[i])
                {
                    var n = i - initialState.Length * 501 + 50_000_000_000L - round - 1;
                    sum += n;
                    IO.WriteLine($"adding {n}, sum {sum}");
                }
            }

            IO.WriteLine($"sum: {sum}");

        }

        private static bool IsShiftedOneToRight(BitArray ba, BitArray stepBa)
        {
            for (var i = 0; i < ba.Length - 1; ++i)
            {
                if (stepBa[i + 1] != ba[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrettyPrint(BitArray plants, int initialLength)
        {
            var line1 = new StringBuilder(); var line2 = new StringBuilder(); var line3 = new StringBuilder(); var line4 = new StringBuilder();
            var first = plants.IndexOf(true);
            var last = plants.LastIndexOf(true);
            for (var i = first - 1; i <= last + 1; ++i)
            {
                var n = i - initialLength * 501;
                if (n <= -100 || n >= 100)
                {
                    line1.Append(Math.Abs(n / 100));
                    line2.Append((Math.Abs(n) / 10) % 10);
                    line3.Append(Math.Abs(n) % 10);
                }
                else if (n <= -10 || n >= 10)
                {
                    line1.Append(' ');
                    line2.Append(Math.Abs(n) / 10);
                    line3.Append(Math.Abs(n) % 10);
                }
                else
                {
                    line1.Append(' ');
                    line2.Append(' ');
                    line3.Append(Math.Abs(n));
                }
                line4.Append(plants[i] ? '#' : '.');
            }

            IO.WriteLine(line1.ToString()); IO.WriteLine(line2.ToString()); IO.WriteLine(line3.ToString()); IO.WriteLine(line4.ToString());
        }

    }
}
