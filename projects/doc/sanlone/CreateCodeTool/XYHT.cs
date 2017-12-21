using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace CreateCodeTool
{
    /// <summary>
    /// 向阳航天
    /// </summary>
    public static class XYHT
    {
        #region 生成实体
        /// <summary>
        /// 生成实体层
        /// </summary>
        /// <param name="tableName"></param>
        public static void CreateModel(string _tableName)
        {
            Dictionary<string, string> list = TableObject.Print(_tableName);
            try
            {
                //文件名称
                string FileName = _tableName.Substring(0, 1).ToUpper() + _tableName.Substring(1).ToString() + ".cs";
                string DirName = Comm.FilePath + "Entity\\";
                if (!Directory.Exists(DirName))
                { Directory.CreateDirectory(DirName); }
                FileName = DirName + FileName;
                //类名称
                string tableName = _tableName.Substring(0, 1).ToUpper() + _tableName.Substring(1).ToString();
                //创建文件流
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                //创建读写器
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                //执行操作
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("");
                sw.WriteLine("namespace  " + Comm.project.EntityNameSpace + "");
                sw.WriteLine("{");
                sw.WriteLine("    /// <summary>");
                sw.WriteLine("    /// " + tableName + "");
                sw.WriteLine("    /// </summary>");
                sw.WriteLine("    [Serializable]");
                sw.WriteLine("    public class " + tableName);
                sw.WriteLine("    {");
                //此处定义变量
                foreach (string dd in list.Keys)
                {
                    sw.WriteLine("       private " + list[dd] + " " + dd + ";");
                }
                sw.WriteLine("");
                sw.WriteLine("");
                //此处定义属性
                foreach (string dd in list.Keys)
                {
                    sw.WriteLine("       /// <summary>");
                    sw.WriteLine("       /// " + dd.Substring(0, 1).ToUpper() + dd.Substring(1).ToString() + "");
                    sw.WriteLine("       /// </summary>");
                    sw.WriteLine("       public " + list[dd] + " " + dd.Substring(0, 1).ToUpper() + dd.Substring(1).ToString() + "");
                    sw.WriteLine("         {");
                    sw.WriteLine("           get { return " + dd + "; }");
                    sw.WriteLine("           set { " + dd + " = value; }");
                    sw.WriteLine("         }");
                }
                sw.WriteLine("    }");
                sw.WriteLine("}");
                //关闭写入器
                sw.Close();
                //关闭文件流
                fs.Close();
                Comm.msg = "生成成功！~!~";
            }
            catch (Exception ex)
            {
                Comm.msg = ex.Message;
            }
        }
        #endregion

        #region 生成数据层(DAL)
        public static void CreateDAL(string tableName)
        {
            Dictionary<string, string> list = TableObject.GetMethod(tableName);
            Dictionary<string, string> field = TableObject.Getfield(tableName);
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                //string sql = "use " + Comm.project.DBName + "  ; select [name] from syscolumns where id=object_id(N'" + tableName + "') and COLUMNPROPERTY(id,name,'IsIdentity')=1";
                string sql = @"use {0} ;  SELECT a.name  
  FROM   syscolumns a  
  inner  join sysobjects d on a.id=d.id        
  where  d.name=N'{1}' and exists(SELECT 1 FROM sysobjects where xtype='PK' and  parent_obj=a.id and name in (   
  SELECT name  FROM sysindexes   WHERE indid in(   
  SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid   
  )))";

                sql = string.Format(sql, Comm.project.DBName,tableName);
                SqlCommand command = new SqlCommand(sql, conn);
                string id = (string)command.ExecuteScalar();
                string tmp = string.Empty;
                int i = 0;
                if (id != null)
                {
                    //文件名称
                    string ModelName = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString();
                    string ClassName = ModelName + Comm.Sys_DAL;
                    string FileName = ClassName + ".cs";
                    string DirName = Comm.FilePath + "DAL\\";
                    if (!Directory.Exists(DirName))
                    { Directory.CreateDirectory(DirName); }
                    FileName = DirName + FileName;
                    //创建文件流
                    FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    //创建读写器
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    //开始执行操作
                    //===============================命名空间==================================
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using System.Data.Common;");
                    sw.WriteLine("using System.Data.SqlClient;");
                    sw.WriteLine("using System.Data;");
                    sw.WriteLine(string.Format("using {0};", Comm.project.EntityNameSpace));
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + Comm.project.DALNameSpace + "");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class " + ClassName);
                    sw.WriteLine("    {");
                    //===============================私有字段==================================
                    sw.WriteLine("        #region 私有字段");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 数据库连接对象");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   private CommonDbConneciton _commonDbConneciton;");
                    sw.WriteLine("        #endregion");
                    //===============================构造函数==================================
                    sw.WriteLine("        #region 构造函数");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 构造函数");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public " + ClassName + "()");
                    sw.WriteLine("  {");
                    sw.WriteLine("  //初始化通用连接库");
                    sw.WriteLine("  _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);");
                    sw.WriteLine("  }");
                    sw.WriteLine("        #endregion");
                    //===============================接口函数==================================
                    //==添加实体
                    sw.WriteLine("        #region 接口函数");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 添加实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public int AddModel(" + ModelName + " model)");
                    sw.WriteLine("  {");
                    sw.WriteLine(" string sql = string.Empty;");
                    sw.WriteLine(" sql =@\"INSERT INTO [" + ModelName + "](");
                    SqlDataReader reader = TableObject.GetReader(tableName);

                    string tmpName = "";
                    while (reader.Read())
                    {
                        tmpName = reader["COLUMN_NAME"].ToString();
                        tmpName = ",[" + tmpName.Substring(0, 1).ToUpper() + tmpName.Substring(1) + "]";
                        if (i == 0)
                            tmpName = tmpName.Substring(1);
                        sw.WriteLine("                        " + tmpName);
                        i++;
                    }
                    sw.WriteLine("                        )VALUES(");
                    i = 0;
                    reader = TableObject.GetReader(tableName);
                    while (reader.Read())
                    {
                        tmpName = reader["COLUMN_NAME"].ToString();
                        tmpName = ",@" + tmpName.Substring(0, 1).ToUpper() + tmpName.Substring(1);
                        if (i == 0)
                            tmpName = tmpName.Substring(1);
                        sw.WriteLine("                        " + tmpName);
                        i++;
                    }
                    sw.WriteLine(@"                        )""" + ";");
                    sw.WriteLine(" IList<DbParameter> parameters = new List<DbParameter>(); ");
                    reader = TableObject.GetReader(tableName);
                    while (reader.Read())
                    {
                        tmp = "     parameters.Add(_commonDbConneciton.CreateSqlParameter(\"@{0}\", SqlDbType.{1}, model.{2}));";
                        tmpName = reader["COLUMN_NAME"].ToString();
                        tmpName = tmpName.Substring(0, 1).ToUpper() + tmpName.Substring(1);
                        tmp = string.Format(tmp, tmpName, TableObject.getSysType(reader["TYPE_NAME"].ToString()), tmpName);
                        sw.WriteLine(tmp);
                    }
                    reader = null;
                    sw.WriteLine("     return ExecuteNonQuery(sql, parameters);");
                    sw.WriteLine("  }");
                    //==修改实体
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 修改实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public int EditModel(" + ModelName + " model)");
                    sw.WriteLine("  {");
                    sw.WriteLine("   StringBuilder sql = new StringBuilder();");
                    sw.WriteLine("   IList<DbParameter> parameters = new List<DbParameter>();");
                    tmp = @"     sql.AppendFormat(""UPDATE [{0}] SET "");";
                    sw.WriteLine(string.Format(tmp, ModelName));
                    reader = TableObject.GetReader(tableName);
                    i = 0;
                    tmpName = "";
                    while (reader.Read())
                    {
                        tmp = @"sql.AppendFormat(""{0}[{1}] = @{2} "");";
                        tmpName = reader["COLUMN_NAME"].ToString();
                        if (i == 0)
                        {
                            sw.WriteLine("     " + string.Format(tmp, "", tmpName, tmpName));
                        }
                        else
                        {
                            sw.WriteLine("     " + string.Format(tmp, ",", tmpName, tmpName));
                        }
                        i++;
                    }
                    sw.WriteLine(string.Format(@"     sql.AppendFormat(""WHERE [{0}] = @{1} "");", id, id));
                    reader = TableObject.GetReader(tableName);
                    while (reader.Read())
                    {
                        tmp = "     parameters.Add(_commonDbConneciton.CreateSqlParameter(\"@{0}\", SqlDbType.{1}, model.{2}));";
                        tmpName = reader["COLUMN_NAME"].ToString();
                        tmpName = tmpName.Substring(0, 1).ToUpper() + tmpName.Substring(1);
                        tmp = string.Format(tmp, tmpName, TableObject.getSysType(reader["TYPE_NAME"].ToString()), tmpName);
                        sw.WriteLine(tmp);
                    }
                    sw.WriteLine("     return ExecuteNonQuery(sql.ToString(), parameters);");
                    sw.WriteLine("  }");
                    //==删除实体
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 删除实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public int DeleteModel(int id)");
                    sw.WriteLine("  {");
                    sw.WriteLine(string.Format(@"   string sql = ""DELETE [{0}] WHERE [{1}] = @{2}"";", ModelName, id, id));
                    sw.WriteLine("  IList<DbParameter> parameters = new List<DbParameter>();");
                    sw.WriteLine(string.Format(@"  parameters.Add(_commonDbConneciton.CreateSqlParameter(""@{0}"", SqlDbType.Int, id));", id));
                    sw.WriteLine("  return ExecuteNonQuery(sql, parameters);");
                    sw.WriteLine("  }");
                    //==查询实体List
                    DataTable dt = TableObject.GetTable(tableName);
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public List<" + ModelName + "> GetModel()");
                    sw.WriteLine("  {");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(string.Format("string sql =@\"SELECT"+ System.Environment.NewLine));
                    string tmpColName = string.Empty;
                    i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        tmpColName = row["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + row["COLUMN_NAME"].ToString().Substring(1);
                        if (i == dt.Rows.Count - 1)
                            sb.Append(string.Format("                                 [{0}]) FROM   {1}  \";" + System.Environment.NewLine, tmpColName, ModelName).Substring(1));
                        else
                            sb.Append(string.Format("                                 [{0}]," + System.Environment.NewLine, tmpColName));
                        i++;
                    }
                    sw.WriteLine(sb.ToString());
                    sw.WriteLine("  return GetList(sql, null);");
                    sw.WriteLine("  }");
                    //==查询实体单个
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public " + ModelName + " GetModel(int ID)");
                    sw.WriteLine("  {");
                    sw.WriteLine(" string sql =@\"SELECT  TOP 1  ");
                     tmpName = "";
                    i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        tmpName = row["COLUMN_NAME"].ToString();
                        tmpName = ",[" + tmpName.Substring(0, 1).ToUpper() + tmpName.Substring(1) + "]";
                        if (i == 0)
                            tmpName = tmpName.Substring(1);
                        sw.WriteLine("                        " + tmpName);
                        i++;
                    }
                    sw.WriteLine(string.Format("                        FROM [{0}] WHERE {1}=@{2}\";", ModelName, id, id));
                    sw.WriteLine("   IList<DbParameter> parameters = new List<DbParameter>();");
                    sw.WriteLine(string.Format("parameters.Add(_commonDbConneciton.CreateSqlParameter(\"{0}\", SqlDbType.{1}, {2}));",id,"Int","ID"));
                    sw.WriteLine("  return GetModel(sql, parameters);");
                    sw.WriteLine("  }");
                    sw.WriteLine("        #endregion");
                    //===============================私有函数==================================

                    sw.WriteLine("        #region 私有函数");
                    //执行SQL语句
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 执行SQL语句");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("private int ExecuteNonQuery(string sql, IList<DbParameter> parameters)");
                    sw.WriteLine("{");
                    sw.WriteLine("return _commonDbConneciton.ExecuteNonQuery(sql, parameters);");
                    sw.WriteLine("}");
                    //查询实体List集合
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   private List<" + ModelName + "> GetList(string sql, IList<DbParameter> parameters)");
                    sw.WriteLine("  {");
                    sw.WriteLine(string.Format("  List<{0}> ls = new List<{1}>();",ModelName,ModelName));
                    sw.WriteLine("  SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);");
                    sw.WriteLine(string.Format("  {0} model;", ModelName));
                    sw.WriteLine("    while (reader.Read())");
                    sw.WriteLine("      {");
                    sw.WriteLine(string.Format("         model = new {0}();", ModelName));
                    sw.WriteLine("         model = GetEntity(reader);");
                    sw.WriteLine("         ls.Add(model);");
                    sw.WriteLine("      }");
                    sw.WriteLine("  reader.Close();");
                    sw.WriteLine("  return ls;");
                    sw.WriteLine("  }");
                    // //查询实体【单个】
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   private " + ModelName + " GetModel(string sql, IList<DbParameter> parameters)");
                    sw.WriteLine("  {");
                    sw.WriteLine("  SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);");
                    sw.WriteLine(string.Format("  {0} model = new {1}();", ModelName, ModelName));
                    sw.WriteLine("    while (reader.Read())");
                    sw.WriteLine("      {");
                    sw.WriteLine(string.Format("         model = new {0}();", ModelName));
                    sw.WriteLine("         model = GetEntity(reader);");
                    sw.WriteLine("      }");
                    sw.WriteLine("  reader.Close();");
                    sw.WriteLine("  return model;");
                    sw.WriteLine("  }");
                    //reader转实体
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// Reader查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   private " + ModelName + " GetEntity(SqlDataReader reader)");
                    sw.WriteLine("  {");
                    sw.WriteLine(string.Format("    return EntityHelper.GetEntityListByDT<{0}>(reader);",ModelName));
                    sw.WriteLine("  }");
                    sw.WriteLine("        #endregion");
                    //===============================扩展函数==================================
                    sw.WriteLine("        #region 扩展");
                    sw.WriteLine("        #endregion");
                    sw.WriteLine("   }");
                    sw.WriteLine("  }");
                    //关闭写入器
                    sw.Close();
                    //关闭文件流
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                // throw;
            }
        }
        #endregion

        #region 生成业务层(BLL)
        /// <summary>
        /// 生成业务层
        /// </summary>
        /// <param name="tableName"></param>
        public static void CreateBLL(string tableName)
        {
            Dictionary<string, string> list = TableObject.GetMethod(tableName);
            Dictionary<string, string> field = TableObject.Getfield(tableName);
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            StringBuilder sb = new StringBuilder();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                //string sql = "use " + Comm.project.DBName + "  ; select [name] from syscolumns where id=object_id(N'" + tableName + "') and COLUMNPROPERTY(id,name,'IsIdentity')=1";
                string sql = @"use {0} ;  SELECT a.name  
  FROM   syscolumns a  
  inner  join sysobjects d on a.id=d.id        
  where  d.name=N'{1}' and exists(SELECT 1 FROM sysobjects where xtype='PK' and  parent_obj=a.id and name in (   
  SELECT name  FROM sysindexes   WHERE indid in(   
  SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid   
  )))";
                sql = string.Format(sql, Comm.project.DBName, tableName);
                SqlCommand command = new SqlCommand(sql, conn);
                string id = (string)command.ExecuteScalar();
                string tmp = string.Empty;
                int i = 0;
                //文件名称
                string ModelName = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString();
                string ClassName = ModelName + Comm.Sys_BLL;
                string FileName = ClassName + ".cs";
                string DirName = Comm.FilePath + Comm.Sys_BLL + "\\";
                if (!Directory.Exists(DirName))
                { Directory.CreateDirectory(DirName); }
                FileName = DirName + FileName;
                //创建文件流
                FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                //创建读写器
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                //开始执行操作
                //===============================命名空间==================================
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("using System.Data.Common;");
                sw.WriteLine("using System.Data.SqlClient;");
                sw.WriteLine("using System.Data;");
                sw.WriteLine("using System.Data;");
                sw.WriteLine(string.Format("using {0};", Comm.project.EntityNameSpace));
                sw.WriteLine(string.Format("using {0};", Comm.project.DALNameSpace));
                sw.WriteLine("");
                sw.WriteLine("namespace " + Comm.project.BLLNameSpace + "");
                sw.WriteLine("{");
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// 业务类");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("    public class " + ClassName);
                sw.WriteLine("    {");
                //===============================私有字段==================================
                string dal = ModelName + Comm.Sys_DAL;
                 dal = "_" + ModelName.Substring(0, 1).ToLower() + ModelName.Substring(1).ToString()+Comm.Sys_DAL;
                 sw.WriteLine("        #region 私有字段");
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// 数据库訪問对象");
                sw.WriteLine("/// </summary>");//
                sw.WriteLine(string.Format("   private {0} {1} = null;", ModelName + Comm.Sys_DAL,dal));
                sw.WriteLine("        #endregion");
                //===============================构造函数==================================
                sw.WriteLine("        #region 构造函数");
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// ");
                sw.WriteLine("/// </summary>");//
                sw.WriteLine(string.Format("public {0}()", ClassName));
                sw.WriteLine("  {");
                sw.WriteLine(string.Format("{0} = new {1}();", dal, ModelName + Comm.Sys_DAL));
                sw.WriteLine("  }");
                sw.WriteLine("        #endregion");
                //===============================对外接口==================================
                //增加
                sw.WriteLine("        #region 对外接口");
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// 增加");
                sw.WriteLine("/// </summary>");//
                sw.WriteLine(string.Format("public  int AddModel({0} model)", ModelName));
                sw.WriteLine("  {");
                sw.WriteLine("    try");
                sw.WriteLine("    {");
                sw.WriteLine(string.Format("return {0}.AddModel(model);", dal));
                sw.WriteLine("    }");
                sw.WriteLine("    catch");
                sw.WriteLine("    {");
                sw.WriteLine("      return -1;");
                sw.WriteLine("    }");
                sw.WriteLine("  }");
                //修改
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// 修改");
                sw.WriteLine("/// </summary>");//
                sw.WriteLine(string.Format("public  int EditModel({0} model)", ModelName));
                sw.WriteLine("  {");
                sw.WriteLine("    try");
                sw.WriteLine("    {");
                sw.WriteLine(string.Format("return {0}.EditModel(model);", dal));
                sw.WriteLine("    }");
                sw.WriteLine("    catch");
                sw.WriteLine("    {");
                sw.WriteLine("      return -1;");
                sw.WriteLine("    }");
                sw.WriteLine("  }");
                //删除
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// 删除");
                sw.WriteLine("/// </summary>");//
                sw.WriteLine(string.Format("public  int DelteModel(int ID)"));
                sw.WriteLine("  {");
                sw.WriteLine("    try");
                sw.WriteLine("    {");
                sw.WriteLine(string.Format("return {0}.DeleteModel(ID);", dal));
                sw.WriteLine("    }");
                sw.WriteLine("    catch");
                sw.WriteLine("    {");
                sw.WriteLine("      return -1;");
                sw.WriteLine("    }");
                sw.WriteLine("  }");
                //////获取实体集合
                sw.WriteLine(string.Format("public  {0} GetModel(int ID)", ModelName));
                sw.WriteLine("  {");
                sw.WriteLine("    try");
                sw.WriteLine("    {");
                sw.WriteLine(string.Format("return {0}.GetModel(ID);", dal));
                sw.WriteLine("    }");
                sw.WriteLine("    catch");
                sw.WriteLine("    {");
                sw.WriteLine("      return null;");
                sw.WriteLine("    }");
                sw.WriteLine("  }");
                sw.WriteLine("        #endregion");
                //===============================私有函数==================================
                sw.WriteLine("        #region 私有函数");
                sw.WriteLine("        #endregion");
                //===============================结束==================================
                sw.WriteLine("    }");
                sw.WriteLine(" }");
                //关闭写入器
                sw.Close();
                //关闭文件流
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

     

    }
}
