using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using NWR.Model;

namespace NWR.DAL
{
    public class SC_OrderDetailedArrangeDao
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
        public SC_OrderDetailedArrangeDao()
        {
            //初始化通用连接库
            _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);
        }
        #endregion
        #region 接口函数
        /// <summary>
        /// 添加实体
        /// </summary>
        public int AddModel(SC_OrderDetailedArrange model)
        {
            string sql = string.Empty;
            sql = @"SET identity_insert OrderList ON;INSERT INTO [SC_OrderDetailedArrange](
                        [OrderDetailedArrangeID]
                        ,[OrderDetailedID]
                        ,[ProduceTaskID]
                        ,[CreateDate]
                        ,[CreateUserID]
                        ,[DeleteDate]
                        ,[DeleteReason]
                        ,[DeleteUserID]
                        )VALUES(
                        @OrderDetailedArrangeID
                        ,@OrderDetailedID
                        ,@ProduceTaskID
                        ,@CreateDate
                        ,@CreateUserID
                        ,@DeleteDate
                        ,@DeleteReason
                        ,@DeleteUserID
                        )";
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@OrderDetailedArrangeID", SqlDbType.Int, model.OrderDetailedArrangeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@OrderDetailedID", SqlDbType.Int, model.OrderDetailedID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ProduceTaskID", SqlDbType.Int, model.ProduceTaskID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@CreateDate", SqlDbType.DateTime, model.CreateDate));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@CreateUserID", SqlDbType.NVarChar, model.CreateUserID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteDate", SqlDbType.DateTime, model.DeleteDate));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteReason", SqlDbType.NVarChar, model.DeleteReason));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteUserID", SqlDbType.NVarChar, model.DeleteUserID));
            return ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        public int EditModel(SC_OrderDetailedArrange model)
        {
            StringBuilder sql = new StringBuilder();
            IList<DbParameter> parameters = new List<DbParameter>();
            sql.AppendFormat("UPDATE [SC_OrderDetailedArrange] SET ");
            sql.AppendFormat("[OrderDetailedArrangeID] = @OrderDetailedArrangeID ");
            sql.AppendFormat(",[OrderDetailedID] = @OrderDetailedID ");
            sql.AppendFormat(",[ProduceTaskID] = @ProduceTaskID ");
            sql.AppendFormat(",[CreateDate] = @CreateDate ");
            sql.AppendFormat(",[CreateUserID] = @CreateUserID ");
            sql.AppendFormat(",[DeleteDate] = @DeleteDate ");
            sql.AppendFormat(",[DeleteReason] = @DeleteReason ");
            sql.AppendFormat(",[DeleteUserID] = @DeleteUserID ");
            sql.AppendFormat("WHERE [OrderDetailedArrangeID] = @OrderDetailedArrangeID ");
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@OrderDetailedArrangeID", SqlDbType.Int, model.OrderDetailedArrangeID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@OrderDetailedID", SqlDbType.Int, model.OrderDetailedID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@ProduceTaskID", SqlDbType.Int, model.ProduceTaskID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@CreateDate", SqlDbType.DateTime, model.CreateDate));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@CreateUserID", SqlDbType.NVarChar, model.CreateUserID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteDate", SqlDbType.DateTime, model.DeleteDate));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteReason", SqlDbType.NVarChar, model.DeleteReason));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@DeleteUserID", SqlDbType.NVarChar, model.DeleteUserID));
            return ExecuteNonQuery(sql.ToString(), parameters);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        public int DeleteModel(int id)
        {
            string sql = "DELETE [SC_OrderDetailedArrange] WHERE [OrderDetailedArrangeID] = @OrderDetailedArrangeID";
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@OrderDetailedArrangeID", SqlDbType.Int, id));
            return ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        public List<SC_OrderDetailedArrange> GetModel()
        {
            string sql = @"SELECT
                                 [OrderDetailedArrangeID],
                                 [OrderDetailedID],
                                 [ProduceTaskID],
                                 [CreateDate],
                                 [CreateUserID],
                                 [DeleteDate],
                                 [DeleteReason],
                                [DeleteUserID]) FROM   SC_OrderDetailedArrange  ";

            return GetList(sql, null);
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        public SC_OrderDetailedArrange GetModel(int ID)
        {
            string sql = @"SELECT  TOP 1  
                        [OrderDetailedArrangeID]
                        ,[OrderDetailedID]
                        ,[ProduceTaskID]
                        ,[CreateDate]
                        ,[CreateUserID]
                        ,[DeleteDate]
                        ,[DeleteReason]
                        ,[DeleteUserID]
                        FROM [SC_OrderDetailedArrange] WHERE OrderDetailedArrangeID=@OrderDetailedArrangeID";
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("OrderDetailedArrangeID", SqlDbType.Int, ID));
            return GetModel(sql, parameters);
        }
        #endregion
        #region 私有函数
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        private int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return _commonDbConneciton.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        private List<SC_OrderDetailedArrange> GetList(string sql, IList<DbParameter> parameters)
        {
            List<SC_OrderDetailedArrange> ls = new List<SC_OrderDetailedArrange>();
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);
            SC_OrderDetailedArrange model;
            while (reader.Read())
            {
                model = new SC_OrderDetailedArrange();
                model = GetEntity(reader);
                ls.Add(model);
            }
            reader.Close();
            return ls;
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        private SC_OrderDetailedArrange GetModel(string sql, IList<DbParameter> parameters)
        {
            SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);
            SC_OrderDetailedArrange model = new SC_OrderDetailedArrange();
            while (reader.Read())
            {
                model = new SC_OrderDetailedArrange();
                model = GetEntity(reader);
            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// Reader查询实体
        /// </summary>
        private SC_OrderDetailedArrange GetEntity(SqlDataReader reader)
        {
            return EntityHelper.GetEntityListByDT<SC_OrderDetailedArrange>(reader);
        }
        #endregion
        #region 扩展
        #endregion
    }
}
