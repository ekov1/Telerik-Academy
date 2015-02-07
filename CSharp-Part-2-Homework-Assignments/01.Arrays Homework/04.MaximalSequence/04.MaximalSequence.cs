using System;

//Write a program that finds the maximal sequence of equal elements in an array.

class Program
{
    static void Main()
    {
        int[] arr = { 1, 1, 1, 3, 4, 5, 5, 5, 5, 5, 3, 3, 4, 3, 3 };  //The longest sequence of equal chars is 5 of 5s.
                    // Alternative array { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

        int frequency = 1;
        int longestSequence = 0;
        int numberOfLongestSequence = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                frequency = 1;
            }
            else
            {
                ++frequency;
                if (frequency > longestSequence)
                {
                    longestSequence = frequency;
                    numberOfLongestSequence = arr[i];
                }
            }
        }

        Console.WriteLine("The length of the longest sequence of equal elements is: " + longestSequence);
        Console.WriteLine(numberOfLongestSequence);
    }
}
 
