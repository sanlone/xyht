using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace CreateCodeTool
{
    public static  class CreateEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        public static void PrintLine(string className, string FilePath, string EntityNameSpace)
        {
            Dictionary<string, string> list = Print(className);
            try
            {

                //文件名称
                string FileName = className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + ".cs";
                FileName = FilePath + FileName;
                //类名称
                string ClassName = className.Substring(0, 1).ToUpper() + className.Substring(1).ToString();
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
                sw.WriteLine("namespace  " + EntityNameSpace + "");
                sw.WriteLine("{");
                sw.WriteLine("    /// <summary>");
                sw.WriteLine("    /// " + ClassName + "");
                sw.WriteLine("    /// </summary>");
                sw.WriteLine("    [Serializable]");
                sw.WriteLine("    public class " + ClassName);
                sw.WriteLine("    {");
                foreach (string dd in list.Keys)
                {
                    sw.WriteLine("       private " + list[dd] + " " + dd + ";");
                    sw.WriteLine("");
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

                //this.label1.Text = "生成成功！~!~";
            }
            catch (Exception ex)
            {
               // this.label1.Text = ex.Message;
            }
        }
        /// <summary>
        /// 这个方法是把表中所有的字段进行封装
        /// </summary>
        /// <param name="list"></param>
        /// <param name="classname"></param>
        public static Dictionary<string, string> Print(string classname)
        {
            Dictionary<string, string> list = GetMethod(classname);
            Dictionary<string, string> wanz = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(str);
            string sql = "use " + this.cmbDBName.Text + "  ; EXEC sp_columns '" + Comm.project.DALNameSpace + "'";
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
                this.label1.Text = "已成功的得到该数据库下的所有表！！";
            }
            catch (Exception ex)
            {
                this.label1.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return wanz;
        }
    }
}
