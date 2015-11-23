using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.DAL
{
    /// <summary>
    /// 自动编号生成器接口
    /// </summary>
    public interface IAutoNumberCreater
    {
        /// <summary>
        /// 生成自动编号
        /// </summary>
        /// <param name="prefix">自动生成编号的前缀</param>
        /// <param name="dateFormat">自动生成编号中的日期部分的格式</param>
        /// <param name="numberFormat">自动生成的编号中自增序列号的长度</param>
        /// <param name="type">自动编号的类型</param>
        /// <returns></returns>
        string CreateNumber(string prefix, string dateFormat, int serialLen, string type);

        /// <summary>
        /// 生成自动编号
        /// </summary>
        /// <param name="prefix">自动生成编号的前缀</param>
        /// <param name="numberFormat">自动生成的编号中自增序列号的长度</param>
        /// <param name="type">自动编号的类型</param>
        /// <returns></returns>
        string CreateNumber(string prefix, int serialLen, string type);
    }
}
