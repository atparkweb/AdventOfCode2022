using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Utilities
    {
        static string GetInputPath(string file)
        {
            return @"C:\\Users\\atpark333\\source\\repos\\AdventOfCode2022\\AdventOfCode2022\\input\\" + file;
        }

        public static string[] GetLinesFromFile(string file)
        {
            string path = GetInputPath(file);
            return File.ReadAllLines(path);
        }
    }
}
