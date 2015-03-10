using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseInAMatrix
{
    class HorseInAMatrix
    {
        public static void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];
            int[] dr = {-2, -2, -1, -1, 1, 1, 2, 2};
            int[] dc = {-1, 1, -2, 2, -2, 2, -1, 1};

            int r = 0;
            int c = 0;
            int newR = 0;
            int newC = 0;
            int lastRow = 0;
            int lastCol = 0;
            matrix[r, c] = 1;

            for (int i = 2; i <= n*n; i++)
            {
                bool moved = false;

                for (int dir = 0; dir <= 7; dir++)
                {
                    newR = r + dr[dir];
                    newC = c + dc[dir];

                    if (InRange(newR, newC, n) && matrix[newR, newC] == 0)
                    {
                        r = newR;
                        c = newC;
                        moved = true;
                        break;
                    }
                }

                if (!moved) //if there was no available move
                {   
                    bool found = false;

                    for (int j = 0; j < n && !found; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (matrix[j, k] == 0)
                            { 
                                r = j;
                                c = k;
                                lastRow = r;
                                lastCol = c;
                                found = true;
                                break;
                            }
                        }
                    }
                }
                matrix[r, c] = i;

            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
            }


        }

        private static bool InRange(int newR, int newC, int n)
        {
            if (newR < n && newR >= 0 && newC < n && newC >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Solve();

        }
    }
}
