using System;

namespace AdventOfCode.Day1
{
    public class Solution2
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day1/input");
            for (int i = 0; i < lines.Length; i++) {
                for (int j = i+1; j < lines.Length; j++) {
                    for (int k = j+1; k < lines.Length; k++) {
                        int iLine = int.Parse(lines[i]);
                        int jLine = int.Parse(lines[j]);
                        int kLine = int.Parse(lines[k]);
                        if ((iLine+jLine+kLine) == 2020) {
                            Console.WriteLine("Found it!!");
                            Console.WriteLine(iLine * jLine * kLine);
                            return;
                        }
                    }
                }
            }
        }
    }
}

