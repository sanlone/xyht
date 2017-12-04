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

        #region 私有字段

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
        /// 用户权限字典
        /// </summary>
        private Dictionary<int, UserPermissions> _dicRoleMenus = null;

        #endregion

        #region 公共属性

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化窗口
        /// </summary>
        public Frm_Login()
        {
            InitializeComponent();
        }

        #endregion

        #region 对外接口

        #endregion

        #region 私有函数

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        private bool GetUserRoleMenus(int userID)
        {

            _dicRoleMenus = new Dictionary<int, UserPermissions>();

            UserRoles userRoles = null;
            RoleMenus roleMenus = null;
            string[] ayyRoles = new string[0] { };

            //获取用户角色
            userRoles = _userRolesBll.GetModel(userID);

            if (userRoles == null || string.IsNullOrEmpty(userRoles.RoleID))
            {
                return false;
            }

            ayyRoles = userRoles.RoleID.Split(',');

            for (int i = 0; i < ayyRoles.Length; i++)
            {
                //获取角色权限
                roleMenus = _roleMenusBll.GetModel(Convert.ToInt32(ayyRoles[i]));

                foreach (int key in roleMenus.DicPermissions.Keys)
                {
                    if (!_dicRoleMenus.ContainsKey(key))
                    {
                        //添加到权限字典
                        _dicRoleMenus.Add(key, roleMenus.DicPermissions[key]);
                    }
                }

            }

            return true;

        }

        #endregion

        #region 窗口事件

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

        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Login_Click(object sender, EventArgs e)
        {

            //登录
            string account = textBox_Account.Text.Trim();
            string pwd = textBox_PassWord.Text;

            if (account.Length < 2)
            {
                label_AccountErr.Text = "账号错误";
                label_PwdErr.Text = "";
                return;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                label_AccountErr.Text = "";
                label_PwdErr.Text = "密码不能为空";
                return;
            }

            Users curUser = _usersBll.GetModel(account);

            if (curUser == null || curUser.UserAccount == null)
            {
                label_AccountErr.Text = "账号错误";
                label_PwdErr.Text = "";
                return;
            }

            pwd = _usersBll.GetMD5(textBox_PassWord.Text);
            //对比加密密码
            if (pwd.Length != curUser.Password.Length || !pwd.Equals(curUser.Password))
            {
                label_AccountErr.Text = "";
                label_PwdErr.Text = "密码错误";
                return;
            }

            if (!GetUserRoleMenus(curUser.UserID))
            {
                MessageBox.Show("用户状态有误，请联系管理员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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