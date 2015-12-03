using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketQueue
{
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main(string[] args)
        {
            var bag = new BigList<string>();
            var namesCount = new Dictionary<string, int>();
            var sb = new StringBuilder();
            var isExecuting = true;

            while (isExecuting)
            {
                var input = Console.ReadLine().Split(' ').ToArray();

                switch (input[0])
                {
                    case "Append":
                        var name = input[1];
                        bag.Add(name);

                        if (!namesCount.ContainsKey(name))
                        {
                            namesCount.Add(name, 0);
                        }

                        namesCount[name] += 1;
                        sb.AppendLine("OK");
                        break;
                    case "Serve":
                        var count = int.Parse(input[1]);
                        if (count > bag.Count)
                        {
                            sb.AppendLine("Error");
                        }
                        else
                        {
                            var namesSb = new StringBuilder();
                            for (int i = 0; i < count; i++)
                            {
                                namesSb.Append(bag[i] + " ");
                                namesCount[bag[i]] -= 1;
                            }

                            bag.RemoveRange(0, count);

                            sb.AppendLine(namesSb.ToString().Trim());
                        }

                        break;
                    case "Insert":
                        var pos = int.Parse(input[1]);
                        var insertName = input[2];

                        if (pos < 0 || pos > bag.Count)
                        {
                            sb.AppendLine("Error");
                        }
                        else
                        {
                            bag.Insert(pos, insertName);
                            sb.AppendLine("OK");

                            if (!namesCount.ContainsKey(insertName))
                            {
                                namesCount.Add(insertName, 0);
                            }

                            namesCount[insertName] += 1;
                        }

                        break;
                    case "Find":
                        if (!namesCount.ContainsKey(input[1]))
                        {
                            sb.AppendLine(0.ToString());
                        }
                        else
                        {
                            sb.AppendLine(namesCount[input[1]].ToString());
                        }
                        break;
                    case "End":
                        isExecuting = false;
                        break;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
