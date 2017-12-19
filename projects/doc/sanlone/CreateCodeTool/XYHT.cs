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
                sw.WriteLine("using System.Linq;");
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
        public static void CreateDAL(string tableName)
        {
            Dictionary<string, string> list = TableObject.GetMethod(tableName);
            Dictionary<string, string> field = TableObject.Getfield(tableName);
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                string sql = "use " + Comm.project.DBName + "  ; select [name] from syscolumns where id=object_id(N'" + tableName + "') and COLUMNPROPERTY(id,name,'IsIdentity')=1";
                SqlCommand command = new SqlCommand(sql, conn);
                string id = (string)command.ExecuteScalar();
                if (id != null)
                {
                    //文件名称
                    int i = 0;
                    string ModelName = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString();
                    string ClassName = ModelName + "Dao";
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
                    sw.WriteLine("using System.Data;");
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + Comm.project.DALNameSpace + "");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "Dao");
                    sw.WriteLine("    {");
                    //===============================私有字段==================================
                    sw.WriteLine("#region 私有字段");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 数据库连接对象");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   private CommonDbConneciton _commonDbConneciton;");
                    sw.WriteLine("#endregion");
                    //===============================构造函数==================================
                    sw.WriteLine("#region 构造函数");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 构造函数");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public " + ClassName + "()");
                    sw.WriteLine("  {");
                    sw.WriteLine("  //初始化通用连接库");
                    sw.WriteLine("  _commonDbConneciton = new CommonDbConneciton(CommonClass.ConnectionString);");
                    sw.WriteLine("  }");
                    sw.WriteLine("#endregion");
                    //===============================接口函数==================================
                    sw.WriteLine("#region 接口函数");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 添加实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public int AddModel(" + ModelName + " model)");
                    sw.WriteLine("  {");
                    sw.WriteLine(" string sql = string.Empty;");
                    sw.WriteLine(" sql =\"INSERT INTO [" + ModelName + "](");
                    SqlDataReader reader = TableObject.GetReader(tableName);

                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("            " + ModelName + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    sw.WriteLine("            " + ModelName + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            sw.WriteLine("            " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    }
                    reader = null;
                    sw.WriteLine("  }");

                    DataTable dt = TableObject.GetTable(tableName);
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   public List<" + ModelName + "> GetModel()");
                    sw.WriteLine("  {");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(string.Format("string sql = \"SELECT"));
                    string tmpColName = string.Empty;
                    i =0;
                    foreach (DataRow row in dt.Rows)
                    {
                        tmpColName = row["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + row["COLUMN_NAME"].ToString().Substring(1);
                        if (i == dt.Rows.Count-1)
                            sb.Append(string.Format("  [{0}]\") FROM   {1}  "  +System.Environment.NewLine, tmpColName, ModelName).Substring(1));
                        else
                            sb.Append(string.Format("  [{0}]," + System.Environment.NewLine, tmpColName));
                        i++;
                    }
                    sw.WriteLine(sb.ToString());
                    sw.WriteLine("  return GetList(sql, null);");
                    sw.WriteLine("  }");
                    sw.WriteLine("#endregion");
                    //===============================私有函数==================================
                    sw.WriteLine("#region 私有函数");
                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 查询实体");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("   private List<" + ModelName + "> GetList(string sql, IList<DbParameter> parameters)");
                    sw.WriteLine("  {");
                    sw.WriteLine("  List<Roles> ls = new List<Roles>();");
                    sw.WriteLine("  SqlDataReader reader = (SqlDataReader)_commonDbConneciton.ExecuteReader(sql, parameters);");
                    sw.WriteLine(string.Format("  {0} model;",ModelName));
                    sw.WriteLine("    while (reader.Read())");
                    sw.WriteLine("      {");
                    sw.WriteLine(string.Format("         model = new {0}();",ModelName));
                    sw.WriteLine("         model = GetUsers(reader);");
                    sw.WriteLine("      }");
                    sw.WriteLine("  reader.Close();");
                    sw.WriteLine("  return ls;");
                    sw.WriteLine("  }");
                    sw.WriteLine("#endregion");
                    //===============================扩展函数==================================
                    sw.WriteLine("#region 扩展函数");

                    sw.WriteLine("#endregion");
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
        /// <summary>
        /// 生成DAL层
        /// </summary>
        /// <param name="tableName"></param>
        public static void CreateDALEx(string tableName)
        {
            Dictionary<string, string> list = TableObject.GetMethod(tableName);
            Dictionary<string, string> field = TableObject.Getfield(tableName);
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                string sql = "use " + Comm.project.DBName + "  ; select [name] from syscolumns where id=object_id(N'" + tableName + "') and COLUMNPROPERTY(id,name,'IsIdentity')=1";
                SqlCommand command = new SqlCommand(sql, conn);
                string id = (string)command.ExecuteScalar();
                if (id != null)
                {
                    //文件名称
                    string FileName = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "Dao.cs";
                    string DirName = Comm.FilePath + "Entity\\";
                    if (!Directory.Exists(DirName))
                    { Directory.CreateDirectory(DirName); }
                    FileName = Comm.FilePath + FileName;
                    //创建文件流
                    FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);

                    //创建读写器
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    //执行操作
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using System.Data;");
                    sw.WriteLine("using System.Data.SqlClient;");
                    sw.WriteLine("using " + Comm.project.DALNameSpace + ";");
                    sw.WriteLine("using " + Comm.project.EntityNameSpace + ";");
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + Comm.project.DALNameSpace + "");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "Service");
                    sw.WriteLine("    {");
                    sw.WriteLine("       public  IList<" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "> GetAll" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "()");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + tableName + "\";");
                    sw.WriteLine("           List<" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "> list = new List<" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + ">();");
                    sw.WriteLine("           using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))");
                    sw.WriteLine("           {");
                    sw.WriteLine("              while (dr.Read())");
                    sw.WriteLine("              { list.Add(DataRowToModel(dr));}");
                    sw.WriteLine("           }");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //获取一个实体");
                    sw.WriteLine("       public static " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " DataRowToModel(IDataReader reader)");
                    sw.WriteLine("        {");
                    sw.WriteLine("            " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + " = new " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "();");
                    SqlDataReader reader = TableObject.GetReader(tableName);
                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("            " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(ide + reader["COLUMN_NAME"]);
                                    sw.WriteLine("            " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                                // reader.NextResult();
                                //break;
                            }
                        }
                        else
                        {
                            sw.WriteLine("            " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    } reader = null;
                    //sw.WriteLine("                  list.Add(" + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ");     ");
                    //sw.WriteLine("              }");
                    sw.WriteLine("            return " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ";");
                    sw.WriteLine("        }");


                    sw.WriteLine("       //这是一个查询单个方法");
                    sw.WriteLine("       public static " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " Get" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "One(int " + tableName + id + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + tableName + " where " + id + "=\"+" + tableName + id + ";");
                    sw.WriteLine("           " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + " = new " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "();");
                    sw.WriteLine("           DataTable table = DBHelper.GetDataSet(sql);");

                    sw.WriteLine("            return " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ";");
                    sw.WriteLine("         }");
                    sw.WriteLine("       //这是一个修改的方法");
                    sw.WriteLine("       public void Modify" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "(" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"update " + tableName + " set \"+");
                    reader = TableObject.GetReader(tableName);
                    int i = 0;
                    while (reader.Read())
                    {
                        if (reader["COLUMN_NAME"].ToString() != id)
                        {
                            i++;
                            if (i == 1)
                            {
                                sw.WriteLine("           \"" + reader["COLUMN_NAME"] + "=@" + reader["COLUMN_NAME"] + "\"+");
                            }
                            else
                            {
                                sw.WriteLine("           \"," + reader["COLUMN_NAME"] + "=@" + reader["COLUMN_NAME"] + "\"+");
                            }
                        }
                    }
                    sw.WriteLine("           \" WHERE " + id + " = @" + id + "\";");
                    sw.WriteLine("             SqlParameter[] para = new SqlParameter[]");
                    sw.WriteLine("                {");
                    reader = TableObject.GetReader(tableName);
                    int j = 0;
                    while (reader.Read())
                    {
                        if (reader["COLUMN_NAME"].ToString() != id)
                        {
                            j++;
                            if (field != null && field.Count > 0)
                            {
                                foreach (string ide in field.Keys)
                                {
                                    if (reader["COLUMN_NAME"].Equals(ide))
                                    {
                                        if (j == 1)
                                        {
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if (j == 1)
                                        {
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (j == 1)
                                {
                                    sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                                else
                                {
                                    sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                            }
                        }
                    }
                    sw.WriteLine("                };");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql, para);");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个删除的方法");
                    sw.WriteLine("       public void Delete" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "ById(int " + tableName + id + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"DELETE " + tableName + " WHERE " + id + " = @" + tableName + id + "\";");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql, new SqlParameter(\"@" + tableName + id + "\", " + tableName + id + "));");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个添加的方法");
                    sw.WriteLine("       public void GetInsert(" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"insert into " + tableName + " values(\"+");
                    reader = TableObject.GetReader(tableName);
                    int k = 0;
                    while (reader.Read())
                    {
                        if (reader["COLUMN_NAME"].ToString() != id)
                        {
                            k++;
                            if (k == 1)
                            {
                                sw.WriteLine("              \"@" + reader["COLUMN_NAME"] + "\"+");
                            }
                            else
                            {
                                sw.WriteLine("              \",@" + reader["COLUMN_NAME"] + "\"+");
                            }
                        }

                    }
                    sw.WriteLine("                \");\";");
                    sw.WriteLine("             SqlParameter[] parameter = new SqlParameter[]");
                    sw.WriteLine("                {");
                    reader = TableObject.GetReader(tableName);
                    int m = 0;
                    while (reader.Read())
                    {

                        if (reader["COLUMN_NAME"].ToString() != id)
                        {
                            m++;
                            if (field != null && field.Count > 0)
                            {
                                foreach (string ide in field.Keys)
                                {
                                    if (reader["COLUMN_NAME"].Equals(ide))
                                    {
                                        if (m == 1)
                                        {
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if (m == 1)
                                        {
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (m == 1)
                                {
                                    sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                                else
                                {
                                    sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                            }

                        }
                    }
                    sw.WriteLine("                  };");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql,parameter);");
                    sw.WriteLine("        }");
                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                    //关闭写入器
                    sw.Close();

                    //关闭文件流
                    fs.Close();
                }
                else
                {
                    //创建文件流
                    FileStream fs = new FileStream(tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "Service.cs", FileMode.OpenOrCreate, FileAccess.Write);

                    //创建读写器
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    //执行操作
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using System.Data;");
                    sw.WriteLine("using System.Data.SqlClient;");
                    sw.WriteLine("using " + Comm.project.BLLNameSpace + ";");
                    sw.WriteLine("using " + Comm.project.EntityNameSpace + ";");
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + Comm.project.DALNameSpace + "");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "Service");
                    sw.WriteLine("    {");
                    sw.WriteLine("       public  IList<" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "> GetAll" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "()");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + tableName + "\";");
                    sw.WriteLine("           List<" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "> list = new List<" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + ">();");
                    sw.WriteLine("           DataTable table = DBHelper.GetDataSet(sql);");
                    sw.WriteLine("           foreach (DataRow reader in table.Rows)");
                    sw.WriteLine("              {");
                    sw.WriteLine("                  " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + " = new " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "();");
                    SqlDataReader reader = TableObject.GetReader(tableName);
                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("                  " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(ide + reader["COLUMN_NAME"]);
                                    sw.WriteLine("                  " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                                // reader.NextResult();
                                //break;
                            }
                        }
                        else
                        {
                            sw.WriteLine("                   " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    } reader = null;
                    sw.WriteLine("                  list.Add(" + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ");     ");
                    sw.WriteLine("              }");
                    sw.WriteLine("            return list;");
                    sw.WriteLine("         }");
                    sw.WriteLine("       //这是一个查询单个方法");
                    sw.WriteLine("       public static " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " Get" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "One(string " + tableName + "Name,object " + tableName + "id)");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + tableName + " where \" + " + tableName + "Name + \"=\"+" + tableName + "id ;");
                    sw.WriteLine("           " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + " = new " + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "();");
                    sw.WriteLine("           DataTable table = DBHelper.GetDataSet(sql);");
                    sw.WriteLine("           foreach (DataRow reader in table.Rows)");
                    sw.WriteLine("              {");
                    reader = TableObject.GetReader(tableName);
                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("                  " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(ide + reader["COLUMN_NAME"]);
                                    sw.WriteLine("                  " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                                // reader.NextResult();
                                //break;
                            }
                        }
                        else
                        {
                            sw.WriteLine("                   " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + TableObject.getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    } reader = null;
                    sw.WriteLine("              }");
                    sw.WriteLine("            return " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ";");
                    sw.WriteLine("         }");
                    sw.WriteLine("       //这是一个修改的方法");
                    sw.WriteLine("       public void Modify" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + "(" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ",string " + tableName + "Name,object " + tableName + "id)");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"update " + tableName + " set \"+");
                    reader = TableObject.GetReader(tableName);
                    int i = 0;
                    while (reader.Read())
                    {
                        i++;
                        if (i == 1)
                        {
                            sw.WriteLine("           \"" + reader["COLUMN_NAME"] + "=@" + reader["COLUMN_NAME"] + "\"+");
                        }
                        else
                        {
                            sw.WriteLine("           \"," + reader["COLUMN_NAME"] + "=@" + reader["COLUMN_NAME"] + "\"+");
                        }

                    }
                    sw.WriteLine("           \" WHERE \" + " + tableName + "Name + \"= \"+" + tableName + "id ;");
                    sw.WriteLine("             SqlParameter[] para = new SqlParameter[]");
                    sw.WriteLine("                {");
                    reader = TableObject.GetReader(tableName);
                    int j = 0;
                    while (reader.Read())
                    {
                        j++;
                        if (field != null && field.Count > 0)
                        {
                            foreach (string ide in field.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    if (j == 1)
                                    {
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    break;
                                }
                                else
                                {
                                    if (j == 1)
                                    {
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (j == 1)
                            {
                                sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                            else
                            {
                                sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                        }

                    }
                    sw.WriteLine("                };");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql, para);");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个删除的方法");
                    sw.WriteLine("       public void Delete" + tableName + "ById(string " + tableName + "Name,object " + tableName + "id)");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"DELETE " + tableName + " WHERE \" + " + tableName + "Name + \"= \"+" + tableName + "id ;");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql);");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个添加的方法");
                    sw.WriteLine("       public void GetInsert(" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1).ToString() + " " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"insert into " + tableName + " values(\"+");
                    reader = TableObject.GetReader(tableName);
                    int k = 0;
                    while (reader.Read())
                    {
                        k++;
                        if (k == 1)
                        {
                            sw.WriteLine("              \"@" + reader["COLUMN_NAME"] + "\"+");
                        }
                        else
                        {
                            sw.WriteLine("              \",@" + reader["COLUMN_NAME"] + "\"+");
                        }

                    }
                    sw.WriteLine("                \");\";");
                    sw.WriteLine("             SqlParameter[] parameter = new SqlParameter[]");
                    sw.WriteLine("                {");
                    reader = TableObject.GetReader(tableName);
                    int m = 0;
                    while (reader.Read())
                    {

                        m++;
                        if (field != null && field.Count > 0)
                        {

                            foreach (string ide in field.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    if (m == 1)
                                    {
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    break;
                                }
                                else
                                {
                                    if (m == 1)
                                    {
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (m == 1)
                            {
                                sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                            else
                            {
                                sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + tableName.Substring(0, 1).ToLower() + tableName.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                        }


                    }
                    sw.WriteLine("                  };");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql,parameter);");
                    sw.WriteLine("        }");
                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                    //关闭写入器
                    sw.Close();

                    //关闭文件流
                    fs.Close();
                }
                Comm.msg = "生成成功！！O(∩_∩)O哈哈~";
            }
            catch (Exception ex)
            {
                Comm.msg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        public static void CreateBLL()
        {

        }
    }
}
