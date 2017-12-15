using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CreateCodeTool
{
    public static class TableObject
    {
        /// <summary>
        /// 获取数据表中字段信息--------这个方法是把表中所有的字段进行封装
        /// </summary>
        /// <param name="list"></param>
        /// <param name="classname"></param>
        public static Dictionary<string, string> Print(string tableName)
        {
            Dictionary<string, string> list = GetMethod(tableName);
            Dictionary<string, string> wanz = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            string sql = "use " + Comm.project.DBName + "  ; EXEC sp_columns '" + tableName + "'";
            try
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(sql, conn);
                SqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    if (list != null && list.Count > 0)
                    {
                        foreach (string id in list.Keys)
                        {
                            if (reader["COLUMN_NAME"].Equals(id))
                            {
                                wanz.Add(list[id].ToString().Substring(0, 1).ToLower() + list[id].Substring(1).ToString(), list[id]);
                                break;
                            }
                            else
                            {
                                wanz.Add(reader["COLUMN_NAME"].ToString().Substring(0, 1).ToLower() + reader["COLUMN_NAME"].ToString().Substring(1), getType(reader["TYPE_NAME"].ToString()));
                                break;
                            }
                        }
                    }
                    else
                    {
                        wanz.Add(reader["COLUMN_NAME"].ToString().Substring(0, 1).ToLower() + reader["COLUMN_NAME"].ToString().Substring(1), getType(reader["TYPE_NAME"].ToString()));
                    }
                } reader.Close();
                Comm.msg = "已成功的得到该数据库下的所有表！！";
            }
            catch (Exception ex)
            {
                Comm.msg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return wanz;

        }
        /// <summary>
        /// 这个方法是得到这张表是否有外建存在
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetMethod(string tableName)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                SqlCommand commend = new SqlCommand("use " + Comm.project.DBName + "  ;EXEC sp_fkeys @fktable_name = N'" + tableName + "'", conn);
                SqlDataReader reader = commend.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["FKCOLUMN_NAME"].ToString(), reader["PKTABLE_NAME"].ToString());
                } reader.Close();
            }
            catch (Exception ex)
            {
                Comm.msg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        /// <summary>
        /// 进行类型转换
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string getType(string type)
        {
            switch (type)
            {
                case "varchar":
                case "varbinary":
                case "ntext":
                case "char":
                case "nvarchar":
                case "nchar":
                case "text":
                    return "string";

                case "smallint":
                case "int":
                case "bit":
                case "bigint":
                case "int identity":
                    return "int";

                case "money":
                case "float":
                case "decimal":
                case "numeric":
                case "smallmoney":
                    return "double";

                case "smalldatetime":
                case "datetime":
                case "timestamp":
                    return "DateTime";
            }
            return "string";
        }
        //这个方法是查询出主表的那个字段所对应的
        public static Dictionary<string, string> Getfield(string table)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                SqlCommand commend = new SqlCommand("use " + Comm.project.DBName + "  ;EXEC sp_fkeys @fktable_name = N'" + table + "'", conn);
                SqlDataReader reader = commend.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["FKCOLUMN_NAME"].ToString(), reader["PKTABLE_NAME"].ToString() + "." + reader["PKCOLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["PKCOLUMN_NAME"].ToString().Substring(1));

                } reader.Close();
            }
            catch (Exception ex)
            {
                Comm.msg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classname"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string classname)
        {
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            string sql = "use " + Comm.project.DBName+ "  ; EXEC sp_columns '" + classname + "'";
            try
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(sql, conn);
                SqlDataReader reader = command1.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Comm.msg = ex.Message;
            }
            finally
            {
                //conn.Close();
            }
            return null;
        }
    }
}
