﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.SearchCondition;
using LJH.ZNCB.BLL;

namespace ZhinengChaoBiao
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private List<Device> _Devices = null;
        private List<DeviceReadLog> _ReadLogs = null;


        #region 私有方法
        private void InitCharts()
        {
            InitChart(chtMonthEnergy);
            chtMonthEnergy.Titles.Add("本月用电量");
            chtMonthEnergy.ChartAreas["ChartArea1"].AxisY.Interval = 10;
            chtMonthEnergy.ChartAreas["ChartArea1"].AxisX.Title = "日期";
            InitChart(chtMonthWater);
            chtMonthWater.Titles.Add("本月用水量");
            chtMonthWater.ChartAreas["ChartArea1"].AxisY.Interval = 10;
            chtMonthWater.ChartAreas["ChartArea1"].AxisX.Title = "日期";
            InitChart(chtYearWater);
            chtYearWater.Titles.Add("最近一年用水量");
            chtYearWater.ChartAreas["ChartArea1"].AxisY.Interval = 100;
            chtYearWater.ChartAreas["ChartArea1"].AxisX.Title = "月份";
            InitChart(chtYearEnergy);
            chtYearEnergy.Titles.Add("最近一年用电量");
            chtYearEnergy.ChartAreas["ChartArea1"].AxisY.Interval = 100;
            chtYearEnergy.ChartAreas["ChartArea1"].AxisX.Title = "月份";
        }

        private void InitChart(Chart chart)
        {
            //作图区的显示属性设置
            chart.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;
            chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            //背景色设置
            chart.ChartAreas["ChartArea1"].ShadowColor = Color.Transparent;
            chart.ChartAreas["ChartArea1"].BackColor = Color.Azure;         //该处设置为了由天蓝到白色的逐渐变化
            chart.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;
            chart.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
            //X,Y坐标线颜色和大小
            chart.ChartAreas["ChartArea1"].AxisX.LineColor = Color.Blue;
            chart.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Blue;
            chart.ChartAreas["ChartArea1"].AxisX.LineWidth = 2;
            chart.ChartAreas["ChartArea1"].AxisY.LineWidth = 2;
            //中间X,Y线条的颜色设置
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Blue;
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.Blue;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //X.Y轴数据显示间隔
            chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;  //X轴数据显示间隔
            //X轴线条显示间隔
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
            chart.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;
        }

        private void FillChart(Chart chart, Color color, IEnumerable<IGrouping<string, DeviceReadLog>> data)
        {
            chart.Series.Clear();
            if (data != null)
            {
                Series series1 = new Series("test");        //数据集声明  
                series1.ChartType = SeriesChartType.Line;   //数据显示方式 Line:为折线  Spline:曲线 
                series1.Color = color;              //线条颜色
                series1.BorderWidth = 2;                    //线条宽度
                series1.ShadowOffset = 1;                   //阴影宽度
                series1.IsVisibleInLegend = false;           //是否显示数据说明
                series1.IsValueShownAsLabel = false;        //线条上是否给吃数据的显示
                series1.MarkerStyle = MarkerStyle.Diamond;   //线条上的数据点标志类型
                series1.MarkerSize = 10;                     //              标志的大小
                foreach (var w in data)
                {
                    series1.Points.AddXY(w.Key, w.Sum(it => it.Amount));
                }
                chart.Series.Add(series1);
            }
        }
        #endregion

        public void FreshData()
        {
            _Devices = new DeviceBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;

            var con = new DeviceReadLogSearchCondition();
            con.ReadDateRange = new DateTimeRange(DateTime.Today.AddMonths(-12), DateTime.Now);
            _ReadLogs = new DeviceReadLogBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;

            divisionTree1.Init();
            divisionTree1_NodeMouseClick(divisionTree1, null);
        }

        #region 事件处理函数

        private void FrmDeviceReport_Load(object sender, EventArgs e)
        {
            this.divisionTree1.Init();
            InitCharts();
            btnFresh.PerformClick();
        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            FreshData();
        }

        private void FillCharts(List<DeviceReadLog> logs)
        {
            DateTime dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var montEenergies = from it in logs
                                where it.DeviceType == DeviceType.智能电表 && it.ReadDate >= dt
                                orderby it.ReadDate ascending
                                group it by it.ReadDate.ToString("dd日");
            FillChart(chtMonthEnergy, Color.Red, montEenergies);

            var monthWaters = from it in logs
                              where it.DeviceType == DeviceType.智能水表 && it.ReadDate >= dt
                              orderby it.ReadDate ascending
                              group it by it.ReadDate.ToString("dd日");
            FillChart(chtMonthWater, Color.Green, monthWaters);

            var yearenergies = from it in logs
                               where it.DeviceType == DeviceType.智能电表
                               orderby it.ReadDate ascending
                               group it by it.ReadDate.ToString("yyyy年MM月");
            FillChart(chtYearEnergy, Color.Red, yearenergies);

            var yearWaters = from it in logs
                             where it.DeviceType == DeviceType.智能水表
                             orderby it.ReadDate ascending
                             group it by it.ReadDate.ToString("yyyy年MM月");
            FillChart(chtYearWater, Color.Green, yearWaters);
        }

        private void divisionTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_ReadLogs == null || _ReadLogs.Count == 0) return;
            if (_Devices == null || _Devices.Count == 0) return;

            var devices = _Devices;
            if (divisionTree1.SelectedNode != null && divisionTree1.SelectedNode.Tag != null)
            {
                var ds = divisionTree1.GetDivisionofNode(divisionTree1.SelectedNode);
                if (ds != null && ds.Count > 0) devices = devices.Where(it => ds.Exists(d => d.ID == it.Division)).ToList();
            }
            if (devices != null && devices.Count > 0)
            {
                var logs = _ReadLogs.Where(it => devices.Exists(d => d.ID == it.DeviceID)).ToList();
                FillCharts(logs);
            }
        }
        #endregion
    }
}
