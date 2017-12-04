using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// 角色表 QX_Roles
    /// </summary>
    public class Roles
    {

        public Roles()
        { }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {

            Roles model = new Roles();

            model.RoleID = this._roleID;
            model.MenuTypeID = this._menuTypeID;
            model.ParentID = this._parentID;
            model.RoleName = this._roleName;
            model.Sort = this._sort;
            model.Description = this._description;

            return model;

        }

        #region Model

        private int _roleID;
        private int _menuTypeID;
        private int _parentID;
        private string _roleName;
        private int _sort;
        private string _description;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public int MenuTypeID
        {
            get { return _menuTypeID; }
            set { _menuTypeID = value; }
        }

        /// <summary>
        /// 上级角色
        /// </summary>
        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        /// <summary>
        /// 角色说明
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

    }
}
