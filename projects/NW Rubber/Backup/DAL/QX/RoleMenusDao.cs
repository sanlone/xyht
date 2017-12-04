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
    /// 权限表通讯类
    /// </summary>
    public class RoleMenusDao
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
        public RoleMenusDao()
        {
            //初始化通用连接库
            _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);
        }

        #endregion

        #region 接口函数

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(RoleMenus model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_G_RoleMenus] ([RoleID],[MenuList],[Description]) "
                + "VALUES (@RoleID, @MenuList, @Description)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuList", SqlDbType.NVarChar, model.MenuList));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(RoleMenus model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_G_RoleMenus] SET ");
            sql.AppendFormat("[RoleID] = @RoleID, ");
            sql.AppendFormat("[MenuList] = @MenuList, ");
            sql.AppendFormat("[Description] = @Description ");
            sql.AppendFormat("WHERE [RoleMenuID] = @RoleMenuID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuList", SqlDbType.NVarChar, model.MenuList));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleMenuID", SqlDbType.Int, model.RoleMenuID));

            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleMenuID"></param>
        /// <returns></returns>
        public int DeleteModel(int roleMenuID)
        {
            string sql = "DELETE [QX_G_RoleMenus] WHERE [RoleMenuID] = @RoleMenuID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleMenuID", SqlDbType.Int, roleMenuID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<RoleMenus> GetModel()
        {
            string sql = "SELECT [RoleMenuID],[RoleID],[MenuList],[Description] FROM [QX_G_RoleMenus]";
            return GetList(sql, null);
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="roleMenuID"></param>
        /// <returns></returns>
        public RoleMenus GetModel(int roleID)
        {
            string sql = "SELECT TOP 1 [RoleMenuID],[RoleID],[MenuList],[Description] FROM [QX_G_RoleMenus] WHERE RoleID = @RoleID";

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
            string sql = "SELECT [RoleMenuID],[RoleID],[MenuList],[Description] FROM [QX_G_RoleMenus]";
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
        private List<RoleMenus> GetList(string sql, IList<DbParameter> parameters)
        {
            List<RoleMenus> ls = new List<RoleMenus>();

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            RoleMenus model;

            while (reader.Read())
            {
                model = new RoleMenus();
                GetRoleMenus(reader, ref model);
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
        private RoleMenus GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            RoleMenus model = new RoleMenus();

            while (reader.Read())
            {
                GetRoleMenus(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// 获取RoleMenus实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetRoleMenus(SqlDataReader reader, ref RoleMenus model)
        {
            model.RoleMenuID = Convert.ToInt32(reader["RoleMenuID"]);
            model.RoleID = Convert.ToInt32(reader["RoleID"]);
            model.MenuList = Convert.ToString(reader["MenuList"]);
            model.Description = Convert.ToString(reader["Description"]);
        }

        #endregion

    }
}
