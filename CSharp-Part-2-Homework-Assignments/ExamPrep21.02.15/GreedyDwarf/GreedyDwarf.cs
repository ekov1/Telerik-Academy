using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class GreedyDwarf
    {
        static void Main(string[] args)
        {
            //read valley (number sequence) and numbers
            int[] valley = ReadArray(Console.ReadLine()); //to be implemented
            //read M
            int M = int.Parse(Console.ReadLine());

            int maxSum = int.MinValue;

            for (int i = 0; i < M; i++)
            {
                int[] pattern = ReadArray(Console.ReadLine());
                bool[] isVisited = new bool[valley.Length];

                int currentSum = WorkWithPattern(valley, pattern, isVisited);

                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }
            }

            Console.WriteLine(maxSum);
        }

        private static int WorkWithPattern(int[] valley, int[] pattern, bool[] isVisited)
        {
            int currentIndex = 0;
            int currentSum = valley[currentIndex];
            isVisited[currentIndex] = true;

            for (int j = 0; true; j++)
            {
                if (j > pattern.Length - 1)
                {
                    j -= pattern.Length;
                }

                int nextStep = pattern[j];
                currentIndex += nextStep;

                if (currentIndex < 0 || currentIndex > valley.Length - 1 || isVisited[currentIndex])
                {
                    break;
                }

                currentSum += valley[currentIndex];
                isVisited[currentIndex] = true;
            }
            return currentSum;
        }




        private static int[] ReadArray(string input)
        {
            int[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            return arr;
        }
    }
}
