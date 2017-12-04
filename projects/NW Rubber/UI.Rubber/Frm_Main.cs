using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using NWR.BLL;
using NWR.Model;
using NWR.UI.UserControls;

namespace NWR.UI
{
    public partial class Frm_Main : Form
    {

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private MenusBll _menusBll = null;

        /// <summary>
        /// Ȩ��ϵͳ
        /// </summary>
        private int _menuTypeID = 1;

        /// <summary>
        /// ��ǰ�û�
        /// </summary>
        private Users _curUsers = null;
        /// <summary>
        /// �û�Ȩ���ֵ�
        /// </summary>
        private Dictionary<int, UserPermissions> _dicRoleMenus = null;

        /// <summary>
        /// ��ȡ�����ռ�
        /// </summary>
        private string _assemblyString = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;

        #endregion

        #region ��������

        /// <summary>
        /// ��ǰ�û�
        /// </summary>
        public Users CurUsers
        {
            get { return _curUsers; }
            //set { _curUsers = value; }
        }

        /// <summary>
        /// �û�Ȩ���ֵ�
        /// </summary>
        public Dictionary<int, UserPermissions> DicRoleMenus
        {
            get { return _dicRoleMenus; }
            set { _dicRoleMenus = value; }
        }

        #endregion

        #region �¼�֪ͨ

        public event EventHandler UserLogout;
        private void Frm_Main_Logout()
        {
            if (UserLogout != null)
            {
                UserLogout(this, EventArgs.Empty);
            }
        }

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public Frm_Main()
        {
            InitializeComponent();
        }
        public Frm_Main(Users curUsers, Dictionary<int, UserPermissions> dicRoleMenus)
        {
            InitializeComponent();
            _curUsers = curUsers;
            _dicRoleMenus = dicRoleMenus;
            GetUserInfo();
        }

        #endregion

        #region ����ӿ�

        /// <summary>
        /// Open����û�����
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="selectIndex"></param>
        public void OpenUserAddForm(int userID, int selectIndex)
        {
            UserControl userAdd = new UC_UserAdd(userID, selectIndex);
            //ƽ��
            userAdd.Dock = DockStyle.Fill;
            //��obj�ĸ�����ָ��Ϊ������
            userAdd.Parent = this;

            //�Ƴ��ؼ�
            for (int i = panel_Main.Controls.Count; i > 0; i--)
            {
                panel_Main.Controls[i - 1].Dispose();
            }

            //��Ӵ���
            panel_Main.Controls.Add(userAdd);

        }

        /// <summary>
        /// Open�û�������
        /// </summary>
        /// <param name="userID"></param>
        public void OpenUserManagerForm(int selectIndex)
        {
            UserControl userAdd = new UC_UserManage(selectIndex);
            //ƽ��
            userAdd.Dock = DockStyle.Fill;
            //��obj�ĸ�����ָ��Ϊ������
            userAdd.Parent = this;

            //�Ƴ��ؼ�
            for (int i = panel_Main.Controls.Count; i > 0; i--)
            {
                panel_Main.Controls[i - 1].Dispose();
            }

            //��Ӵ���
            panel_Main.Controls.Add(userAdd);
        }

        /// <summary>
        /// Open�û���ɫ����
        /// </summary>
        /// <param name="userID"></param>
        public void OpenUserRolesForm(Users model)
        {
            UserControl userAdd = new UC_UserRoles(model);
            //ƽ��
            userAdd.Dock = DockStyle.Fill;
            //��obj�ĸ�����ָ��Ϊ������
            userAdd.Parent = this;

            //�Ƴ��ؼ�
            for (int i = panel_Main.Controls.Count; i > 0; i--)
            {
                panel_Main.Controls[i - 1].Dispose();
            }

            //��Ӵ���
            panel_Main.Controls.Add(userAdd);
        }

        #endregion

        #region ˽�к���

        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        private void GetUserInfo()
        {
            label_UserName.Text = "������" + _curUsers.UserName;
            label_Role.Text = "ְλ��" + _curUsers.UserName;
        }

        /// <summary>
        /// ��ʼ���˵���
        /// </summary>
        private void Init_TreeViewMenu()
        {
            return;

            int parentID = 0;

            List<Menus> lsMenus = _menusBll.GetModel(_menuTypeID, parentID);

            if (lsMenus == null || lsMenus.Count == 0)
            {
                //�쳣
                return;
            }

            TreeNode node = null;

            for (int i = 0; i < lsMenus.Count; i++)
            {
                //�ж��Ƿ���Ȩ��
                if (_dicRoleMenus.ContainsKey(lsMenus[i].MenuID))
                {
                    node = new TreeNode();
                    node.Text = lsMenus[i].MenuName;
                    node.Name = lsMenus[i].MenuPath;
                    node.Tag = lsMenus[i];

                    treeView_Menu.Nodes.Add(node);

                    GetChildNodes(node, lsMenus[i].MenuID);
                }
            }
        }

        /// <summary>
        /// �ݹ���Ӳ˵��ڵ�
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="menus"></param>
        private void GetChildNodes(TreeNode parentNode, int parentID)
        {
            List<Menus> lsMenus = _menusBll.GetModel(_menuTypeID, parentID);

            TreeNode node = null;

            for (int i = 0; i < lsMenus.Count; i++)
            {
                //�ж��Ƿ���Ȩ��
                if (_dicRoleMenus.ContainsKey(lsMenus[i].MenuID))
                {
                    node = new TreeNode();
                    node.Text = lsMenus[i].MenuName;
                    node.Name = lsMenus[i].MenuPath;
                    node.Tag = lsMenus[i];

                    parentNode.Nodes.Add(node);

                    GetChildNodes(node, lsMenus[i].MenuID);
                }
            }
        }

        /// <summary>
        /// ��Ӵ���
        /// </summary>
        /// <param name="ctrlName"></param>
        private void AddControl(string ctrlName)
        {

            string ctrlPath = _assemblyString + ".UserControls." + ctrlName;

            UserControl userControl = (UserControl)Assembly.Load(_assemblyString).CreateInstance(ctrlPath);

            if (userControl != null)
            {
                //�Ƴ��ؼ�
                for (int i = panel_Main.Controls.Count; i > 0; i--)
                {
                    panel_Main.Controls[i - 1].Dispose();
                }

                //ƽ��
                userControl.Dock = DockStyle.Fill;
                //��obj�ĸ�����ָ��Ϊ������
                userControl.Parent = this;

                if (userControl.GetType() == typeof(UC_RoleMenusManage))
                {
                    //����λ��
                    userControl.Location = new Point(0, 0);
                    userControl.Dock = DockStyle.None;
                }

                //����û��ؼ�
                panel_Main.Controls.Add(userControl);
            }

        }

        #endregion

        #region ���ں���

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {

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

            _menusBll = new MenusBll();
            Init_TreeViewMenu();

        }

        /// <summary>
        /// ѡ�в˵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Menus menus = (Menus)e.Node.Tag;

            AddControl(menus.MenuPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_Edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_EditPwd frmEditPwd = new Frm_EditPwd(_curUsers);
            frmEditPwd.Show();
        }

        /// <summary>
        /// �˳���¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_Logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("���Ƿ�Ҫ�˳���¼��", "ϵͳ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.Cancel)
            {
                return;
            }
            this.Dispose();
            Frm_Main_Logout();
        }

        #endregion
    }
}