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
    public partial class UC_RoleManage : UserControl
    {

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private MenuTypeBll _menuTypeBll = null;
        /// <summary>
        /// 
        /// </summary>
        private RolesBll _rolesBll = null;

        /// <summary>
        /// ��ǰѡ�в˵�����
        /// </summary>
        private MenuType _curMenuType = null;
        /// <summary>
        /// ��ǰѡ�в˵�
        /// </summary>
        private Roles _curRoles = null;

        #endregion

        #region ��������

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UC_RoleManage()
        {
            InitializeComponent();
        }

        #endregion

        #region ����ӿ�

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��ʼ���˵���
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

            //����ѡ���׸��ڵ�
        }

        /// <summary>
        /// ��ȡ���ڵ�
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

                parentNode.Nodes.Add(node);

                GetChildNodes(node, menuTypeID, lsRoles[i].RoleID);
            }
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_RoleManager_Load(object sender, EventArgs e)
        {
            _menuTypeBll = new MenuTypeBll();
            _rolesBll = new RolesBll();

            Init_TreeViewRoles();
        }

        /// <summary>
        /// �ڵ�ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Role_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {

                button_Edit.Enabled = false;

                if (e.Node.Parent == null)
                {
                    _curMenuType = (MenuType)e.Node.Tag;
                    textBox_MenuTypeName.Text = _curMenuType.MenuTypeName;
                    textBox_RoleName.Text = "";
                    textBox_Description.Text = "";
                }
                else
                {
                    _curRoles = (Roles)e.Node.Tag;

                    textBox_RoleName.Text = _curRoles.RoleName;
                    textBox_Description.Text = _curRoles.Description;
                    button_Edit.Enabled = true;
                }

            }
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (treeView_Roles.SelectedNode == null)
            {
                return;
            }

            Roles model = new Roles();

            model.MenuTypeID = _curMenuType.MenuTypeID;
            //�ж��ϼ��ڵ�
            model.ParentID = treeView_Roles.SelectedNode.Parent == null ? 0 : _curRoles.RoleID;
            model.RoleName = _curMenuType.MenuTypeName + (treeView_Roles.SelectedNode.Nodes.Count + 1).ToString();
            model.Sort = treeView_Roles.SelectedNode.Nodes.Count + 1;
            model.Description = "";

            if (_rolesBll.AddModel(model) > 0)
            {
                Init_TreeViewRoles();
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
        private void toolStripButton_Up_Click(object sender, EventArgs e)
        {
            if (treeView_Roles.SelectedNode == null
                || treeView_Roles.SelectedNode.Index == 0
                || treeView_Roles.SelectedNode.Parent == null)
            {
                return;
            }

            TreeNode curNode = treeView_Roles.SelectedNode;
            TreeNode newNode = (TreeNode)curNode.Clone();

            //��ȡѡ��node
            Roles model = (Roles)treeView_Roles.SelectedNode.Tag;
            //����
            if (_rolesBll.UpdateSort(model, -1) < 0)
            {
                MessageBox.Show("����ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Sort--;
            curNode.Parent.Nodes.Insert(model.Sort - 1, newNode);
            curNode.Remove();
            treeView_Roles.SelectedNode = newNode;




        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Down_Click(object sender, EventArgs e)
        {
            if (treeView_Roles.SelectedNode == null
                 || treeView_Roles.SelectedNode.NextNode == null
                 || treeView_Roles.SelectedNode.Parent == null)
            {
                return;
            }

            TreeNode curNode = treeView_Roles.SelectedNode;
            TreeNode newNode = (TreeNode)curNode.Clone();

            //��ȡѡ��node
            Roles model = (Roles)curNode.Tag;

            //����
            if (_rolesBll.UpdateSort(model, 1) < 0)
            {
                MessageBox.Show("����ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Sort++;
            curNode.Parent.Nodes.Insert(model.Sort, newNode);
            curNode.Remove();
            treeView_Roles.SelectedNode = newNode;
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            if (treeView_Roles.SelectedNode == null || treeView_Roles.SelectedNode.Parent == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("ȷ��Ҫɾ��", "ϵͳ��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (_rolesBll.DelteModel(_curRoles.RoleID) > 0)
                {
                    Init_TreeViewRoles();
                }
                else
                {
                    MessageBox.Show("����ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Edit_Click(object sender, EventArgs e)
        {
            Roles model = (Roles)_curRoles.Clone();

            model.RoleName = textBox_RoleName.Text;
            model.Description = textBox_Description.Text;

            if (_rolesBll.EditModel(model) > 0)
            {
                Init_TreeViewRoles();
                MessageBox.Show("�����ɹ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void button_ReSet_Click(object sender, EventArgs e)
        {
            if (_curRoles != null)
            {
                textBox_RoleName.Text = _curRoles.RoleName;
                textBox_Description.Text = _curRoles.Description;
            }
        }

        #endregion




    }
}
