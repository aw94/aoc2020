using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace adventofcode.day8
{
    public class day8part2
    {
        private string[] Actions;
        private int[] Instructions;
        private int Accumulator { get; set; }
        public day8part2(IReadOnlyList<string> input)
        {
            Actions = new string[input.Count];
            Instructions = new int[input.Count];
            for (var index = 0; index < input.Count; index++)
            {
                var line = input[index];
                Actions[index] = line.Split(" ")[0];
                Instructions[index] = int.Parse(line.Split(" ")[1]);
            }
        }

        public void Solve()
        {
            var stop = false;

            for (int i = 0; i < Actions.Length; i++)
            {
                var tempActions = (string[]) Actions.Clone();

                if (tempActions[i] == "jmp")
                {
                    tempActions[i] = "nop";
                }
                else if (tempActions[i] == "nop")
                {
                    tempActions[i] = "jmp";
                }
                else
                {
                    continue;
                }

                for (var index = 0; index < tempActions.Length; index++)
                {
                    var actionCase = new string(tempActions[index]);
                    var actionNumber = Instructions[index];

                    // Setting used action to null
                    tempActions[index] = null;

                    index += DoStuff(actionCase, actionNumber);

                    if (index == Actions.Length - 1)
                    {
                        Console.WriteLine(Accumulator);
                        stop = true;
                    }

                    // Fail, run next
                    if (!string.IsNullOrWhiteSpace(actionCase)) continue;
                    Accumulator = 0;
                    break;
                }

                if (!stop) continue; 
                break;
            }
        }

        private int DoStuff(string actionCase, int actionNumber)
        {
            switch (actionCase)
            {
                case "nop":
                    return 0;
                case "acc":
                    Accumulator += actionNumber;
                    return 0;
                case "jmp":
                    return actionNumber == 0 ? 0 : actionNumber - 1;
            }
            return 0;
        }
    }
}