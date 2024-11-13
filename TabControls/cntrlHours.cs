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

             //Set the start date (e.g., October 20, 2024)
            dtStartDate.Value = new DateTime(2024, 10, 20);

            // Set the select time (e.g., 8:32:00 PM)
            dtStartTime.Value = DateTime.Today.AddHours(20).AddMinutes(32); // Set time for 8:32 PM

            // Set the end date (e.g., October 23, 2024)
            dtEndDate.Value = new DateTime(2024, 10, 23);

            txtInput180.Text = "4.3, 8.3, 15.7, 23.7, 35.1, 47.1, 62.5, 78.5, 97.8, 117.8, 141.2, 165.2, 192.6, 220.6, 252.0, 284.0, 319.3, 355.3, 394.7, 434.7, 478.1, 522.1, 569.5, 617.5, 668.8, 720.8, 776.2, 832.2, 891.6, 951.6, 1015.0, 1079.0, 1146.3, 1214.3, 1285.7, 1357.7, 1433.1, 1509.1, 1588.5, 1668.5, 1751.8, 1835.8, 1923.2, 2011.2, 2102.6, 2194.6, 2290.0, 2386.0, 2485.3, 2585.3, 2688.7, 2792.7, 2900.1, 3008.1, 3119.5, 3231.5, 3346.8, 3462.8, 3582.2, 3702.2, 3825.6, 3949.6, 4077.0, 4205.0, 4336.3, 4468.3, 4603.7, 4739.7, 4879.1, 5019.1, 5162.5, 5306.5, 5453.8, 5601.8, 5753.2, 5905.2, 6060.6, 6216.6, 6376.0, 6536.0, 6699.3, 6863.3, 7030.7, 7198.7, 7370.1, 7542.1, 7717.5, 7893.5, 8072.8, 8252.8, 8436.2, 8620.2, 8807.6, 8995.6, 9187.0, 9379.0, 9574.3, 9770.3, 9969.7, 10169.7, 10373.1, 10577.1, 10784.5, 10992.5, 11203.8, 11415.8, 11631.2, 11847.2, 12066.6, 12286.6, 12510.0, 12734.0, 12961.3, 13189.3, 13420.7, 13652.7, 13888.1, 14124.1, 14363.5, 14603.5, 14846.8, 15090.8, 15338.2, 15586.2, 15837.6, 16089.6, 16345.0, 16601.0, 16860.3, 17120.3, 17383.7, 17647.7, 17915.1, 18183.1, 18454.5, 18726.5, 19001.8, 19277.8, 19557.2, 19837.2, 20120.6, 20404.6, 20692.0, 20980.0, 21271.3, 21563.3, 21858.7, 22154.7, 22454.1, 22754.1, 23057.5, 23361.5, 23668.8, 23976.8, 24288.2, 24600.2, 24915.6, 25231.6, 25551.0, 25871.0, 26194.3, 26518.3, 26845.7, 27173.7, 27505.1, 27837.1, 28172.5, 28508.5, 28847.8, 29187.8, 29531.2, 29875.2, 30222.6, 30570.6, 30922.0, 31274.0, 31629.3, 31985.3, 32344.7, 32704.7, 33068.1, 33432.1, 33799.5, 34167.5, 34538.8, 34910.8, 35286.2, 35662.2, 36041.6, 36421.6, 36805.0, 37189.0, 37576.3, 37964.3, 38355.7, 38747.7, 39143.1, 39539.1, 39938.5, 40338.5, 40741.8, 41145.8, 41553.2, 41961.2, 42372.6, 42784.6, 43200.0, 43616.0, 44035.3, 44455.3, 44878.7, 45302.7, 45730.1, 46158.1, 46589.5, 47021.5, 47456.8, 47892.8, 48332.2, 48772.2, 49215.6, 49659.6";

       
        
        }

        private void btnCalculateTotalMinutes_Click(object sender, EventArgs e)
        {
            var result = hoursCalculator.CalculateRanges(dtStartDate.Value, dtStartTime.Value, dtEndDate.Value);

            lblTotalMinutesValue.Text = result.TotalMinutes.ToString();

            lblMinutesToMidNightValue.Text = result.MinutesToMidnight.ToString();

            lblRange1DayValue.Text = result.RangeMinusOneDayMinutes.ToString() + " - " + result.TotalMinutes + " min";

            double rangeInHours = Math.Round((result.TotalMinutes / 60.0), 2);

            TotalMinutes = result.TotalMinutes;

            RangeInHours = result.RangeMinusOneDayMinutes;

            lblRanginHrsValue.Text = (Math.Round(result.RangeInHours, 2).ToString() + " - " + (rangeInHours)).ToString();

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
                ProcessDataset(range180, minRange, maxRange, variation, startDateTime, Color.White);

            }
            if (range120 != null && range120.Count > 0)
            {
                ProcessDataset(range120, minRange, maxRange, variation, startDateTime, Color.LightGray);

            }
            if (range90 != null && range90.Count > 0)
            {
                ProcessDataset(range90, minRange, maxRange, variation, startDateTime, Color.FromArgb(169, 169, 169));

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
            double orginalExtraHours = double.Parse(exactHours + "." + exactMinutes);

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
            double totalHrsValueToMatch = double.Parse(hoursCalculator.RemoveNonNumeric(totalHrs.ToString()));
            double exactHrsValueToMatch = double.Parse(hoursCalculator.RemoveNonNumeric(exactHrs.ToString()));
            double daysHrsMinValueToMatch = double.Parse(hoursCalculator.RemoveNonNumeric(daysHrsMin.ToString()));

            // Add row with values to the grid
            DataGridViewRow row = new DataGridViewRow();
            row.DefaultCellStyle.BackColor = rowColor;
            row.Cells.Add(new DataGridViewTextBoxCell { Value = totalMinutes });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = totalHrs });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = exactHrs });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = daysHrsMin });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = timeOfDay });

            double[] resultArrayTotalMints = hoursCalculator.CalculateTotalMintsArray(totalMinutes);
            double[] resultArrayTotalHours = hoursCalculator.CalculateTotalHoursArray(totalHrs);
            double[] resultArrayExtraHours = hoursCalculator.CalculateExactHourArray(orginalExtraHours);
            double[] resultArraysHrsMin = hoursCalculator.CalculateHourMinsArray(daysHrsMinValueToMatch);
            double[] resultArraysTimeofDay = hoursCalculator.CalculateTimeofDayArray(DateTime.Parse(timeOfDay));

            // Distinguish core values from variation values visually
            bool matchRow = false;
            if (isCoreValue || resultArrayTotalMints.Any(value => combinedRange.Contains(value)))
            {
                matchRow = true;
                row.Cells[0].Style.ForeColor = Color.Black;
                row.Cells[0].Style.Font = new Font(gvHours.DefaultCellStyle.Font, FontStyle.Bold);
                row.Cells[0].Style.BackColor = Color.Yellow; // Highlight Total Hrs column
            }

            // Highlight matches in yellow if found in combinedRange
            if (resultArrayTotalHours.Any(value => combinedRange.Contains(value)))
            {
                matchRow = true;
                row.Cells[1].Style.BackColor = Color.Yellow; // Highlight Total Hrs column
            }
            if (resultArrayExtraHours.Any(value => combinedRange.Contains(value)))
            {
                matchRow = true;
                row.Cells[2].Style.BackColor = Color.Yellow; // Highlight Exact Hrs column
            }
            if (resultArraysHrsMin.Any(value => combinedRange.Contains(value)))
            {
                matchRow = true;
                row.Cells[3].Style.BackColor = Color.Yellow; // Highlight Days, Hrs, Min column
            }
            if (resultArraysTimeofDay.Any(value => combinedRange.Contains(value)))
            {
                matchRow = true;
                row.Cells[4].Style.BackColor = Color.Yellow; // Highlight Time of Day 
            }

            if (!chkShowMatchOnly.Checked || matchRow)
            {
                gvHours.Rows.Add(row);

            }
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
    }
}
