namespace ZhinengChaoBiao
{
    partial class FrmReadLogStatistics
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReadLogStatistics));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEachDevice = new System.Windows.Forms.CheckBox();
            this.rdYear = new System.Windows.Forms.RadioButton();
            this.rdMonth = new System.Windows.Forms.RadioButton();
            this.rdDay = new System.Windows.Forms.RadioButton();
            this.cmbDeviceType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucDateTimeInterval1 = new LJH.GeneralLibrary.WinformControl.UCDateTimeInterval();
            this.ucDivision1 = new ZhinengChaoBiao.Controls.UCDivision();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colReadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.cmbDeviceType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ucDivision1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 109);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEachDevice);
            this.groupBox2.Controls.Add(this.rdYear);
            this.groupBox2.Controls.Add(this.rdMonth);
            this.groupBox2.Controls.Add(this.rdDay);
            this.groupBox2.Location = new System.Drawing.Point(477, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 89);
            this.groupBox2.TabIndex = 161;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计方式";
            // 
            // chkEachDevice
            // 
            this.chkEachDevice.AutoSize = true;
            this.chkEachDevice.Checked = true;
            this.chkEachDevice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEachDevice.Location = new System.Drawing.Point(22, 51);
            this.chkEachDevice.Name = "chkEachDevice";
            this.chkEachDevice.Size = new System.Drawing.Size(108, 16);
            this.chkEachDevice.TabIndex = 3;
            this.chkEachDevice.Text = "按设备分开统计";
            this.chkEachDevice.UseVisualStyleBackColor = true;
            // 
            // rdYear
            // 
            this.rdYear.AutoSize = true;
            this.rdYear.Location = new System.Drawing.Point(128, 20);
            this.rdYear.Name = "rdYear";
            this.rdYear.Size = new System.Drawing.Size(47, 16);
            this.rdYear.TabIndex = 2;
            this.rdYear.Text = "按年";
            this.rdYear.UseVisualStyleBackColor = true;
            // 
            // rdMonth
            // 
            this.rdMonth.AutoSize = true;
            this.rdMonth.Checked = true;
            this.rdMonth.Location = new System.Drawing.Point(75, 21);
            this.rdMonth.Name = "rdMonth";
            this.rdMonth.Size = new System.Drawing.Size(47, 16);
            this.rdMonth.TabIndex = 1;
            this.rdMonth.TabStop = true;
            this.rdMonth.Text = "按月";
            this.rdMonth.UseVisualStyleBackColor = true;
            // 
            // rdDay
            // 
            this.rdDay.AutoSize = true;
            this.rdDay.Location = new System.Drawing.Point(22, 21);
            this.rdDay.Name = "rdDay";
            this.rdDay.Size = new System.Drawing.Size(47, 16);
            this.rdDay.TabIndex = 0;
            this.rdDay.Text = "按日";
            this.rdDay.UseVisualStyleBackColor = true;
            // 
            // cmbDeviceType
            // 
            this.cmbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceType.FormattingEnabled = true;
            this.cmbDeviceType.Items.AddRange(new object[] {
            "",
            "智能电表",
            "智能水表"});
            this.cmbDeviceType.Location = new System.Drawing.Point(318, 80);
            this.cmbDeviceType.Name = "cmbDeviceType";
            this.cmbDeviceType.Size = new System.Drawing.Size(143, 20);
            this.cmbDeviceType.TabIndex = 160;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 159;
            this.label2.Text = "设备类型";
            // 
            // btnExport
            // 
            this.btnExport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExport.Location = new System.Drawing.Point(684, 62);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 38);
            this.btnExport.TabIndex = 158;
            this.btnExport.Text = "数据另存为";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuery.Location = new System.Drawing.Point(684, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(140, 38);
            this.btnQuery.TabIndex = 157;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucDateTimeInterval1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读表时间";
            // 
            // ucDateTimeInterval1
            // 
            this.ucDateTimeInterval1.EndDateTime = new System.DateTime(2015, 12, 5, 17, 18, 0, 450);
            this.ucDateTimeInterval1.Location = new System.Drawing.Point(9, 13);
            this.ucDateTimeInterval1.Name = "ucDateTimeInterval1";
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Size = new System.Drawing.Size(221, 74);
            this.ucDateTimeInterval1.StartDateTime = new System.DateTime(2015, 12, 5, 17, 18, 0, 453);
            this.ucDateTimeInterval1.TabIndex = 1;
            // 
            // ucDivision1
            // 
            this.ucDivision1.Location = new System.Drawing.Point(276, 10);
            this.ucDivision1.Name = "ucDivision1";
            this.ucDivision1.Size = new System.Drawing.Size(196, 68);
            this.ucDivision1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 22);
            this.statusStrip1.TabIndex = 121;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(863, 17);
            this.lblCount.Spring = true;
            this.lblCount.Text = "总共 0 项";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReadDate,
            this.colDevice,
            this.colDeviceType,
            this.colAmount});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(878, 356);
            this.dataGridView1.TabIndex = 122;
            // 
            // colReadDate
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.colReadDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colReadDate.HeaderText = "统计日期";
            this.colReadDate.Name = "colReadDate";
            this.colReadDate.ReadOnly = true;
            this.colReadDate.Width = 130;
            // 
            // colDevice
            // 
            this.colDevice.HeaderText = "设备";
            this.colDevice.Name = "colDevice";
            this.colDevice.ReadOnly = true;
            // 
            // colDeviceType
            // 
            this.colDeviceType.HeaderText = "设备类型";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "能耗";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // FrmReadLogStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 487);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReadLogStatistics";
            this.Text = "读表记录报表";
            this.Load += new System.EventHandler(this.FrmReadLogReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UCDivision ucDivision1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private LJH.GeneralLibrary.WinformControl.UCDateTimeInterval ucDateTimeInterval1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbDeviceType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdYear;
        private System.Windows.Forms.RadioButton rdMonth;
        private System.Windows.Forms.RadioButton rdDay;
        private System.Windows.Forms.CheckBox chkEachDevice;


    }
}