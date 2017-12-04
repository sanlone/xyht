using System;
using System.Collections.Generic;
using System.Text;
using NWR.DAL;
using NWR.Model;
using System.Data;

namespace NWR.BLL
{
    public class MenusBll
    {

        #region ˽���ֶ�

        /// <summary>
        /// �˵���ͨ����
        /// </summary>
        private MenusDao _menusDao = null;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public MenusBll()
        {
            _menusDao = new MenusDao();
        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// ��Ӳ˵�
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        public int AddModel(Menus model)
        {
            try
            {
                return _menusDao.AddModel(model);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// �޸Ĳ˵�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(Menus model)
        {
            try
            {
                return _menusDao.EditModel(model);
            }
            catch (Exception ex)
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
        public int UpdateSort(Menus model, int sort)
        {
            try
            {
                return _menusDao.UpdateSort(model, sort);
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
                return _menusDao.DeleteModel(menuID);
            }
            catch (Exception ex)
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
        public List<Menus> GetModel(int menuTypeID, int parentID)
        {
            try
            {
                return _menusDao.GetModel(menuTypeID, parentID);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        #endregion

        #region ˽�к���

        #endregion

    }

    public class MenuTypeBll
    {

        #region ˽���ֶ�

        /// <summary>
        /// �˵���ͨ����
        /// </summary>
        private MenuTypeDao _menuTypeDao = null;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public MenuTypeBll()
        {
            _menuTypeDao = new MenuTypeDao();

        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// ��Ӳ˵�
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        public int AddModel(MenuType menuType)
        {
            try
            {
                return _menuTypeDao.AddModel(menuType);
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        /// <summary>
        /// ��Ӳ˵�
        /// </summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        public int EditModel(MenuType menuType)
        {
            try
            {
                return _menuTypeDao.EditModel(menuType);
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(int menuTypeID)
        {
            try
            {
                return _menuTypeDao.DeleteModel(menuTypeID);
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        /// <summary>
        /// ��ȡ�˵������б�
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public MenuType GetModel(int menuTypeID)
        {
            try
            {
                return _menuTypeDao.GetModel(menuTypeID);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        /// <summary>
        /// ��ȡ�˵������б�
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<MenuType> GetModel()
        {
            try
            {
                return _menuTypeDao.GetModel();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        /// <summary>
        /// ��ȡ�˵������б�
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataTable GetTable()
        {
            try
            {
                return _menuTypeDao.GetTable();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        #endregion

        #region ˽�к���

        #endregion

    }
}
