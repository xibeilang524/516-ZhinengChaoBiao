using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.ZNCB.DAL.LinqProvider
{
    class DeviceBusProvider : ProviderBase<DeviceBus, string>
    {
        #region 构造函数
        public DeviceBusProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override DeviceBus GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable<DeviceBus>().SingleOrDefault(it => it.ID == id);
        }
        #endregion
    }
}
