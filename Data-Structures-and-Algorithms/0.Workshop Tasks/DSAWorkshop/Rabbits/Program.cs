using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbits = Console.ReadLine().Split(' ').Where(x => x != "-1").Select(int.Parse).ToArray();
            var groups = rabbits.GroupBy(x => x).ToList();

            double i = 0;

            foreach (var @group in groups)
            {
                var groupCount = group.Count();

                var distinctColors = Math.Ceiling((double) groupCount/(group.Key+1));

                i += distinctColors*(group.Key+1);
            }

            Console.WriteLine(i);
        }
    }
}
