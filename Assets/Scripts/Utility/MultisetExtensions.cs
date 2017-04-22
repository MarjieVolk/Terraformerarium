using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class MultisetExtensions
{
    // TODO maxunion
    public static Multiset<T> MultisetMaxUnion<T>(this Multiset<T> first, Multiset<T> second)
    {
        return null;
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

