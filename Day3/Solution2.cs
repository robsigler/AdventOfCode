using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public class Solution2
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day3/input");

            int answer = ForSlope(lines,1,1)*ForSlope(lines,3,1)*ForSlope(lines,5,1)*ForSlope(lines,7,1)*ForSlope(lines,1,2);
            Console.WriteLine("Final answer is " + answer);
        }

        public static int ForSlope(string[] lines, int right, int down) {
            int treesEncountered = 0;
            for (int i=0; i<lines.Length; i=i+down) {
                string terrainLine = lines[i];
                int indexToCheckForTree = right * (i / down);
                while (terrainLine.Length <= indexToCheckForTree) {
                    terrainLine = terrainLine + terrainLine;
                }
                if (terrainLine[indexToCheckForTree] == '#') {
                    treesEncountered++;
                }
            }
            return treesEncountered;
        }
    }
}

