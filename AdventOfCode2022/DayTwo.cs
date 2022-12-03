namespace AdventOfCode2022
{
    internal class DayTwo
    {
        public static int[] Run()
        {
            string[] lines = Utilities.GetLinesFromResource("d2");

            Dictionary<string, int> inputMap1 = new Dictionary<string, int>();
            inputMap1["A X"] = 4; // Rock Rock         Draw
            inputMap1["A Y"] = 8; // Rock Paper        Win
            inputMap1["A Z"] = 3; // Rock Scissors     Loss
            inputMap1["B X"] = 1; // Paper Rock        Loss
            inputMap1["B Y"] = 5; // Paper Paper       Draw
            inputMap1["B Z"] = 9; // Paper Scissors    Win
            inputMap1["C X"] = 7; // Scissors Rock     Win
            inputMap1["C Y"] = 2; // Scissors Paper    Loss
            inputMap1["C Z"] = 6; // Scissors Scissors Draw

            Dictionary<string, int> inputMap2 = new Dictionary<string, int>();
            inputMap2["A X"] = 3; // Rock Scissors     Loss
            inputMap2["A Y"] = 4; // Rock Rock         Draw
            inputMap2["A Z"] = 8; // Rock Paper        Win
            inputMap2["B X"] = 1; // Paper Rock        Loss
            inputMap2["B Y"] = 5; // Paper Paper       Draw
            inputMap2["B Z"] = 9; // Paper Scissors    Win
            inputMap2["C X"] = 2; // Scissors Paper    Loss
            inputMap2["C Y"] = 6; // Scissors Scissors Draw
            inputMap2["C Z"] = 7; // Scissors Rock     Win

            int totalScore1 = 0;
            int totalScore2 = 0;
            foreach (var line in lines)
            {
                totalScore1 += inputMap1[line];
                totalScore2 += inputMap2[line];
            }

            int[] result = new int[2];
            result[0] = totalScore1;
            result[1] = totalScore2;

            return result;
        }
    }
}
