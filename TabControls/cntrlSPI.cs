using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquareCalculator.TabControls
{
    public partial class cntrlSPI : UserControl
    {
        public List<Range> RangeSPO180 { get; private set; }
        public List<Range> RangeSPO120 { get; private set; }
        public List<Range> RangeSPO90 { get; private set; }

        public cntrlSPI()
        {
            
            InitializeComponent();
            RangeSPO180 = new List<Range>();
            RangeSPO120 = new List<Range>();
            RangeSPO90 = new List<Range>();

            // Ensure tableLayoutPanel1 fills the entire UserControl
            tableLayoutPanel1.Dock = DockStyle.Fill;

            // Set the row style to make `pnTop` and `pnlBottom` occupy equal space
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12)); // 50% height for pnTop
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88)); // 50% height for pnlBottom

            // Ensure `pnTop` and `pnlBottom` fill their cells in the `TableLayoutPanel`
            pnTop.Dock = DockStyle.Fill;
            pnlBottom.Dock = DockStyle.Fill;
        }

        public void SetRanges(List<Range> ranges180, List<Range> ranges120, List<Range> ranges90)
        {
            RangeSPO180 = ranges180;
            RangeSPO120 = ranges120;
            RangeSPO90 = ranges90;

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
            if (RangeSPO180 != null && chkInclude180.Checked)
            {
                // Create a list of tuples with the correct type based on your filtering criteria
                var filteredValues = RangeSPO180
                    .SelectMany(r => r.Data)
                    .Where(d => d.Value >= minSPO && d.Value <= maxSPO)
                    .Select(d => (colName: "180", matchedRange: d.Value)) // Use tuples here
                    .ToList();

                // Add the filtered tuples to lstPEPs
                lstPEPs.AddRange(filteredValues);
            }
            if (RangeSPO120 != null && chkInclude120.Checked)
            {
                // Create a list of tuples with the correct type based on your filtering criteria
                var filteredValues = RangeSPO120
                    .SelectMany(r => r.Data)
                    .Where(d => d.Value >= minSPO && d.Value <= maxSPO)
                    .Select(d => (colName: "120", matchedRange: d.Value)) // Use tuples here
                    .ToList();

                // Add the filtered tuples to lstPEPs
                lstPEPs.AddRange(filteredValues);
            }
            if (RangeSPO90 != null && chkInclude90.Checked)
            {
                // Create a list of tuples with the correct type based on your filtering criteria
                var filteredValues = RangeSPO90
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
                        var filteredValues180 = RangeSPO180
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
                        var filteredValues120 = RangeSPO120
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
                        var filteredValues90 = RangeSPO90
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


                rwIndex++;
            }

            // Adjust the width of all columns based on their content
            dgViewSPO.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Adjust the width of the visible columns in the DataGridView
            AdjustDataGridViewColumns(dgViewSPO);
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
    }
}
