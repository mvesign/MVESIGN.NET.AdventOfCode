using System;
using System.Collections.Generic;
using System.Linq;

namespace MVESIGN.NET.AdventOfCode.Day7
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
            : base(7)
        {
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            // Part one
            Console.WriteLine("Part 1: " + evaluateLines(CurrentDay.ReadAllLines(1).ToList()));

            // Part two
            Console.WriteLine("Part 2: " + evaluateLines(CurrentDay.ReadAllLines(2).ToList()));
        }

        /// <summary>
        /// Evaluate a given set of lines.
        /// </summary>
        /// <param name="lines">List of lines.</param>
        /// <returns>Returns the evaluated value.</returns>
        private ushort? evaluateLines(List<string> lines)
        {
            List<Expression> wires = new List<Expression>();

            lines.ForEach(input =>
            {
                var inputParts = input.Split(new[] { " -> " }, StringSplitOptions.None);
                var expressionParts = inputParts[0].Split(' ');

                Expression expression = new Expression() { Name = inputParts[1] };

                if (expressionParts.Length == 3)
                {
                    expression.Operands.Add(new Operand() { Name = expressionParts[0] });
                    expression.Operands.Add(new Operand() { Name = expressionParts[2] });
                    expression.Operator = expressionParts[1];
                }
                else if (expressionParts.Length == 2)
                {
                    expression.Operands.Add(new Operand() { Name = expressionParts[1] });
                    expression.Operator = expressionParts[0];
                }
                else
                    expression.Operands.Add(new Operand() { Name = expressionParts[0] });

                if (expressionParts.Length > 0)
                    wires.Add(expression);
            });

            while (evaluateAll(wires) > 0)
            {
                List<Expression> wiresDone = wires.Where(wire => wire.Value.HasValue).ToList();

                wires.Where(wire => !wire.Value.HasValue).ToList().ForEach(wire =>
                {
                    wire.Operands.ForEach(operand =>
                    {
                        wiresDone.ForEach(wireDone =>
                        {
                            operand.Value = operand.Name == wireDone.Name ? wireDone.Value : operand.Value;
                        });
                    });
                });
            }

            return wires.FirstOrDefault(wire => wire.Name == "a").Value;
        }

        /// <summary>
        /// Evaluate all wired expressions.
        /// </summary>
        /// <param name="wires">List of wired expressions.</param>
        /// <returns>Returns the evaluated value.</returns>
        private int evaluateAll(List<Expression> wires)
        {
            wires.Where(wire => !wire.Value.HasValue).ToList().ForEach(wire =>
            {
                wire.Operands.ForEach(operand =>
                {
                    ushort value;
                    operand.Value = ushort.TryParse(operand.Name, out value) ? value : operand.Value;
                });

                if (wire.Operands.All(operand => operand.Value.HasValue))
                {
                    wire.Value = evaluate(wire.Operator, wire.Operands);
                }
            });

            return wires.Count(a => !a.Value.HasValue);
        }

        /// <summary>
        /// Evaluate an action based on a given list of operands.
        /// </summary>
        /// <param name="action">Value of the action.</param>
        /// <param name="operands">List of operands.</param>
        /// <returns>Returns the evaluated value.</returns>
        private ushort evaluate(string action, List<Operand> operands)
        {
            if (operands.Count == 2)
            {
                if (action == "AND")
                {
                    return (ushort)(operands[0].Value.Value & operands[1].Value.Value);
                }
                if (action == "OR")
                {
                    return (ushort)(operands[0].Value.Value | operands[1].Value.Value);
                }
                if (action == "LSHIFT")
                {
                    return (ushort)(operands[0].Value.Value << operands[1].Value.Value);
                }
                if (action == "RSHIFT")
                {
                    return (ushort)(operands[0].Value.Value >> operands[1].Value.Value);
                }
            }
            else if (operands.Count == 1)
            {
                return action == "NOT" ? (ushort)(~operands[0].Value.Value) : operands[0].Value.Value;
            }

            return 0;
        }
    }
}