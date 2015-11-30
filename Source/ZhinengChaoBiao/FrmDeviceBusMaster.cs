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
    public partial class FrmDeviceBusMaster :LJH.GeneralLibrary.Core.UI. FrmMasterBase
    {
        public FrmDeviceBusMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<DeviceBus> _depts = null;
        #endregion

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmDeviceBusDetail();
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                _depts = (new DeviceBusBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                _depts = (new DeviceBusBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (_depts != null)
            {
                return (from item in _depts select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            DeviceBus ct = item as DeviceBus;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colComport"].Value = "COM" + ct.Comport.ToString();
            row.Cells["colBaud"].Value = ct.Baud;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new DeviceBusBLL(AppSettings.Current.ConnStr)).Delete(item as DeviceBus);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
