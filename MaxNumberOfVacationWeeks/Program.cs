using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution(2014, "April", "May", "Wednesday");
        }
        private static readonly bool DEBUGGING = true;
        public static int Solution(int Y, string A, string B, string W)
        {

            var days = new List<string> {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            var months = new List<string> {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };

            if (!months.Contains(A) || !months.Contains(B)) return 0;
            if (!days.Contains(W)) return 0;

            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || string.IsNullOrEmpty(W)) return 0;
            if (Y < 2001 || Y > 2099) return 0;
            var tryParseA = DateTime.TryParse(string.Format("{0} 1, {1}", A, Y), out DateTime dateA);
            var tryParseB = DateTime.TryParse(string.Format("{0} 1, {1}", B, Y), out DateTime dateB);

            if (!(tryParseA && tryParseB)) return 0;

            var daysInMonth = DateTime.DaysInMonth(Y, dateB.Month);

            dateB = dateB.AddDays(daysInMonth - 1);

            if (dateB < dateA) return 0;

            var daysUntilMonday = ((int)DayOfWeek.Monday - (int)dateA.DayOfWeek + 7) % 7;
            var nextMonday = dateA.AddDays(daysUntilMonday);
            var daysAfterSunday = (7 + ((int)dateB.DayOfWeek - (int)DayOfWeek.Sunday)) % 7;
            var previousSunday = dateB.AddDays(-1 * daysAfterSunday);

            if (DEBUGGING)
            {
                Console.WriteLine((previousSunday.Day + (DateTime.DaysInMonth(dateA.Year, dateB.Month) - nextMonday.Day)) / 7);
                Console.ReadKey();
                return 0;
            }

            return (previousSunday.Day + (DateTime.DaysInMonth(dateA.Year, dateB.Month) - nextMonday.Day)) / 7;
        }
    }
}
