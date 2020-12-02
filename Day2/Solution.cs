using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    public class Solution
    {
        public static void Solve(string[] args)
        {
            List<string> validPasswords = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"Day2/input");
            foreach (string line in lines) {
                string[] words = line.Split(" ");
                string policyRange = words[0];
                string[] splitPolicyRange = policyRange.Split("-");
                int minCount = int.Parse(splitPolicyRange[0]);
                int maxCount = int.Parse(splitPolicyRange[1]);
                string password = words[2];
                string letterWithColon = words[1];
                char policyLetter = letterWithColon[0];
                int policyLetterCount = 0;
                foreach (char letter in password) {
                    if (letter == policyLetter) {
                        policyLetterCount++;
                    }
                }
                if ((policyLetterCount >= minCount) && (policyLetterCount <= maxCount)) {
                    validPasswords.Add(line);
                }
            }
            Console.WriteLine(validPasswords.Count);
        }
    }
}

