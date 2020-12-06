using System;
using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class Solution2
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day6/input");

            List<HashSet<char>> groups = new List<HashSet<char>>();
            {
                Dictionary<char, int> answers = new Dictionary<char, int>();
                int groupMembers = 0;
                foreach (string line in lines) {
                    if (line.Equals("")) {
                        groups.Add(FindAllYes(answers, groupMembers));
                        answers = new Dictionary<char, int>();
                        groupMembers = 0;
                    } else {
                        groupMembers++;
                        foreach (char question in line) {
                            if (answers.ContainsKey(question)) {
                                answers[question] = answers[question] + 1;
                            } else {
                                answers[question] = 1;
                            }
                        }
                    }
                }
                if (groupMembers > 0) {
                    groups.Add(FindAllYes(answers, groupMembers));
                }
            }
            int sum = 0;
            foreach (HashSet<char> group in groups) {
                sum += group.Count;
            }
            Console.WriteLine("Counted a sum of " + sum);
        }

        public static HashSet<char> FindAllYes(Dictionary<char, int> answers, int groupSize) {
            HashSet<char> group = new HashSet<char>();
            foreach(KeyValuePair<char, int> entry in answers)
            {
                if (entry.Value == groupSize) {
                    group.Add(entry.Key);
                }
            }
            return group;
        }
    }
}