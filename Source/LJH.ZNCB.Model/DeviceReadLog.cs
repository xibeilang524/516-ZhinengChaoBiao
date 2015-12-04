using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model
{
    public class DeviceReadLog : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public DeviceReadLog()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }

        public string DeviceID { get; set; }

        public DeviceType DeviceType { get; set; }

        public DateTime ReadDate { get; set; }

        public decimal ReadValue { get; set; }

        public DateTime LastDate { get; set; }

        public decimal LastValue { get; set; }

        public decimal Amount { get; set; }
        #endregion
    }
}
