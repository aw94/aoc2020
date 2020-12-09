using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.day9
{
    public class day9part1
    {
        private List<string> Input { get; }

        public day9part1(string[] input)
        {
            Input = input.ToList();
        }
        
        public void Solve()
        {
            for (int i = 0; i < Input.Count; i++)
            {
                if (i < 25) continue;
                for (int j = i - 25; j < i; j++)
                {
                    var number = Math.Max(decimal.Parse(Input[i]),
                            decimal.Parse(Input[j]) - Math.Min(decimal.Parse(Input[i]), decimal.Parse(Input[j])))
                        .ToString();
                    if (Input.ToArray()[(j > 25 ? j - 25 : 0)..j].Contains(number)) break;
                    if (j == i - 1)
                    {
                        Console.WriteLine(Input[i]);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}