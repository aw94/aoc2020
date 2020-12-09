using System.IO;
using adventofcode.day5;
using adventofcode.day6;
using adventofcode.day7;
using adventofcode.day8;

namespace adventofcode
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("./input.txt");
            var day7 = new day8part2(input);
            day7.Solve();
        }
    }
}