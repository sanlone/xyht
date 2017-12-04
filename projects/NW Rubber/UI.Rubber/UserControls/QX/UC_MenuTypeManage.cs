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
    public partial class UC_MenuTypeManage : UserControl
    {

        #region 私有字段

        /// <summary>
        /// 
        /// </summary>
        private MenuTypeBll _menuTypeBll = null;

        private MenuType _curMenuType = null;

        #endregion

        #region 公共属性

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public UC_MenuTypeManage()
        {
            InitializeComponent();
        }

        #endregion

        #region 对外接口

        #endregion

        #region 私有函数

        /// <summary>
        /// 初始化系统列表
        /// </summary>
        private void DataGridView_MenuType_Init()
        {
            DataTable table = _menuTypeBll.GetTable();
            dataGridView_MenuType.AutoGenerateColumns = false;
            dataGridView_MenuType.DataSource = table;
        }

        /// <summary>
        /// 清空所有文本框内容
        /// </summary>
        private void ClearTextBox()
        {
            textBox_MenuTypeName.Text = "";
            textBox_Description.Text = "";
        }

        /// <summary>
        /// 设置文本框内容
        /// </summary>
        /// <param name="menuType"></param>
        private void SetTextBox(MenuType menuType)
        {
            textBox_MenuTypeName.Text = menuType.MenuTypeName;
            textBox_Description.Text = menuType.Description;
        }

        #endregion

        #region 窗口事件

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_MenuTypeManager_Load(object sender, EventArgs e)
        {
            //初始化BLL
            _menuTypeBll = new MenuTypeBll();
            //初始化实体
            _curMenuType = new MenuType();
            //加载系统列表
            DataGridView_MenuType_Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_MenuType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dataGridView_MenuType.Columns[e.ColumnIndex].Name)
            {
                case "ID":
                    e.Value = e.RowIndex + 1;
                    break;
            }
        }
        /// <summary>
        /// DataGridView选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_MenuType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_MenuType.SelectedRows.Count > 0)
            {
                _curMenuType.MenuTypeID = Convert.ToInt32(dataGridView_MenuType.SelectedRows[0].Cells["MenuTypeID"].Value);
                _curMenuType.MenuTypeName = dataGridView_MenuType.SelectedRows[0].Cells["MenuTypeName"].Value.ToString();
                _curMenuType.Description = dataGridView_MenuType.SelectedRows[0].Cells["Description"].Value.ToString();

                SetTextBox(_curMenuType);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {

            MenuType menuType = new MenuType();
            menuType.MenuTypeName = textBox_MenuTypeName.Text;
            menuType.Description = textBox_Description.Text;

            if (_menuTypeBll.AddModel(menuType) > 0)
            {
                MessageBox.Show("添加成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                ClearTextBox();
                DataGridView_MenuType_Init();
            }
            else
            {
                MessageBox.Show("添加失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Edit_Click(object sender, EventArgs e)
        {
            MenuType menuType = new MenuType();
            menuType.MenuTypeName = textBox_MenuTypeName.Text;
            menuType.Description = textBox_Description.Text;

            if (_menuTypeBll.EditModel(menuType) > 0)
            {
                MessageBox.Show("修改成功", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                ClearTextBox();
                DataGridView_MenuType_Init();
            }
            else
            {
                MessageBox.Show("修改失败", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            //暂不删除
        }




        #endregion

    }
}
