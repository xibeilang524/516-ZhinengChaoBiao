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
    public partial class FrmOperatorDetail : FrmDetailBase
    {
        private OperatorBLL bll = new OperatorBLL(AppSettings.Current.ConnStr);
        private string _subPwd = new string('*', 10);

        public FrmOperatorDetail()
        {
            InitializeComponent();
        }

        #region 重写基类的方法
        protected override void InitControls()
        {
            comRoleList.Init();
            if (IsAdding)
            {
                this.btnChangePwd.Visible = false;
                this.txtPassword.Size = this.txtOperatorName.Size;
            }
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btnOk.Enabled =  Operator.Current.Permit(Permission.Operator, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            Operator info = (Operator)UpdatingItem;
            this.txtOperatorID.Text = info.ID;
            this.txtOperatorID.Enabled = false;
            this.txtOperatorID.BackColor = Color.White;
            this.txtOperatorName.Text = info.Name;
            this.txtPassword.Text = _subPwd;
            this.txtPassword.Enabled = false;
            this.txtPassword.BackColor = Color.White;
            this.comRoleList.SelectedRoleID = info.RoleID;
            this.comRoleList.Enabled = info.CanEdit;
        }


        protected override object GetItemFromInput()
        {
            Operator info = null;
            if (CheckInput())
            {
                if (IsAdding)
                {
                    info = new Operator();
                    info.Password = txtPassword.Text.Trim();
                }
                else
                {
                    info = UpdatingItem as Operator;
                    if (txtPassword.Text.Trim() != _subPwd)
                    {
                        info.Password = txtPassword.Text.Trim();
                    }
                }
                info.ID = txtOperatorID.Text.Trim();
                info.Name = txtOperatorName.Text.Trim();
                info.Role = comRoleList.Role;
                info.RoleID = comRoleList.SelectedRoleID;
            }
            return info;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return bll.Add((Operator)addingItem);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return bll.Update(updatingItem as Operator);
        }

        protected override bool CheckInput()
        {
            if (txtOperatorID.Text.Trim().Length == 0)
            {
                MessageBox.Show("操作员登录ID不能为空!");
                return false;
            }

            if (txtOperatorName.Text.Trim().Length == 0)
            {
                MessageBox.Show("操作员姓名不能为空!");
                return false;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("操作员密码不能为空!");
                return false;
            }
            return true;
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            FrmChangePwd frm = new FrmChangePwd();
            frm.Operator = UpdatingItem as Operator;
            frm.ShowDialog();
        }
        #endregion
    }
}
