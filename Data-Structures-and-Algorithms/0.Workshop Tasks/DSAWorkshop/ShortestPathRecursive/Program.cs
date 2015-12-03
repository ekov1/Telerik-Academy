using System;
using System.Collections.Generic;

namespace ShortestPathRecursive
{
    class Program
    {
        private static SortedSet<string> PossiblePaths;

        static void Main(string[] args)
        {
            var map = Console.ReadLine().ToCharArray();

            PossiblePaths = new SortedSet<string>();

            GetPossiblePath(map, 0);

            Console.WriteLine(PossiblePaths.Count);
            Console.WriteLine(string.Join(Environment.NewLine, PossiblePaths));
        }

        private static void GetPossiblePath(char[] map, int k)
        {
            if (k == map.Length)
            {
                PossiblePaths.Add(new string(map));
                return;
            }

            if (map[k] == '*')
            {
                map[k] = 'L';
                GetPossiblePath(map, k + 1);
                map[k] = 'S';
                GetPossiblePath(map, k + 1);
                map[k] = 'R';
                GetPossiblePath(map, k + 1);
                map[k] = '*';
            }
            else
            {
                GetPossiblePath(map, k + 1);
            }
        }
    }
}
