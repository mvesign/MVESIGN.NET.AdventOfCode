using System;
using System.IO;

namespace MVESIGN.NET.AdventOfCode
{
    /// <summary>
    /// Class containing internal general functionalities.
    /// </summary>
    internal static class Methods
    {
        /// <summary>
        /// Read all lines within a file of a given day.
        /// </summary>
        /// <param name="day">Number of the day.</param>
        /// <param name="part">Part of the day.</param>
        /// <returns>Returns the read file lines.</returns>
        public static string[] ReadAllLines(this int day, int? part = null)
        {
            return File.Exists(selectFilePath(day, part)) ? File.ReadAllLines(selectFilePath(day, part)) : null;
        }

        /// <summary>
        /// Read all content within a file of a given day.
        /// </summary>
        /// <param name="day">Number of the day.</param>
        /// <param name="part">Part of the day.</param>
        /// <returns>Returns the read file content.</returns>
        public static string ReadAllText(this int day, int? part = null)
        {
            return File.Exists(selectFilePath(day, part)) ? File.ReadAllText(selectFilePath(day, part)) : string.Empty;
        }

        /// <summary>
        /// Select the absolute file path of a given day.
        /// </summary>
        /// <param name="day">Number of the day.</param>
        /// <param name="part">Part of the day.</param>
        /// <returns>Returns the selected file path.</returns>
        private static string selectFilePath(int day, int? part)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), string.Format("Day{0}", day), "Content", string.Format("Input{0}.txt", part));
        }
    }
}