using System;
using System.Collections.Generic;

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

    class Program
    {
        static void Main()
        {
            List<int> sieve = new List<int>();

            for (int i = 1; i <= 10000; i++)
            {
                sieve.Add(i); //fills the list with the numbers from 1 to 10 millions (10 thousand in this case)
            }
            Console.WriteLine("Primes found using the Sieve of Eratosthenes algorithm.\n" + new string('-', 40));
            for (int i = 2; i < sieve.Capacity; i++)
            {
                for (int j = 2; j < sieve.Capacity; j++)
                {

                    sieve.Remove(i * j);
                    if (!sieve.Contains(i))
                    {
                        break;
                    }
                }
                //Console.Write("{0}, ", i);
            }

            foreach (int prime in sieve)
            {
                Console.Write("{0}, ", prime);
            }
        }
    }
