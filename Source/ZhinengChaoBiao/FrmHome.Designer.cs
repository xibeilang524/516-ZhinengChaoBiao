namespace ZhinengChaoBiao
{
    partial class FrmHome
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chtYearEnergy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtYearWater = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtMonthWater = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtMonthEnergy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtYearEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtYearWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMonthWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMonthEnergy)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 50);
            this.panel2.TabIndex = 65;
            // 
            // btnFresh
            // 
            this.btnFresh.Location = new System.Drawing.Point(769, 12);
            this.btnFresh.Name = "btnFresh";
            this.btnFresh.Size = new System.Drawing.Size(108, 31);
            this.btnFresh.TabIndex = 0;
            this.btnFresh.Text = "刷新(&F)";
            this.btnFresh.UseVisualStyleBackColor = true;
            this.btnFresh.Click += new System.EventHandler(this.btnFresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 466);
            this.panel1.TabIndex = 66;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chtYearEnergy, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chtYearWater, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chtMonthWater, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chtMonthEnergy, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 466);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // chtYearEnergy
            // 
            chartArea1.Name = "ChartArea1";
            this.chtYearEnergy.ChartAreas.Add(chartArea1);
            this.chtYearEnergy.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.ItemColumnSpacing = 10;
            legend1.Name = "Legend1";
            this.chtYearEnergy.Legends.Add(legend1);
            this.chtYearEnergy.Location = new System.Drawing.Point(3, 236);
            this.chtYearEnergy.Name = "chtYearEnergy";
            this.chtYearEnergy.Size = new System.Drawing.Size(354, 227);
            this.chtYearEnergy.TabIndex = 5;
            this.chtYearEnergy.Text = "chart1";
            // 
            // chtYearWater
            // 
            chartArea2.Name = "ChartArea1";
            this.chtYearWater.ChartAreas.Add(chartArea2);
            this.chtYearWater.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.ItemColumnSpacing = 10;
            legend2.Name = "Legend1";
            this.chtYearWater.Legends.Add(legend2);
            this.chtYearWater.Location = new System.Drawing.Point(363, 236);
            this.chtYearWater.Name = "chtYearWater";
            this.chtYearWater.Size = new System.Drawing.Size(355, 227);
            this.chtYearWater.TabIndex = 4;
            this.chtYearWater.Text = "chart1";
            // 
            // chtMonthWater
            // 
            chartArea3.Name = "ChartArea1";
            this.chtMonthWater.ChartAreas.Add(chartArea3);
            this.chtMonthWater.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.ItemColumnSpacing = 10;
            legend3.Name = "Legend1";
            this.chtMonthWater.Legends.Add(legend3);
            this.chtMonthWater.Location = new System.Drawing.Point(3, 3);
            this.chtMonthWater.Name = "chtMonthWater";
            this.chtMonthWater.Size = new System.Drawing.Size(354, 227);
            this.chtMonthWater.TabIndex = 3;
            this.chtMonthWater.Text = "chart2";
            title1.Name = "adc";
            this.chtMonthWater.Titles.Add(title1);
            // 
            // chtMonthEnergy
            // 
            chartArea4.Name = "ChartArea1";
            this.chtMonthEnergy.ChartAreas.Add(chartArea4);
            this.chtMonthEnergy.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.ItemColumnSpacing = 10;
            legend4.Name = "Legend1";
            this.chtMonthEnergy.Legends.Add(legend4);
            this.chtMonthEnergy.Location = new System.Drawing.Point(363, 3);
            this.chtMonthEnergy.Name = "chtMonthEnergy";
            this.chtMonthEnergy.Size = new System.Drawing.Size(355, 227);
            this.chtMonthEnergy.TabIndex = 1;
            this.chtMonthEnergy.Text = "chart1";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(721, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 466);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(727, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 466);
            this.panel3.TabIndex = 7;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 516);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHome";
            this.Text = "主页";
            this.Load += new System.EventHandler(this.FrmDeviceReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtYearEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtYearWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMonthWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMonthEnergy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMonthWater;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMonthEnergy;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtYearEnergy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtYearWater;
    }
}