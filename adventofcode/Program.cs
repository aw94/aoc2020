using System.IO;
using adventofcode.day5;

namespace adventofcode
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("./input.txt");
            var day5 = new day5part2alternative(input);
            day5.Solve();
        }
    }
}