namespace SquareCalculator.TabControls
{
    partial class cntrlHours
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpVariation = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkShowMatch2plusOnly = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkShowMatch90Only = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkShowMatch120Only = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkShowMatch180Only = new System.Windows.Forms.CheckBox();
            this.nbrMatchTolerance = new System.Windows.Forms.NumericUpDown();
            this.lblMatchTolerance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkShowMatchOnly = new System.Windows.Forms.CheckBox();
            this.numberVariation = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRanginHrsValue = new System.Windows.Forms.Label();
            this.lblRange1DayValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMinutesToMidNightValue = new System.Windows.Forms.Label();
            this.lblMinutestoMidNight = new System.Windows.Forms.Label();
            this.lblTotalMinutesValue = new System.Windows.Forms.Label();
            this.lblTotalMinutes = new System.Windows.Forms.Label();
            this.grpHoursCalculations = new System.Windows.Forms.GroupBox();
            this.btnCalculateTotalMinutes = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtInput90 = new System.Windows.Forms.TextBox();
            this.txtInput180 = new System.Windows.Forms.TextBox();
            this.txtInput120 = new System.Windows.Forms.TextBox();
            this.gvHours = new System.Windows.Forms.DataGridView();
            this.colTotalMint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExactHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayHoursMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeOfDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalculationHours = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpVariation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrMatchTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberVariation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpHoursCalculations.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHours)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(2369, 1206);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.SplitContainer1_SplitterMoving);
            // 
            // gpVariation
            // 
            this.gpVariation.Controls.Add(this.label11);
            this.gpVariation.Controls.Add(this.chkShowMatch2plusOnly);
            this.gpVariation.Controls.Add(this.label10);
            this.gpVariation.Controls.Add(this.chkShowMatch90Only);
            this.gpVariation.Controls.Add(this.label9);
            this.gpVariation.Controls.Add(this.chkShowMatch120Only);
            this.gpVariation.Controls.Add(this.label8);
            this.gpVariation.Controls.Add(this.chkShowMatch180Only);
            this.gpVariation.Controls.Add(this.nbrMatchTolerance);
            this.gpVariation.Controls.Add(this.lblMatchTolerance);
            this.gpVariation.Controls.Add(this.label7);
            this.gpVariation.Controls.Add(this.chkShowMatchOnly);
            this.gpVariation.Controls.Add(this.numberVariation);
            this.gpVariation.Controls.Add(this.label6);
            this.gpVariation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpVariation.Location = new System.Drawing.Point(4, 602);
            this.gpVariation.Margin = new System.Windows.Forms.Padding(4);
            this.gpVariation.Name = "gpVariation";
            this.gpVariation.Padding = new System.Windows.Forms.Padding(4);
            this.gpVariation.Size = new System.Drawing.Size(503, 600);
            this.gpVariation.TabIndex = 2;
            this.gpVariation.TabStop = false;
            this.gpVariation.Text = "Variation";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 172);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 22);
            this.label11.TabIndex = 85;
            this.label11.Text = "Show 2+ Matches only";
            // 
            // chkShowMatch2plusOnly
            // 
            this.chkShowMatch2plusOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMatch2plusOnly.AutoSize = true;
            this.chkShowMatch2plusOnly.Location = new System.Drawing.Point(372, 172);
            this.chkShowMatch2plusOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowMatch2plusOnly.Name = "chkShowMatch2plusOnly";
            this.chkShowMatch2plusOnly.Size = new System.Drawing.Size(18, 17);
            this.chkShowMatch2plusOnly.TabIndex = 84;
            this.chkShowMatch2plusOnly.UseVisualStyleBackColor = true;
            this.chkShowMatch2plusOnly.CheckedChanged += new System.EventHandler(this.chkShowMatch2plusOnly_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 139);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(216, 22);
            this.label10.TabIndex = 83;
            this.label10.Text = "Show 90 Matches only:";
            // 
            // chkShowMatch90Only
            // 
            this.chkShowMatch90Only.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMatch90Only.AutoSize = true;
            this.chkShowMatch90Only.Location = new System.Drawing.Point(372, 139);
            this.chkShowMatch90Only.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowMatch90Only.Name = "chkShowMatch90Only";
            this.chkShowMatch90Only.Size = new System.Drawing.Size(18, 17);
            this.chkShowMatch90Only.TabIndex = 82;
            this.chkShowMatch90Only.UseVisualStyleBackColor = true;
            this.chkShowMatch90Only.CheckedChanged += new System.EventHandler(this.chkShowMatch180Only_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 103);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(227, 22);
            this.label9.TabIndex = 81;
            this.label9.Text = "Show 120 Matches only:";
            // 
            // chkShowMatch120Only
            // 
            this.chkShowMatch120Only.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMatch120Only.AutoSize = true;
            this.chkShowMatch120Only.Location = new System.Drawing.Point(372, 103);
            this.chkShowMatch120Only.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowMatch120Only.Name = "chkShowMatch120Only";
            this.chkShowMatch120Only.Size = new System.Drawing.Size(18, 17);
            this.chkShowMatch120Only.TabIndex = 80;
            this.chkShowMatch120Only.UseVisualStyleBackColor = true;
            this.chkShowMatch120Only.CheckedChanged += new System.EventHandler(this.chkShowMatch180Only_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(227, 22);
            this.label8.TabIndex = 79;
            this.label8.Text = "Show 180 Matches only:";
            // 
            // chkShowMatch180Only
            // 
            this.chkShowMatch180Only.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMatch180Only.AutoSize = true;
            this.chkShowMatch180Only.Location = new System.Drawing.Point(372, 71);
            this.chkShowMatch180Only.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowMatch180Only.Name = "chkShowMatch180Only";
            this.chkShowMatch180Only.Size = new System.Drawing.Size(18, 17);
            this.chkShowMatch180Only.TabIndex = 78;
            this.chkShowMatch180Only.UseVisualStyleBackColor = true;
            this.chkShowMatch180Only.CheckedChanged += new System.EventHandler(this.chkShowMatch180Only_CheckedChanged);
            // 
            // nbrMatchTolerance
            // 
            this.nbrMatchTolerance.Location = new System.Drawing.Point(311, 240);
            this.nbrMatchTolerance.Margin = new System.Windows.Forms.Padding(4);
            this.nbrMatchTolerance.Name = "nbrMatchTolerance";
            this.nbrMatchTolerance.Size = new System.Drawing.Size(79, 22);
            this.nbrMatchTolerance.TabIndex = 77;
            this.nbrMatchTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMatchTolerance
            // 
            this.lblMatchTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMatchTolerance.AutoSize = true;
            this.lblMatchTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchTolerance.Location = new System.Drawing.Point(25, 242);
            this.lblMatchTolerance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatchTolerance.Name = "lblMatchTolerance";
            this.lblMatchTolerance.Size = new System.Drawing.Size(165, 22);
            this.lblMatchTolerance.TabIndex = 76;
            this.lblMatchTolerance.Text = "Match Tolerance:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 22);
            this.label7.TabIndex = 75;
            this.label7.Text = "Show Matches only:";
            // 
            // chkShowMatchOnly
            // 
            this.chkShowMatchOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMatchOnly.AutoSize = true;
            this.chkShowMatchOnly.Checked = true;
            this.chkShowMatchOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMatchOnly.Location = new System.Drawing.Point(372, 38);
            this.chkShowMatchOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowMatchOnly.Name = "chkShowMatchOnly";
            this.chkShowMatchOnly.Size = new System.Drawing.Size(18, 17);
            this.chkShowMatchOnly.TabIndex = 74;
            this.chkShowMatchOnly.UseVisualStyleBackColor = true;
            this.chkShowMatchOnly.CheckedChanged += new System.EventHandler(this.btnCalculationHours_Click);
            // 
            // numberVariation
            // 
            this.numberVariation.Location = new System.Drawing.Point(311, 210);
            this.numberVariation.Margin = new System.Windows.Forms.Padding(4);
            this.numberVariation.Name = "numberVariation";
            this.numberVariation.Size = new System.Drawing.Size(79, 22);
            this.numberVariation.TabIndex = 73;
            this.numberVariation.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 22);
            this.label6.TabIndex = 71;
            this.label6.Text = "Minutes Variation:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRanginHrsValue);
            this.groupBox1.Controls.Add(this.lblRange1DayValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblMinutesToMidNightValue);
            this.groupBox1.Controls.Add(this.lblMinutestoMidNight);
            this.groupBox1.Controls.Add(this.lblTotalMinutesValue);
            this.groupBox1.Controls.Add(this.lblTotalMinutes);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 303);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(503, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculations";
            // 
            // lblRanginHrsValue
            // 
            this.lblRanginHrsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRanginHrsValue.AutoSize = true;
            this.lblRanginHrsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRanginHrsValue.Location = new System.Drawing.Point(340, 207);
            this.lblRanginHrsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRanginHrsValue.Name = "lblRanginHrsValue";
            this.lblRanginHrsValue.Size = new System.Drawing.Size(53, 22);
            this.lblRanginHrsValue.TabIndex = 7;
            this.lblRanginHrsValue.Text = "value";
            // 
            // lblRange1DayValue
            // 
            this.lblRange1DayValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRange1DayValue.AutoSize = true;
            this.lblRange1DayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRange1DayValue.Location = new System.Drawing.Point(337, 150);
            this.lblRange1DayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRange1DayValue.Name = "lblRange1DayValue";
            this.lblRange1DayValue.Size = new System.Drawing.Size(53, 22);
            this.lblRange1DayValue.TabIndex = 6;
            this.lblRange1DayValue.Text = "value";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 207);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Range in Hrs:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Range (-1 Day):";
            // 
            // lblMinutesToMidNightValue
            // 
            this.lblMinutesToMidNightValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinutesToMidNightValue.AutoSize = true;
            this.lblMinutesToMidNightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutesToMidNightValue.Location = new System.Drawing.Point(337, 100);
            this.lblMinutesToMidNightValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinutesToMidNightValue.Name = "lblMinutesToMidNightValue";
            this.lblMinutesToMidNightValue.Size = new System.Drawing.Size(53, 22);
            this.lblMinutesToMidNightValue.TabIndex = 3;
            this.lblMinutesToMidNightValue.Text = "value";
            // 
            // lblMinutestoMidNight
            // 
            this.lblMinutestoMidNight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinutestoMidNight.AutoSize = true;
            this.lblMinutestoMidNight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutestoMidNight.Location = new System.Drawing.Point(9, 100);
            this.lblMinutestoMidNight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinutestoMidNight.Name = "lblMinutestoMidNight";
            this.lblMinutestoMidNight.Size = new System.Drawing.Size(203, 22);
            this.lblMinutestoMidNight.TabIndex = 2;
            this.lblMinutestoMidNight.Text = "Minutes to MindNight:";
            // 
            // lblTotalMinutesValue
            // 
            this.lblTotalMinutesValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMinutesValue.AutoSize = true;
            this.lblTotalMinutesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMinutesValue.Location = new System.Drawing.Point(337, 49);
            this.lblTotalMinutesValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMinutesValue.Name = "lblTotalMinutesValue";
            this.lblTotalMinutesValue.Size = new System.Drawing.Size(53, 22);
            this.lblTotalMinutesValue.TabIndex = 1;
            this.lblTotalMinutesValue.Text = "value";
            // 
            // lblTotalMinutes
            // 
            this.lblTotalMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMinutes.AutoSize = true;
            this.lblTotalMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMinutes.Location = new System.Drawing.Point(9, 49);
            this.lblTotalMinutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMinutes.Name = "lblTotalMinutes";
            this.lblTotalMinutes.Size = new System.Drawing.Size(143, 22);
            this.lblTotalMinutes.TabIndex = 0;
            this.lblTotalMinutes.Text = "Total Minutes :";
            // 
            // grpHoursCalculations
            // 
            this.grpHoursCalculations.Controls.Add(this.btnCalculateTotalMinutes);
            this.grpHoursCalculations.Controls.Add(this.dtEndDate);
            this.grpHoursCalculations.Controls.Add(this.label3);
            this.grpHoursCalculations.Controls.Add(this.dtStartTime);
            this.grpHoursCalculations.Controls.Add(this.label2);
            this.grpHoursCalculations.Controls.Add(this.dtStartDate);
            this.grpHoursCalculations.Controls.Add(this.label1);
            this.grpHoursCalculations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHoursCalculations.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHoursCalculations.Location = new System.Drawing.Point(4, 4);
            this.grpHoursCalculations.Margin = new System.Windows.Forms.Padding(4);
            this.grpHoursCalculations.Name = "grpHoursCalculations";
            this.grpHoursCalculations.Padding = new System.Windows.Forms.Padding(4);
            this.grpHoursCalculations.Size = new System.Drawing.Size(503, 291);
            this.grpHoursCalculations.TabIndex = 0;
            this.grpHoursCalculations.TabStop = false;
            this.grpHoursCalculations.Text = "Hours";
            // 
            // btnCalculateTotalMinutes
            // 
            this.btnCalculateTotalMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculateTotalMinutes.Location = new System.Drawing.Point(156, 183);
            this.btnCalculateTotalMinutes.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalculateTotalMinutes.Name = "btnCalculateTotalMinutes";
            this.btnCalculateTotalMinutes.Size = new System.Drawing.Size(299, 45);
            this.btnCalculateTotalMinutes.TabIndex = 6;
            this.btnCalculateTotalMinutes.Text = "Calculate Total Minutes";
            this.btnCalculateTotalMinutes.UseVisualStyleBackColor = true;
            this.btnCalculateTotalMinutes.Click += new System.EventHandler(this.btnCalculateTotalMinutes_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEndDate.Location = new System.Drawing.Point(155, 138);
            this.dtEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(297, 22);
            this.dtEndDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Date:";
            // 
            // dtStartTime
            // 
            this.dtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartTime.CustomFormat = "hh:mm tt";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(157, 82);
            this.dtStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(297, 22);
            this.dtStartTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Time : ";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartDate.Location = new System.Drawing.Point(157, 33);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(297, 22);
            this.dtStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date : ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtInput90, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtInput180, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtInput120, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gvHours, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCalculationHours, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.469388F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.673469F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.959184F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.591837F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.30612F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1853, 1206);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtInput90
            // 
            this.txtInput90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput90.Location = new System.Drawing.Point(4, 87);
            this.txtInput90.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtInput90.Name = "txtInput90";
            this.txtInput90.Size = new System.Drawing.Size(1845, 22);
            this.txtInput90.TabIndex = 36;
            // 
            // txtInput180
            // 
            this.txtInput180.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput180.Location = new System.Drawing.Point(4, 2);
            this.txtInput180.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtInput180.Name = "txtInput180";
            this.txtInput180.Size = new System.Drawing.Size(1845, 22);
            this.txtInput180.TabIndex = 33;
            // 
            // txtInput120
            // 
            this.txtInput120.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput120.Location = new System.Drawing.Point(4, 43);
            this.txtInput120.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtInput120.Name = "txtInput120";
            this.txtInput120.Size = new System.Drawing.Size(1845, 22);
            this.txtInput120.TabIndex = 35;
            // 
            // gvHours
            // 
            this.gvHours.AllowUserToAddRows = false;
            this.gvHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvHours.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvHours.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvHours.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.gvHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTotalMint,
            this.colTotalHours,
            this.colExactHours,
            this.colDayHoursMin,
            this.colTimeOfDay});
            this.gvHours.GridColor = System.Drawing.SystemColors.Control;
            this.gvHours.Location = new System.Drawing.Point(4, 179);
            this.gvHours.Margin = new System.Windows.Forms.Padding(4);
            this.gvHours.Name = "gvHours";
            this.gvHours.RowHeadersWidth = 51;
            this.gvHours.Size = new System.Drawing.Size(1845, 1023);
            this.gvHours.TabIndex = 38;
            this.gvHours.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvHours_RowHeaderMouseClick);
            this.gvHours.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // colTotalMint
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotalMint.DefaultCellStyle = dataGridViewCellStyle26;
            this.colTotalMint.HeaderText = "Total Mins";
            this.colTotalMint.MinimumWidth = 6;
            this.colTotalMint.Name = "colTotalMint";
            // 
            // colTotalHours
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotalHours.DefaultCellStyle = dataGridViewCellStyle27;
            this.colTotalHours.HeaderText = "Total Hrs";
            this.colTotalHours.MinimumWidth = 6;
            this.colTotalHours.Name = "colTotalHours";
            // 
            // colExactHours
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colExactHours.DefaultCellStyle = dataGridViewCellStyle28;
            this.colExactHours.HeaderText = "Exact Hours";
            this.colExactHours.MinimumWidth = 6;
            this.colExactHours.Name = "colExactHours";
            // 
            // colDayHoursMin
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDayHoursMin.DefaultCellStyle = dataGridViewCellStyle29;
            this.colDayHoursMin.HeaderText = "Day, Hrs, Min";
            this.colDayHoursMin.MinimumWidth = 6;
            this.colDayHoursMin.Name = "colDayHoursMin";
            // 
            // colTimeOfDay
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTimeOfDay.DefaultCellStyle = dataGridViewCellStyle30;
            this.colTimeOfDay.HeaderText = "Time of Day";
            this.colTimeOfDay.MinimumWidth = 6;
            this.colTimeOfDay.Name = "colTimeOfDay";
            // 
            // btnCalculationHours
            // 
            this.btnCalculationHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculationHours.Location = new System.Drawing.Point(4, 124);
            this.btnCalculationHours.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalculationHours.Name = "btnCalculationHours";
            this.btnCalculationHours.Size = new System.Drawing.Size(1845, 47);
            this.btnCalculationHours.TabIndex = 39;
            this.btnCalculationHours.Text = "Find Matches In Range";
            this.btnCalculationHours.UseVisualStyleBackColor = true;
            this.btnCalculationHours.Click += new System.EventHandler(this.btnCalculationHours_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gpVariation, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.grpHoursCalculations, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 607F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(511, 1206);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // cntrlHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "cntrlHours";
            this.Size = new System.Drawing.Size(2373, 1210);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpVariation.ResumeLayout(false);
            this.gpVariation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrMatchTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberVariation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpHoursCalculations.ResumeLayout(false);
            this.grpHoursCalculations.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHours)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpHoursCalculations;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalculateTotalMinutes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalMinutes;
        private System.Windows.Forms.Label lblTotalMinutesValue;
        private System.Windows.Forms.Label lblMinutestoMidNight;
        private System.Windows.Forms.Label lblMinutesToMidNightValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRange1DayValue;
        private System.Windows.Forms.Label lblRanginHrsValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtInput90;
        private System.Windows.Forms.TextBox txtInput120;
        private System.Windows.Forms.TextBox txtInput180;
        private System.Windows.Forms.DataGridView gvHours;
        private System.Windows.Forms.Button btnCalculationHours;
        private System.Windows.Forms.GroupBox gpVariation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numberVariation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalMint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExactHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayHoursMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeOfDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkShowMatchOnly;
        private System.Windows.Forms.NumericUpDown nbrMatchTolerance;
        private System.Windows.Forms.Label lblMatchTolerance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkShowMatch90Only;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkShowMatch120Only;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkShowMatch180Only;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkShowMatch2plusOnly;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
