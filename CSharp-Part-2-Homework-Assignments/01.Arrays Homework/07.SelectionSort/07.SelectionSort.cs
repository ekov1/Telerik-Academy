using System;
using System.Collections.Generic;

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
//Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the 
//smallest from the rest, move it at the second position, etc.

class Program
{
    static void Main()
    {
        int[] arr = { 64, 25, 12, 22, 11 }; //feel free to test for other values
        //int[] copyArr = arr; 
        int[] copyArr = new int[arr.Length];
        Array.Copy(arr, copyArr, arr.Length);
        int min;

        for (int i = 0; i < arr.Length-1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    int b = arr[i];
                    arr[i] = arr[j];
                    arr[j] = b;
                }
            }
        }
        


        Console.WriteLine();

        Console.Write("Initial array order: ");
        for (int i = 0; i < arr.Length; i++)
        {

            Console.Write("{0} ", copyArr[i]);
        }
        Console.WriteLine();

        Console.Write("Reordered array (selection sort): ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }
}

 