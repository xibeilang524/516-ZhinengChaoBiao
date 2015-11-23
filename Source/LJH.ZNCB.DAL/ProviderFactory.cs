using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.DAL
{
    /// <summary>
    /// 表示数据库提供者的工厂类
    /// </summary>
    public class ProviderFactory
    {
        /// <summary>
        /// 创建一个数据提供者实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repUri"></param>
        /// <returns></returns>
        public static T Create<T>(string connStr) where T : class
        {
            T instance = null;
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly(); // Assembly.Load("LJH.Inventory.DAL");
                if (asm != null)
                {
                    foreach (Type t in asm.GetTypes())
                    {
                        if (t.IsClass && !t.IsAbstract)
                        {
                            foreach (Type inter in t.GetInterfaces())
                            {
                                if (inter == typeof(T))
                                {
                                    Stream stream = asm.GetManifestResourceStream("LJH.ZNCB.DAL.LinqProvider.DataMapping.xml");
                                    MappingSource mappingSource = XmlMappingSource.FromStream(stream);
                                    instance = Activator.CreateInstance(t, connStr, mappingSource) as T;
                                    return instance;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            throw new Exception(string.Format("没有找到 {0} ,请确保 {1} 已经存在!", typeof(T).FullName, typeof(T).FullName));
        }
    }
}
