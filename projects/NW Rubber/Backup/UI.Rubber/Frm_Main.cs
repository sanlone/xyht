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

        #region 私有字段

        /// <summary>
        /// 
        /// </summary>
        private MenusBll _menusBll = null;

        /// <summary>
        /// 权限系统
        /// </summary>
        private int _menuTypeID = 1;

        /// <summary>
        /// 当前用户
        /// </summary>
        private Users _curUsers = null;
        /// <summary>
        /// 用户权限字典
        /// </summary>
        private Dictionary<int, UserPermissions> _dicRoleMenus = null;

        /// <summary>
        /// 获取命名空间
        /// </summary>
        private string _assemblyString = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;

        #endregion

        #region 公共属性

        /// <summary>
        /// 当前用户
        /// </summary>
        public Users CurUsers
        {
            get { return _curUsers; }
            //set { _curUsers = value; }
        }

        /// <summary>
        /// 用户权限字典
        /// </summary>
        public Dictionary<int, UserPermissions> DicRoleMenus
        {
            get { return _dicRoleMenus; }
            set { _dicRoleMenus = value; }
        }

        #endregion

        #region 事件通知

        public event EventHandler UserLogout;
        private void Frm_Main_Logout()
        {
            if (UserLogout != null)
            {
                UserLogout(this, EventArgs.Empty);
            }
        }

        #endregion

        #region 构造函数

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

        #region 对外接口

        /// <summary>
        /// Open添加用户窗口
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="selectIndex"></param>
        public void OpenUserAddForm(int userID, int selectIndex)
        {
            UserControl userAdd = new UC_UserAdd(userID, selectIndex);
            //平铺
            userAdd.Dock = DockStyle.Fill;
            //把obj的父窗体指定为主窗口
            userAdd.Parent = this;

            //移除控件
            for (int i = panel_Main.Controls.Count; i > 0; i--)
            {
                panel_Main.Controls[i - 1].Dispose();
            }

            //添加窗口
            panel_Main.Controls.Add(userAdd);

        }

        /// <summary>
        /// Open用户管理窗口
        /// </summary>
        /// <param name="userID"></param>
        public void OpenUserManagerForm(int selectIndex)
        {
            UserControl userAdd = new UC_UserManage(selectIndex);
            //平铺
            userAdd.Dock = DockStyle.Fill;
            //把obj的父窗体指定为主窗口
            userAdd.Parent = this;

            //移除控件
            for (int i = panel_Main.Controls.Count; i > 0; i--)
            {
                panel_Main.Controls[i - 1].Dispose();
            }

            //添加窗口
            panel_Main.Controls.Add(userAdd);
        }

        /// <summary>
        /// Open用户角色窗口
        /// </summary>
        /// <param name="userID"></param>
        public void OpenUserRolesForm(Users model)
        {
            UserControl userAdd = new UC_UserRoles(model);
            //平铺
            userAdd.Dock = DockStyle.Fill;
            //把obj的父窗体指定为主窗口
            userAdd.Parent = this;

            //移除控件
            for (int i = panel_Main.Controls.Count; i > 0; i--)
            {
                panel_Main.Controls[i - 1].Dispose();
            }

            //添加窗口
            panel_Main.Controls.Add(userAdd);
        }

        #endregion

        #region 私有函数

        /// <summary>
        /// 加载用户信息
        /// </summary>
        private void GetUserInfo()
        {
            label_UserName.Text = "姓名：" + _curUsers.UserName;
            label_Role.Text = "职位：" + _curUsers.UserName;
        }

        /// <summary>
        /// 初始化菜单树
        /// </summary>
        private void Init_TreeViewMenu()
        {
            return;

            int parentID = 0;

            List<Menus> lsMenus = _menusBll.GetModel(_menuTypeID, parentID);

            if (lsMenus == null || lsMenus.Count == 0)
            {
                //异常
                return;
            }

            TreeNode node = null;

            for (int i = 0; i < lsMenus.Count; i++)
            {
                //判断是否有权限
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
        /// 递归添加菜单节点
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="menus"></param>
        private void GetChildNodes(TreeNode parentNode, int parentID)
        {
            List<Menus> lsMenus = _menusBll.GetModel(_menuTypeID, parentID);

            TreeNode node = null;

            for (int i = 0; i < lsMenus.Count; i++)
            {
                //判断是否有权限
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
        /// 添加窗口
        /// </summary>
        /// <param name="ctrlName"></param>
        private void AddControl(string ctrlName)
        {

            string ctrlPath = _assemblyString + ".UserControls." + ctrlName;

            UserControl userControl = (UserControl)Assembly.Load(_assemblyString).CreateInstance(ctrlPath);

            if (userControl != null)
            {
                //移除控件
                for (int i = panel_Main.Controls.Count; i > 0; i--)
                {
                    panel_Main.Controls[i - 1].Dispose();
                }

                //平铺
                userControl.Dock = DockStyle.Fill;
                //把obj的父窗体指定为主窗口
                userControl.Parent = this;

                if (userControl.GetType() == typeof(UC_RoleMenusManage))
                {
                    //设置位置
                    userControl.Location = new Point(0, 0);
                    userControl.Dock = DockStyle.None;
                }

                //添加用户控件
                panel_Main.Controls.Add(userControl);
            }

        }

        #endregion

        #region 窗口函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {

            #region 全局捕获异常
            try
            {

                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(CommonClass.Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CommonClass.CurrentDomain_UnhandledException);
                //设置应用程序处理异常方式：ThreadException处理，处理未捕获的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            }
            catch
            {
                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //只要在线程上创建了任何控件，则线程异常模式将不能再有任何更改。
            }
            #endregion

            _menusBll = new MenusBll();
            Init_TreeViewMenu();

        }

        /// <summary>
        /// 选中菜单
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
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_Edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_EditPwd frmEditPwd = new Frm_EditPwd(_curUsers);
            frmEditPwd.Show();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_Logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("您是否要退出登录？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
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