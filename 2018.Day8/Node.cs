using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day8
{
    internal class Node
    {
        internal List<Node> Children { get; }
        internal List<int> Metadata { get; }

        private Node()
        {
            this.Children = new List<Node>();
            this.Metadata = new List<int>();
        }

        private static Node FromIntArray(int[] input, ref int cursor)
        {
            var ret = new Node();
            var numChildren = input[cursor++];
            var numMetadata = input[cursor++];
            while (numChildren-- > 0)
            {
                ret.Children.Add(FromIntArray(input, ref cursor));
            }
            while (numMetadata-- > 0)
            {
                ret.Metadata.Add(input[cursor++]);
            }
            return ret;
        }

        internal static Node FromIntArray(int[] input)
        {
            int cursor = 0;
            return FromIntArray(input, ref cursor);
        }

        internal int SumMetadata()
        {
            return this.Metadata.Sum() + this.Children.Sum(c => c.SumMetadata());
        }

        internal int Value()
        {
            if (!this.Children.Any())
            {
                return this.Metadata.Sum();
            }
            else
            {
                var ret = 0;
                foreach (var c in this.Metadata)
                {
                    if (c == 0)
                    {
                        continue;
                    }
                    var id = c - 1;
                    if (id < this.Children.Count)
                    {
                        ret += this.Children[id].Value();
                    }
                }
                return ret;
            }
        }
    }
}
