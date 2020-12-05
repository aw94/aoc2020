using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.day5
{
    public class day5part1
    {
        private string[] Input { get; }

        public day5part1(string[] input)
        {
            Input = input;
        }

        private static decimal CalculateSeat(decimal one, decimal two)
        {
            decimal calc = (Math.Max(one, two) - Math.Min(one, two));
            calc /= 2;
            return Math.Ceiling(calc);
        }

        public void Solve()
        {
            var seatIdList = new List<decimal>();
            foreach (var seat in Input)
            {
                var row = new decimal[] {0, 127};
                var column = new decimal[] {0, 7};
                foreach (var letter in seat)
                {
                    switch (letter)
                    {
                        case 'F':
                            row[1] -= CalculateSeat(row[0], row[1]);
                            continue;
                        case 'B':
                            row[0] += CalculateSeat(row[0], row[1]);
                            continue;
                        case 'R':
                            column[0] += CalculateSeat(column[0], column[1]);
                            continue;
                        case 'L':
                            column[1] -= CalculateSeat(column[0], column[1]);
                            continue;
                        default: throw new Exception();
                    }
                }

                seatIdList.Add(row[0] * 8 + column[0]);
            }

            Console.WriteLine(seatIdList.Max());
            Console.ReadKey();
        }
    }
}