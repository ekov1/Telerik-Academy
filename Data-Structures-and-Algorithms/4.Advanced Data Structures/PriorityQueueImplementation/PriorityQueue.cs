namespace PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            elements.Add(element);

            //Insert a new item to the end of the array
            int pos = elements.Count - 1;

            // Percolate up - order the heap in such a way that the lower the value is, the closer to the root it is placed
            // Ideally becoming the root element itself
            while (pos > 0 && element.CompareTo(elements[pos / 2]) < 0)
            {
                elements[pos] = elements[pos / 2];

                pos = pos / 2;
            }

            elements[pos] = element;
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements are present in the collection.");
            }

            var element = elements[0];
            this.elements.RemoveAt(0);
            
            PercolateDown(0);

            return element;
        }

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements are present in the collection.");
            }

            return elements[0];
        }

        // Compares all elements down from the root and reoders the binary-tree array
        private void PercolateDown(int pos)
        {
            var l = 2 * pos + 1;
            var r = 2 * pos + 2;
            var min = pos;

            if (l < this.elements.Count && this.elements[l].CompareTo(this.elements[min]) < 0)
            {
                min = l;
            }

            if (r < this.elements.Count && this.elements[r].CompareTo(this.elements[min]) < 0)
            {
                min = r;
            }

            if (min != pos)
            {
                T current = this.elements[pos];
                this.elements[pos] = this.elements[min];
                this.elements[min] = current;
                PercolateDown(min);
            }
        }
    }
}
