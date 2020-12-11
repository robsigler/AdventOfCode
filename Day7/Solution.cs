using System;
using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class Solution
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day7/input");
            Dictionary<string, HashSet<string>> rules = new Dictionary<string, HashSet<string>>();
            foreach (string line in lines) {
                string[] split = line.Split("contain ");
                string containingColorString = split[0];
                string[] containingColorStringSplit = containingColorString.Split(" ");
                string containingColor = containingColorStringSplit[0] + " " + containingColorStringSplit[1];
                string contentsString = split[1].Substring(0, split[1].Length-1);
                HashSet<string> contents = new HashSet<string>();
                if (contentsString.Equals("no other bags")) {
                    // Nothing to do
                } else {
                    string[] splitContents = contentsString.Split(", ");
                    foreach (string splitContent in splitContents) {
                        string[] words = splitContent.Split(" ");
                        int count = int.Parse(words[0]);
                        string color = words[1] + " " + words[2];
                        contents.Add(color);
                    }
                }
                rules.Add(containingColor, contents);
            }

            string desiredColor = "shiny gold";
            Console.WriteLine("How many different bag colors can contain " + desiredColor + "?");
            HashSet<string> differentColors = new HashSet<string>();

            // One run
            int newAdditions = 1;
            while (newAdditions != 0) {
                newAdditions = 0;
                foreach(KeyValuePair<string, HashSet<string>> entry in rules)
                {
                    foreach (string canContainColor in entry.Value) {
                        if (canContainColor.Equals(desiredColor) || differentColors.Contains(canContainColor)) {
                            if (!differentColors.Contains(entry.Key)) {
                                differentColors.Add(entry.Key);
                                newAdditions++;
                            }
                        }
                    }
                }
                Console.WriteLine("New additions found is " + newAdditions);
            }
            
            Console.WriteLine("Is it " + differentColors.Count);
        }

    }
}