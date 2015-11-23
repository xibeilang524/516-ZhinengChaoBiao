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
    public class AlarmProvider : ProviderBase<AlarmInfo, Guid>
    {
        public AlarmProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写基类方法
        protected override AlarmInfo GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<AlarmInfo>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<AlarmInfo> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<AlarmInfo> result = dc.GetTable<AlarmInfo>();
            if (search is AlarmSearchCondition)
            {
                AlarmSearchCondition con = search as AlarmSearchCondition;
                if (con.AlarmDateTime != null)
                {
                    result = result.Where(c => c.AlarmDateTime >= con.AlarmDateTime.Begin);
                    result = result.Where(c => c.AlarmDateTime <= con.AlarmDateTime.End);
                }
                if (con.AlarmType != null) result = result.Where(c => c.AlarmType == con.AlarmType);
                if (con.OperatorID != null) result = result.Where(c => c.OperatorID == con.OperatorID);
            }
            result = result.OrderBy(item => item.AlarmDateTime);
            return result.ToList();
        }
        #endregion
    }
}
