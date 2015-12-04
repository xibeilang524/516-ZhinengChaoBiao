using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.Model.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.ZNCB.DAL.LinqProvider
{
    public class DeviceReadLogProvider : ProviderBase<DeviceReadLog , Guid>
    {
        public DeviceReadLogProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写基类方法
        protected override DeviceReadLog  GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<DeviceReadLog>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<DeviceReadLog> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<DeviceReadLog> ret = dc.GetTable<DeviceReadLog>();
            if (search is DeviceReadLogSearchCondition)
            {
                var con = search as DeviceReadLogSearchCondition;
                if (con.ReadDateRange != null) ret = ret.Where(it => it.ReadDate >= con.ReadDateRange.Begin && it.ReadDate <= con.ReadDateRange.End);
                if (!string.IsNullOrEmpty(con.DeviceID)) ret = ret.Where(it => it.DeviceID == con.DeviceID);
                if (con.Devices != null && con.Devices.Count > 0) ret = ret.Where(it => con.Devices.Contains(it.DeviceID));
            }
            return ret.ToList();
        }
        #endregion
    }
}
