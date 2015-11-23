using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.ZNCB.DAL.LinqProvider
{
    public class AutoNumberCreater : IAutoNumberCreater
    {
        #region 构造函数
        public AutoNumberCreater(string connStr, System.Data.Linq.Mapping.MappingSource ms)
        {
            ConnectStr = connStr;
            _MappingSource = ms;
        }
        #endregion

        #region 私有变量
        private string ConnectStr;
        private System.Data.Linq.Mapping.MappingSource _MappingSource = null;
        #endregion

        #region 实现 IAutoNumberCreater 接口
        /// <summary>
        /// 生成自动编号
        /// </summary>
        /// <param name="prefix">自动生成编号的前缀</param>
        /// <param name="numberFormat">自动生成的编号中自增序列号的长度</param>
        /// <param name="type">自动编号的类型</param>
        /// <returns></returns>
        public string CreateNumber(string prefix, string dateFormat, int serialLen, string type)
        {
            try
            {
                string head = string.Format("{0}{1}", prefix, DateTime.Now.ToString(dateFormat));
                DataContext dc = DataContextFactory.CreateDataContext(ConnectStr, _MappingSource);
                AutoCreateNumber num = dc.GetTable<AutoCreateNumber>().SingleOrDefault(item => item.Prefix == head && item.NumberType == type);
                if (num == null)
                {
                    num = new AutoCreateNumber()
                    {
                        Prefix = head,
                        Number = 1,
                        NumberType = type
                    };
                    dc.GetTable<AutoCreateNumber>().InsertOnSubmit(num);
                }
                else
                {
                    num.Number += 1;
                }
                dc.SubmitChanges();
                return num.Prefix + num.Number.ToString("D" + serialLen);
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
            }
            return null;
        }

        /// <summary>
        /// 生成自动编号
        /// </summary>
        /// <param name="prefix">自动生成编号的前缀</param>
        /// <param name="numberFormat">自动生成的编号中自增序列号的长度</param>
        /// <param name="type">自动编号的类型</param>
        /// <returns></returns>
        public string CreateNumber(string prefix, int serialLen, string type)
        {
            try
            {
                DataContext dc = DataContextFactory.CreateDataContext(ConnectStr, _MappingSource);
                AutoCreateNumber num = dc.GetTable<AutoCreateNumber>().SingleOrDefault(item => item.Prefix == prefix && item.NumberType == type);
                if (num == null)
                {
                    num = new AutoCreateNumber()
                    {
                        Prefix = prefix,
                        Number = 1,
                        NumberType = type
                    };
                    dc.GetTable<AutoCreateNumber>().InsertOnSubmit(num);
                }
                else
                {
                    num.Number += 1;
                }
                dc.SubmitChanges();
                return num.Prefix + num.Number.ToString("D" + serialLen);
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
            }
            return null;
        }
        #endregion
    }

    internal class AutoCreateNumber
    {
        public string Prefix { get; set; }

        public int Number { get; set; }

        public string NumberType { get; set; }
    }
}
