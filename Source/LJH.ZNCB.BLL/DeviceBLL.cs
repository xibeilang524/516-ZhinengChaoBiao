using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.ZNCB.Model;
using LJH.ZNCB.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.ZNCB.BLL
{
    public class DeviceBLL : BLLBase<string, Device>
    {
        #region 构造函数
        public DeviceBLL(string repoUri)
            : base(repoUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(Device info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("D", 3, "Device");
            }
            if (string.IsNullOrEmpty(info.ID))
            {
                return new CommandResult(ResultCode.Fail, "创建ID失败");
            }
            return base.Add(info);
        }

        public CommandResult AddReadLog(string deviceID, DateTime dt, decimal value)
        {
            var device = GetByID(deviceID).QueryObject;
            if (device != null)
            {
                var provider = ProviderFactory.Create<IProvider<Device, string>>(RepoUri);
                IUnitWork unitWork = provider.CreateUnitWork();
                DeviceReadLog log = null;
                if (device.LastDate.HasValue && device.LastValue < value)
                {
                    log = new DeviceReadLog()
                    {
                        ID = Guid.NewGuid(),
                        DeviceID = device.ID,
                        DeviceName = device.Name,
                        DeviceType = device.DeviceType,
                        ReadDate = dt,
                        ReadValue = value,
                        LastDate = device.LastDate.Value,
                        LastValue = device.LastValue.Value,
                        Amount = value - device.LastValue.Value
                    };
                    ProviderFactory.Create<IProvider<DeviceReadLog, Guid>>(RepoUri).Insert(log, unitWork);
                }
                var clone = device.Clone();
                clone.LastDate = dt;
                clone.LastValue = log != null ? (clone.LastValue + log.Amount) : value; //记录设备上次的读数时以记录里实际扣除的数为准
                provider.Update(clone, device, unitWork);
                return unitWork.Commit();
            }
            return new CommandResult(ResultCode.Fail, "没有找到符合条件的设备");
        }
        #endregion
    }
}
