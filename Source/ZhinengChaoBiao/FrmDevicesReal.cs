using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LJH.ZNCB.Model;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Device;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace ZhinengChaoBiao
{
    public partial class FrmDevicesReal : Form
    {
        public FrmDevicesReal()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Device> _Devices = null;
        private List<DeviceBus> _Buses = null;
        private Thread _ReadValueThread = null;
        #endregion

        #region 重写基类方法
        private void ShowItemInGridViewRow(DataGridViewRow row, Device ct)
        {
            row.Tag = ct;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            var bus = _Buses.SingleOrDefault(it => it.ID == ct.Bus);
            row.Cells["colBus"].Value = bus != null ? bus.Name : null;
            row.Cells["colDeviceType"].Value = ct.DeviceType.ToString();
            row.Cells["colAddress"].Value = ct.Address;
            var d = facilityTree.GetDivision(ct.Division);
            row.Cells["colDivision"].Value = d != null ? d.Name : null;
            if (!_Devices.Exists(it => it.ID == ct.ID)) _Devices.Add(ct);
        }

        private DataGridViewRow GetRow(string deviceID)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var device = row.Tag as Device;
                if (device.ID == deviceID) return row;
            }
            return null;
        }

        private void ReadValue_Thread()
        {
            try
            {
                while (true)
                {
                    if (_Buses == null || _Buses.Count == 0) break;
                    if (_Devices == null || _Devices.Count == 0) break;
                    foreach (var d in _Devices)
                    {
                        var bus = _Buses.SingleOrDefault(it => it.ID == d.Bus);
                        decimal value = 0;
                        DateTime dt = DateTime.Now;
                        var ret = DeviceBusService.Instance.ReadValue((byte)bus.Comport, d.Address, out value);
                        this.Invoke((Action)(() =>
                            {
                                var row = GetRow(d.ID);
                                if (row != null)
                                {
                                    if (ret == BusResult.Success)
                                    {
                                        row.Cells["colReadDate"].Value = dt;
                                        row.Cells["colReadValue"].Value = value;
                                        row.Cells["colState"].Value = "在线";
                                        row.DefaultCellStyle.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        row.Cells["colState"].Value = "离线";
                                        row.DefaultCellStyle.ForeColor = Color.Red;
                                    }
                                }
                            }));
                    }
                    Thread.Sleep(2000);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
            }
            finally
            {
                _ReadValueThread = null;
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmDevicesReal_Load(object sender, EventArgs e)
        {
            this.facilityTree.Init();
            _Buses = new DeviceBusBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _Devices = (new DeviceBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            this.dataGridView1.Rows.Clear();
            if (_Devices != null)
            {
                foreach (var d in _Devices)
                {
                    int row = dataGridView1.Rows.Add();
                    ShowItemInGridViewRow(dataGridView1.Rows[row], d);
                }
                lblCount.Text = string.Format("共 {0} 项", _Devices.Count);
            }

            _ReadValueThread = new Thread(new ThreadStart(ReadValue_Thread));
            _ReadValueThread.IsBackground = true;
            _ReadValueThread.Start();
        }

        private void facilityTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var items = _Devices;
            if (items == null || items.Count == 0) return;
            if (facilityTree.SelectedNode != null && facilityTree.SelectedNode != facilityTree.Nodes[0])
            {
                var ds = facilityTree.GetDivisionofNode(facilityTree.SelectedNode);
                items = items.Where(it => ds.Exists(d => d.ID == it.Division)).ToList();
            }
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var device = row.Tag as Device;
                row.Visible = items != null && items.Exists(it => it.ID == device.ID);
                if (row.Visible) count++;
            }
            lblCount.Text = string.Format("共 {0} 项", count);
        }

        private void FrmDevicesReal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ReadValueThread != null) _ReadValueThread.Abort();
        }
        #endregion
    }
}
