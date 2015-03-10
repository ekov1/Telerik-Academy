using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace newBunnyFactory
{
    class newBunnyFactory
    {
        static void FakeInput()
        {
            StringReader reader = new StringReader(@"3
                                                     2
                                                     5
                                                     5
                                                     4
                                                     8
                                                     4
                                                     9
                                                     5
                                                     6
                                                     3
                                                     4
                                                     END
");

            Console.SetIn(reader);
        }

        static int s = 0;

        static void Main()
        {
            FakeInput();

            //read input
            var cages = new StringBuilder();
            int temp;
            string input = Console.ReadLine();
            List<BigInteger> tempCages = new List<BigInteger>();
            tempCages.Add(int.Parse(input));

            while (true)
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input, out temp))
                {
                    tempCages.Add(temp);
                }
                else
                {
                    break;
                }
            }


            cages = FirstCycle(tempCages);
            if (s < cages.Length)
            {
                cages.Replace("0", ""); //removes zeroes and ones from the first iteration
                cages.Replace("1", "");
            }


            int cycle = 2;

            //calculations
            while (true)
            {
                if (s > cages.Length)
                {
                    break;
                }

                s = 0;
                double bunnySum = 0;
                BigInteger bunnyProduct = 1;

                if (cycle > cages.Length)
                {
                    break;
                }

                for (int i = 0; i < cycle; i++)
                {
                    s += int.Parse(cages[i].ToString());
                }

                if (s > cages.Length)
                {
                    break;
                }

                cages.Remove(0, cycle); //removes the s cages



                for (int i = 0; i < s; i++)
                {
                    bunnySum += int.Parse(cages[i].ToString());
                    bunnyProduct *= BigInteger.Parse(cages[i].ToString());
                }
                cages.Remove(0, s); //removes the cages with the bunies that we calc'ed with
                cages.Insert(0, bunnyProduct);
                cages.Insert(0, bunnySum);

                cages.Replace("0", ""); //removes ones and zeroes
                cages.Replace("1", "");

                //set conditions when we break out of the process


                cycle++;
            }


            //print result
            for (int i = 0; i < cages.Length; i++)
            {
                if (i != cages.Length - 1)
                {
                    Console.Write(cages[i] + " ");
                }
                else
                {
                    Console.Write(cages[i]);
                }
            }
        }

        private static StringBuilder FirstCycle(List<BigInteger> tempCages)
        {

            s = 0;
            BigInteger bunnySum = 0;
            BigInteger bunnyProduct = 1;

            s = (int)tempCages[0];


            var strB = new StringBuilder();
            if (s > tempCages.Count)
            {
                tempCages.Reverse();
                foreach (int i in tempCages)
                {
                    strB.Insert(0, i);
                }

                return strB;
            }



            tempCages.Remove(s); //removes the s cages

            tempCages.Reverse();


            for (int i = 0; i < s; i++)
            {
                bunnySum += tempCages[tempCages.Count - 1 - i];
                bunnyProduct *= tempCages[tempCages.Count - 1 - i];
            }
            for (int i = 0; i < s; i++)
            {
                tempCages.RemoveAt(tempCages.Count - 1);
            }
            //removes the cages with the bunnies that we calc'ed with

            tempCages.Add(bunnyProduct);
            tempCages.Add(bunnySum);


            strB = new StringBuilder();
            foreach (BigInteger i in tempCages)
            {
                strB.Insert(0, i);
            }
            return strB;
        }
    }
}
