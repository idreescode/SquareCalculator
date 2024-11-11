using SquareCalculator.Helper;
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
    public partial class cntrlHours : UserControl
    {
        private HoursCalculator hoursCalculator;
        private SQR9Helper SQR9Helper;
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
        }

        private void btnCalculateTotalMinutes_Click(object sender, EventArgs e)
        {
            var result = hoursCalculator.CalculateRanges(dtStartDate.Value, dtStartTime.Value, dtEndDate.Value);

            lblTotalMinutesValue.Text = result.TotalMinutes.ToString();

            lblMinutesToMidNightValue.Text = result.MinutesToMidnight.ToString();

            lblRange1DayValue.Text = result.RangeMinusOneDayMinutes.ToString() + "-" + result.TotalMinutes + " min";

            double rangeInHours = Math.Round((result.TotalMinutes / 60.0), 2);

            lblRanginHrsValue.Text = (Math.Round(result.RangeInHours,2).ToString() + "-" + (rangeInHours)).ToString();

        }
    }
}
