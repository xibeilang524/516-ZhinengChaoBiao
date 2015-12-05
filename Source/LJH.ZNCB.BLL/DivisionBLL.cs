using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class DivisionBLL : BLLBase<string, Division>
    {
        #region 构造函数
        public DivisionBLL(string repoUri)
            : base(repoUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(Division info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("D", 3, "Division");
            }
            if (string.IsNullOrEmpty(info.ID))
            {
                return new CommandResult(ResultCode.Fail, "创建ID失败");
            }
            return base.Add(info);
        }

        public override CommandResult Delete(Division info)
        {
            var devices = new DeviceBLL(RepoUri).GetItems(null).QueryObjects;
            if (devices != null && devices.Exists(it => it.Division == info.ID)) return new CommandResult(ResultCode.Fail, "区域下面已经有设备不能删除");
            return base.Delete(info);
        }
        #endregion
    }
}
