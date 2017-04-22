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

    public IEnumerator<T> GetEnumerator()
    {
        return new MultisetEnumerator(this);
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new MultisetEnumerator(this);
    }

    private class MultisetEnumerator : IEnumerator<T>, IEnumerator
    {
        private Multiset<T> parent;
        private Dictionary<T, int>.Enumerator dataEnumerator;
        private int amountOfCurrentSeen;

        public MultisetEnumerator(Multiset<T> parent)
        {
            this.parent = parent;
            Reset();
        }

        public T Current
        {
            get
            {
                if (amountOfCurrentSeen > 0)
                {
                    return dataEnumerator.Current.Key;
                }

                return default(T);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (amountOfCurrentSeen > 0)
                {
                    return dataEnumerator.Current.Key;
                }

                return null;
            }
        }

        public void Dispose()
        {
            dataEnumerator.Dispose();
        }

        public bool MoveNext()
        {
            if (amountOfCurrentSeen >= dataEnumerator.Current.Value)
            {
                amountOfCurrentSeen = 1;
                return dataEnumerator.MoveNext();
            }
            else
            {
                amountOfCurrentSeen++;
                return true;
            }
        }

        public void Reset()
        {
            dataEnumerator = parent.data.GetEnumerator();
            dataEnumerator.MoveNext();
            amountOfCurrentSeen = 0;
        }
    }
}

