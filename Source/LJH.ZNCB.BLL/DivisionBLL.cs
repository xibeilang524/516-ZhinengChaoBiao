using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;

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
    }
}
