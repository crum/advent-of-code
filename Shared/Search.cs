using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class Search
    {
        public static int IndexOf(this BitArray arr, bool target)
        {
            for (var i = 0; i < arr.Length; ++i)
            {
                if (arr[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public static int LastIndexOf(this BitArray arr, bool target)
        {
            for (var i = arr.Length - 1; i >= 0; --i)
            {
                if (arr[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
