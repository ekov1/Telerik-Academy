using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newJoro
{
    class newJoroTheRabbit
    {
        static void FakeInput()
        {
            StringReader reader = new StringReader(@"1, -2, -3, 4, -5, 6, -7, -8");

            Console.SetIn(reader);
        }

        static void Main(string[] args)
        {
            //FakeInput();

            int[] terrain = ReadArray(Console.ReadLine());
            int maxCount = 0;
            int count = 0;
            


            for (int startPos = 0; startPos < terrain.Length; startPos++)
            {
                for (int step = 1; step < terrain.Length; step++)
                {
                    //bool[] visited = new bool[terrain.Length];
                    count = 1;

                    int prevNum = terrain[startPos];
                    int pos = (startPos + step) % terrain.Length;

                    while (true)
                    {

                        int nextNum = terrain[pos];

                        if (nextNum <= prevNum)
                        {
                            break;
                        }

                        ++count;
                        //visited[pos] = true;
                        prevNum = nextNum;
                        pos = pos + step;

                        if (pos >= terrain.Length)
                        {
                            pos -= terrain.Length;
                        }

                        
                    }

                    if (maxCount < count)
                    {
                        maxCount = count;
                    }

                }

            }
            Console.WriteLine(maxCount);
        }

        private static int[] ReadArray(string input)
        {
            int[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            return arr;
        }

    }
}
