namespace MVESIGN.NET.AdventOfCode.Day13
{
    /// <summary>
    /// Class containing details of one table rule.
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Gain value of the rule.
        /// </summary>
        public int Gain { get; set; }

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the related person.
        /// </summary>
        public string Related { get; set; }
    }
}