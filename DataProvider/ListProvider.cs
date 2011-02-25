using System;
using System.Collections.Generic;

namespace DataProvider
{
    public static class ListProvider
    {
        static public List<int> GetIntList(int count, int min, int max, SortingCondition sortingCondition = SortingCondition.Unassorted)
        {
            var list = new List<int>();
            var random = new Random();

            switch (sortingCondition)
            {
                case SortingCondition.Unassorted:
                    {
                        for (int i = 0; i < count; i++)
                            list.Add(random.Next(min, max));
                        break;
                    }
                case SortingCondition.PoorlySorted:
                    {
                        int sortedCount = (int)(count * 0.4);
                        for (int i = 0; i < sortedCount; i++)
                            list.Add(random.Next(min, max));
                        list.Sort();

                        for (int i = 0; i < count - sortedCount; i++)
                            list.Insert(random.Next(0, list.Count), random.Next(min, max));
                        break;
                    }
                case SortingCondition.SubstantiallySorted:
                    {
                        int sortedCount = (int)(count * 0.8);
                        for (int i = 0; i < sortedCount; i++)
                            list.Add(random.Next(min, max));
                        list.Sort();

                        for (int i = 0; i < count - sortedCount; i++)
                            list.Insert(random.Next(0, list.Count), random.Next(min, max));
                        break;
                    }
                case SortingCondition.Sorted:
                    {
                        for (int i = 0; i < count; i++)
                            list.Add(random.Next(min, max));
                        list.Sort();
                        break;
                    }
                case SortingCondition.PartiallySorted:
                    {
                        int firstListCount = count / 3;
                        var firstList = new List<int>();
                        for (int i = 0; i < firstListCount; i++)
                            firstList.Add(random.Next(min, max));
                        firstList.Sort();

                        int secondListCount = count / 3;
                        var secondList = new List<int>();
                        for (int i = 0; i < secondListCount; i++)
                            secondList.Add(random.Next(min, max));
                        secondList.Sort();

                        int thirdListCount = count - firstListCount - secondListCount;
                        var thirdList = new List<int>();
                        for (int i = 0; i < thirdListCount; i++)
                            thirdList.Add(random.Next(min, max));
                        thirdList.Sort();

                        list.AddRange(firstList);
                        list.AddRange(secondList);
                        list.AddRange(thirdList);
                        break;
                    }
                case SortingCondition.Reversed:
                    {
                        for (int i = 0; i < count; i++)
                            list.Add(random.Next(min, max));
                        list.Sort();
                        list.Reverse();
                        break;
                    }
            }
            return list;
        }
    }

    public enum SortingCondition
    {
        Unassorted,
        PoorlySorted,
        SubstantiallySorted,
        Sorted,
        PartiallySorted,
        Reversed
    }
}
