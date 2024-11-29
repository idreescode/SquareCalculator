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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
        private List<double> allDataSets = new List<double>();
        private List<GridData> gridList = new List<GridData>();
        private List<TimeData> timeData = new List<TimeData>();
        List<List<TimeData>> nestedTimeDataList = new List<List<TimeData>>();
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

           //// FillData();

            // Fix the left panel
            splitContainer1.FixedPanel = FixedPanel.Panel1;

            splitContainer1.SplitterDistance = 350;

            // Handle splitter moving event to prevent leftward movement


            // Ensure right panel resizes with the form
            splitContainer1.Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        }

        private void SplitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            int fixedWidth = 350; // Fixed width for the left panel
            if (e.SplitX != fixedWidth)
            {
                e.Cancel = true; // Prevent the splitter from moving
            }
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
            ClearList();

            // Load ranges from textboxes
            if (!string.IsNullOrWhiteSpace(txtInput180.Text) && txtInput180.Text != "Input 180")
            {
                range180 = GetInputRanges(txtInput180);
            }
            if (!string.IsNullOrWhiteSpace(txtInput120.Text) && txtInput120.Text != "Input 120")
            {
                range120 = GetInputRanges(txtInput120);
            }
            if (!string.IsNullOrWhiteSpace(txtInput90.Text) && txtInput90.Text != "Input 90")
            {
                range90 = GetInputRanges(txtInput90);
            }

            // Reset allDataSets based on the checkbox selection
            if (chkShowMatch180Only.Checked)
            {
                combinedRange = range180;
                range120 = null; // Clear other lists
                range90 = null;
                allDataSets = new List<double>(range180 ?? new List<double>()); // Update allDataSets
            }
            else if (chkShowMatch120Only.Checked)
            {
                combinedRange = range120;
                range180 = null; // Clear other lists
                range90 = null;
                allDataSets = new List<double>(range120 ?? new List<double>()); // Update allDataSets
            }
            else if (chkShowMatch90Only.Checked)
            {
                combinedRange = range90;
                range180 = null; // Clear other lists
                range120 = null;
                allDataSets = new List<double>(range90 ?? new List<double>()); // Update allDataSets
            }
            else
            {
                // Default case: Combine all ranges if no specific checkbox is selected
                combinedRange = new List<double>();
                allDataSets.Clear();

                if (range180 != null)
                {
                    combinedRange.AddRange(range180);
                    allDataSets.AddRange(range180);
                }
                if (range120 != null)
                {
                    combinedRange.AddRange(range120);
                    allDataSets.AddRange(range120);
                }
                if (range90 != null)
                {
                    combinedRange.AddRange(range90);
                    allDataSets.AddRange(range90);
                }
            }

            // Define the min and max range (example: 3089-4529.99) and variation (e.g., 10)
            double minRange = RangeInHours;
            double maxRange = TotalMinutes;

            // Filter combinedRange based on min and max range
            combinedRange = combinedRange?
                .Where(x => x >= minRange && x <= maxRange) // Keep only values within the range
                .Distinct()                                // Ensure uniqueness
                .ToList();

            // Update allDataSets after range filtering
            allDataSets = allDataSets
                .Distinct()
                .ToList();

            int variation = Convert.ToInt32(numberVariation.Value);

            // Populate grid with the filtered range
            PopulateGridWithRange(minRange, maxRange, variation);

            // Sort the grid for better readability
            gvHours.Sort(gvHours.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            // Highlight cells based on matching tolerance
            HighlightMatchingCells(gvHours, allDataSets ?? new List<double>(), double.Parse(nbrMatchTolerance.Value.ToString()));
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
            double[] resultArraysHrsMin = hoursCalculator.CalculateHourMinsArray(daysHrsMin);
            double[] resultArraysTimeofDay = hoursCalculator.CalculateTimeofDayArray(DateTime.Parse(timeOfDay));



            // Distinguish core values from variation values visually
            bool matchRow = false;
            if (isCoreValue || resultArrayTotalMints.Any(combinedRange.Contains))
            {
                matchRow = true;
                row.Cells[0].Style.ForeColor = Color.Black;
                row.Cells[0].Style.Font = new Font(gvHours.DefaultCellStyle.Font, FontStyle.Bold);
                row.Cells[0].Style.BackColor = Color.LightGreen; // Highlight Total Hrs column
            }

            // Highlight matches in yellow if found in combinedRange
            if (resultArrayTotalHours.Any(combinedRange.Contains))
            {
                matchRow = true;
                row.Cells[1].Style.BackColor = Color.Yellow; // Highlight Total Hrs column
            }
            if (resultArrayExtraHours.Any(combinedRange.Contains))
            {
                matchRow = true;
                row.Cells[2].Style.BackColor = Color.Yellow; // Highlight Exact Hrs column
            }
            if (resultArraysHrsMin.Any(combinedRange.Contains))
            {
                matchRow = true;
                row.Cells[3].Style.BackColor = Color.Yellow; // Highlight Days, Hrs, Min column
            }
            if (resultArraysTimeofDay.Any(combinedRange.Contains))
            {
                matchRow = true;
                row.Cells[4].Style.BackColor = Color.Yellow; // Highlight Time of Day 
            }

            if ((chkShowMatchOnly.Checked || chkShowMatch180Only.Checked || chkShowMatch120Only.Checked || chkShowMatch90Only.Checked) && matchRow)

            {
                row.Tag = "ParentRow";
                gvHours.Rows.Add(row);

                List<TimeData> variations = hoursCalculator.PopulateTimeData(
                    resultArrayTotalMints.ToList(),
                    resultArrayTotalHours.ToList(),
                    resultArrayExtraHours.ToList(),
                    resultArraysHrsMin.ToList(),
                    resultArraysTimeofDay.ToList()
                );
                nestedTimeDataList.Add(variations);

                hoursCalculator.AddGridData(gridList, totalMinutes, totalHrs, exactHours, daysHrsMinValueToMatch, DateTime.Parse(timeOfDay));

            }
            else if (!chkShowMatchOnly.Checked && !chkShowMatch180Only.Checked && !chkShowMatch120Only.Checked && !chkShowMatch90Only.Checked)
            {
                row.Tag = "ParentRow";
                gvHours.Rows.Add(row);

                List<TimeData> variations = hoursCalculator.PopulateTimeData(
                    resultArrayTotalMints.ToList(),
                    resultArrayTotalHours.ToList(),
                    resultArrayExtraHours.ToList(),
                    resultArraysHrsMin.ToList(),
                    resultArraysTimeofDay.ToList()
                );
                nestedTimeDataList.Add(variations);

                hoursCalculator.AddGridData(gridList, totalMinutes, totalHrs, exactHours, daysHrsMinValueToMatch, DateTime.Parse(timeOfDay));
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
                        if (range180 != null && chkShowMatch180Only.Checked)
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

        private void HighlightMatchingCells(DataGridView dataGridView, List<double> allDataSets, double tolerance = 1.0)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Skip the new row placeholder (if AllowUserToAddRows is true)
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dataGridView.Columns[cell.ColumnIndex].Name;

                    // Apply different logic for a specific column
                    string cellVlaue = cell.Value?.ToString();

                    if (columnName == "colTimeOfDay") // Replace with the actual column name
                    {
                        cellVlaue = Convert.ToDateTime(cell.Value.ToString()).ToString("hhmm");
                    }
                    // Check if the cell value is numeric
                    if (double.TryParse(hoursCalculator.RemoveNonNumeric(cellVlaue), out double cellValue))
                    {
                        // Calculate the tolerance range
                        double minValue = cellValue - tolerance;
                        double maxValue = cellValue + tolerance;

                        // Check if any value in allDataSets falls within the range
                        if (allDataSets.Any(datasetValue => datasetValue >= minValue && datasetValue <= maxValue))
                        {
                            // Highlight the cell if there's a match
                            cell.Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            // Optionally, reset the cell color if no match is found
                            cell.Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void gvHours_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex < 0 || e.RowIndex >= gvHours.Rows.Count)
                return;

            DataGridViewRow clickedRow = gvHours.Rows[e.RowIndex];

            // Skip interaction if the clicked row is a child row
            if (clickedRow.Tag != null && clickedRow.Tag.ToString() == "ChildRow")
            {
                return; // Do nothing for child rows
            }

            // Check if the row is already expanded
            if (clickedRow.Tag == "ParentRow")
            {
                // Expand the row by adding child rows
                AddChildRows(clickedRow, e.RowIndex);

                // Mark the row as expanded
                clickedRow.Tag = "Expanded";
            }
            else
            {
                // Collapse the row by removing child rows
                RemoveChildRows(clickedRow, e.RowIndex);

                // Mark the row as collapsed
                clickedRow.Tag = "ParentRow";
            }
        }

        private void AddChildRows(DataGridViewRow parentRow, int rowIndex)
        {
            // Example data for variations (replace this with your actual variations)
            try
            {
                List<TimeData> variations = nestedTimeDataList[rowIndex];
                // Insert child rows
                foreach (var variation in variations)
                {
                    DataGridViewRow childRow = new DataGridViewRow();
                    childRow.DefaultCellStyle.BackColor =
                        Color.FromArgb(144, 133, 133); // Different background color for child rows
                    childRow.Cells.Add(new DataGridViewTextBoxCell { Value = variation.TotalMins });
                    childRow.Cells.Add(new DataGridViewTextBoxCell { Value = variation.TotalHrs });
                    childRow.Cells.Add(new DataGridViewTextBoxCell { Value = variation.ExactHours });
                    childRow.Cells.Add(new DataGridViewTextBoxCell { Value = variation.DayHrsMin });
                    childRow.Cells.Add(new DataGridViewTextBoxCell { Value = variation.TimeOfDay });

                    // Mark the row as a child row using the Tag property
                    childRow.Tag = "ChildRow";



                    gvHours.Rows.Insert(rowIndex + 1, childRow);
                    rowIndex++;
                }

            }
            catch
            {
                MessageBox.Show("Please collapse the expanded row before proceeding.", "Row Expanded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void RemoveChildRows(DataGridViewRow parentRow, int rowIndex)
        {
            // Remove all rows below the parent row until another parent row is encountered
            while (rowIndex + 1 < gvHours.Rows.Count && gvHours.Rows[rowIndex + 1].DefaultCellStyle.BackColor == Color.FromArgb(144, 133, 133))
            {
                gvHours.Rows.RemoveAt(rowIndex + 1);
            }
        }

        private void ClearList()
        {
            if (combinedRange != null)
                combinedRange.Clear();

            if (gridList != null)
                gridList.Clear();

            if (allDataSets != null)
                allDataSets.Clear();

            if (nestedTimeDataList != null)
                nestedTimeDataList.Clear();

            if (timeData != null)
                timeData.Clear();


        }

        private void chkShowMatch180Only_CheckedChanged(object sender, EventArgs e)
        {
            EnsureSingleCheck((System.Windows.Forms.CheckBox)sender);
        }

        private void chkShowMatch120Only_CheckedChanged(object sender, EventArgs e)
        {
            EnsureSingleCheck((System.Windows.Forms.CheckBox)sender);
        }

        private void chkShowMatch90Only_CheckedChanged(object sender, EventArgs e)
        {
            EnsureSingleCheck((System.Windows.Forms.CheckBox)sender);
        }
        private void EnsureSingleCheck(System.Windows.Forms.CheckBox senderCheckBox)
        {
            // List of all checkboxes
            System.Windows.Forms.CheckBox[] checkboxes = { chkShowMatch180Only, chkShowMatch120Only, chkShowMatch90Only, chkShowMatchOnly };

            // Loop through each checkbox
            foreach (var checkbox in checkboxes)
            {
                // Uncheck all other checkboxes except the one clicked
                if (checkbox != senderCheckBox)
                {
                    checkbox.Checked = false;
                }
            }

            if (senderCheckBox.CheckState == CheckState.Checked)
                senderCheckBox.Checked = true;
            if (senderCheckBox.CheckState == CheckState.Unchecked)
                senderCheckBox.Checked = false;


            btnCalculationHours_Click(null, null);
        }


        private void FilterRowsByCellColor(DataGridView gridView)
        {
            // List to store rows that meet the condition
            List<DataGridViewRow> rowsToKeep = new List<DataGridViewRow>();
            List<(int RowIndex, int ColumnIndex)> indices = new List<(int RowIndex, int ColumnIndex)>();

            // Iterate through each row in the grid
            foreach (DataGridViewRow row in gridView.Rows)
            {
                int lightGreenCount = 0;

                // Count how many cells in this row have LightGreen background color
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.Yellow)
                    {
                        lightGreenCount++;
                        indices.Add((row.Index, cell.ColumnIndex)); // Collect indices of cells
                    }
                }

                // Keep the row if more than two cells have LightGreen background
                if (lightGreenCount >= 2)
                {
                    rowsToKeep.Add(row);
                }
            }

            // Change the color of specific cells in the collected indices
            foreach (var (rowIndex, columnIndex) in indices)
            {
                gridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.LightGreen;
            }

            // Remove all rows not in the keep list
            for (int i = gridView.Rows.Count - 1; i >= 0; i--)
            {
                if (!rowsToKeep.Contains(gridView.Rows[i]))
                {
                    gridView.Rows.RemoveAt(i);
                }
            }
        }


        private void chkShowMatch2plusOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowMatch2plusOnly.Checked)
            {
                FilterRowsByCellColor(gvHours);
            }
            else
            {
                btnCalculationHours_Click(null, null);
            }

        }

        private void chkShowMatchOnly_CheckedChanged(object sender, EventArgs e)
        {
            EnsureSingleCheck((System.Windows.Forms.CheckBox)sender);

        }

        private void FillData()
        {
            ///Set the start date(e.g., October 20, 2024)
            dtStartDate.Value = new DateTime(2024, 10, 20);

            // Set the select time (e.g., 8:32:00 PM)
            dtStartTime.Value = DateTime.Today.AddHours(20).AddMinutes(32); // Set time for 8:32 PM

            // Set the end date (e.g., October 23, 2024)
            dtEndDate.Value = new DateTime(2024, 10, 23);

            txtInput180.Text = "10,100,1000,3000,3500,4000";
        }
    }
}
