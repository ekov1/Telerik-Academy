using System;
using System.Collections.Generic;

//Write a program that sorts an array of strings using the Quick sort algorithm.

class Program
{
    static public int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        while (true)
        {
            while (arr[left] < pivot)
                left++;

            while (arr[right] > pivot)
                right--;

            if (arr[right] == pivot && arr[left] == pivot)
            {
                left++;
            }

            if (left < right)
            {
                int temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    static public void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                QuickSort(arr, left, pivot - 1);
            }

            if (pivot + 1 < right)
            {
                QuickSort(arr, pivot + 1, right);
            }
        }
    }

    static void Main()
    {
        int[] arr = { 3, 8, 7, 5, 2, -1, 13, 21, 2, 1, 9, 6, 4, 17, 33, -19, -5, -1, -1, -12 }; //Feel free to edit the array with custom values
        Console.WriteLine("Array before QuickSort\n" + new string('-', 40) + "\n" + string.Join(", ", arr));
        QuickSort(arr, 0, arr.Length - 1);
        Console.WriteLine("\nArray after QuickSort Method\n" + new string('-', 40) + "\n" + string.Join(", ", arr) + "\n\n");
    }
}
