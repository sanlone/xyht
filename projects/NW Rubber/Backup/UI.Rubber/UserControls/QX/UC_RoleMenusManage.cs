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
    public partial class UC_RoleMenusManage : UserControl
    {

        #region ˽���ֶ�

        /// <summary>
        /// 
        /// </summary>
        private MenuTypeBll _menuTypeBll = null;
        /// <summary>
        /// 
        /// </summary>
        private MenusBll _menusBll = null;
        /// <summary>
        /// 
        /// </summary>
        private RolesBll _rolesBll = null;
        /// <summary>
        /// 
        /// </summary>
        private RoleMenusBll _roleMenusBll = null;

        /// <summary>
        /// ��ǰѡ��Ȩ������
        /// </summary>
        private MenuType _curMenuType = null;
        /// <summary>
        /// ��ǰѡ�н�ɫ
        /// </summary>
        private Roles _curRole = null;
        /// <summary>
        /// ��ǰѡ�н�ɫȨ��
        /// </summary>
        private RoleMenus _curRoleMenus = null;

        /// <summary>
        /// Ȩ���ֵ�
        /// </summary>
        private Dictionary<int, Menus> _dicDataGridView = null;

        #endregion

        #region ��������

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public UC_RoleMenusManage()
        {
            InitializeComponent();
        }

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��ʼ����ɫ
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

                GetRolesChildNodes(node, lsMenuType[i].MenuTypeID, 0);
            }

            //չ���ڵ�
            treeView_Roles.ExpandAll();
        }
        /// <summary>
        /// ��ӽ�ɫ�ӽڵ�
        /// </summary>
        /// <param name="node"></param>
        /// <param name="menuTypeID"></param>
        /// <param name="parentID"></param>
        private void GetRolesChildNodes(TreeNode parentNode, int menuTypeID, int parentID)
        {
            List<Roles> lsRoles = _rolesBll.GetModel(menuTypeID, parentID);

            TreeNode node = null;

            for (int i = 0; i < lsRoles.Count; i++)
            {
                node = new TreeNode();
                node.Text = lsRoles[i].RoleName;
                node.Tag = lsRoles[i];

                parentNode.Nodes.Add(node);

                GetRolesChildNodes(node, menuTypeID, lsRoles[i].RoleID);
            }
        }

        /// <summary>
        /// ��ʼ��Ȩ�޲˵�
        /// </summary>
        private void Init_TreeViewMenus(int menuTypeID)
        {
            treeView_Menus.Nodes.Clear();
            //ͬʱ���DataGridView
            dataGridView_Menus.Rows.Clear();
            _dicDataGridView = new Dictionary<int, Menus>();

            MenuType menuTpye = _menuTypeBll.GetModel(menuTypeID);

            TreeNode node = new TreeNode();

            node = new TreeNode();
            node.Text = menuTpye.MenuTypeName;
            node.Tag = menuTpye;

            treeView_Menus.Nodes.Add(node);

            GetMenusChildNodes(node, menuTpye.MenuTypeID, 0);

            //չ���ڵ�
            treeView_Menus.ExpandAll();


        }
        /// <summary>
        /// ��ӽ�ɫ�ӽڵ�
        /// </summary>
        /// <param name="node"></param>
        /// <param name="menuTypeID"></param>
        /// <param name="parentID"></param>
        private void GetMenusChildNodes(TreeNode parentNode, int menuTypeID, int parentID)
        {
            List<Menus> lsRoles = _menusBll.GetModel(menuTypeID, parentID);

            TreeNode node = null;

            for (int i = 0; i < lsRoles.Count; i++)
            {
                node = new TreeNode();
                node.Text = lsRoles[i].MenuName;
                node.Tag = lsRoles[i];

                parentNode.Nodes.Add(node);

                GetRolesChildNodes(node, menuTypeID, lsRoles[i].MenuID);
            }
        }

        /// <summary>
        /// ��ʼ���˵��б�
        /// </summary>
        private void Init_DataGridViewMenus()
        {
            dataGridView_Menus.Rows.Clear();

            int rowindex = 0;

            foreach (int key in _dicDataGridView.Keys)
            {
                rowindex = dataGridView_Menus.Rows.Add();

                dataGridView_Menus.Rows[rowindex].Cells["MenuID"].Value = _dicDataGridView[key].MenuID;
                dataGridView_Menus.Rows[rowindex].Cells["MenuName"].Value = _dicDataGridView[key].MenuName;

                if (_curRoleMenus != null && _curRoleMenus.DicPermissions.ContainsKey(_dicDataGridView[key].MenuID))
                {
                    dataGridView_Menus.Rows[rowindex].Cells["SelectColumn"].Value = _curRoleMenus.DicPermissions[_dicDataGridView[key].MenuID].Select;
                    dataGridView_Menus.Rows[rowindex].Cells["AddColumn"].Value = _curRoleMenus.DicPermissions[_dicDataGridView[key].MenuID].Add;
                    dataGridView_Menus.Rows[rowindex].Cells["UpdateColumn"].Value = _curRoleMenus.DicPermissions[_dicDataGridView[key].MenuID].Update;
                    dataGridView_Menus.Rows[rowindex].Cells["DeleteColumn"].Value = _curRoleMenus.DicPermissions[_dicDataGridView[key].MenuID].Delete;
                }
                else
                {
                    dataGridView_Menus.Rows[rowindex].Cells["SelectColumn"].Value = 1;
                    dataGridView_Menus.Rows[rowindex].Cells["AddColumn"].Value = 1;
                    dataGridView_Menus.Rows[rowindex].Cells["UpdateColumn"].Value = 1;
                    dataGridView_Menus.Rows[rowindex].Cells["DeleteColumn"].Value = 1;
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

                #region ���Ȩ���ֵ�

                Menus model = (Menus)node.Tag;

                if (nodeChecked)
                {
                    if (!_dicDataGridView.ContainsKey(model.MenuID))
                    {
                        _dicDataGridView.Add(model.MenuID, model);
                    }
                }
                else
                {
                    if (_dicDataGridView.ContainsKey(model.MenuID))
                    {
                        _dicDataGridView.Remove(model.MenuID);
                    }
                }

                #endregion

                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        /// <summary>
        /// ��ȡ�����ڵ�
        /// </summary>
        /// <param name="e"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private TreeNode GetMenuTypeNode(TreeNode node)
        {
            if (node.Parent != null)
            {
                return GetMenuTypeNode(node.Parent);
            }
            else
            {
                return node;
            }
        }

        /// <summary>
        /// �����û���ɫȨ��
        /// </summary>
        /// <param name="strRoles"></param>
        /// <returns></returns>
        private int EditRoleMenus(string strMenus)
        {
            if (_curRoleMenus.RoleMenuID == 0)
            {
                //���
                _curRoleMenus.RoleID = _curRole.RoleID;
                _curRoleMenus.MenuList = strMenus;
                _curRoleMenus.Description = "";
                return _roleMenusBll.AddModel(_curRoleMenus);
            }
            else
            {
                //�޸�
                _curRoleMenus.MenuList = strMenus;
                return _roleMenusBll.EditModel(_curRoleMenus);
            }
        }

        #endregion

        #region �����¼�

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_RoleMenusManager_Load(object sender, EventArgs e)
        {
            _menuTypeBll = new MenuTypeBll();
            _menusBll = new MenusBll();
            _roleMenusBll = new RoleMenusBll();
            _rolesBll = new RolesBll();
            _dicDataGridView = new Dictionary<int, Menus>();

            //��ʼ��
            Init_TreeViewRoles();
            //��ʼ��
            Init_TreeViewMenus(1);

            treeView_Roles.Focus();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Roles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //��ȡ���ڵ�MenuTypeʵ��
            TreeNode parentNode = GetMenuTypeNode(e.Node);

            _curMenuType = ((MenuType)parentNode.Tag);

            //�ж��Ƿ�Ϊ��ɫ�ڵ�
            if (e.Node.Parent != null)
            {
                _curRole = (Roles)e.Node.Tag;
                //��ѯ��ɫȨ��
                _curRoleMenus = _roleMenusBll.GetModel(_curRole.RoleID);

                Init_TreeViewMenus(_curMenuType.MenuTypeID);

                Set_TreeViewMenus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Set_TreeViewMenus()
        {
            //���������ӽڵ�
            foreach (TreeNode node in treeView_Menus.Nodes[0].Nodes)
            {
                //�ж��Ƿ�ѡ��
                if (_curRoleMenus != null && _curRoleMenus.DicPermissions.ContainsKey(((Menus)node.Tag).MenuID))
                {
                    node.Checked = true;
                    treeView_Menus_AfterCheck(this, new TreeViewEventArgs(node, TreeViewAction.ByKeyboard));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Menus_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                //�ж��Ƿ�ΪȨ�޽ڵ�
                if (e.Node.Parent != null)
                {
                    #region ���Ȩ���ֵ�

                    Menus model = (Menus)e.Node.Tag;

                    if (e.Node.Checked)
                    {
                        if (!_dicDataGridView.ContainsKey(model.MenuID))
                        {
                            _dicDataGridView.Add(model.MenuID, model);
                        }
                    }
                    else
                    {
                        if (_dicDataGridView.ContainsKey(model.MenuID))
                        {
                            _dicDataGridView.Remove(model.MenuID);
                        }
                    }

                    #endregion
                }

                //ѡ���ӽڵ�
                CheckAllChildNodes(e.Node, e.Node.Checked);

                bool bCheck = true;

                if (e.Node.Parent != null)
                {
                    //����ͬ���ڵ��Ƿ�ȫѡ
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                        {
                            bCheck = false;
                        }
                    }
                    //ѡ�и��ڵ�
                    e.Node.Parent.Checked = bCheck;
                }

                //����DataGridView
                Init_DataGridViewMenus();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Menus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Menus_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (dataGridView_Menus.Columns[e.ColumnIndex].Name)
            {
                case "AddColumn":
                case "UpdateColumn":
                case "DeleteColumn":
                    if (e.RowIndex > -1)
                    {
                        dataGridView_Menus.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToBoolean(dataGridView_Menus.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) ? false : true;
                    }
                    else
                    {
                        if (dataGridView_Menus.Rows.Count > 0)
                        {
                            bool bCheck = !Convert.ToBoolean(dataGridView_Menus.Rows[0].Cells[e.ColumnIndex].Value);

                            for (int i = 0; i < dataGridView_Menus.Rows.Count; i++)
                            {
                                dataGridView_Menus.Rows[i].Cells[e.ColumnIndex].Value = bCheck;
                            }
                        }
                    }
                    break;
            }

        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�ѡ�н�ɫ
            if (treeView_Roles.SelectedNode == null)
            {
                MessageBox.Show("��ѡ���ɫ", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (treeView_Roles.SelectedNode.Parent == null)
            {
                MessageBox.Show("��ɫ����������ѡ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //�ж��Ƿ����Ȩ��
            if (dataGridView_Menus.Rows.Count == 0)
            {
                MessageBox.Show("�����Ȩ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder strMenus = new StringBuilder();

            //ѭ������Ȩ�޲˵�����
            for (int i = 0; i < dataGridView_Menus.Rows.Count; i++)
            {
                strMenus.AppendFormat("{0}&1{1}{2}{3},"
                    , dataGridView_Menus.Rows[i].Cells["MenuID"].Value
                    , Convert.ToBoolean(dataGridView_Menus.Rows[i].Cells["AddColumn"].Value) ? "1" : "0"
                    , Convert.ToBoolean(dataGridView_Menus.Rows[i].Cells["UpdateColumn"].Value) ? "1" : "0"
                    , Convert.ToBoolean(dataGridView_Menus.Rows[i].Cells["DeleteColumn"].Value) ? "1" : "0");
            }

            strMenus.Remove(strMenus.Length - 1, 1);

            //��ӵ���ɫȨ�ޱ�
            if (EditRoleMenus(strMenus.ToString()) > 0)
            {
                MessageBox.Show("����ɹ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("����ʧ��", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

    }
}
