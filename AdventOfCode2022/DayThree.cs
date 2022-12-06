using System.Security.Cryptography;

namespace AdventOfCode2022
{
    internal class DayThree : Solution
    {
        int dayNumber = 3;
        string[] lines = Utilities.GetLinesFromResource("d3");
        int sum = 0;
        int groupSum = 0;

        override public void Run()
        {
            for (var i = 0; i < this.lines.Length; i++)
            {
                Dictionary<char, int> contentsMap = new Dictionary<char, int>();
                string line = this.lines[i];

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
                            this.sum += DayThree.getPriority(line[j]);
                            break;
                        }
                    }
                }

                // for every group of three lines
                if (i > 0 && (i + 1) % 3 == 0)
                {
                    var chars = this.lines[i].Intersect(this.lines[i - 1]).Intersect(this.lines[i - 2]);
                    foreach (var c in chars) {
                        this.groupSum += DayThree.getPriority(c);
                    }
                } 
            }

            int[] result = new int[2];
            result[0] = this.sum;
            result[1] = this.groupSum;
            base.Print(this.dayNumber, result);
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
