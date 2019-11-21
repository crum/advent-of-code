using Shared;
using System;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var serial = 2187;

            var maxX = -1;
            var maxY = -1;
            var maxSize = -1;
            var max = int.MinValue;

            for (var size = 1; size <= 300; ++size)
            {
                for (var x = 1; x <= 298; ++x)
                {
                    for (var y = 1; y <= 298; ++y)
                    {
                        var sumPower = 0;
                        for (var dx = 0; dx < size; ++dx)
                        {
                            for (var dy = 0; dy < size; ++dy)
                            {
                                sumPower += Power(x + dx, y + dy, serial);
                            }
                        }
                        if (sumPower > max)
                        {
                            max = sumPower;
                            maxX = x;
                            maxY = y;
                            maxSize = size;
                        }
                    }
                }
            }

            IO.WriteLine($"max {max} at {maxX}, {maxY}, {maxSize}");
        }

        static int Power(int x, int y, int serial)
        {
            var i = ((x + 10) * y + serial) * (x + 10);
            return (i / 100) % 10 - 5; 
        }
    }
}
