using System;
using System.Collections.Generic;
using Algorithms;
using DataProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        private static IList<int> _unassortedList;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            _unassortedList = ListProvider.GetIntList(1000, -100, 100, SortingCondition.Unassorted);
        }

        #region Tests

        [TestMethod]
        public void BubbleSortTest()
        {
            GeneralSortTest(SortingAlgorithms.BubbleSort);
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            GeneralSortTest(SortingAlgorithms.InsertionSort);
        }

        [TestMethod]
        public void OddEvenSortTest()
        {
            GeneralSortTest(SortingAlgorithms.OddEvenSort);
        }

        [TestMethod]
        public void OptimizedCocktailSortTest()
        {
            GeneralSortTest(SortingAlgorithms.CocktailSortOptimized);
        }

        [TestMethod]
        public void OptimizedBubbleSortTest()
        {
            GeneralSortTest(SortingAlgorithms.BubbleSortOptimized);
        }

        [TestMethod]
        public void TreeSortTest()
        {
            GeneralSortTest(SortingAlgorithms.TreeSort);
        }

        [TestMethod]
        public void SelectionSortTest()
        {
            GeneralSortTest(SortingAlgorithms.SelectionSort);
        }

        [TestMethod]
        public void CombSortTest()
        {
            GeneralSortTest(SortingAlgorithms.CombSort);
        }

        [TestMethod]
        public void GnomeSortTest()
        {
            GeneralSortTest(SortingAlgorithms.GnomeSort);
        }

        [TestMethod]
        public void CountingSortTest()
        {
            GeneralSortTest(SortingAlgorithms.CountingSort);
        }

        [TestMethod]
        public void ShellSortTest()
        {
            GeneralSortTest(SortingAlgorithms.ShellSort);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            GeneralSortTest(SortingAlgorithms.MergeSort);
        }

        [TestMethod]
        public void OptimizedMergeSortTest()
        {
            GeneralSortTest(SortingAlgorithms.MergeSortOptimized);
        }

        private void GeneralSortTest(Func<IList<int>, IList<int>> sortAlgorithm)
        {
            var expected = new List<int>(_unassortedList);
            expected.Sort();
            var actual = new List<int>(sortAlgorithm(_unassortedList));
            CollectionAssert.AreEqual(expected, actual, "{0} doesn't work properly", sortAlgorithm.Method.Name);
        }

        #endregion

    }
}
