using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class DeviceBusBLL : BLLBase<string, DeviceBus>
    {
        #region 构造函数
        public DeviceBusBLL(string repoUri)
            : base(repoUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(DeviceBus info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("B", 3, "DeviceBus");
            }
            if (string.IsNullOrEmpty(info.ID))
            {
                return new CommandResult(ResultCode.Fail, "创建ID失败");
            }
            return base.Add(info);
        }

        public override CommandResult Delete(DeviceBus info)
        {
            var devices = new DeviceBLL(RepoUri).GetItems(null).QueryObjects;
            if (devices != null && devices.Exists(it => it.Bus == info.ID))
            {
                return new CommandResult(ResultCode.Fail, "不能删除此总线, 已经有设备挂接在这个总线之下");
            }
            return base.Delete(info);
        }
        #endregion
    }
}
