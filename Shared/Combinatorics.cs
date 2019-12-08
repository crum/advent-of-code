using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class Combinatorics
    {
        public static IEnumerable<IEnumerable<T>> Permutations<T>(params T[] items)
        {
            return Permutations(items.Length, items);
        }

        private static IEnumerable<IEnumerable<T>> Permutations<T>(int k, T[] items)
        {
            if (k == 1)
            {
                yield return items;
            }
            else
            {
                foreach (var p in Permutations(k - 1, items))
                {
                    yield return p;
                }

                for (var i = 0; i < k - 1; ++i)
                {
                    if (k % 2 == 0)
                    {
                        var temp = items[i];
                        items[i] = items[k - 1];
                        items[k - 1] = temp;
                    }
                    else
                    {
                        var temp = items[0];
                        items[0] = items[k - 1];
                        items[k - 1] = temp;
                    }
                    foreach (var p in Permutations(k - 1, items))
                    {
                        yield return p;
                    }
                }
            }
        }
    }
}
