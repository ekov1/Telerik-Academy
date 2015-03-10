using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Laser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            int cuboidW = int.Parse(line[0]);
            int cuboidH = int.Parse(line[1]);
            int cuboidD = int.Parse(line[2]);

            bool[, ,] cube = new bool[cuboidW, cuboidH, cuboidD];
            


        }
    }
}
