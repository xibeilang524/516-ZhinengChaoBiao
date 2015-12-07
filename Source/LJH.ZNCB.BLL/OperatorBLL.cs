using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model.Security;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class OperatorBLL : BLLBase<string, Operator>
    {
        #region 构造函数
        public OperatorBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 实例方法
        /// <summary>
        /// 登录验证
        /// </summary>
        public bool Authentication(string logName, string pwd)
        {
            Operator info = GetByID(logName).QueryObject;
            if (info != null)
            {
                if (info.ID == logName && info.Password == pwd)
                {
                    Operator.Current = info;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
