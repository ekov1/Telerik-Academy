using System;

namespace BadCat
{
    using System.Collections.Generic;

    class Program
    {
        private static bool[,] dependencies;
        private static int?[] parents;
        private static SortedSet<string> validSet;

        static void Main(string[] args)
        {
            dependencies = new bool[10, 10];
            parents = new int?[10];
            validSet = new SortedSet<string>();

            var p = int.Parse(Console.ReadLine());

            for (int i = 0; i < p; i++)
            {
                var info = Console.ReadLine().Split(' ');

                var firstNum = int.Parse(info[0]);
                var secondNum = int.Parse(info[3]);
                parents[firstNum] = 0;
                parents[secondNum] = 1;

                switch (info[2])
                {
                    case "before":
                        dependencies[firstNum, secondNum] = true;
                        parents[secondNum] += 1;
                        break;
                    case "after":
                        dependencies[secondNum, firstNum] = true;
                        parents[firstNum] += 1;
                        break;
                }
            }

            List<int> guess = new List<int>();

            var q = new Queue<int>();
            int lastElement = 0;
            for (int i = lastElement; i < parents.Length; i++)
            {
                if (parents[i] == 0)
                {
                    q.Enqueue(i);
                    lastElement = i;
                    break;
                }
            }

            while (q.Count > 0)
            {
                var currentNum = q.Dequeue();

                guess.Add(currentNum);

                for (int i = lastElement; i < parents.Length; i++)
                {
                    if (parents[i] == 0)
                    {
                        q.Enqueue(i);
                        lastElement = i;
                        break;
                    }
                }
            }
        }
    }
}
