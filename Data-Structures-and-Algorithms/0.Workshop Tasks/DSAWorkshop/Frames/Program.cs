using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        private static HashSet<string> sb = new HashSet<string>();

        static void Main(string[] args)
        {
            var numOfFrames = int.Parse(Console.ReadLine());

            var frames = new int[numOfFrames][];
            var usedFrames = new bool[numOfFrames];
            var result = new List<int[]>();

            for (int i = 0; i < numOfFrames; i++)
            {
                var setting = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                frames[i] = new int[2];
                frames[i][0] = setting[0];
                frames[i][1] = setting[1];
                frames[i] = frames[i].OrderBy(x => x).ToArray();
            }

            frames = frames.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();

            //GeneratePermutations(frames, 0);

            Permute(frames, result, usedFrames, 0);

            Console.WriteLine(sb.Count);
            Console.WriteLine(string.Join(Environment.NewLine, sb));
        }

        static void Permute(int[][] arr, List<int[]> res, bool[] used, int k)
        {
            if (k >= used.Length)
            {
                Print(res);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;


                    res.Add(arr[i]);

                    Permute(arr, res, used, k + 1);

                    res.RemoveAt(res.Count - 1);


                    if (arr[i][0] != arr[i][1])
                    {
                        res.Add(new int[]{arr[i][1], arr[i][0]});
                    Permute(arr, res, used, k + 1);

                        res.RemoveAt(res.Count - 1);
                    }

                    used[i] = false;
                }
            }
        }

        static void Print(List<int[]> arr)
        {
            var tempSb = new StringBuilder();
            for (int i = 0; i < arr.Count; i++)
            {
                tempSb.AppendFormat("({0}, {1}) | ", arr[i][0], arr[i][1]);
            }

            sb.Add(tempSb.ToString().Trim(' ', '|'));
        }
    }
}
