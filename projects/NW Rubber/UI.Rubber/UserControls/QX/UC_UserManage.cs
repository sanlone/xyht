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

        #region 私有字段

        /// <summary>
        /// 
        /// </summary>
        private UsersBll _userBll = null;

        /// <summary>
        /// 当前选中
        /// </summary>
        private int _selectIndex = -1;


        #endregion

        #region 公共属性

        #endregion

        #region 构造函数

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

        #region 对外接口

        #endregion

        #region 私有函数

        /// <summary>
        /// 添加按钮列
        /// </summary>
        private void AddDataGridViewButtonColumn()
        {

            DataGridViewButtonColumn dgv_button_col_Reset = new DataGridViewButtonColumn();
            //设定列的名字
            dgv_button_col_Reset.Name = "Reset";
            //在所有按钮上表示内容
            dgv_button_col_Reset.UseColumnTextForButtonValue = true;
            dgv_button_col_Reset.Text = "重置密码";
            //设置列标题
            dgv_button_col_Reset.HeaderText = "重置密码";
            //设置列宽
            dgv_button_col_Reset.Width = 65;
            //向DataGridView追加
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_Reset);


            DataGridViewButtonColumn dgv_button_col_UserRoles = new DataGridViewButtonColumn();
            //设定列的名字
            dgv_button_col_UserRoles.Name = "UserRoles";
            //在所有按钮上表示内容
            dgv_button_col_UserRoles.UseColumnTextForButtonValue = true;
            dgv_button_col_UserRoles.Text = "用户角色";
            //设置列标题
            dgv_button_col_UserRoles.HeaderText = "用户角色";
            //设置列宽
            dgv_button_col_UserRoles.Width = 65;
            //向DataGridView追加
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_UserRoles);



            DataGridViewButtonColumn dgv_button_col_Edit = new DataGridViewButtonColumn();
            //设定列的名字
            dgv_button_col_Edit.Name = "Edit";
            //在所有按钮上表示内容
            dgv_button_col_Edit.UseColumnTextForButtonValue = true;
            dgv_button_col_Edit.Text = "修改";
            //设置列标题
            dgv_button_col_Edit.HeaderText = "修改";
            //设置列宽
            dgv_button_col_Edit.Width = 45;
            //向DataGridView追加
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_Edit);


            DataGridViewButtonColumn dgv_button_col_Delete = new DataGridViewButtonColumn();
            //设定列的名字
            dgv_button_col_Delete.Name = "Delete";
            //在所有按钮上表示内容
            dgv_button_col_Delete.UseColumnTextForButtonValue = true;
            dgv_button_col_Delete.Text = "删除";
            //设置列标题
            dgv_button_col_Delete.HeaderText = "删除";
            //设置列宽
            dgv_button_col_Delete.Width = 45;
            //向DataGridView追加
            dataGridView_Users.Columns.Insert(dataGridView_Users.Columns.Count, dgv_button_col_Delete);

        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string GetSelectWhere()
        {

            StringBuilder strwhere = new StringBuilder(" WHERE 1=1 ");

            if (!string.IsNullOrEmpty(textBox_SelectWhere.Text))
            {
                switch (comboBox_SelectType.SelectedItem.ToString())
                {
                    case "姓名":
                        strwhere.AppendFormat(" AND UserName like '%{0}%' ", textBox_SelectWhere.Text);
                        break;
                    case "编号":
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
                case "默认正序": strwhere.Append(" ORDER BY UserID ASC");
                    break;
                case "默认倒序": strwhere.Append(" ORDER BY UserID DESC");
                    break;
                case "年龄最大": strwhere.Append(" ORDER BY Birthday ASC");
                    break;
                case "年龄最小": strwhere.Append(" ORDER BY Birthday DESC");
                    break;
                case "入职最早": strwhere.Append(" ORDER BY EntryTime ASC");
                    break;
                case "入职最晚": strwhere.Append(" ORDER BY EntryTime DESC");
                    break;
                case "在职最长": strwhere.Append(" ");
                    break;
                case "在职最短": strwhere.Append(" ");
                    break;
            }


            return strwhere.ToString();
        }

        #endregion

        #region 窗口事件

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
                        case 0: e.Value = "良好"; break;
                        case 1: e.Value = "损坏"; break;
                    }
                    break;
                case "ID":
                    e.Value = e.RowIndex + 1;
                    break;
                case "Sex":
                    e.Value = e.Value.ToString() == "0" ? "男" : "女";
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
        /// 重置密码
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
                    MessageBox.Show("操作成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("操作失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// 修改
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
        /// 删除
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

                DialogResult result = MessageBox.Show("您确定删除吗？", "是否删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                int userID = Convert.ToInt32(dataGridView_Users.Rows[e.RowIndex].Cells["UserID"].Value);

                int deleteUserID = ((Frm_Main)this.ParentForm).CurUsers.UserID;
                string deleteReason = "系统删除";

                if (_userBll.DeleteModel(userID, deleteUserID, deleteReason) > 0)
                {
                    button_Select_Click(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("删除失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 用户角色
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
        /// 查询事件
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
