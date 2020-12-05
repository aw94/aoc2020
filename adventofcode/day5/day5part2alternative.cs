using System;
using System.Linq;

namespace adventofcode.day5
{
    public class day5part2alternative
    {
        
        private string[] Input { get; }

        public day5part2alternative(string[] input)
        {
            Input = input;
        }

        public void Solve()
        {
            var seatListId = (from seat in Input select seat.Replace('B', '1') into binaryString select binaryString.Replace('F', '0') into binaryString select binaryString.Replace('L', '0') into binaryString select binaryString.Replace('R', '1') into binaryString select Convert.ToInt32(binaryString, 2)).ToList();
            seatListId.Sort();
            for (var i = 0; i < seatListId.Count; i++)
            {
                if (seatListId[i + 1] == seatListId[i] + 1) continue;
                Console.WriteLine(seatListId[i] + 1);
                break;
            }
            Console.ReadKey();
        }
    }
}