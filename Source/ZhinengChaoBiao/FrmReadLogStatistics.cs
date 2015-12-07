using System;
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
    public partial class FrmReadLogStatistics: Form
    {
        public FrmReadLogStatistics()
        {
            InitializeComponent();
        }

        private void ShowItemsOnGrid(List<DeviceReadLog> items)
        {
            this.dataGridView1.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                var gs = from it in items
                         orderby it.ReadDate ascending
                         group it by GetKey(it);
                foreach (var g in gs)
                {
                    int row = dataGridView1.Rows.Add();
                    ShowItemOnRow(dataGridView1.Rows[row], g);
                }
            }
            lblCount.Text = string.Format("共 {0} 项", dataGridView1.Rows.Count);
        }

        private string GetKey(DeviceReadLog log)
        {
            var key = log.DeviceType == DeviceType.智能电表 ? "用电" : (log.DeviceType == DeviceType.智能水表 ? "用水" : "其它");
            if (rdDay.Checked) key += "," + log.ReadDate.ToString("yyyy年MM月dd日");
            else if (rdMonth.Checked) key += "," + log.ReadDate.ToString("yyyy年MM月");
            else if (rdYear.Checked) key += "," + log.ReadDate.ToString("yyyy年");

            if (chkEachDevice.Checked) key += "," + log.DeviceID;
            return key;
        }

        private void ShowItemOnRow(DataGridViewRow row, IGrouping<string, DeviceReadLog> g)
        {
            row.Tag = g;
            string[] temp = g.Key.Split(',');
            row.Cells["colReadDate"].Value = temp[1];
            row.Cells["colDevice"].Value = temp.Length >= 3 ? g.First().DeviceName : null; //表示按设备来统计
            row.Cells["colDeviceType"].Value = temp[0];
            row.Cells["colAmount"].Value = g.Sum(it => it.Amount);
        }

        private void FrmReadLogReport_Load(object sender, EventArgs e)
        {
            this.ucDivision1.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisYear();
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
