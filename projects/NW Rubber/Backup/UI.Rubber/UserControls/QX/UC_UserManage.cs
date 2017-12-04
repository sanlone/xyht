using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NWR.BLL;
using NWR.Model;

namespace NWR.UI.UserControls
{
    public partial class UC_UserManage : UserControl
    {

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private UsersBll _userBll = null;

        /// <summary>
        /// ��ǰѡ��
        /// </summary>
        private int _selectIndex = -1;


        #endregion

        #region ��������

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UC_UserManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public UC_UserManage(int selectIndex)
        {
            InitializeComponent();
            _selectIndex = selectIndex;
        }

        #endregion

        #region ����ӿ�

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��Ӱ�ť��
        /// </summary>
        private void AddDataGridViewButtonColumn()
        {

            DataGridViewButtonColumn dgv_button_col_Reset = new DataGridViewButtonColumn();
            //�趨�е�����
            dgv_button_col_Reset.Name = "Reset";
            //�����а�ť�ϱ�ʾ����
            dgv_button_col_Reset.UseColumnTextForButtonValue = true;
            dgv_button_col_Reset.Text = "��������";
            //�����б���
            dgv_button_col_Reset.HeaderText = "��������";
            //�����п�
            dgv_button_col_Reset.Width = 65;
            //��DataGridView׷��
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_Reset);


            DataGridViewButtonColumn dgv_button_col_UserRoles = new DataGridViewButtonColumn();
            //�趨�е�����
            dgv_button_col_UserRoles.Name = "UserRoles";
            //�����а�ť�ϱ�ʾ����
            dgv_button_col_UserRoles.UseColumnTextForButtonValue = true;
            dgv_button_col_UserRoles.Text = "�û���ɫ";
            //�����б���
            dgv_button_col_UserRoles.HeaderText = "�û���ɫ";
            //�����п�
            dgv_button_col_UserRoles.Width = 65;
            //��DataGridView׷��
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_UserRoles);



