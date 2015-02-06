using System;

//Write a program that reads two integer arrays from the console and compares them element by element.

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of your arrays!: ");
        int n = int.Parse(Console.ReadLine());

        int[] array1 = new int[n];
        int[] array2 = new int[n];
        bool areEqual = true;

        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write("Enter the value of element {0} of array1: ", i);
            array1[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write("Enter the value of element {0} of array2: ", i);
            array2[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write("Elements {0} from array1 and array2 are ", i);
            if (array1[i] != array2[i])
            {
                Console.Write("not the same.");
                Console.WriteLine();
                areEqual = false;
            }
            else
            {
                Console.Write("the same.");
                Console.WriteLine();
            }
        }
        if (areEqual)
        {
            Console.WriteLine("Therefore both arrays are considered equal");
        }
        else
        {
            Console.WriteLine("Therefore both arrays are considered unequal");
        }
    }
}

