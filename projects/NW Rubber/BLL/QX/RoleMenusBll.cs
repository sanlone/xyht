using System;
using System.Collections.Generic;
using System.Text;
using NWR.DAL;
using NWR.Model;

namespace NWR.BLL
{
    public class RoleMenusBll
    {
        #region ˽���ֶ�

        /// <summary>
        /// �˵���ͨ����
        /// </summary>
        private RoleMenusDao _roleMenusDao = null;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public RoleMenusBll()
        {
            _roleMenusDao = new RoleMenusDao();
        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="RoleMenus"></param>
        /// <returns></returns>
        public int AddModel(RoleMenus model)
        {
            try
            {
                return _roleMenusDao.AddModel(model);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(RoleMenus model)
        {
            try
            {
                return _roleMenusDao.EditModel(model);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public int DelteModel(int menuID)
        {
            try
            {
                return _roleMenusDao.DeleteModel(menuID);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// ��ȡ�˵��б�
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<RoleMenus> GetModel()
        {
            return _roleMenusDao.GetModel();
        }
        public RoleMenus GetModel(int roleID)
        {
            try
            {
                return _roleMenusDao.GetModel(roleID);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region ˽�к���

        #endregion


    }
}
