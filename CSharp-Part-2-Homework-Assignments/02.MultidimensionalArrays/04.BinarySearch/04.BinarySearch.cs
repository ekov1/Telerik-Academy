using System;
using System.Collections.Generic;

//Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.

class Program
{
    static void Main()
    {
        Console.Write("Please define the size of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Please enter the value of the K parameter: ");
        int k = int.Parse(Console.ReadLine());

        Array.Sort(arr);

        int largestNumber = Array.BinarySearch(arr, k);

        if (largestNumber >= 0)
        {
            Console.WriteLine("Element at index [{0}] of the sorted array = {1}\n", largestNumber, arr[largestNumber]);
        }
        while (largestNumber < 0)
        {
            k--;
            largestNumber = Array.BinarySearch(arr, k);
        }
        Console.WriteLine("Element that is closest to or equal to parameter K is {0} at position {1} of the sorted array! \n", arr[largestNumber], largestNumber);


    }
}
