using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// �û���ɫ�� QX_UserRoles
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
        /// �û���ɫ���
        /// </summary>
        public int UserRoleID
        {
            get { return _userRoleID; }
            set { _userRoleID = value; }
        }

        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        /// <summary>
        /// ��ɫ���
        /// </summary>
        public string RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        /// <summary>
        /// ˵��
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

    }
}
