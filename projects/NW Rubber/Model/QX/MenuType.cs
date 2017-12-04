using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// QX_MenuType
    /// </summary>
    public class MenuType
    {

        public MenuType()
        { }

        #region Model

        private int _menuTypeID;
        private string _menuTypeName;
        private string _description;

        /// <summary>
        /// 自增编号
        /// </summary>
        public int MenuTypeID
        {
            get { return _menuTypeID; }
            set { _menuTypeID = value; }
        }

        /// <summary>
        /// 菜单类型名称
        /// </summary>
        public string MenuTypeName
        {
            get { return _menuTypeName; }
            set { _menuTypeName = value; }
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
