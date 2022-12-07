using AdventOfCode2022.Library;

namespace AdventOfCode2022.Solutions
{
    internal class DayOne : Solution
    {
        int dayNumber = 1;
        string[]? lines = Utilities.GetLinesFromResource("d1");
        int sum = 0;
        int max = 0;

        override public void Run()
        {
            if (lines == null) return;

            List<int> totals = new List<int>();

            foreach (var line in lines)
            {
                if (line == "")
                {
                    if (sum > max)
                    {
                        max = sum;
                    }

                    totals.Add(sum);
                    sum = 0;
                }
                else
                {
                    if (int.TryParse(line, out int amount))
                    {
                        sum += amount;
                    }
                    else
                    {
                        Console.WriteLine("Can't parse integer from line");
                    }
                }
            }

            int[] result = new int[2];
            result[0] = max;

            totals.Sort();
            totals.Reverse();
            int topThreeSum = totals.Take(3).Sum();
            result[1] = topThreeSum;

            Print(dayNumber, result);
        }
    }
}
