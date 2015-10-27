namespace RemoveNegativesFromSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        public static void Main()
        {
            var intList = new List<int>
            {
                -2, 3, 2, 2, 2, 5, -6, 6, 6, -6, 6, -7, 6, 5, 3, -3, 2, -3, 3, 3, 3, -3, 6
            };

            Console.WriteLine(string.Join(", ", intList.Where(x => x > 0)));
        }
    }
}
