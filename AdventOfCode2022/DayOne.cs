namespace AdventOfCode2022
{
    internal class DayOne : Solution
    {
        int dayNumber = 1;
        string[] lines = Utilities.GetLinesFromResource("d1");
        int sum = 0;
        int max = 0;

        override public void Run()
        {
            List<int> totals = new List<int>();

            foreach (var line in this.lines)
            {
                if (line == "")
                {
                    if (this.sum > this.max)
                    {
                        this.max = this.sum;
                    }

                    totals.Add(this.sum);
                    this.sum = 0;
                } else {
                    if (int.TryParse(line, out int amount))
                    {
                        this.sum += amount;
                    }
                    else
                    {
                        Console.WriteLine("Can't parse integer from line");
                    }
                }
            }

            int[] result = new int[2];
            result[0] = this.max;

            totals.Sort();
            totals.Reverse();
            int topThreeSum = totals.Take(3).Sum();
            result[1] = topThreeSum;

            base.Print(this.dayNumber, result);
        }
    }
}
