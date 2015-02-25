using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slides
{
    class Program
    {
        static void Main(string[] args)
        {
            //read dimensions
            string[] line = Console.ReadLine().Split(' ');
            int cuboidWidth = int.Parse(line[0]);
            int cuboidHeight = int.Parse(line[1]);
            int cuboidDepth = int.Parse(line[2]);

            //read cuboid
            string[, ,] cuboid = new string[cuboidWidth, cuboidHeight, cuboidDepth];
            for (int h = 0; h < cuboidHeight; h++)
            {
                string[] row = Console.ReadLine().Split('|');
                for (int d = 0; d < cuboidDepth; d++)
                {
                    string[] cubes = row[d].Trim().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < cuboidWidth; w++)
                    {
                        string cube = cubes[w];
                        cuboid[w, h, d] = cube;
                    }
                }
            }



            //read ball
            line = Console.ReadLine().Split(' ');
            int ballWidth = int.Parse(line[0]);
            int ballHeight = 0;
            int ballDepth = int.Parse(line[1]);

            //ball falling through
            int nextWidth = ballWidth;
            int nextHeight = ballHeight;
            int nextDepth = ballDepth;
            bool canFallThrough = true;
            string currentCube = "";

            while (canFallThrough)
            {
                if (nextHeight == cuboidHeight)
                {
                    break;
                }
                ballWidth = nextWidth;
                ballHeight = nextHeight;
                ballDepth = nextDepth;

                currentCube = cuboid[nextWidth, nextHeight, nextDepth];
                //switch case for commands S X; T 1 1; B; E

                char command = currentCube[0];
                switch (command)
                {
                    case 'B': canFallThrough = false; break;
                    case 'E': nextHeight++; break;
                    case 'T': int[] coord = currentCube.Substring(2).Split(' ').Select(x => int.Parse(x)).ToArray();
                        nextWidth = coord[0];
                        nextDepth = coord[1];
                        break;
                    case 'S': nextHeight++;
                        string direction = currentCube.Substring(2);
                        switch (direction)
                        {
                            case "L": nextWidth--; break;
                            case "R": nextWidth++; break;
                            case "F": nextDepth--; break;
                            case "B": nextDepth++; break;
                            case "FR": nextWidth++; nextDepth--; break;  
                            case "BL": nextWidth--; nextDepth++; break;  
                            case "FL": nextWidth--; nextDepth--; break;  
                            case "BR": nextWidth++; nextDepth++; break;  
                        }

                        if (nextWidth < 0 || nextWidth > cuboidWidth - 1 || nextDepth < 0 || nextDepth > cuboidDepth - 1)
                        {
                            canFallThrough = false;
                            break;
                        }

                        break;
                }
            }

            //output
            Console.WriteLine(canFallThrough ? "Yes" : "No");
            Console.WriteLine("{2} {1} {1}", ballWidth, ballHeight, ballDepth);

        }
    }
}
