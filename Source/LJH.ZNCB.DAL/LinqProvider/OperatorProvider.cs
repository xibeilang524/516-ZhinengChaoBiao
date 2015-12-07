using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.ZNCB.Model.Security;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.ZNCB.DAL.LinqProvider
{
    public class OperatorProvider : ProviderBase<Operator, string>
    {
        public OperatorProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写模板方法
        protected override Operator GetingItemByID(string id, DataContext dc)
        {
            Operator item = dc.GetTable<Operator>().SingleOrDefault(o => o.ID == id);
            if (item != null) item.Role = dc.GetTable<Role>().SingleOrDefault(r => r.ID == item.RoleID);
            return item;
        }

        protected override List<Operator> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<Operator> ret = dc.GetTable<Operator>();
            List<Operator> items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                List<Role> roles = dc.GetTable<Role>().ToList();
                if (roles != null && roles.Count > 0)
                {
                    foreach (Operator item in items)
                    {
                        item.Role = roles.SingleOrDefault(r => r.ID == item.RoleID);
                    }
                }
            }
            return items;
        }
        #endregion
    }
}
