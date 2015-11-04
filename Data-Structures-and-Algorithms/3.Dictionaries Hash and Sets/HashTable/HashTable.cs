namespace HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HashTable<TK, TV> : IDictionary<TK, TV>
    {
        private const int ExpansionCoefficient = 2;
        private const double AllowedOccupationPercentage = 0.75D;
        private const int DefaultCapacity = 16;

        private LinkedList<KeyValuePair<TK, TV>>[] elements;

        private readonly ICollection<TK> keys;

        public HashTable()
        {
            this.Clear();
            this.keys = new HashSet<TK>();
        }

        public TV this[TK key]
        {
            get
            {
                //var result = this.elements[this.GetNormalizedHash(key)]
                //                                .First(x => x.Key.Equals(key))
                //                                .Value;

                TV result = default(TV);

                var keyExists = this.TryGetValue(key, out result);

                if (!keyExists)
                {
                    throw new KeyNotFoundException("The provided key was not in the dictionary");
                }

                return result;
            }

            set
            {
                var container = this.elements[this.GetNormalizedHash(key)];

                if (container == null)
                {
                    this.Add(new KeyValuePair<TK, TV>(key, value));
                    return;
                }

                var current = container.First;

                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        current.Value = new KeyValuePair<TK, TV>(key, value);
                        return;
                    }

                    current = current.Next;
                }
            }
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<TK> Keys
        {
            get
            {
                return this.keys;
            }
        }

        public ICollection<TV> Values
        {
            get
            {
                var result = new List<TV>();

                foreach (var k in this.Keys)
                {
                    foreach (var element in this.elements[this.GetNormalizedHash(k)])
                    {
                        result.Add(element.Value);
                    }
                }

                return result;
            }
        }

        public void Add(KeyValuePair<TK, TV> item)
        {
            if (this.Keys.Contains(item.Key))
            {
                throw new InvalidOperationException("An item with the same key has already been added.");
            }

            this.Keys.Add(item.Key);

            if (this.elements.Length * AllowedOccupationPercentage <= this.Count)
            {
                this.ResizeTo(this.elements.Length * ExpansionCoefficient);
            }

            if (this.elements[this.GetNormalizedHash(item.Key)] == null)
            {
                this.elements[this.GetNormalizedHash(item.Key)] = new LinkedList<KeyValuePair<TK, TV>>();
            }

            this.elements[this.GetNormalizedHash(item.Key)].AddLast(item);
            this.Count++;
        }

        public void Add(TK key, TV value)
        {
            this.Add(new KeyValuePair<TK, TV>(key, value));
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<TK, TV>>[DefaultCapacity];
            this.Count = 0;
        }

        public bool Contains(KeyValuePair<TK, TV> item)
        {
            return this.elements[this.GetNormalizedHash(item.Key)] != null
                && this.elements[this.GetNormalizedHash(item.Key)].Any(x => x.Equals(item));
        }

        public bool ContainsKey(TK key)
        {
            return this.Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
        {
            for (int i = arrayIndex; ;)
            {
                foreach (var k in this.Keys)
                {
                    foreach (var element in this.elements[k.GetHashCode() % this.elements.Length])
                    {
                        if (i >= array.Length)
                        {
                            return;
                        }

                        array[i++] = element;
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            foreach (var k in this.Keys)
            {
                foreach (var element in this.elements[this.GetNormalizedHash(k)])
                {
                    yield return element;
                }
            }
        }

        public bool Remove(KeyValuePair<TK, TV> item)
        {
            return this.Remove(item.Key, item.Value, true);
        }

        public bool Remove(TK key)
        {
            return this.Remove(key, default(TV), false);
        }

        public bool TryGetValue(TK key, out TV value)
        {
            var container = this.elements[this.GetNormalizedHash(key)];
            var exists = container != null && container.Any(x => x.Key.Equals(key));

            value = exists ? container.First(x => x.Key.Equals(key)).Value : default(TV);

            return exists;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var kvp in this)
            {
                result.Append(kvp);
                result.Append(", ");
            }

            return result.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool Remove(TK key, TV value, bool shouldRemoveValue)
        {
            if (this.elements.Length * AllowedOccupationPercentage / 2 > this.Count)
            {
                this.ResizeTo(this.elements.Length / ExpansionCoefficient);
            }

            this.Keys.Remove(key);

            var container = this.elements[this.GetNormalizedHash(key)];

            if (container == null)
            {
                return false;
            }

            var current = container.First;

            while (current != null)
            {
                if (current.Value.Key.Equals(key))
                {
                    if (!shouldRemoveValue || current.Value.Value.Equals(value))
                    {
                        container.Remove(current);
                        this.Count--;
                        return true;
                    }
                }

                current = current.Next;
            }

            return false;
        }

        private void ResizeTo(int length)
        {
            var newElements = new LinkedList<KeyValuePair<TK, TV>>[length];

            foreach (var k in this.Keys)
            {
                newElements[Math.Abs(k.GetHashCode() % newElements.Length)] = this.elements[this.GetNormalizedHash(k)];
            }

            this.elements = newElements;
        }

        private int GetNormalizedHash(TK key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }
    }
}