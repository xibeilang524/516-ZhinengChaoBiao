using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ZhinengChaoBiao
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmDeviceReport_Load(object sender, EventArgs e)
        {
            // Create new data series and set it's visual attributes
            //////////////////////////////////////实验1///////////////////////////////////////////////
            Series series = new Series("曲线");
            series.ChartType = SeriesChartType.FastPoint;
            series.BorderWidth = 3;
            series.ShadowOffset = 2;

            // Populate new series with data
            series.Points.AddY(167);
            series.Points.AddY(157);
            series.Points.AddY(183);
            series.Points.AddY(123);
            series.Points.AddY(170);
            series.Points.AddY(160);
            series.Points.AddY(190);
            series.Points.AddY(120);
            series["ShowMarkerLines"] = "true";



            // Add series into the chart's series collection
            chart1.Series.Add(series);
            Title t = new Title("");
            chart1.Titles.Add(t);
        }
    }
}
