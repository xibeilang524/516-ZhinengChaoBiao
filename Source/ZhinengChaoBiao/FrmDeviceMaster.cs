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
    public partial class FrmDeviceMaster : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        public FrmDeviceMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Device> _Devices = null;
        private List<DeviceBus> _Buses = null;
        #endregion

        #region 私有方法
        private List<object> FilterData()
        {
            var items = _Devices;
            if (items == null || items.Count == 0) return null;
            if (facilityTree.SelectedNode != null && facilityTree.SelectedNode != facilityTree.Nodes[0])
            {
                var ds = facilityTree.GetDivisionofNode(facilityTree.SelectedNode);
                items = items.Where(it => ds.Exists(d => d.ID == it.Division)).ToList();
            }
            if (items != null && items.Count > 0) return items.Select(it => (object)it).ToList();
            return null;
        }
        #endregion

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            var frm = new FrmDeviceDetail();
            if (facilityTree.SelectedNode != null && facilityTree.SelectedNode.Tag != null)
            {
                Division pc = facilityTree.SelectedNode.Tag as Division;
                if (pc != null) frm.ParentDivision = pc;
            }
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            this.facilityTree.Init();
            _Buses = new DeviceBusBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (SearchCondition == null)
            {
                _Devices = (new DeviceBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                _Devices = (new DeviceBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (_Devices != null)
            {
                return FilterData();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Device ct = item as Device;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            var bus = _Buses.SingleOrDefault(it => it.ID == ct.Bus);
            row.Cells["colBus"].Value = bus != null ? bus.Name : null;
            row.Cells["colDeviceType"].Value = ct.DeviceType.ToString();
            row.Cells["colAddress"].Value = ct.Address;
            row.Cells["colState"].Value = ct.State;
            row.Cells["colLastDt"].Value = ct.LastDate;
            //row.Cells["colLastValue"].Value = ct.LastValue;
            var d = facilityTree.GetDivision(ct.Division);
            row.Cells["colDivision"].Value = d != null ? d.Name : null;
            if (!_Devices.Exists(it => it.ID == ct.ID)) _Devices.Add(ct);
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new DeviceBLL(AppSettings.Current.ConnStr)).Delete(item as Device);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion

        #region 事件处理程序
        private void facilityTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var items = FilterData();
            ShowItemsOnGrid(items);
        }

        private void mnu_AddDivision_Click(object sender, EventArgs e)
        {
            Division pc = facilityTree.SelectedNode.Tag as Division;
            FrmDivisionDetail frm = new FrmDivisionDetail();
            frm.IsAdding = true;
            frm.ParentDivision = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                Division item = args.AddedItem as Division;
                facilityTree.AddDivisionNode(item, facilityTree.SelectedNode);
                facilityTree.SelectedNode.Expand();
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteDivision_Click(object sender, EventArgs e)
        {
            Division pc = facilityTree.SelectedNode.Tag as Division;
            if (pc != null && MessageBox.Show("是否删除此区域?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new DivisionBLL(AppSettings.Current.ConnStr)).Delete(pc);
                if (ret.Result == ResultCode.Successful)
                {
                    facilityTree.SelectedNode.Parent.Nodes.Remove(facilityTree.SelectedNode);
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_DivisionProperty_Click(object sender, EventArgs e)
        {
            Division pc = facilityTree.SelectedNode.Tag as Division;
            if (pc != null)
            {
                FrmDivisionDetail frm = new FrmDivisionDetail();
                frm.IsAdding = false;
                frm.UpdatingItem = pc;
                frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
                {
                    facilityTree.Init();
                    facilityTree.SelectNode(pc.ID);
                };
                frm.ShowDialog();
            }
        }

        private void mnu_AddDevice_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }

        private void 模拟读表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                FrmRead frm = new FrmRead();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Device = this.dataGridView1.SelectedRows[0].Tag as Device;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var d = new DeviceBLL(AppSettings.Current.ConnStr).GetByID(frm.Device.ID).QueryObject;
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], d);
                }
            }
        }
        #endregion
    }
}
