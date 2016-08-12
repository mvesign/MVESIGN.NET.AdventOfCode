using System;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day2
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
            : base(2)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + FileLines
                .Select(line => convertLineToNumbers(line))
                .Select(item => 3 * item[0] * item[1] + 2 * item[0] * item[2] + 2 * item[1] * item[2])
                .Sum()
            );

            // Part two
            Console.WriteLine("Part 2: " + FileLines
                .Select(line => convertLineToNumbers(line))
                .Select(item => 2 * item[0] + 2 * item[1] + item[0] * item[1] * item[2])
                .Sum()
            );
        }

        /// <summary>
        /// Convert a file line into a set of numbers.
        /// </summary>
        /// <param name="line">Value of the file line.</param>
        /// <returns>Returns the converted set of numbers.</returns>
        private int[] convertLineToNumbers(string line)
        {
            return line.Split('x').Select(int.Parse).OrderBy(value => value).ToArray();
        }
    }
}