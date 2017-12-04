using System;
using System.Collections.Generic;
using System.Text;
using NWR.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace NWR.DAL.QX
{
    /// <summary>
    /// ��ɫȨ�ޱ�ͨѶ��
    /// </summary>
    public class RolePermissionsDao
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
        public RolePermissionsDao()
        {
            //��ʼ��ͨ�����ӿ�
            _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);
        }

        #endregion

        #region �ӿں���

        /// <summary>
        /// ���ģ��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddModel(RoleMenus model)
        {
            string sql = string.Empty;

            sql = "INSERT INTO [QX_RolePermissions] ([RoleID],[PermissionList],[Description]) "
                + "VALUES (@RoleID, @PermissionList, @Description)";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@PermissionList", SqlDbType.NText, model.MenuList));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.Text, 200, model.Description));

            return ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// �޸�ģ��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditModel(RoleMenus model)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("UPDATE [QX_RolePermissions] SET ");
            sql.AppendFormat("[RoleID] = @RoleID, ");
            sql.AppendFormat("[PermissionList] = @PermissionList, ");
            sql.AppendFormat("[Description] = @Description ");
            sql.AppendFormat("WHERE [RolePermissionID] = @RolePermissionID ");

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RoleID", SqlDbType.Int, model.RoleID));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@PermissionList", SqlDbType.NText, model.MenuList));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@Description", SqlDbType.Text, 200, model.Description));
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RolePermissionID", SqlDbType.Int, model.RoleMenuID));

            return ExecuteNonQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��ģ��
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public int DeleteModel(int rolePermissionID)
        {
            string sql = "DELETE [QX_RolePermissions] WHERE [RolePermissionID] = @RolePermissionID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RolePermissionID", SqlDbType.Int, rolePermissionID));

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// ��ѯģ���б�
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<RoleMenus> GetModel()
        {
            string sql = "SELECT [RolePermissionID],[RoleID],[PermissionList],[Description] FROM [QX_RolePermissions]";
            return GetList(sql, null);
        }
        /// <summary>
        /// ��ѯģ��ʵ��
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public RoleMenus GetModel(int rolePermissionID)
        {
            string sql = "SELECT TOP 1 [RolePermissionID],[RoleID],[PermissionList],[Description] FROM [QX_RolePermissions] WHERE RolePermissionID = @RolePermissionID";

            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(_commonDbConneciton.CreateSqlParameter("@RolePermissionID", SqlDbType.Int, rolePermissionID));

            return GetModel(sql, parameters);
        }
        /// <summary>
        /// ��ѯģ���б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable()
        {
            string sql = "SELECT [RolePermissionID],[RoleID],[PermissionList],[Description] FROM [QX_RolePermissions]";
            return _commonDbConneciton.ExecuteDataTable(sql, null);
        }

        #endregion

        #region ˽�к���

        /// <summary>
        /// ִ��SQL���
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private int ExecuteNonQuery(string sql, IList<DbParameter> parameters)
        {
            return _commonDbConneciton.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// ��ѯģ���б�
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
                GetRolePermissions(reader, ref model);
                ls.Add(model);
            }

            reader.Close();

            return ls;
        }

        /// <summary>
        /// ��ѯģ���б�
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
                GetRolePermissions(reader, ref model);
            }

            reader.Close();

            return model;
        }

        /// <summary>
        /// ��ȡRolePermissionsʵ��
        /// </summary>
        /// <param name="model"></param>
        /// <param name="reader"></param>
        private void GetRolePermissions(SqlDataReader reader, ref RoleMenus model)
        {
            model.RoleMenuID = Convert.ToInt32(reader["RolePermissionID"]);
            model.RoleID = Convert.ToInt32(reader["RoleID"]);
            model.MenuList = Convert.ToString(reader["PermissionList"]);
            model.Description = Convert.ToString(reader["Description"]);
        }

        #endregion

    }
}
