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
    /// 角色表通讯类
    /// </summary>
    public class RolesDao
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
        public RolesDao()
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
        public int AddModel(Roles model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_Roles] ([MenuTypeID], [ParentID], [RoleName], [Sort], [Description]) "
                + "VALUES (@MenuTypeID, @ParentID, @RoleName, @Sort, @Description)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, model.MenuTypeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ParentID", SqlDbType.Int, model.ParentID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleName", SqlDbType.NVarChar, 100, model.RoleName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Sort", SqlDbType.Int, model.Sort));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// 修改模具
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(Roles model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_Roles] SET ");
            sql.AppendFormat("[MenuTypeID] = @MenuTypeID, ");
            sql.AppendFormat("[ParentID] = @ParentID, ");
            sql.AppendFormat("[RoleName] = @RoleName, ");
            sql.AppendFormat("[Sort] = @Sort, ");
            sql.AppendFormat("[Description] = @Description ");
            sql.AppendFormat("WHERE [RoleID] = @RoleID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, model.MenuTypeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ParentID", SqlDbType.Int, model.ParentID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleName", SqlDbType.NVarChar, 100, model.RoleName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Sort", SqlDbType.Int, model.Sort));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));

            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 上移下移
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int UpdateSort(Roles model, int sort)
        {
            StringBuilder sql = new StringBuilder();

            if (sort > 0)
            {
                //下移一位
                sql.AppendFormat("UPDATE [QX_Roles] SET [Sort] = {0} WHERE [MenutypeID]={1} AND Sort={2}"
                    , model.Sort.ToString()
                    , model.MenuTypeID.ToString()
                    , (model.Sort + 1).ToString());
                sql.AppendLine();
                sql.AppendFormat("UPDATE [QX_Roles] SET [Sort] = {0} WHERE [RoleID] = {1}"
                    , (model.Sort + 1).ToString()
                    , model.RoleID.ToString());
            }
            else
            {
                //上移一位
                sql.AppendFormat("UPDATE [QX_Roles] SET [Sort] = {0} WHERE [MenutypeID]={1} AND Sort={2}"
                    , model.Sort.ToString()
                    , model.MenuTypeID.ToString()
                    , (model.Sort - 1).ToString());
                sql.AppendLine();
                sql.AppendFormat("UPDATE [QX_Roles] SET [Sort] = {0} WHERE [RoleID] = {1}"
                    , (model.Sort - 1).ToString()
                    , model.RoleID.ToString());
            }

            return ExecuteNonQuery(sql.ToString(), null);
        }

        /// <summary>
        /// 删除模具
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(int roleID)
        {
            string sql = "DELETE [QX_Roles] WHERE [RoleID] = @RoleID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, roleID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询模具列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<Roles> GetModel()
        {
            string sql = "SELECT [RoleID], [MenuTypeID], [ParentID], [RoleName], [Sort], [Description] FROM [QX_Roles]";
            return GetList(sql, null);
        }
        /// <summary>
        /// 查询模具列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<Roles> GetModel(int menuTypeID, int parentID)
        {
            string sql = "SELECT [RoleID], [MenuTypeID], [ParentID], [RoleName], [Sort], [Description] FROM [QX_Roles] WHERE MenuTypeID = @MenuTypeID AND ParentID=@ParentID ORDER BY [Sort] ";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, menuTypeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ParentID", SqlDbType.Int, parentID));

            return GetList(sql, parameters);
        }
        /// <summary>
        /// 查询模具实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Roles GetModel(int roleID)
        {
            string sql = "SELECT TOP 1 [RoleID], [RoleName], [Description] FROM [QX_Roles] WHERE RoleID = @RoleID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, roleID));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// 查询模具列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable()
        {
            string sql = "SELECT [RoleID], [RoleName], [Description] FROM [QX_Roles]";
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
        private List<Roles> GetList(string sql, IList<DbParameter> parameters)
        {
            List<Roles> ls = new List<Roles>();

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            Roles model;

            while (reader.Read())
            {
                model = new Roles();
                GetRoles(reader, ref model);
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
        private Roles GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            Roles model = new Roles();

            while (reader.Read())
            {
                GetRoles(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// 获取Roles实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetRoles(SqlDataReader reader, ref Roles model)
        {
            model.RoleID = Convert.ToInt32(reader["RoleID"]);
            model.MenuTypeID = Convert.ToInt32(reader["MenuTypeID"]);
            model.ParentID = Convert.ToInt32(reader["ParentID"]);
            model.RoleName = Convert.ToString(reader["RoleName"]);
            model.Sort = Convert.ToInt32(reader["Sort"]);
            model.Description = Convert.ToString(reader["Description"]);
        }

        #endregion

    }
}
