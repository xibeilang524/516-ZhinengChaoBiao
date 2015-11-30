using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class DeviceBLL : BLLBase<string, Device>
    {
        #region 构造函数
        public DeviceBLL(string repoUri)
            : base(repoUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(Device info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("D", 3, "Device");
            }
            if (string.IsNullOrEmpty(info.ID))
            {
                return new CommandResult(ResultCode.Fail, "创建ID失败");
            }
            return base.Add(info);
        }
        #endregion
    }
}
