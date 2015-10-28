namespace EncryptedSequence
{
    using System;
    using System.Collections.Generic;

    public static class Startup
    {
        public static void Main()
        {
            var n = 2;

            var queue = new Queue<int>();

            queue.Enqueue(n);

            var intList = new List<int>();

            for (int i = 1; i <= 50; i++)
            {
                var p = queue.Dequeue();
                intList.Add(p);

                var o = p + 1;
                var q = p * 2 + 1;
                var r = p + 2;

                queue.Enqueue(o);
                queue.Enqueue(q);
                queue.Enqueue(r);
            }

            Console.WriteLine(string.Join(", ", intList));
        }
    }
}
