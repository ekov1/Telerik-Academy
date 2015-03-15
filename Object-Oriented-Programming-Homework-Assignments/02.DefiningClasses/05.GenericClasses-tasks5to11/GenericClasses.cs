using System;
using System.Linq;


namespace _05.GenericClasses_tasks5to7
{
    class GenericClasses
    {
        static void Main()
        {

            var testArray = new GenericList<int>(10); //we are obliged to pass the initial capacity of the list

            for (int i = 0; i < 10; i++) //adds 10 elements to the array
            {
                testArray.Add(i);
            }

            testArray.Insert(0, 15); //inserts an element with value 15 at index 0 of the list, the list doubles its capacity

            foreach (var item in testArray) //due to the implementation of IEnumerable we are able to print the GenericList with a foreach loop
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            testArray.Clear(); //we clear the GenericList and now it holds nothing, Count is reset to 0, Capacity stays the same

            foreach (var item in testArray) //nothing will print as there are no elements present
            {
                Console.WriteLine(item);
            }

            testArray.Add(7);
            testArray.Add(4);
            testArray.Add(5);

            foreach (var item in testArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            testArray.Insert(2, 61); //inserts 61 at index 2 (where 5 currently is)
            Console.WriteLine();

            foreach (var item in testArray) 
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            testArray.Remove(1); //removes the element at index 1 (4)
            Console.WriteLine();

            foreach (var item in testArray)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\nIndex of '7' = " + testArray.IndexOf(7)); //returns the index of 7
            Console.WriteLine("\nElement with max value = " + testArray.Max());
            Console.WriteLine("\nElement with min value = " + testArray.Min());

            Console.WriteLine("\nPrint the List: " + testArray.ToString()+"\n");
        }
    }
}
