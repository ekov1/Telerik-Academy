using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter the file name whose content you wish to read (please enter full path (e.g. C:\\WINDOWS\\win.ini)).\nFile path: ");
            string path = Console.ReadLine();

            try
            {
                string readFile = System.IO.File.ReadAllText(path);
                Console.WriteLine("File content: ");
                Console.WriteLine(readFile);

            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("No such file or directory, please specify a correct path!");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No such file or directory, please specify a correct path!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied, please try with another directory/file!");
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("Please make sure that the input is in the correct format (e.g. C:\\WINDOWS\\win.ini)!");
            }
            finally
            {
                Console.Write("Press a key to continue...");
                Console.ReadLine();
            }
            Console.Clear();
        }
    }
}
