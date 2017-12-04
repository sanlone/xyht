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

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private MenuTypeBll _menuTypeBll = null;

        private MenuType _curMenuType = null;

        #endregion

        #region ��������

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UC_MenuTypeManage()
        {
            InitializeComponent();
        }

        #endregion

        #region ����ӿ�

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��ʼ��ϵͳ�б�
        /// </summary>
        private void DataGridView_MenuType_Init()
        {
            DataTable table = _menuTypeBll.GetTable();
            dataGridView_MenuType.AutoGenerateColumns = false;
            dataGridView_MenuType.DataSource = table;
        }

        /// <summary>
        /// ��������ı�������
        /// </summary>
        private void ClearTextBox()
        {
            textBox_MenuTypeName.Text = "";
            textBox_Description.Text = "";
        }

        /// <summary>
        /// �����ı�������
        /// </summary>
        /// <param name="menuType"></param>
        private void SetTextBox(MenuType menuType)
        {
            textBox_MenuTypeName.Text = menuType.MenuTypeName;
            textBox_Description.Text = menuType.Description;
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_MenuTypeManager_Load(object sender, EventArgs e)
        {
            //��ʼ��BLL
            _menuTypeBll = new MenuTypeBll();
            //��ʼ��ʵ��
            _curMenuType = new MenuType();
            //����ϵͳ�б�
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
        /// DataGridViewѡ���¼�
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
        /// ���
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
                MessageBox.Show("��ӳɹ�", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.None);
                ClearTextBox();
                DataGridView_MenuType_Init();
            }
            else
            {
                MessageBox.Show("���ʧ��", "����ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// �޸�
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
                MessageBox.Show("�޸ĳɹ�", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.None);
                ClearTextBox();
                DataGridView_MenuType_Init();
            }
            else
            {
                MessageBox.Show("�޸�ʧ��", "����ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            //�ݲ�ɾ��
        }




        #endregion

    }
}
