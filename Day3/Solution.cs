using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public class Solution
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day3/input");

            int treesEncountered = 0;
            for (int i=0; i<lines.Length; i++) {
                string terrainLine = lines[i];
                int indexToCheckForTree = 3 * i;
                while (terrainLine.Length <= indexToCheckForTree) {
                    terrainLine = terrainLine + terrainLine;
                }
                Console.WriteLine(terrainLine);
                if (terrainLine[indexToCheckForTree] == '#') {
                    treesEncountered++;
                }
            }
            Console.WriteLine(treesEncountered + " trees encountered.");
        }
    }
}

