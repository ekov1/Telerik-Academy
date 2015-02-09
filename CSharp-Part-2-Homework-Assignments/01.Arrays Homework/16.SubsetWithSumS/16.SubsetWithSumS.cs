using System;
using System.Collections.Generic;

//We are given an array of integers and a number S.
//Write a program to find if there exists a subset of the elements of the array that has a sum S.

//http://www.careercup.com/question?id=12899672 is where I found the algorithm used in the Combine method

class Program
{

    public static void Combine(int[] arr, List<int> outstr, int index, int sum)
    {

        for (int i = index; i < arr.Length; i++)
        {

            int count = 0;
            foreach (int item in outstr) //calculates the sum of all items currently in the list
                count += item;

            if ((arr[i] + count) == sum)
            {
                foreach (int item in outstr)
                {
                    Console.Write("{0} + ", item);
                }

                Console.Write("{0} = {1}", arr[i], sum);
                Console.WriteLine();
            }

            outstr.Add(arr[i]);
            Combine(arr, outstr, i + 1, sum); //adds elements from arr[i] to a list and checks each time if they sum up, if not, adds the next element
            outstr.Remove(arr[i]);
        }

    }


    static void Main()
    {
        int[] arr = { -1, -4, -2, 2, 1, 2, 3, 5, 2, 6 }; //feel free to adjust array elements as you see fit!
        Console.Write("Enter the number S(um) for which we will be checking if a subset exists: ");
        int S = int.Parse(Console.ReadLine());
        Console.WriteLine("\nAll possible subsets that sum up to " + S + "\n" + new string('-', 40) + "\n");
        Combine(arr, new List<int>(), 0, S);
        Console.WriteLine();

    }
}

