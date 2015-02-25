using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    class KaspichanNumbers
    {
        static void Main(string[] args)
        {
            //create an array of all digit sequences (256 elements).
            ulong numBase = 256;
            string[] arr = new string[numBase];
            for (int i = 0; i < (int)numBase; i++) //can be extracted into a method
            {
                if (i < 26)
                {
                    arr[i] = string.Format("{0}", (char)(i + 'A'));
                }
                else //initiates after the initial filling of just 1 letter 
                {
                    arr[i] = string.Format("{0}{1}", (char)(i/ 26 - 1 + 'a'),
                                                     (char)(i % 26 + 'A'));
                }
            }

            
            //read input
            ulong input = ulong.Parse(Console.ReadLine());

            //calculations
            string result = string.Empty;

            if (input == 0)
            {
                result = "A";
            }

            else
            {
                while (input > 0)
                {
                    ulong remainder = input % numBase;
                    result = arr[remainder] + result;
                    input /= numBase;
                }
            }
            //output
            Console.WriteLine(result); 
        }
    }
}
