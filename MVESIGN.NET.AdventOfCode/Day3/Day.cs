using System;
using System.Collections.Generic;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day3
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
            : base(3)
        {
            FileContent = CurrentDay.ReadAllText();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + deliverPackages(1));

            // Part two
            Console.WriteLine("Part 2: " + deliverPackages(2));
        }

        /// <summary>
        /// Deliver the packages by a number of santas.
        /// </summary>
        /// <param name="numberOfSantas">Number of delivering santas.</param>
        /// <returns>Returns the amount of unique houses where a package is delivered.</returns>
        private int deliverPackages(int numberOfSantas)
        {
            var houses = new List<Tuple<int, int>>();

            for (int index = 0; index < numberOfSantas; index++)
            {
                int column = 0, row = 0;

                for (int number = 0; number < FileContent.Length; number += numberOfSantas)
                {
                    if (houses.Where(house => house.Item1 == row && house.Item2 == column).Count() <= 0)
                    {
                        houses.Add(Tuple.Create<int, int>(row, column));
                    }

                    column += FileContent[number + index] == '>' ? 1 : FileContent[number + index] == '<' ? -1 : 0;
                    row += FileContent[number + index] == '^' ? -1 : FileContent[number + index] == 'v' ? 1 : 0;
                }
            }

            return houses.Count;
        }
    }
}