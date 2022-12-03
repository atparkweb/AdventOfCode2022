namespace AdventOfCode2022
{
    internal class DayOne
    {
        public static int[] Run()
        {
            var sum = 0;
            var max = 0;
            List<int> totals = new List<int>();

            string[] lines = Utilities.GetLinesFromResource("d1");

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
                } else {
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

            return result;
        }
    }
}
