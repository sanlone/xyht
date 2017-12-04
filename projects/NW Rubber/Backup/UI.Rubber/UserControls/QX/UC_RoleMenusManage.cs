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

        #region 私有字段

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
        /// 当前选中权限类型
        /// </summary>
        private MenuType _curMenuType = null;
        /// <summary>
        /// 当前选中角色
        /// </summary>
        private Roles _curRole = null;
        /// <summary>
        /// 当前选中角色权限
        /// </summary>
        private RoleMenus _curRoleMenus = null;

        /// <summary>
        /// 权限字典
        /// </summary>
        private Dictionary<int, Menus> _dicDataGridView = null;

        #endregion

        #region 公共属性

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public UC_RoleMenusManage()
        {
            InitializeComponent();
        }

        #endregion

        #region 私有函数

        /// <summary>
        /// 初始化角色
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

            //展开节点
            treeView_Roles.ExpandAll();
        }
        /// <summary>
        /// 添加角色子节点
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
        /// 初始化权限菜单
        /// </summary>
        private void Init_TreeViewMenus(int menuTypeID)
        {
            treeView_Menus.Nodes.Clear();
            //同时清空DataGridView
            dataGridView_Menus.Rows.Clear();
            _dicDataGridView = new Dictionary<int, Menus>();

            MenuType menuTpye = _menuTypeBll.GetModel(menuTypeID);

            TreeNode node = new TreeNode();

            node = new TreeNode();
            node.Text = menuTpye.MenuTypeName;
            node.Tag = menuTpye;

            treeView_Menus.Nodes.Add(node);

            GetMenusChildNodes(node, menuTpye.MenuTypeID, 0);

            //展开节点
            treeView_Menus.ExpandAll();


        }
        /// <summary>
        /// 添加角色子节点
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
        /// 初始化菜单列表
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
        /// 选中子节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;

                #region 添加权限字典

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
        /// 获取顶级节点
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
        /// 保存用户角色权限
        /// </summary>
        /// <param name="strRoles"></param>
        /// <returns></returns>
        private int EditRoleMenus(string strMenus)
        {
            if (_curRoleMenus.RoleMenuID == 0)
            {
                //添加
                _curRoleMenus.RoleID = _curRole.RoleID;
                _curRoleMenus.MenuList = strMenus;
                _curRoleMenus.Description = "";
                return _roleMenusBll.AddModel(_curRoleMenus);
            }
            else
            {
                //修改
                _curRoleMenus.MenuList = strMenus;
                return _roleMenusBll.EditModel(_curRoleMenus);
            }
        }

        #endregion

        #region 窗口事件

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

            //初始化
            Init_TreeViewRoles();
            //初始化
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
            //获取根节点MenuType实体
            TreeNode parentNode = GetMenuTypeNode(e.Node);

            _curMenuType = ((MenuType)parentNode.Tag);

            //判断是否为角色节点
            if (e.Node.Parent != null)
            {
                _curRole = (Roles)e.Node.Tag;
                //查询角色权限
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
            //遍历所有子节点
            foreach (TreeNode node in treeView_Menus.Nodes[0].Nodes)
            {
                //判断是否选中
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
                //判断是否为权限节点
                if (e.Node.Parent != null)
                {
                    #region 添加权限字典

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

                //选中子节点
                CheckAllChildNodes(e.Node, e.Node.Checked);

                bool bCheck = true;

                if (e.Node.Parent != null)
                {
                    //遍历同级节点是否全选
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                        {
                            bCheck = false;
                        }
                    }
                    //选中父节点
                    e.Node.Parent.Checked = bCheck;
                }

                //设置DataGridView
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            //判断是否选中角色
            if (treeView_Roles.SelectedNode == null)
            {
                MessageBox.Show("请选择角色", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (treeView_Roles.SelectedNode.Parent == null)
            {
                MessageBox.Show("角色错误，请重新选择！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //判断是否添加权限
            if (dataGridView_Menus.Rows.Count == 0)
            {
                MessageBox.Show("请添加权限", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder strMenus = new StringBuilder();

            //循环遍历权限菜单设置
            for (int i = 0; i < dataGridView_Menus.Rows.Count; i++)
            {
                strMenus.AppendFormat("{0}&1{1}{2}{3},"
                    , dataGridView_Menus.Rows[i].Cells["MenuID"].Value
                    , Convert.ToBoolean(dataGridView_Menus.Rows[i].Cells["AddColumn"].Value) ? "1" : "0"
                    , Convert.ToBoolean(dataGridView_Menus.Rows[i].Cells["UpdateColumn"].Value) ? "1" : "0"
                    , Convert.ToBoolean(dataGridView_Menus.Rows[i].Cells["DeleteColumn"].Value) ? "1" : "0");
            }

            strMenus.Remove(strMenus.Length - 1, 1);

            //添加到角色权限表
            if (EditRoleMenus(strMenus.ToString()) > 0)
            {
                MessageBox.Show("保存成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

    }
}
