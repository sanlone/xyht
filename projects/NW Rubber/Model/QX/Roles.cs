using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// ��ɫ�� QX_Roles
    /// </summary>
    public class Roles
    {

        public Roles()
        { }

        /// <summary>
        /// ��¡
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
        /// ��ɫ���
        /// </summary>
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }

        /// <summary>
        /// �˵�����
        /// </summary>
        public int MenuTypeID
        {
            get { return _menuTypeID; }
            set { _menuTypeID = value; }
        }

        /// <summary>
        /// �ϼ���ɫ
        /// </summary>
        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        /// <summary>
        /// ��ɫ˵��
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

    }
}
