using System;
using System.Collections.Generic;
using System.Text;
using NWR.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace NWR.DAL
{
    /// <summary>
    /// 用户角色表通讯类
    /// </summary>
    public class UserRolesDao
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
        public UserRolesDao()
        {
            //初始化通用连接库
            _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);
        }

        #endregion

        #region 接口函数

        /// <summary>
        /// 添加模具
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(UserRoles model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_G_UserRoles] ([UserID],[RoleID],[Description]) "
                + "VALUES (@UserID, @RoleID, @Description)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, model.UserID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.NText, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// 修改模具
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(UserRoles model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_G_UserRoles] SET ");
            sql.AppendFormat("[UserID] = @UserID, ");
            sql.AppendFormat("[RoleID] = @RoleID, ");
            sql.AppendFormat("[Description] = @Description ");
            sql.AppendFormat("WHERE [UserRoleID] = @UserRoleID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, model.UserID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.NText, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserRoleID", SqlDbType.Int, model.UserRoleID));

            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 删除模具
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(int roleID)
        {
            string sql = "DELETE [QX_G_UserRoles] WHERE [UserRoleID] = @UserRoleID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserRoleID", SqlDbType.Int, roleID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询模具列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<UserRoles> GetModel()
        {
            string sql = "SELECT [UserRoleID],[UserID],[RoleID],[Description] FROM [QX_G_UserRoles]";
            return GetList(sql, null);
        }
        /// <summary>
        /// 查询模具实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public UserRoles GetModel(int userID)
        {
            string sql = "SELECT TOP 1 [UserRoleID],[UserID],[RoleID],[Description] FROM [QX_G_UserRoles] WHERE UserID = @UserID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@UserID", SqlDbType.Int, userID));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// 查询模具列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable()
        {
            string sql = "SELECT [UserRoleID],[UserID],[RoleID],[Description] FROM [QX_G_UserRoles]";
            return _commonDbConneciton.ExecuteDataTable(sql, null);
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
        /// 查询模具列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<UserRoles> GetList(string sql, IList<DbParameter> parameters)
        {
            List<UserRoles> ls = new List<UserRoles>();

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            UserRoles model;

            while (reader.Read())
            {
                model = new UserRoles();
                GetUserRoles(reader, ref model);
                ls.Add(model);
            }

            reader.Close();

            return ls;
        }

        /// <summary>
        /// 查询模具列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private UserRoles GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            UserRoles model = new UserRoles();

            while (reader.Read())
            {
                GetUserRoles(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// 获取UserRoles实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetUserRoles(SqlDataReader reader, ref UserRoles model)
        {
            model.UserRoleID = Convert.ToInt32(reader["UserRoleID"]);
            model.UserID = Convert.ToInt32(reader["UserID"]);
            model.RoleID = Convert.ToString(reader["RoleID"]);
            model.Description = Convert.ToString(reader["Description"]);
        }

        #endregion

    }
}
