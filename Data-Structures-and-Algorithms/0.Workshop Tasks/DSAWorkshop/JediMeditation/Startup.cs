// Task description's at https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/tree/master/workshops/2015-10-30-data-structures/jedi-meditation
namespace JediMeditation
{
    using System;
    using System.Collections.Generic;

    public static class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var masters = new List<string>();
            var knights = new List<string>();
            var padawans = new List<string>();

            var allJedi = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allJedi.Length; i++)
            {
                var jedi = allJedi[i];

                var rank = jedi[0];

                if (rank == 'm')
                {
                    masters.Add(jedi);
                }
                else if (rank == 'k')
                {
                    knights.Add(jedi);
                }
                else
                {
                    padawans.Add(jedi);
                }
            }

            Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", padawans));
        }
    }
}
