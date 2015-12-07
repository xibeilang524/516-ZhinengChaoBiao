using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Model;

namespace ZhinengChaoBiao.Controls
{
    public partial class UCDivision : UserControl
    {
        public UCDivision()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void InitCmbDivision()
        {
            List<Division> divisions = new DivisionBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            cmbDivision.DataSource = null;
            if (divisions != null && divisions.Count > 0)
            {
                List<Division> items = new List<Division>();
                items.Add(new Division() { ID = string.Empty, Name = string.Empty });
                items.AddRange(from it in divisions orderby it.Name ascending select it);
                cmbDivision.DataSource = items;
                cmbDivision.DisplayMember = "Name";
            }
            cmbDivision.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitCmbDevice()
        {
            cmbDevice.DataSource = null;
            List<Device> items = new DeviceBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            Division d = cmbDivision.SelectedItem as Division;
            if (d != null && !string.IsNullOrEmpty(d.ID))
            {
                List<Division> ds = GetDesendents(d);
                items = items.Where(it => ds.Exists(item => item.ID == it.Division)).ToList();
            }
            items.Insert(0, new Device { ID = string.Empty, Name = string.Empty });
            cmbDevice.DataSource = items;
            cmbDevice.DisplayMember = "Name";
            cmbDevice.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private List<Division> GetDesendents(Division division)
        {
            if (division != null)
            {
                var _Divisions = new DivisionBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                List<Division> chs = new List<Division>();
                if (_Divisions != null && _Divisions.Count > 0)
                {
                    foreach (Division d in _Divisions)
                    {
                        if (IsDescendantOf(d, division, _Divisions)) chs.Add(d);
                    }
                }
                return chs;
            }
            return null;
        }

        private bool IsDescendantOf(Division d1, Division d2, List<Division> allDivisions)
        {
            bool ret = false;
            if (d1.ID == d2.ID) return true;
            if (string.IsNullOrEmpty(d1.Parent)) return false;
            if (d1.Parent == d2.ID) return true;
            Division d = allDivisions.SingleOrDefault(it => it.ID == d1.Parent);
            if (d != null) return IsDescendantOf(d, d2, allDivisions);
            return ret;
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCmbDevice();
        }
        #endregion

        public void Init()
        {
            InitCmbDivision();
            InitCmbDevice();
        }

        public List<Device> GetSelectedDevices()
        {
            List<Device> ret = null;
            if (!string.IsNullOrEmpty(cmbDevice.Text))
            {
                ret = new List<Device>();
                ret.Add(cmbDevice.SelectedItem as Device);
            }
            else if (!string.IsNullOrEmpty(cmbDivision.Text))
            {
                ret = new List<Device>();
                ret.AddRange(cmbDevice.DataSource as List<Device>);
                ret.RemoveAll(it => string.IsNullOrEmpty(it.ID));
            }
            return ret;
        }
    }
}
