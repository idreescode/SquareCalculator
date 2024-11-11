using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculator.Helper
{
    public class HoursCalculator
    {

        public (int TotalMinutes, int MinutesToMidnight, int RangeMinusOneDayMinutes, double RangeInHours) CalculateRanges(DateTime startDate, DateTime startTime, DateTime endDate)
        {
            // Combine start date and start time into a single DateTime object
            DateTime startDateTime = new DateTime(
                startDate.Year, startDate.Month, startDate.Day,
                startTime.Hour, startTime.Minute, startTime.Second);

            // Set the end time to 11:59 PM on the end date
            DateTime endDateTime = new DateTime(
                endDate.Year, endDate.Month, endDate.Day, 23, 59, 0);

            // Calculate total minutes between startDateTime and endDateTime
            int totalMinutes = (int)(endDateTime - startDateTime).TotalMinutes + 1;

            // Calculate minutes from the start time to midnight
            DateTime midnightStart = startDateTime.Date.AddDays(1); // Midnight on the next day
            int minutesToMidnight = (int)(midnightStart - startDateTime).TotalMinutes;

            // Calculate full days between start and end dates
            DateTime nextDayStart = midnightStart;
            DateTime previousDayEnd = endDateTime.Date;
            int fullDays = (previousDayEnd - nextDayStart).Days;

            // Calculate total minutes for the full days
            int fullDaysMinutes = fullDays * 24 * 60; // 24 hours * 60 minutes

            // Calculate total minutes up to midnight on the previous day (fully days + minutesToMidnight)
            int totalUpToPreviousDay = fullDaysMinutes + minutesToMidnight;

            // Calculate range (-1 Day): the difference between `totalUpToPreviousDay` and `totalMinutes`
            int rangeMinusOneDayMinutes = totalUpToPreviousDay;

            // Convert range to hours
            double rangeInHours = rangeMinusOneDayMinutes / 60.0;

            return (totalMinutes, minutesToMidnight, rangeMinusOneDayMinutes, rangeInHours);
        }




    }
}
