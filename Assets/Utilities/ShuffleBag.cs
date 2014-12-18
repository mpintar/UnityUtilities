/*
 * Inspired by: http://kaioa.com/node/53
  */

using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityUtilities
{
    public class ShuffleBag<T> : ICollection<T>, IEnumerable<T>
    {
        private int cursorPosition;
        private T currentItem;
        private List<T> items;
        private bool isReadOnly = false;
        private Random random;

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return items.Capacity;
            }
        }

        public T CurrentItem
        {
            get
            {
                return currentItem;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
        }

        public ShuffleBag()
        {
            items = new List<T>();
            random = new Random();
        }

        public ShuffleBag(int capacity)
        {
            items = new List<T>(capacity);
            random = new Random();
        }

        public ShuffleBag(IEnumerable<T> collection)
        {
            items = new List<T>(collection);
            random = new Random();
        }

        public void Add(T item)
        {
            Add(item, 1);
        }

        public void Add(T item, int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                items.Add(item);
            }

            cursorPosition = Count - 1;
        }

        public void Add(params T[] items)
        {
            foreach(var item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public T Next()
        {
            if (cursorPosition < 1)
            {
                cursorPosition = Count - 1;
                currentItem = items[0];
                return currentItem;
            }

            int index = random.Next(cursorPosition);

            currentItem = items[index];
            items[index] = items[cursorPosition];
            items[cursorPosition] = currentItem;
            cursorPosition--;

            return currentItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}