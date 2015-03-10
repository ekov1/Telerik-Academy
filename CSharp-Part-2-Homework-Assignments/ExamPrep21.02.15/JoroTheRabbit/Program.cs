using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] terrain = ReadArray(Console.ReadLine());

            

            int num = 0;

            int maxLength = 0;

            for (int step = 0; step <= terrain.Length; step++)
            {
                int length = 0;
                bool[] visited = new bool[terrain.Length];
                
                while (true)
                {

                    num = terrain[(step + length) % terrain.Length];
                    int nextNum = terrain[(step+step+length) % terrain.Length];

                    if (num >= nextNum || visited[(step + step + length) % terrain.Length])
                    {
                        break;
                    }

                    visited[(step + length)% terrain.Length] = true;
                    length++;

                }

                if (maxLength < length)
                {
                    maxLength = length;
                }

            }
            
    
        }



        private static int[] ReadArray(string input)
        {
            int[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            return arr;
        }
    }

}
