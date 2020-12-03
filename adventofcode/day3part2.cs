using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public class day3part2
    {
        private string[] Input { get; }

        public day3part2(string[] input)
        {
            Input = input;
        }

        public void Solve()
        {
            var input = Input;
            var right = 0;
            var tree = 0;
            var treeList = new List<int>();
            var charsPerInput = input[0].Length;
            var slopes = new[]
            {
                new Tuple<int, int>(1, 1), new Tuple<int, int>(3, 1), new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1), new Tuple<int, int>(1, 2),
            };

            foreach (var slope in slopes)
            {
                
                tree = 0;
                right = 0;
                for (int i = 0; i < input.Length - 1; i+=slope.Item2)
                {
                    right += slope.Item1;

                    if (right >= charsPerInput)
                    {
                        right -= charsPerInput;
                    }

                    if (input[i + slope.Item2][right] == '#')
                    {
                        tree++;
                    }
                }
                treeList.Add(tree);
            }

            var sum = 1;
            treeList.ForEach(c =>
            {
                 sum *= c;
            } );
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}