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
        #region ˽���ֶ�
        /// <summary>
        /// ���ݿ����Ӷ���
        /// </summary>
        private CommonDbConneciton _commonDbConneciton;
        #endregion
        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public SC_OrderDetailedArrangeDao()
        {
            //��ʼ��ͨ�����ӿ�
            _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);
        }
        #endregion
        #region �ӿں���
        /// <summary>
        /// ���ʵ��
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
        /// �޸�ʵ��
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
        /// ɾ��ʵ��
        /// </summary>
        public int DeleteModel(int id)
        {
            string sql = "DELETE [SC_OrderDetailedArrange] WHERE [OrderDetailedArrangeID] = @OrderDetailedArrangeID";
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@OrderDetailedArrangeID", SqlDbType.Int, id));
            return ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// ��ѯʵ��
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
        /// ��ѯʵ��
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
        #region ˽�к���
        /// <summary>
        /// ִ��SQL���
        /// </summary>
        private int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return _commonDbConneciton.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// ��ѯʵ��
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
        /// ��ѯʵ��
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
        /// Reader��ѯʵ��
        /// </summary>
        private SC_OrderDetailedArrange GetEntity(SqlDataReader reader)
        {
            return EntityHelper.GetEntityListByDT<SC_OrderDetailedArrange>(reader);
        }
        #endregion
        #region ��չ
        #endregion
    }
}
