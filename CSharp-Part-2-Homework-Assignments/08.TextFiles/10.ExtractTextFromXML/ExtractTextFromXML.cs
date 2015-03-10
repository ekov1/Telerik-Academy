
//    Write a program that extracts from given XML file all the text without the tags.

//Example:

//<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3">
//<interest>Games</interest><interest>C#</interest><interest>Java</interest></interests></student>
using System;
using System.Xml;
class ExtractTextFromXML
{
    static void Main()
    {
        XmlDocument x = new XmlDocument();
        x.Load(@"..\..\sample.xml");
        PrintNode(x.DocumentElement);
    }

    private static void PrintNode(XmlNode x)
    {
        if (!x.HasChildNodes)
            Console.Write(string.Format("{0} ", x.InnerText));

        for (int i = 0; i < x.ChildNodes.Count; i++)
        {
            PrintNode(x.ChildNodes[i]);
        }
    }
}
