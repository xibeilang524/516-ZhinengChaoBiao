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

namespace ZhinengChaoBiao
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        public  Operator Operator{get;set;}

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            if (Operator.Current.ID.ToLower() == "admin" && Operator.ID.ToLower() != "admin")  //
            {
                txtOldPwd.Enabled = false;
                txtOldPwd.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                OperatorBLL bll = new OperatorBLL(AppSettings.Current.ConnStr);
                Operator.Password = txtNewPwd.Text;
                CommandResult result=bll.Update (Operator );
                if (result.Result == ResultCode.Successful)
                {
                    this.Close();
                }
                else
                {
                    Operator.Password = txtOldPwd.Text;
                    MessageBox.Show(result.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInput()
        {
            if (Operator.Current.ID.ToLower() == "admin" && Operator.ID.ToLower() != "admin")  //
            {
            }
            else
            {
                if (Operator.Password != txtOldPwd.Text)
                {
                    MessageBox.Show("旧密码输入不正确!");
                    txtOldPwd.SelectAll();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtNewPwd.Text))
            {
                MessageBox.Show("新密码不能为空!");
                txtNewPwd.SelectAll();
                return false;
            }
            if (txtNewPwd.Text != txtConfirmPwd.Text)
            {
                MessageBox.Show("新密码与确认密码不一致!");
                txtConfirmPwd.SelectAll();
                return false;
            }
            return true;
        }
    }
}
