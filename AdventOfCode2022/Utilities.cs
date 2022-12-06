using AdventOfCode2022.Properties;

namespace AdventOfCode2022
{
    internal class Utilities
    {
        public static string[] GetLinesFromResource(string file)
        {
            try
            {
                string? contents = Resources.ResourceManager.GetString(file);
                if (contents == null)
                {
                    throw new ArgumentNullException(nameof(file));
                }
                return contents.Split(System.Environment.NewLine);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Invalid resource reference: {ex}");
                return new string[0];
            }
        }
    }
}
