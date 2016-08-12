using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day9
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
            : base(9)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            Regex regex = new Regex(@"^(.*?) to (.*?) = (\d+)$", RegexOptions.Compiled);

            var stages = FileLines.Select(inputLine =>
            {
                var match = regex.Match(inputLine);
                return new
                {
                    Start = match.Groups[1].Value,
                    Finish = match.Groups[2].Value,
                    Distance = int.Parse(match.Groups[3].Value)
                };
            });

            stages = stages.Union(
                stages.Select(stage => new
                {
                    Start = stage.Finish,
                    Finish = stage.Start,
                    Distance = stage.Distance
                })
            ).ToArray();

            var matrix = stages.ToDictionary(stage => stage.Start + "-" + stage.Finish, (stage) => stage.Distance);
            var routes = permutate(stages.Select(stage => stage.Start).Distinct().ToArray()).ToArray().Select(route =>
            {
                var totalDistance = 0;
                for (var i = 1; i < route.Length; i++)
                {
                    var stage = route[i - 1] + "-" + route[i];
                    if (!matrix.ContainsKey(stage))
                    {
                        return new { route, totalDistance = int.MaxValue };
                    }

                    totalDistance += matrix[stage];
                }

                return new { route, totalDistance };
            });

            // Part one
            Console.WriteLine("Part 1: " + routes.Min(route => route.totalDistance).ToString());

            // Part two
            Console.WriteLine("Part 2: " + routes.Max(route => route.totalDistance).ToString());
        }

        /// <summary>
        /// Permutate a given list of input values.
        /// </summary>
        /// <param name="input">List of input values.</param>
        /// <returns>Returns a list of permutated values.</returns>
        private IEnumerable<string[]> permutate(string[] input)
        {
            if (input.Length == 0)
            {
                yield break;
            }

            if (input.Length == 1)
            {
                yield return input;
            }

            foreach (var item in input)
            {
                foreach (var permutation in permutate(input.Where(l => !l.Equals(item)).ToArray()))
                {
                    yield return permutation.Concat(new[] { item }).ToArray();
                }
            }
        }
    }
}