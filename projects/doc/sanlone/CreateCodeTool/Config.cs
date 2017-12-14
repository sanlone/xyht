using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CreateCodeTool
{
    public partial class Config : Form
    {
        #region 变量
        public string connString = "Data Source={0};Initial Catalog=master;User ID={1};password={2}";
        public string FilePath = string.Empty;
        public string EntityNameSpace = "ZM.Entity";
        public string DALNameSpace = "ZM.DAL";
        public string DBNameSpace = "ZM.MSSqlServer";

        
        #endregion

        public Config()
        {
            InitializeComponent();
        }

        #region 窗体事件

        private void Config_Load(object sender, EventArgs e)
        {
            this.cmbSysType.SelectedIndex = 0;
            FilePath = this.txtCreateFilePath.Text.Trim() + @"\";
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            connString = string.Format(connString, txtName.Text.Trim(), txtUser.Text.Trim(), txtPWD.Text.Trim());

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter("Exec sp_helpdb", conn);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                this.cmbDBName.DataSource = ds.Tables[0].DefaultView;
                this.cmbDBName.DisplayMember = "name";
                this.cmbDBName.SelectedIndex = 0;


                MessageBox.Show("连接成功并拿到数据！~！");

            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbDBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkedListBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "use " + this.cmbDBName.Text + "  ; select name from dbo.sysobjects  where xtype='U' and sysstat<200";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    Comm.msg= "(*^__^*) 嘻嘻……数据库里没有表！";
                }
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        this.checkedListBox1.Items.Add(reader[i]);
                    }
                    Comm.msg= "已成功的得到该数据库下的所有表！！";
                } reader.Close();
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox1.SetItemChecked(i, true);
                }
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Comm.project = this.getProEntity();
            if (this.chkselected.Checked)
            {
                if (!this.chkselected.Checked)
                    return;
                if (string.IsNullOrEmpty(this.txtColumnName.Text.Trim()))
                    return;
                if (string.IsNullOrEmpty(this.txtTabelName.Text.Trim()))
                    return;
                string table = this.txtTabelName.Text.Trim();
                string sqltext = this.txtColumnName.Text.Trim();
                string[] col = this.txtColumnName.Text.Trim().Split(',');
                if (WY.createsql(table, sqltext, col, FilePath, DALNameSpace))
                {
                    Comm.msg= "生成成功！~!~";
                }
                else
                {
                    Comm.msg= "生成失败！~!~";
                }
                return;
            }
            this.GetValues();
            try
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    if (this.checkedListBox1.GetItemChecked(i))
                    {
                        //生成实体
                        PrintLine(this.checkedListBox1.Items[i].ToString());
                        //生成DBHelper
                        PrintLine();
                        //生成数据访问层
                        PrintCRUM(this.checkedListBox1.Items[i].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
        }
        private void txtSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();

            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog.SelectedPath;
                // TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
                this.txtCreateFilePath.Text = FileName + @"\";
                FilePath = this.txtCreateFilePath.Text = FileName + @"\";
            }

        }
        #endregion

        #region 方法
        private void GetValues()
        {
            this.EntityNameSpace = this.txtNamespace.Text.Trim();
            this.DALNameSpace = this.txtDALNameSpace.Text.Trim();
            this.DBNameSpace = this.txtDBNameSpace.Text.Trim();
        }
        /// <summary>
        /// 这个方法是得到这张表是否有外间存在
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetMethod(string table)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand commend = new SqlCommand("use " + this.cmbDBName.Text + "  ;EXEC sp_fkeys @fktable_name = N'" + table + "'", conn);
                SqlDataReader reader = commend.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["FKCOLUMN_NAME"].ToString(), reader["PKTABLE_NAME"].ToString());

                } reader.Close();
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        //这个方法是查询出主表的那个字段所对应的
        public Dictionary<string, string> Getfield(string table)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand commend = new SqlCommand("use " + this.cmbDBName.Text + "  ;EXEC sp_fkeys @fktable_name = N'" + table + "'", conn);
                SqlDataReader reader = commend.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["FKCOLUMN_NAME"].ToString(), reader["PKTABLE_NAME"].ToString() + "." + reader["PKCOLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["PKCOLUMN_NAME"].ToString().Substring(1));

                } reader.Close();
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        /// <summary>
        /// 这个方法是把表中所有的字段进行封装
        /// </summary>
        /// <param name="list"></param>
        /// <param name="classname"></param>
        public Dictionary<string, string> Print(string classname)
        {
            Dictionary<string, string> list = GetMethod(classname);
            Dictionary<string, string> wanz = new Dictionary<string, string>();
            SqlConnection conn = new SqlConnection(connString);
            string sql = "use " + this.cmbDBName.Text + "  ; EXEC sp_columns '" + classname + "'";
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
                Comm.msg= "已成功的得到该数据库下的所有表！！";
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return wanz;

        }
        public SqlDataReader GetReader(string classname)
        {
            SqlConnection conn = new SqlConnection(connString);
            string sql = "use " + this.cmbDBName.Text + "  ; EXEC sp_columns '" + classname + "'";
            try
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(sql, conn);
                SqlDataReader reader = command1.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
            finally
            {
                //conn.Close();
            }
            return null;
        }
        /// <summary>
        /// 进行类型转换
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string getType(string type)
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
        public void PrintCRUM(string className)
        {
            Dictionary<string, string> list = GetMethod(className);
            Dictionary<string, string> field = Getfield(className);
            //select [name] from syscolumns where id=object_id(N'你的表名') and COLUMNPROPERTY(id,name,'IsIdentity')=1
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "use " + this.cmbDBName.Text + "  ; select [name] from syscolumns where id=object_id(N'" + className + "') and COLUMNPROPERTY(id,name,'IsIdentity')=1";
                SqlCommand command = new SqlCommand(sql, conn);
                string id = (string)command.ExecuteScalar();
                if (id != null)
                {
                    //文件名称
                    string FileName = className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "DAL.cs";
                    FileName = FilePath + FileName;
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
                    sw.WriteLine("using " + this.DBNameSpace + ";");
                    sw.WriteLine("using " + this.EntityNameSpace + ";");
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + DALNameSpace + "");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "Service");
                    sw.WriteLine("    {");
                    sw.WriteLine("       public  IList<" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "> GetAll" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "()");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + className + "\";");
                    sw.WriteLine("           List<" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "> list = new List<" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + ">();");
                    sw.WriteLine("           using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))");
                    sw.WriteLine("           {");
                    sw.WriteLine("              while (dr.Read())");
                    sw.WriteLine("              { list.Add(DataRowToModel(dr));}");
                    sw.WriteLine("           }");
                    sw.WriteLine("        }");





                    sw.WriteLine("       //获取一个实体");
                    sw.WriteLine("       public static " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " DataRowToModel(IDataReader reader)");
                    sw.WriteLine("        {");
                    sw.WriteLine("            " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + " = new " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "();");
                    SqlDataReader reader = GetReader(className);
                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("            " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(ide + reader["COLUMN_NAME"]);
                                    sw.WriteLine("            " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                                // reader.NextResult();
                                //break;
                            }
                        }
                        else
                        {
                            sw.WriteLine("            " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    } reader = null;
                    //sw.WriteLine("                  list.Add(" + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ");     ");
                    //sw.WriteLine("              }");
                    sw.WriteLine("            return " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ";");
                    sw.WriteLine("        }");


                    sw.WriteLine("       //这是一个查询单个方法");
                    sw.WriteLine("       public static " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " Get" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "One(int " + className + id + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + className + " where " + id + "=\"+" + className + id + ";");
                    sw.WriteLine("           " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + " = new " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "();");
                    sw.WriteLine("           DataTable table = DBHelper.GetDataSet(sql);");

                    sw.WriteLine("            return " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ";");
                    sw.WriteLine("         }");
                    sw.WriteLine("       //这是一个修改的方法");
                    sw.WriteLine("       public void Modify" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "(" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"update " + className + " set \"+");
                    reader = GetReader(className);
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
                    reader = GetReader(className);
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
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if (j == 1)
                                        {
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (j == 1)
                                {
                                    sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                                else
                                {
                                    sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                            }
                        }
                    }
                    sw.WriteLine("                };");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql, para);");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个删除的方法");
                    sw.WriteLine("       public void Delete" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "ById(int " + className + id + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"DELETE " + className + " WHERE " + id + " = @" + className + id + "\";");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql, new SqlParameter(\"@" + className + id + "\", " + className + id + "));");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个添加的方法");
                    sw.WriteLine("       public void GetInsert(" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"insert into " + className + " values(\"+");
                    reader = GetReader(className);
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
                    reader = GetReader(className);
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
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if (m == 1)
                                        {
                                            sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        else
                                        {
                                            sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (m == 1)
                                {
                                    sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                }
                                else
                                {
                                    sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
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
                    FileStream fs = new FileStream(className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "Service.cs", FileMode.OpenOrCreate, FileAccess.Write);

                    //创建读写器
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    //执行操作
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using System.Data;");
                    sw.WriteLine("using System.Data.SqlClient;");
                    sw.WriteLine("using " + this.DBNameSpace + ";");
                    sw.WriteLine("using " + this.EntityNameSpace + ";");
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + this.DALNameSpace + "");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "Service");
                    sw.WriteLine("    {");
                    sw.WriteLine("       public  IList<" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "> GetAll" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "()");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + className + "\";");
                    sw.WriteLine("           List<" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "> list = new List<" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + ">();");
                    sw.WriteLine("           DataTable table = DBHelper.GetDataSet(sql);");
                    sw.WriteLine("           foreach (DataRow reader in table.Rows)");
                    sw.WriteLine("              {");
                    sw.WriteLine("                  " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + " = new " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "();");
                    SqlDataReader reader = GetReader(className);
                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("                  " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(ide + reader["COLUMN_NAME"]);
                                    sw.WriteLine("                  " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                                // reader.NextResult();
                                //break;
                            }
                        }
                        else
                        {
                            sw.WriteLine("                   " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    } reader = null;
                    sw.WriteLine("                  list.Add(" + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ");     ");
                    sw.WriteLine("              }");
                    sw.WriteLine("            return list;");
                    sw.WriteLine("         }");
                    sw.WriteLine("       //这是一个查询单个方法");
                    sw.WriteLine("       public static " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " Get" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "One(string " + className + "Name,object " + className + "id)");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"Select * from " + className + " where \" + " + className + "Name + \"=\"+" + className + "id ;");
                    sw.WriteLine("           " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + " = new " + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "();");
                    sw.WriteLine("           DataTable table = DBHelper.GetDataSet(sql);");
                    sw.WriteLine("           foreach (DataRow reader in table.Rows)");
                    sw.WriteLine("              {");
                    reader = GetReader(className);
                    while (reader.Read())
                    {
                        if (list != null && list.Count > 0)
                        {
                            foreach (string ide in list.Keys)
                            {
                                if (reader["COLUMN_NAME"].Equals(ide))
                                {
                                    sw.WriteLine("                  " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + " =" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "Service.Get" + list[ide].ToString().Substring(0, 1).ToUpper() + list[ide].Substring(1).ToString() + "One((" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + ide + "\"]);//FK");
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(ide + reader["COLUMN_NAME"]);
                                    sw.WriteLine("                  " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + "= (" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                                    break;
                                }
                                // reader.NextResult();
                                //break;
                            }
                        }
                        else
                        {
                            sw.WriteLine("                   " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + " = (" + getType(reader["TYPE_NAME"].ToString()) + ")reader[\"" + reader["COLUMN_NAME"] + "\"];");
                        }
                    } reader = null;
                    sw.WriteLine("              }");
                    sw.WriteLine("            return " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ";");
                    sw.WriteLine("         }");
                    sw.WriteLine("       //这是一个修改的方法");
                    sw.WriteLine("       public void Modify" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + "(" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ",string " + className + "Name,object " + className + "id)");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql=\"update " + className + " set \"+");
                    reader = GetReader(className);
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
                    sw.WriteLine("           \" WHERE \" + " + className + "Name + \"= \"+" + className + "id ;");
                    sw.WriteLine("             SqlParameter[] para = new SqlParameter[]");
                    sw.WriteLine("                {");
                    reader = GetReader(className);
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
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    break;
                                }
                                else
                                {
                                    if (j == 1)
                                    {
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (j == 1)
                            {
                                sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                            else
                            {
                                sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                        }

                    }
                    sw.WriteLine("                };");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql, para);");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个删除的方法");
                    sw.WriteLine("       public void Delete" + className + "ById(string " + className + "Name,object " + className + "id)");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"DELETE " + className + " WHERE \" + " + className + "Name + \"= \"+" + className + "id ;");
                    sw.WriteLine("           DBHelper.ExecuteCommand(sql);");
                    sw.WriteLine("        }");
                    sw.WriteLine("       //这是一个添加的方法");
                    sw.WriteLine("       public void GetInsert(" + className.Substring(0, 1).ToUpper() + className.Substring(1).ToString() + " " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + ")");
                    sw.WriteLine("        {");
                    sw.WriteLine("           string sql = \"insert into " + className + " values(\"+");
                    reader = GetReader(className);
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
                    reader = GetReader(className);
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
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + field[ide].ToString() + ")");
                                    }
                                    break;
                                }
                                else
                                {
                                    if (m == 1)
                                    {
                                        sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    else
                                    {
                                        sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (m == 1)
                            {
                                sw.WriteLine("               new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
                            }
                            else
                            {
                                sw.WriteLine("              ,new SqlParameter(\"@" + reader["COLUMN_NAME"] + "\", " + className.Substring(0, 1).ToLower() + className.Substring(1).ToString() + "." + reader["COLUMN_NAME"].ToString().Substring(0, 1).ToUpper() + reader["COLUMN_NAME"].ToString().Substring(1) + ")");
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
                Comm.msg= "生成成功！！O(∩_∩)O哈哈~";
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 生成实体类方法
        /// </summary>
        /// <param name="list"></param>
        /// <param name="className"></param>
        public void PrintLine(string className)
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
                sw.WriteLine("namespace  " + this.EntityNameSpace + "");
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

                Comm.msg= "生成成功！~!~";
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
        }
        /// <summary>
        /// 生成Dbhelper类
        /// </summary>
        public void PrintLine()
        {

            try
            {

                string FileName = FilePath + "DBHelper.cs";
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
                sw.WriteLine("using System.Configuration;");
                sw.WriteLine("");
                sw.WriteLine("namespace  " + this.DBNameSpace + "");
                sw.WriteLine("{");
                sw.WriteLine("    public static class DBHelper");
                sw.WriteLine("    {");
                sw.WriteLine("        //连接数据库代码时Commention对象重复使用");
                sw.WriteLine("       private static SqlConnection connection;");
                sw.WriteLine("");
                sw.WriteLine("       public static SqlConnection Connection");
                sw.WriteLine("       {");
                sw.WriteLine("           get");
                sw.WriteLine("             {");
                sw.WriteLine("");
                sw.WriteLine("                 string connectionString = \"Data Source=localhost;Initial Catalog=" + this.cmbDBName.Text + ";User ID=admin;passWord=;\";");
                sw.WriteLine("               if (connection == null)");
                sw.WriteLine("                {");
                sw.WriteLine("                       connection = new SqlConnection(connectionString);");
                sw.WriteLine("                       connection.Open();");
                sw.WriteLine("                }");
                sw.WriteLine("               else if (connection.State == System.Data.ConnectionState.Closed)");
                sw.WriteLine("                {");
                sw.WriteLine("                       connection.Open();");
                sw.WriteLine("                 }");
                sw.WriteLine("               else if (connection.State == System.Data.ConnectionState.Broken)");
                sw.WriteLine("                {");
                sw.WriteLine("                       connection.Close();");
                sw.WriteLine("                       connection.Open();");
                sw.WriteLine("                }");
                sw.WriteLine("               return connection;");
                sw.WriteLine("             }");
                sw.WriteLine("        }");
                sw.WriteLine("        //不带参数执行增删改的方法");
                sw.WriteLine("        public static int ExecuteCommand(string safeSql)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(safeSql, Connection);");
                sw.WriteLine("               int result = cmd.ExecuteNonQuery();");
                sw.WriteLine("               return result;");
                sw.WriteLine("           }");
                sw.WriteLine("        //带好的参数执行增删改的方法");
                sw.WriteLine("       public static int ExecuteCommand(string sql, SqlParameter[] values)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.AddRange(values);");
                sw.WriteLine("               return cmd.ExecuteNonQuery();");
                sw.WriteLine("            }");
                sw.WriteLine("        //带一个参数执行增删改的方法");
                sw.WriteLine("       public static int ExecuteCommand(string sql, SqlParameter value)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.Add(value);");
                sw.WriteLine("               int result = cmd.ExecuteNonQuery();");
                sw.WriteLine("               return result;");
                sw.WriteLine("            }");
                sw.WriteLine("        //不带参数并返回sql语句的第一个结果的第一个值");
                sw.WriteLine("       public static int ExecuteScalar(string safeSql)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(safeSql, Connection);");
                sw.WriteLine("               int result = (int)cmd.ExecuteScalar();");
                sw.WriteLine("               return result;");
                sw.WriteLine("           }");
                sw.WriteLine("        //带好的参数并返回sql语句的第一个结果的第一个值");
                sw.WriteLine("        public static int ExecuteScalar(string sql, SqlParameter[] values)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.AddRange(values);");
                sw.WriteLine("               int result = (int)cmd.ExecuteScalar();");
                sw.WriteLine("               return result;");
                sw.WriteLine("           }");
                sw.WriteLine("        //带一个参数并返回sql语句的第一个结果的第一个值");
                sw.WriteLine("        public static int ExecuteScalar(string sql, SqlParameter value)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.Add(value);");
                sw.WriteLine("               int result = (int)cmd.ExecuteScalar();");
                sw.WriteLine("               return result;");
                sw.WriteLine("           }");
                sw.WriteLine("        //不带参数并返回SqlDataReader的方法");
                sw.WriteLine("        public static SqlDataReader ExecuteReader(string safeSql)");
                sw.WriteLine("           {");
                sw.WriteLine("              SqlCommand cmd = new SqlCommand(safeSql, Connection);");
                sw.WriteLine("              SqlDataReader reader = cmd.ExecuteReader();");
                sw.WriteLine("              return reader;");
                sw.WriteLine("           }");
                sw.WriteLine("        //带一个参数并返回SqlDataReader对象的方法");
                sw.WriteLine("        public static SqlDataReader ExecuteReader(string sql, SqlParameter value)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.Add(value);");
                sw.WriteLine("               SqlDataReader reader = cmd.ExecuteReader();");
                sw.WriteLine("               return reader;");
                sw.WriteLine("           }");
                sw.WriteLine("//带许多参数并返回一个SqlDataReader的方法");
                sw.WriteLine("        public static SqlDataReader ExecuteReader(string sql, SqlParameter[] values)");
                sw.WriteLine("           {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.AddRange(values);");
                sw.WriteLine("               SqlDataReader reader = cmd.ExecuteReader();");
                sw.WriteLine("               return reader;");
                sw.WriteLine("            }");
                sw.WriteLine("        //不带参数并返回一个DataTable的方法");
                sw.WriteLine("        public static DataTable GetDataSet(string safeSql)");
                sw.WriteLine("           {");
                sw.WriteLine("               DataSet ds = new DataSet();");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(safeSql, Connection);");
                sw.WriteLine("               SqlDataAdapter da = new SqlDataAdapter(cmd);");
                sw.WriteLine("               da.Fill(ds);");
                sw.WriteLine("               return ds.Tables[0];");
                sw.WriteLine("           }");
                sw.WriteLine("        //不带参数并返回一个SqlDataReader的方法");
                sw.WriteLine("        public static SqlDataReader GetReader(string safeSql)");
                sw.WriteLine("            {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(safeSql, Connection);");
                sw.WriteLine("               SqlDataReader reader = cmd.ExecuteReader();");
                sw.WriteLine("               return reader;");
                sw.WriteLine("            }");
                sw.WriteLine("        //带许多参数并返回一个SqlDataReader的方法");
                sw.WriteLine("        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)");
                sw.WriteLine("            {");
                sw.WriteLine("               SqlCommand cmd = new SqlCommand(sql, Connection);");
                sw.WriteLine("               cmd.Parameters.AddRange(values);");
                sw.WriteLine("               SqlDataReader reader = cmd.ExecuteReader();");
                sw.WriteLine("               return reader;");
                sw.WriteLine("            }");
                sw.WriteLine("       }");
                sw.WriteLine("}");
                //关闭写入器
                sw.Close();

                //关闭文件流
                fs.Close();

                Comm.msg= "已经成功生Dbhelper类！！！~!~";
            }
            catch (Exception ex)
            {
                Comm.msg= ex.Message;
            }
        }
        #endregion

        #region 获取实体
        private Project getProEntity()
        { 
                  Project pro= new Project();
                  pro.EntityNameSpace = this.txtNamespace.Text.Trim();
                  pro.DALNameSpace = this.txtDALNameSpace.Text.Trim();
                  pro.DBNameSpace = this.txtDBNameSpace.Text.Trim();
                  return pro;
        }
        #endregion

    }
}