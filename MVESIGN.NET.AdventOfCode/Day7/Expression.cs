using System.Collections.Generic;

namespace MVESIGN.NET.AdventOfCode.Day7
{
    /// <summary>
    /// Class containing details of an expression.
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// Create an expression instance.
        /// </summary>
        public Expression()
        {
            Operands = new List<Operand>();
        }

        /// <summary>
        /// Name of the expression.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of operands within the expression.
        /// </summary>
        public List<Operand> Operands { get; set; }

        /// <summary>
        /// Value of the current operator.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Current operator value.
        /// </summary>
        public ushort? Value { get; set; }
    }
}