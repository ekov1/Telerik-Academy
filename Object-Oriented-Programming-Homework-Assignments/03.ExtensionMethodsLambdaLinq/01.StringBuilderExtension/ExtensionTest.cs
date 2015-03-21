using System;
using System.Text;

namespace _01.StringBuilderExtension
{
    class ExtensionTest
    {
        static void Main()
        {
            var sb = new StringBuilder();
            sb.Append("This is a test, not a text, but a test!");
            var ssb = sb.Substring(6, 10);
            Console.WriteLine(ssb);

            bool test1 = sb.Substring(2, 1).ToString().Equals("i"); // This is true.
            Console.WriteLine(test1);

        }
    }
}
