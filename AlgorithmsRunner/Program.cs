using System;
using System.Collections.Generic;
using Algorithms;
using DataProvider;

namespace AlgorithmsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortingConditions = new SortingCondition[] { SortingCondition.Unassorted, SortingCondition.Reversed };
            var sortingAlgorithms = new Func<IList<int>, IList<int>>[] { SortingAlgorithms.CSharpSort,
                SortingAlgorithms.CountingSort, SortingAlgorithms.MergeSort, SortingAlgorithms.MergeSortOptimized, SortingAlgorithms.ShellSort, SortingAlgorithms.CombSort };
            SortingAlgorithmsPrinter.SortingAlgorithmsComparison(sortingAlgorithms, sortingConditions, false, 100000, -1000, 1000);
            
            /*
            var searchingAlgorithms = new Func<IList<int>, int, int?>[] { SearchAlgorithms.BinarySearch };
            SearchingAlgorithmsPrinter.SearchingAlgorithmsComparison(searchingAlgorithms, false, 10000000, -1000, 1000);
            */
            Console.Read();
        }
    }
}
