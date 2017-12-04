using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NWR.BLL;
using NWR.Model;

namespace NWR.UI
{
    public partial class Frm_Login : Form
    {

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private UsersBll _usersBll = null;
        /// <summary>
        /// 
        /// </summary>
        private UserRolesBll _userRolesBll = null;
        /// <summary>
        /// 
        /// </summary>
        private RoleMenusBll _roleMenusBll = null;

        /// <summary>
        /// �û�Ȩ���ֵ�
        /// </summary>
        private Dictionary<int, UserPermissions> _dicRoleMenus = null;

        #endregion

        #region ��������

        #endregion

        #region ���캯��

        /// <summary>
        /// ��ʼ������
        /// </summary>
        public Frm_Login()
        {
            InitializeComponent();
        }

        #endregion

        #region ����ӿ�

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��ȡ�û�Ȩ��
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        private bool GetUserRoleMenus(int userID)
        {

            _dicRoleMenus = new Dictionary<int, UserPermissions>();

            UserRoles userRoles = null;
            RoleMenus roleMenus = null;
            string[] ayyRoles = new string[0] { };

            //��ȡ�û���ɫ
            userRoles = _userRolesBll.GetModel(userID);

            if (userRoles == null || string.IsNullOrEmpty(userRoles.RoleID))
            {
                return false;
            }

            ayyRoles = userRoles.RoleID.Split(',');

            for (int i = 0; i < ayyRoles.Length; i++)
            {
                //��ȡ��ɫȨ��
                roleMenus = _roleMenusBll.GetModel(Convert.ToInt32(ayyRoles[i]));

                foreach (int key in roleMenus.DicPermissions.Keys)
                {
                    if (!_dicRoleMenus.ContainsKey(key))
                    {
                        //��ӵ�Ȩ���ֵ�
                        _dicRoleMenus.Add(key, roleMenus.DicPermissions[key]);
                    }
                }

            }

            return true;

        }

        #endregion

        #region �����¼�

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Login_Load(object sender, EventArgs e)
        {
            _usersBll = new UsersBll();
            _userRolesBll = new UserRolesBll();
            _roleMenusBll = new RoleMenusBll();

            #region ȫ�ֲ����쳣
            try
            {

                //����UI�߳��쳣
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(CommonClass.Application_ThreadException);
                //�����UI�߳��쳣
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CommonClass.CurrentDomain_UnhandledException);
                //����Ӧ�ó������쳣��ʽ��ThreadException��������δ������쳣
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            }
            catch
            {
                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //ֻҪ���߳��ϴ������κοؼ������߳��쳣ģʽ�����������κθ��ġ�
            }
            #endregion

        }

        /// <summary>
        /// ��¼�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Login_Click(object sender, EventArgs e)
        {

            //��¼
            string account = textBox_Account.Text.Trim();
            string pwd = textBox_PassWord.Text;

            if (account.Length < 2)
            {
                label_AccountErr.Text = "�˺Ŵ���";
                label_PwdErr.Text = "";
                return;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                label_AccountErr.Text = "";
                label_PwdErr.Text = "���벻��Ϊ��";
                return;
            }

            Users curUser = _usersBll.GetModel(account);

            if (curUser == null || curUser.UserAccount == null)
            {
                label_AccountErr.Text = "�˺Ŵ���";
                label_PwdErr.Text = "";
                return;
            }

            pwd = _usersBll.GetMD5(textBox_PassWord.Text);
            //�Աȼ�������
            if (pwd.Length != curUser.Password.Length || !pwd.Equals(curUser.Password))
            {
                label_AccountErr.Text = "";
                label_PwdErr.Text = "�������";
                return;
            }

            if (!GetUserRoleMenus(curUser.UserID))
            {
                MessageBox.Show("�û�״̬��������ϵ����Ա", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();

            Frm_Main frmMain = new Frm_Main(curUser, _dicRoleMenus);
            frmMain.UserLogout += new EventHandler(frmMain_UserLogout);
            frmMain.Show();
        }

        void frmMain_UserLogout(object sender, EventArgs e)
        {
            Frm_Main frmMain = (Frm_Main)sender;
            frmMain.Dispose();
            this.Show();
        }

        #endregion

    }

}