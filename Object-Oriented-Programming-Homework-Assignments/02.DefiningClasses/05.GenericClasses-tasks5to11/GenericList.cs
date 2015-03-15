using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.GenericClasses_tasks5to7
{
    class GenericList<T> : IEnumerable<T>
    {
        private const int initialCap = 8;
        private T[] items;

        public GenericList(int capacity)  //we pass the initial capacity as an argument
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.items = new T[this.Capacity];
        }

        public GenericList()  : this(initialCap) //we put an initial cap of 8 elements in case it is not passed as an argument explicitly
        {
        }

        private int Count { get; set; }
        private int Capacity { get; set; }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity = this.Capacity * 2;

                T[] oldItems = this.items;
                this.items = new T[this.Capacity];
                Array.Copy(oldItems, this.items, this.Count);
            }

            this.items[this.Count] = item;
            ++this.Count;
        }

        public void Remove(int index)
        {
            if (index >= 0 && index <= this.Count)
            {
                --this.Count;
                --this.Capacity;

                T[] olditems = this.items;
                this.items = new T[Count];

                for (int i = 0; i < index; i++) //adds elements up to the item with the given index
                {
                    items[i] = olditems[i];
                }

                for (int i = 0; index + i < this.Count; i++) //adds the other elements
                {
                    items[index + i] = olditems[index + i + 1];
                }
            }

            else
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}. Must be non-negative and within the limits of the collection", index));
            }
        }

        public void Insert(int index, T item)
        {
            if (index >= 0 && index <= this.Count)
            {
                ++this.Count;
                T[] oldItems = this.items;

                if (this.Count >= this.Capacity)
                {
                    this.Capacity = this.Capacity * 2;

                    this.items = new T[this.Capacity];
                }

                else
                {
                    this.items = new T[this.Count];
                }

                for (int i = 0; i < index; i++) //adds elements up to the item with the given index
                {
                    items[i] = oldItems[i];
                }

                items[index] = item;

                for (int i = 1; index + i < this.Count; i++) //adds the other elements
                {
                    items[index + i] = oldItems[index + i - 1];
                }
            }

            else
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}. Must be non-negative and within the limits of the collection", index));
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.items = new T[this.Capacity];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (T item in items)
            {
                sb.Append(item + ", ");
            }
            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}. Must be non-negative and within the limits of the collection", index));
                }
                T item = items[index];

                return item;
            }
        }

        public T Max<T>(T firstItem, T secondItem) where T: IComparable<T>
        {
            if (firstItem.CompareTo(secondItem) <= 0)
            {
                return firstItem;
            }
            else
            {
                return secondItem;
            }
        }

        public T Min<T>(T firstItem, T secondItem) where T : IComparable<T>
        {
            if (firstItem.CompareTo(secondItem) <= 0)
            {
                return secondItem;
            }
            else
            {
                return firstItem;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return items[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
