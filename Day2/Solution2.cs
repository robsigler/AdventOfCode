using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    public class Solution2
    {
        public static void Solve(string[] args)
        {
            List<string> validPasswords = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"Day2/input");
            foreach (string line in lines) {
                string[] words = line.Split(" ");
                string policyRange = words[0];
                string[] splitPolicyRange = policyRange.Split("-");

                int firstIndex = int.Parse(splitPolicyRange[0])-1;
                int secondIndex = int.Parse(splitPolicyRange[1])-1;

                string password = words[2];
                string letterWithColon = words[1];
                char policyLetter = letterWithColon[0];

                bool firstIndexMatch = false;
                if ((firstIndex) < password.Length) {
                    firstIndexMatch = (policyLetter == password[firstIndex]);
                }

                bool secondIndexMatch = false;
                if ((secondIndex) < password.Length) {
                    secondIndexMatch = (policyLetter == password[secondIndex]);
                }

                if (firstIndexMatch ^ secondIndexMatch) {
                    validPasswords.Add(line);
                }
            }
            Console.WriteLine(validPasswords.Count);
        }
    }
}

