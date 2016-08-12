using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day6
{
    /// <summary>
    /// Class containing functionalities for the current day.
    /// </summary>
    public class Day : MVESIGN.NET.AdventOfCode.Day
    {
        private int[,] brightness = new int[1000, 1000];
        private bool[,] lights = new bool[1000, 1000];
        private int totalBrightness = 0;
        private int totalLightsOn = 0;

        /// <summary>
        /// Create an instance of the current day.
        /// </summary>
        public Day()
            : base(6)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            FileLines.ToList().ForEach(inputLine =>
            {
                var groups = Regex.Match(inputLine, @"(turn on|turn off|toggle)\s([0-9]+)\,([0-9]+)\sthrough\s([0-9]+)\,([0-9]+)").Groups;

                bool? method = groups[1].Value == "turn on" ? true : groups[1].Value == "turn off" ? false : (bool?)null;
                Tuple<int, int> startPoint = new Tuple<int, int>(int.Parse(groups[2].Value), int.Parse(groups[3].Value));
                Tuple<int, int> endPoint = new Tuple<int, int>(int.Parse(groups[4].Value), int.Parse(groups[5].Value));

                for (int i = startPoint.Item1; i <= endPoint.Item1; i++)
                {
                    for (int j = startPoint.Item2; j <= endPoint.Item2; j++)
                    {
                        brightness[i, j] = !method.HasValue ? brightness[i, j] + 2 : method.Value ? brightness[i, j] + 1 : brightness[i, j] > 0 ? brightness[i, j] - 1 : brightness[i, j];
                        lights[i, j] = !method.HasValue ? !lights[i, j] : method.Value;
                    }
                }
            });

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    totalBrightness += brightness[i, j];
                    totalLightsOn += lights[i, j] ? 1 : 0;
                }
            }

            // Part one
            Console.WriteLine("Part 1: " + totalLightsOn);

            // Part two
            Console.WriteLine("Part 2: " + totalBrightness);
        }
    }
}