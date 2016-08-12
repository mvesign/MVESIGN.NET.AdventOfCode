namespace MVESIGN.NET.AdventOfCode.Day7
{
    /// <summary>
    /// Class containing details of an operand.
    /// </summary>
    public class Operand
    {
        /// <summary>
        /// Name of the operand.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the operand.
        /// </summary>
        public ushort? Value { get; set; }
    }
}