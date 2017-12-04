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

        #region 私有字段

        /// <summary>
        /// 用户表通信类
        /// </summary>
        private UsersDao _usersDao = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public UsersBll()
        {
            _usersDao = new UsersDao();
        }

        #endregion

        #region 对外接口

        /// <summary>
        /// 获取加密字符串
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string GetMD5(string pwd)
        {
            return MD5encryption.GetMD5(pwd);
        }

        /// <summary>
        /// 添加实体
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
                //写入Log日志
                //
                return -1;
            }

            return result;

        }

        /// <summary>
        /// 修改实体
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
                //写入Log日志
                //
                return -1;
            }

            return result;

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int EditPwd(Users model, string pwd)
        {
            return _usersDao.EditPwd(model, pwd);
        }

        /// <summary>
        /// 判断账号是否存在
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
                //写入Log日志
                //
                return true;
            }

            return result;

        }

        /// <summary>
        /// 删除用户
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
                //写入Log日志
                //
                return -1;
            }

            return result;

        }

        /// <summary>
        /// 获取用户实体
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
        /// 获取用户实体
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
                //写入Log日志
                //
                return null;
            }

        }

        /// <summary>
        /// 获取服务器时间
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
                //写入Log日志 
                //
                return Convert.ToDateTime("1900-01-01");
            }

            return now;

        }

        #endregion

        #region 私有函数

        #endregion

    }
}
