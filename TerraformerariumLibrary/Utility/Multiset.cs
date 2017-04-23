using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Multiset<T> : ICollection<T>
{
    private Dictionary<T, int> data;
    private int size;

    public Multiset()
    {
        data = new Dictionary<T, int>();
        size = 0;
    }

    public Multiset(IEnumerable<T> enumerable) : this()
    {
        foreach (T element in enumerable)
        {
            Add(element);
        }
    }

    public Multiset(params T[] elements) : this()
    {
        foreach (T element in elements)
        {
            Add(element);
        }
    }

    public Dictionary<T, int> AsDictionary()
    {
        return new Dictionary<T, int>(data);
    }

    public int Count { get { return size; } }

    public bool IsReadOnly { get { return false; } }

    public void Add(T item)
    {
        int current;
        if (data.TryGetValue(item, out current))
        {
            data[item] = current + 1;
        }
        else
        {
            data[item] = 1;
        }
        this.size++;
    }

    public void Clear()
    {
        data = new Dictionary<T, int>();
        size = 0;
    }

    public bool Contains(T item)
    {
        return data.ContainsKey(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        foreach (T element in this)
        {
            array[arrayIndex++] = element;
        }
    }

    public bool Remove(T item)
    {
        int current;

        if (data.TryGetValue(item, out current))
        {
            if (current == 0)
            {
                return false;
            }
            if (current == 1)
            {
                data.Remove(item);
                return true;
            }

            data[item]--;
            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private IEnumerable<T> GetEnumerable()
    {
        var snapshot = new Dictionary<T, int>(this.data);
        foreach (var kvp in snapshot)
        {
            for(int count = 0; count < kvp.Value; count++)
            {
                yield return kvp.Key;
            }
        }
    }
}

