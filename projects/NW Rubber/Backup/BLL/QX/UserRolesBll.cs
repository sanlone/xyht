using System;
using System.Collections.Generic;
using System.Text;
using NWR.DAL;
using NWR.Model;
using System.Data;

namespace NWR.BLL
{
    public class UserRolesBll
    {

        #region 私有字段

        /// <summary>
        /// 用户角色表通信类
        /// </summary>
        private UserRolesDao _userRolesDao = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public UserRolesBll()
        {
            _userRolesDao = new UserRolesDao();
        }

        #endregion

        #region 对外接口

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="UserRoles"></param>
        /// <returns></returns>
        public int AddModel(UserRoles model)
        {
            try
            {
                return _userRolesDao.AddModel(model);
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
        public int EditModel(UserRoles model)
        {
            try
            {
                return _userRolesDao.EditModel(model);
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
                return _userRolesDao.DeleteModel(menuID);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 根据用户编号获取用户角色
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserRoles GetModel(int userID)
        {
            try
            {
                return _userRolesDao.GetModel(userID);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<UserRoles> GetModel()
        {
            try
            {
                return _userRolesDao.GetModel();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 私有函数

        #endregion

    }
}
