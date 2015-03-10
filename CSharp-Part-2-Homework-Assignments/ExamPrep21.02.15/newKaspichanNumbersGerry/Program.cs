using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newKaspichanNumbersGerry
{
    class Program
    {
        static void Main(string[] args)
        {
            var listStr = new List<string>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                listStr.Add(i.ToString());
            }

            for (char i = 'a'; i <= 'i'; i++)
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                    listStr.Add(i.ToString()+j.ToString());
                }
            }
        }
    }
}
