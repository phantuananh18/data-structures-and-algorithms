using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    class Program
    {
        //O(n^2) implementation
        static bool checkUnique(string s)
        {
            /* s="logarit"
             * loop
             * i="l"
             * j="o"
             * check i==j ? true : false
             */
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                        return false;
                }
            }
            return true;
        }

        //sort -> O(nlogn) implementation - O(n^2) is worst case
        static bool isUnique(string s)
        {
            /* s="logarit"
             * sort string of charaters -> s="agilort"
             * loop
             */
            s.ToCharArray();
            for(int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                    return false;
            }
            return true;
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine(checkUnique("logarit"));
            Console.WriteLine(isUnique("logaritlogatt"));
            Console.ReadKey();
        }
    }
}