            DataGridViewButtonColumn dgv_button_col_Edit = new DataGridViewButtonColumn();
            //�趨�е�����
            dgv_button_col_Edit.Name = "Edit";
            //�����а�ť�ϱ�ʾ����
            dgv_button_col_Edit.UseColumnTextForButtonValue = true;
            dgv_button_col_Edit.Text = "�޸�";
            //�����б���
            dgv_button_col_Edit.HeaderText = "�޸�";
            //�����п�
            dgv_button_col_Edit.Width = 45;
            //��DataGridView׷��
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_Edit);


            DataGridViewButtonColumn dgv_button_col_Delete = new DataGridViewButtonColumn();
            //�趨�е�����
            dgv_button_col_Delete.Name = "Delete";
            //�����а�ť�ϱ�ʾ����
            dgv_button_col_Delete.UseColumnTextForButtonValue = true;
            dgv_button_col_Delete.Text = "ɾ��";
            //�����б���
            dgv_button_col_Delete.HeaderText = "ɾ��";
            //�����п�
            dgv_button_col_Delete.Width = 45;
            //��DataGridView׷��
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_Delete);

        }

        /// <summary>
        /// ��ȡ��ѯ����
        /// </summary>
        /// <returns></returns>
        private string GetSelectWhere()
        {

            StringBuilder strwhere = new StringBuilder(" WHERE 1=1 ");

            if (!string.IsNullOrEmpty(textBox_SelectWhere.Text))
            {
                switch (comboBox_SelectType.SelectedItem.ToString())
                {
                    case "����":
                        strwhere.AppendFormat(" AND UserName like '%{0}%' ", textBox_SelectWhere.Text);
                        break;
                    case "���":
                        strwhere.AppendFormat(" AND EmployeeID like '%{0}%' ", textBox_SelectWhere.Text);
                        break;
                }
            }

            DateTime data1 = Convert.ToDateTime("1900/01/01");
            DateTime data2 = Convert.ToDateTime("1900/01/01");

            if (DateTime.TryParse(textBox1.Text, out data1) || DateTime.TryParse(textBox2.Text, out data2))
            {
                if (data1 < data2)
                {
                    strwhere.AppendFormat(" AND EntryTime BETWEEN '{0}' AND '{1}' ", data1.ToString(), data2.ToString());
                }
                else
                {
                    strwhere.AppendFormat(" AND EntryTime BETWEEN '{0}' AND '{1}' ", data2.ToString(), data1.ToString());
                }

            }


            switch (comboBox_Sore.SelectedItem.ToString())
            {
                case "Ĭ������": strwhere.Append(" ORDER BY UserID ASC");
                    break;
                case "Ĭ�ϵ���": strwhere.Append(" ORDER BY UserID DESC");
                    break;
                case "�������": strwhere.Append(" ORDER BY Birthday ASC");
                    break;
                case "������С": strwhere.Append(" ORDER BY Birthday DESC");
                    break;
                case "��ְ����": strwhere.Append(" ORDER BY EntryTime ASC");
                    break;
                case "��ְ����": strwhere.Append(" ORDER BY EntryTime DESC");
                    break;
                case "��ְ�": strwhere.Append(" ");
                    break;
                case "��ְ���": strwhere.Append(" ");
                    break;
            }


            return strwhere.ToString();
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_UserManager_Load(object sender, EventArgs e)
        {
            _userBll = new UsersBll();

            comboBox_SelectType.SelectedIndex = 0;
            comboBox_Sore.SelectedIndex = 0;

            AddDataGridViewButtonColumn();

            dataGridView_Users.AutoGenerateColumns = false;

            button_Select_Click(this, EventArgs.Empty);

            dataGridView_Users.ClearSelection();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Users_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            switch (dataGridView_Users.Columns[e.ColumnIndex].Name)
            {
                case "MoldState":
                    switch (Convert.ToInt32(e.Value))
                    {
                        case 0: e.Value = "����"; break;
                        case 1: e.Value = "��"; break;
                    }
                    break;
                case "ID":
                    e.Value = e.RowIndex + 1;
                    break;
                case "Sex":
                    e.Value = e.Value.ToString() == "0" ? "��" : "Ů";
                    break;
                case "Birthday":
                case "EntryDate":
                case "DeleteDate":
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
                    }
                    break;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView_Users.Columns[e.ColumnIndex].Name)
            {
                case "Reset": dataGridViewButtonColumn_Reset_Click(sender, e); break;
                case "Edit": dataGridViewButtonColumn_Edit_Click(sender, e); break;
                case "Delete": dataGridViewButtonColumn_Delete_Click(sender, e); break;
                case "UserRoles": dataGridViewButtonColumn_UserRoles_Click(sender, e); break;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewButtonColumn_Reset_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                int userID = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["UserID"].Value);

                Users model = _userBll.GetModel(userID);

                model.Password = _userBll.GetMD5("123456");

                if (_userBll.EditModel(model) > 0)
                {
                    MessageBox.Show("�����ɹ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("����ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewButtonColumn_Edit_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int userID = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["UserID"].Value);

                ((Frm_Main)this.ParentForm).OpenUserAddForm(userID, e.RowIndex);

            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewButtonColumn_Delete_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                if (!string.IsNullOrEmpty(dataGridView_Users.Rows[e.RowIndex].Cells["DeleteDate"].Value.ToString()))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("��ȷ��ɾ����", "�Ƿ�ɾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                int userID = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["UserID"].Value);

                int deleteUserID = ((Frm_Main)this.ParentForm).CurUsers.UserID;
                string deleteReason = "ϵͳɾ��";

                if (_userBll.DeleteModel(userID, deleteUserID, deleteReason) > 0)
                {
                    button_Select_Click(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("ɾ��ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// �û���ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewButtonColumn_UserRoles_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Users model = new Users();

                model.UserID = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["UserID"].Value);
                model.UserName = Convert.ToString(dataGridView_Users.Rows[e.RowIndex].Cells["UserName"].Value);
                model.Sex = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["Sex"].Value);
                model.EmployeeID = Convert.ToString(dataGridView_Users.Rows[e.RowIndex].Cells["EmployeeID"].Value);
                model.DepartmentID = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["DepartmentID"].Value);
                model.UserType = CommonClass.GetUserType(Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["UserType"].Value));
                model.Remark = Convert.ToString(dataGridView_Users.Rows[e.RowIndex].Cells["Remark"].Value);

                ((Frm_Main)this.ParentForm).OpenUserRolesForm(model);
            }
        }

        /// <summary>
        /// ��ѯ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Select_Click(object sender, EventArgs e)
        {
            string strwhere = GetSelectWhere();

            DataTable dt = _userBll.GetTable(strwhere);

            dataGridView_Users.DataSource = dt;

            if (_selectIndex > -1 && dataGridView_Users.Rows.Count > _selectIndex)
            {
                dataGridView_Users.CurrentCell = dataGridView_Users.Rows[_selectIndex].Cells[0];
            }
        }

        #endregion

    }
}
