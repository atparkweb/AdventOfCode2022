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
            foreach (var line in lines)
            {
                if (line.Contains("$ cd"))
                {
                    if (line.Contains("$ cd .."))
                    {
                        dirStack.Pop();
                    }
                    else if (line.Contains("$ cd /"))
                    {
                        while (dirStack.Count > 0)
                        {
                            dirStack.Pop();
                        }
                    }
                    else
                    {
                        var dirName = line.Split(" ")[2];
                        dirStack.Push(dirName);

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

            foreach (var key in directories.Keys)
            {
                Console.WriteLine(directories[key].ToString());
            }
        }
    }
}
