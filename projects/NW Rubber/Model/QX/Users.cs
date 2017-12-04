using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.Model
{
    /// <summary>
    /// �û��� QX_Users
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
        /// �û����
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        /// <summary>
        /// �û��˺�
        /// </summary>
        public string UserAccount
        {
            get { return _userAccount; }
            set { _userAccount = value; }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// �Ա�
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Ա�����
        /// </summary>
        public string EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        /// <summary>
        /// ���ű��
        /// </summary>
        public int DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }

        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        /// <summary>
        /// �û�״̬
        /// </summary>
        public EnumUserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        public DateTime DeleteDate
        {
            get { return _deleteDate; }
            set { _deleteDate = value; }
        }

        /// <summary>
        /// ɾ��ԭ��
        /// </summary>
        public string DeleteReason
        {
            get { return _deleteReason; }
            set { _deleteReason = value; }
        }

        /// <summary>
        /// ɾ����Ա���
        /// </summary>
        public int DeleteUserID
        {
            get { return _deleteUserID; }
            set { _deleteUserID = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        #endregion

    }
}
