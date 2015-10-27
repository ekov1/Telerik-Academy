namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        public static void Main()
        {
            var intList = new List<int> { 4, 2, 2, 5, 2, 1, 3, 2, 3, 1, 5, 2 };

            var intDictionary = new Dictionary<int, int>();

            // The following is of complexity 2*n and preserves the original order
            for (int i = 0; i < intList.Count; i++)
            {
                var currentElement = intList[i];

                if (!intDictionary.ContainsKey(currentElement))
                {
                    intDictionary.Add(currentElement, 1);
                }
                else
                {
                    intDictionary[currentElement]++;
                }
            }

            var newIntList = new List<int>();

            for (int i = 0; i < intList.Count; i++)
            {
                var currentElement = intList[i];

                if (intDictionary[currentElement] % 2 == 0)
                {
                    newIntList.Add(currentElement);
                }
            }

            Console.WriteLine(string.Join(", ", newIntList));

            // alternative -> does not preserve the original order
            var list = intList.GroupBy(x => x).Where(group => group.Count() % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", list.Select(x => string.Join(", ", x))));
        }
    }
}
