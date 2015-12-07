using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.Security;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace ZhinengChaoBiao
{
    public partial class FrmRoleMaster : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        private List<Role> roles;

        public FrmRoleMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法及事件处理
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmRoleDetail();
        }

        protected override bool DeletingItem(object item)
        {
            RoleBLL bll = new RoleBLL(AppSettings.Current.ConnStr);
            Role info = (Role)item;
            CommandResult result = bll.Delete(info);
            if (result.Result != ResultCode.Successful)
            {
                MessageBox.Show(result.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            RoleBLL bll = new RoleBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                roles = bll.GetItems(null).QueryObjects.ToList();
            }
            else
            {
                roles = bll.GetItems(SearchCondition).QueryObjects.ToList();
            }
            List<object> source = new List<object>();
            foreach (object o in roles)
            {
                source.Add(o);
            }
            return source;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Role info = item as Role;
            row.Tag = item;
            row.Cells["colName"].Value = info.Name;
            row.Cells["colMemo"].Value = info.Memo;
        }

        protected override void Init()
        {
            base.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Role, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Role, PermissionActions.Edit);
        }
        #endregion
    }
}
