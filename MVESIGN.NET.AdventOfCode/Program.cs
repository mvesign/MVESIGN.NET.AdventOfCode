using System;
using System.Configuration;

namespace MVESIGN.NET.AdventOfCode
{
    /// <summary>
    /// Class containing the main starting point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main starting point of the program.
        /// </summary>
        /// <param name="args">Details of the starting arguments.</param>
        static void Main(string[] args)
        {
            Program.ProcessDay(int.Parse(ConfigurationManager.AppSettings["CurrentDay"]));

            Console.ReadLine();
        }

        /// <summary>
        /// Process a day.
        /// </summary>
        /// <param name="numberOfDay">Number of the day.</param>
        public static void ProcessDay(int numberOfDay)
        {
            Console.WriteLine(string.Format("Process day {0}", numberOfDay));

            Day day = (Day)Activator.CreateInstance(Type.GetType(string.Format("{0}.Day{1}.Day", typeof(Program).Assembly.GetName().Name, numberOfDay), true));
            day.Process();
        }
    }
}