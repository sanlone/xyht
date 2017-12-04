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

        #region ˽���ֶ�

        /// <summary>
        /// �û���ɫ��ͨ����
        /// </summary>
        private UserRolesDao _userRolesDao = null;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UserRolesBll()
        {
            _userRolesDao = new UserRolesDao();
        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// ��Ӳ˵�
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
        /// �޸Ĳ˵�
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
        /// ɾ���˵�
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
        /// �����û���Ż�ȡ�û���ɫ
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
        /// ��ȡ�û���ɫ�б�
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

        #region ˽�к���

        #endregion

    }
}
