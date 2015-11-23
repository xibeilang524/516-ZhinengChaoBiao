using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Model;

namespace ZhinengChaoBiao
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private string dbPath = "Data Source=" + Path.Combine(Application.StartupPath, "ZhinengChaoBiao.db");

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} [{1}]", "能源管理平台", Application.ProductVersion);
            AppSettings .Current .ConnStr ="SQLITE:" + dbPath;
            var alarm = new AlarmInfo()
            {
                ID = Guid.NewGuid(),
                AlarmDateTime = DateTime.Now,
                AlarmType = AlarmType.System,
                AlarmSource ="系统",
                AlarmDescr = "登录系统",
                OperatorID = "admin",
            };
            var ret = new AlarmInfoBLL(AppSettings.Current.ConnStr).Add(alarm);
        }
    }
}
