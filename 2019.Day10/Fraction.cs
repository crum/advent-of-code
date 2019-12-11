using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _2019.Day10
{
    internal class Fraction : IComparable<Fraction>
    {
        internal int Numerator { get; set; }
        internal int Denominator { get; set; }

        internal Fraction Reduce()
        {
            var ret = new Fraction(this);
            var gcd = Gcd(ret.Numerator, ret.Denominator);
            while (gcd != 1)
            {
                ret.Numerator /= gcd;
                ret.Denominator /= gcd;
                gcd = Gcd(ret.Numerator, ret.Denominator);
            }
            return ret;
        }

        private int Gcd(int x, int y)
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

        internal Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        internal Fraction(Fraction f)
        {
            this.Numerator = f.Numerator;
            this.Denominator = f.Denominator;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Fraction;
            if (other == null)
            {
                return false;
            }
            return this.Reduce().Denominator == other.Reduce().Denominator && this.Reduce().Numerator == other.Reduce().Numerator;
        }

        public override int GetHashCode()
        {
            return this.Reduce().Denominator.GetHashCode() ^ this.Reduce().Numerator.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }

        public int CompareTo([AllowNull] Fraction other)
        {
            if (other == null)
            {
                return -1;
            }
            return other.Numerator * this.Denominator - this.Numerator * other.Denominator;
        }
    }
}
