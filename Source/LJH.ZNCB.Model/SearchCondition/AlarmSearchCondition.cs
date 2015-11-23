using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model.SearchCondition
{
    public class AlarmSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange AlarmDateTime { get; set; }
        public AlarmType? AlarmType { get; set; } //报警类型
        public string OperatorID { get; set; } //报警来源
    }
}
