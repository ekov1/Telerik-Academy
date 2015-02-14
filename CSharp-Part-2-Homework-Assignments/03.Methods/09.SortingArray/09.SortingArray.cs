using System;
using System.Collections.Generic;

//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

class Program
{
    static void Main()
    {

        int[] arr = { 3, 2, 7, 7,61, 17, 81, 22, 61,
                      68, 52, 64, 32, 67, 38, 48, 58,
                      45, 2, -1, 13, 21, 52, 11, 32,
                      61,-34,-2,0,-17,6,8, 2, 1, 9,
                      6, 4, 17, 33, -19, -5, -1, -1,
                      -12, 5, 21, 21, 17, 3, 88, 6, 51,
                      53, -1, 2, 66, 90, 42, 43, 33}; //Feel free to edit the array with custom values

        Console.WriteLine("Array elements: ");
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine(new string('-', 40));

        Console.Write("Please enter the index from which the array expands onward: ");
        int index = int.Parse(Console.ReadLine());


        Console.WriteLine("Maximal value that exists after or at the provided index is: " + MaxFromSelectIndex(arr, index));
        Console.WriteLine("\nArray elements sorted in ascending order: ");
        AscendingSort(arr);
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\nArray elements sorted in descending order: ");
        DescendingSort(arr);
        Console.WriteLine(new string('-', 40));

    }

    private static int MaxFromSelectIndex(int[] arr, int index)
    {
        int currentMax = int.MinValue;

        for (int i = index; i < arr.Length; i++)
        {
            if (currentMax<arr[i])
            {
                currentMax = arr[i];
            }
        }

        return currentMax;
    }

    private static void AscendingSort(int[] arr)
    {
        Array.Sort(arr);

        Console.WriteLine(string.Join(", ", arr));
    }
    private static void DescendingSort(int[] arr)
    {
        Array.Sort(arr, (x, y) => y.CompareTo(x));

        Console.WriteLine(string.Join(", ", arr));
    }
}

