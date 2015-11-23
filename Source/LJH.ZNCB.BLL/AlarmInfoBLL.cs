using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB .Model;
namespace LJH.ZNCB.BLL
{
    public class AlarmInfoBLL : BLLBase<Guid, AlarmInfo>
    {
        #region 构造函数
        public AlarmInfoBLL(string repoUri)
            : base(repoUri)
        {

        }
        #endregion
    }
}
