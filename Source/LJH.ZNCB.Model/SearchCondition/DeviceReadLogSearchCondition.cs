using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model.SearchCondition
{
    public class DeviceReadLogSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange ReadDateRange { get; set; }

        public string DeviceID { get; set; }

        public List<string> Devices { get; set; }

        public DeviceType? DeviceType { get; set; }
    }
}
