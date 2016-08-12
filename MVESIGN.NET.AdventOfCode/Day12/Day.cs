using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day12
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
            : base(12)
        {
            FileContent = CurrentDay.ReadAllText();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine(string.Format("Part 1: {0}", Regex.Matches(FileContent, @"[\-0-9]+").Cast<Match>().Select(number => int.Parse(number.Value)).Sum()));

            // Part two
            Console.WriteLine(string.Format("Part 2: {0}", sumBalance(JObject.Parse(FileContent))));
        }

        /// <summary>
        /// Check whether an JSON token contains the keyword "red".
        /// </summary>
        /// <param name="token">A JSON token.</param>
        /// <returns>Returns true when the JSON token contains the keyword "red", else false.</returns>
        private bool isRed(JObject token)
        {
            return token
                .Properties()
                .Select(property => property.Value).OfType<JValue>()
                .Select(item => item.Value).OfType<string>()
                .Any(item => string.Equals(item, "red", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Summarize the balance of an JSON token.
        /// </summary>
        /// <param name="jsonToken">Value of the JSON token.</param>
        /// <returns>Returns the summarized balance.</returns>
        private long sumBalance(JToken jsonToken)
        {
            if (jsonToken is JObject)
            {
                JObject jsonObject = (JObject)jsonToken;

                if (isRed(jsonObject))
                {
                    return 0;
                }

                return jsonObject.Properties().Select(property => property.Value).Sum(token => sumBalance(token));
            }
            else if (jsonToken is JArray)
            {
                return ((JArray)jsonToken).Sum(token => sumBalance(token));
            }
            else if (jsonToken is JValue)
            {
                JValue jsonValue = (JValue)jsonToken;
                return jsonValue.Value is long ? (long)jsonValue.Value : 0;
            }

            throw new InvalidOperationException(string.Format("Given token could not be converted - {0}", jsonToken));
        }
    }
}