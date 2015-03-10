using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelevanceIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string subString = Console.ReadLine();
            int L = int.Parse(Console.ReadLine());
            string[] paragraph = new string[L];
            int[] indexes = new int[L];


            for (int i = 0; i < L; i++)
            {
                paragraph[i] = Console.ReadLine();
            }

        }
    }
}
