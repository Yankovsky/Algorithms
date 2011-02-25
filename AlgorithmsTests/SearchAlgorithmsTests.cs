using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;
using DataProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class SearchAlgorithmsTests
    {
        private static IList<int> _sortedList;
        private static int _elementContainedInList;
        private static int _elementNotContainedInList;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            var min = -100;
            _sortedList = ListProvider.GetIntList(1000, min, 100, SortingCondition.Sorted);
            _elementContainedInList = _sortedList.GetElementContainedInList();
            _elementNotContainedInList = min - 1;
        }

        [TestMethod]
        public void BinarySearchTest()
        {
            GeneralSearchTest(SearchAlgorithms.BinarySearch);
        }

        [TestMethod]
        public void BinarySearchElementNotFoundTest()
        {
            GeneralElementNotFoundTest(SearchAlgorithms.BinarySearch);
        }

        private void GeneralSearchTest(Func<IList<int>, int, int?> searchAlgorithm)
        {
            var expected = _sortedList.IndexesOf(_elementContainedInList);
            var actual = searchAlgorithm(_sortedList, _elementContainedInList);
            Assert.IsTrue(expected.Contains(actual.Value), "{0} doesn't work properly", searchAlgorithm.Method.Name);
        }

        private void GeneralElementNotFoundTest(Func<IList<int>, int, int?> searchAlgorithm)
        {
            var actual = searchAlgorithm(_sortedList, _elementNotContainedInList);
            Assert.AreEqual(null, actual, "{0} find an element not contained in the list", searchAlgorithm.Method.Name);
        }
    }
}
