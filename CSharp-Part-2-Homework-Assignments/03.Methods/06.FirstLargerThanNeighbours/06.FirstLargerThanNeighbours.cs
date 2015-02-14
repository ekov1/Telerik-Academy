using System;
using System.Collections.Generic;

//Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
//Use the method from the previous exercise.

class Program
{
    static void Main()
    {
        int[] arr = { 3, 2, 7, 7, 2, -1, 13, 21, 52,
                      61,-34,-2,0,-17,6,8, 2, 1, 9,
                      6, 4, 17, 33, -19, -5, -1, -1,
                      -12, 5, 21, 21, 17, 3, -1, 2 }; //Feel free to edit the array with custom values

        Console.WriteLine("Array elements: ");
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine(new string('-', 40));
        int len = arr.Length;
        Console.WriteLine();
        int index;
        for (index = 0; index < len; index++)
        {
            if (CompareWithNeighbouringElements(arr, index, len) == 0) break;
        }
       
    }

    private static int CompareWithNeighbouringElements(int[] arr, int index, int length)
    {
        if (IsFirstOrLast(index, length))
        {
            return -1;
        }
        else
        {
            if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
            {
                Console.WriteLine("The element at index {0} is the first occurence where an element is greater than both its neighbouring elements!\n", index);
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }



    private static bool IsFirstOrLast(int index, int length)
    {
        if (index == 0 || index == length - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
