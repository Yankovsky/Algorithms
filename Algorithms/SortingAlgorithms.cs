using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Algorithms
{
    public static class SortingAlgorithms
    {
        #region C# sorting mechanism

        public static IList<int> CSharpSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            list.Sort();
            return list;
        }

        #endregion

        #region Exchange sorts

        public static IList<int> BubbleSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            int elementsCount = list.Count();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < elementsCount - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
            while (swapped);
            return list;
        }

        public static IList<int> BubbleSortOptimized(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            int endIndex = list.Count();
            do
            {
                var newEndIndex = 0;
                for (int i = 0; i < endIndex - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        newEndIndex = i + 1;
                    }
                }
                endIndex = newEndIndex;
            }
            while (endIndex > 1);
            return list;
        }

        public static IList<int> CocktailSortOptimized(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            int startIndex = 0;
            int endIndex = list.Count();
            do
            {
                var newEndIndex = 0;
                for (int i = startIndex; i < endIndex - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        newEndIndex = i + 1;
                    }
                }
                endIndex = newEndIndex;

                var newStartIndex = 0;
                for (int i = endIndex - 1; i >= startIndex; i--)
                {
                    if (list[i] > list[i + 1])
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        newStartIndex = i + 1;
                    }
                }
                startIndex = newStartIndex;
            }
            while (endIndex - startIndex > 1);
            return list;
        }
        
        public static IList<int> OddEvenSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            int elementsCount = list.Count();
            bool sorted;
            do
            {
                sorted = true;
                for (int i = 0; i < elementsCount - 1; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        sorted = false;
                    }
                }
                for (int i = 1; i < elementsCount - 1; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        sorted = false;
                    }
                }
            }
            while (!sorted);
            return list;
        }

        public static IList<int> CombSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            int elementsCount = list.Count();
            double shrinkFactor = 1.3;
            int gap = elementsCount;
            bool swapped;
            do
            {
                swapped = false;
                gap = (int)(gap / shrinkFactor);
                if (gap == 9 || gap == 10)
                    gap = 11;
                if (gap == 0)
                    gap = 1;
                for (int i = 0; i + gap < elementsCount; i++)
                    if (list[i] > list[i + gap])
                    {
                        list.Swap(i, i + gap);
                        swapped = true;
                    }
            }
            while (gap != 1 || swapped);
            return list;
        }

        public static IList<int> GnomeSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            int elementsCount = list.Count();
            int index = 1;
            do
            {
                if (index == 0 || list[index - 1] <= list[index])
                    index++;
                else
                {
                    list.Swap(index - 1, index);
                    index--;
                }
            }
            while (index != elementsCount);
            return list;
        }

        #endregion

        #region Selection sorts

        public static IList<int> SelectionSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            var elementsCount = list.Count();
            for (int startIndex = 0; startIndex < elementsCount; startIndex++)
            {
                int minIndex = startIndex;
                for (int j = startIndex; j < elementsCount; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                if (startIndex != minIndex)
                    list.Swap(startIndex, minIndex);
            }
            return list;
        }

        #endregion

        #region Insertion sorts

        public static IList<int> InsertionSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            var elementsCount = list.Count();
            for (int i = 1; i < elementsCount; i++)
                for (int j = i; j > 0; j--)
                    if (list[j - 1] > list[j])
                        list.Swap(j - 1, j);
            return list;
        }

        //Using binary search for place a element
        public static IList<int> InsertionSortOptimized(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            var elementsCount = list.Count();
            for (int i = 1; i < elementsCount; i++)
                for (int j = i; j > 0; j--)
                    if (list[j - 1] > list[j])
                        list.Swap(j - 1, j);
            return list;
        }

        public static IList<int> TreeSort(IList<int> unassortedList)
        {
            var tree = new BinarySearchTree(unassortedList);
            return tree.Traversal();
        }

        public static IList<int> ShellSort(IList<int> unassortedList)
        {
            var list = new List<int>(unassortedList);
            var elementsCount = list.Count();
            double shrinkFactor = 2.2;
            var gap = elementsCount;
            bool swapped;
            do
            {
                swapped = false;
                gap = (int)(gap / shrinkFactor);
                if (gap == 0)
                    gap = 1;
                for (int i = 0; i < gap; i++)
                    for (int j = i + gap; j < elementsCount; j += gap)
                    {
                        int k = 0;
                        while (j >= k + gap && list[j - k - gap] > list[j - k])
                        {
                            list.Swap(j - k - gap, j - k);
                            k += gap;
                            swapped = true;
                        }
                    }
            }
            while (gap != 1 || swapped);
            return list;
        }

        #endregion

        #region Distribution sorts
        
        public static IList<int> CountingSort(IList<int> unassortedList)
        {
            int elementsCount = unassortedList.Count();

            int min;
            int max;
            max = min = unassortedList[0];

            for (int i = 0; i < elementsCount; i++)
            {
                if (unassortedList[i] < min)
                    min = unassortedList[i];
                if (unassortedList[i] > max)
                    max = unassortedList[i];
            }
            var size = max - min + 1;

            int[] array = new int[size];

            for (int i = 0; i < elementsCount; i++)
                array[unassortedList[i] - min] += 1;

            var list = new List<int>();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < array[i]; j++)
                    list.Add(i + min);
            return list;
        }

        #endregion

        #region Merge sorts

        public static IList<int> MergeSort(IList<int> unassortedList)
        {
            int elementsCount = unassortedList.Count();
            if (elementsCount == 1)
                return unassortedList;

            var dividerIndex = elementsCount / 2;
            IList<int> leftList = new List<int>();
            for (int i = 0; i < dividerIndex; i++)
                leftList.Add(unassortedList[i]);
            IList<int> rightList = new List<int>();
            for (int i = dividerIndex; i < elementsCount; i++)
                rightList.Add(unassortedList[i]);

            leftList = MergeSort(leftList);
            rightList = MergeSort(rightList);
            return Merge(leftList, rightList);
        }

        //Using InsertionSort for lists of 16 elements or less
        public static IList<int> MergeSortOptimized(IList<int> unassortedList)
        {
            int elementsCount = unassortedList.Count();
            if (elementsCount < 16)
                return InsertionSort(unassortedList);

            var dividerIndex = elementsCount / 2;
            IList<int> leftList = new List<int>();
            for (int i = 0; i < dividerIndex; i++)
                leftList.Add(unassortedList[i]);
            IList<int> rightList = new List<int>();
            for (int i = dividerIndex; i < elementsCount; i++)
                rightList.Add(unassortedList[i]);

            leftList = MergeSortOptimized(leftList);
            rightList = MergeSortOptimized(rightList);
            return Merge(leftList, rightList);
        }

        private static IList<int> Merge(IList<int> leftList, IList<int> rightList)
        {
            var list = new List<int>();
            var elementsCount = leftList.Count + rightList.Count;
            leftList.Add(int.MaxValue);
            rightList.Add(int.MaxValue);
            var leftIndex = 0;
            var rightIndex = 0;
            for (int i = 0; i < elementsCount; i++)
            {
                if (leftList[leftIndex] < rightList[rightIndex])
                {
                    list.Add(leftList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    list.Add(rightList[rightIndex]);
                    rightIndex++;
                }
            }
            return list;
        }

        #endregion

    }
}