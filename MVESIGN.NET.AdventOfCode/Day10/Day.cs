using System;
using System.Text;

namespace MVESIGN.NET.AdventOfCode.Day10
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
            : base(10)
        {
            FileContent = CurrentDay.ReadAllText();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + lookAndSay(FileContent, 40).Length);

            // Part two
            Console.WriteLine("Part 2: " + lookAndSay(FileContent, 50).Length);
        }

        /// <summary>
        /// Play look-and-say.
        /// </summary>
        /// <param name="input">Input value of the game</param>
        /// <param name="sequence">Sequence of the game.</param>
        /// <returns>Returns the outgoing number of the game.</returns>
        private string lookAndSay(string input, int sequence)
        {
            for (int count = 0; count < sequence; count++)
            {
                input = lookAndSay(input);
            }

            return input;
        }

        /// <summary>
        /// Play look-and-say.
        /// </summary>
        /// <param name="input">Input value of the game</param>
        /// <returns>Returns the outgoing number of the sequence.</returns>
        private string lookAndSay(string input)
        {
            StringBuilder outcome = new StringBuilder();

            for (int position = 0, sequence = 0; position < input.Length; )
            {
                while (position + sequence < input.Length && input[position] == input[position + sequence])
                {
                    sequence++;
                }

                outcome.Append(sequence).Append(input[position]);
                position += sequence;
                sequence = 0;
            }

            return outcome.ToString();
        }
    }
}