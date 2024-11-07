using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SquareCalculator
{
    #region Enum
    public enum ValueType
    {
        O, // Original
        V  // Variation
    }
    public enum SPOValueType
    {
        PEPs,
        DETs,
        MatchSource
    }
    #endregion Enum

    public class RangeData
    {
        private RangeChecker rangeChecker = new RangeChecker();

        public double Value { get; set; }
        public ValueType ValueType { get; set; }
        public int? VariationNo { get; set; } = null; // Nullable, null for original values

        public RangeData(double value, ValueType vType, int variationNo)
        {
            Value = value;
            ValueType = vType;
            VariationNo = variationNo;
        }

        // Method to get the actual value for display
        public double GetActualValue(bool wholeNumber)
        {
            return (wholeNumber ? Math.Truncate(Value) : Value);
        }

        // Method to get the formatted value for display
        public string GetFormattedValue(bool wholeNumber, bool formatted = true, string customValue = null)
        {
            if (formatted)
                if (customValue == null)
                    return $"{(wholeNumber ? Math.Truncate(Value) : Value)} ({ValueType.ToString()})";
                else
                    return $"{(wholeNumber ? Math.Truncate(Value) : Value)} ({customValue}) ({ValueType.ToString()})";
            else
                return $"{(wholeNumber ? Math.Truncate(Value) : Value)}";

            //return $"{(wholeNumber ? Math.Truncate(Value) : Value)} ({(customValue == null ? ValueType.ToString() : customValue)})";
            //return $"{Value} ({ValueType})";
            //return $"{Value}";
        }
    }

    public class Range
    {
        public double Value { get; set; }
        public string Column { get; set; }
        public List<RangeData> Data { get; set; }

        private RangeChecker rangeChecker = new RangeChecker();

        public Range(double value)
        {
            int columnIndex = rangeChecker.GetColumnNumber(value);
            switch (columnIndex)
            {
                case 1:
                    Data = new List<RangeData>() {
                        new RangeData(value, ValueType.O, 1),
                        new RangeData(System.Math.Round(value*10, 2), ValueType.V, 2)
                    };
                    break;
                case 2:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round(value/10, 2), ValueType.V, 1),
                        new RangeData(value, ValueType.O, 2),
                        new RangeData(System.Math.Round(value+100, 2), ValueType.V, 3)
                    };
                    break;
                case 3:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round((value/10)/10, 2), ValueType.V, 1),
                        new RangeData(System.Math.Round((value%100)/10, 2), ValueType.V, 2),
                        new RangeData(System.Math.Round((value/10), 2), ValueType.V, 3),
                        new RangeData(System.Math.Round((value%100), 2), ValueType.V, 4),
                        new RangeData(value, ValueType.O, 5)
                    };
                    break;
                case 4:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round(value/10, 2), ValueType.V, 1),
                        new RangeData(value, ValueType.O, 2)
                    };
                    break;
                case 5:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round((value%1000)/10, 2), ValueType.V, 1),
                        new RangeData(System.Math.Round(value%1000, 2), ValueType.V, 2),
                        new RangeData(value, ValueType.O, 3)
                    };
                    break;
                case 6:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round(value/10, 2), ValueType.V, 1),
                        new RangeData(value, ValueType.O, 2)
                    };
                    break;
                case 7:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round((value%10000)/10, 2), ValueType.V, 1),
                        new RangeData(System.Math.Round(value%10000, 2), ValueType.V, 2),
                        new RangeData(value, ValueType.O, 3)
                    };
                    break;
                case 8:
                    Data = new List<RangeData>() {
                        new RangeData(System.Math.Round(value/10, 2), ValueType.V, 1),
                        new RangeData(value, ValueType.O, 2)
                    };
                    break;
                case 9:
                    Data = new List<RangeData>() {
                        new RangeData(value, ValueType.O, 1)
                    };
                    break;
            }

            Column = string.Join("", "C", columnIndex.ToString());
            Value = value;
        }

        // Add a RangeData item to the column
        public void AddData(RangeData data)
        {
            Data.Add(data);
        }

        // Method to get the formatted data for display in the grid
        public string GetFormattedData()
        {
            // Sort the data by VariationNo (Originals will come first because VariationNo is null)
            var sortedData = Data.OrderBy(d => d.VariationNo).ToList();

            // Join all formatted values with a tab space between them
            //return string.Join("    ", sortedData.Select(d => d.GetFormattedValue()));
            return string.Join("\t", sortedData.Select(d => d.GetFormattedValue(false)));
        }

        //List<Range>
        public void SearchRange(double minVal, double maxVal)
        {
        }
    }

    public class SPORange
    {
        public double Value { get; set; }
        public string Column { get; set; }
    }
}