using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode.day4
{
    public class day4part1
    {
        private List<string> Input { get; } = new List<string>();

        public day4part1(IReadOnlyList<string> input)
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

            const string pattern = @"\w+:";
            foreach (var matchCollection in Input.Select(field => Regex.Matches(field, pattern)))
            {
                if (matchCollection.Count == 8)
                {
                    validPasswords++;
                }
                else if (matchCollection.All(c => c.Value.ToString() != "cid:") && matchCollection.Count == 7)
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
            Console.ReadKey();
        }
    }
}