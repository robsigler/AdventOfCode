using System;

namespace AdventOfCode.Day1
{
    public class Solution
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day1/input");
            for (int i = 0; i < lines.Length; i++) {
                for (int j = i+1; j < lines.Length; j++) {
                    int iLine = int.Parse(lines[i]);
                    int jLine = int.Parse(lines[j]);
                    Console.WriteLine(iLine + " + " + jLine + " = 2020?");
                    if ((iLine+jLine) == 2020) {
                        Console.WriteLine("Found it!!");
                        Console.WriteLine(iLine + " * " + jLine + " = " + (iLine * jLine));
                        return;
                    }
                }
            }
        }
    }
}

