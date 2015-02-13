using System;
using System.Collections.Generic;

//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.

class Program
{
    static void Main()
    {
        int[] arr = { 3, 8, 7, 5, 2, -1, 13, 21, 2, 1, 9, 6, 4, 17, 33, -19, -5, -1, -1, -12, 5, 21, 21, 17, 3, -1, 2 }; //Feel free to edit the array with custom values
        Console.WriteLine("Array elements: ");
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine(new string('-', 40));
        Console.Write("Enter the value whose frequency we will be checking: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("There are " + CheckFrequency(arr, k) + " occurences of the number " + k);

    }

    private static int CheckFrequency(int[] arr, int k)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (k == arr[i])
            {
                count++;
            }
        }
        return count;
    }
}
