namespace PriorityQueueImplementation
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var Q = new PriorityQueue<int>();

            Q.Enqueue(6);
            Q.Enqueue(7);
            Q.Enqueue(12);
            Q.Enqueue(10);
            Q.Enqueue(15);
            Q.Enqueue(17);

            Console.WriteLine("Peek should return the top-most element of the min-heap: " + Q.Peek());

            int enqValue = 5;

            Console.WriteLine("\n\rEnqueued element with value " + enqValue);
            Q.Enqueue(enqValue);

            Console.WriteLine("\n\rPeek should return the top-most element of the min-heap: " + Q.Peek());

            Console.WriteLine("Dequeued element with value " + Q.Dequeue());
            Console.WriteLine("Dequeued element with value " + Q.Dequeue());
            Console.WriteLine("Dequeued element with value " + Q.Dequeue());
            Console.WriteLine("Dequeued element with value " + Q.Dequeue());
            Console.WriteLine("Dequeued element with value " + Q.Dequeue());

            enqValue = 4;
            Console.WriteLine("\n\rEnqueued element with value " + enqValue);
            Q.Enqueue(enqValue);

            enqValue = 8;
            Q.Enqueue(enqValue);
            Console.WriteLine("\n\rEnqueued element with value " + enqValue);

            Console.WriteLine("\n\rDequeued element with value " + Q.Dequeue());
            Console.WriteLine("Dequeued element with value " + Q.Dequeue());
            Console.WriteLine("Dequeued element with value " + Q.Dequeue());
        }
    }
}
