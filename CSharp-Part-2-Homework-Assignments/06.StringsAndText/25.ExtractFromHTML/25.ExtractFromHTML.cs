using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
//Example input:

//<html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skilful .NET software engineers.</p></body>
//</html>
//Output:

//Title: News

//Text: Telerik Academy aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.

class Program
{
    static void Main()
    {
        Console.WriteLine("Please input formatted text: ");
        string input = Console.ReadLine();

        foreach (Match item in Regex.Matches(input, "(?<=^|>)[^><]+?(?=<|$)"))
        {
            Console.WriteLine(item);
        }
    }
}
