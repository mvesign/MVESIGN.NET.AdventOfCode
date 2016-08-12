using System;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day11
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
            : base(11)
        {
            FileContent = CurrentDay.ReadAllText();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            FileContent = selectNextPassword(FileContent);

            // Part one
            Console.WriteLine("Part 1: " + FileContent);

            FileContent = selectNextPassword(FileContent);

            // Part two
            Console.WriteLine("Part 2: " + FileContent);
        }

        /// <summary>
        /// Increment the value of a given password.
        /// </summary>
        /// <param name="password">Value of the password.</param>
        /// <returns>Returns the incremented value of the password.</returns>
        private string incrementPassword(string password)
        {
            var characters = password.ToCharArray();
            for (int number = password.Length - 1; number >= 0; )
            {
                if (characters[number] == 'z')
                {
                    characters[number--] = 'a';
                }
                else
                {
                    characters[number]++;
                    break;
                }
            }

            return new string(characters);
        }

        /// <summary>
        /// Check whether a given password is valid.
        /// </summary>
        /// <param name="password">Value of the password.</param>
        /// <returns>Returns true when the password is valid, else false.</returns>
        private bool isValid(string password)
        {
            if ("iol".Any(character => password.IndexOf(character) > 0))
            {
                return false;
            }

            bool hasStraight = false;
            for (int number = 0; !hasStraight && number < password.Length - 2; number++)
            {
                hasStraight |= (password[number] + 1 == password[number + 1] && password[number] + 2 == password[number + 2]);
            }

            int amountOfPairs = 0;
            for (int number = 0, previousPair = -2; amountOfPairs < 2 && number < password.Length - 1; number++)
            {
                if (password[number] == password[number + 1] && (previousPair != number - 1))
                {
                    amountOfPairs++;
                    previousPair = number;
                }
            }

            return hasStraight && amountOfPairs > 1;
        }

        /// <summary>
        /// Select the next password based on the old password
        /// </summary>
        /// <param name="password">Value of the old password.</param>
        /// <returns>Returns the new password.</returns>
        private string selectNextPassword(string password)
        {
            do
            {
                password = incrementPassword(password);
            }
            while (!isValid(password));

            return password;
        }
    }
}