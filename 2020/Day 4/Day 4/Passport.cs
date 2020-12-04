using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_4
{
    public class Passport
    {
        private Passport()
        {
        }

        public int BirthYear { get; private set; }

        public int IssueYear { get; private set; }

        public int ExpirationYear { get; private set; }

        public string Height { get; private set; }

        public string HairColour { get; private set; }

        public string EyeColour { get; private set; }

        public string PassportId { get; private set; }

        public string CountryId { get; private set; }

        public static bool TryParse(IDictionary<string, string> data, bool validate, out Passport result)
        {
            try
            {
                var passport = new Passport()
                {
                    BirthYear = validate ? ParseYear(data["byr"], 1920, 2002) : int.Parse(data["byr"]),
                    IssueYear = validate ? ParseYear(data["iyr"], 2010, 2020) : int.Parse(data["iyr"]),
                    ExpirationYear = validate ? ParseYear(data["eyr"], 2020, 2030) : int.Parse(data["eyr"]),
                    Height = validate ? ParseHeight(data["hgt"]) : data["hgt"],
                    HairColour = validate ? ParseColour(data["hcl"]) : data["hcl"],
                    EyeColour = validate ? ParseEyeColour(data["ecl"]) : data["ecl"],
                    PassportId = validate ? ParsePassportId(data["pid"]) : data["pid"]
                };

                if (data.TryGetValue("cid", out var cid))
                {
                    passport.CountryId = cid;
                }

                result = passport;
            }
            catch
            {
                result = null;
                return false;
            }
            
            return true;
        }

        private static int ParseYear(string input, int min, int max)
        {
            if (input.Length != 4)
            {
                throw new InvalidDataException();
            }

            var number = int.Parse(input);
            if (number < min
                || number > max)
            {
                throw new InvalidDataException();
            }

            return number;
        }

        private static string ParseHeight(string input)
        {
            var matches = Regex.Matches(input, "^(?<value>[0-9]+)(?<unit>(cm|in){1})$");

            if (matches.Count != 1)
            {
                throw new InvalidDataException();
            }

            var match = matches.First();
            int height = int.Parse(match.Groups["value"].Value);

            switch (match.Groups["unit"].Value)
            {
                case "cm":
                    if (height >= 150 && height <= 193)
                    {
                        return input;
                    }
                    break;
                case "in":
                    if (height >= 59 && height <= 76)
                    {
                        return input;
                    }
                    break;
            }

            throw new InvalidDataException();
        }

        private static string ParseColour(string input)
        {
            if (!Regex.IsMatch(input, "^#[0-9a-f]{6}$"))
            {
                throw new InvalidDataException();
            }

            return input;
        }

        private static string ParseEyeColour(string input)
        {
            switch (input)
            {
                case "amb":
                case "blu":
                case "brn":
                case "gry":
                case "grn":
                case "hzl":
                case "oth":
                    return input;
            }

            throw new InvalidDataException();
        }

        private static string ParsePassportId(string input)
        {
            if (Regex.IsMatch(input, "^[0-9]{9}$"))
            {
                return input;
            }

            throw new InvalidDataException();
        }
    }
}
