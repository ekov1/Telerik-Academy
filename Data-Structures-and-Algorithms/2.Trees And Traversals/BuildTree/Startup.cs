namespace BuildTree
{
    using Tree;
    using Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            @"7  
2 4
3 2
5 0
3 5
5 6
5 1".CopyStringToClipboard();
            Console.WriteLine("Sample input copied to clipboard. Right-Click to paste...\n\r");

            BuildTreeNodes();
        }

        private static void BuildTreeNodes()
        {
            var childrenList = new List<int>();
            var parentsList = new List<int>();
            var nodeDict = new Dictionary<int, IGraphNode<int>>();

            var n = int.Parse(Console.ReadLine()) - 1;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var parent = int.Parse(input[0]);
                var child = int.Parse(input[1]);

                parentsList.Add(parent);
                childrenList.Add(child);

                if (!nodeDict.ContainsKey(parent))
                {
                    nodeDict.Add(parent, new Tree<int>(parent));
                }
                
                if (!nodeDict.ContainsKey(child))
                {
                    nodeDict.Add(child, new Tree<int>(child));
                }

                nodeDict[parent].AddChild(nodeDict[child]);
            }
            
            var root = parentsList.Except(childrenList).ToList();

            Console.WriteLine("Root node: " + string.Join(" ", root));

            var k = parentsList.Intersect(childrenList).ToList();

            Console.WriteLine("All middle nodes: " + string.Join(", ", k));

            var leaves = childrenList.Except(parentsList);

            Console.WriteLine("All leaf nodes: " + string.Join(", ", leaves));

            var tree = nodeDict[root[0]];
        }
    }
}