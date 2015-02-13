using System;
using System.Collections.Generic;

//You are given an array of strings. Write a method that sorts the array by the 
//length of its elements (the number of characters composing them).

class Program
{
    static void Main()
    {
        string[] stringArr = { "You", "are", "given", "an", "array", "of", "strings.", "Write a method", "that sorts", "the array by the" };
        Array.Sort(stringArr, (x, y) => x.Length.CompareTo(y.Length));
        foreach (var item in stringArr)
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
    }
}

