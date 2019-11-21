using System;
using System.Collections.Generic;
using System.Text;

namespace Day10
{
    internal class Star
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int dX { get; set; }
        internal int dY { get; set; }

        public override string ToString()
        {
            return $"{X},{Y}@{dX},{dY}";
        }
    }
}
