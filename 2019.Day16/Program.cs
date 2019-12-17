using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019.Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            var shortInput = SingleDigitsToArray("59780176309114213563411626026169666104817684921893071067383638084250265421019328368225128428386936441394524895942728601425760032014955705443784868243628812602566362770025248002047665862182359972049066337062474501456044845186075662674133860649155136761608960499705430799727618774927266451344390608561172248303976122250556049804603801229800955311861516221350410859443914220073199362772401326473021912965036313026340226279842955200981164839607677446008052286512958337184508094828519352406975784409736797004839330203116319228217356639104735058156971535587602857072841795273789293961554043997424706355960679467792876567163751777958148340336385972649515437");
            var input = new int[shortInput.Length * 10000];
            for (var i = 0; i < 10000; ++i)
            {
                Array.Copy(shortInput, 0, input, shortInput.Length * i, shortInput.Length);
            }
            //input = SingleDigitsToArray("12345678");
            var nextInput = new int[input.Length];

            IO.WriteLine($"phase 0: {string.Join("", input)}");

            for (var i = 0; i < 100; ++i)
            {
                for (var j = 0; j < input.Length; ++j)
                {
                    var total = 0;
                    var pattern = Pattern(j + 1).GetEnumerator();
                    pattern.MoveNext();
                    for (var k = 0; k < input.Length; ++k)
                    {
                        total += input[k] * pattern.Current;
                        pattern.MoveNext();
                    }
                    nextInput[j] = Math.Abs(total) % 10;
                }
                Array.Copy(nextInput, 0, input, 0, input.Length);
                //IO.WriteLine($"phase {i + 1}: {string.Join("", input)}");
            }
            IO.WriteLine($"final: {string.Join("", input.Skip(5978017).Take(8))}");
        }

        private static int[] SingleDigitsToArray(string s)
        {
            var ret = new int[s.Length];
            for (var i = 0; i < ret.Length; ++i)
            {
                ret[i] = (s[i] - '0');
            }
            return ret;
        }

        private static IEnumerable<int> Pattern(int phase)
        {
            foreach (var x in Enumerable.Repeat(0, phase - 1))
            {
                yield return x;
            }
            while (true)
            {
                foreach (var x in Enumerable.Repeat(1, phase))
                {
                    yield return x;
                }
                foreach (var x in Enumerable.Repeat(0, phase))
                {
                    yield return x;
                }
                foreach (var x in Enumerable.Repeat(-1, phase))
                {
                    yield return x;
                }
                foreach (var x in Enumerable.Repeat(0, phase))
                {
                    yield return x;
                }
            }
        }
    }
}
