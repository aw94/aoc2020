using System;

namespace adventofcode
{
    public class day3part1
    {
        private string[] Input { get; }

        public day3part1(string[] input)
        {
            Input = input;
        }


        public void Solve()
        {
            var input = Input;
            var right = 0;
            var tree = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                right += 3;

                if (right >= 31)
                {
                    right -= 31;
                }

                if (input[i + 1][right] == '#')
                {
                    tree++;
                }
            }


            Console.WriteLine(tree);
            Console.ReadKey();
        }
    }
}