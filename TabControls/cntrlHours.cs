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

        private List<double> range180;
        private List<double> range120;
        private List<double> range90;

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
            range180 = GetInputRanges(txtInput180);
            range120 = GetInputRanges(txtInput120);
            range90 = GetInputRanges(txtInput90);

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
            ProcessDataset(range180, minRange, maxRange, variation, startDateTime, Color.LightGray);
            ProcessDataset(range120, minRange, maxRange, variation, startDateTime, Color.White);
            ProcessDataset(range90, minRange, maxRange, variation, startDateTime, Color.LightBlue);
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
                        AddRowToGrid(value, startDateTime, i == 0, rowColor); // i == 0 indicates core value
                    }
                }
            }
        }

        private void AddRowToGrid(double totalMinutes, DateTime startDateTime, bool isCoreValue, Color rowColor)
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

            // Add row with values to the grid
            DataGridViewRow row = new DataGridViewRow();
            row.DefaultCellStyle.BackColor = rowColor;
            row.Cells.Add(new DataGridViewTextBoxCell { Value = totalMinutes });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = totalHrs });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = exactHrs });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = daysHrsMin });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = timeOfDay });

            // Distinguish core values from variation values visually
            if (isCoreValue)
            {
                row.Cells[0].Style.ForeColor = Color.Green;
                row.Cells[0].Style.Font = new Font(gvHours.DefaultCellStyle.Font, FontStyle.Bold);
            }

            gvHours.Rows.Add(row);
        }

        private List<double> GetInputRanges(TextBox txtInput)
        {
            // Initialize an empty list to hold the parsed double values
            List<double> inputRanges = new List<double>();

            // Get the text from the TextBox
            string inputText = txtInput.Text;

            // Split the input by commas and trim any surrounding whitespace
            string[] inputParts = inputText.Split(',');

            // Parse each part into a double and add to the list if valid
            foreach (string part in inputParts)
            {
                if (double.TryParse(part.Trim(), out double value))
                {
                    inputRanges.Add(value);
                }
            }

            return inputRanges;
        }



    }
}
