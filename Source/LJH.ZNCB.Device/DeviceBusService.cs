using System;
using System.IO ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Device
{
    public class DeviceBusService
    {
        #region 静态属性
        private static DeviceBusService _Instance = null;

        public static DeviceBusService Instance
        {
            get
            {
                if (_Instance == null) _Instance = new DeviceBusService();
                return _Instance;
            }
        }

        private static object _BusesLocker = new object();
        private static List<DeviceBus> _Buses = new List<DeviceBus>();
        #endregion

        #region 构造函数
        private DeviceBusService()
        {
        }
        #endregion

        #region 公共方法
        private DeviceBus GetBus(byte comport)
        {
            lock (_BusesLocker)
            {
                var ret = _Buses.SingleOrDefault(it => it.Comport == comport);
                if (ret == null)
                {
                    ret = new DeviceBus(comport, 1200);
                    _Buses.Add(ret);
                }
                if (!ret.IsOpened) ret.Open();
                return ret;
            }
        }
        /// <summary>
        /// 读取某个设备的当前值
        /// </summary>
        /// <param name="address"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public BusResult ReadValue(byte comport, string address, out decimal v)
        {
            v = 0;
            var bus = GetBus(comport);
            if (bus != null && bus.IsOpened)
            {
                return bus.ReadValue(address, out v);
            }
            else
            {
                return BusResult.Fail;
            }
        }
        #endregion
    }

    public enum BusResult
    {
        Success = 0,
        Fail = 1
    }
}
