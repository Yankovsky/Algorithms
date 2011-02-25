using System;
using System.Collections.Generic;

namespace AlgorithmsRunner
{
    internal static class PrintUtilities
    {
        internal static void PrintCollection<T>(this IEnumerable<T> list)
        {
            foreach (var element in list)
                Console.Write("{0} ", element);
            Console.WriteLine();
        }
    }
}
