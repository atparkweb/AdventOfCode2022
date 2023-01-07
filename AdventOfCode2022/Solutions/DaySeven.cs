using AdventOfCode2022.Library;
using System.Text.RegularExpressions;
using System;

namespace AdventOfCode2022.Solutions
{
    internal class DaySeven : Solution
    {
        string[]? lines = Utilities.GetLinesFromResource("d7");
        int result = 0;
        Dictionary<string, int> directories = new Dictionary<string, int>();
        Stack<string> dirStack = new Stack<string>();

        public override void Run()
        {
            var maxDepth = 0;
            var currentDepth = 0;

            dirStack.Push("root");
            directories["root"] = 0;

            foreach (var line in lines)
            {
                if (line.Contains("$ cd"))
                {
                    if (line.Contains("$ cd .."))
                    {
                        dirStack.Pop();
                        currentDepth = Math.Max(0, currentDepth - 1);
                    }
                    else if (line.Contains("$ cd /"))
                    {
                        while (dirStack.Count > 1)
                        {
                            dirStack.Pop();
                        }
                        currentDepth = 0;
                    }
                    else
                    {
                        var dirName = line.Split(" ")[2];
                        dirStack.Push(dirName);
                        
                        currentDepth += 1;
                        maxDepth = Math.Max(maxDepth, currentDepth);

                        var currentPath = string.Join("/", dirStack.ToArray());

                        if (!directories.ContainsKey(currentPath))
                        {
                            directories.Add(currentPath, 0);
                        }
                    }
                }
                else if (Regex.IsMatch(line, "^[0-9]+ .*$"))
                {
                    var size = int.Parse(line.Split(" ")[0]);
                    var currentPath = string.Join("/", dirStack.ToArray());
                    directories[currentPath] += size;
                }
            }

            currentDepth = maxDepth;
            while (currentDepth > 0)
            {
                foreach (var key in directories.Keys)
                {
                    Stack<string> pathArray = new Stack<string>(key.Split('/'));
                    if (pathArray.Count == currentDepth)
                    {
                        int size = directories[key];
                        pathArray.Pop();
                        string parent = string.Join('/', pathArray.ToArray());
                        if (directories.ContainsKey(parent))
                        {
                            directories[parent] += size;
                        }
                    }
                }
                currentDepth -= 1;
            }

            int MAX_DIR_SIZE = 100000;
            foreach (var key in directories.Keys)
            {
                int size = directories[key];
                if (size <= MAX_DIR_SIZE)
                {
                    result += size;
                }
            }

            int[] results = new int[2];
            results[0] = result;
            results[1] = 0;

            Print(7, results);
        }
    }
}
