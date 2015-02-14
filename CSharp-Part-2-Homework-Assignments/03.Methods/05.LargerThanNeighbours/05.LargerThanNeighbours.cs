using System;
using System.Collections.Generic;

//Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).

    class Program
    {
        static void Main()
        {
            int[] arr = { 3, 8, 7, 5, 2, -1, 13, 21, 2, 1, 9, 6, 4, 17, 33, -19, -5, -1, -1, -12, 5, 21, 21, 17, 3, -1, 2 }; //Feel free to edit the array with custom values

            Console.WriteLine("Array elements: ");
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(new string('-', 40));
            Console.Write("Please enter the index of the element that you will be comparing with neighbouring elements: ");
            int index = int.Parse(Console.ReadLine());
            int len = arr.Length;
            Console.WriteLine();
            CompareWithNeighbouringElements(arr, index, len);

        }

        private static void CompareWithNeighbouringElements(int[] arr, int index, int length)
        {
            if (IsFirstOrLast(index, length))
            {
                Console.WriteLine("You have provided the index of either the first or last index of the array, therefore we cannot compare both neighbouring elements. Program terminating...\n");
            }
            else
            {
                if (arr[index] > arr[index-1] && arr[index] > arr [index+1])
                {
                    Console.WriteLine("The element at the provided index {0} is greater than both neighbouring elements!\n", index);
                }
                else if (arr[index] > arr[index-1] && arr[index] < arr [index+1])
                {
                    Console.WriteLine("The element at the provided index {0} is greater than the element before, but lesser than the following element!\n", index);
                }
                else if (arr[index] < arr[index - 1] && arr[index] > arr[index + 1])
                {
                    Console.WriteLine("The element at the provided index {0} is greater than the following element, but lesser than the previous element!\n", index);
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
