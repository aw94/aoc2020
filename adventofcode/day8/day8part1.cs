using System;

namespace adventofcode.day8
{
    public class day8part1
    {
        private string[] Input { get; }
        public int Accumulator { get; set; }

        public day8part1(string[] input)
        {
            Input = input;
        }

        public void Solve()
        {
            for (var index = 0; index < Input.Length; index++)
            {
                var line = Input[index];
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine(Accumulator);
                }

                index += DoStuff(line);
                ;
                Input[index] = "";
            }
        }

        public int DoStuff(string action)
        {
            var actionNumber = int.Parse(action.Split(" ")[1]);
            var actionCase = action.Split(" ")[0];
            switch (actionCase)
            {
                case "nop":
                    return 0;
                case "acc":
                    Accumulator += actionNumber;
                    return 0;
                case "jmp":
                    return actionNumber - 1;
            }

            return 0;
        }
    }
}