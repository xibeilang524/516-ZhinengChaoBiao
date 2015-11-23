using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model
{
    /// <summary>
    /// 表示区域信息
    /// </summary>
    public class Division : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public Division() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置上级区域ID
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
