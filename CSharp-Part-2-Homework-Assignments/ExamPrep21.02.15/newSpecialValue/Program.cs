using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newPatterns
{
    class Program
    {
        static void FakeInput()
        {
            StringReader reader = new StringReader(@"60
2701 4465 5068 9980 3465 2861 3941 1625 2239 1210 1297 7232 682 5646 4538 2266 5039 198 68 4826 7870 6908 2689 6598 5343 8485 8659 7828 9079 5268 9336 2897 7061 6627 1769 163 218 5435 7901 923 5170 258 8457 5297 3692 5807 8577 4104 4105 4106 208 5724 798 128 8530 5793 1776 8470 4636 4979 
                                                     ");

            Console.SetIn(reader);
        }


        static void Main(string[] args)
        {
            //FakeInput();

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[i, col] = row[col];
                }
            }

            int[] patternRow = { 0, 0, 0, 1, 1, 0, 0 };
            int[] patternCol = { 0, 1, 1, 0, 0, 1, 1 };


            bool found = false;
            long MaxSequence = long.MinValue;
            bool rolling = true;

            while (rolling)
            {
                long sequence = 0;

                for (int i = 0; i <= n - 3; i++) //3 being the height of our pattern
                {
                    sequence = 0;
                    for (int j = 0; j <= n - 5; j++) //5 being the length of our pattern
                    {
                        if (matrix[i, j] + 1 == matrix[i, j + 1]
                            && matrix[i, j + 1] + 1 == matrix[i, j + 2]
                            && matrix[i, j + 2] + 1 == matrix[i + 1, j + 2]
                            && matrix[i + 1, j + 2] + 1 == matrix[i + 2, j + 2]
                            && matrix[i + 2, j + 2] + 1 == matrix[i + 2, j + 3]
                            && matrix[i + 2, j + 3] + 1 == matrix[i + 2, j + 4])
                        {
                            sequence += matrix[i, j];
                            sequence += matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j + 2] + matrix[i + 2, j + 2] + matrix[i + 2, j + 3];
                            sequence += matrix[i + 2, j + 4];
                            found = true;
                        }

                        if (sequence > MaxSequence)
                        {
                            MaxSequence = sequence;
                        }

                        if (i == n - 3 && j == n - 5)
                        {
                            rolling = false;
                        }
                    }


                }
            }

            if (found)
            {
                Console.WriteLine("YES " + MaxSequence);
            }
            else
            {
                diag(n, matrix);
            }

        }

        private static void diag(int n, int[,] a)
        {
            long d = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        d = d + a[i, j];
                    }
                }
            }
            Console.WriteLine("NO {0}", d);
        }


    }
}
