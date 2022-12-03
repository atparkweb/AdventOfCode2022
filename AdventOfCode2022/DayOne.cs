﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class DayOne
    {
        public static int[] Run()
        {
            var sum = 0;
            var max = 0;
            List<int> totals = new List<int>();

            string[] lines = Utilities.GetLinesFromFile("d1.txt");

            foreach (var line in lines)
            {
                if (line == "")
                {
                    if (sum > max)
                    {
                        max = sum;
                    }

                    totals.Add(sum);
                    sum = 0;
                } else {
                    if (int.TryParse(line, out int amount))
                    {
                        sum += amount;
                    }
                    else
                    {
                        Console.WriteLine("Can't parse integer from line");
                    }
                }
            }

            totals.Sort();
            totals.Reverse();

            int[] result = new int[2];
            result[0] = max;

            int topThreeSum = totals.GetRange(0, 3).Sum();
            result[1] = topThreeSum;

            return result;
        }
    }
}