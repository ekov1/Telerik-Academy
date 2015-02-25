using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that parses an URL address given in the format:
//[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.

class Program
{
    static void Main()
    {
        Console.Write("Enter a valid URL address: ");
        string url = "https://telerikacademy.com/resources";
        Uri uri = new Uri(url);
        Console.WriteLine("[protocol]: " + uri.Scheme);
        Console.WriteLine("[server]: " + uri.Host);
        Console.WriteLine("[resources]: " + uri.LocalPath);
    }
}
