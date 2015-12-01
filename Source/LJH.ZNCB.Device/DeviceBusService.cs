using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Device
{
    public class DeviceBusService
    {
        #region 静态属性
        private DeviceBusService _Instance = null;

        public DeviceBusService Instance
        {
            get
            {
                if (_Instance == null) _Instance = new DeviceBusService();
                return _Instance;
            }
        }
        #endregion

        #region 构造函数
        private DeviceBusService()
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 读取某个设备的当前值
        /// </summary>
        /// <param name="address"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public BusResult ReadValue(string address, out decimal v)
        {
            v = 0;
            return BusResult.Fail;
        }
        #endregion
    }

    public enum BusResult
    {
        Success=0,
        Fail=1
    }
}
