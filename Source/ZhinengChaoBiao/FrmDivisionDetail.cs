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
    public partial class FrmDivisionDetail : FrmDetailBase
    {
        public FrmDivisionDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public Division ParentDivision { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtParentCategory.Text = ParentDivision != null ? ParentDivision.Name : string.Empty;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("区域编码不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (ParentDivision != null && UpdatingItem != null && ParentDivision.ID == (UpdatingItem as Division).ID)
            {
                MessageBox.Show("区域的上级区域不能是本区域");
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            Division ct = UpdatingItem as Division;
            txtID.Text = ct.ID;
            txtID.Enabled = false;
            txtName.Text = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent))
            {
                ParentDivision = (new DivisionBLL(AppSettings.Current.ConnStr)).GetByID(ct.Parent).QueryObject;
                txtParentCategory.Text = ParentDivision != null ? ParentDivision.Name : string.Empty;
            }
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            Division ct = UpdatingItem as Division;
            if (IsAdding)
            {
                ct = new Division();
                ct.ID = txtID.Text;
            }
            ct.Name = txtName.Text;
            ct.Parent = ParentDivision != null ? ParentDivision.ID : null;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new DivisionBLL(AppSettings.Current.ConnStr)).Add(addingItem as Division);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new DivisionBLL(AppSettings.Current.ConnStr)).Update(updatingItem as Division);
        }
        #endregion

        #region 事件处理程序
        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDivisionMaster frm = new FrmDivisionMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentDivision = frm.SelectedItem as Division;
                txtParentCategory.Text = ParentDivision != null ? ParentDivision.Name : string.Empty;
            }
        }

        private void txtParentCategory_DoubleClick(object sender, EventArgs e)
        {
            ParentDivision = null;
            txtParentCategory.Text = ParentDivision != null ? ParentDivision.Name : string.Empty;
        }
        #endregion
    }
}
