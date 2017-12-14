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
    /// ����������
    /// </summary>
    public partial class Main : Form
    {
        #region ����
        
        #endregion

        #region ���캯��
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region �¼�
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

        #region ����Master���ݿ�
        /// <summary>
        /// ����Master���ݿ�
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
                ShowMsg("���ӳɹ����õ����ݣ�~��");
            }
            catch (Exception ex)
            { Comm.msg = ex.Message; }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region �л����ݿ�
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
                    ShowMsg("(*^__^*) �����������ݿ���û�б�");
                }
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        this.checkedListBox1.Items.Add(reader[i]);
                    }
                    ShowMsg("�ѳɹ��ĵõ������ݿ��µ����б���");
                } reader.Close();
            }
            catch (Exception ex)
            { Comm.msg = ex.Message; }
            finally
            { conn.Close(); }
        }
        #endregion

        #region ȫѡ���ݱ�
        /// <summary>
        /// ȫѡ���ݱ�
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

        #region �л����·��
        /// <summary>
        /// �л����·��
        /// </summary>
        private void ChangeOutPath()
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog.SelectedPath;
                // TODO: �ڴ˴���Ӵ��룬������ĵ�ǰ���ݱ��浽һ���ļ��С�
                this.txtCreateFilePath.Text = FileName + @"\";
                Comm.FilePath = this.txtCreateFilePath.Text = FileName + @"\";
            }
        }
        #endregion

        #region ���ɴ���
        private void CreateCode()
        {
            Comm.project = new Project();
            Comm.project.DBName = this.cmbDBName.Text;
            Comm.project.EntityNameSpace = this.txtNamespace.Text.Trim();
            Comm.project.DALNameSpace = this.txtDALNameSpace.Text.Trim();
            Comm.project.DBNameSpace = this.txtDBNameSpace.Text.Trim();

            switch (this.cmbSysType.Text)
            {
                case "XYHT����":
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        if (this.checkedListBox1.GetItemChecked(i))
                        {
                            //����ʵ��
                            string tableName = this.checkedListBox1.Items[i].ToString();
                            XYHT.CreateModel(tableName);
                            //����DAL
                            //����DAL
                        }
                    }
                    break;
                default:
                    break;
            }
            ShowMsg("�����������!_��");
        }
        #endregion

        #region ��ʾ��Ϣ
        private void ShowMsg(string msg)
        {
            this.lblMsg.Text = msg;
            Application.DoEvents();
        }
        #endregion

    }
}