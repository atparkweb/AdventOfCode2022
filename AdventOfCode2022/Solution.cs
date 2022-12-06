namespace AdventOfCode2022
{
    internal abstract class Solution
    {
        public abstract void Run();

        protected void Print(int dayNumber, int[] result)
        {
            Console.WriteLine($"Day {dayNumber}a: {result[0]}");
            Console.WriteLine($"Day {dayNumber}b: {result[1]}");
        }
    }
}
