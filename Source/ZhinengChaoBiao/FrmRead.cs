using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB .Model ;
using LJH.ZNCB.BLL;
using LJH.GeneralLibrary.Core.DAL;

namespace ZhinengChaoBiao
{
    public partial class FrmRead : Form
    {
        public FrmRead()
        {
            InitializeComponent();
        }

        public Device Device { get; set; }

        private void FrmRead_Load(object sender, EventArgs e)
        {
            if (Device != null)
            {
                var d = new DeviceBLL(AppSettings.Current.ConnStr).GetByID(Device.ID).QueryObject;
                if (d != null)
                {
                    txtLastValue.DecimalValue = d.LastValue.HasValue ? d.LastValue.Value : 0;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Device != null && Device.LastValue >= txtValue.DecimalValue)
            {
                MessageBox.Show("表读数小于表的上次读数");
                return;
            }
            var ret = new DeviceBLL(AppSettings.Current.ConnStr).AddReadLog(Device.ID, DateTime.Now, txtValue.DecimalValue);
            if (ret.Result == ResultCode.Successful)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        
    }
}
