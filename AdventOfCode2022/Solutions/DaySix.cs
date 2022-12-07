using AdventOfCode2022.Library;

namespace AdventOfCode2022.Solutions
{
    internal class DaySix : Solution
    {
        string[]? lines = Utilities.GetLinesFromResource("d6");
        int result1 = 0;
        int result2 = 0;
        const int targetLength = 14;

        public override void Run()
        {
            if (lines == null) return;

            char[] letters = lines[0].ToCharArray();
            int left = 0;
            int right = targetLength - 1;
            bool startFound = false;
            while (!startFound && right < letters.Length)
            {
                HashSet<char> charSet = new HashSet<char>();
                for (var i = left; i <= right; i++)
                {
                    charSet.Add(letters[i]);
                }

                if (charSet.Count == targetLength)
                {
                    startFound = true;
                }
                else
                {
                    left += 1;
                    right += 1;
                }
            }

            if (!startFound)
            {
                throw new Exception("Start of packet not found.");
            }

            result1 = right + 1;
            int[] result = new int[2];
            result[0] = result1;
            result[1] = result2;

            Print(6, result);
        }
    }
}
