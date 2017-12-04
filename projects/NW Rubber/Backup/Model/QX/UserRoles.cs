using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// 用户角色表 QX_UserRoles
    /// </summary>
    public class UserRoles
    {

        public UserRoles()
        { }

        #region Model

        private int _userRoleID;
        private int _userID;
        private string _roleID;
        private string _description;

        /// <summary>
        /// 用户角色编号
        /// </summary>
        public int UserRoleID
        {
            get { return _userRoleID; }
            set { _userRoleID = value; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

    }
}
