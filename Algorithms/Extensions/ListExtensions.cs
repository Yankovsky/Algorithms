using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class ListExtensions
    {
        public static IList<int> Sort(this IList<int> unassortedList, Func<IList<int>, IList<int>> sortFunction)
        {
            return sortFunction(unassortedList);
        }

        public static int? Search(this IList<int> sortedList, int x, Func<IList<int>, int, int?> searchFunction)
        {
            return searchFunction(sortedList, x);
        }        

        public static void Swap(this IList<int> list, int firstElementIndex, int secondElementIndex)
        {
            var temp = list[firstElementIndex];
            list[firstElementIndex] = list[secondElementIndex];
            list[secondElementIndex] = temp;
        }

        public static IEnumerable<int> IndexesOf(this IList<int> list, int x)
        {
            var indexesList = new List<int>();
            for (int i = 0; i < list.Count(); i++)
                if (list.ElementAt(i) == x)
                    indexesList.Add(i);
            return indexesList;
        }
    }
}
