using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class KukataIsDancing
    {
        static void Main(string[] args)
        {
            int dances = int.Parse(Console.ReadLine());
            string[,] cube = { {"RED", "BLUE", "RED"},
                               {"BLUE", "GREEN", "BLUE"},
                               {"RED", "BLUE", "RED"}};

            int[][] directions = { new int[]{0, 1}, //right 
                                   new int[]{-1, 0},//up
                                   new int[]{0, -1},//left
                                   new int[]{1, 0}};//down


            for (int i = 0; i < dances; i++)
            {
                int[] pos = { 1, 1 };
                int dirIndex = 0;
                int[] dir = directions[dirIndex];
                string moves = Console.ReadLine();

                foreach (char command in moves)
                {
                    switch (command)
                    {
                        case 'W':
                            pos = Walk(pos, dir);
                            RotateFloorAndValidate(cube, pos);
                            break;

                        case 'R':

                            dirIndex = TurnRight(directions, dirIndex);
                            dir = directions[dirIndex];
                            break;

                        case 'L':
                            dirIndex = TurnLeft(directions, dirIndex);
                            dir = directions[dirIndex];
                            break;
                    }
                }
                Console.WriteLine(cube[pos[0], pos[1]]);
            }
        }

        private static void RotateFloorAndValidate(string[,] cube, int[] pos)
        {
            if (pos[0] >= cube.GetLength(0))
            {
                pos[0] = 0;
            }
            else if (pos[0] < 0)
            {
                pos[0] = cube.GetLength(0) - 1;
            }
            else if (pos[1] >= cube.GetLength(1))
            {
                pos[1] = 0;
            }
            else if (pos[1] < 0)
            {
                pos[1] = cube.GetLength(1) - 1;
            }
            //for (int j = 0; j < pos.Length; j++) //ALTERNATIVE
            //{
            //    if (pos[j] >= cube.GetLength(j))
            //    {
            //        pos[j] = 0;
            //    }
            //    else if (pos[j] < 0)
            //    {
            //        pos[j = cube.GetLength(j) - 1;
            //    }
            //}
        }

        private static int TurnLeft(int[][] directions, int dirIndex)
        {
            dirIndex += 1;
            if (dirIndex >= directions.GetLength(0))
            {
                dirIndex = 0;
            }
            return dirIndex;
        }

        private static int TurnRight(int[][] directions, int dirIndex)
        {
            dirIndex -= 1;
            if (dirIndex < 0)
            {
                dirIndex = directions.GetLength(0) - 1;
            }
            return dirIndex;
        }


        private static int[] Walk(int[] pos, int[] dir)
        {
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                pos[i] += dir[i];
            }
            return pos;
        }
    }
}
