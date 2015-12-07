using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.ZNCB.Model.Security
{
    /// <summary>
    /// 表示权限的动作
    /// </summary>
    [Flags]
    public enum PermissionActions
    {
        /// <summary>
        /// 没有指定
        /// </summary>
        None = 0,
        /// <summary>
        /// 查看
        /// </summary>
        Read = 0x1,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 0x2,
        /// <summary>
        /// 审批
        /// </summary>
        Approve = 0x04,
        /// <summary>
        /// 取消审核
        /// </summary>
        UndoApprove = 0x08,
        /// <summary>
        /// 作废
        /// </summary>
        Nullify = 0x10,
        /// <summary>
        /// 发货
        /// </summary>
        Ship = 0x20,
        /// <summary>
        /// 入库
        /// </summary>
        Inventory = 0x40,
        /// <summary>
        /// 打印
        /// </summary>
        Print = 0x80,
        /// <summary>
        /// 盘点
        /// </summary>
        Check=0x100,
        /// <summary>
        /// 原材料加工
        /// </summary>
        Slice=0x200,
    }
}
        
