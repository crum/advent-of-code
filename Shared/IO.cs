using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Shared
{
    public static class IO
    {
        public static void WriteLine(string s)
        {
            Debug.WriteLine($"[{DateTimeOffset.Now}] {s}");
            Console.WriteLine($"[{DateTimeOffset.Now}] {s}");
        }
    }
}
