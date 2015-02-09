using System;
using System.Collections.Generic;

//Write a program that sorts an array of integers using the Merge sort algorithm.

class Program
{
    private static int[] MergeSort(int[] arr)
    {
        if (arr.Length == 1)
        {
            return arr;
        }

        int middle = arr.Length / 2;
        int[] left = new int[middle];
        int[] right = new int[arr.Length - middle];

        for (int i = 0; i < arr.Length; i++)
	    {
            if (i < middle)
            {
                left[i] = arr[i];
            }
            else
            {
                right[i - middle] = arr[i];
            }
		}

        left = MergeSort(left);
        right = MergeSort(right);
        
        return Merge(left, right);
    }

    private static int[] Merge(int[] left, int[] right)
    {
        int i, j;
        int[] result = new int[left.Length + right.Length];
        for (i = 0, j = 0; i < left.Length && j < right.Length; )
        {
            if (left[i] < right[j])
            {
                result[i+j] = left[i];
                i++;
            }
            else
            {
                result[i+j] = right[j];
                j++;
            }
        }

        for (; i < left.Length;)
        {
            result[i + j] = left[i];
            i++;
        }

        for (; j < right.Length;)
        {
            result[i + j] = right[j];
            j++;
        }

        return result;
    }



    static void Main()
    {
        int[] arr = { 12, 6, 3, -1, 4, 6, 1, 5, 3, 8, 7, 2, 9 };
        Console.WriteLine("Array before Merge Sort\n" + new string('-', 40) + "\n" + string.Join(", ", arr));
        arr = MergeSort(arr);
        Console.WriteLine("\nArray after Merge Sort\n" + new string('-', 40) + "\n" + string.Join(", ", arr) + "\n\n");
    }
}
