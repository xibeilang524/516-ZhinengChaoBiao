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
using LJH.ZNCB.Model.Security;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace ZhinengChaoBiao
{
    public partial class FrmOperatorMaster : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        private List<Operator> operators;
        private OperatorBLL bll = new OperatorBLL(AppSettings.Current.ConnStr);

        public FrmOperatorMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmOperatorDetail();
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                operators = bll.GetItems(null).QueryObjects.ToList();
            }
            else
            {
                operators = bll.GetItems(SearchCondition).QueryObjects.ToList();
            }
            List<object> source = new List<object>();
            foreach (object o in operators)
            {
                source.Add(o);
            }
            return source;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Operator info = item as Operator;
            row.Tag = info;
            row.Cells["colOperatorID"].Value = info.ID;
            row.Cells["colOperatorName"].Value = info.Name;
            row.Cells["colRoleID"].Value = info.Role != null ? info.Role.Name : string.Empty;
        }

        protected override bool DeletingItem(object item)
        {
            Operator info = (Operator)item;
            CommandResult ret = bll.Delete(info);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override void Init()
        {
            base.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Operator, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Operator, PermissionActions.Edit);
        }

        #endregion
    }
}
