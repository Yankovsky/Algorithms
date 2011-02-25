using System.Collections.Generic;

namespace Algorithms
{
    public static class SearchAlgorithms
    {
        public static int? BinarySearch(IList<int> sortedList, int x)
        {
            var low = 0;
            var high = sortedList.Count;
            while (low != high)
            {
                var mid = (low + high) >> 1;
                if (x == sortedList[mid])
                    return mid;
                else if (x < sortedList[mid])
                    high = mid;
                else
                    low = mid;
            }
            return null;
        }
    }
}
