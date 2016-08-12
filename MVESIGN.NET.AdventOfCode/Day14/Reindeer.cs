namespace MVESIGN.NET.AdventOfCode.Day14
{
    /// <summary>
    /// Class containing details of Santa's reindeer.
    /// </summary>
    public class Reindeer
    {
        /// <summary>
        /// Whether the reindeer is resting or not.
        /// </summary>
        public bool IsResting { get; set; }

        /// <summary>
        /// Name of the reindeer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of points rewarded to the reindeer.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Number of seconds the reindeer needs to rest.
        /// </summary>
        public int RestingPeriod { get; set; }

        /// <summary>
        /// Number of seconds the reindeer is within the current period.
        /// </summary>
        public int SecondsInPeriod { get; set; }

        /// <summary>
        /// Number of kilometers the reindeer can travel per second.
        /// </summary>
        public int TravelDistance { get; set; }

        /// <summary>
        /// Number of total traveled distance.
        /// </summary>
        public int TraveledFor { get; set; }

        /// <summary>
        /// Number of seconds the reindeer can travel.
        /// </summary>
        public int TravelPeriod { get; set; }

        /// <summary>
        /// Swap the current period of the reindeer.
        /// </summary>
        public void SwapPeriod()
        {
            IsResting = !IsResting;
            SecondsInPeriod = 0;
        }

        /// <summary>
        /// Convert a string that represents the current object.
        /// </summary>
        /// <returns>Returns a string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("{0} has travelled {1} km with a total of {2} points", Name, TraveledFor, Points);
        }
    }
}