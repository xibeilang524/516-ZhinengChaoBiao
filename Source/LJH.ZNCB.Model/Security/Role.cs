using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.ZNCB.Model.Security
{
    [Serializable()]
    public class Role : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 私有变量
        //系统预定义的三种角色
        private readonly string Admin = "SYS"; //系统管理员
        Dictionary<uint, uint> _AllRights = null;
        private string _Permission=null ;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        public string Permission
        {
            get { return _Permission; }
            set
            {
                _Permission = value;
                _AllRights = null;
            }
        }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 是否可以删除,系统默认的角色(系统管理员,卡片操作员,进出口操作员)不能删除
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return ID.ToUpper() != Admin;
            }
        }

        /// <summary>
        /// 是否可以编辑,系统默认的角色(系统管理员)不能编辑
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return ID.ToUpper() != Admin;
            }
        }
        /// <summary>
        /// 是否是系统管理员
        /// </summary>
        public bool IsAdmin
        {
            get { return ID.ToUpper() == Admin; }
        }
        #endregion

        #region 私有方法
        private Dictionary<uint, uint> GetAllRights()
        {
            if (_AllRights == null) _AllRights = new Dictionary<uint, uint>();
            if (!string.IsNullOrEmpty(Permission))
            {
                foreach (string str in Permission.Split(','))
                {
                    ulong temp = 0;
                    if (ulong.TryParse(str, out temp))
                    {
                        uint permission = (uint)((temp >> 32) & 0xFFFFFFFF); //高32位表示权限
                        uint actions = (uint)(temp & 0xFFFFFFFF); //低32位表示动作
                        if (_AllRights.Keys.Contains(permission))
                        {
                            _AllRights[permission] = _AllRights[permission] | actions;
                        }
                        else
                        {
                            _AllRights.Add(permission, actions);
                        }
                    }
                }
            }
            return _AllRights;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 查看此角色是否被授予此权限
        /// </summary>
        public bool Permit(Permission right, PermissionActions action)
        {
            if (Permission == "all")
            {
                return true;
            }
            else
            {
                if (_AllRights == null) GetAllRights();
                if (_AllRights != null && _AllRights.Count > 0)
                {
                    if (_AllRights.Keys.Contains((uint)right))
                    {
                        return (_AllRights[(uint)right] & (uint)action) == (uint)action;
                    }
                }
                return false;
            }
        }
        #endregion
    }
}
