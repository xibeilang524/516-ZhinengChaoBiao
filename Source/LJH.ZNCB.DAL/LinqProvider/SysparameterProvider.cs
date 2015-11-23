using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Linq;
using LJH.ZNCB.Model;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.ZNCB.DAL.LinqProvider
{
    public class SysparameterProvider : ProviderBase<SysparameterInfo,string>
    {
        public SysparameterProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }

        #region 重写模板方法
        protected override SysparameterInfo GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable<SysparameterInfo>().SingleOrDefault(s => s.ID == id);
        }
        #endregion
    }
}