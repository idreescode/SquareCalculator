using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquareCalculator.Helper
{
    public class SQR9Helper
    {
        private static readonly List<int> numberList = new List<int>
    {
        1, 10, 11, 100, 101, 110, 111, 1000, 1001, 1010, 1011, 1100, 1101, 1110, 1111, 10000, 10001, 10010, 10011,
        11000, 11001, 11010, 11011, 100000, 100001, 100010, 100011
    };

        public List<double> GetInputRanges(System.Windows.Forms.TextBox txtInput, List<Range> range180)
        {
            List<double> inputRanges = new List<double>();
            string inputText = txtInput.Text;
            string[] inputParts = inputText.Split(',');

            foreach (string part in inputParts)
            {
                if (double.TryParse(part.Trim(), out double result))
                {
                    if (!txtInput.Name.Contains("180") && !txtInput.Name.Equals("txtInputSearch"))
                    {
                        if (range180 != null && !range180.Any(i => i.Value.Equals(result)))
                            inputRanges.Add(result);
                    }
                    else
                        inputRanges.Add(result);
                }
                else
                {
                    MessageBox.Show($"Invalid input: '{part.Trim()}'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return inputRanges;
        }

        public void PopulateGrid(ref List<Range> ranges, DataGridView dataGrid, string rangeId, string gridType = "")
        {
            dataGrid.Rows.Clear();
            dataGrid.CellPainting += dgView_CellPainting;
            var groupedByColumn = ranges.GroupBy(r => r.Column).ToDictionary(g => g.Key, g => g.ToList());
            int maxRowCount = groupedByColumn.Values.Max(g => g.Count());

            while (dataGrid.Rows.Count < maxRowCount)
            {
                dataGrid.Rows.Add();
            }

            foreach (var group in groupedByColumn)
            {
                string column = group.Key;

                if (gridType == "PAD")
                {
                    column = $"{column}{gridType}";
                }

                for (int i = 0; i < group.Value.Count; i++)
                {
                    dataGrid.Rows[i].Cells[column + "_" + rangeId].Value = group.Value[i].GetFormattedData();
                }
            }

            dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            AdjustDataGridViewColumns(dataGrid);
        }

        public (double minValue, double maxValue) GetMinMaxSearchValue(double minValue, double maxValue)
        {
            return (Math.Floor(minValue), Math.Floor(maxValue) + 0.99);
        }

        public (double minValue, double maxValue) GetMinMaxWithTolerance(double input, double tolerance)
        {
            double minValue = input - tolerance;
            double maxValue = input + tolerance;
            minValue = Math.Round(minValue, 2);
            maxValue = Math.Round(maxValue, 2);
            return (minValue, maxValue);
        }

        public void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        public double Calculate_FSD(double rangeValue, double initialForecast, double txtInputSD, int cmbMESelectedValue)
        {
            double fsd = rangeValue - txtInputSD;
            if (fsd >= 0)
                return fsd;

            double val1 = cmbMESelectedValue - txtInputSD;
            double val2 = rangeValue - 1 + 1;
            return val1 + val2;
        }

        public  bool IsInRange(double input)
        {
            int intPart = (int)Math.Floor(input);
            if (numberList.Contains(intPart))
            {
                double decimalPart = input - intPart;
                return decimalPart >= 0.0 && decimalPart < 1.0;
            }
            return false;
        }

        public void AdjustDataGridViewColumns(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                int availableWidth = dgv.ClientSize.Width;
                int visibleColumnCount = dgv.Columns.Cast<DataGridViewColumn>().Count(col => col.Visible);

                if (visibleColumnCount > 0)
                {
                    int columnWidth = availableWidth / visibleColumnCount;
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

        public void dgView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null)
            {
                DataGridView grid = sender as DataGridView;
                string cellValue = e.Value.ToString();
                string[] parts = cellValue.Contains('\t')
                    ? cellValue.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    : cellValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                Font regularFont = new Font(e.CellStyle.Font, FontStyle.Regular);
                Brush regularBrush = Brushes.Black;
                Brush variationBrush = Brushes.Blue;
                Brush redBrush = Brushes.Red;

                float totalTextWidth = 0;
                foreach (string part in parts)
                {
                    totalTextWidth += e.Graphics.MeasureString(part.Replace("(O)", "").Replace("(V)", "").Trim(), regularFont).Width + 5;
                }

                float xPosition = e.CellBounds.Left;
                if (totalTextWidth < e.CellBounds.Width)
                {
                    xPosition = e.CellBounds.Left + (e.CellBounds.Width - totalTextWidth) / 2;
                }

                float yPosition = e.CellBounds.Top + (e.CellBounds.Height - e.Graphics.MeasureString(cellValue, e.CellStyle.Font).Height) / 2;

                foreach (string part in parts)
                {
                    if (part.Contains("(O)"))
                    {
                        string originalValue = part.Replace("(O)", "").Trim();
                        Brush brush = IsInRange(double.Parse(originalValue)) ? redBrush : regularBrush;
                        e.Graphics.DrawString(originalValue, regularFont, brush, xPosition, yPosition);
                        xPosition += e.Graphics.MeasureString(originalValue, regularFont).Width + 3;
                    }
                    else if (part.Contains("(V)"))
                    {
                        string variationValue = part.Replace("(V)", "").Trim();
                        Brush brush = IsInRange(double.Parse(variationValue)) ? redBrush : variationBrush;
                        e.Graphics.DrawString(variationValue, regularFont, brush, xPosition, yPosition);
                        xPosition += e.Graphics.MeasureString(variationValue, regularFont).Width + 3;
                    }
                }
            }
        }

        // ... (Other methods from the previous SQR9Helper class)


     


    }

}
