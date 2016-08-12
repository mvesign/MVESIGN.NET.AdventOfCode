using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day15
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
            : base(15)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            List<Ingredient> ingredients = convertToIngredients();

            var scores = distribute(new int[ingredients.Count], 100, 0)
                   .Select(amounts => calculateCookieScore(ingredients, amounts))
                   .ToList();

            // Part one
            Console.WriteLine(string.Format("Part 1: {0}", scores.Max(score => score.Item1)));

            // Part two
            Console.WriteLine(string.Format("Part 2: {0}", scores.Where(score => score.Item2 == 500).Max(score => score.Item1)));
        }

        /// <summary>
        /// Calculate the score of each cookie ingredient list.
        /// </summary>
        /// <param name="ingredients">List of ingredients.</param>
        /// <param name="amounts">List of amount of teaspoons per ingredient.</param>
        /// <returns>Returs the calculated cookie score.</returns>
        private Tuple<long, long> calculateCookieScore(List<Ingredient> ingredients, int[] amounts)
        {
            var score = ingredients
                .Zip(amounts, (ingredient, amount) => ingredient * amount)
                .Aggregate((a, b) => a + b);

            return Tuple.Create(score.Score, score.Calories);
        }

        /// <summary>
        /// Convert the current set of file lines into ingredients.
        /// </summary>
        /// <returns>Returns the converted set of ingredients.</returns>
        private List<Ingredient> convertToIngredients()
        {
            return FileLines.Select(fileLine =>
                    Regex.Match(fileLine, @"(\w+): capacity ([\-]?\d+), durability ([\-]?\d+), flavor ([\-]?\d+), texture ([\-]?\d+), calories ([\-]?\d+)")
                        .Groups.Cast<Group>()
                        .Skip(1)
                        .Select(group => group.Value)
                        .ToArray()
                )
                .Select(ingredient => new Ingredient()
                {
                    Capacity = int.Parse(ingredient[1]),
                    Calories = int.Parse(ingredient[5]),
                    Durability = int.Parse(ingredient[2]),
                    Flavor = int.Parse(ingredient[3]),
                    Texture = int.Parse(ingredient[4]),
                })
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private IEnumerable<int[]> distribute(int[] start, int target, int length)
        {
            var remaining = target - start.Sum();
            if (length == start.Length - 1)
            {
                int[] array = start.ToArray();
                array[length] = remaining;
                yield return array;
            }
            else
            {
                for (int count = 0; count < remaining; count++)
                {
                    int[] array = start.ToArray();
                    array[length] = count;
                    foreach (var distribution in distribute(array, target, length + 1))
                    {
                        yield return distribution;
                    }
                }
            }
        }
    }
}