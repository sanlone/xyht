using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NWR.BLL;
using NWR.Model;
using System.Reflection;
using System.Web.UI.WebControls;

namespace NWR.UI.UserControls
{
    public partial class UC_UserAdd : UserControl
    {

        #region ˽���ֶ�

        private UsersBll _usersBll = null;
        /// <summary>
        /// �û����
        /// </summary>
        private int _userID = 0;
        private int _selectIndex = 0;

        #endregion

        #region ��������

        #endregion

        #region ���캯��

        public UC_UserAdd()
        {
            InitializeComponent();
        }
        public UC_UserAdd(int userID, int selectIndex)
        {
            InitializeComponent();
            _userID = userID;
            _selectIndex = selectIndex;
        }

        #endregion

        #region ����ӿ�

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��ʼ���û�����
        /// </summary>
        private void ComboBox_UserType_Init()
        {
            comboBox_UserType.Items.Clear();

            Type t = typeof(EnumUserType);
            Array arrs = Enum.GetValues(t);

            EnumUserType enumUserType;
            FieldInfo fieldInfo;
            DescriptionAttribute attrib;
            object[] attribArray;

            for (int i = 0; i < arrs.Length; i++)
            {
                enumUserType = (EnumUserType)arrs.GetValue(i);
                fieldInfo = enumUserType.GetType().GetField(enumUserType.ToString());
                attribArray = fieldInfo.GetCustomAttributes(false);
                attrib = (DescriptionAttribute)attribArray[0];

                comboBox_UserType.Items.Add(new ListItem(attrib.Description, i.ToString()));
            }

            comboBox_UserType.SelectedIndex = comboBox_UserType.Items.Count > 0 ? 0 : -1;

        }

        /// <summary>
        /// ��ʼ���û���Ϣ
        /// </summary>
        private void UserInfo_Init()
        {
            if (_userID == 0)
            {
                button_Add.Text = "���";
                button_Cancel.Text = "ȡ��";
                return;
            }

            label_UserAccount.Enabled = false;
            label_Password.Enabled = false;
            label_Password2.Enabled = false;
            textBox_UserAccount.Enabled = false;
            textBox_Password.Enabled = false;
            textBox_Password2.Enabled = false;
            button_Add.Text = "�޸�";
            button_Cancel.Text = "����";

            Users model = _usersBll.GetModel(_userID);

            if (model != null)
            {
                textBox_UserAccount.Text = model.UserAccount;
                textBox_UserName.Text = model.UserName;
                if (model.Sex == 0)
                {
                    radioButton_Man.Checked = true;
                }
                else
                {
                    radioButton_Woman.Checked = true;
                }
                dateTimePicker__Birthday.Text = model.Birthday.ToString();
                textBox_Phone.Text = model.Phone;
                textBox_Email.Text = model.Email;
                textBox_EmployeeID.Text = model.EmployeeID;
                ComboBox_UserType_Set(model.UserType);

                textBox_Remark.Text = model.Remark;
            }

        }

        /// <summary>
        /// ComboBox��ֵ
        /// </summary>
        /// <param name="userType"></param>
        private void ComboBox_UserType_Set(EnumUserType userType)
        {
            foreach (ListItem item in comboBox_UserType.Items)
            {
                if (Convert.ToInt32(item.Value) == userType.GetHashCode())
                {
                    comboBox_UserType.SelectedItem = item;
                    return;
                }
            }
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_UserAdd_Load(object sender, EventArgs e)
        {
            //��ʼ��Bll
            _usersBll = new UsersBll();
            //��ʼ���û�����
            ComboBox_UserType_Init();
            //��ʼ��
            UserInfo_Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_UserAccount_Leave(object sender, EventArgs e)
        {

            err_UserAccount.Text = "";

            string userAccount = textBox_UserAccount.Text;

            if (string.IsNullOrEmpty(userAccount))
            {
                err_UserAccount.Text = "�������˺�";
                err_UserAccount.ForeColor = Color.Red;
                return;
            }

            if (_usersBll.ExsitModel(userAccount))
            {
                //����
                err_UserAccount.Text = "���û����Ѵ���";
                err_UserAccount.ForeColor = Color.Red;
            }
            else
            {
                //������
                err_UserAccount.Text = "���û�����ʹ��";
                err_UserAccount.ForeColor = Color.Green;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Password_Leave(object sender, EventArgs e)
        {

            err_Password.Text = "";

            string passWord = textBox_Password.Text;
            string passWord2 = textBox_Password2.Text;

            if (string.IsNullOrEmpty(passWord))
            {
                err_Password.Text = "����������";
                return;
            }

            if (passWord.Length < 4)
            {
                err_Password.Text = "���벻������4λ";
                return;
            }

            if (passWord2.Length > 4 && passWord != passWord2)
            {
                err_Password2.Text = "������������벻һ��";
                return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Password2_Leave(object sender, EventArgs e)
        {

            string passWord = textBox_Password.Text;
            string passWord2 = textBox_Password2.Text;

            if (string.IsNullOrEmpty(passWord2))
            {
                err_Password2.Text = "������ȷ������";
                return;
            }

            if (passWord != passWord2)
            {
                err_Password2.Text = "������������벻һ��";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {

            Users model = null;

            if (_userID > 0)
            {
                //���޸��û�����
                model = _usersBll.GetModel(_userID);

                model.UserAccount = textBox_UserAccount.Text;
                model.UserName = textBox_UserName.Text;
                model.Sex = radioButton_Man.Checked ? 0 : 1;
                model.Birthday = Convert.ToDateTime(dateTimePicker__Birthday.Text);
                model.Phone = textBox_Phone.Text;
                model.Email = textBox_Email.Text;
                model.EmployeeID = textBox_EmployeeID.Text;
                model.DepartmentID = 1;
                model.UserType = CommonClass.GetUserType(Convert.ToInt32(((ListItem)comboBox_UserType.SelectedItem).Value));
                model.Remark = textBox_Remark.Text;

                //�޸�
                if (_usersBll.EditModel(model) > 0)
                {
                    MessageBox.Show("�޸ĳɹ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("�޸�ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                model = new Users();

                model.UserAccount = textBox_UserAccount.Text;
                //����
                model.Password = _usersBll.GetMD5(textBox_Password.Text);
                model.UserName = textBox_UserName.Text;
                model.Sex = radioButton_Man.Checked ? 0 : 1;
                model.Birthday = Convert.ToDateTime(dateTimePicker__Birthday.Text);
                model.Phone = textBox_Phone.Text;
                model.Email = textBox_Email.Text;
                model.EmployeeID = textBox_EmployeeID.Text;
                model.DepartmentID = 1;
                model.UserType = CommonClass.GetUserType(Convert.ToInt32(((ListItem)comboBox_UserType.SelectedItem).Value));
                //��ѯ������ʱ��
                model.EntryDate = _usersBll.GetDBTime();
                model.Remark = textBox_Remark.Text;

                //���
                if (_usersBll.AddModel(model) > 0)
                {
                    MessageBox.Show("��ӳɹ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("���ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            ((Frm_Main)this.ParentForm).OpenUserManagerForm(_selectIndex);
        }
        #endregion

    }
}
