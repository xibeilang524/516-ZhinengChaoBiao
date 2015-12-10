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

        private readonly byte _HEAD = 0x68;
        private readonly byte _TAIL = 0x16;

        private CommPort _Commport = null;

        private object _DataLocker = new object();
        private List<byte> _RecievedData = new List<byte>();
        private AutoResetEvent _PacketReceived = new AutoResetEvent(false);
        private Packet _Response = null;
        #endregion

        #region 私有方法
        public byte[] CreateRequest(byte cmd, string address, byte[] data)
        {
            List<byte> p = new List<byte>();
            p.Add(_HEAD);
            p.AddRange(ConvertAddress(address));
            p.Add(_HEAD);
            p.Add(cmd);
            p.Add((byte)(data == null ? 0 : data.Length));
            p.AddRange(data.Select(it => (byte)(it + 0x33))); //数据每字节都加0X33
            p.Add(CalCRC(p));
            p.Add(_TAIL);
            return p.ToArray();
        }

        private byte[] ConvertAddress(string address)
        {
            List<byte> ret = new List<byte>();
            if (address.Length % 2 == 1) address = "0" + address;
            for (int i = 0; i < address.Length; i = i + 2)
            {
                ret.Add(byte.Parse(address.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
            }
            while (ret.Count < 5) ret.Add(0xAA);
            ret.Reverse();
            return ret.ToArray();
        }

        private byte CalCRC(IEnumerable<byte> p)
        {
            int ret = 0;
            foreach (var b in p)
            {
                ret += b;
            }
            return (byte)(ret & 0xFF);
        }

        private void Commport_OnDataArrivedEvent(object sender, byte[] data)
        {
            lock (_DataLocker)
            {
                _RecievedData.AddRange(data);
                _Response = GetPacket(_RecievedData);
                if (_Response != null) _PacketReceived.Set();
            }
        }

        private Packet GetPacket(List<byte> data)
        {
            while (data.Count > 0) //去掉前面的无用字节
            {
                if (data[0] != _HEAD)
                {
                    data.RemoveAt(0);
                }
                else
                {
                    if (data.Count >= 7 && data[6] != _HEAD) //如果第6个字节不是包头，说明前面这些字符也是无效的。
                    {
                        data.RemoveRange(0, 6);
                    }
                    else
                    {
                        if (data.Count >= 9 && data.Count >= data[8] + 11 && data[11 + data[8] - 1] != _TAIL) //如果包尾不是指定的字节，则说明前面的数据都是无用的
                        {
                            data.RemoveRange(0, 11 + data[8]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (data.Count >= 9 && data.Count >= data[8] + 11)
            {
                byte[] p = new byte[data[8] + 11];
                data.CopyTo(0, p, 0, p.Length);
                data.RemoveRange(0, p.Length); //同时从缓存中删除包
                var ret = new Packet();
                ret.Command = p[7];
                ret.Address = HexStringConverter.HexToString(new byte[] { p[5], p[4], p[3], p[2], p[1] }, string.Empty).Trim('A');
                if (p[8] > 2) //前两字节数据与请求数据的一样，不需要
                {
                    byte[] d = new byte[p[8] - 2];
                    Array.Copy(p, 9, d, 0, d.Length);
                    ret.Data = d;
                }
                return ret;
            }
            return null;
        }
        #endregion

        #region 公共属性
        public byte Comport { get; set; }

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

        public Packet Request(byte cmd, string address, byte[] data)
        {
            if (IsOpened)
            {
                lock (_DataLocker)
                {
                    _PacketReceived.Reset();
                    _RecievedData.Clear();
                    _Response = null;
                }
                byte[] p = CreateRequest(cmd, address, data);
                _Commport.SendData(p);
                _PacketReceived.WaitOne(2000);
                return _Response;
            }
            return null;
        }
        /// <summary>
        /// 读表
        /// </summary>
        /// <param name="address"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public BusResult ReadValue(string address, out decimal v)
        {
            v = 0;
            var response = Request(0x01, address, new byte[] { 0x01, 0x09 });
            if (response != null && response.Command == 0x81 && response.Data.Length >= 4)
            {
                byte[] d = new byte[4];
                Array.Copy(response.Data, 2, d, 0, d.Length);
                d.Reverse();
                for (int i = 0; i < d.Length; i++)
                {
                    d[i] = (byte)(d[i] - 0x33);
                }
                string temp = LJH.GeneralLibrary.HexStringConverter.HexToString(d, string.Empty);
                if (decimal.TryParse(temp, out v))
                {
                    v /= 100;
                    return BusResult.Success;
                }
            }
            return BusResult.Fail;
        }
        #endregion
    }
}
