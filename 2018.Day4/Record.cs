using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Day4
{
    internal class Record : IComparable<Record>
    {
        internal DateTime Time { get; set; }

        internal enum RecordType
        {
            Invalid,
            NewGuard,
            Sleep,
            Wake,
        }

        internal RecordType Type { get; set; }
        internal int? GuardId { get; set; }

        public int CompareTo([AllowNull] Record other)
        {
            return this.Time.CompareTo(other.Time);
        }
    }
}
