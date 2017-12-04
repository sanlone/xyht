using System;
using System.Collections.Generic;
using System.Text;
using NWR.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace NWR.DAL
{
    /// <summary>
    /// 菜单表通讯类
    /// </summary>
    public class MenusDao
    {

        #region 私有字段

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private CommonDbConneciton _commonDbConneciton;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public MenusDao()
        {
            //添加引用System.configuration
            _connectionString = Base64encryption.DecodeBase64(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _commonDbConneciton = new CommonDbConneciton(_connectionString);
        }

        #endregion

        #region 接口函数

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(Menus model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_Menus] ([MenuTypeID],[ParentID],[MenuName],[MenuPath],[Sort],[ImagePath],[Description]) "
                + "VALUES (@MenuTypeID,@ParentID,@MenuName,@MenuPath,@Sort,@ImagePath,@Description)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, model.MenuTypeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ParentID", SqlDbType.Int, model.ParentID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuName", SqlDbType.NVarChar, 100, model.MenuName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuPath", SqlDbType.NVarChar, 100, model.MenuPath));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Sort", SqlDbType.Int, model.Sort));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ImagePath", SqlDbType.NVarChar, 100, model.ImagePath));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(Menus model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_Menus] SET ");
            sql.AppendFormat("[MenuTypeID] = @MenuTypeID, ");
            sql.AppendFormat("[ParentID] = @ParentID, ");
            sql.AppendFormat("[MenuName] = @MenuName, ");
            sql.AppendFormat("[MenuPath] = @MenuPath, ");
            sql.AppendFormat("[Sort] = @Sort, ");
            sql.AppendFormat("[ImagePath] = @ImagePath, ");
            sql.AppendFormat("[Description] = @Description ");
            sql.AppendFormat("WHERE [MenuID] = @MenuID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuID", SqlDbType.Int, model.MenuID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, model.MenuTypeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ParentID", SqlDbType.Int, model.ParentID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuName", SqlDbType.NVarChar, 100, model.MenuName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuPath", SqlDbType.NVarChar, 100, model.MenuPath));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Sort", SqlDbType.Int, model.Sort));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ImagePath", SqlDbType.NVarChar, 100, model.ImagePath));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));


            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 上移下移
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int UpdateSort(Menus model, int sort)
        {
            StringBuilder sql = new StringBuilder();

            if (sort > 0)
            {
                //下移一位
                sql.AppendFormat("UPDATE [QX_Menus] SET [Sort] = {0} WHERE [MenutypeID]={1} AND Sort={2}"
                    , model.Sort.ToString()
                    , model.MenuTypeID.ToString()
                    , (model.Sort + 1).ToString());
                sql.AppendLine();
                sql.AppendFormat("UPDATE [QX_Menus] SET [Sort] = {0} WHERE [MenuID] = {1}"
                    , (model.Sort + 1).ToString()
                    , model.MenuID.ToString());
            }
            else
            {
                //上移一位
                sql.AppendFormat("UPDATE [QX_Menus] SET [Sort] = {0} WHERE [MenutypeID]={1} AND Sort={2}"
                    , model.Sort.ToString()
                    , model.MenuTypeID.ToString()
                    , (model.Sort - 1).ToString());
                sql.AppendLine();
                sql.AppendFormat("UPDATE [QX_Menus] SET [Sort] = {0} WHERE [MenuID] = {1}"
                    , (model.Sort - 1).ToString()
                    , model.MenuID.ToString());
            }

            return ExecuteNonQuery(sql.ToString(), null);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(int menuID)
        {
            string sql = "DELETE [QX_Menus] WHERE [MenuID] = @MenuID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuID", SqlDbType.Int, menuID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<Menus> GetModel()
        {
            string sql = "SELECT [MenuID],[MenuTypeID],[ParentID],[MenuName],[MenuPath],[Sort],[ImagePath],[Description] FROM [QX_Menus]";
            return GetList(sql, null);
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<Menus> GetModel(int menuTypeID, int parentID)
        {
            string sql = "SELECT [MenuID],[MenuTypeID],[ParentID],[MenuName],[MenuPath],[Sort],[ImagePath],[Description] FROM [QX_Menus] WHERE MenuTypeID = @MenuTypeID AND ParentID = @ParentID ORDER BY [Sort]";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, menuTypeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ParentID", SqlDbType.Int, parentID));

            return GetList(sql, parameters);
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Menus GetModel(int menuID)
        {
            string sql = "SELECT TOP 1 [MenuID],[MenuTypeID],[ParentID],[MenuName],[MenuPath],[Sort],[ImagePath],[Description] FROM [QX_Menus] WHERE MenuID = @MenuID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuID", SqlDbType.Int, menuID));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable()
        {
            string sql = "SELECT [MenuID],[MenuTypeID],[ParentID],[MenuName],[MenuPath],[Sort],[ImagePath],[Description] FROM [QX_Menus]";
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
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<Menus> GetList(string sql, IList<DbParameter> parameters)
        {
            List<Menus> ls = new List<Menus>();

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            Menus model;

            while (reader.Read())
            {
                model = new Menus();
                GetMenus(reader, ref model);
                ls.Add(model);
            }

            reader.Close();

            return ls;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Menus GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            Menus model = new Menus();

            while (reader.Read())
            {
                GetMenus(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// 获取Menus实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetMenus(SqlDataReader reader, ref Menus model)
        {
            model.MenuID = Convert.ToInt32(reader["MenuID"]);
            model.MenuTypeID = Convert.ToInt32(reader["MenuTypeID"]);
            model.ParentID = Convert.ToInt32(reader["ParentID"]);
            model.MenuName = Convert.ToString(reader["MenuName"]);
            model.MenuPath = Convert.ToString(reader["MenuPath"]);
            model.Sort = Convert.ToInt32(reader["Sort"]);
            model.ImagePath = Convert.ToString(reader["ImagePath"]);
            model.Description = Convert.ToString(reader["Description"]);
        }

        #endregion

    }


    /// <summary>
    /// 菜单类型表通讯类
    /// </summary>
    public class MenuTypeDao
    {

        #region 私有字段

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private CommonDbConneciton _commonDbConneciton;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuTypeDao()
        {
            //添加引用System.configuration
            _connectionString = Base64encryption.DecodeBase64(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            _commonDbConneciton = new CommonDbConneciton(_connectionString);
        }

        #endregion

        #region 接口函数

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(MenuType model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_MenuType] ([MenuTypeName],[Description]) "
                + "VALUES (@MenuTypeName,@Description)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeName", SqlDbType.NVarChar, 100, model.MenuTypeName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(MenuType model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_MenuType] SET ");
            sql.AppendFormat("[MenuTypeName] = @MenuTypeName, ");
            sql.AppendFormat("[Description] = @Description ");
            sql.AppendFormat("WHERE [MenuTypeID] = @MenuTypeID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeName", SqlDbType.NVarChar, 100, model.MenuTypeName));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.NVarChar, 200, model.Description));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, model.MenuTypeID));


            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(int menuTypeID)
        {
            string sql = "DELETE [QX_MenuType] WHERE [MenuTypeID] = @MenuTypeID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, menuTypeID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<MenuType> GetModel()
        {
            string sql = "SELECT [MenuTypeID],[MenuTypeName],[Description] FROM [QX_MenuType]";
            return GetList(sql, null);
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MenuType GetModel(int menuTypeID)
        {
            string sql = "SELECT TOP 1 [MenuTypeID],[MenuTypeName],[Description] FROM [QX_MenuType] WHERE MenuTypeID = @MenuTypeID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@MenuTypeID", SqlDbType.Int, menuTypeID));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable()
        {
            string sql = "SELECT [MenuTypeID],[MenuTypeName],[Description] FROM [QX_MenuType]";
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
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<MenuType> GetList(string sql, IList<DbParameter> parameters)
        {
            List<MenuType> ls = new List<MenuType>();

            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            MenuType model;

            while (reader.Read())
            {
                model = new MenuType();
                GetMenus(reader, ref model);
                ls.Add(model);
            }

            reader.Close();

            return ls;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private MenuType GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);

            MenuType model = new MenuType();

            while (reader.Read())
            {
                GetMenus(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// 获取Menus实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetMenus(SqlDataReader reader, ref MenuType model)
        {
            model.MenuTypeID = Convert.ToInt32(reader["MenuTypeID"]);
            model.MenuTypeName = Convert.ToString(reader["MenuTypeName"]);
            model.Description = Convert.ToString(reader["Description"]);
        }

        #endregion

    }
}
