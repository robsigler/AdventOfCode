using System;
using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class Solution
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day6/input");

            List<HashSet<char>> groups = new List<HashSet<char>>();
            {
                HashSet<char> group = new HashSet<char>();
                foreach (string line in lines) {
                    if (line.Equals("")) {
                        groups.Add(group);
                        group = new HashSet<char>();
                    } else {
                        foreach (char question in line) {
                            group.Add(question);
                        }
                    }
                }
                if (group.Count > 0) {
                    groups.Add(group);
                }
            }
            int sum = 0;
            foreach (HashSet<char> group in groups) {
                sum += group.Count;
            }
            Console.WriteLine("Counted a sum of " + sum);
        }

    }
}