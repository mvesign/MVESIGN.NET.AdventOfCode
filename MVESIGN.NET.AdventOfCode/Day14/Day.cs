using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.NET.AdventOfCode.Day14
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
            : base(14)
        {
            FileLines = CurrentDay.ReadAllLines();
        }

        /// <summary>
        /// List of active reindeers.
        /// </summary>
        public List<Reindeer> Reindeers { get; set; }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public override void Process()
        {
            Reindeers = convertToReindeers();

            processRace(2503);

            // Part one
            Console.WriteLine(string.Format("Part 1: {0}", selectLeaderOfRace()));

            // Part two
            Console.WriteLine(string.Format("Part 2: {0}", Reindeers.MaxBy(reindeer => reindeer.Points)));
        }

        /// <summary>
        /// Calculate the next position for a given reindeer.
        /// </summary>
        /// <param name="reindeer">Details of the reindeer.</param>
        private void calculateNextPosition(Reindeer reindeer)
        {
            if (reindeer.IsResting && reindeer.SecondsInPeriod >= reindeer.RestingPeriod)
            {
                reindeer.SwapPeriod();
            }

            if (!reindeer.IsResting)
            {
                if (reindeer.SecondsInPeriod >= reindeer.TravelPeriod)
                {
                    reindeer.SwapPeriod();
                }
                else
                {
                    reindeer.TraveledFor += reindeer.TravelDistance;
                }
            }

            reindeer.SecondsInPeriod++;
        }

        /// <summary>
        /// Convert the current set of file lines into reindeers.
        /// </summary>
        /// <returns>Returns the converted set of reindeers.</returns>
        private List<Reindeer> convertToReindeers()
        {
            return FileLines.Select(fileLine =>
                    Regex.Match(fileLine, @"(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+) seconds.")
                        .Groups.Cast<Group>()
                        .Skip(1)
                        .Select(group => group.Value)
                        .ToArray()
                )
                .Select(reindeer => new Reindeer()
                {
                    Name = reindeer[0],
                    RestingPeriod = int.Parse(reindeer[3]),
                    TravelDistance = int.Parse(reindeer[1]),
                    TravelPeriod = int.Parse(reindeer[2])
                })
                .ToList();
        }

        /// <summary>
        /// Process the reindeer race.
        /// </summary>
        /// <param name="seconds">Number of seconds the race is in progress.</param>
        private void processRace(int seconds)
        {
            for (int period = 0; period < seconds; period++)
            {
                Reindeers.ForEach(reindeer => calculateNextPosition(reindeer));

                selectLeaderOfRace().Points++;
            }
        }

        /// <summary>
        /// Select the leading reindeer of the race in the current state.
        /// </summary>
        /// <returns>Returns the selected reindeer.</returns>
        private Reindeer selectLeaderOfRace()
        {
            return Reindeers.MaxBy(reindeer => reindeer.TraveledFor);
        }
    }
}