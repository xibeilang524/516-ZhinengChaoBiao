using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model
{
    public class DeviceBus : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        public DeviceBus()
        {
        }

        #region 公共属性
        public string ID { get; set; }

        public string Name { get; set; }

        public int Comport { get; set; }

        public int Baud { get; set; }
        #endregion
    }
}
