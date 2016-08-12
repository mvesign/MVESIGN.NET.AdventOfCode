using System;
using System.Security.Cryptography;
using System.Text;

namespace MVESIGN.NET.AdventOfCode.Day4
{
    /// <summary>
    /// Class containing functionalities for the current day.
    /// </summary>
    public class Day : MVESIGN.NET.AdventOfCode.Day
    {
        private static MD5 md5 = null;

        /// <summary>
        /// Create an instance of the current day.
        /// </summary>
        public Day()
            : base(4)
        {
            md5 = MD5.Create();

            FileContent = CurrentDay.ReadAllText();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + computeHash(5));

            // Part two
            Console.WriteLine("Part 2: " + computeHash(6));
        }

        /// <summary>
        /// Compute the hash untill it starts with a given amount of zeros.
        /// </summary>
        /// <param name="amountOfZeros">Amount of zeros.</param>
        /// <returns>Returns the amount of executes computes.</returns>
        private int computeHash(int amountOfZeros)
        {
            int number = 0;
            for (; true; number++)
            {
                if (BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(string.Format("{0}{1}", FileContent, number))))
                    .Replace("-", "")
                    .StartsWith(new String('0', amountOfZeros))
                )
                {
                    break;
                }
            }

            return number;
        }
    }
}