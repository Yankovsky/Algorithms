using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProvider
{
    public static class ElementProvider
    {
        static public T GetElementContainedInList<T>(this IEnumerable<T> list)
        {
            var random = new Random();
            var index = random.Next(0, list.Count());
            return list.ElementAt(index);            
        }

        static public T GetElementNotContainedInList<T>(this IEnumerable<T> list) where T : new()
        {
            return new T();
        }
    }
}
