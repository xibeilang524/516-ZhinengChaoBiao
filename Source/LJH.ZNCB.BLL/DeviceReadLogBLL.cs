using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class DeviceReadLogBLL :BLLBase<Guid, DeviceReadLog>
    {
        #region 构造函数
        public DeviceReadLogBLL(string repoUri)
            : base(repoUri)
        {

        }
        #endregion
    }
}
