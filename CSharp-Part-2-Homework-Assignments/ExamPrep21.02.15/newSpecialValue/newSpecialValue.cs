using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newSpecialValue
{
    class newSpecialValue
    {
        static void FakeInput()
        {
            StringReader reader = new StringReader(@"6
                                                    5, -4, 8, -5, 0
                                                    1, -2, -1, 1, 0, -1, -1, -2, 1
                                                    3, -5
                                                    4, -9, -4, 4, 0, 7
                                                    1, -2, -8, 4, -8, 7, -5, -4, -4
                                                    4, -1, 0, -3, 2, 4, -4, 1");

            Console.SetIn(reader);
        }

        static void Main()
        {
            //FakeInput();

            int N = int.Parse(Console.ReadLine());
            var rowsL = new List<int[]>();


            for (int i = 0; i < N; i++)
            {
                int[] row = ReadArray(Console.ReadLine());
                rowsL.Add(row);
            }
            int rows = rowsL.Count;
            int cols = rowsL.Max(row => row.Length);




            int j = 0;

            int maxResult = 0;

            while (j < rowsL[0].Length)
            {
                int result = 0;
                int lastCell = 0;
                int currentCell = rowsL[0][j];
                bool[,] visitedL = new bool[rows, cols];

                int path = 1;
                int i = 0;

                while (true)
                {
                    if (currentCell < 0 || visitedL[(i + 1) % rows, currentCell])
                    {
                        lastCell = currentCell;
                        break;
                    }

                    visitedL[(i + 1) % rows, currentCell] = true;
                    currentCell = rowsL[(i + 1) % rows][currentCell];

                    path++;
     
                    i++;
                }

                result = path + Math.Abs(lastCell);

                if (maxResult < result)
                {
                    maxResult = result;
                }
                j++;
            }
            Console.WriteLine(maxResult     );

        }

        private static int[] ReadArray(string input)
        {
            int[] arr = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            return arr;
        }
    }
}
