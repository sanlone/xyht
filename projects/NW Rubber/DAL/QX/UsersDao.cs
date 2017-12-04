using System;
using System.Collections.Generic;
using System.Text;
using NWR.Model;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace NWR.DAL
{
    /// <summary>
    /// 用户表通讯类
    /// </summary>
    public class UsersDao
    {

        #region 私有字段

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private CommonDbConneciton _commonDbConneciton;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public UsersDao()
        {
            //初始化通用连接库
            _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);
        }

        #endregion

        #region 接口函数

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(Users model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_Users] ([UserAccount],[Password],[UserName],[Sex],[Birthday],[Phone],[Email],[EmployeeID],[DepartmentID],[EntryDate],[UserType],[Remark]) "
                + "VALUES (@UserAccount,@Password,@UserName,@Sex,@Birthday,@Phone,@Email,@EmployeeID,@DepartmentID,@EntryDate,@UserType,@Remark)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserAccount", SqlDbType.NVarChar, 50, model.UserAccount));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Password", SqlDbType.NVarChar, 50, model.Password));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserName", SqlDbType.NVarChar, 50, model.UserName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Sex", SqlDbType.TinyInt, model.Sex));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Birthday", SqlDbType.DateTime, model.Birthday));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Phone", SqlDbType.NVarChar, 20, model.Phone));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Email", SqlDbType.NVarChar, 50, model.Email));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@EmployeeID", SqlDbType.NVarChar, 50, model.EmployeeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DepartmentID", SqlDbType.Int, model.DepartmentID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@EntryDate", SqlDbType.DateTime, model.EntryDate));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserType", SqlDbType.TinyInt, model.UserType.GetHashCode()));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Remark", SqlDbType.NVarChar, 200, model.Remark));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public bool ExsitModel(string userAccount)
        {
            string sql = "SELECT COUNT(UserID) AS [Count] FROM [QX_Users] WHERE [UserAccount] = @UserAccount";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserAccount", SqlDbType.NVarChar, 50, userAccount));

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            int count = 0;

            while (reader.Read())
            {
                count = Convert.ToInt32(reader["Count"]);
            }

            return count > 0;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(Users model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_Users] SET ");
            sql.AppendFormat("[UserAccount] = @UserAccount, ");
            sql.AppendFormat("[Password] = @Password, ");
            sql.AppendFormat("[UserName] = @UserName, ");
            sql.AppendFormat("[Sex] = @Sex, ");
            sql.AppendFormat("[Birthday] = @Birthday, ");
            sql.AppendFormat("[Phone] = @Phone, ");
            sql.AppendFormat("[Email] = @Email, ");
            sql.AppendFormat("[EmployeeID] = @EmployeeID, ");
            sql.AppendFormat("[DepartmentID] = @DepartmentID, ");
            sql.AppendFormat("[UserType] = @UserType, ");
            sql.AppendFormat("[Remark] = @Remark ");
            sql.AppendFormat("WHERE [UserID] = @UserID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserAccount", SqlDbType.NVarChar, 50, model.UserAccount));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Password", SqlDbType.NVarChar, 50, model.Password));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserName", SqlDbType.NVarChar, 50, model.UserName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Sex", SqlDbType.TinyInt, model.Sex));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Birthday", SqlDbType.DateTime, model.Birthday));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Phone", SqlDbType.NVarChar, 20, model.Phone));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Email", SqlDbType.NVarChar, 50, model.Email));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@EmployeeID", SqlDbType.NVarChar, 50, model.EmployeeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DepartmentID", SqlDbType.Int, model.DepartmentID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserType", SqlDbType.TinyInt, model.UserType.GetHashCode()));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Remark", SqlDbType.NVarChar, 200, model.Remark));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, model.UserID));


            return ExecuteNonQuery(sql.ToString(), parameters);
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int EditPwd(Users model, string pwd)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE [QX_Users] SET [Password] = @Password ");
            sql.AppendFormat("WHERE [UserID] = @UserID AND [UserAccount] = @UserAccount");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserAccount", SqlDbType.NVarChar, 50, model.UserAccount));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Password", SqlDbType.NVarChar, 50, pwd));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, model.UserID));

            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(Users model)
        {
            string sql = "UPDATE [QX_Users] SET [DeleteDate] = @DeleteDate, [DeleteReason] = @DeleteReason, [DeleteUserID] = @DeleteUserID, [UserType] = @UserType WHERE [UserID] = @UserID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteDate", SqlDbType.DateTime, model.DeleteDate));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteReason", SqlDbType.NVarChar, 200, model.DeleteReason));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteUserID", SqlDbType.Int, model.DeleteUserID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserType", SqlDbType.Int, model.UserType));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, model.UserID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<Users> GetModel()
        {
            string sql = "SELECT [UserID],[UserAccount],[Password],[UserName],[Sex],[Birthday],[Phone],[Email],[EmployeeID],[DepartmentID],[EntryDate],[UserType],[DeleteDate],[DeleteReason],[DeleteUserID],[Remark] FROM [QX_Users]";
            return GetList(sql, null);
        }
        /// <summary>
        /// 查询实体实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Users GetModel(int userID)
        {
            string sql = "SELECT TOP 1 [UserID],[UserAccount],[Password],[UserName],[Sex],[Birthday],[Phone],[Email],[EmployeeID],[DepartmentID],[EntryDate],[UserType],[DeleteDate],[DeleteReason],[DeleteUserID],[Remark] FROM [QX_Users] WHERE UserID=@UserID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, userID));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// 查询实体实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Users GetModel(string userAccount)
        {
            string sql = "SELECT TOP 1 [UserID],[UserAccount],[Password],[UserName],[Sex],[Birthday],[Phone],[Email],[EmployeeID],[DepartmentID],[EntryDate],[UserType],[DeleteDate],[DeleteReason],[DeleteUserID],[Remark] FROM [QX_Users] WHERE UserType <> 4 AND UserAccount=@UserAccount";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserAccount", SqlDbType.NVarChar, 50, userAccount));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable(string strwhere)
        {
            string sql = "SELECT [UserID],[UserAccount],[Password],[UserName],[Sex],[Birthday],[Phone],[Email],[EmployeeID],[DepartmentID],[EntryDate],[UserType],[DeleteDate],[DeleteReason],[DeleteUserID],(SELECT UserName FROM [QX_Users] WHERE UserID = tab.[DeleteUserID]) [DeleteUserName],[Remark] FROM [QX_Users] tab " + strwhere;
            return _commonDbConneciton.ExecuteDataTable(sql, null);
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDBTime()
        {

            DateTime now = DateTime.MinValue;

            string sql = "SELECT GetDate() as Now";

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, null);

            while (reader.Read())
            {
                now = Convert.ToDateTime(reader["Now"]);
            }

            return now;

        }

        #endregion

        #region 私有函数

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return _commonDbConneciton.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<Users> GetList(string sql, IList<DbParameter> parameters)
        {
            List<Users> ls = new List<Users>();

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            Users model;

            while (reader.Read())
            {
                model = new Users();
                GetUsers(reader, ref model);
                ls.Add(model);
            }

            reader.Close();

            return ls;
        }

        /// <summary>
        /// 查询实体列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Users GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            Users model = new Users();

            while (reader.Read())
            {
                GetUsers(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// 获取Users实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetUsers(SqlDataReader reader, ref Users model)
        {
            model.UserID = Convert.ToInt32(reader["UserID"]);
            model.UserAccount = Convert.ToString(reader["UserAccount"]);
            model.Password = Convert.ToString(reader["Password"]);
            model.UserName = Convert.ToString(reader["UserName"]);
            model.Sex = Convert.ToInt32(reader["Sex"]);
            model.Birthday = Convert.ToDateTime(reader["Birthday"]);
            model.Phone = Convert.ToString(reader["Phone"]);
            model.Email = Convert.ToString(reader["Email"]);
            model.EmployeeID = Convert.ToString(reader["EmployeeID"]);
            model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
            model.EntryDate = Convert.ToDateTime(reader["EntryDate"]);
            model.UserType = GetUserType(Convert.ToInt32(reader["UserType"]));
            if (!string.IsNullOrEmpty(reader["DeleteDate"].ToString()))
            {
                model.DeleteDate = Convert.ToDateTime(reader["DeleteDate"]);
            }
            if (!string.IsNullOrEmpty(reader["DeleteReason"].ToString()))
            {
                model.DeleteReason = Convert.ToString(reader["DeleteReason"]);
            }
            if (!string.IsNullOrEmpty(reader["DeleteUserID"].ToString()))
            {
                model.DeleteUserID = Convert.ToInt32(reader["DeleteUserID"]);
            }
            model.Remark = Convert.ToString(reader["Remark"]);
        }

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        private EnumUserType GetUserType(int typeID)
        {
            EnumUserType userType = EnumUserType.Formal;

            switch (typeID)
            {
                case 0: userType = EnumUserType.TrialPeriod; break;
                case 1: userType = EnumUserType.Temporary; break;
                case 2: userType = EnumUserType.Formal; break;
                case 3: userType = EnumUserType.HasLeft; break;
                case 4: userType = EnumUserType.Disable; break;
            }

            return userType;
        }


        #endregion

    }
}
