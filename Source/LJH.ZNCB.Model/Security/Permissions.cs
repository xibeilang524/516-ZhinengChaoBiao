using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LJH.ZNCB.Model.Security
{
    /// <summary>
    /// 操作员的权限枚举
    /// </summary>
    public enum Permission
    {
        #region 基本资料
        /// <summary>
        /// 查看系统选项
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "系统选项")]
        SystemOptions = 1,
        /// <summary>
        /// 产品类别
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品类别")]
        ProductCategory,
        /// <summary>
        /// 产品资料
        /// </summary>
        //[OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品资料")]
        Product,
        /// <summary>
        /// 原材料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Check | PermissionActions.Slice | PermissionActions.Nullify, Description = "原材料")]
        SteelRoll,
        /// <summary>
        /// 加工小件
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Check | PermissionActions.Nullify, Description = "加工小件")]
        SteelRollSlice,
        /// <summary>
        /// 仓库资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "仓库资料")]
        WareHouse,
        /// <summary>
        /// 部门资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "部门资料")]
        Department,
        /// <summary>
        /// 人员资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "人员资料")]
        Staff,
        /// <summary>
        /// 其它公司类别
        /// </summary>
        //[OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "其它公司类别")]
        OtherCompanyType,
        /// <summary>
        /// 其它公司资料
        /// </summary>
        //[OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "其它公司资料")]
        OtherCompany,
        /// <summary>
        /// 计量单位资料
        /// </summary>
        //[OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "计量单位资料")]
        Unit,
        /// <summary>
        /// 币别资料
        /// </summary>
        //[OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "币别资料")]
        CurrencyType,
        /// <summary>
        /// 运输方式
        /// </summary>
        //[OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "运输方式")]
        Transport,
        /// <summary>
        /// 操作员资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "操作员资料")]
        Operator,
        /// <summary>
        /// 查看角色资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "角色资料")]
        Role,
        #endregion

        #region 销售
        /// <summary>
        /// 客户类别
        /// </summary>
        [OperatorRight(Catalog = "销售", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "客户类别")]
        CustomerType = 101,
        /// <summary>
        /// 客户资料
        /// </summary>
        [OperatorRight(Catalog = "销售", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "客户资料")]
        Customer,
        /// <summary>
        /// 订单资料
        /// </summary>
        [OperatorRight(Catalog = "销售", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "订单资料")]
        Order,
        #endregion

        #region 采购
        /// <summary>
        /// 供应商类别
        /// </summary>
        [OperatorRight(Catalog = "采购", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "供应商类别")]
        SupplierType = 201,
        /// <summary>
        /// 供应商资料
        /// </summary>
        [OperatorRight(Catalog = "采购", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "供应商资料")]
        Supplier,
        /// <summary>
        /// 采购单资料
        /// </summary>
        [OperatorRight(Catalog = "采购", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "采购单资料")]
        PurchaseOrder,
        #endregion

        #region 仓库
        /// <summary>
        /// 产品库存
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品库存")]
        ProductInventory = 301,
        /// <summary>
        /// 库存盘点
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "库存盘点")]
        InventoryCheck,
        /// <summary>
        /// 收货单资料
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify | PermissionActions.Inventory | PermissionActions.Print, Description = "收货单资料")]
        InventorySheet,
        /// <summary>
        /// 送货单资料
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify | PermissionActions.Ship | PermissionActions.Print, Description = "送货单资料")]
        DeliverySheet,
        #endregion

        #region 财务
        /// <summary>
        /// 客户应收管理
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read, Description = "客户应收管理")]
        CustomerState = 401,
        /// <summary>
        /// 客户其它应收款
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "客户其它应收款")]
        CustomerOtherReceivable,
        /// <summary>
        /// 客户收款流水
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "客户收款流水")]
        CustomerPayment,
        /// <summary>
        /// 资金支出类别
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "资金支出类别")]
        ExpenditureType,
        /// <summary>
        /// 资金支出资料
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "资金支出资料")]
        ExpenditureRecord,
        /// <summary>
        /// 供应商应付管理
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read, Description = "供应商应付管理")]
        SupplierState,
        /// <summary>
        /// 供应商付款流水
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "供应商付款流水")]
        SupplierPayment,
        #endregion

        #region 其它

        #endregion

        #region 查询与报表
        /// <summary>
        /// 出货记录查询
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Actions = PermissionActions.Read, Description = "出货记录查询")]
        DeliveryRecordReport = 501,
        /// <summary>
        /// 产品出货统计
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Actions = PermissionActions.Read, Description = "产品出货统计")]
        DeliveryStatistics,
        /// <summary>
        /// 业务员业绩统计
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Actions = PermissionActions.Read, Description = "业务员业绩统计")]
        PerformanceStatistics,
        #endregion
    }
}
