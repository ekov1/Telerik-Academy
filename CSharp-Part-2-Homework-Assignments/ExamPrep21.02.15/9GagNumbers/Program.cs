using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO://TODO:
namespace _9GagNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var sb = new StringBuilder();
            ulong num = 0;
            ulong power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);

                switch (sb.ToString())
                {
                    case "-!":    num += (ulong)Math.Pow(0, power);sb.Clear();break;       
                    case "**":    num += (ulong)Math.Pow(1, power);sb.Clear();break;
                    case "!!!":   num += (ulong)Math.Pow(2, power);sb.Clear(); break;
                    case "&&":    num += (ulong)Math.Pow(3, power);sb.Clear();break;
                    case "&-":    num += (ulong)Math.Pow(4, power);sb.Clear();break;
                    case "!-":    num += (ulong)Math.Pow(5, power);sb.Clear(); break;
                    case "*!!!":  num += (ulong)Math.Pow(6, power);sb.Clear(); break;
                    case "&*!":   num += (ulong)Math.Pow(7, power);sb.Clear(); break;
                    case "!!**!-":num += (ulong)Math.Pow(8, power);sb.Clear(); break;
                    default: break;
                }
            }


        }
    }
}
