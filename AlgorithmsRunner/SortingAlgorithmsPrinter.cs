using System;
using System.Collections.Generic;
using Algorithms;
using DataProvider;

namespace AlgorithmsRunner
{
    static internal class SortingAlgorithmsPrinter
    {
        static internal void SortingAlgorithmsComparison(IEnumerable<Func<IList<int>, IList<int>>> sortingAlgorithms, IEnumerable<SortingCondition> sortingConditions,
            bool printCollection = false, int objectsCount = 1000, int min = -100, int max = 100)
        {
            Console.WriteLine("--------Test for {0} objects ({1} to {2})--------", objectsCount, min, max);
            foreach (var sortingCondition in sortingConditions)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sortingCondition);
                Console.ResetColor();
                var list = ListProvider.GetIntList(objectsCount, min, max, sortingCondition);
                foreach (var sortingAlgorithm in sortingAlgorithms)
                    SortAlgorithmShell(sortingAlgorithm, list, printCollection);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }

        static private void SortAlgorithmShell(Func<IList<int>, IList<int>> sortingFunction, IList<int> unassortedList, bool printCollection = false)
        {
            if (printCollection)
                unassortedList.PrintCollection();
            var timer = new Timer();

            timer.Start();
            var sortedList = unassortedList.Sort(sortingFunction);
            Console.WriteLine("{0}{1} seconds", sortingFunction.Method.Name.PadRight(40), timer.GetTime());

            if (printCollection)
            {
                sortedList.PrintCollection();
                Console.WriteLine();
            }
        }
    }
}
