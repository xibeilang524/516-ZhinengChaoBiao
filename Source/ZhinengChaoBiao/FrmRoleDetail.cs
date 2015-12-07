using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.Security;
using LJH.ZNCB.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace ZhinengChaoBiao
{
    public partial class FrmRoleDetail :FrmDetailBase 
    {
        private RoleBLL bll = new RoleBLL(AppSettings.Current.ConnStr);

        public FrmRoleDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override  bool CheckInput()
        {
            if (string.IsNullOrEmpty (this.txtName.Text.Trim()))
            {
                MessageBox .Show ("角色名称不能为空!");
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            functionTree1.Init();
            if (IsAdding)
            {
                this.Text = "增加角色";
            }
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btnOk.Enabled = Operator.Current.Permit(Permission.Role, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            Role info = (Role)UpdatingItem;
            this.txtName.Text = info != null ? info.Name : string.Empty;
            this.txtMemo.Text = info.Memo;
            this.functionTree1.SelectedRights = info.Permission;
            if (info.IsAdmin) this.functionTree1.Enabled = false;
            this.Text ="角色 "+ info.ID + " 的信息";
        }

        protected override object GetItemFromInput()
        {
            Role info;
            if (UpdatingItem == null)
            {
                info = new Role();
                info.ID = txtName.Text;
            }
            else
            {
                info = UpdatingItem as Role;
            }
            info.Name = txtName.Text.Trim();
            info.Memo = this.txtMemo.Text.Trim();
            info.Permission = this.functionTree1.SelectedRights;
            return info;
        }

        protected override CommandResult  AddItem(object item)
        {
            return bll.Add ((Role)item);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return bll.Update(item as Role);
        }
        #endregion
    }
}
