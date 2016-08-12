using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day8
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
            : base(8)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            int size = 0;
            int escapedSize = 0;

            FileLines.ToList().ForEach(inputLine =>
            {
                size += ((inputLine.Length - Regex.Unescape(inputLine).Length) + 2);
                escapedSize += escapeValue(inputLine).Length - inputLine.Length;
            });

            // Part one
            Console.WriteLine("Part 1: " + size);

            // Part two
            Console.WriteLine("Part 2: " + escapedSize);
        }

        /// <summary>
        /// Escape a given value.
        /// </summary>
        /// <param name="value">Value that needs to be escaped.</param>
        /// <returns>Returns the escaped value.</returns>
        private string escapeValue(string value)
        {
            StringBuilder escapedValue = new StringBuilder();
            foreach (char valueChar in value)
                escapedValue.Append(valueChar == '"' ? @"\""" : valueChar == '\\' ? "\\\\" : valueChar.ToString());

            return "\"" + escapedValue.ToString() + "\"";
        }
    }
}