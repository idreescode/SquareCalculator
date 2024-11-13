using SquareCalculator.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquareCalculator.TabControls
{
    public partial class cntrlHours : UserControl
    {
        private HoursCalculator hoursCalculator;
        private SQR9Helper SQR9Helper;
        double TotalMinutes = 0.0;
        double RangeInHours = 0.0;

        private List<double> range180 = new List<double>();
        private List<double> range120 = new List<double>();
        private List<double> range90 = new List<double>();
        private List<double> combinedRange = new List<double>();
        public cntrlHours()
        {
            InitializeComponent();
            hoursCalculator = new HoursCalculator();
            SQR9Helper = new SQR9Helper();
            lblRanginHrsValue.Text = string.Empty;
            lblRange1DayValue.Text = string.Empty;
            lblMinutesToMidNightValue.Text = string.Empty;
            lblTotalMinutesValue.Text = string.Empty;

            SQR9Helper.SetPlaceholder(txtInput180, "Input 180");
            SQR9Helper.SetPlaceholder(txtInput120, "Input 120");
            SQR9Helper.SetPlaceholder(txtInput90, "Input 90");

            CenterAlignAllDataGridViewColumns(this);

        }

        private void btnCalculateTotalMinutes_Click(object sender, EventArgs e)
        {
            var result = hoursCalculator.CalculateRanges(dtStartDate.Value, dtStartTime.Value, dtEndDate.Value);

            lblTotalMinutesValue.Text = result.TotalMinutes.ToString();

            lblMinutesToMidNightValue.Text = result.MinutesToMidnight.ToString();

            lblRange1DayValue.Text = result.RangeMinusOneDayMinutes.ToString() + "-" + result.TotalMinutes + " min";

            double rangeInHours = Math.Round((result.TotalMinutes / 60.0), 2);

            TotalMinutes = result.TotalMinutes;

            RangeInHours = result.RangeMinusOneDayMinutes;

            lblRanginHrsValue.Text = (Math.Round(result.RangeInHours, 2).ToString() + "-" + (rangeInHours)).ToString();

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            // Get the row header cell bounds
            var rowHeaderBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, gvHours.RowHeadersWidth, e.RowBounds.Height);

            // Center the row number in the row header
            TextRenderer.DrawText(e.Graphics, rowNumber, gvHours.Font, rowHeaderBounds, SystemColors.ControlText, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

        }



        private void CenterAlignAllDataGridViewColumns(Control container)
        {
            foreach (Control control in container.Controls)
            {
                // If the control is a DataGridView, center-align all columns
                if (control is DataGridView dataGridView)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                else
                {
                    // Recursively call the function for nested containers (e.g., Panels, TabPages)
                    CenterAlignAllDataGridViewColumns(control);
                }
            }
        }

        private void btnCalculationHours_Click(object sender, EventArgs e)
        {
            // Parse values from textboxes
            combinedRange.Clear();
            if (txtInput180.Text != null && txtInput180.Text != "Input 180")
            {
                range180 = GetInputRanges(txtInput180);
                combinedRange.AddRange(range180);
            }
            if (txtInput120.Text != null && txtInput120.Text != "Input 120")
            {
                range120 = GetInputRanges(txtInput120);
                combinedRange.AddRange(range120);
            }
            if (txtInput90.Text != null && txtInput90.Text != "Input 90")
            {
                range90 = GetInputRanges(txtInput90);
                combinedRange.AddRange(range90);
            }
            combinedRange = combinedRange.Distinct().ToList();

            // Define the min and max range (example: 3089-4529.99) and variation (e.g., 10)
            double minRange = RangeInHours;
            double maxRange = TotalMinutes;
            int variation = Convert.ToInt32(numberVariation.Value);
            // Call PopulateGridWithRange to process and display the values
            PopulateGridWithRange(minRange, maxRange, variation);
            gvHours.Sort(gvHours.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        public void PopulateGridWithRange(double minRange, double maxRange, int variation)
        {
            // Clear existing rows in the grid
            gvHours.Rows.Clear();

            // Define the start date and time
            DateTime startDateTime = new DateTime(
            dtStartDate.Value.Year, dtStartDate.Value.Month, dtStartDate.Value.Day,
                dtStartTime.Value.Hour, dtStartTime.Value.Minute, dtStartDate.Value.Second);

            // Process each dataset with visual distinction

            if (range180 != null && range180.Count > 0)
            {
                ProcessDataset(range180, minRange, maxRange, variation, startDateTime, Color.LightGray);

            }
            if (range120 != null && range120.Count > 0)
            {
                ProcessDataset(range120, minRange, maxRange, variation, startDateTime, Color.White);

            }
            if (range90 != null && range90.Count > 0)
            {
                ProcessDataset(range90, minRange, maxRange, variation, startDateTime, Color.LightBlue);

            }

        }

        private void ProcessDataset(List<double> dataset, double minRange, double maxRange, int variation, DateTime startDateTime, Color rowColor)
        {
            foreach (double coreValue in dataset)
            {
                // Check if core value is within the specified range
                if (coreValue >= minRange && coreValue <= maxRange)
                {
                    // Add the core value and variation values
                    for (int i = -variation; i <= variation; i++)
                    {
                        double value = coreValue + i; // Apply variation
                        AddRowToGrid(value, startDateTime, i == 0, rowColor, combinedRange); // i == 0 indicates core value
                    }
                }
            }
        }

        private void AddRowToGrid(double totalMinutes, DateTime startDateTime, bool isCoreValue, Color rowColor, List<double> combinedRange)
        {
            // Calculate Total Hrs
            double totalHrs = Math.Round(totalMinutes / 60, 2);

            // Calculate Exact Hrs (e.g., 51 hrs 57 min)
            int exactHours = (int)(totalMinutes / 60);
            int exactMinutes = (int)(totalMinutes % 60);
            string exactHrs = $"{exactHours} hrs {exactMinutes} min";

            // Calculate Days, Hrs, Min
            int days = (int)(totalMinutes / 1440);
            int remainingMinutes = (int)(totalMinutes - days * 1440);
            int hours = remainingMinutes / 60;
            int minutes = remainingMinutes % 60;
            string daysHrsMin = $"{days}D {hours}H {minutes}M";

            // Calculate Time of Day
            DateTime endDateTime = startDateTime.AddMinutes(totalMinutes);
            string timeOfDay = endDateTime.ToString("MM/dd/yyyy hh:mm tt");

            // Format values for matching in combinedRange
            double totalHrsValueToMatch =double.Parse( RemoveNonNumeric(totalHrs.ToString()));


            double exactHrsValueToMatch = double.Parse(RemoveNonNumeric(exactHrs.ToString()));
            double daysHrsMinValueToMatch = double.Parse(RemoveNonNumeric(daysHrsMin.ToString()));

            // Add row with values to the grid
            DataGridViewRow row = new DataGridViewRow();
            row.DefaultCellStyle.BackColor = rowColor;
            row.Cells.Add(new DataGridViewTextBoxCell { Value = totalMinutes });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = totalHrs });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = exactHrs });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = daysHrsMin });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = timeOfDay });

            double[] resultArrayTotalHours = CalculateArray(totalHrs);

            // Distinguish core values from variation values visually
            if (isCoreValue)
            {
                row.Cells[0].Style.ForeColor = Color.Green;
                row.Cells[0].Style.Font = new Font(gvHours.DefaultCellStyle.Font, FontStyle.Bold);
                row.Cells[0].Style.BackColor = Color.Yellow; // Highlight Total Hrs column
            }

            // Highlight matches in yellow if found in combinedRange
            if (resultArray.Any(value => combinedRange.Contains(value)))
            {
                row.Cells[1].Style.BackColor = Color.Yellow; // Highlight Total Hrs column
            }
            if (combinedRange.Contains(exactHrsValueToMatch))
            {
                row.Cells[2].Style.BackColor = Color.Yellow; // Highlight Exact Hrs column
            }
            if (combinedRange.Contains(daysHrsMinValueToMatch))
            {
                row.Cells[3].Style.BackColor = Color.Yellow; // Highlight Days, Hrs, Min column
            }
            gvHours.Rows.Add(row);
        }


        private List<double> GetInputRanges(System.Windows.Forms.TextBox txtInput)
        {
            // Initialize an empty list to hold the parsed double values
            List<double> inputRanges = new List<double>();

            // Get the text from the TextBox
            string inputText = txtInput.Text;

            // Split the input by commas and trim any surrounding whitespace
            string[] inputParts = inputText.Split(',');

            foreach (string part in inputParts)
            {
                // Try to parse each part to a double
                if (double.TryParse(part.Trim(), out double result))
                {
                    if (!txtInput.Name.Contains("180"))
                    {
                        // Verify input in range180
                        if (range180 != null)
                        {
                            // Add to the list if parsing is successful and not found in range180
                            if (!range180.Contains(result))
                                inputRanges.Add(result);
                        }
                        else
                        {
                            inputRanges.Add(result);
                        }
                    }
                    else
                    {
                        inputRanges.Add(result);
                    }
                }
                else
                {
                    // Handle invalid input (e.g., show a message or ignore the invalid input)
                    MessageBox.Show($"Invalid input: '{part.Trim()}'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return inputRanges;
        }

        public string RemoveNonNumeric(string input)
        {
            // Use LINQ to filter out non-numeric characters
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public  double[] CalculateArray(double originalValue)
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


    }
}
