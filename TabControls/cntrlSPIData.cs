using SquareCalculator.TabControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquareCalculator
{
    public partial class cntrlSPIData : UserControl
    {
        private List<Range> range180;
        private List<Range> range120;
        private List<Range> range90;
        public Action<List<Range>, List<Range>, List<Range>> OnUpdateRanges;

        private static List<int> numberList = new List<int>
        {
            1, 10, 11, 100, 101, 110, 111, 1000, 1001, 1010, 1011, 1100, 1101, 1110, 1111, 10000, 10001, 10010, 10011,
            11000, 11001, 11010, 11011, 100000, 100001, 100010, 100011
        };
        public cntrlSPIData()
        {
           
            InitializeComponent();
            // Optionally, call any methods on cntrlSPI to trigger processing after setting these lists
            ClearControls();
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

            OnUpdateRanges?.Invoke(range180, range120, range90);

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
                        if ((grid.Name.Equals("dgView180") || grid.Name.Equals("dgView120") || grid.Name.Equals("dgView90") ||
                             grid.Name.Equals("dgViewPAD180") || grid.Name.Equals("dgViewPAD120") || grid.Name.Equals("dgViewPAD90"))
                            && IsInRange(double.Parse(originalValue)))
                        {
                            e.Graphics.DrawString(originalValue, regularFont, redBrush, xPosition, yPosition);
                        }
                        else
                        {
                            e.Graphics.DrawString(originalValue, regularFont, regularBrush, xPosition, yPosition);
                        }
                        xPosition += e.Graphics.MeasureString(originalValue, regularFont).Width + 3;
                    }
                    else if (part.Contains("(V)"))  // Variation value
                    {
                        string variationValue = part.Replace("(V)", "").Trim();
                        if ((grid.Name.Equals("dgView180") || grid.Name.Equals("dgView120") || grid.Name.Equals("dgView90") ||
                             grid.Name.Equals("dgViewPAD180") || grid.Name.Equals("dgViewPAD120") || grid.Name.Equals("dgViewPAD90"))
                            && IsInRange(double.Parse(variationValue)))
                        {
                            e.Graphics.DrawString(variationValue, regularFont, redBrush, xPosition, yPosition);
                        }
                        else
                        {
                            e.Graphics.DrawString(variationValue, regularFont, variationBrush, xPosition, yPosition);
                        }
                        xPosition += e.Graphics.MeasureString(variationValue, regularFont).Width + 3;
                    }
                }

            }
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

            SetPlaceholder(txtInput180, "Input 180");
            SetPlaceholder(txtInput120, "Input 120");
            SetPlaceholder(txtInput90, "Input 90");
        }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();

            //clear list as well
            range180 = range120 = range90 = null;
            //if (spoCustomSearch != null)
            //    spoCustomSearch.Clear();
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

            groupedByColumn.Keys.ToList().ForEach(column => dataGrid.Columns[column + "_" + rangeId].Visible = true);

            columnsWithoutRecords.ForEach(column => dataGrid.Columns[column + "_" + rangeId].Visible = false);



            #endregion Hide Unused Columns

            // Adjust the width of all columns based on their content
            dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Adjust the width of the visible columns in the DataGridView
            AdjustDataGridViewColumns(dataGrid);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
