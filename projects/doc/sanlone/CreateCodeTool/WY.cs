using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CreateCodeTool
{
    public static  class WY
    {
        public static bool createsql(string table, string sqltext, string[] col, string FilePath,string DALNameSpace)
        {
            // 文件名称
            //string FileName = className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + ".cs";
            string FileName = table + ".cs";
            FileName = FilePath + FileName;
            //类名称
            //string ClassName = className.Substring(0, 1).ToUpper() + className.Substring(1).ToString();
            string ClassName = table;
            //创建文件流
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);

            //创建读写器
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);


            //执行操作
            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("using System.Linq;");
            sw.WriteLine("using System.Text;");
            sw.WriteLine("using System.Data;");
            sw.WriteLine("using System.Data.SQLite;");
            sw.WriteLine("");
            sw.WriteLine("namespace  " + DALNameSpace + "");
            sw.WriteLine("{");
            sw.WriteLine("    /// <summary>");
            sw.WriteLine("    /// " + ClassName + "");
            sw.WriteLine("    /// </summary>");
            sw.WriteLine("    [Serializable]");
            sw.WriteLine("    public class " + ClassName);
            sw.WriteLine("    {");
            sw.WriteLine("    #region Fields");
            sw.WriteLine(" public static SQLiteConnection conn = new SQLiteConnection(ICS.DBUtility.DbHelperSQLite.connectionStringLibrary);");
            sw.WriteLine(" public static SQLiteCommand selectCMD, insertCMD, updateCMD, deleteCMD;");
            sw.WriteLine(" public static SQLiteDataAdapter sda;");
            sw.WriteLine("    #endregion");
            sw.WriteLine(" public " + ClassName + "() ");
            sw.WriteLine(" { Create(); }");
            sw.WriteLine("    #region Constructor");
            sw.WriteLine("public void Create()");
            sw.WriteLine("  { ");
            sw.WriteLine("  //设置select查询命令 ");
            sw.WriteLine(string.Format("  selectCMD = new SQLiteCommand(@{0}select {1} from {2}{3}, conn);", "\"", sqltext, table, "\""));
            sw.WriteLine("  //设置Insert命令查询命令 ");
            StringBuilder sb = new StringBuilder();
            foreach (string var in col)
            {
                sb.Append("@" + var + ",");
            }
            //sb = sb.ToString().Substring(sb.ToString().Length - 1, 1);
            sw.WriteLine(string.Format("  insertCMD = new SQLiteCommand(@{0}insert into{1}({2} )values({3}){4}, conn);", "\"", table, sqltext, sb.ToString().Substring(0, sb.ToString().Length - 1), "\""));
            sw.WriteLine("  //设置Update命令 ");
            sb = new StringBuilder();
            foreach (string var in col)
            {
                sb.Append(var + "=@" + var + ",");
            }
            //sb = sb.ToString().Substring(sb.ToString().Length - 1, 1);
            sw.WriteLine(string.Format("  updateCMD = new SQLiteCommand(@{0}update {1} set {2}{3} , conn);", "\"", table, sb.ToString().Substring(0, sb.ToString().Length - 1), "\""));
            sw.WriteLine("  //设置Delete命令 ");
            sw.WriteLine(string.Format("  deleteCMD = new SQLiteCommand(@{0}delete from {1} where id=@id{2}, conn);", "\"", table, "\""));
            //构造sql参数
            StringBuilder inserpara = new StringBuilder(); StringBuilder updatepara = new StringBuilder(); StringBuilder deletepara = new StringBuilder();
            string strIN = string.Empty;
            string strUP = string.Empty;
            string strDE = string.Empty;
            foreach (string var in col)
            {
                strIN = var + "_IN"; strUP = var + "_UP"; strDE = var + "_DE";
                sw.WriteLine(" SQLiteParameter " + strIN + " ;");
                sw.WriteLine(" SQLiteParameter " + strUP + " ;");
                sw.WriteLine(" SQLiteParameter " + strDE + " ;");

                sw.WriteLine(string.Format("{0} = new SQLiteParameter(\"@{0}\",\"{1}\");", strIN, var, var));
                sw.WriteLine(string.Format("{0} = new SQLiteParameter(\"@{0}\",\"{1}\");", strUP, var, var));
                sw.WriteLine(string.Format("{0} = new SQLiteParameter(\"@{0}\",\"{1}\");", strDE, var, var));
                sw.WriteLine("//指定SourceVersion确定参数值是列的当前值(Current)，还是原始值(Original)，还是建议值(Proposed)");
                sw.WriteLine(" " + strIN + ".SourceVersion = DataRowVersion.Current;");
                sw.WriteLine(" " + strUP + ".SourceVersion = DataRowVersion.Current;");
                sw.WriteLine(" " + strDE + ".SourceVersion = DataRowVersion.Current;");

                inserpara.Append(strIN + ",");
                updatepara.Append(strUP + ",");
                deletepara.Append(strDE + ",");
            }
            sw.WriteLine("  insertCMD.Parameters.AddRange(new SQLiteParameter[] { " + inserpara.ToString().Substring(0, inserpara.ToString().Length - 1) + " }); ");
            sw.WriteLine("  updateCMD.Parameters.AddRange(new SQLiteParameter[] { " + updatepara.ToString().Substring(0, updatepara.ToString().Length - 1) + " }); ");
            sw.WriteLine("  deleteCMD.Parameters.AddRange(new SQLiteParameter[] { " + deletepara.ToString().Substring(0, deletepara.ToString().Length - 1) + " }); ");

            sw.WriteLine("  } ");
            sw.WriteLine("  /// <summary> ");
            sw.WriteLine("  /// 获取数据源 ");
            sw.WriteLine("  /// <summary> ");
            sw.WriteLine("  public DataSet GetDataSource(string where) ");
            sw.WriteLine("  { ");
            sw.WriteLine("   DataSet ds = new DataSet(); ");
            sw.WriteLine("   SQLiteCommandBuilder scb = new SQLiteCommandBuilder(sda); ");
            sw.WriteLine("    if (!string.IsNullOrEmpty(where)) ");
            sw.WriteLine("    { selectCMD.CommandText += \" where \" + where; } ");
            sw.WriteLine("   sda = new SQLiteDataAdapter(selectCMD); ");
            sw.WriteLine("   sda.Fill(ds); ");
            sw.WriteLine("   return ds; ");
            sw.WriteLine("  } ");
            sw.WriteLine("  /// <summary> ");
            sw.WriteLine("  /// 更新数据源 ");
            sw.WriteLine("  /// <summary> ");
            sw.WriteLine(" public bool UpDate(DataSet ds) ");
            sw.WriteLine("  { ");
            sw.WriteLine("   if (conn.State != ConnectionState.Open) ");
            sw.WriteLine("    conn.Open(); ");
            sw.WriteLine("    SQLiteCommandBuilder scb = new SQLiteCommandBuilder(sda); ");
            sw.WriteLine("    sda.InsertCommand = scb.GetInsertCommand(); ");
            sw.WriteLine("    sda.UpdateCommand = scb.GetUpdateCommand(); ");
            sw.WriteLine("    sda.DeleteCommand = scb.GetDeleteCommand(); ");
            sw.WriteLine("    SQLiteTransaction tx = conn.BeginTransaction(); ");
            sw.WriteLine("    sda.UpdateCommand.Transaction = tx; ");
            sw.WriteLine("    sda.InsertCommand.Transaction = tx; ");
            sw.WriteLine("    sda.DeleteCommand.Transaction = tx; ");
            sw.WriteLine("    try ");
            sw.WriteLine("    { ");
            sw.WriteLine("    sda.Update(ds.GetChanges()); ");
            sw.WriteLine("    tx.Commit(); ");
            sw.WriteLine("    return true; ");
            sw.WriteLine("    } ");
            sw.WriteLine("     catch (System.Data.SQLite.SQLiteException E) ");
            sw.WriteLine("     { ");
            sw.WriteLine("    tx.Rollback(); ");
            sw.WriteLine("    return false; ");
            sw.WriteLine("    } ");
            sw.WriteLine("   } ");
            sw.WriteLine("    #endregion");
            sw.WriteLine("    }");
            sw.WriteLine("}");
            //关闭写入器
            sw.Close();

            //关闭文件流
            fs.Close();

            return true;
        }
    }
}
