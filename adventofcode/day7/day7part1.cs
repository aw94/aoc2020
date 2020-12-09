using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventofcode.day7
{
    public class day7part1
    {
        private string[] Input { get; }
        public int ValidBags { get; set; }
        public day7part1(string[] input)
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


            foreach (var line in Input)
            {
                var strArr = line.Split(' ');
                var bag = $"{strArr[0]} {strArr[1]}";
                var pattern = @"(?<bag>[a-z]+\s[a-z]+)";
                var currentBag = allBags[bag];
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    if (match.Groups["bag"].Value.Contains("bag") || match.Groups["bag"].Value.Contains(bag) || match.Groups["bag"].Value.Contains("other")) continue;

                    currentBag.Add(match.Groups["bag"].Value);
                }
            }


            foreach (var bag in allBags)
            {
                if(bag.Key == "shiny gold") continue;
                
                RecursiveLookUp(allBags, bag.Key, ValidBags);
            }

            Console.WriteLine(ValidBags);
        }
        private bool RecursiveLookUp(Dictionary<string, List<string>> bagList, string bagName, int validBags)
        {
            for (int i = 0; i < bagList[bagName].Count; i++)
            {
                if (validBags != ValidBags) return true;
                if (bagList[bagName].Contains("shiny gold"))
                {
                    ValidBags++;
                    return true;
                }
            RecursiveLookUp(bagList,bagList[bagName][i],validBags);
                
            }
            return false;
        }
    
}
}