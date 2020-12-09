using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.day7
{
    public class day7part2
    {
        private string[] Input { get; }
        public int ValidBags { get; set; }

        public day7part2(string[] input)
        {
            Input = input;
        }

        public void Solve()
        {
            var allBags = new Dictionary<string, List<string>>();
            foreach (var line in Input)
            {
                var strArr = line.Split(' ');
                allBags.Add($"{strArr[0]} {strArr[1]}", new List<string>());
            }


            // regex because I'm lazy..
            foreach (var line in Input)
            {
                var strArr = line.Split(' ');
                var bag = $"{strArr[0]} {strArr[1]}";
                var pattern = @"(?<bag>\d*\s[a-z]+\s[a-z]+)";
                var currentBag = allBags[bag];
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    if (match.Groups["bag"].Value.Contains("bag") || match.Groups["bag"].Value.Contains(bag) ||
                        match.Groups["bag"].Value.Contains("other") ||
                        match.Groups["bag"].Value.Contains("contain")) continue;

                    currentBag.Add(match.Groups["bag"].Value);
                }
            }


            foreach (var bag in allBags.Single(c => c.Key == "shiny gold").Value)
            {
                RecursiveLookUp(allBags, bag, (int) char.GetNumericValue(bag[0]));
                ValidBags += (int) char.GetNumericValue(bag[0]);
            }

            Console.WriteLine(ValidBags);
        }

        private bool RecursiveLookUp(IReadOnlyDictionary<string, List<string>> bagDictionary,
            string bagName, int prevNumber = 1)
        {
            var total = 0;
            var bagNameWithoutNumber = bagName.Substring(2);
            for (int i = 0; i < bagDictionary[bagNameWithoutNumber].Count; i++)
            {
                total += (int) char.GetNumericValue(bagDictionary[bagNameWithoutNumber][i][0]);
            }

            if (bagDictionary[bagNameWithoutNumber].Count == 0) return true;
            total *= prevNumber;
            ValidBags += total;
            for (int i = 0; i < bagDictionary[bagNameWithoutNumber].Count; i++)
            {
                RecursiveLookUp(bagDictionary, bagDictionary[bagNameWithoutNumber][i],
                    (int) char.GetNumericValue(bagDictionary[bagNameWithoutNumber][i][0]) * prevNumber);
            }

            return false;
        }
    }
}