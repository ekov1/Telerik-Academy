using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

class Program
{
    static void Main()
    {
        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile("https://telerikacademy.com/Content/Images/news-img01.png", "../../logo.jpg");
                Console.WriteLine("Download - complete!");
                Console.WriteLine("The picture is saved at {0}.", Directory.GetCurrentDirectory());
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (WebException e)
            {
                Console.Error.WriteLine(e.Message);
            }

            catch (NotSupportedException e)
            {
                Console.Error.WriteLine(e.Message);
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }


        }
    }
}
