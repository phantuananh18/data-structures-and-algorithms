using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    class Program
    {
        static bool checkPermutation(string a, string b)
        {
            //if (a.Length != b.Length)
            //    return false;
            SortString(a);
            SortString(b);
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(checkPermutation("abcd", "bdca"));
            Console.ReadKey();
        }
    }
}