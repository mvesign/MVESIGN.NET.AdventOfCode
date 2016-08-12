using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day13
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
            : base(13)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Mapping of each person and their happiness.
        /// </summary>
        public Dictionary<string, int> Mapping { get; set; }

        /// <summary>
        /// Names of all unique persons.
        /// </summary>
        public List<string> Persons { get; set; }

        /// <summary>
        /// Set of rules, converted out of the current file lines.
        /// </summary>
        public List<Rule> Rules { get; set; }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            Rules = convertToRules();
            Persons = Rules.Select(rule => rule.Name).Distinct().ToList();
            Mapping = Rules.ToDictionary(rule => string.Format("{0} - {1}", rule.Name, rule.Related), rule => rule.Gain);

            // Part one
            Console.WriteLine(string.Format("Part 1: {0}", calculateHappiness()));

            // Part two
            Persons.ForEach(person =>
                {
                    Mapping[string.Format("MVESIGN - {0}", person)] = 0;
                    Mapping[string.Format("{0} - MVESIGN", person)] = 0;
                }
            );
            Persons.Add("MVESIGN");

            Console.WriteLine(string.Format("Part 2: {0}", calculateHappiness()));
        }

        /// <summary>
        /// Calculate the untimate happiness of the current table settings.
        /// </summary>
        /// <returns>Returns the calculated, ultimate happiness factor.</returns>
        private int calculateHappiness()
        {
            return Persons.Skip(1).Permutations()
                .Select(person => person.Prepend(Persons[0]).Concat(Persons[0]).Pairwise((a, b) => new { a, b }))
                .Select(pairs =>
                    new
                    {
                        Happiness = pairs.Sum(pair => Mapping[string.Format("{0} - {1}", pair.a, pair.b)] + Mapping[string.Format("{0} - {1}", pair.b, pair.a)])
                    }
                )
                .MaxBy(plan => plan.Happiness)
                .Happiness;
        }

        /// <summary>
        /// Convert the current set of file lines into rules.
        /// </summary>
        /// <returns>Returns the converted set of rules.</returns>
        private List<Rule> convertToRules()
        {
            return FileLines
                .Select(line =>
                    Regex.Match(line, @"(\w+) would (lose|gain) (\d+) happiness units by sitting next to (\w+)\.")
                        .Groups.Cast<Group>()
                        .Skip(1)
                        .Select(group => group.Value)
                        .ToArray()
                )
                .Select(person => new Rule()
                    {
                        Name = person[0],
                        Related = person[3],
                        Gain = int.Parse(person[2]) * (person[1] == "lose" ? -1 : 1)
                    }
                )
                .ToList();
        }
    }
}