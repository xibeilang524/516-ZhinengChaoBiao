using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.ZNCB.Model
{
    /// <summary>
    /// 表示一个时间段
    /// </summary>
    [Serializable]
    public class DateTimeRange
    {
        #region 构造函数
        public DateTimeRange()
        {
            Begin = DateTime.MinValue;
            End = DateTime.MaxValue;
        }

        public DateTimeRange(DateTime bengin, DateTime dtend)
        {
            Begin = bengin;
            End = dtend;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 开始时间(如果不指定为日期的最小值)
        /// </summary>
        public DateTime Begin { get; set; }

        /// <summary>
        /// 结束时间(如果不指定为日期的最大值)
        /// </summary>
        public DateTime End { get; set; }
        #endregion
    }
}
