using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace adventofcode.day6
{
    public class day6part2
    {
        private List<Tuple<string, int>> Input { get; } = new List<Tuple<string, int>>();

        public day6part2(IReadOnlyList<string> input)
        {
            var tempStr = new StringBuilder();
            var people = 0;
            for (int i = 0; i <= input.Count; i++)
            {
                if (input.Count == i || string.IsNullOrWhiteSpace(input[i]))
                {
                    Input.Add(new Tuple<string, int>(tempStr.ToString(), people));
                    tempStr.Clear();
                    people = 0;
                }
                else
                {
                    people++;
                    tempStr.Append(input[i]);
                }
            }
        }

        public void Solve()
        {
            var count = Input.Select(t =>
                t.Item1.Count(chr => t.Item1.Length - t.Item1.Replace(chr.ToString(), "").Length == t.Item2)).ToList();
            Console.WriteLine(count.Sum());
        }
    }
}