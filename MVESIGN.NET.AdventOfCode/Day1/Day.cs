using MoreLinq;
using System;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day1
{
    /// <summary>
    /// Class containing functionalities for the current day.
    /// </summary>
    public class Day : MVESIGN.NET.AdventOfCode.Day
    {
        /// <summary>
        /// Create an instance of the current day.
        /// </summary>
        public Day()
            : base(1)
        {
            FileContent = CurrentDay.ReadAllText();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + FileContent.Sum(character => character == '(' ? 1 : -1));

            // Part two
            Console.WriteLine("Part 2: " + FileContent
                .Scan(0, (f, d) => d == '(' ? f + 1 : f - 1)
                .Select((floor, index) => new { floor, index })
                .First(f => f.floor == -1)
                .index
            );
        }
    }
}