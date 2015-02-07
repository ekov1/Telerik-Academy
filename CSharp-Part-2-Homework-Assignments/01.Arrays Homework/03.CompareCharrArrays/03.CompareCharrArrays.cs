using System;

//Write a program that compares two char arrays lexicographically (letter by letter).

class Program
{
    static void Main()
    {
        bool areEqual = true;
        Console.Write("Enter the size of your first char array!: ");
        int n = int.Parse(Console.ReadLine());

        char[] array1 = new char[n];
        for (int i = 0; i < array1.Length; i++)
        {
            Console.Write("Enter a character: ");
            array1[i] = Convert.ToChar(Console.ReadLine());
        }

        Console.Write("Enter the size of your second char array!: ");
        n = int.Parse(Console.ReadLine());

        char[] array2 = new char[n];
        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write("Enter a character: ");
            array2[i] = Convert.ToChar(Console.ReadLine());
        }
        
        if (array1.Length != array2.Length)
        {
            Console.WriteLine("The arrays cannot be equal because they are of different length!");
        }
        else
        {
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] == array2[i])
                {
                    Console.WriteLine("For element {0} in array1 and element {0} in array2 = {1} and {2}, the elements are equal!", i, array1[i], array2[i]);
                }
                else
                {
                    Console.WriteLine("For element {0} in array1 and element {0} in array2 = {1} and {2}, the elements are not equal!", i, array1[i], array2[i]);
                    areEqual = false;
                }
            }
        }
        if (areEqual)
        {
            Console.WriteLine("The arrays are equal!");
        }
        else
        {
            Console.WriteLine("The arrays are not equal!");
        }
    }
}
 