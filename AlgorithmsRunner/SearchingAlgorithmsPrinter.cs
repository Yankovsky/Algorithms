using System;
using System.Collections.Generic;
using DataProvider;
using Algorithms;

namespace AlgorithmsRunner
{
    static internal class SearchingAlgorithmsPrinter
    {
        static internal void SearchingAlgorithmsComparison(IEnumerable<Func<IList<int>, int, int?>> searchingAlgorithms,
            bool printCollection = false, int objectsCount = 1000, int min = -100, int max = 100)
        {
            Console.WriteLine("--------Test for {0} objects ({1} to {2})--------", objectsCount, min, max);
            var sortedList = ListProvider.GetIntList(objectsCount, min, max, SortingCondition.Sorted);
            foreach (var searchingAlgorithm in searchingAlgorithms)
                SearchAlgorithmShell(searchingAlgorithm, sortedList, printCollection);
            Console.WriteLine("-----------------------------------------------------------");
        }

        static private void SearchAlgorithmShell(Func<IList<int>, int, int?> searchingFunction, IList<int> sortedList, bool printCollection = false)
        {
            if (printCollection)
                sortedList.PrintCollection();
            var timer = new Timer();
            var element = sortedList.GetElementContainedInList();

            timer.Start();
            var elementIndex = sortedList.Search(element, searchingFunction);
            Console.WriteLine("{0}{1} seconds", searchingFunction.Method.Name.PadRight(40), timer.GetTime());

            if (printCollection)
            {
                Console.WriteLine("Element {0} at {1} position".PadLeft(40), element, elementIndex);
            }
        }
    }
}
