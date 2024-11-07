using System.Collections.Generic;

namespace SquareCalculator
{
    public static class Global
    {
        // List of tuples representing ranges and corresponding column numbers
        public static List<(double MinValue, double MaxValue, int ColumnNumber)> ranges = new List<(double MinValue, double MaxValue, int ColumnNumber)>
        {
            (1, 32.99, 1),
            (33, 99.99, 2),
            (100, 199.99, 3),
            (200, 999.99, 4),
            (1000, 1999.99, 5),
            (2000, 9999.99, 6),
            (10000, 19999.99, 7),
            (20000, 99999.99, 8),
            (100000, double.MaxValue, 9) // 100000 and higher
        };
    }
}