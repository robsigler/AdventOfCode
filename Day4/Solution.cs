using System;
using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    public class Solution
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day4/input");

            List<string> passports = new List<string>();

            {
                string passport = "";
                foreach (string line in lines) {
                    if (line.Equals("")) {
                        passports.Add(passport);
                        passport = "";
                    } else {
                        if (passport.Equals("")) {
                            passport = line;
                        } else {
                            passport = passport + " " + line;
                        }
                    }
                }
                if (!passport.Equals("")) {
                    passports.Add(passport);
                }
            }

            string[] requiredFields = new [] {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
                // "cid",
            };

            int validPassports = 0;
            foreach (string passport in passports) {
                Console.WriteLine(passport);
                Dictionary<string, string> passportDict = new Dictionary<string, string>();
                string[] pieces = passport.Split(" ");
                foreach (string piece in passport.Split(" ")) {
                    string[] splitField = piece.Split(":");
                    if (splitField.Length != 2) {
                        Console.WriteLine("Improperly formatted field found");
                    }
                    string fieldName = splitField[0];
                    string fieldValue = splitField[1];
                    passportDict.Add(fieldName, fieldValue);
                }
                bool valid = true;
                foreach (string requiredField in requiredFields) {
                    if (!passportDict.ContainsKey(requiredField)) {
                        valid = false;
                    }
                }
                if (valid) {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports + " valid passports.");
        }
    }
}

