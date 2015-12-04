using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model
{
    public class Device : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public Device()
        {
        }
        #endregion

        #region 公共属性
        public string ID { get; set; }

        public string Name { get; set; }

        public string Bus { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 获取或设置设备类型 1表示电表 2表示水表
        /// </summary>
        public DeviceType  DeviceType { get; set; }
        /// <summary>
        /// 获取或设置状态
        /// </summary>
        public int State { get; set; }

        public string Division { get; set; }

        public DateTime? LastDt { get; set; }

        public decimal? LastValue { get; set; }
        #endregion

        #region 公共方法
        public Device Clone()
        {
            return this.MemberwiseClone() as Device;
        }
        #endregion
    }
}
