using System;
using System.Collections.Generic;
using System.Text;
using NWR.DAL;
using NWR.Model;

namespace NWR.BLL
{
    /// <summary>
    /// 角色表逻辑类
    /// </summary>
    public class RolesBll
    {

        #region 私有字段

        /// <summary>
        /// 菜单表通信类
        /// </summary>
        private RolesDao _rolesDao = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public RolesBll()
        {
            _rolesDao = new RolesDao();
        }

        #endregion

        #region 对外接口

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        public int AddModel(Roles model)
        {
            try
            {
                return _rolesDao.AddModel(model);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(Roles model)
        {
            try
            {
                return _rolesDao.EditModel(model);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 上移下移
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int UpdateSort(Roles model, int sort)
        {
            try
            {
                return _rolesDao.UpdateSort(model, sort);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public int DelteModel(int menuID)
        {
            try
            {
                return _rolesDao.DeleteModel(menuID);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<Roles> GetModel(int menuTypeID, int parentID)
        {
            return _rolesDao.GetModel(menuTypeID, parentID);
        }

        #endregion

        #region 私有函数

        #endregion

    }
}
