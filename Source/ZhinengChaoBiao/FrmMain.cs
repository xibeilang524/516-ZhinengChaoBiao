using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using LJH.ZNCB.BLL;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.Security;
using LJH.ZNCB.Device;
using LJH.GeneralLibrary.Core.UI;

namespace ZhinengChaoBiao
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Form> _openedForms = new List<Form>();
        private DateTime _ExpireDate = new DateTime(2015, 12, 31);
        private Thread _ReadValueThread = null;
        #endregion

        #region 私有方法
        private void ReadValue_Thread()
        {
            try
            {
                bool hasRead = false;
                while (true)
                {
                    DateTime dt = DateTime.Now;
                    if (dt.Hour == 23)
                    {
                        if (!hasRead)
                        {
                            hasRead = true;
                            var _Buses = new DeviceBusBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                            var _Devices = (new DeviceBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
                            if (_Buses == null || _Buses.Count == 0) continue;
                            if (_Devices == null || _Devices.Count == 0) continue;
                            foreach (var d in _Devices)
                            {
                                var bus = _Buses.SingleOrDefault(it => it.ID == d.Bus);
                                if (bus != null)
                                {
                                    decimal value = 0;
                                    var ret = DeviceBusService.Instance.ReadValue((byte)bus.Comport, d.Address, out value);
                                    if (ret == BusResult.Success)
                                    {
                                        new DeviceBLL(AppSettings.Current.ConnStr).AddReadLog(d.ID, DateTime.Now, value);
                                    }
                                }
                            }
                            this.Invoke((Action)(() =>
                                                    {
                                                        foreach (Form frm in _openedForms)  //如果主页已经打开，刷新主页
                                                        {
                                                            if (frm is FrmHome)
                                                            {
                                                                (frm as FrmHome).FreshData();
                                                                break;
                                                            }
                                                        }
                                                    }));
                        }
                    }
                    else
                    {
                        hasRead = false;
                    }
                    Thread.Sleep(60000);
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

        #region 公共方法
        /// <summary>
        /// 显示窗口的单个实例，如果之前已经打开过，则只是激活打开过的窗体
        /// </summary>
        /// <param name="formType">要打开的窗体类型</param>
        /// <param name="mainPanel">是否在主面板中打开,否则在从面板中打开</param>
        public T ShowSingleForm<T>(bool mainPanel = true) where T : Form
        {
            T instance = null;
            foreach (Form frm in _openedForms)
            {
                if (frm.GetType() == typeof(T))
                {
                    ucFormView1.ActiveForm(frm);
                    instance = frm as T;
                    break;
                }
            }
            if (instance == null)
            {
                instance = Activator.CreateInstance(typeof(T)) as T;
                instance.Tag = this;
                instance.TopLevel = false;
                _openedForms.Add(instance);
                this.ucFormView1.AddAForm(instance);
                instance.FormClosed += delegate(object sender, FormClosedEventArgs e)
                {
                    _openedForms.Remove(instance);
                };
            }
            return instance;
        }

        private void DoLogIn()
        {
            DialogResult ret = (new FrmLogin()).ShowDialog();
            if (ret == DialogResult.OK)
            {
                this.lblOperator.Text = Operator.Current.Name;
                ShowState();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void ShowState()
        {
            ShowOperatorRights();
            foreach (var frm in _openedForms)
            {
                if (frm is FrmMasterBase)
                {
                    (frm as FrmMasterBase).ShowOperatorRights();
                }
            }
        }

        private void ShowOperatorRights()
        {
            Operator cur = Operator.Current;
        }
        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (DateTime.Today > _ExpireDate)
            {
                MessageBox.Show("软件已经过期,请联系供应商");
                Environment.Exit(0);
            }
            this.Text = string.Format("{0} [{1}]", "能源管理平台", Application.ProductVersion);
            DoLogIn();
            mnu_Home.PerformClick();

            _ReadValueThread = new Thread(new ThreadStart(ReadValue_Thread));
            _ReadValueThread.IsBackground = true;
            _ReadValueThread.Start();
        }

        private void mnu_Division_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDivisionMaster>();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeviceBusMaster>();
        }

        private void mnu_Device_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDeviceMaster>();
        }

        private void mnu_Home_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmHome>();
        }

        private void mnu_ReadLogReport_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmReadLogReport>();
        }

        private void mnu_Statistics_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmReadLogStatistics>();
        }

        private void mnu_Operator_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmOperatorMaster>();
        }

        private void mnu_Role_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmRoleMaster>();
        }

        private void mnu_DevicesReal_Click(object sender, EventArgs e)
        {
            ShowSingleForm<FrmDevicesReal>();
        }
        #endregion
    }
}
