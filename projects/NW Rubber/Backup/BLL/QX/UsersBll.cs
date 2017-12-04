using System;
using System.Collections.Generic;
using System.Text;
using NWR.DAL;
using NWR.Model;
using System.Data;

namespace NWR.BLL
{
    public class UsersBll
    {

        #region ˽���ֶ�

        /// <summary>
        /// �û���ͨ����
        /// </summary>
        private UsersDao _usersDao = null;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UsersBll()
        {
            _usersDao = new UsersDao();
        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// ��ȡ�����ַ���
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string GetMD5(string pwd)
        {
            return MD5encryption.GetMD5(pwd);
        }

        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(Users model)
        {

            int result = 0;

            try
            {
                result = _usersDao.AddModel(model);
            }
            catch (Exception ex)
            {
                //д��Log��־
                //
                return -1;
            }

            return result;

        }

        /// <summary>
        /// �޸�ʵ��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(Users model)
        {

            int result = 0;

            try
            {
                result = _usersDao.EditModel(model);
            }
            catch (Exception ex)
            {
                //д��Log��־
                //
                return -1;
            }

            return result;

        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int EditPwd(Users model, string pwd)
        {
            return _usersDao.EditPwd(model, pwd);
        }

        /// <summary>
        /// �ж��˺��Ƿ����
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public bool ExsitModel(string userAccount)
        {

            bool result = true;

            try
            {
                result = _usersDao.ExsitModel(userAccount);
            }
            catch (Exception ex)
            {
                //д��Log��־
                //
                return true;
            }

            return result;

        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="deleteUserID"></param>
        /// <param name="deleteReason"></param>
        /// <returns></returns>
        public int DeleteModel(int userID, int deleteUserID, string deleteReason)
        {
            int result = 0;

            Users model = GetModel(userID);
            model.DeleteDate = GetDBTime();
            model.DeleteReason = deleteReason;
            model.DeleteUserID = deleteUserID;
            model.UserType = EnumUserType.Disable;

            try
            {
                result = _usersDao.DeleteModel(model);
            }
            catch (Exception ex)
            {
                //д��Log��־
                //
                return -1;
            }

            return result;

        }

        /// <summary>
        /// ��ȡ�û�ʵ��
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Users GetModel(int userID)
        {
            try
            {
                return _usersDao.GetModel(userID);
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }
        /// <summary>
        /// ��ȡ�û�ʵ��
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Users GetModel(string account)
        {
            try
            {
                return _usersDao.GetModel(account);
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetTable(string strwhere)
        {
            try
            {
                return _usersDao.GetTable(strwhere);
            }
            catch (Exception ex)
            {
                //д��Log��־
                //
                return null;
            }

        }

        /// <summary>
        /// ��ȡ������ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime GetDBTime()
        {

            DateTime now = DateTime.MinValue;

            try
            {
                now = _usersDao.GetDBTime();
            }
            catch (Exception ex)
            {
                //д��Log��־ 
                //
                return Convert.ToDateTime("1900-01-01");
            }

            return now;

        }

        #endregion

        #region ˽�к���

        #endregion

    }
}
