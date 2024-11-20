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

        public double[] CalculateTotalMintsArray(double originalValue)
        {
            // Parse original value to remove non-numeric characters
            double parsedValue = double.Parse(RemoveNonNumeric(originalValue.ToString()));
            // Generate variations based on the specified logic
            double valueWith1Prefix = double.Parse("1" + parsedValue.ToString());

            // Return an array with the calculated variations
            return new double[]
            {
                parsedValue,             // Original Value
                valueWith1Prefix
            };
        }

        public double[] CalculateTotalHoursArray(double originalValue)
        {
            // Parse original value to remove non-numeric characters
            double totalHrsValueToMatch = double.Parse(RemoveNonNumeric(originalValue.ToString()));

            // Initialize variables
            double dropFirstDigit = originalValue;

            // Check the first condition: if there are 3 digits before the decimal
            bool isThreeDigitsBeforeDecimal = originalValue >= 100;

            // If the condition is true, drop the first digit
            if (isThreeDigitsBeforeDecimal)
            {
                dropFirstDigit = double.Parse(originalValue.ToString().Substring(1)); // Drop the first digit
            }

            // Create the result array based on the condition
            if (isThreeDigitsBeforeDecimal)
            {
                return new double[]
                {
                    dropFirstDigit,                   // Drop the first digit
                    originalValue * 10,              // First variation * 10
                    originalValue * 100,             // First variation * 100
                    originalValue,                   // Original value
                    originalValue * 10,              // Original value * 10
                    originalValue + 1000             // Original value + 1000
                };
            }
            else
            {
                // Apply only the last three calculations if the first condition is false
                return new double[]
                {
                    originalValue,                   // Original value
                    originalValue * 10,              // Original value * 10
                    originalValue + 1000             // Original value + 1000
                };
            }
        }

        public double[] CalculateExactHourArray(double originalValue)
        {
            // Convert the value to a string to check its digit count
            string originalValueStr = RemoveNonNumeric(originalValue.ToString());
            int digitCount = originalValueStr.Length;

            // Initialize the result array
            List<double> results = new List<double>();

            // If the value is 5 digits
            if (digitCount == 5)
            {
                // Original value
                results.Add(originalValue);

                // Divide by 10
                results.Add(originalValue / 10);

                // Drop the first digit (e.g., 14641 -> 4641)
                double dropFirstDigit = double.Parse(originalValueStr.Substring(1));
                results.Add(dropFirstDigit);

                // Divide the dropped digit value by 10
                results.Add(dropFirstDigit / 10);
            }
            // If the value is 4 digits
            else if (digitCount == 4)
            {
                // Original value
                results.Add(originalValue);

                // Add 1 to the original value
                results.Add(originalValue + 1);

                // Divide by 10
                results.Add(originalValue / 10);

                // Add 1000 to the result of the division
                results.Add((originalValue / 10) + 1000);
            }

            // Return the result as an array
            return results.ToArray();
        }

        public double[] CalculateHourMinsArray(string originalValue)
        {
            // Parse the input string to remove all non-numeric characters
    
            double totalHrsValueToMatch = double.Parse(RemoveNonNumeric(originalValue.ToString()));

            // Standard Calculation
            double originalDividedBy10 = totalHrsValueToMatch / 10;
            double originalPlus1000 = originalDividedBy10 + 1000;

            // Alternate Calculation
            // Extract days, hours, and minutes for alternate logic
            int days = 0, hours = 0, minutes = 0;

            // Extract days (e.g., "6D")
            if (originalValue.Contains("D"))
            {
                int dIndex = originalValue.IndexOf("D");
                days = int.Parse(originalValue.Substring(0, dIndex));
                originalValue = originalValue.Substring(dIndex + 1); // Remove "6D"
            }

            // Extract hours (e.g., "2H")
            if (originalValue.Contains("H"))
            {
                int hIndex = originalValue.IndexOf("H");
                hours = int.Parse(originalValue.Substring(0, hIndex));
                originalValue = originalValue.Substring(hIndex + 1); // Remove "2H"
            }

            // Extract minutes (e.g., "41M")
            if (originalValue.Contains("M"))
            {
                int mIndex = originalValue.IndexOf("M");
                minutes = int.Parse(originalValue.Substring(0, mIndex));
            }

            // Convert to total minutes
            int totalMinutes = (days * 24 * 60) + (hours * 60) + minutes;

            // Alternate calculations
            double alternatePlus1 = totalMinutes + 1;
            double alternateDividedBy10 = totalMinutes / 10.0;

            // Return results as an array
            return new double[]
            {
                    totalHrsValueToMatch,         // Standard: Original value (numeric only)
                    originalDividedBy10,          // Standard: Original value / 10
                    originalPlus1000,             // Standard: (Original value / 10) + 1000
                    totalMinutes,                 // Alternate: Total minutes (6D161M as 6161)
                    alternatePlus1,               // Alternate: 1 + Total minutes
                    alternateDividedBy10          // Alternate: Total minutes / 10
            };
        }

        public double[] CalculateTimeofDayArray(DateTime originalTime)
        {
            List<double> timeVariants = new List<double>();

            // Format original time in hhmm (24-hour format without leading zeros)
            string originalTimeFormatted = originalTime.ToString("hmm");

            // Parse the original time as an integer
            if (int.TryParse(originalTimeFormatted, out int originalValue))
            {
                // Add the original value (AM version)
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


        public string RemoveNonNumeric(string input)
        {
            // Use LINQ to filter out non-numeric characters
            return new string(input.Where(char.IsDigit).ToArray());
        }


        public void AddGridData(List<GridData> gridList, double totalMinutes, double totalHrs, double originalExtraHours, double daysHrsMinValueToMatch, DateTime TimeofDay)
        {
            string timeofDayTimeFormatted = TimeofDay.ToString("hhmm");
            var gridData = new GridData()
            {
                TotalMints = totalMinutes,
                TotalHours = totalHrs,
                ExactHour = originalExtraHours,
                HourMins = daysHrsMinValueToMatch,
                TimeofDay = timeofDayTimeFormatted
            };

            gridList.Add(gridData);
        }

        public List<TimeData> PopulateTimeData(List<double> totalMinsArray, List<double> totalHrsArray, List<double> exactHoursArray, List<double> dayHrsMinArray, List<double> timeOfDayArray)
        {
            // Determine the largest size
            int maxRows = new[] { totalMinsArray.Count, totalHrsArray.Count, exactHoursArray.Count, dayHrsMinArray.Count, timeOfDayArray.Count }.Max();

            // Normalize arrays by repeating or padding values
            totalMinsArray = NormalizeArray(totalMinsArray, maxRows, 0.0);
            totalHrsArray = NormalizeArray(totalHrsArray, maxRows, 0.0);
            exactHoursArray = NormalizeArray(exactHoursArray, maxRows, 0.0);
            dayHrsMinArray = NormalizeArray(dayHrsMinArray, maxRows, 0.0);
            timeOfDayArray = NormalizeArray(timeOfDayArray, maxRows, 0.0);

            // Create the list to hold the rows
            List<TimeData> timeDataList = new List<TimeData>();

            // Populate the list
            for (int i = 1; i < maxRows; i++)
            {
                timeDataList.Add(new TimeData
                {
                    TotalMins = totalMinsArray[i] == 0.0 ? "" : totalMinsArray[i].ToString(),
                    TotalHrs = totalHrsArray[i] == 0.0 ? "" : totalHrsArray[i].ToString(),
                    ExactHours = exactHoursArray[i] == 0.0 ? "" : exactHoursArray[i].ToString(),
                    DayHrsMin = dayHrsMinArray[i] == 0.0 ? "" : dayHrsMinArray[i].ToString(),
                    TimeOfDay = timeOfDayArray[i] == 0.0 ? "" : timeOfDayArray[i].ToString()
                });
            }

            return timeDataList;
        }

        // Method to normalize arrays (repeat or pad values)
        private List<T> NormalizeArray<T>(List<T> array, int targetSize, T defaultValue)
        {
            List<T> result = new List<T>(targetSize);

            for (int i = 0; i < targetSize; i++)
            {
                // Repeat values if the array is smaller than targetSize
                if (i < array.Count)
                {
                    result.Add(array[i]);
                }
                else
                {
                    // Add default value if the array is smaller
                    result.Add(defaultValue);
                }
            }

            return result;
        }

    }
}
