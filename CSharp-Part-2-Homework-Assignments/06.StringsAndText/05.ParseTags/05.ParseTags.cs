using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.
//The tags cannot be nested.
//Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.

//The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

class Program
{
    static void Main()
    {
        Console.Write("String that will be analyzed.\nInput: ");
        string input = Console.ReadLine();

        var sb = new StringBuilder();

        while (input.IndexOf("<upcase>") != -1)
        {
            int inTags = input.IndexOf("<upcase>");
            int outTags = input.IndexOf("</upcase>");
            string upper = input.Substring(inTags + "<upcase>".Length, outTags - inTags - "<upcase>".Length);
            input = input.Replace("<upcase>" + upper + "</upcase>", upper.ToUpper());
        }

        Console.WriteLine();
        Console.WriteLine(input);
    }
}
