namespace MVESIGN.NET.AdventOfCode
{
    /// <summary>
    /// Class containing functionalities for the current day.
    /// </summary>
    public abstract class Day
    {
        /// <summary>
        /// Create an instance of the current day.
        /// </summary>
        /// <param name="currentDay">Number of the current day.</param>
        public Day(int currentDay)
        {
            CurrentDay = currentDay;
        }

        /// <summary>
        /// Number of the current day.
        /// </summary>
        public int CurrentDay { get; set; }

        /// <summary>
        /// Content of the current day.
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// Content lines of the current day.
        /// </summary>
        public string[] FileLines { get; set; }

        /// <summary>
        /// Process the current day.
        /// </summary>
        public abstract void Process();
    }
}