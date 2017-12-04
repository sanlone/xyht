using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{

    /// <summary>
    /// 角色权限表 QX_RolePermissions
    /// </summary>
    public class RoleMenus
    {

        public RoleMenus()
        {

        }

        #region Model

        private int _roleMenuID;
        private int _roleID;
        private string _menuList;
        private string _description;
        private Dictionary<int, UserPermissions> _dicPermissions = new Dictionary<int, UserPermissions>();



        /// <summary>
        /// 角色权限编号
        /// </summary>
        public int RoleMenuID
        {
            get { return _roleMenuID; }
            set { _roleMenuID = value; }
        }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        public string MenuList
        {
            get { return _menuList; }
            set
            {
                _menuList = value;

                if (!string.IsNullOrEmpty(_menuList))
                {
                    string[] arrMenus = new string[0] { };
                    string[] arrPermissions = new string[0] { };
                    UserPermissions model = null;
                    _dicPermissions = new Dictionary<int, UserPermissions>();

                    arrMenus = _menuList.Split(',');

                    for (int i = 0; i < arrMenus.Length; i++)
                    {
                        arrPermissions = arrMenus[i].Split('&');
                        model = new UserPermissions();
                        model.Select = arrPermissions[1].Substring(0, 1) == "1" ? true : false;
                        model.Add = arrPermissions[1].Substring(1, 1) == "1" ? true : false;
                        model.Update = arrPermissions[1].Substring(2, 1) == "1" ? true : false;
                        model.Delete = arrPermissions[1].Substring(3, 1) == "1" ? true : false;
                        _dicPermissions.Add(Convert.ToInt32(arrPermissions[0]), model);
                    }
                }
            }
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// 权限实体
        /// </summary>
        public Dictionary<int, UserPermissions> DicPermissions
        {
            get { return _dicPermissions; }
            set { _dicPermissions = value; }
        }

        #endregion

    }

    /// <summary>
    /// 自定义权限类
    /// </summary>
    public class UserPermissions
    {
        public UserPermissions() { }
        public UserPermissions(string strPermissions)
        {
            if (!string.IsNullOrEmpty(strPermissions) && strPermissions.Length == 4)
            {
                _select = strPermissions.Substring(0, 1) == "1" ? true : false;
                _add = strPermissions.Substring(1, 1) == "1" ? true : false;
                _update = strPermissions.Substring(2, 1) == "1" ? true : false;
                _delete = strPermissions.Substring(3, 1) == "1" ? true : false;
            }
        }

        #region Model
        private bool _select;
        private bool _add;
        private bool _update;
        private bool _delete;

        /// <summary>
        /// 查看权限
        /// </summary>
        public bool Select
        {
            get { return _select; }
            set { _select = value; }
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        public bool Add
        {
            get { return _add; }
            set { _add = value; }
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        public bool Update
        {
            get { return _update; }
            set { _update = value; }
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        public bool Delete
        {
            get { return _delete; }
            set { _delete = value; }
        }
        #endregion
    }

}
