using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{

    /// <summary>
    /// ��ɫȨ�ޱ� QX_RolePermissions
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
        /// ��ɫȨ�ޱ��
        /// </summary>
        public int RoleMenuID
        {
            get { return _roleMenuID; }
            set { _roleMenuID = value; }
        }

        /// <summary>
        /// ��ɫ���
        /// </summary>
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        /// <summary>
        /// Ȩ���б�
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
        /// ˵��
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Ȩ��ʵ��
        /// </summary>
        public Dictionary<int, UserPermissions> DicPermissions
        {
            get { return _dicPermissions; }
            set { _dicPermissions = value; }
        }

        #endregion

    }

    /// <summary>
    /// �Զ���Ȩ����
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
        /// �鿴Ȩ��
        /// </summary>
        public bool Select
        {
            get { return _select; }
            set { _select = value; }
        }
        /// <summary>
        /// ���Ȩ��
        /// </summary>
        public bool Add
        {
            get { return _add; }
            set { _add = value; }
        }
        /// <summary>
        /// �޸�Ȩ��
        /// </summary>
        public bool Update
        {
            get { return _update; }
            set { _update = value; }
        }
        /// <summary>
        /// ɾ��Ȩ��
        /// </summary>
        public bool Delete
        {
            get { return _delete; }
            set { _delete = value; }
        }
        #endregion
    }

}
