using System;
using System.Collections.Generic;
using System.Text;
using NWR.DAL;
using NWR.Model;

namespace NWR.BLL
{
    /// <summary>
    /// ��ɫ���߼���
    /// </summary>
    public class RolesBll
    {

        #region ˽���ֶ�

        /// <summary>
        /// �˵���ͨ����
        /// </summary>
        private RolesDao _rolesDao = null;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public RolesBll()
        {
            _rolesDao = new RolesDao();
        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// ��Ӳ˵�
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
        /// �޸Ĳ˵�
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
        /// ��������
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
        /// ɾ���˵�
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
        /// ��ȡ�˵��б�
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<Roles> GetModel(int menuTypeID, int parentID)
        {
            return _rolesDao.GetModel(menuTypeID, parentID);
        }

        #endregion

        #region ˽�к���

        #endregion

    }
}
