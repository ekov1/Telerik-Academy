using System;
using System.IO;
using System.Text;

//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters.
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter 
//of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

class Program
{

    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("Enter text:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter key(cipher):");
        string key = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            sb.Append((char)(input[i] ^ key[i % key.Length]));
        }

        Console.WriteLine("Enciphered text: " + sb);
    }
 }

