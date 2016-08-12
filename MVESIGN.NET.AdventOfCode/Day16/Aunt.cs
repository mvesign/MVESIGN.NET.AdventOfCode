using System.Collections.Generic;

namespace MVESIGN.NET.AdventOfCode.Day16
{
    /// <summary>
    /// Class containing details of aunt Sue.
    /// </summary>
    public class Aunt
    {
        /// <summary>
        /// Number of compounds specified for the current aunt.
        /// </summary>
        public Dictionary<string, int> Clues { get; set; }

        /// <summary>
        /// Number of the aunt in the list.
        /// </summary>
        public int Number { get; set; }
    }
}