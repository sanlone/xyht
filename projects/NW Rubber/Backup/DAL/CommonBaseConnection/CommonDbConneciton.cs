using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace NWR.DAL
{
    /// <summary>
    /// SQL数据库连接类
    /// </summary>
    public class CommonDbConneciton
    {

        #region 私有字段

        /// <summary>
        /// 数据库工厂
        /// </summary>
        private DbProviderFactory _providerFactory;

        #endregion

        #region 公共属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommonDbConneciton(string connectionString)
        {
            ConnectionString = connectionString;
            _providerFactory = ProviderFactory.GetDbProviderFactory(DbProviderType.SqlServer);
            if (_providerFactory == null)
            {
                throw new ArgumentException("数据库工厂对象为空");
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommonDbConneciton(string connectionString, DbProviderType providerType)
        {
            ConnectionString = connectionString;
            _providerFactory = ProviderFactory.GetDbProviderFactory(providerType);
            if (_providerFactory == null)
            {
                throw new ArgumentException("数据库工厂对象为空");
            }
        }

        #endregion

        #region 接口函数

        /// <summary>
        /// 添加参数对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return CreateDbParameter(name, ParameterDirection.Input, value);
        }
        /// <summary>
        /// 添加参数对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterDirection"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value)
        {
            DbParameter parameter = _providerFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            return parameter;
        }


        /// <summary>
        /// 添加参数对象
        /// </summary>
        /// <param name="parameterName">要映射的参数的名称</param>
        /// <param name="dbType">System.Data.SqlDbType 值之一</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public SqlParameter CreateSqlParameter(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter parameter = new SqlParameter(parameterName, dbType);
            parameter.Value = value;
            return parameter;
        }
        /// <summary>
        /// 添加参数对象
        /// </summary>
        /// <param name="parameterName">要映射的参数的名称</param>
        /// <param name="dbType">System.Data.SqlDbType 值之一</param>
        /// <param name="size">参数的长度</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public SqlParameter CreateSqlParameter(string parameterName, SqlDbType dbType, int size, object value)
        {
            SqlParameter parameter = new SqlParameter(parameterName, dbType, size);
            parameter.Value = value;
            return parameter;
        }


        /// <summary>
        /// 对数据库执行增删改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql">要执行的增删改的SQL语句</param>
        /// <param name="parameters">执行增删改语句所需要的参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// 对数据库执行增删改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql">要执行的增删改的SQL语句</param>
        /// <param name="parameters">执行增删改语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                //受影响的行数
                int affectedRows = command.ExecuteNonQuery();
                command.Connection.Close();
                return affectedRows;
            }
        }


        /// <summary>
        /// 执行一个查询语句，返回一个关联的DataReader实例
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters)
        {
            return ExecuteReader(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// 执行一个查询语句，返回一个关联的DataReader实例
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbCommand command = CreateDbCommand(sql, parameters, commandType);
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }


        /// <summary>
        /// 执行一个查询语句，返回一个包含查询结果的DataTable
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters)
        {
            return ExecuteDataTable(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// 执行一个查询语句，返回一个包含查询结果的DataTable
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                using (DbDataAdapter adapter = _providerFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }


        /// <summary>
        /// 执行一个查询语句，返回查询结果的第一行第一列
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, IList<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// 执行一个查询语句，返回查询结果的第一行第一列
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                object result = command.ExecuteScalar();
                command.Connection.Close();
                return result;
            }
        }


        /// <summary>
        /// 查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public List<T> QueryForList<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForList<T>(sql, parameters, CommandType.Text);
        }
        /// <summary>
        ///  查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public List<T> QueryForList<T>(string sql, IList<DbParameter> parameters, CommandType commandType) where T : new()
        {
            DataTable data = ExecuteDataTable(sql, parameters, commandType);
            return EntityReader.GetEntities<T>(data);
        }


        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public T QueryForObject<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForObject<T>(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public T QueryForObject<T>(string sql, IList<DbParameter> parameters, CommandType commandType) where T : new()
        {
            return QueryForList<T>(sql, parameters, commandType)[0];
        }


        #endregion

        #region 私有函数

        /// <summary>
        /// 创建DbCommand对象
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        private DbCommand CreateDbCommand(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbConnection connection = _providerFactory.CreateConnection();
            DbCommand command = connection.CreateCommand();
            connection.ConnectionString = ConnectionString;
            command.CommandText = sql;
            command.CommandType = commandType;
            command.Connection = connection;

            if (!(parameters == null || parameters.Count == 0))
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;

        }





        #endregion

    }


    /// <summary> 
    /// 数据库类型枚举 
    /// </summary> 
    public enum DbProviderType : byte
    {
        SqlServer,
        MySql,
        SQLite,
        Oracle,
        ODBC,
        OleDb,
        Firebird,
        PostgreSql,
        DB2,
        Informix,
        SqlServerCe
    }


    /// <summary> 
    /// DbProviderFactory工厂类 
    /// </summary> 
    public class ProviderFactory
    {

        #region 私有字段

        /// <summary>
        /// 名称集合
        /// </summary>
        private static Dictionary<DbProviderType, string> providerInvariantNames = new Dictionary<DbProviderType, string>();

        /// <summary>
        /// 工厂集合
        /// </summary>
        private static Dictionary<DbProviderType, DbProviderFactory> providerFactoies = new Dictionary<DbProviderType, DbProviderFactory>(20);

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        static ProviderFactory()
        {
            //加载已知的数据库访问类的程序集 
            providerInvariantNames.Add(DbProviderType.SqlServer, "System.Data.SqlClient");
            providerInvariantNames.Add(DbProviderType.OleDb, "System.Data.OleDb");
            providerInvariantNames.Add(DbProviderType.ODBC, "System.Data.ODBC");
            providerInvariantNames.Add(DbProviderType.Oracle, "Oracle.DataAccess.Client");
            providerInvariantNames.Add(DbProviderType.MySql, "MySql.Data.MySqlClient");
            providerInvariantNames.Add(DbProviderType.SQLite, "System.Data.SQLite");
            providerInvariantNames.Add(DbProviderType.Firebird, "FirebirdSql.Data.Firebird");
            providerInvariantNames.Add(DbProviderType.PostgreSql, "Npgsql");
            providerInvariantNames.Add(DbProviderType.DB2, "IBM.Data.DB2.iSeries");
            providerInvariantNames.Add(DbProviderType.Informix, "IBM.Data.Informix");
            providerInvariantNames.Add(DbProviderType.SqlServerCe, "System.Data.SqlServerCe");
        }

        #endregion

        #region 借口函数

        /// <summary> 
        /// 获取指定数据库类型对应的程序集名称 
        /// </summary> 
        /// <param name="providerType">数据库类型枚举</param> 
        /// <returns></returns> 
        public static string GetProviderInvariantName(DbProviderType providerType)
        {
            return providerInvariantNames[providerType];
        }

        /// <summary> 
        /// 获取指定类型的数据库对应的DbProviderFactory 
        /// </summary> 
        /// <param name="providerType">数据库类型枚举</param> 
        /// <returns></returns> 
        public static DbProviderFactory GetDbProviderFactory(DbProviderType providerType)
        {
            //如果还没有加载，则加载该DbProviderFactory 
            if (!providerFactoies.ContainsKey(providerType))
            {
                providerFactoies.Add(providerType, ImportDbProviderFactory(providerType));
            }
            return providerFactoies[providerType];
        }

        #endregion

        #region 私有函数

        /// <summary> 
        /// 加载指定数据库类型的DbProviderFactory 
        /// </summary> 
        /// <param name="providerType">数据库类型枚举</param> 
        /// <returns></returns> 
        private static DbProviderFactory ImportDbProviderFactory(DbProviderType providerType)
        {
            string providerName = providerInvariantNames[providerType];
            DbProviderFactory factory = null;

            try
            {
                //从全局程序集中查找
                factory = DbProviderFactories.GetFactory(providerName);
            }
            catch (ArgumentException e)
            {
                factory = null;
                throw e;
            }

            return factory;

        }

        #endregion

    }
}
