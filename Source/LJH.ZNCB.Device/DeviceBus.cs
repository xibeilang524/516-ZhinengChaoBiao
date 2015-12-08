using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading ;
using LJH.GeneralLibrary;

namespace LJH.ZNCB.Device
{
    internal class DeviceBus
    {
        #region 构造函数
        public DeviceBus(byte comport, int baud)
        {
            Comport = comport;
            _Commport = new CommPort(comport, baud);
        }
        #endregion

        #region 私有变量
        private CommPort _Commport = null;

        private object _DataLocker = new object();
        private List<byte> _RecievedData = new List<byte>();
        private AutoResetEvent _PacketReceived = new AutoResetEvent(false);
        private Packet _Response = null;
        #endregion

        #region 私有方法
        private void Commport_OnDataArrivedEvent(object sender, byte[] data)
        {
            lock (_DataLocker)
            {
                _RecievedData.AddRange(data);
                _Response = Packet.GetPacket(_RecievedData);
                if (_Response != null) _PacketReceived.Set();
            }
        }
        #endregion

        #region 公共属性
        public byte Comport { get; set; }
        /// <summary>
        /// 获取读卡器是否已经打开
        /// </summary>
        public bool IsOpened
        {
            get { return _Commport.PortOpened; }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 打开
        /// </summary>
        public void Open()
        {
            if (_Commport.PortOpened) _Commport.Close();
            _Commport.Open();
            if (_Commport.PortOpened)
            {
                _Commport.OnDataArrivedEvent -= new DataArrivedDelegate(Commport_OnDataArrivedEvent);
                _Commport.OnDataArrivedEvent += new DataArrivedDelegate(Commport_OnDataArrivedEvent);
            }
            else
            {
                throw new Exception("串口打开失败");
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (_Commport != null && _Commport.PortOpened)
            {
                _Commport.Close();
            }
        }

        public Packet Request(Packet p)
        {
            if (IsOpened)
            {
                lock (_DataLocker)
                {
                    _PacketReceived.Reset();
                    _RecievedData.Clear();
                    _Response = null;
                }
                _Commport.SendData(p.ToBinary());
                _PacketReceived.WaitOne(2000);
                return _Response;
            }
            return null;
        }

        public BusResult ReadValue(string address, out decimal v)
        {
            v = 0;
            return BusResult.Fail;
        }
        #endregion
    }
}
