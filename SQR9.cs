using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SquareCalculator
{
    public partial class SQR9 : Form
    {
        private List<Range> range180;
        private List<Range> range120;
        private List<Range> range90;
        private List<Range> rangeSPO180;
        private List<Range> rangeSPO120;
        private List<Range> rangeSPO90;


        private List<(string colName, List<double> inputRange)> spoCustomSearch;
        private static List<int> numberList = new List<int>
        {
            1, 10, 11, 100, 101, 110, 111, 1000, 1001, 1010, 1011, 1100, 1101, 1110, 1111, 10000, 10001, 10010, 10011,
            11000, 11001, 11010, 11011, 100000, 100001, 100010, 100011
        };

        public SQR9()
        {
            InitializeComponent();
            this.Resize += new EventHandler(SQR9_Resize);
        }
        private void SQR9_Load(object sender, System.EventArgs e)
        {
            //Clear controls
            ClearControls();
            ClearControls("SPO");
            BindMEDropdown();

            SQR9_Resize(null, null);
        }
        private void SQR9_Resize(object sender, EventArgs e)
        {
            // Define padding and spacing constants
            int padding = 10;
            int buttonWidth = 100; // Width of the Button
            int textBoxHeight = 20; // Height of the TextBox
            int cButtonWidth = 40; // Width of the "C" button

            // Resize the TabControl to fit the entire form, minus padding
            tabControl.SetBounds(padding, padding, this.ClientSize.Width - 2 * padding, this.ClientSize.Height - 2 * padding);

            // Get the reference to the selected tab page
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab != null)
            {
                if (selectedTab.Name == "tabPage1")  // Assuming "tab1" is the first tab
                {
                    // Tab 1 logic
                    // Calculate the width of each DataGridView
                    int totalWidth = (selectedTab.ClientSize.Width - (padding * 2)) - cButtonWidth;
                    int dgvWidth = (totalWidth / 3) - padding;

                    // Calculate the height for the DataGridView
                    int rowHeight = selectedTab.ClientSize.Height - 2 * padding;

                    // Position for the DataGridView, TextBox, and Button
                    int currentX = padding;
                    foreach (var dgvId in new[] { "180", "120", "90" })
                    {
                        DataGridView dgv = selectedTab.Controls.Find($"dgView{dgvId}", true).FirstOrDefault() as DataGridView;
                        System.Windows.Forms.TextBox tb = selectedTab.Controls.Find($"txtInput{dgvId}", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                        System.Windows.Forms.Button btn = selectedTab.Controls.Find($"btnProcessInput{dgvId}", true).FirstOrDefault() as System.Windows.Forms.Button;

                        if (dgv != null && tb != null && btn != null)
                        {
                            // Set bounds for the DataGridView
                            dgv.SetBounds(currentX, padding + textBoxHeight + padding, dgvWidth, rowHeight - textBoxHeight - 2 * padding);

                            // Set bounds for the TextBox
                            tb.SetBounds(currentX, padding, dgvWidth - buttonWidth - padding, textBoxHeight);

                            // Set bounds for the Button
                            btn.SetBounds(currentX + tb.Width + padding, padding, buttonWidth, textBoxHeight);

                            // Adjust the width of the visible columns in the DataGridView
                            AdjustDataGridViewColumns(dgv);

                            // Update the X position for the next DataGridView
                            currentX += dgvWidth + padding;
                        }
                    }

                    // Position the "C" button
                    System.Windows.Forms.Button btnClear = selectedTab.Controls.Find("btnClear", true).FirstOrDefault() as System.Windows.Forms.Button;
                    if (btnClear != null)
                    {
                        btnClear.SetBounds(currentX - 5, padding, cButtonWidth, textBoxHeight);
                    }
                }
                else if (selectedTab.Name == "tabPage2")  // Assuming "tab2" is the second tab
                {
                    // Tab 2 logic

                    // First row: Position the controls (textboxes, labels, combobox, button)
                    int currentY = padding;

                    foreach (var controlId in new[] { "label3", "txtInputSD", "txtInputSearch", "label1", "cmbME", "label2", "txtTolerance", "chkNoDecimals", "btnSearch" })  // Update control IDs as per your form
                    {
                        Control ctrl = selectedTab.Controls.Find(controlId, true).FirstOrDefault();

                        if (ctrl != null)
                        {
                            // Example positioning, adjust as needed
                            ctrl.SetBounds(padding, currentY, 150, textBoxHeight);
                            padding += ctrl.Width + 10;
                        }
                    }

                    padding = 10;

                    // Second row: Position the DataGridView
                    DataGridView dgvTab2 = selectedTab.Controls.Find("dgViewSearch", true).FirstOrDefault() as DataGridView;
                    if (dgvTab2 != null)
                    {
                        dgvTab2.SetBounds(padding, currentY + textBoxHeight + padding, selectedTab.ClientSize.Width - 2 * padding, selectedTab.ClientSize.Height - currentY - textBoxHeight - 2 * padding);
                    }
                }
                else if (selectedTab.Name == "tabPage3")  // Assuming "tabPage3" is the third tab
                {
                    // Define padding and spacing constants
                    padding = 10;
                    int controlHeight = 20; // Adjust based on the height of the top row controls

                    // Calculate the starting Y position for the DataGridView, below the top two rows of controls
                    int currentY = padding + (controlHeight * 2);  // Assuming 2 rows of controls

                    // Get reference to the DataGridView
                    DataGridView dgvTab3 = selectedTab.Controls.Find("dgViewSPO", true).FirstOrDefault() as DataGridView;

                    if (dgvTab3 != null)
                    {
                        // Resize the DataGridView to fit the remaining space
                        dgvTab3.SetBounds(padding, currentY + padding,
                            selectedTab.ClientSize.Width - 2 * padding,
                            selectedTab.ClientSize.Height - currentY - 2 * padding);
                    }
                }

            }
        }

        #region Control Events

        private void ProcessInput(System.Windows.Forms.TextBox inputTextBox, ref List<Range> rangeList, DataGridView dataGridView, string rangeType, string prefix = "")
        {
            rangeList = new List<Range>();
            List<double> inputRanges = GetInputRanges(inputTextBox);

            if (inputRanges.Count == 0) return;

            foreach (double range in inputRanges.OrderBy(x => x))
            {
                rangeList.Add(new Range(range));
            }

            // Display the data in the DataGridView
            PopulateGrid(ref rangeList, dataGridView, rangeType, prefix);
        }

        private void btnProcessInput_Click(object sender, System.EventArgs e)
        {
            var buttonName = (sender as System.Windows.Forms.Button).Name;

            // Remove 'ref' from the dictionary, just specify the range lists directly
            if (buttonName == "btnProcessInput180")
            {
                ProcessInput(txtInput180, ref range180, dgView180, "180");
            }
            else if (buttonName == "btnProcessInput120")
            {
                ProcessInput(txtInput120, ref range120, dgView120, "120");
            }
            else if (buttonName == "btnProcessInput90")
            {
                ProcessInput(txtInput90, ref range90, dgView90, "90");
            }
            else if (buttonName == "btnPriceAngleDataSort180")
            {
                ProcessInput(txtInputPAD180, ref rangeSPO180, dgViewPAD180, "180", "PAD");
            }
            else if (buttonName == "btnPriceAngleDataSort120")
            {
                ProcessInput(txtInputPAD120, ref rangeSPO120, dgViewPAD120, "120", "PAD");
            }
            else if (buttonName == "btnPriceAngleDataSort90")
            {
                ProcessInput(txtInputPAD90, ref rangeSPO90, dgViewPAD90, "90", "PAD");
            }
        }

        private void dgView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if the cell is not a header and has content
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null)
            {
                // Get the column name (header text)
                DataGridView grid = sender as DataGridView;
                string cellHeader = grid.Columns[e.ColumnIndex].HeaderText;
                //if (grid.Name.Equals("dgViewSearch") && (cellHeader.Equals("Initial Forecast") || cellHeader.Equals("F-SD") || cellHeader.Equals("Final Forecast")))
                if (grid.Name.Equals("dgViewSearch") && (cellHeader.Equals("Initial Forecast") || cellHeader.Equals("F-SD")))
                    return;

                // Get cell value and split it into parts using '\t' as the delimiter
                string cellValue = e.Value.ToString();
                string[] parts;
                if (cellValue.Contains('\t'))
                    parts = cellValue.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                else
                    parts = cellValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                //string[] parts = cellValue.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Handle the cell painting
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                // Set fonts and colors
                Font regularFont = new Font(e.CellStyle.Font, FontStyle.Regular);
                //Font variationFont = new Font(e.CellStyle.Font, FontStyle.Regular);
                Brush regularBrush = Brushes.Black;
                Brush variationBrush = Brushes.Blue;
                Brush redBrush = Brushes.Red;

                //Console.WriteLine($"Does {testValue1} match a range in the list? {IsInRange(testValue1)}");


                // Calculate the total width of all parts
                float totalTextWidth = 0;
                foreach (string part in parts)
                {
                    // Measure the string without the "(O)" or "(V)" tag and trim the extra spaces
                    totalTextWidth += e.Graphics.MeasureString(part.Replace("(O)", "").Replace("(V)", "").Trim(), regularFont).Width + 5;

                    //Font font = part.Contains("(O)") ? originalFont : variationFont;
                    //totalTextWidth += e.Graphics.MeasureString(part.Replace("(O)", "").Replace("(V)", "").Trim(), font).Width + 5;
                    //totalTextWidth += e.Graphics.MeasureString(part.Replace("(O)", "").Replace("(V)", "").Trim(), originalFont).Width + 5;
                }

                // Determine if the total text width is less than the cell width
                float xPosition = e.CellBounds.Left;
                if (totalTextWidth < e.CellBounds.Width)
                {
                    // Center the text if it's smaller than the cell width
                    xPosition = e.CellBounds.Left + (e.CellBounds.Width - totalTextWidth) / 2;
                }

                float yPosition = e.CellBounds.Top + (e.CellBounds.Height - e.Graphics.MeasureString(cellValue, e.CellStyle.Font).Height) / 2;

                // Iterate through the parts and draw them accordingly
                foreach (string part in parts)
                {
                    if (part.Contains("(O)"))  // Original value
                    {
                        string originalValue = part.Replace("(O)", "").Trim();
                        if ((grid.Name.Equals("dgView180") || grid.Name.Equals("dgView120") || grid.Name.Equals("dgView90")) && IsInRange(double.Parse(originalValue)))
                            e.Graphics.DrawString(originalValue, regularFont, redBrush, xPosition, yPosition);
                        else
                            e.Graphics.DrawString(originalValue, regularFont, regularBrush, xPosition, yPosition);
                        xPosition += e.Graphics.MeasureString(originalValue, regularFont).Width + 3;
                    }
                    else if (part.Contains("(V)"))  // Variation value
                    {
                        string variationValue = part.Replace("(V)", "").Trim();
                        if ((grid.Name.Equals("dgView180") || grid.Name.Equals("dgView120") || grid.Name.Equals("dgView90")) && IsInRange(double.Parse(variationValue)))
                            e.Graphics.DrawString(variationValue, regularFont, redBrush, xPosition, yPosition);
                        else
                            e.Graphics.DrawString(variationValue, regularFont, variationBrush, xPosition, yPosition);
                        xPosition += e.Graphics.MeasureString(variationValue, regularFont).Width + 3;

                        //e.Graphics.DrawString(variationValue, variationFont, variationBrush, xPosition, yPosition);
                        //xPosition += e.Graphics.MeasureString(variationValue, variationFont).Width + 3;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();

            //clear list as well
            range180 = range120 = range90 = null;
            if (spoCustomSearch != null)
                spoCustomSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var ranges = GetInputRanges(txtInputSearch);
            if (ranges[0] > 32 || ranges[1] > 32)
            {
                MessageBox.Show("Input range cannot be greater than 32");
                return;
            }

            var (min, max) = GetMinMaxSearchValue(ranges[0], ranges[1]);

            // Flatten all RangeData objects across all ranges
            var foundRange = range180.SelectMany(r => r.Data).AsEnumerable();

            if (min <= max)
                foundRange = foundRange.Where(d => d.Value >= min && d.Value <= max);
            else
            {
                double ME = double.Parse(cmbME.SelectedValue.ToString());

                // Case 2: minValue is greater than ME, we are wrapping around
                foundRange = foundRange.Where(d =>
                    (d.Value >= min && d.Value <= ME) ||  // Part 1: Values between minValue and ME (higher range)
                    (d.Value >= 1 && d.Value <= max)      // Part 2: Values between 1 and maxValue (lower range)
                ).ToList();
            }

            // Exclude the input value and order the results
            foundRange = foundRange.OrderBy(i => i.Value).ToList();

            // Search within RangeData and exclude the input value
            //var foundRange = range180
            //    .SelectMany(r => r.Data)  // Flatten all RangeData objects across all ranges
            //    .Where(d => d.Value >= min && d.Value <= max)  // Filter by the range and exclude input value
            //    .OrderBy(i => i.Value)
            //    .ToList();

            if (foundRange != null)
            {
                //clear all rows
                dgViewSearch.Rows.Clear();

                // Subscribe to CellPainting event
                dgViewSearch.CellPainting += dgView_CellPainting;

                // Add all required rows at once to match the count of foundRange
                dgViewSearch.Rows.Add(foundRange.Count());

                // Iterate through each column group and add data to the corresponding column in the grid
                int rwIndex = 0;
                foreach (var rangeData in foundRange)
                {
                    //dgViewSearch.Rows[rwIndex].Cells[0].Value = rangeData.Value;
                    var formattedDate180 = double.Parse(rangeData.GetFormattedValue(chkNoDecimals.Checked, false));
                    dgViewSearch.Rows[rwIndex].Cells[0].Value = rangeData.GetFormattedValue(chkNoDecimals.Checked);
                    var (minTol, maxTol) = GetMinMaxWithTolerance(rangeData.Value, double.Parse(txtTolerance.Text));
                    var rangeCount_InitialForecast = 0;

                    #region DET 180

                    // Search within RangeData and exclude the input value
                    var foundRangeDET180 = range180
                        .SelectMany(r => r.Data)  // Flatten all RangeData objects across all ranges
                        .Where(d => d.Value >= minTol && d.Value <= maxTol && d.Value != rangeData.Value)  // Filter by the range and exclude input value
                        .OrderBy(i => i.Value)
                        .ToList();

                    if (foundRangeDET180 != null)
                    {
                        dgViewSearch.Rows[rwIndex].Cells[1].Value = string.Join(",", foundRangeDET180.Select(d => d.GetFormattedValue(chkNoDecimals.Checked)));
                        rangeCount_InitialForecast += foundRangeDET180
                            .Select(d => d.GetActualValue(chkNoDecimals.Checked))
                            .Distinct()
                            .Where(value => value.Equals(formattedDate180))
                            .Count();
                    }

                    #endregion DET 180

                    #region DET 120
                    if (range120 != null)
                    {
                        // Search within RangeData and exclude the input value
                        var foundRangeDET120 = range120
                            .SelectMany(r => r.Data)  // Flatten all RangeData objects across all ranges
                            .Where(d => d.Value >= minTol && d.Value <= maxTol)  // Filter by the range and exclude input value
                            .OrderBy(i => i.Value)
                            .ToList();

                        if (foundRangeDET120 != null)
                        {
                            dgViewSearch.Rows[rwIndex].Cells[2].Value = string.Join(",", foundRangeDET120.Select(d => d.GetFormattedValue(chkNoDecimals.Checked)));
                            rangeCount_InitialForecast += foundRangeDET120
                                .Select(d => d.GetActualValue(chkNoDecimals.Checked))
                                .Distinct()
                                .Where(value => value.Equals(formattedDate180))
                                .Count();
                        }
                    }
                    #endregion DET 120

                    #region DET 90
                    if (range90 != null)
                    {
                        // Search within RangeData and exclude the input value
                        var foundRangeDET90 = range90
                            .SelectMany(r => r.Data)  // Flatten all RangeData objects across all ranges
                            .Where(d => d.Value >= minTol && d.Value <= maxTol)  // Filter by the range and exclude input value
                            .OrderBy(i => i.Value)
                            .ToList();

                        if (foundRangeDET90 != null)
                        {
                            dgViewSearch.Rows[rwIndex].Cells[3].Value = string.Join(",", foundRangeDET90.Select(d => d.GetFormattedValue(chkNoDecimals.Checked)));
                            rangeCount_InitialForecast += foundRangeDET90
                                .Select(d => d.GetActualValue(chkNoDecimals.Checked))
                                .Distinct()
                                .Where(value => value.Equals(formattedDate180))
                                .Count();
                        }
                    }
                    #endregion DET 90

                    #region Inital Forcast
                    if (rangeCount_InitialForecast > 0)
                    {
                        //dgViewSearch.Rows[rwIndex].Cells[4].Value = string.Format("{0} ({1})", formattedDate180, rangeCount_InitialForecast);
                        dgViewSearch.Rows[rwIndex].Cells[4].Value = string.Format("{0}", formattedDate180);

                        // Get the current font from the cell
                        var cellFont = dgViewSearch.Rows[rwIndex].Cells[4].Style.Font;

                        // Check if the font is not null before creating a new one
                        if (cellFont != null)
                        {
                            // Create a new font with the same family and size but with the Regular style
                            dgViewSearch.Rows[rwIndex].Cells[4].Style.Font = new Font(cellFont.FontFamily, cellFont.Size,
                                (rangeCount_InitialForecast == 1 ? FontStyle.Regular : (rangeCount_InitialForecast == 2 ? FontStyle.Italic : FontStyle.Bold)));
                        }
                        else
                        {
                            // Fallback: If no font was set earlier, you can create a new default font
                            dgViewSearch.Rows[rwIndex].Cells[4].Style.Font = new Font("Tahoma", 9,
                                (rangeCount_InitialForecast == 1 ? FontStyle.Regular : (rangeCount_InitialForecast == 2 ? FontStyle.Italic : FontStyle.Bold)));
                        }
                    }
                    #endregion Inital Forcast

                    #region FSD
                    if (rangeCount_InitialForecast > 0)
                    {
                        var calculatedFSD = Calculate_FSD(formattedDate180, rangeCount_InitialForecast);
                        dgViewSearch.Rows[rwIndex].Cells[5].Value = calculatedFSD;

                        var (minFSD, maxFSD) = GetMinMaxSearchValue(calculatedFSD, calculatedFSD);
                        //if(Math.Truncate(Value))

                        #region Final Forcast
                        if (rangeCount_InitialForecast > 0)
                        {
                            StringBuilder finalForecast = new StringBuilder();
                            if (range180 != null)
                                finalForecast.Append(string.Join(",", range180.SelectMany(r => r.Data).Where(d => d.Value >= minFSD && d.Value <= maxFSD).Select(d => d.GetFormattedValue(false, true, "180"))));

                            if (range120 != null)
                            {
                                if (finalForecast.Length > 0)
                                    finalForecast.Append(",");

                                finalForecast.Append(string.Join(",", range120.SelectMany(r => r.Data).Where(d => d.Value >= minFSD && d.Value <= maxFSD).Select(d => d.GetFormattedValue(false, true, "120"))));
                            }

                            if (range90 != null)
                            {
                                if (finalForecast.Length > 0)
                                    finalForecast.Append(",");

                                finalForecast.Append(string.Join(",", range90.SelectMany(r => r.Data).Where(d => d.Value >= minFSD && d.Value <= maxFSD).Select(d => d.GetFormattedValue(false, true, "90"))));
                            }

                            //finalForecast.Append(string.Join(",", foundRangeDET180.Where(d => d.Value >= minFSD && d.Value <= maxFSD).Select(d => d.GetFormattedValue(false, true, "180"))));
                            //finalForecast.Append(string.Join(",", foundRangeDET120.Where(d => d.Value >= minFSD && d.Value <= maxFSD).Select(d => d.GetFormattedValue(false, true, "120"))));
                            //finalForecast.Append(string.Join(",", foundRangeDET90.Where(d => d.Value >= minFSD && d.Value <= maxFSD).Select(d => d.GetFormattedValue(false, true, "90"))));

                            dgViewSearch.Rows[rwIndex].Cells[6].Value = finalForecast.ToString();
                        }
                        #endregion Final Forcast
                    }
                    #endregion FSD

                    rwIndex++;
                }

                // Adjust the width of all columns based on their content
                dgViewSearch.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Adjust the width of the visible columns in the DataGridView
                AdjustDataGridViewColumns(dgViewSearch);
            }
        }

        private void chkNoDecimals_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQR9_Resize(null, null);
        }

        private void btnSearchSPO_Click(object sender, EventArgs e)
        {
            var inputSPO = double.Parse(txtInputSPO.Text);
            var minSPO = rdoAdd.Checked ? inputSPO : (inputSPO - double.Parse(txtInputSPORange.Text));
            var maxSPO = rdoAdd.Checked ? (inputSPO + double.Parse(txtInputSPORange.Text)) : inputSPO;

            //clear rows
            dgViewSPO.Rows.Clear();

            //var lstSPO = new List<SPORange>();
            var lstPEPs = new List<(string colName, double matchedRange)>();
            if (rangeSPO180 != null && chkInclude180.Checked)
            {
                // Create a list of tuples with the correct type based on your filtering criteria
                var filteredValues = rangeSPO180
                    .SelectMany(r => r.Data)
                    .Where(d => d.Value >= minSPO && d.Value <= maxSPO)
                    .Select(d => (colName: "180", matchedRange: d.Value)) // Use tuples here
                    .ToList();

                // Add the filtered tuples to lstPEPs
                lstPEPs.AddRange(filteredValues);
            }
            if (rangeSPO120 != null && chkInclude120.Checked)
            {
                // Create a list of tuples with the correct type based on your filtering criteria
                var filteredValues = rangeSPO120
                    .SelectMany(r => r.Data)
                    .Where(d => d.Value >= minSPO && d.Value <= maxSPO)
                    .Select(d => (colName: "120", matchedRange: d.Value)) // Use tuples here
                    .ToList();

                // Add the filtered tuples to lstPEPs
                lstPEPs.AddRange(filteredValues);
            }
            if (rangeSPO90 != null && chkInclude90.Checked)
            {
                // Create a list of tuples with the correct type based on your filtering criteria
                var filteredValues = rangeSPO90
                    .SelectMany(r => r.Data)
                    .Where(d => d.Value >= minSPO && d.Value <= maxSPO)
                    .Select(d => (colName: "90", matchedRange: d.Value)) // Use tuples here
                    .ToList();

                // Add the filtered tuples to lstPEPs
                lstPEPs.AddRange(filteredValues);
            }

            if (lstPEPs.Count == 0)
                return;

            //limit as per range
            if (txtRangeSPO.Text != string.Empty)
            {
                string[] range = txtRangeSPO.Text.Split(',');
                lstPEPs = lstPEPs
                    .Where(item => item.matchedRange >= double.Parse(range[0]) && item.matchedRange <= double.Parse(range[1]))
                    .ToList();
            }

            //add rows
            dgViewSPO.Rows.Add(lstPEPs.Count());

            // Exclude the input value and order the results
            var sortedValues = lstPEPs.OrderBy(i => i.matchedRange).ToList();

            int rwIndex = 0;
            foreach (var d in sortedValues)
            {
                dgViewSPO.Rows[rwIndex].Cells[0].Value = string.Format("{0} ({1})", d.matchedRange, d.colName);

                #region Change Font of PEPs on (180)
                if (d.colName.Equals("180"))
                {
                    // Get the current font from the cell
                    var cellFont = dgViewSPO.Rows[rwIndex].Cells[0].Style.Font;
                    if (cellFont != null)
                        dgViewSPO.Rows[rwIndex].Cells[0].Style.Font = new Font(cellFont.FontFamily, cellFont.Size, FontStyle.Bold);
                    else
                        dgViewSPO.Rows[rwIndex].Cells[0].Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
                }
                #endregion Change Font of PEPs on (180)

                //DETs
                var detVal = System.Math.Abs(System.Math.Round(d.matchedRange - inputSPO, 2));
                dgViewSPO.Rows[rwIndex].Cells[1].Value = detVal;

                //Match Source
                double matchSource = default(double);
                var (minSPOTol, maxSPOTol) = GetMinMaxWithTolerance(detVal, double.Parse(txtDetTolerance.Text));
                switch (d.colName)
                {
                    case "180":
                        // Create a list of tuples with the correct type based on your filtering criteria
                        var filteredValues180 = rangeSPO180
                            .SelectMany(r => r.Data)
                            .Where(r => r.Value >= minSPOTol && r.Value <= maxSPOTol)
                            .Select(r => (colName: "180", matchedRange: r.Value)) // Use tuples here
                            .OrderBy(r => r.matchedRange)
                            .FirstOrDefault();

                        // Check if the matchedRange field is not the default value
                        if (filteredValues180.matchedRange != default(double)) // assuming matchedRange is a double
                        {
                            matchSource = filteredValues180.matchedRange;
                            dgViewSPO.Rows[rwIndex].Cells[2].Value = string.Format("{0} ({1})", filteredValues180.matchedRange, filteredValues180.colName);
                        }
                        break;
                    case "120":
                        // Create a list of tuples with the correct type based on your filtering criteria
                        var filteredValues120 = rangeSPO120
                            .SelectMany(r => r.Data)
                            .Where(r => r.Value >= minSPOTol && r.Value <= maxSPOTol)
                            .Select(r => (colName: "120", matchedRange: r.Value)) // Use tuples here
                            .OrderBy(r => r.matchedRange)
                            .FirstOrDefault();

                        // Check if the matchedRange field is not the default value
                        if (filteredValues120.matchedRange != default(double)) // assuming matchedRange is a double
                        {
                            matchSource = filteredValues120.matchedRange;
                            dgViewSPO.Rows[rwIndex].Cells[2].Value = string.Format("{0} ({1})", filteredValues120.matchedRange, filteredValues120.colName);
                        }
                        break;
                    case "90":
                        // Create a list of tuples with the correct type based on your filtering criteria
                        var filteredValues90 = rangeSPO90
                            .SelectMany(r => r.Data)
                            .Where(r => r.Value >= minSPOTol && r.Value <= maxSPOTol)
                            .Select(r => (colName: "90", matchedRange: r.Value)) // Use tuples here
                            .OrderBy(r => r.matchedRange)
                            .FirstOrDefault();

                        // Check if the matchedRange field is not the default value
                        if (filteredValues90.matchedRange != default(double)) // assuming matchedRange is a double
                        {
                            matchSource = filteredValues90.matchedRange;
                            dgViewSPO.Rows[rwIndex].Cells[2].Value = string.Format("{0} ({1})", filteredValues90.matchedRange, filteredValues90.colName);
                        }
                        break;
                }

                //Old DET
                if (matchSource != default(double)) // assuming matchSource is a double
                {
                    dgViewSPO.Rows[rwIndex].Cells[3].Value = loadnSearchInputs(matchSource);
                }

                rwIndex++;
            }

            // Adjust the width of all columns based on their content
            dgViewSPO.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Adjust the width of the visible columns in the DataGridView
            AdjustDataGridViewColumns(dgViewSPO);
        }

        // Handle the RowHeaderMouseClick event
        private void dgViewSearch_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the clicked row index
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0)  // Ensure a valid row is clicked
            {
                // Get the current row
                DataGridViewRow row = dgViewSearch.Rows[rowIndex];

                // Check if the first cell's background color is gray (assuming all cells will have the same background color)
                bool isGray = row.Cells[0].Style.BackColor == Color.LightGray;

                // Define the colors to apply
                Color targetColor = isGray ? dgViewSearch.DefaultCellStyle.BackColor : Color.LightGray;

                // Iterate through each cell in the clicked row and apply the target color
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = targetColor;
                }
            }
        }

        #endregion Control Events

        #region Private Methods

        private void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText)
        {
            // Set the initial placeholder
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            // Handle the GotFocus event to remove the placeholder when the user starts typing
            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            // Handle the LostFocus event to show the placeholder when the TextBox is empty
            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void ClearControls()
        {


            foreach (var dgvId in new[] { "180", "120", "90" })
            {
                (this.Controls.Find($"txtInput{dgvId}", true).FirstOrDefault() as System.Windows.Forms.TextBox).Clear();
                DataGridView dgv = this.Controls.Find($"dgView{dgvId}", true).FirstOrDefault() as DataGridView;

                dgv.RowHeadersVisible = false;
                dgv.Rows.Clear();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.Visible = false;
                }

            }
            //TabControl2
            txtInputSD.Text = txtInputSearch.Text = string.Empty;
            txtTolerance.Text = "1";
            cmbME.SelectedIndex = cmbME.Items.Count - 1;  // Select the last item

            //dgViewSearch.RowHeadersVisible = false;
            // Subscribe to the event (this can be done in the designer or programmatically)
            dgViewSearch.RowHeaderMouseClick += dgViewSearch_RowHeaderMouseClick;
            dgViewSearch.Rows.Clear();

            //TabControl3
            txtInputSPO.Text = txtInputSPORange.Text = txtRangeSPO.Text = txtSPO180.Text = txtSPO120.Text = txtSPO90.Text = txtSPO45.Text = string.Empty;
            txtDetTolerance.Text = txtOdDet.Text = "3";
            rdoAdd.Checked = true;  // Select Add
            chkSPO_120.Checked = chkSPO_90.Checked = chkSPO_45.Checked = false;

            dgViewSPO.RowHeadersVisible = false;
            dgViewSPO.Rows.Clear();


            // Set placeholder for a TextBox


            SetPlaceholder(txtInput180, "Input 180");
            SetPlaceholder(txtInput120, "Input 120");
            SetPlaceholder(txtInput90, "Input 90");


            SetPlaceholder(txtInputSearch, "Search Range");
            SetPlaceholder(txtInputSD, "Starting Date");

            SetPlaceholder(txtInputSPO, "Starting Point");
            SetPlaceholder(txtInputSPORange, "Search Range");

            SetPlaceholder(txtSPO180, "180");
            SetPlaceholder(txtSPO120, "120");
            SetPlaceholder(txtSPO90, "90");
            SetPlaceholder(txtSPO45, "45");
        }

        private void ClearControls(string clearType = "")
        {

            if (clearType == "SPO")
                foreach (var dgvId in new[] { "180", "120", "90" })
                {
                    (this.Controls.Find($"txtInput{dgvId}", true).FirstOrDefault() as System.Windows.Forms.TextBox).Clear();
                    DataGridView dgv = this.Controls.Find($"dgViewPAD{dgvId}", true).FirstOrDefault() as DataGridView;

                    dgv.RowHeadersVisible = false;
                    dgv.Rows.Clear();
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        column.Visible = false;
                    }

                }
           
            //TabControl2
            txtInputSD.Text = txtInputSearch.Text = string.Empty;
            txtTolerance.Text = "1";
            cmbME.SelectedIndex = cmbME.Items.Count - 1;  // Select the last item

            //dgViewSearch.RowHeadersVisible = false;
            // Subscribe to the event (this can be done in the designer or programmatically)
            dgViewSearch.RowHeaderMouseClick += dgViewSearch_RowHeaderMouseClick;
            dgViewSearch.Rows.Clear();

            //TabControl3
            txtInputSPO.Text = txtInputSPORange.Text = txtRangeSPO.Text = txtSPO180.Text = txtSPO120.Text = txtSPO90.Text = txtSPO45.Text = string.Empty;
            txtDetTolerance.Text = txtOdDet.Text = "3";
            rdoAdd.Checked = true;  // Select Add
            chkSPO_120.Checked = chkSPO_90.Checked = chkSPO_45.Checked = false;

            dgViewSPO.RowHeadersVisible = false;
            dgViewSPO.Rows.Clear();


            // Set placeholder for a TextBox

            if (clearType == "SPO")
            {
                SetPlaceholder(txtInputPAD180, "Input 180");
                SetPlaceholder(txtInputPAD120, "Input 120");
                SetPlaceholder(txtInputPAD90, "Input 90");
            }
           

            SetPlaceholder(txtInputSearch, "Search Range");
            SetPlaceholder(txtInputSD, "Starting Date");

            SetPlaceholder(txtInputSPO, "Starting Point");
            SetPlaceholder(txtInputSPORange, "Search Range");

            SetPlaceholder(txtSPO180, "180");
            SetPlaceholder(txtSPO120, "120");
            SetPlaceholder(txtSPO90, "90");
            SetPlaceholder(txtSPO45, "45");
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
                    if (!txtInput.Name.Contains("180") && !txtInput.Name.Equals("txtInputSearch"))
                    {
                        //verify input in Range180
                        if (range180 != null)
                        {
                            // Add to the list if parsing is successful and not found in 180ranges
                            if (!range180.Any(i => i.Value.Equals(result)))
                                inputRanges.Add(result);
                        }
                        else
                            inputRanges.Add(result);
                    }
                    else
                        inputRanges.Add(result);
                }
                else
                {
                    // Handle invalid input (e.g., show a message or ignore the invalid input)
                    MessageBox.Show($"Invalid input: '{part.Trim()}'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

            return inputRanges;
        }

        private void PopulateGrid(ref List<Range> ranges, System.Windows.Forms.DataGridView dataGrid, string rangeId, string GridType = "")
        {
            //clear all rows
            dataGrid.Rows.Clear();

            // Subscribe to CellPainting event
            dataGrid.CellPainting += dgView_CellPainting;

            // Group the ranges by the Column property
            var groupedByColumn = ranges.GroupBy(r => r.Column).ToDictionary(g => g.Key, g => g.ToList());

            // Determine the maximum number of rows needed (i.e., the largest group size)
            int maxRowCount = groupedByColumn.Values.Max(g => g.Count());

            // Ensure the DataGridView has enough rows
            while (dataGrid.Rows.Count < maxRowCount)
            {
                dataGrid.Rows.Add();
            }

            // Iterate through each column group and add data to the corresponding column in the grid
            foreach (var group in groupedByColumn)
            {
                string column = group.Key;

                if (GridType == "PAD")
                {
                    column = $"{column}{GridType}";
                }

                for (int i = 0; i < group.Value.Count; i++)
                {

                    dataGrid.Rows[i].Cells[column + "_" + rangeId].Value = group.Value[i].GetFormattedData();


                }
            }

            #region Hide Unused Columns

            //Hide un-used columns {format: C1 (1-32.99)}
            var allColumns = Global.ranges.Select(c => new
            {
                id = $"C{c.ColumnNumber}",
                name = $"C{c.ColumnNumber} ({c.MinValue}-{c.MaxValue})"
            }).ToList();

            // Find columns that do not have records by comparing all columns against columns with records
            List<string> columnsWithoutRecords = allColumns
                .Where(c => !groupedByColumn.Keys.ToList().Contains(c.id))  // Compare id from allColumns with keys in groupedByColumn
                .Select(c => c.id)  // Select the id of the columns without records
                .ToList();

            //Show columns have data
            if (GridType == "PAD")
            {
                groupedByColumn.Keys.ToList().ForEach(column => dataGrid.Columns[column + GridType + "_" + rangeId].Visible = true);
            }
            else
            {
                groupedByColumn.Keys.ToList().ForEach(column => dataGrid.Columns[column + "_" + rangeId].Visible = true);
            }
            //Iterate and hide column

            if (GridType == "PAD")
            {
                columnsWithoutRecords.ForEach(column => dataGrid.Columns[column + GridType + "_" + rangeId].Visible = false);
            }
            else
            {
                columnsWithoutRecords.ForEach(column => dataGrid.Columns[column + "_" + rangeId].Visible = false);
            }


            #endregion Hide Unused Columns

            // Adjust the width of all columns based on their content
            dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Adjust the width of the visible columns in the DataGridView
            AdjustDataGridViewColumns(dataGrid);
        }

        private (double minValue, double maxValue) GetMinMaxSearchValue(double minValue, double maxValue)
        {
            //return (Math.Floor(minValue), Math.Ceiling(maxValue) - 0.01);
            //return (Math.Floor(minValue), Math.Ceiling(maxValue) + 0.99);
            return (Math.Floor(minValue), Math.Floor(maxValue) + 0.99);
        }

        private (double minValue, double maxValue) GetMinMaxWithTolerance(double input, double tolerance)
        {
            double minValue = input - tolerance;
            double maxValue = input + tolerance;

            // Format the values to two decimal places
            minValue = Math.Round(minValue, 2);
            maxValue = Math.Round(maxValue, 2);

            // Adjust max value to end with .99
            //maxValue = Math.Floor(maxValue) + 0.99;

            return (minValue, maxValue);
        }

        private void BindMEDropdown()
        {
            List<int> comboBoxItems = new List<int> { 28, 29, 30, 31, 32 };
            cmbME.DataSource = comboBoxItems;
            cmbME.SelectedItem = 32;
        }

        private double Calculate_FSD(double rangeValue, double intialForecast)
        {
            var fsd = (rangeValue - (double.Parse(txtInputSD.Text)));
            if (fsd >= 0)
                return fsd;
            else
            {
                //var val1 = (double.Parse(cmbME.SelectedValue.ToString()) - double.Parse(txtInputSD.Text)) + 1;
                var val1 = double.Parse(cmbME.SelectedValue.ToString()) - double.Parse(txtInputSD.Text);
                var val2 = (rangeValue - 1) + 1;
                return (val1 + val2);
            }
        }

        public static bool IsInRange(double input)
        {
            // Get the integer part of the input double
            int intPart = (int)Math.Floor(input);

            // Check if the integer part exists in the number list
            if (numberList.Contains(intPart))
            {
                // Check if the decimal part is within the range of 0.0 to 0.99
                double decimalPart = input - intPart;
                return decimalPart >= 0.0 && decimalPart < 1.0;
            }
            return false;
        }

        private string loadnSearchInputs(double matchSource)
        {
            if (spoCustomSearch == null)
            {
                if (chkSPO_180.Checked || chkSPO_120.Checked || chkSPO_90.Checked || chkSPO_45.Checked)
                {
                    spoCustomSearch = new List<(string colName, List<double> inputRange)>();

                    if (chkSPO_180.Checked || chkSPO_120.Checked || chkSPO_90.Checked || chkSPO_45.Checked)
                        spoCustomSearch = new List<(string colName, List<double> inputRange)>();

                    if (chkSPO_180.Checked && !string.IsNullOrEmpty(txtSPO180.Text))
                    {
                        // Split the input by commas and trim any surrounding whitespace
                        spoCustomSearch.Add(("180", txtSPO180.Text.Split(',').Select(i => double.Parse(i)).ToList()));
                    }
                    if (chkSPO_120.Checked && !string.IsNullOrEmpty(txtSPO120.Text))
                    {
                        // Split the input by commas and trim any surrounding whitespace
                        spoCustomSearch.Add(("120", txtSPO120.Text.Split(',').Select(i => double.Parse(i)).ToList()));
                    }
                    if (chkSPO_90.Checked && !string.IsNullOrEmpty(txtSPO90.Text))
                    {
                        // Split the input by commas and trim any surrounding whitespace
                        spoCustomSearch.Add(("90", txtSPO90.Text.Split(',').Select(i => double.Parse(i)).ToList()));
                    }
                    if (chkSPO_45.Checked && !string.IsNullOrEmpty(txtSPO45.Text))
                    {
                        // Split the input by commas and trim any surrounding whitespace
                        spoCustomSearch.Add(("45", txtSPO45.Text.Split(',').Select(i => double.Parse(i)).ToList()));
                    }
                }
            }

            if (spoCustomSearch != null)
            {
                if (spoCustomSearch.Count > 0)
                {
                    StringBuilder oldDet = new StringBuilder();
                    var (minMSTol, maxMSTol) = GetMinMaxWithTolerance(matchSource, double.Parse(txtOdDet.Text));
                    // Flatten the ranges and pair them with their column names
                    oldDet.Append(string.Join(",",
                        spoCustomSearch
                            .SelectMany(tuple => tuple.inputRange
                                .Where(d => d >= minMSTol && d <= maxMSTol)
                                .Select(d => string.Format("{0} ({1})", d, tuple.colName))
                            )
                        )
                    );
                    return oldDet.ToString();
                }
            }

            return string.Empty;
        }

        // Method to adjust the DataGridView columns to fit within the grid width
        private void AdjustDataGridViewColumns(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                // Get the available width by subtracting the vertical scrollbar width (if any) and any padding
                //int availableWidth = dgv.ClientSize.Width - dgv.RowHeadersWidth;
                int availableWidth = dgv.ClientSize.Width;

                // Count the number of visible columns
                int visibleColumnCount = dgv.Columns.Cast<DataGridViewColumn>().Count(col => col.Visible);

                if (visibleColumnCount > 0)
                {
                    // Calculate the width for each visible column
                    int columnWidth = availableWidth / visibleColumnCount;

                    // Set the width of each visible column
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.Visible)
                        {
                            col.Width = columnWidth;
                        }
                    }
                }
            }
        }

        #endregion Private Methods

        private void btnSPODataClear_Click(object sender, EventArgs e)
        {
            ClearControls("SPO");
            //clear list as well
            rangeSPO180 = rangeSPO120 = rangeSPO90 = null;
            if (spoCustomSearch != null)
                spoCustomSearch.Clear();
        }
    }
}