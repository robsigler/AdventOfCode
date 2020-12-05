using System;
using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    public class Solution2
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

                if (IsValid(passportDict)) {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports + " valid passports.");
        }

        public static bool IsValid(Dictionary<string, string> passport) {
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
            foreach (string requiredField in requiredFields) {
                if (!passport.ContainsKey(requiredField)) {
                    Console.WriteLine("Missing field");
                    return false;
                }
            }

            int byr = int.Parse(passport["byr"]);
            if ((byr < 1920) || (byr > 2002)) {
                Console.WriteLine("bad birth year");
                return false;
            }

            int iyr = int.Parse(passport["iyr"]);
            if ((iyr < 2010) || (iyr > 2020)) {
                Console.WriteLine("bad issued year");
                return false;
            }

            int eyr = int.Parse(passport["eyr"]);
            if ((eyr < 2020) || (eyr > 2030)) {
                Console.WriteLine("bad eyr");
                return false;
            }

            string height = passport["hgt"];
            if (height.EndsWith("cm")) {
                int cm = int.Parse(height.Substring(0, height.Length - 2));
                if ((cm < 150) || (cm > 193)) {
                    Console.WriteLine("bad hgt in cm");
                    return false;
                }
            } else if (height.EndsWith("in")) {
                int inches = int.Parse(height.Substring(0, height.Length - 2));
                if ((inches < 59) || (inches > 76)) {
                    Console.WriteLine("bad hgt in inches");
                    return false;
                }
            } else {
                Console.WriteLine("bad hgt");
                return false;
            }

            string hcl = passport["hcl"];
            if (!hcl.StartsWith('#')) {
                Console.WriteLine("bad hcl, no #");
                return false;
            }
            if (hcl.Length != 7) {
                Console.WriteLine("bad hcl, too short");
                return false;
            }
            foreach (char hex in hcl.Split("#")[1]) {
                int intVersion = (int) hex;
                bool isDigit = (intVersion >= 0) || (intVersion <= 9);
                bool isAThruF = (intVersion >= ((int)'a')) || (intVersion <= ((int)'f'));
                if (!(isDigit || isAThruF)) {
                    Console.WriteLine("bad hcl, bad digits");
                    return false;
                }
            }

            List<string> validEyeColors = new List<string>(new [] {
                "amb",
                "blu",
                "brn",
                "gry",
                "grn",
                "hzl",
                "oth",
            });
            string ecl = passport["ecl"];
            if (!validEyeColors.Contains(ecl)) {
                Console.WriteLine("bad ecl, not in list");
                return false;
            }

            string pid = passport["pid"];
            if (pid.Length != 9) {
                Console.WriteLine("bad pid, wrong length");
                return false;
            }
            try {
                int.Parse(pid);
            } catch {
                return false;
            }

            return true;
        }
    }
}

