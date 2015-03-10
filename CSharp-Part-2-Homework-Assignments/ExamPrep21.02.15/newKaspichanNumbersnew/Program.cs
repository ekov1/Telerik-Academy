using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newKaspichanNumbersnew
{
    class Program
    {
        static void Main()
        {
            ulong input = ulong.Parse(Console.ReadLine());
            var result = new StringBuilder();

            string[] numeralSys = new string[256];

            for (int i = 0; i < 256; i++)
            {
                if (i < 26)
                {
                    numeralSys[i] = ((char)('A' + i)).ToString();
                }
                else if (i < 52)
                {
                    numeralSys[i] = "a" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 78)
                {
                    numeralSys[i] = "b" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 104)
                {
                    numeralSys[i] = "c" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 130)
                {
                    numeralSys[i] = "d" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 156)
                {
                    numeralSys[i] = "e" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 182)
                {
                    numeralSys[i] = "f" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 208)
                {
                    numeralSys[i] = "g" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 234)
                {
                    numeralSys[i] = "h" + ((char)('A' + i % 26)).ToString();
                }
                else if (i < 256)
                {
                    numeralSys[i] = "i" + ((char)('A' + i % 26)).ToString();
                }

            }
            if (input == 0)
            {
                Console.WriteLine("A");
            }
            else
            {

                while (input > 0)
                {
                    ulong remainder = input % 256;
                    result.Insert(0, numeralSys[remainder]);
                    input /= 256;
                }
                Console.WriteLine(result);
            }

        }
    }
}
