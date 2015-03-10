using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EncodedPath
{
    class EncodedPath
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //4
            int m = int.Parse(Console.ReadLine()); //3
            //string input = Console.ReadLine(); //Abe, G060 3 pi4
            string input = new string('3', 50) + " Abe, Gosho e pi4!";

            bool[,] matrix = new bool[n, m];
            int[] dr = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };

            BigInteger result = 1;
            matrix[0, 0] = true;

            int direction = 0;
            //int r = 0;
            //int c = 0;
            int newR = 0;
            int newC = 0;
            bool exit = false;


            foreach (char ch in input.ToUpper())
            {
                switch (ch)
                {
                    #region
                    case '0':
                        direction = 0; break;
                    case '1':
                        direction = 1; break;
                    case '2':
                        direction = 2; break;
                    case '3':
                        direction = 3; break;
                    case '4':
                        direction = 4; break;
                    case '5':
                        direction = 5; break;
                    case '6':
                        direction = 6; break;
                    case '7':
                        direction = 7; break;
                    case '8':
                        direction = 0; break;
                    case '9':
                        direction = 1; break;
                    case ' ':
                        direction = 4; break;
                    case '!':
                        direction = 5; break;
                    case ',':
                        direction = 6; break;
                    case '.':
                        direction = 7; break;
                    default:
                        direction = (ch - 'A' + 2) % 8; break;
                    #endregion
                }

                        newR = newR + dr[direction];
                        newC = newC + dc[direction];

                        if (InRange(newR, newC, n, m) && !matrix[newR, newC])
                        {
                            result += ((BigInteger) 1) << 2*(newR + newC);
                            matrix[newR, newC] = true;
                            
                        }
                        else if (InRange(newR, newC, n, m))
                        {
                            ;
                        }
                        else
                        {
                            break;
                        }

            }

            Console.WriteLine(result%1000007);

        }

        private static bool InRange(int newR, int newC, int n, int m)
        {
            if (newR < n && newR >= 0 && newC < m && newC >= 0)
            {
                return true;
            }
                return false;
        }
    }
}
