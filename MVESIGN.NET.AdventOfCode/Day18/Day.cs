using System;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day18
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
            : base(18)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// List of all light states.
        /// </summary>
        public int[][] States { get; set; }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + processStates(false));

            // Part two
            Console.WriteLine("Part 2: " + processStates(true));
        }

        private int processStates(bool withFixedCorners)
        {
            States = FileLines.Select(line => line.Trim().Select(character => character == '#' ? 1 : 0).ToArray()).ToArray();

            for (int number = 0; number < 100; number++)
            {
                var nextStates = Enumerable.Range(0, States.Length)
                    .Select(row => Enumerable.Range(0, States[row].Length)
                        .Select(column => selectNextLight(row, column, withFixedCorners)).ToArray()
                    ).ToArray();

                States = nextStates;
            }

            return States.Sum(state => state.Sum());
        }

        /// <summary>
        /// Helper function to select the value for the current light.
        /// </summary>
        /// <param name="row">Number of the row.</param>
        /// <param name="column">Number of column.</param>
        /// <returns>Returns the value of the light.</returns>
        private int selectLight(int row, int column)
        {
            return row < 0 || row >= States.Length ? 0 : column < 0 || column >= States[row].Length ? 0 : States[row][column];
        }

        /// <summary>
        /// Helper function to select all turned on lights of the neighbours for the current light.
        /// </summary>
        /// <param name="row">Number of the row.</param>
        /// <param name="column">Number of column.</param>
        /// <returns>Returns the value of the neighbours light.</returns>
        private int selectNeighbourLights(int row, int column)
        {
            return selectLight(row - 1, column - 1) + selectLight(row, column - 1) + selectLight(row + 1, column - 1)
                + selectLight(row - 1, column) + selectLight(row + 1, column)
                + selectLight(row - 1, column + 1) + selectLight(row, column + 1) + selectLight(row + 1, column + 1);
        }

        /// <summary>
        /// Helper function to select the next value for the current light.
        /// </summary>
        /// <param name="row">Number of the row.</param>
        /// <param name="column">Number of column.</param>
        /// <returns>Returns the next value of the light.</returns>
        private  int selectNextLight (int row, int column, bool withFixedCorners)
        {
            if (withFixedCorners)
            {
                if (row == 0 && column == 0)
                {
                    return 1;
                }
                if (row == States.Length - 1 && column == 0)
                {
                    return 1;
                }
                if (row == 0 && column == States[row].Length - 1)
                {
                    return 1;
                }
                if (row == States.Length - 1 && column == States[row].Length - 1)
                {
                    return 1;
                }
            }

            return selectNeighbourLights(row, column) == 3 ? 1 : selectNeighbourLights(row, column) == 2 && selectLight(row, column) == 1 ? 1 : 0;
        }
    }
}