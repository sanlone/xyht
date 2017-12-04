using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NWR.Model;
using NWR.BLL;

namespace NWR.UI
{
    public partial class Frm_EditPwd : Form
    {

        #region 私有字段

        /// <summary>
        /// 当前用户
        /// </summary>
        private Users _curUser = null;

        /// <summary>
        /// 
        /// </summary>
        private UsersBll _usersBll = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_EditPwd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_EditPwd(Users model)
        {
            InitializeComponent();
            _curUser = model;
        }

        #endregion

        #region 窗口事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_EditPwd_Load(object sender, EventArgs e)
        {
            if (_curUser == null)
            {
                return;
            }

            _usersBll = new UsersBll();
            textBox_UserAccount.Text = _curUser.UserAccount;

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            string pwd_old = textBox_Pwd_Old.Text;
            string pwd_new = textBox_Pwd_New.Text;
            string pwd_new2 = textBox_Pwd_New2.Text;

            label_Err_Pwd_Old.Text = "";
            label_Err_Pwd_New.Text = "";
            label_Err_Pwd_New2.Text = "";

            #region 密码验证

            if (string.IsNullOrEmpty(pwd_old))
            {
                label_Err_Pwd_Old.Text = "原密码不能为空";
                return;
            }
            label_Err_Pwd_Old.Text = "";

            if (string.IsNullOrEmpty(pwd_new))
            {
                label_Err_Pwd_New.Text = "新密码不能为空";
                return;
            }
            label_Err_Pwd_New.Text = "";

            if (pwd_new != pwd_new2)
            {
                label_Err_Pwd_New2.Text = "两次密码不一致";
                return;
            }
            label_Err_Pwd_New2.Text = "";



            pwd_old = _usersBll.GetMD5(pwd_old);

            if (pwd_old != _curUser.Password)
            {
                label_Err_Pwd_Old.Text = "原密码错误";
                return;
            }
            label_Err_Pwd_Old.Text = "";

            #endregion

            pwd_new = _usersBll.GetMD5(pwd_new);

            if (_usersBll.EditPwd(_curUser, pwd_new) > 0)
            {
                _curUser.Password = pwd_new;
                this.Dispose();
            }
            else
            {
                label_Err_Pwd_New.Text = "密码修改失败";
            }

        }
        #endregion

    }
}