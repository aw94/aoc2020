using System.IO;
using adventofcode.day5;
using adventofcode.day6;

namespace adventofcode
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("./input.txt");
            var day6 = new day6part2(input);
            day6.Solve();
        }
    }
}