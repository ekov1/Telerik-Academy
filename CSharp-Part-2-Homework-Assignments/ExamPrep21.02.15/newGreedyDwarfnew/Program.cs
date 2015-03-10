using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGreedyDwarfnew
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valley = ReadPattern(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int maxCoins = int.MinValue;


            for (int i = 0; i < M; i++)
            {

                int coins = 0;
                int[] pattern = ReadPattern(Console.ReadLine());
                //////////////
                coins = PlayPattern(pattern, valley);
                //////////////
                if (coins > maxCoins)
                {
                    maxCoins = coins;
                }
            }
            Console.WriteLine(maxCoins);


        }

        private static int PlayPattern(int[] pattern, int[] valley)
        {
            bool[] visited = new bool[valley.Length];
            int coins = valley[0];
            visited[0] = true;
            int index = 0;
            int i = 0;

            while (true)
            {
                index += pattern[i%pattern.Length];
                if (index < 0 || index >= valley.Length || visited[index])
                {
                    break;
                }
                coins += valley[index];

                visited[index] = true;
                i++;
            }
            return coins;
        }

        private static int[] ReadPattern(string p)
        {
            int[] pattern = p.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            return pattern;
        }
    }
}
