using System;

//Write a program that finds the maximal increasing sequence in an array.
            //                Example:
            //        input	             result
            //3, 2, 3, 4, 2, 2, 4	    2, 3, 4

    class Program
    {
        static void Main()
        {
            int[] arr = { 3, 2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 4, 5, 6, 7, 8, 9, 10, 11 };  //The longest increasing sequence is 4, 5, 6, 7, 8, 9, 10, 11 - a sequence of 8 numbers

            int sequence = 1;
            int longestSequence = 0;
            int lastNumber = 0;
            int startedASequence = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1]+1)
                {
                    ++sequence;
                    startedASequence = 1;
                    if (sequence > longestSequence)
                    {
                        longestSequence = sequence;
                        if (startedASequence == 1)
                        {
                            lastNumber = arr[i];
                            startedASequence = 0;
                        }
                    }
                }
                else
                {
                    sequence = 1;
                    startedASequence = 0;
                }
            }
            for (int i = 1; i <= longestSequence; i++)
            {
                Console.Write(lastNumber-longestSequence+i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The length of the longest increasing sequence of numbers is: " + longestSequence);
            Console.WriteLine();
        }
    }
