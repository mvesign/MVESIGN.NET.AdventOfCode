using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVESIGN.NET.AdventOfCode.Day17
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
            : base(17)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            List<int> containers = FileLines.Select(int.Parse).ToList();

            var combinations = selectCombinations(new List<int>(), containers, 150);

            // Part one
            Console.WriteLine(string.Format("Part 1: {0}", combinations.Count()));

            // Part two
            int minimumContainers = combinations.Min(combination => combination.Count());
            Console.WriteLine(string.Format("Part 2: {0}", combinations.Where(combination => combination.Count == minimumContainers).Count()));
        }

        /// <summary>
        /// Select the number of combinations for filling containers with a given amount.
        /// </summary>
        /// <param name="usedContainers">List of used containers.</param>
        /// <param name="containers">List of available containers.</param>
        /// <param name="amount">Amount of liters eggnog.</param>
        /// <returns>Returns the number of combinations.</returns>
        private IEnumerable<List<int>> selectCombinations(List<int> usedContainers, List<int> containers, int amount)
        {
            var remaining = amount - usedContainers.Sum();
            for (int number = 0; number < containers.Count; number++)
            {
                if (containers[number] > remaining)
                {
                    continue;
                }

                var container = containers[number];

                var yieldedUsedContainers = usedContainers.ToList();
                yieldedUsedContainers.Add(container);
                if (container == remaining)
                {
                    yield return yieldedUsedContainers;
                }
                else
                {
                    var yieldedContainers = containers.Skip(number + 1).ToList();
                    foreach (var distributed in selectCombinations(yieldedUsedContainers, yieldedContainers, amount))
                    {
                        yield return distributed;
                    }
                }
            }
        }
    }
}