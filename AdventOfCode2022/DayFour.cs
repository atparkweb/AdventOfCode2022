using System.Linq;

namespace AdventOfCode2022
{
    internal class DayFour : Solution
    {
        int dayNumber = 4;
        string[] lines = Utilities.GetLinesFromResource("d4");
        int count = 0;

        override public void Run()
        {
            foreach (string line in lines)
            {
                int[] sections = line.Split('-', ',')
                    .ToList()
                    .ConvertAll<int>(s => int.Parse(s))
                    .ToArray();
                if (this.hasFullOverlap(sections))
                {
                    count++;
                }
            }

            int[] result = new int[2];
            result[0] = count;
            result[1] = 0;

            base.Print(this.dayNumber, result);
        }

        bool hasFullOverlap(int[] sections)
        {
            return (sections[0] >= sections[2] && sections[1] <= sections[3])
                || (sections[2] >= sections[0] && sections[3] <= sections[1]);
        }
    }
}
