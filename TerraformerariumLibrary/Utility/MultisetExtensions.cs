using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class MultisetExtensions
{
    // TODO maxunion
    public static Multiset<T> MultisetMaxUnion<T>(this Multiset<T> first, Multiset<T> second)
    {
        var firstItemsWithCounts = first.GroupBy(item => item).ToDictionary(group => group.Key, group => group.Count());
        var secondItemsWithCounts = second.GroupBy(item => item).ToDictionary(group => group.Key, group => group.Count());

        var allKeys = firstItemsWithCounts.Keys.Union(secondItemsWithCounts.Keys);

        var maxes = allKeys
            .Select(
                key =>
                {
                    var firstCount = firstItemsWithCounts.ContainsKey(key)
                        ? firstItemsWithCounts[key]
                        : 0;
                    var secondCount = secondItemsWithCounts.ContainsKey(key)
                        ? secondItemsWithCounts[key]
                        : 0;
                    return new
                    {
                        key,
                        count = Math.Max(firstCount, secondCount),
                    };
                });
        return new Multiset<T>(
            maxes.SelectMany(obj => Enumerable.Repeat(obj.key, obj.count)));
    }

    public static Multiset<T> MultisetDifference<T>(this Multiset<T> first, Multiset<T> second)
    {
        Multiset<T> difference = new Multiset<T>(first);
        foreach (T element in second)
        {
            difference.Remove(element);
        }

        return difference;
    }
}

