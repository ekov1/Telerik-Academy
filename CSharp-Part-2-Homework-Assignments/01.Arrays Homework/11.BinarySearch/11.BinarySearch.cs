using System;
using System.Collections.Generic;

//Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the desireable size of the array: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Please fill in the elements of the array: ");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            Console.WriteLine("\nSorted array looks like this: " + string.Join(", ", arr) + "\n");
            Console.Write("Enter the integer whose index we are seeking: ");
            int key = int.Parse(Console.ReadLine());

            int iMax = n - 1;
            int iMin = 0;
            int iMid = n / 2;
            bool keyfound = false;

            while (iMax >= iMin)
            {
                iMid = (iMin + iMax) / 2;
                if (arr[iMid] == key)
                {
                    Console.WriteLine("Key = {0} found at index {1}\n", key, iMid);
                    keyfound = true;
                    break;
                }
                else if (arr[iMid] < key)
                {
                    iMin = iMid + 1;
                }
                else
                {
                    iMax = iMid - 1;
                }
            }

            if (!keyfound)
            {
                Console.WriteLine("Key = {0} not found!\nLo siento mucho, señor!\n"); 
            }
        }
    }

    /*  pseudo code found at wiki
     int binary_search(int A[], int key, int imin, int imax)
    {
      // continue searching while [imin,imax] is not empty
      while (imax >= imin)
        {
          // calculate the midpoint for roughly equal partition
          int imid = midpoint(imin, imax);
          if(A[imid] == key)
            // key found at index imid
            return imid; 
          // determine which subarray to search
          else if (A[imid] < key)
            // change min index to search upper subarray
            imin = imid + 1;
          else         
            // change max index to search lower subarray
            imax = imid - 1;
        }
      // key was not found
      return KEY_NOT_FOUND;
    }
     */
    //pseudo code found at wiki