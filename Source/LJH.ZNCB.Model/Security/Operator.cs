using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LJH.GeneralLibrary.SoftDog;
using LJH.GeneralLibrary.ExceptionHandling;

namespace LJH.ZNCB.Model.Security
{
    /// <summary>
    /// 代表系统操作员
    /// </summary>
    public class Operator : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 静态变量及方法
        private static LJH.GeneralLibrary.SoftDog.DSEncrypt DES = new DSEncrypt();
        private static Operator currentOperator;
        /// <summary>
        /// 获取或设置当前的操作员
        /// </summary>
        public static Operator Current
        {
            get { return currentOperator; }
            set { currentOperator = value; }
        }

        /// <summary>
        /// 系统默认登录ID
        /// </summary>
        public static string DefaultLogID = "admin";
        #endregion

        #region 构造函数
        public Operator()
        {

        }
        #endregion

        #region 私有变量
        private string _Password;
        #endregion

        #region 公共属性
        /// <summary>
        /// 操作员登录名
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 操作员名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 操作员登录密码
        /// </summary>
        public string Password
        {
            get
            {
                if (_Password.Length > 14)
                {
                    return (new DTEncrypt()).DSEncrypt(_Password);
                }
                else
                {
                    return _Password;
                }
            }
            set
            {
                _Password = (new DTEncrypt()).Encrypt(value);
            }
        }
        /// <summary>
        /// 操作员角色ID
        /// </summary>
        public string RoleID { get; set; }
        /// <summary>
        /// 获取或设置角色信息
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// 获取或设置操作员的职位
        /// </summary>
        public int? StaffID { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 操作员是否可以删除,系统内置的ADMIN操作员不可删除
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return (ID != DefaultLogID );
            }
        }

        public bool CanEdit
        {
            get
            {
                return (ID != DefaultLogID);
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 检测此操作员是否被授予某个权限
        /// </summary>
        /// <param name="right"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool Permit(Permission right,PermissionActions action)
        {
            if (this.Role != null)
            {
                return Role.Permit(right,action);
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
