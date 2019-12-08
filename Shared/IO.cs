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

        public static void Write(string s)
        {
            Debug.Write($"[{DateTimeOffset.Now}] {s}");
            Console.Write($"[{DateTimeOffset.Now}] {s}");
        }

        public static int ReadInteger()
        {
            Write("enter integer: ");
            var val = Console.ReadLine().Trim();
            var num = -1;
            while (!int.TryParse(val, out num))
            {
                Write("no, an integer: ");
                val = Console.ReadLine().Trim();
            }
            return num;
        }
    }
}
