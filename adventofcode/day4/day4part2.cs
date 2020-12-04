using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode.day4
{
    public class day4part2
    {
        private List<string> Input { get; } = new List<string>();

        public day4part2(IReadOnlyList<string> input)
        {
            var tempStr = new StringBuilder();
            for (int i = 0; i <= input.Count; i++)
            {
                if (input.Count == i || string.IsNullOrWhiteSpace(input[i]))
                {
                    Input.Add(tempStr.ToString());
                    tempStr.Clear();
                }
                else
                {
                    tempStr.Append(input[i] + " ");
                }
            }
        }

        public void Solve()
        {
            var validPasswords = 0;
            const string pattern = @"(?<field>\w+):(?<answer>\S+)";
            
            foreach (var matches in Input.Select(field => Regex.Matches(field, pattern)))
            {
                switch (matches.Count)
                {
                    case 8 when matches.All(ValidateField):
                        validPasswords++;
                        break;
                    case 7 when matches.All(
                        c => c.Groups["field"].Value != "cid" && ValidateField(c)):
                        validPasswords++;
                        break;
                }
            }

            Console.WriteLine(validPasswords);
            Console.ReadKey();
        }

        private static bool ValidateField(Match field)
        {
            switch (field.Groups["field"].Value)
            {
                case "pid":
                {
                    if (field.Groups["answer"].Value.Length == 9) return true;
                    break;
                }
                case "cid":
                {
                    return true;
                }
                case "byr":
                {
                    var test = int.Parse(field.Groups["answer"].Value);
                    if (test >= 1920 && test <= 2002) return true;
                    break;
                }
                case "iyr":
                {
                    var test = int.Parse(field.Groups["answer"].Value);
                    if (test >= 2010 && test <= 2020) return true;
                    break;
                }
                case "eyr":
                {
                    var test = int.Parse(field.Groups["answer"].Value);
                    if (test >= 2020 && test <= 2030) return true;
                    break;
                }
                case "ecl":
                {
                    var validColors = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                    var test = field.Groups["answer"].Value;
                    if (validColors.Any(c => c == test)) return true;
                    break;
                }
                case "hgt":
                {

                    var match = Regex.Match(field.Groups["answer"].Value, @"^(?<length>\d+)(?<unit>\w+)$");
                    var length = int.Parse(match.Groups["length"].Value);
                    var unit = match.Groups["unit"].Value;
                    if (unit == "cm" && (length >= 150 && length <= 193) || unit == "in" && (length >= 59 && length <= 76))
                    {
                        return true;
                    }
                   
                    break;
                }
                case "hcl":
                {
                    var test = field.Groups["answer"].Value;
                    if (Regex.IsMatch(test, @"^#[a-f0-9]{6}$")) return true;
                    break;
                }
                default: throw new Exception();
            }

            return false;
        }
    }
}