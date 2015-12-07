using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model.Security
{
    public class OperatorRightAttribute : Attribute
    {
        #region 构造函数
        public OperatorRightAttribute()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 权限的类别
        /// </summary>
        public string Catalog { get; set; }
        /// <summary>
        /// 获取或设置值
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 获取或设置权限的所有操作
        /// </summary>
        public PermissionActions Actions { get; set; }
        /// <summary>
        /// 权限的备注
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
