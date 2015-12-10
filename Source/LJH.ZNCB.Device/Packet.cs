using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Device
{
    internal class Packet
    {
        #region 构造函数
        public Packet() { }
        #endregion

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
    }
}
