using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class MoreMath
    {
        public static int Gcd(int x, int y)
        {
            if (x == 0)
            {
                return y;
            }
            else if (y == 0)
            {
                return x;
            }
            else if (x == 1 || y == 1)
            {
                return 1;
            }
            else
            {
                return Gcd(y, x % y);
            }
        }
        public static long Gcd(long x, long y)
        {
            if (x == 0)
            {
                return y;
            }
            else if (y == 0)
            {
                return x;
            }
            else if (x == 1 || y == 1)
            {
                return 1;
            }
            else
            {
                return Gcd(y, x % y);
            }
        }

        public static long Lcm(long x, long y)
        {
            return Math.Abs(x * y) / Gcd(x, y);
        }
    }
}
