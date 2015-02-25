using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
//Example:

//input	output
//<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>	
//<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

class Program
{
    static void Main()
    {
        Console.WriteLine("Please input formatted text: ");
        string input = Console.ReadLine();

        string patternOpenTag = @"<a*\s\bhref*=[""]";
        string patternCloseTag = @"[""]>";
        string patternCloseAllTags = @"</a>";
        //string replaceWith = @"[URL=" + @"]";

        string result = Regex.Replace(input, patternOpenTag, "[URL=");
        string newResult = Regex.Replace(result, patternCloseTag, "]");
        string finalResult = Regex.Replace(newResult, patternCloseAllTags, "[/URL]");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(finalResult);
    }
}
