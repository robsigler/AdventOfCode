using System;
using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class Solution2
    {
        public struct ColoredBags
        {
            public ColoredBags(string color, int count)
            {
                this.color = color;
                this.count = count;
            }
            public string color { get; }
            public int count { get; }
        }

        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day7/input");
            var rules = new Dictionary<string, List<ColoredBags>>();
            foreach (string line in lines) {
                string[] split = line.Split("contain ");
                string containingColorString = split[0];
                string[] containingColorStringSplit = containingColorString.Split(" ");
                string containingColor = containingColorStringSplit[0] + " " + containingColorStringSplit[1];
                string contentsString = split[1].Substring(0, split[1].Length-1);
                var contents = new List<ColoredBags>();
                if (contentsString.Equals("no other bags")) {
                    // Nothing to do
                } else {
                    string[] splitContents = contentsString.Split(", ");
                    foreach (string splitContent in splitContents) {
                        string[] words = splitContent.Split(" ");
                        int count = int.Parse(words[0]);
                        string color = words[1] + " " + words[2];
                        contents.Add(new ColoredBags(color, count));
                    }
                }
                rules.Add(containingColor, contents);
            }

            string desiredColor = "shiny gold";
            var currentInventory = new List<string>();
            currentInventory.Add(desiredColor);
            int bagCount = 0;
            while (currentInventory.Count > 0) {
                var coloredBagsList = rules[currentInventory[0]];
                currentInventory.RemoveAt(0);
                bagCount++;

                foreach (var coloredBags in coloredBagsList) {
                    for (int i=0; i<coloredBags.count; i++) {
                        currentInventory.Add(coloredBags.color);
                    }
                }
            }
            Console.WriteLine(bagCount-1);
        }
    }
}