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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpHoursCalculations = new System.Windows.Forms.GroupBox();
            this.btnCalculateTotalMinutes = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalMinutes = new System.Windows.Forms.Label();
            this.lblTotalMinutesValue = new System.Windows.Forms.Label();
            this.lblMinutestoMidNight = new System.Windows.Forms.Label();
            this.lblMinutesToMidNightValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRange1DayValue = new System.Windows.Forms.Label();
            this.lblRanginHrsValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtInput180 = new System.Windows.Forms.TextBox();
            this.txtInput120 = new System.Windows.Forms.TextBox();
            this.txtInput90 = new System.Windows.Forms.TextBox();
            this.gvHours = new System.Windows.Forms.DataGridView();
            this.btnCalculationHours = new System.Windows.Forms.Button();
            this.colTimeOfDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayHoursMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExactHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalMint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpHoursCalculations.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHours)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.grpHoursCalculations);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1777, 980);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
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
            this.grpHoursCalculations.Name = "grpHoursCalculations";
            this.grpHoursCalculations.Size = new System.Drawing.Size(380, 201);
            this.grpHoursCalculations.TabIndex = 0;
            this.grpHoursCalculations.TabStop = false;
            this.grpHoursCalculations.Text = "Hours";
            // 
            // btnCalculateTotalMinutes
            // 
            this.btnCalculateTotalMinutes.Location = new System.Drawing.Point(93, 155);
            this.btnCalculateTotalMinutes.Name = "btnCalculateTotalMinutes";
            this.btnCalculateTotalMinutes.Size = new System.Drawing.Size(221, 38);
            this.btnCalculateTotalMinutes.TabIndex = 6;
            this.btnCalculateTotalMinutes.Text = "Calculate Total Minutes";
            this.btnCalculateTotalMinutes.UseVisualStyleBackColor = true;
            this.btnCalculateTotalMinutes.Click += new System.EventHandler(this.btnCalculateTotalMinutes_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(84, 116);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(230, 20);
            this.dtEndDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Date";
            // 
            // dtStartTime
            // 
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(84, 66);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(230, 20);
            this.dtStartTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Time : ";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(84, 26);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(230, 20);
            this.dtStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date : ";
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
            this.groupBox1.Location = new System.Drawing.Point(0, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 779);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculations";
            // 
            // lblTotalMinutes
            // 
            this.lblTotalMinutes.AutoSize = true;
            this.lblTotalMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMinutes.Location = new System.Drawing.Point(7, 40);
            this.lblTotalMinutes.Name = "lblTotalMinutes";
            this.lblTotalMinutes.Size = new System.Drawing.Size(92, 13);
            this.lblTotalMinutes.TabIndex = 0;
            this.lblTotalMinutes.Text = "Total Minutes :";
            // 
            // lblTotalMinutesValue
            // 
            this.lblTotalMinutesValue.AutoSize = true;
            this.lblTotalMinutesValue.Location = new System.Drawing.Point(182, 40);
            this.lblTotalMinutesValue.Name = "lblTotalMinutesValue";
            this.lblTotalMinutesValue.Size = new System.Drawing.Size(33, 13);
            this.lblTotalMinutesValue.TabIndex = 1;
            this.lblTotalMinutesValue.Text = "value";
            // 
            // lblMinutestoMidNight
            // 
            this.lblMinutestoMidNight.AutoSize = true;
            this.lblMinutestoMidNight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutestoMidNight.Location = new System.Drawing.Point(7, 81);
            this.lblMinutestoMidNight.Name = "lblMinutestoMidNight";
            this.lblMinutestoMidNight.Size = new System.Drawing.Size(131, 13);
            this.lblMinutestoMidNight.TabIndex = 2;
            this.lblMinutestoMidNight.Text = "Minutes to MindNight:";
            // 
            // lblMinutesToMidNightValue
            // 
            this.lblMinutesToMidNightValue.AutoSize = true;
            this.lblMinutesToMidNightValue.Location = new System.Drawing.Point(182, 81);
            this.lblMinutesToMidNightValue.Name = "lblMinutesToMidNightValue";
            this.lblMinutesToMidNightValue.Size = new System.Drawing.Size(33, 13);
            this.lblMinutesToMidNightValue.TabIndex = 3;
            this.lblMinutesToMidNightValue.Text = "value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Range (-1 Day):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Range in Hrs:";
            // 
            // lblRange1DayValue
            // 
            this.lblRange1DayValue.AutoSize = true;
            this.lblRange1DayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRange1DayValue.Location = new System.Drawing.Point(182, 122);
            this.lblRange1DayValue.Name = "lblRange1DayValue";
            this.lblRange1DayValue.Size = new System.Drawing.Size(33, 13);
            this.lblRange1DayValue.TabIndex = 6;
            this.lblRange1DayValue.Text = "value";
            // 
            // lblRanginHrsValue
            // 
            this.lblRanginHrsValue.AutoSize = true;
            this.lblRanginHrsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRanginHrsValue.Location = new System.Drawing.Point(182, 178);
            this.lblRanginHrsValue.Name = "lblRanginHrsValue";
            this.lblRanginHrsValue.Size = new System.Drawing.Size(33, 13);
            this.lblRanginHrsValue.TabIndex = 7;
            this.lblRanginHrsValue.Text = "value";
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.469388F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.673469F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.959184F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.591837F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.30612F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1393, 980);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtInput180
            // 
            this.txtInput180.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput180.Location = new System.Drawing.Point(3, 2);
            this.txtInput180.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInput180.Name = "txtInput180";
            this.txtInput180.Size = new System.Drawing.Size(1387, 20);
            this.txtInput180.TabIndex = 33;
            // 
            // txtInput120
            // 
            this.txtInput120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput120.Location = new System.Drawing.Point(3, 36);
            this.txtInput120.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInput120.Name = "txtInput120";
            this.txtInput120.Size = new System.Drawing.Size(1387, 20);
            this.txtInput120.TabIndex = 35;
            // 
            // txtInput90
            // 
            this.txtInput90.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput90.Location = new System.Drawing.Point(3, 72);
            this.txtInput90.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInput90.Name = "txtInput90";
            this.txtInput90.Size = new System.Drawing.Size(1387, 20);
            this.txtInput90.TabIndex = 36;
            // 
            // gvHours
            // 
            this.gvHours.AllowUserToAddRows = false;
            this.gvHours.BackgroundColor = System.Drawing.Color.White;
            this.gvHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTotalMint,
            this.colTotalHours,
            this.colExactHours,
            this.colDayHoursMin,
            this.colTimeOfDay});
            this.gvHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvHours.GridColor = System.Drawing.SystemColors.Control;
            this.gvHours.Location = new System.Drawing.Point(3, 147);
            this.gvHours.Name = "gvHours";
            this.gvHours.Size = new System.Drawing.Size(1387, 830);
            this.gvHours.TabIndex = 38;
            this.gvHours.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // btnCalculationHours
            // 
            this.btnCalculationHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalculationHours.Location = new System.Drawing.Point(3, 102);
            this.btnCalculationHours.Name = "btnCalculationHours";
            this.btnCalculationHours.Size = new System.Drawing.Size(1387, 39);
            this.btnCalculationHours.TabIndex = 39;
            this.btnCalculationHours.Text = "Find Matches In Range";
            this.btnCalculationHours.UseVisualStyleBackColor = true;
            this.btnCalculationHours.Click += new System.EventHandler(this.btnCalculationHours_Click);
            // 
            // colTimeOfDay
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTimeOfDay.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTimeOfDay.HeaderText = "Time of Day";
            this.colTimeOfDay.Name = "colTimeOfDay";
            this.colTimeOfDay.Width = 350;
            // 
            // colDayHoursMin
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDayHoursMin.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDayHoursMin.HeaderText = "Day, Hrs, Min";
            this.colDayHoursMin.Name = "colDayHoursMin";
            this.colDayHoursMin.Width = 350;
            // 
            // colExactHours
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colExactHours.DefaultCellStyle = dataGridViewCellStyle3;
            this.colExactHours.HeaderText = "Exact Hours";
            this.colExactHours.Name = "colExactHours";
            this.colExactHours.Width = 300;
            // 
            // colTotalHours
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotalHours.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTotalHours.HeaderText = "Total Hrs";
            this.colTotalHours.Name = "colTotalHours";
            this.colTotalHours.Width = 250;
            // 
            // colTotalMint
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotalMint.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTotalMint.HeaderText = "Total Mints";
            this.colTotalMint.Name = "colTotalMint";
            this.colTotalMint.Width = 200;
            // 
            // cntrlHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "cntrlHours";
            this.Size = new System.Drawing.Size(1777, 980);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpHoursCalculations.ResumeLayout(false);
            this.grpHoursCalculations.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalMint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExactHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayHoursMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeOfDay;
    }
}
