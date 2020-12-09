using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.day9
{
    public class day9part2
    {
        private List<string> Input { get; }

        private readonly int _myNumber = 1721308972;
        

        public day9part2(string[] input)
        {
            Input = input.ToList();
        }


        public void Solve()
        {
            for (int i = 0; i < Input.Count; i++)
            {
                decimal number = 0;
                var storedInts = new List<decimal>();
                for (int j = i; j < Input.Count; j++)
                {
                    number += decimal.Parse(Input[j]);
                    storedInts.Add(decimal.Parse(Input[j]));
                    if (number > _myNumber) break;
                    if (number == _myNumber)
                    {
                        storedInts.Sort();
                        Console.WriteLine($"lowest: {storedInts[0]} higest: {storedInts[^1]}");
                        Console.WriteLine(decimal.Add(storedInts[0],storedInts[^1]).ToString());
                        return;
                    }
                }
            }
        }
    }
}