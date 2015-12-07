using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model.Security;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class RoleBLL : BLLBase<string, Role>
    {
        #region 构造函数
        public RoleBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(Role info)
        {
            List<Operator> ops = (new OperatorBLL(RepoUri)).GetItems(null).QueryObjects;
            if (ops.Exists(item => item.RoleID == info.ID)) return new CommandResult(ResultCode.Fail, "已经有操作员归属到此角色，不能删除。"); 
            return base.Delete(info);
        }
        #endregion
    }
}
