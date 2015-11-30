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
    public partial class FrmDivisionMaster :LJH.GeneralLibrary.Core.UI. FrmMasterBase
    {
        public FrmDivisionMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Division> _depts = null;
        #endregion

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmDivisionDetail();
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                _depts = (new DivisionBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                _depts = (new DivisionBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (_depts != null)
            {
                return (from item in _depts select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Division ct = item as Division;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent) && _depts != null && _depts.Count > 0)
            {
                Division p = _depts.SingleOrDefault(it => it.ID == ct.Parent);
                row.Cells["colParent"].Value = p != null ? p.Name : string.Empty;
            }
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new DivisionBLL(AppSettings.Current.ConnStr)).Delete(item as Division);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
