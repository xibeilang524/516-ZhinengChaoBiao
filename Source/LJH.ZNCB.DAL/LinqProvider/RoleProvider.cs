using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model.Security;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.ZNCB.DAL.LinqProvider
{
    public class RoleProvider:ProviderBase <Role,string>
    {
        public RoleProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms):base(connStr,ms)
        {
        }

        #region 重写模板方法
        protected override Role GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable <Role>().SingleOrDefault(r => r.ID == id);
        }
        #endregion
    }
}
