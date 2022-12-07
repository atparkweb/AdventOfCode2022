using System.Text.RegularExpressions;
using AdventOfCode2022.Library;

namespace AdventOfCode2022.Solutions
{
    internal class DayFive : Solution
    {
        string result1 = "";
        string result2 = "";
        string instructionPattern = @"^move ([0-9]{1,2}) from ([1-9]) to ([1-9])$";

        // FIX: This is a lazy hack. Should read and build stacks from input data
        Stack<char>[] stacks = {
            new Stack<char>(new List<char> {'Z', 'J', 'G'}),
            new Stack<char>(new List<char> { 'Q', 'L', 'R', 'P', 'W', 'F', 'V', 'C' }),
            new Stack<char>(new List<char> { 'F', 'P', 'M', 'C', 'L', 'G', 'R' }),
            new Stack<char>(new List<char> { 'L', 'F', 'B', 'W', 'P', 'H', 'M' }),
            new Stack<char>(new List<char> { 'G', 'C', 'F', 'S', 'V', 'Q' }),
            new Stack<char>(new List<char> { 'W', 'H', 'J', 'Z', 'M', 'Q', 'T', 'L' }),
            new Stack<char>(new List<char> { 'H', 'F', 'S', 'B', 'V' }),
            new Stack<char>(new List<char> { 'F', 'J', 'Z', 'S' }),
            new Stack<char>(new List<char> { 'M', 'C', 'D', 'P', 'F', 'H', 'B', 'T' })
        };

        string[]? lines = Utilities.GetLinesFromResource("d5");

        public override void Run()
        {
            if (lines == null) return;

            for (var i = 10; i < lines.Length; i++)
            {
                var line = lines[i];
                Match match = Regex.Match(line, instructionPattern);
                if (match.Success)
                {
                    int moveCount = int.Parse(match.Groups[1].Value);
                    int fromColumn = int.Parse(match.Groups[2].Value) - 1;
                    int toColumn = int.Parse(match.Groups[3].Value) - 1;
                    moveAll(moveCount, fromColumn, toColumn);
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
            }
            List<char> tops = new List<char>();

            foreach (Stack<char> stack in stacks)
            {
                if (stack.Count > 0)
                {
                    result1 += stack.Peek();
                }
            }

            string[] result = new string[2];
            result[0] = result1;
            result[1] = result2;

            Print(5, result);
        }

        private void move(int count, int fromColumn, int toColumn)
        {
            var i = 0;
            while (i < count)
            {
                if (stacks[fromColumn].Count > 0)
                {
                    stacks[toColumn].Push(stacks[fromColumn].Pop());
                }
                i++;
            }
        }

        private void moveAll(int count, int fromColumn, int toColumn)
        {
            Stack<char> tempStack = new Stack<char>();
            var i = 0;

            while (i < count)
            {
                if (stacks[fromColumn].Count > 0)
                {
                    tempStack.Push(stacks[fromColumn].Pop());
                }
                i++;
            }
            i = 0;
            while (i < count)
            {
                if (tempStack.Count > 0)
                {
                    stacks[toColumn].Push(tempStack.Pop());
                }
                i++;
            }
        }
    }
}
