using System.Security.Cryptography;
using AdventOfCode2022.Library;

namespace AdventOfCode2022.Solutions
{
    internal class DayThree : Solution
    {
        int dayNumber = 3;
        string[] lines = Utilities.GetLinesFromResource("d3");
        int sum = 0;
        int groupSum = 0;

        override public void Run()
        {
            for (var i = 0; i < lines.Length; i++)
            {
                Dictionary<char, int> contentsMap = new Dictionary<char, int>();
                string line = lines[i];

                for (var j = 0; j < line.Length; j++)
                {
                    if (j < line.Length / 2) // the first half of the line
                    {
                        if (contentsMap.ContainsKey(line[j]))
                        {
                            contentsMap[line[j]] += 1;
                        }
                        else
                        {
                            contentsMap[line[j]] = 1;
                        }
                    }
                    else // the second half of the line
                    {
                        if (contentsMap.ContainsKey(line[j]))
                        {
                            sum += getPriority(line[j]);
                            break;
                        }
                    }
                }

                // for every group of three lines
                if (i > 0 && (i + 1) % 3 == 0)
                {
                    var chars = lines[i].Intersect(lines[i - 1]).Intersect(lines[i - 2]);
                    foreach (var c in chars)
                    {
                        groupSum += getPriority(c);
                    }
                }
            }

            int[] result = new int[2];
            result[0] = sum;
            result[1] = groupSum;
            Print(dayNumber, result);
        }

        private static int getPriority(char letter)
        {
            var uppercaseOffset = 38;
            var lowercaseOffset = 96;

            if (letter - lowercaseOffset < 0)
            {
                return letter - uppercaseOffset;
            }
            else
            {
                return letter - lowercaseOffset;
            }
        }
    }
}
