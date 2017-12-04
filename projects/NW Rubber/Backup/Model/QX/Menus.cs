using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// QX_Menus
    /// </summary>
    public class Menus
    {

        /// <summary>
        /// 
        /// </summary>
        public Menus()
        {
        }

        /// <summary>
        /// ��¡
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {

            Menus model = new Menus();

            model.MenuID = this._menuID;
            model.MenuTypeID = this._menuTypeID;
            model.ParentID = this._parentID;
            model.MenuName = this._menuName;
            model.MenuPath = this._menuPath;
            model.Sort = this._sort;
            model.ImagePath = this._imagePath;
            model.Description = this._description;

            return model;

        }

        #region Model

        private int _menuID;
        private int _menuTypeID;
        private int _parentID;
        private string _menuName;
        private string _menuPath;
        private int _sort;
        private string _imagePath;
        private string _description;

        /// <summary>
        /// �������
        /// </summary>
        public int MenuID
        {
            get { return _menuID; }
            set { _menuID = value; }
        }

        /// <summary>
        /// �˵����ͱ��
        /// </summary>
        public int MenuTypeID
        {
            get { return _menuTypeID; }
            set { _menuTypeID = value; }
        }

        /// <summary>
        /// �ϼ����
        /// </summary>
        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        /// <summary>
        /// �˵�����
        /// </summary>
        public string MenuName
        {
            get { return _menuName; }
            set { _menuName = value; }
        }

        /// <summary>
        /// �˵�·��
        /// </summary>
        public string MenuPath
        {
            get { return _menuPath; }
            set { _menuPath = value; }
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
        /// ͼƬ·��
        /// </summary>
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
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
