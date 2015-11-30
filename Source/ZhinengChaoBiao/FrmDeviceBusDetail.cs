using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.Model;
using LJH.ZNCB.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace ZhinengChaoBiao
{
    public partial class FrmDeviceBusDetail : FrmDetailBase
    {
        public FrmDeviceBusDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            cmbCommport.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("编号不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (cmbCommport.ComPort == 0)
            {
                MessageBox.Show("请选择串口号");
                return false;
            }
            if (string.IsNullOrEmpty(cmbBaud.Text))
            {
                MessageBox.Show("没有设置波特率");
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            DeviceBus ct = UpdatingItem as DeviceBus;
            txtID.Text = ct.ID;
            txtID.Enabled = false;
            txtName.Text = ct.Name;
            cmbCommport.ComPort = (byte)ct.Comport;
            cmbBaud.Text = ct.Baud.ToString();
        }

        protected override Object GetItemFromInput()
        {
            DeviceBus ct = UpdatingItem as DeviceBus ;
            if (IsAdding)
            {
                ct = new DeviceBus();
                ct.ID = txtID.Text != "自动创建" ? txtID.Text : string.Empty;
            }
            ct.Name = txtName.Text;
            ct.Comport = cmbCommport.ComPort;
            ct.Baud = int.Parse(cmbBaud.Text);
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new DeviceBusBLL(AppSettings.Current.ConnStr)).Add(addingItem as DeviceBus);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new DeviceBusBLL(AppSettings.Current.ConnStr)).Update(updatingItem as DeviceBus);
        }
        #endregion
    }
}
