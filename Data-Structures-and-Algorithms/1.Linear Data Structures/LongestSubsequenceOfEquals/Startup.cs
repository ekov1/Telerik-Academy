namespace LongestSubsequenceOfEquals
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
                2, 3, 2, 2, 2, 5, 6, 6, 6, 6, 6, 7, 6, 5, 3, 3, 2, 3, 3, 3, 3, 3
            };

            var sequenceList = GetLongestSequenceOfEqualNumbers(intList).ToList();

            Console.WriteLine("{0} occured {1} times in a sequence!", sequenceList[0], sequenceList.Count);
        }

        public static IEnumerable<int> GetLongestSequenceOfEqualNumbers(IList<int> list)
        {
            int currentPopularNumber;
            int sequenceCount = 0;
            int longestSequence = 0;
            int mostPopularNumber = list[0];

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] != list[i + 1])
                {
                    sequenceCount = 0;
                }

                sequenceCount++;
                currentPopularNumber = list[i];

                if (sequenceCount > longestSequence)
                {
                    longestSequence = sequenceCount;
                    mostPopularNumber = currentPopularNumber;
                }
            }

            return Enumerable.Repeat(mostPopularNumber, longestSequence);
        }
    }
}
