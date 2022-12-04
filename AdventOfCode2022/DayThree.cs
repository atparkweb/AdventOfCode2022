namespace AdventOfCode2022
{
    internal class DayThree
    {
        public static int[] Run()
        {
            var sum = 0;

            string[] lines = Utilities.GetLinesFromResource("d3");

            foreach (string line in lines)
            {
                Dictionary<char, int> contentsMap = new Dictionary<char, int>();

                int lineLength = line.Length;
                int i = 0;

                while (i < lineLength / 2)
                {
                    if (contentsMap.ContainsKey(line[i]))
                    {
                        contentsMap[line[i]] += 1;
                    }
                    else
                    {
                        contentsMap[line[i]] = 1;
                    }
                    i++;
                }

                while (i < lineLength)
                {
                    if (contentsMap.ContainsKey(line[i]))
                    {
                        sum += DayThree.getPriority(line[i]);
                        break;
                    }
                    i++;
                }
            }

            int[] result = new int[2];
            result[0] = sum;
            result[1] = 0;
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
