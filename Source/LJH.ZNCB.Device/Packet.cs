using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Device
{
    internal class Packet
    {

        #region 静态方法
        public static Packet GetPacket(List<byte> data)
        {
            return null;
        }
        #endregion

        #region 构造函数
        public Packet() { }
        #endregion

        private readonly byte _HEAD = 0x68;
        private readonly byte _TAIL = 0x16;

        #region 公共属性
        /// <summary>
        /// 获取或设置地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置包中的命令码
        /// </summary>
        public byte Command { get; set; }
        /// <summary>
        /// 获取或设置包中的数据，低字节在前
        /// </summary>
        public byte[] Data { get; set; }
        #endregion

        #region 公共方法
        public byte[] ToBinary()
        {
            List<byte> p = new List<byte>();
            p.Add(_HEAD);
            p.AddRange(ConvertAddress(Address));
            p.Add(_HEAD);
            p.Add(Command);
            p.Add((byte)(Data == null ? 0 : Data.Length));
            p.AddRange(Data);
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
        #endregion
    }
}
