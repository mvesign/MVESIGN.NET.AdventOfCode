using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day16
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
            : base(16)
        {
            FileLines = CurrentDay.ReadAllLines();
            MyAunt = convertToAunt("Sue 0: children: 3, cats: 7, samoyeds: 2, pomeranians: 3, akitas: 0, vizslas: 0, goldfish: 5, trees: 3, cars: 2, perfumes: 1");
        }

        /// <summary>
        /// Details of my aunt Sue.
        /// </summary>
        public Aunt MyAunt { get; set; }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            List<Aunt> aunts = convertToAunts();

            // Part 1
            Console.WriteLine(
                "Part 1: {0}", aunts.FirstOrDefault(aunt => MyAunt.Clues.All(clue => !aunt.Clues.ContainsKey(clue.Key) || aunt.Clues[clue.Key] == clue.Value)).Number
            );

            // Part 2
            Console.WriteLine(
                "Part 2: {0}",
                aunts.FirstOrDefault(
                    aunt => MyAunt.Clues.All(clue => 
                        !aunt.Clues.ContainsKey(clue.Key) ||
                        ((clue.Key == "cats" || clue.Key == "trees") ? aunt.Clues[clue.Key] > clue.Value :
                            (clue.Key == "pomeranians" || clue.Key == "goldfish") ? aunt.Clues[clue.Key] < clue.Value :    
                                aunt.Clues[clue.Key] == clue.Value)
                    )
                ).Number
            );
        }

        /// <summary>
        /// Convert a file line into compounds of aunt Sue.
        /// </summary>
        /// <param name="fileLine">Line of the file.</param>
        /// <returns>Returns the converted aunt Sue.</returns>
        private Aunt convertToAunt(string fileLine)
        {
            string[] aunt = Regex.Match(fileLine, @"Sue (\d+): (.+)")
                .Groups.Cast<Group>()
                .Skip(1)
                .Select(group => group.Value)
                .ToArray();

            return convertToAunt(int.Parse(aunt[0]), aunt[1].Split(',').ToList());
        }

        /// <summary>
        /// Convert a list of raw compounds into compounds of aunt Sue.
        /// </summary>
        /// <param name="number">Number of aunt Sue.</param>
        /// <param name="details">List of raw compounds.</param>
        /// <returns>Returns the converted aunt Sue.</returns>
        private Aunt convertToAunt(int number, List<string> details)
        {
            Aunt aunt = new Aunt()
            {
                Clues = new Dictionary<string, int>(),
                Number = number
            };

            details.ForEach(detail =>
            {
                string[] clues = detail.Split(':');
                aunt.Clues.Add(clues[0].Trim(), int.Parse(clues[1]));
            });

            return aunt;
        }

        /// <summary>
        /// Convert a set of file lines into aunts Sue.
        /// </summary>
        /// <returns>Returns a list of converted aunts Sue.</returns>
        private List<Aunt> convertToAunts()
        {
            return FileLines.Select(fileLine => convertToAunt(fileLine)).ToList();
        }
    }
}