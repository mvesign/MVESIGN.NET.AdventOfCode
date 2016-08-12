using System;
using System.Collections.Generic;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day5
{
    /// <summary>
    /// Class containing functionalities for the current day.
    /// </summary>
    public class Day : MVESIGN.NET.AdventOfCode.Day
    {
        private readonly List<string> disallowedSubstrings = null;
        private readonly List<string> vowels = null;

        /// <summary>
        /// Create an instance of the current day.
        /// </summary>
        public Day()
            : base(5)
        {
            disallowedSubstrings = "ab cd pq xy".Split(' ').ToList();
            vowels = "a e i o u".Split(' ').ToList();

            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + FileLines.Where(child => isNice(child)).Count());

            // Part two
            Console.WriteLine("Part 2: " + FileLines.Where(child => isStillNice(child)).Count());
        }

        /// <summary>
        /// Check if a child has double paired characters.
        /// </summary>
        /// <param name="child">Details of the child.</param>
        /// <returns>Returns true when the child has double paired characters, else false.</returns>
        private bool hasDoublePairs(string child)
        {
            for (int i = 0; i + 3 < child.Length; i++)
            {
                for (int j = i + 2; j + 1 < child.Length; j++)
                {
                    if (string.Equals(child.Substring(i, 2), child.Substring(j, 2)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if a child has matching characters.
        /// </summary>
        /// <param name="child">Details of the child.</param>
        /// <returns>Returns true when the child has matching characters, else false.</returns>
        private bool hasMatchingCharacter(string child)
        {
            for (int i = 0; i + 2 < child.Length; i++)
            {
                if (child[i] == child[i + 2])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether a child is nice.
        /// </summary>
        /// <param name="child">Details of the child.</param>
        /// <returns>Returns true when the child is nice, else false.</returns>
        private bool isNice(string child)
        {
            if (disallowedSubstrings.Any(disallowedSubstring => child.Contains(disallowedSubstring)))
            {
                return false;
            }

            if (child.Where(character => vowels.Contains(character.ToString())).Count() < 3)
            {
                return false;
            }


            for (int position = 0; position + 1 < child.Length; position++)
            {
                if (child[position] == child[position + 1])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether a child is still nice.
        /// </summary>
        /// <param name="child">Details of the child.</param>
        /// <returns>Returns true when the child is still nice, else false.</returns>
        private bool isStillNice(string input)
        {
            if (!hasDoublePairs(input))
            {
                return false;
            }

            return hasMatchingCharacter(input);
        }
    }
}