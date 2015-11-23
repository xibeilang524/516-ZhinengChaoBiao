using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ZhinengChaoBiao
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private string dbPath = "Data Source=" + Path.Combine(Application.StartupPath, "ZhinengChaoBiao.db");
    }
}
