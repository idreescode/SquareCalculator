﻿namespace SquareCalculator.TabControls
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpVariation = new System.Windows.Forms.GroupBox();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpVariation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberVariation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpHoursCalculations.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHours)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpVariation);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.grpHoursCalculations);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(2369, 1206);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // gpVariation
            // 
            this.gpVariation.Controls.Add(this.label7);
            this.gpVariation.Controls.Add(this.chkShowMatchOnly);
            this.gpVariation.Controls.Add(this.numberVariation);
            this.gpVariation.Controls.Add(this.label6);
            this.gpVariation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gpVariation.Location = new System.Drawing.Point(0, 865);
            this.gpVariation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpVariation.Name = "gpVariation";
            this.gpVariation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpVariation.Size = new System.Drawing.Size(511, 341);
            this.gpVariation.TabIndex = 2;
            this.gpVariation.TabStop = false;
            this.gpVariation.Text = "Variation";
            // 
            // label7
            // 
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
            this.chkShowMatchOnly.AutoSize = true;
            this.chkShowMatchOnly.Checked = true;
            this.chkShowMatchOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMatchOnly.Location = new System.Drawing.Point(245, 42);
            this.chkShowMatchOnly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShowMatchOnly.Name = "chkShowMatchOnly";
            this.chkShowMatchOnly.Size = new System.Drawing.Size(18, 17);
            this.chkShowMatchOnly.TabIndex = 74;
            this.chkShowMatchOnly.UseVisualStyleBackColor = true;
            this.chkShowMatchOnly.CheckedChanged += new System.EventHandler(this.btnCalculationHours_Click);
            // 
            // numberVariation
            // 
            this.numberVariation.Location = new System.Drawing.Point(155, 82);
            this.numberVariation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numberVariation.Name = "numberVariation";
            this.numberVariation.Size = new System.Drawing.Size(111, 22);
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
            this.label6.Location = new System.Drawing.Point(23, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 22);
            this.label6.TabIndex = 71;
            this.label6.Text = "Variation:";
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
            this.groupBox1.Location = new System.Drawing.Point(0, 271);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(511, 935);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculations";
            // 
            // lblRanginHrsValue
            // 
            this.lblRanginHrsValue.AutoSize = true;
            this.lblRanginHrsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRanginHrsValue.Location = new System.Drawing.Point(273, 219);
            this.lblRanginHrsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRanginHrsValue.Name = "lblRanginHrsValue";
            this.lblRanginHrsValue.Size = new System.Drawing.Size(53, 22);
            this.lblRanginHrsValue.TabIndex = 7;
            this.lblRanginHrsValue.Text = "value";
            // 
            // lblRange1DayValue
            // 
            this.lblRange1DayValue.AutoSize = true;
            this.lblRange1DayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRange1DayValue.Location = new System.Drawing.Point(273, 150);
            this.lblRange1DayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRange1DayValue.Name = "lblRange1DayValue";
            this.lblRange1DayValue.Size = new System.Drawing.Size(53, 22);
            this.lblRange1DayValue.TabIndex = 6;
            this.lblRange1DayValue.Text = "value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Range in Hrs:";
            // 
            // label4
            // 
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
            this.lblMinutesToMidNightValue.AutoSize = true;
            this.lblMinutesToMidNightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutesToMidNightValue.Location = new System.Drawing.Point(273, 100);
            this.lblMinutesToMidNightValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinutesToMidNightValue.Name = "lblMinutesToMidNightValue";
            this.lblMinutesToMidNightValue.Size = new System.Drawing.Size(53, 22);
            this.lblMinutesToMidNightValue.TabIndex = 3;
            this.lblMinutesToMidNightValue.Text = "value";
            // 
            // lblMinutestoMidNight
            // 
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
            this.lblTotalMinutesValue.AutoSize = true;
            this.lblTotalMinutesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMinutesValue.Location = new System.Drawing.Point(273, 49);
            this.lblTotalMinutesValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMinutesValue.Name = "lblTotalMinutesValue";
            this.lblTotalMinutesValue.Size = new System.Drawing.Size(53, 22);
            this.lblTotalMinutesValue.TabIndex = 1;
            this.lblTotalMinutesValue.Text = "value";
            // 
            // lblTotalMinutes
            // 
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
            this.grpHoursCalculations.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHoursCalculations.Location = new System.Drawing.Point(0, 0);
            this.grpHoursCalculations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpHoursCalculations.Name = "grpHoursCalculations";
            this.grpHoursCalculations.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpHoursCalculations.Size = new System.Drawing.Size(511, 271);
            this.grpHoursCalculations.TabIndex = 0;
            this.grpHoursCalculations.TabStop = false;
            this.grpHoursCalculations.Text = "Hours";
            // 
            // btnCalculateTotalMinutes
            // 
            this.btnCalculateTotalMinutes.Location = new System.Drawing.Point(156, 183);
            this.btnCalculateTotalMinutes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalculateTotalMinutes.Name = "btnCalculateTotalMinutes";
            this.btnCalculateTotalMinutes.Size = new System.Drawing.Size(307, 46);
            this.btnCalculateTotalMinutes.TabIndex = 6;
            this.btnCalculateTotalMinutes.Text = "Calculate Total Minutes";
            this.btnCalculateTotalMinutes.UseVisualStyleBackColor = true;
            this.btnCalculateTotalMinutes.Click += new System.EventHandler(this.btnCalculateTotalMinutes_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(155, 138);
            this.dtEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(305, 22);
            this.dtEndDate.TabIndex = 5;
            // 
            // label3
            // 
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
            this.dtStartTime.CustomFormat = "hh:mm tt";
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(157, 82);
            this.dtStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(305, 22);
            this.dtStartTime.TabIndex = 3;
            // 
            // label2
            // 
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
            this.dtStartDate.Location = new System.Drawing.Point(157, 33);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(305, 22);
            this.dtStartDate.TabIndex = 1;
            // 
            // label1
            // 
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.txtInput90.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.txtInput120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput120.Location = new System.Drawing.Point(4, 43);
            this.txtInput120.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtInput120.Name = "txtInput120";
            this.txtInput120.Size = new System.Drawing.Size(1845, 22);
            this.txtInput120.TabIndex = 35;
            // 
            // gvHours
            // 
            this.gvHours.AllowUserToAddRows = false;
            this.gvHours.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvHours.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTotalMint,
            this.colTotalHours,
            this.colExactHours,
            this.colDayHoursMin,
            this.colTimeOfDay});
            this.gvHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvHours.GridColor = System.Drawing.SystemColors.Control;
            this.gvHours.Location = new System.Drawing.Point(4, 179);
            this.gvHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gvHours.Name = "gvHours";
            this.gvHours.RowHeadersWidth = 51;
            this.gvHours.Size = new System.Drawing.Size(1845, 1023);
            this.gvHours.TabIndex = 38;
            this.gvHours.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // colTotalMint
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotalMint.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTotalMint.HeaderText = "Total Mins";
            this.colTotalMint.MinimumWidth = 6;
            this.colTotalMint.Name = "colTotalMint";
            this.colTotalMint.Width = 200;
            // 
            // colTotalHours
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotalHours.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotalHours.HeaderText = "Total Hrs";
            this.colTotalHours.MinimumWidth = 6;
            this.colTotalHours.Name = "colTotalHours";
            this.colTotalHours.Width = 250;
            // 
            // colExactHours
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colExactHours.DefaultCellStyle = dataGridViewCellStyle4;
            this.colExactHours.HeaderText = "Exact Hours";
            this.colExactHours.MinimumWidth = 6;
            this.colExactHours.Name = "colExactHours";
            this.colExactHours.Width = 300;
            // 
            // colDayHoursMin
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDayHoursMin.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDayHoursMin.HeaderText = "Day, Hrs, Min";
            this.colDayHoursMin.MinimumWidth = 6;
            this.colDayHoursMin.Name = "colDayHoursMin";
            this.colDayHoursMin.Width = 350;
            // 
            // colTimeOfDay
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTimeOfDay.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTimeOfDay.HeaderText = "Time of Day";
            this.colTimeOfDay.MinimumWidth = 6;
            this.colTimeOfDay.Name = "colTimeOfDay";
            this.colTimeOfDay.Width = 350;
            // 
            // btnCalculationHours
            // 
            this.btnCalculationHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalculationHours.Location = new System.Drawing.Point(4, 124);
            this.btnCalculationHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalculationHours.Name = "btnCalculationHours";
            this.btnCalculationHours.Size = new System.Drawing.Size(1845, 47);
            this.btnCalculationHours.TabIndex = 39;
            this.btnCalculationHours.Text = "Find Matches In Range";
            this.btnCalculationHours.UseVisualStyleBackColor = true;
            this.btnCalculationHours.Click += new System.EventHandler(this.btnCalculationHours_Click);
            // 
            // cntrlHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "cntrlHours";
            this.Size = new System.Drawing.Size(2369, 1206);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpVariation.ResumeLayout(false);
            this.gpVariation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberVariation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpHoursCalculations.ResumeLayout(false);
            this.grpHoursCalculations.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpHoursCalculations;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
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
    }
}
