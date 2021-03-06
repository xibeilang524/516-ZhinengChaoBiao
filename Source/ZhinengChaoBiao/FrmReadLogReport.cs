﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.SearchCondition;

namespace ZhinengChaoBiao
{
    public partial class FrmReadLogReport : Form
    {
        public FrmReadLogReport()
        {
            InitializeComponent();
        }

        List<Device> _Devices = null;

        private void ShowItemsOnGrid(List<DeviceReadLog> items)
        {
            this.dataGridView1.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                _Devices = new DeviceBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                items = (from it in items
                         orderby it.ReadDate ascending
                         select it).ToList();
                foreach (var item in items)
                {
                    int row = dataGridView1.Rows.Add();
                    ShowItemOnRow(dataGridView1.Rows[row], item);
                }
            }
            lblCount.Text = string.Format("共 {0} 项", dataGridView1.Rows.Count);
        }

        private void ShowItemOnRow(DataGridViewRow row, DeviceReadLog log)
        {
            row.Tag = log;
            row.Cells["colReadDate"].Value = log.ReadDate;
            row.Cells["colDevice"].Value = log.DeviceName;
            row.Cells["colDeviceType"].Value = log.DeviceType == DeviceType.智能电表 ? "用电" : (log.DeviceType == DeviceType.智能水表 ? "用水" : null);
            row.Cells["colValue"].Value = log.ReadValue;
            row.Cells["colLastDate"].Value = log.LastDate;
            row.Cells["colLastValue"].Value = log.LastValue;
            row.Cells["colAmount"].Value = log.Amount;
        }

        private void FrmReadLogReport_Load(object sender, EventArgs e)
        {
            this.ucDivision1.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var con = new DeviceReadLogSearchCondition();
            con.ReadDateRange = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            var deivces = ucDivision1.GetSelectedDevices();
            if (deivces != null && deivces.Count > 0) con.Devices = deivces.Select(it => it.ID).ToList();
            if (!string.IsNullOrEmpty(cmbDeviceType.Text)) con.DeviceType = (DeviceType)cmbDeviceType.SelectedIndex;
           
            var items = new DeviceReadLogBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            ShowItemsOnGrid(items);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView view = this.dataGridView1;
                if (view != null)
                {
                    SaveFileDialog dig = new SaveFileDialog();
                    dig.Filter = "Excel文档|*.xls;*.xlsx|所有文件(*.*)|*.*";
                    dig.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (dig.ShowDialog() == DialogResult.OK)
                    {
                        string path = dig.FileName;
                        NPOIExcelHelper.Export(view, path);
                        MessageBox.Show("导出成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存到电子表格时出现错误!");
            }
        }

    }
}
