namespace OperationsWithQueue
{
    using System;
    using System.Collections.Generic;

    public static class Startup
    {
        public static void Main()
        {
            var operations = new List<Func<int, int>>
            {
                x => x + 1,
                x => x + 2,
                x => x * 2
            };

            var n = 3;
            var m = 15;

            var q = new Queue<int>();

        }
    }
}
