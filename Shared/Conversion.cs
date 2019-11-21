﻿using System;

namespace Shared
{
    public static class Conversion
    {
        public static int[] ToIntArray(this string[] strings)
        {
            var ret = new int[strings.Length];
            for (var i = 0; i < strings.Length; ++i)
            {
                ret[i] = int.Parse(strings[i]);
            }
            return ret;
        }
    }
}
