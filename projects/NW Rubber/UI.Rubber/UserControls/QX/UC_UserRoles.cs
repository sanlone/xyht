using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NWR.Model;
using NWR.BLL;

namespace NWR.UI.UserControls
{
    public partial class UC_UserRoles : UserControl
    {

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private MenuTypeBll _menuTypeBll = null;

        /// <summary>
        /// 
        /// </summary>
        private UserRolesBll _userRolesBll = null;

        /// <summary>
        /// 
        /// </summary>
        private RolesBll _rolesBll = null;

        /// <summary>
        /// �û���ɫ
        /// </summary>
        public UserRoles _curUserRoles = null;

        /// <summary>
        /// ��ǰ�û���ɫ��Ϣ
        /// </summary>
        private List<int> _arrRoles = new List<int>();

        /// <summary>
        /// �û���Ϣ
        /// </summary>
        private Users _user = null;

        #endregion

        #region ��������
        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UC_UserRoles()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public UC_UserRoles(Users model)
        {
            InitializeComponent();
            _user = model;
        }

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��ʼ����ɫ��
        /// </summary>
        private void Init_TreeViewRoles()
        {
            treeView_Roles.Nodes.Clear();

            List<MenuType> lsMenuType = _menuTypeBll.GetModel();

            TreeNode node = null;

            for (int i = 0; i < lsMenuType.Count; i++)
            {
                node = new TreeNode();
                node.Text = lsMenuType[i].MenuTypeName;
                node.Tag = lsMenuType[i];

                treeView_Roles.Nodes.Add(node);

                GetChildNodes(node, lsMenuType[i].MenuTypeID, 0);
            }

            //չ���ڵ�
            treeView_Roles.ExpandAll();

        }
        /// <summary>
        /// ��ȡ�ӽڵ�
        /// </summary>
        private void GetChildNodes(TreeNode parentNode, int menuTypeID, int parentID)
        {
            List<Roles> lsRoles = _rolesBll.GetModel(menuTypeID, parentID);

            TreeNode node = null;

            for (int i = 0; i < lsRoles.Count; i++)
            {
                node = new TreeNode();
                node.Text = lsRoles[i].RoleName;
                node.Tag = lsRoles[i];
                if (_arrRoles.Contains(lsRoles[i].RoleID))
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }

                parentNode.Nodes.Add(node);

                //ѡ�и��ڵ�
                treeView_Roles_AfterCheck(this, new TreeViewEventArgs(node, TreeViewAction.ByMouse));

                GetChildNodes(node, menuTypeID, lsRoles[i].RoleID);
            }
        }

        /// <summary>
        /// ��ȡ�û���ɫ
        /// </summary>
        private void GetUserRolesByUserID()
        {
            _curUserRoles = _userRolesBll.GetModel(_user.UserID);

            if (!string.IsNullOrEmpty(_curUserRoles.RoleID))
            {
                string[] strRoles = _curUserRoles.RoleID.Split(',');

                for (int i = 0; i < strRoles.Length; i++)
                {
                    _arrRoles.Add(Convert.ToInt32(strRoles[i]));
                }

            }
        }

        /// <summary>
        /// ѡ���ӽڵ�
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        /// <summary>
        /// ����ÿ���ڵ�
        /// </summary>
        /// <param name="strRoles"></param>
        private void EachTreeNode(TreeNode pranetNode, ref StringBuilder strRoles)
        {
            //�������нڵ�
            foreach (TreeNode node in pranetNode.Nodes)
            {
                if (node.Tag != null)
                {
                    if (node.Checked)
                    {
                        strRoles.AppendFormat("{0},", (((Roles)node.Tag).RoleID.ToString()));
                    }
                }

                if (node.Nodes.Count > 0)
                {
                    EachTreeNode(node, ref strRoles);
                }
            }
        }

        /// <summary>
        /// �����û���ɫ
        /// </summary>
        /// <param name="strRoles"></param>
        /// <returns></returns>
        private int EditUserRoles(string strRoles)
        {
            if (_curUserRoles.UserRoleID == 0)
            {
                //���
                _curUserRoles.UserID = _user.UserID;
                _curUserRoles.RoleID = strRoles;
                _curUserRoles.Description = "";

                return _userRolesBll.AddModel(_curUserRoles);
            }
            else
            {
                //�޸�
                _curUserRoles.RoleID = strRoles;
                return _userRolesBll.EditModel(_curUserRoles);
            }
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_UserRoles_Load(object sender, EventArgs e)
        {
            //��ʼ��
            _menuTypeBll = new MenuTypeBll();
            _userRolesBll = new UserRolesBll();
            _rolesBll = new RolesBll();

            if (_user != null)
            {
                label_UserName.Text = _user.UserName;
                label_EmployeeID.Text = _user.EmployeeID;
                label_Sex.Text = _user.Sex == 0 ? "��" : "Ů";
                label_DepartmentName.Text = _user.DepartmentID.ToString();

                switch (_user.UserType.GetHashCode())
                {
                    case 0: label_UserType.Text = "������"; break;
                    case 1: label_UserType.Text = "��ʱԱ��"; break;
                    case 2: label_UserType.Text = "��ʽԱ��"; break;
                    case 3: label_UserType.Text = "����ְ"; break;
                    case 4: label_UserType.Text = "��ͣ��"; break;
                }
            }

            //��ȡ�û���ɫ
            GetUserRolesByUserID();
            //��ʼ��
            Init_TreeViewRoles();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Roles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
                //ѡ�и��ڵ� 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                            bol = false;
                    }
                    e.Node.Parent.Checked = bol;
                }
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {

            StringBuilder strRoles = new StringBuilder();

            //�������нڵ�
            foreach (TreeNode node in treeView_Roles.Nodes)
            {
                //���������ڵ�

                //�����ӽڵ�
                if (node.Nodes.Count > 0)
                {
                    EachTreeNode(node, ref strRoles);
                }
            }

            if (strRoles.Length > 0)
            {
                strRoles.Remove(strRoles.Length - 1, 1);
            }

            if (EditUserRoles(strRoles.ToString()) > 0)
            {
                MessageBox.Show("����ɹ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("����ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            ((Frm_Main)this.ParentForm).OpenUserManagerForm(1);
        }

        #endregion

    }
}
