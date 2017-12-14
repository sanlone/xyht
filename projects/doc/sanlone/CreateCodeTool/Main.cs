using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CreateCodeTool
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public partial class Main : Form
    {
        #region 变量
        
        #endregion

        #region 构造函数
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件
        private void Main_Load(object sender, EventArgs e)
        {
            this.cmbSysType.SelectedIndex = 0;
            Comm.FilePath = this.txtCreateFilePath.Text.Trim() + @"\";
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ConnectionMaster();
        }
        private void cmbDBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDatabase();
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            SelectAllTable();
        }
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            ChangeOutPath();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateCode();
        }
        #endregion

        #region 连接Master数据库
        /// <summary>
        /// 连接Master数据库
        /// </summary>
        private void ConnectionMaster()
        {
            Comm.ConnString = string.Format(Comm.connStringFormat, txtName.Text.Trim(), txtUser.Text.Trim(), txtPWD.Text.Trim());
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter("Exec sp_helpdb", conn);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                this.cmbDBName.DataSource = ds.Tables[0].DefaultView;
                this.cmbDBName.DisplayMember = "name";
                this.cmbDBName.SelectedIndex = 0;
                ShowMsg("连接成功并拿到数据！~！");
            }
            catch (Exception ex)
            { Comm.msg = ex.Message; }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 切换数据库
        /// <summary>
        /// 
        /// </summary>
        private void ChangeDatabase()
        {
            this.checkedListBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(Comm.ConnString);
            try
            {
                conn.Open();
                string sql = "use " + this.cmbDBName.Text + "  ; select name from dbo.sysobjects  where xtype='U' and sysstat<200";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    ShowMsg("(*^__^*) 嘻嘻……数据库里没有表！");
                }
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        this.checkedListBox1.Items.Add(reader[i]);
                    }
                    ShowMsg("已成功的得到该数据库下的所有表！！");
                } reader.Close();
            }
            catch (Exception ex)
            { Comm.msg = ex.Message; }
            finally
            { conn.Close(); }
        }
        #endregion

        #region 全选数据表
        /// <summary>
        /// 全选数据表
        /// </summary>
        private void SelectAllTable()
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
                Comm.msg = ex.Message;
            }
        }
        #endregion

        #region 切换输出路径
        /// <summary>
        /// 切换输出路径
        /// </summary>
        private void ChangeOutPath()
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog.SelectedPath;
                // TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
                this.txtCreateFilePath.Text = FileName + @"\";
                Comm.FilePath = this.txtCreateFilePath.Text = FileName + @"\";
            }
        }
        #endregion

        #region 生成代码
        private void CreateCode()
        {
            Comm.project = new Project();
            Comm.project.DBName = this.cmbDBName.Text;
            Comm.project.EntityNameSpace = this.txtNamespace.Text.Trim();
            Comm.project.DALNameSpace = this.txtDALNameSpace.Text.Trim();
            Comm.project.DBNameSpace = this.txtDBNameSpace.Text.Trim();

            switch (this.cmbSysType.Text)
            {
                case "XYHT定制":
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        if (this.checkedListBox1.GetItemChecked(i))
                        {
                            //生成实体
                            string tableName = this.checkedListBox1.Items[i].ToString();
                            XYHT.CreateModel(tableName);
                            //生成DAL
                            //生成DAL
                        }
                    }
                    break;
                default:
                    break;
            }
            ShowMsg("代码生成完成!_！");
        }
        #endregion

        #region 显示信息
        private void ShowMsg(string msg)
        {
            this.lblMsg.Text = msg;
            Application.DoEvents();
        }
        #endregion

    }
}