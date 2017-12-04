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
        /// 克隆
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
        /// 自增编号
        /// </summary>
        public int MenuID
        {
            get { return _menuID; }
            set { _menuID = value; }
        }

        /// <summary>
        /// 菜单类型编号
        /// </summary>
        public int MenuTypeID
        {
            get { return _menuTypeID; }
            set { _menuTypeID = value; }
        }

        /// <summary>
        /// 上级编号
        /// </summary>
        public int ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName
        {
            get { return _menuName; }
            set { _menuName = value; }
        }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string MenuPath
        {
            get { return _menuPath; }
            set { _menuPath = value; }
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
        /// 图片路径
        /// </summary>
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
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
