using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace NWR.DAL
{
    /// <summary>
    /// SQL���ݿ�������
    /// </summary>
    public class CommonDbConneciton
    {

        #region ˽���ֶ�

        /// <summary>
        /// ���ݿ⹤��
        /// </summary>
        private DbProviderFactory _providerFactory;

        #endregion

        #region ��������

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public string ConnectionString;

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public CommonDbConneciton(string connectionString)
        {
            ConnectionString = connectionString;
            _providerFactory = ProviderFactory.GetDbProviderFactory(DbProviderType.SqlServer);
            if (_providerFactory == null)
            {
                throw new ArgumentException("���ݿ⹤������Ϊ��");
            }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public CommonDbConneciton(string connectionString, DbProviderType providerType)
        {
            ConnectionString = connectionString;
            _providerFactory = ProviderFactory.GetDbProviderFactory(providerType);
            if (_providerFactory == null)
            {
                throw new ArgumentException("���ݿ⹤������Ϊ��");
            }
        }

        #endregion

        #region �ӿں���

        /// <summary>
        /// ��Ӳ�������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return CreateDbParameter(name, ParameterDirection.Input, value);
        }
        /// <summary>
        /// ��Ӳ�������
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
        /// ��Ӳ�������
        /// </summary>
        /// <param name="parameterName">Ҫӳ��Ĳ���������</param>
        /// <param name="dbType">System.Data.SqlDbType ֵ֮һ</param>
        /// <param name="value">����ֵ</param>
        /// <returns></returns>
        public SqlParameter CreateSqlParameter(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter parameter = new SqlParameter(parameterName, dbType);
            parameter.Value = value;
            return parameter;
        }
        /// <summary>
        /// ��Ӳ�������
        /// </summary>
        /// <param name="parameterName">Ҫӳ��Ĳ���������</param>
        /// <param name="dbType">System.Data.SqlDbType ֵ֮һ</param>
        /// <param name="size">�����ĳ���</param>
        /// <param name="value">����ֵ</param>
        /// <returns></returns>
        public SqlParameter CreateSqlParameter(string parameterName, SqlDbType dbType, int size, object value)
        {
            SqlParameter parameter = new SqlParameter(parameterName, dbType, size);
            parameter.Value = value;
            return parameter;
        }


        /// <summary>
        /// �����ݿ�ִ����ɾ�Ĳ�����������Ӱ�������
        /// </summary>
        /// <param name="sql">Ҫִ�е���ɾ�ĵ�SQL���</param>
        /// <param name="parameters">ִ����ɾ���������Ҫ�Ĳ���</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// �����ݿ�ִ����ɾ�Ĳ�����������Ӱ�������
        /// </summary>
        /// <param name="sql">Ҫִ�е���ɾ�ĵ�SQL���</param>
        /// <param name="parameters">ִ����ɾ���������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                //��Ӱ�������
                int affectedRows = command.ExecuteNonQuery();
                command.Connection.Close();
                return affectedRows;
            }
        }


        /// <summary>
        /// ִ��һ����ѯ��䣬����һ��������DataReaderʵ��
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters)
        {
            return ExecuteReader(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// ִ��һ����ѯ��䣬����һ��������DataReaderʵ��
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, IList<DbParameter> parameters, CommandType commandType)
        {
            DbCommand command = CreateDbCommand(sql, parameters, commandType);
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }


        /// <summary>
        /// ִ��һ����ѯ��䣬����һ��������ѯ�����DataTable
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, IList<DbParameter> parameters)
        {
            return ExecuteDataTable(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// ִ��һ����ѯ��䣬����һ��������ѯ�����DataTable
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
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
        /// ִ��һ����ѯ��䣬���ز�ѯ����ĵ�һ�е�һ��
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, IList<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// ִ��һ����ѯ��䣬���ز�ѯ����ĵ�һ�е�һ��
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
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
        /// ��ѯ���ʵ�弯��
        /// </summary>
        /// <typeparam name="T">���ص�ʵ�弯������</typeparam>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <returns></returns>
        public List<T> QueryForList<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForList<T>(sql, parameters, CommandType.Text);
        }
        /// <summary>
        ///  ��ѯ���ʵ�弯��
        /// </summary>
        /// <typeparam name="T">���ص�ʵ�弯������</typeparam>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
        /// <returns></returns>
        public List<T> QueryForList<T>(string sql, IList<DbParameter> parameters, CommandType commandType) where T : new()
        {
            DataTable data = ExecuteDataTable(sql, parameters, commandType);
            return EntityReader.GetEntities<T>(data);
        }


        /// <summary>
        /// ��ѯ����ʵ��
        /// </summary>
        /// <typeparam name="T">���ص�ʵ�弯������</typeparam>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <returns></returns>
        public T QueryForObject<T>(string sql, IList<DbParameter> parameters) where T : new()
        {
            return QueryForObject<T>(sql, parameters, CommandType.Text);
        }
        /// <summary>
        /// ��ѯ����ʵ��
        /// </summary>
        /// <typeparam name="T">���ص�ʵ�弯������</typeparam>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
        /// <returns></returns>
        public T QueryForObject<T>(string sql, IList<DbParameter> parameters, CommandType commandType) where T : new()
        {
            return QueryForList<T>(sql, parameters, commandType)[0];
        }


        #endregion

        #region ˽�к���

        /// <summary>
        /// ����DbCommand����
        /// </summary>
        /// <param name="sql">Ҫִ�еĲ�ѯ���</param>
        /// <param name="parameters">ִ��SQL��ѯ�������Ҫ�Ĳ���</param>
        /// <param name="commandType">ִ�е�SQL��������</param>
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
    /// ���ݿ�����ö�� 
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
    /// DbProviderFactory������ 
    /// </summary> 
    public class ProviderFactory
    {

        #region ˽���ֶ�

        /// <summary>
        /// ���Ƽ���
        /// </summary>
        private static Dictionary<DbProviderType, string> providerInvariantNames = new Dictionary<DbProviderType, string>();

        /// <summary>
        /// ��������
        /// </summary>
        private static Dictionary<DbProviderType, DbProviderFactory> providerFactoies = new Dictionary<DbProviderType, DbProviderFactory>(20);

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        static ProviderFactory()
        {
            //������֪�����ݿ������ĳ��� 
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

        #region ��ں���

        /// <summary> 
        /// ��ȡָ�����ݿ����Ͷ�Ӧ�ĳ������� 
        /// </summary> 
        /// <param name="providerType">���ݿ�����ö��</param> 
        /// <returns></returns> 
        public static string GetProviderInvariantName(DbProviderType providerType)
        {
            return providerInvariantNames[providerType];
        }

        /// <summary> 
        /// ��ȡָ�����͵����ݿ��Ӧ��DbProviderFactory 
        /// </summary> 
        /// <param name="providerType">���ݿ�����ö��</param> 
        /// <returns></returns> 
        public static DbProviderFactory GetDbProviderFactory(DbProviderType providerType)
        {
            //�����û�м��أ�����ظ�DbProviderFactory 
            if (!providerFactoies.ContainsKey(providerType))
            {
                providerFactoies.Add(providerType, ImportDbProviderFactory(providerType));
            }
            return providerFactoies[providerType];
        }

        #endregion

        #region ˽�к���

        /// <summary> 
        /// ����ָ�����ݿ����͵�DbProviderFactory 
        /// </summary> 
        /// <param name="providerType">���ݿ�����ö��</param> 
        /// <returns></returns> 
        private static DbProviderFactory ImportDbProviderFactory(DbProviderType providerType)
        {
            string providerName = providerInvariantNames[providerType];
            DbProviderFactory factory = null;

            try
            {
                //��ȫ�ֳ����в���
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
