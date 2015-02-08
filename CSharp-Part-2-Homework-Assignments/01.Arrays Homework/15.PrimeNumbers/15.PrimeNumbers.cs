using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

class Program
{
    static void Main()
    {
        
        long length = 10000000;
        bool[] prime = new bool[length];
        var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        var fullFileName = Path.Combine(desktopFolder, "primeNumbers.txt");
        StreamWriter primes = new StreamWriter(fullFileName);

        for (int i = 2; i < length; i++)
        {
            prime[i] = true;
        }

        for (int i = 2; i < length; i++)
        {
            if (prime[i] == true)
            {
                for (int j = 2; (j * i) < length; j++)
                {
                    prime[i * j] = false;
                }
            }
        }
        using (primes)
        {
            for (int i = 0; i < length; i++)
            {
                if (prime[i])
                {
                    primes.Write("{0}, ", i);
                }
            }
        }
        Console.WriteLine("Primes found using the Sieve of Eratosthenes algorithm.\n" + new string('-', 40));
        Console.WriteLine("The full list of prime numbers 2 to 9999991 has been generated on your desktop as a text file {0}", fullFileName);
        

        /*
        List<int> sieve = new List<int>(); //ALTERNATIVE, AND RATHER SLOW METHOD FOR FINDING PRIMES

        for (int i = 2; i <= 100000; i++)
        {
            sieve.Add(i); //fills the list with the numbers 1 to 10 millions (100 thousand in this case)
        }
        Console.WriteLine("Primes found using the Sieve of Eratosthenes algorithm.\n" + new string('-', 40));
        var sb = new StringBuilder();

        for (int i = 2; i < Math.Sqrt(sieve.Count); i++)
        {
            for (int j = 2; j < sieve.Count; j++)
            {

                sieve.Remove(i * j);
                if (!sieve.Contains(i))
                {
                    break;
                }
            }
        }

        foreach (int prime in sieve)
        {
            sb.Append(prime).Append(", ");
        }
        Console.WriteLine(sb);
        */
    }
}
