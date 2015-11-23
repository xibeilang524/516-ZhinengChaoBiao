using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model
{
    /// <summary>
    /// 表示系统的一些报警日志
    /// </summary>
    public class AlarmInfo : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public AlarmInfo() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 报警ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置报警发生时间
        /// </summary>
        public DateTime AlarmDateTime { get; set; }
        /// <summary>
        /// 获取或设置报警发生的控制器
        /// </summary>
        public string AlarmSource { get; set; }
        /// <summary>
        /// 获取或设置报警类型
        /// </summary>
        public AlarmType AlarmType { get; set; }
        /// <summary>
        /// 获取或设置报警说明
        /// </summary>
        public string AlarmDescr { get; set; }
        /// <summary>
        /// 获取或设置报警操作员
        /// </summary>
        public string OperatorID { get; set; }
        #endregion

        #region 公共方法
        public AlarmInfo Clone()
        {
            return this.MemberwiseClone() as AlarmInfo;
        }
        #endregion
    }

    /// <summary>
    /// 报警类型
    /// </summary>
    public enum AlarmType
    {
        /// <summary>
        ///  系统
        /// </summary>
        System = 1,
    }
}
