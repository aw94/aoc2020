using System.IO;
using adventofcode.day5;
using adventofcode.day6;
using adventofcode.day7;
using adventofcode.day8;
using adventofcode.day9;

namespace adventofcode
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("./input.txt");
            var day9 = new day9part2(input);
            day9.Solve();
        }
    }
}