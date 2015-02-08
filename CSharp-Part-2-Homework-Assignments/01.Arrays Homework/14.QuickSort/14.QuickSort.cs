using System;
using System.Collections.Generic;

//Write a program that sorts an array of strings using the Quick sort algorithm.

class Program
{
    static public int Partition(int[] numbers, int left, int right)
    {
        int pivot = numbers[left];
        while (true)
        {
            while (numbers[left] < pivot)
                left++;

            while (numbers[right] > pivot)
                right--;

            if (numbers[right] == pivot && numbers[left] == pivot)
            {
                left++;
            }

            if (left < right)
            {
                int temp = numbers[right];
                numbers[right] = numbers[left];
                numbers[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    static public void QuickSort_Recursive(int[] arr, int left, int right)
    {
        // For Recusrion
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
                QuickSort_Recursive(arr, left, pivot - 1);

            if (pivot + 1 < right)
                QuickSort_Recursive(arr, pivot + 1, right);
        }
    }

    static void Main(string[] args)
    {
        int[] numbers = { 3, 8, 7, 5, 2, -1, 13, 21, 2, 1, 9, 6, 4, 17, 33, -19, -5, -1, -1, -12 }; //Feel free to edit the array with custom values
        int len = numbers.Length;
        Console.WriteLine("Current array order, before QuickSort: " + string.Join(", ", numbers));
        Console.WriteLine();
        Console.WriteLine("Array after QuickSort - Recursive Method");
        QuickSort_Recursive(numbers, 0, len - 1);
        for (int i = 0; i < numbers.Length; i++)
            Console.WriteLine(numbers[i]);

        Console.WriteLine();

    }
}
