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

namespace ZhinengChaoBiao
{
    public partial class FrmReadLogReport : Form
    {
        public FrmReadLogReport()
        {
            InitializeComponent();
        }

        private void FrmReadLogReport_Load(object sender, EventArgs e)
        {
            this.ucDivision1.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
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
