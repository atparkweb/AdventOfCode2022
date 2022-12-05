using System.Security.Cryptography;

namespace AdventOfCode2022
{
    internal class DayThree
    {
        public static int[] Run()
        {
            var sum = 0;
            var groupSum = 0;

            string[] lines = Utilities.GetLinesFromResource("d3");

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
                            sum += DayThree.getPriority(line[j]);
                            break;
                        }
                    }
                }

                // for every group of three lines
                if (i > 0 && (i + 1) % 3 == 0)
                {
                    var chars = lines[i].Intersect(lines[i - 1]).Intersect(lines[i - 2]);
                    foreach (var c in chars) {
                        groupSum += DayThree.getPriority(c);
                    }
                } 
            }

            int[] result = new int[2];
            result[0] = sum;
            result[1] = groupSum;
            return result;
        }

        private static int getPriority(char letter)
        {
            var uppercaseOffset = 38;
            var lowercaseOffset = 96;

            if ((int)letter - lowercaseOffset < 0)
            {
                return (int)letter - uppercaseOffset;
            } else
            {
                return (int)letter - lowercaseOffset;
            }
        }
    }
}
