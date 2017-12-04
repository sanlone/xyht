using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// 用户表 QX_Users
    /// </summary>
    public class Users
    {

        public Users() { }

        #region Model

        private int _userID;
        private string _userAccount;
        private string _password;
        private string _userName;
        private int _sex;
        private DateTime _birthday;
        private string _phone;
        private string _email;
        private string _employeeID;
        private int _departmentID;
        private DateTime _entryDate;
        private EnumUserType _userType;
        private DateTime _deleteDate;
        private string _deleteReason;
        private int _deleteUserID;
        private string _remark;


        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount
        {
            get { return _userAccount; }
            set { _userAccount = value; }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        /// <summary>
        /// 用户状态
        /// </summary>
        public EnumUserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime DeleteDate
        {
            get { return _deleteDate; }
            set { _deleteDate = value; }
        }

        /// <summary>
        /// 删除原因
        /// </summary>
        public string DeleteReason
        {
            get { return _deleteReason; }
            set { _deleteReason = value; }
        }

        /// <summary>
        /// 删除人员编号
        /// </summary>
        public int DeleteUserID
        {
            get { return _deleteUserID; }
            set { _deleteUserID = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        #endregion

    }
}
