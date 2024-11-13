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


        public double[] CalculateArray(double originalValue)
        {
            // Parse original value to remove non-numeric characters
            double totalHrsValueToMatch = double.Parse(RemoveNonNumeric(originalValue.ToString()));

            // Return the array with additional calculated values
            return new double[]
            {
            originalValue,                           // Original Value
            originalValue + 100,                     // Original Value + 100
            originalValue + 1000,                    // Original Value + 1000
            originalValue + 1100,                    // Original Value + 1100
            originalValue * 10,                      // Original Value x 10
            (originalValue * 10) + 1000,             // (Original Value x 10) + 1000
            originalValue * 100,                     // Original Value x 100
            totalHrsValueToMatch                     // Parsed value without non-numeric characters
            };
        }

        public string RemoveNonNumeric(string input)
        {
            // Use LINQ to filter out non-numeric characters
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public double[] CalculateHourMinsArray(double originalValue)
        {
            // Parse original value to remove non-numeric characters
            double totalHrsValueToMatch = double.Parse(RemoveNonNumeric(originalValue.ToString()));

            // Return the array with additional calculated values
            return new double[]
            {
            originalValue,                           // Original Value
            originalValue/10,                     // Original Value + 100
            (originalValue * 10) + 1000,             // (Original Value x 10) + 1000
            totalHrsValueToMatch                     // Parsed value without non-numeric characters
            };
        }

        public  double[] CalculateTimeofDayArray(DateTime originalTime)
        {
            List<double> timeVariants = new List<double>();

            // Format original time in HHmm (24-hour format)
            string originalTimeFormatted = originalTime.ToString("hhmm");

            // Parse the original time as an integer
            if (int.TryParse(originalTimeFormatted, out int originalValue))
            {
                // Add the original value (AM)
                timeVariants.Add(originalValue);

                // Calculate PM version by adding 1200 if the time is in the AM range (i.e., < 1200)
                if (originalValue < 1200)
                {
                    int pmValue = originalValue + 1200;
                    timeVariants.Add(pmValue);
                }

                // Add +1000 version for 3-digit values (originalValue in AM range, between 0000 and 0959)
                if (originalValue < 1000)
                {
                    int plus1000Value = originalValue + 1000;
                    timeVariants.Add(plus1000Value);
                }
            }

            // Return the list as an array
            return timeVariants.ToArray();
        }


    }
}
