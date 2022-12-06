using System.Linq;

namespace AdventOfCode2022
{
    internal class DayFour : Solution
    {
        int dayNumber = 4;
        string[] lines = Utilities.GetLinesFromResource("d4");
        int result1 = 0;
        int result2 = 0;

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
                    result1++;
                    result2++;
                }

                if (!this.hasFullOverlap(sections) && this.hasOverlap(sections))
                {
                    result2++;
                }
            }

            int[] result = new int[2];
            result[0] = result1;
            result[1] = result2;

            base.Print(this.dayNumber, result);
        }

        bool hasFullOverlap(int[] sections)
        {
            return (sections[0] >= sections[2] && sections[1] <= sections[3])
                || (sections[2] >= sections[0] && sections[3] <= sections[1]);
        }

        bool hasOverlap(int[] sections)
        {
            return (sections[1] >= sections[2] && sections[1] <= sections[3])
                || (sections[3] >= sections[0] && sections[3] <= sections[1]);
        }
    }
}
