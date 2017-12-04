using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NWR.BLL;
using NWR.Model;

namespace NWR.UI.UserControls
{
    public partial class UC_MenuManage : UserControl
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
        /// 当前选中菜单类型
        /// </summary>
        private MenuType _curMenuType = null;
        /// <summary>
        /// 当前选中菜单
        /// </summary>
        private Menus _curMenus = null;

        #endregion

        #region 公共属性

        #endregion

        #region 构造函数

        /// <summary>
        /// 基础构造
        /// </summary>
        public UC_MenuManage()
        {
            InitializeComponent();
        }

        #endregion

        #region 对外接口

        #endregion

        #region 私有函数

        /// <summary>
        /// 初始化菜单树
        /// </summary>
        private void Init_TreeViewMenu()
        {

            treeView_Menus.Nodes.Clear();

            List<MenuType> lsMenuType = _menuTypeBll.GetModel();

            TreeNode node = null;

            for (int i = 0; i < lsMenuType.Count; i++)
            {
                node = new TreeNode();
                node.Expand();
                node.Text = lsMenuType[i].MenuTypeName;
                node.Tag = lsMenuType[i];

                treeView_Menus.Nodes.Add(node);

                GetChildNodes(node, lsMenuType[i].MenuTypeID, 0);
            }

            //展开节点
            treeView_Menus.ExpandAll();

            //设置选中首个节点

        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        private void GetChildNodes(TreeNode parentNode, int menuTypeID, int parentID)
        {
            List<Menus> lsMenus = _menusBll.GetModel(menuTypeID, parentID);

            TreeNode node = null;

            for (int i = 0; i < lsMenus.Count; i++)
            {
                node = new TreeNode();
                node.Text = lsMenus[i].MenuName;
                //node.Name = lsMenus[i].MenuPath;
                node.Tag = lsMenus[i];

                parentNode.Nodes.Add(node);

                GetChildNodes(node, menuTypeID, lsMenus[i].MenuID);
            }
        }

        #endregion

        #region 窗口事件

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_MenuManager_Load(object sender, EventArgs e)
        {
            _menuTypeBll = new MenuTypeBll();
            _menusBll = new MenusBll();

            Init_TreeViewMenu();
        }

        /// <summary>
        /// 树节点选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Menus_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {

                button_Edit.Enabled = false;

                if (e.Node.Parent == null)
                {
                    _curMenuType = (MenuType)e.Node.Tag;
                    textBox_ParentName.Text = _curMenuType.MenuTypeName;
                    textBox_MenuName.Text = "";
                    textBox_MenuPath.Text = "";
                    textBox_ImagePath.Text = "";
                    textBox_Description.Text = "";
                }
                else
                {
                    _curMenus = (Menus)e.Node.Tag;

                    textBox_ParentName.Text = e.Node.Parent.Text;
                    textBox_MenuName.Text = _curMenus.MenuName.ToString();
                    textBox_MenuPath.Text = _curMenus.MenuPath;
                    textBox_ImagePath.Text = _curMenus.ImagePath;
                    textBox_Description.Text = _curMenus.Description;
                    button_Edit.Enabled = true;
                }

            }
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Edit_Click(object sender, EventArgs e)
        {

            Menus model = (Menus)_curMenus.Clone();

            model.MenuName = textBox_MenuName.Text;
            model.MenuPath = textBox_MenuPath.Text;
            model.ImagePath = textBox_ImagePath.Text;
            model.Description = textBox_Description.Text;

            if (_menusBll.EditModel(model) > 0)
            {
                Init_TreeViewMenu();
                MessageBox.Show("操作成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("操作失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ReSet_Click(object sender, EventArgs e)
        {
            textBox_MenuName.Text = _curMenus.MenuName;
            textBox_MenuPath.Text = _curMenus.MenuPath;
            textBox_ImagePath.Text = _curMenus.ImagePath;
            textBox_Description.Text = _curMenus.Description;
        }


        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {

            if (treeView_Menus.SelectedNode == null)
            {
                return;
            }

            Menus model = new Menus();

            model.MenuTypeID = _curMenuType.MenuTypeID;
            //判断上级节点
            model.ParentID = treeView_Menus.SelectedNode.Parent == null ? 0 : _curMenus.MenuID;
            model.MenuName = _curMenuType.MenuTypeName + (treeView_Menus.SelectedNode.Nodes.Count + 1).ToString();
            model.MenuPath = "";
            model.ImagePath = "";
            model.Sort = treeView_Menus.SelectedNode.Nodes.Count + 1;
            model.Description = "";

            if (_menusBll.AddModel(model) > 0)
            {
                Init_TreeViewMenu();
            }
            else
            {
                MessageBox.Show("操作失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Up_Click(object sender, EventArgs e)
        {
            if (treeView_Menus.SelectedNode == null
                || treeView_Menus.SelectedNode.Index == 0
                || treeView_Menus.SelectedNode.Parent == null)
            {
                return;
            }

            TreeNode curNode = treeView_Menus.SelectedNode;
            TreeNode newNode = (TreeNode)curNode.Clone();

            //获取选中node
            Menus model = (Menus)treeView_Menus.SelectedNode.Tag;
            //上移
            if (_menusBll.UpdateSort(model, -1) < 0)
            {
                MessageBox.Show("操作失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Sort--;
            curNode.Parent.Nodes.Insert(model.Sort - 1, newNode);
            curNode.Remove();
            treeView_Menus.SelectedNode = newNode;

        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Down_Click(object sender, EventArgs e)
        {
            if (treeView_Menus.SelectedNode == null
                || treeView_Menus.SelectedNode.NextNode == null
                || treeView_Menus.SelectedNode.Parent == null)
            {
                return;
            }

            TreeNode curNode = treeView_Menus.SelectedNode;
            TreeNode newNode = (TreeNode)curNode.Clone();

            //获取选中node
            Menus model = (Menus)curNode.Tag;

            //下移
            if (_menusBll.UpdateSort(model, 1) < 0)
            {
                MessageBox.Show("操作失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Sort++;
            curNode.Parent.Nodes.Insert(model.Sort, newNode);
            curNode.Remove();
            treeView_Menus.SelectedNode = newNode;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {

            if (treeView_Menus.SelectedNode == null || treeView_Menus.SelectedNode.Parent == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("确认要删除", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (_menusBll.DelteModel(_curMenus.MenuID) > 0)
                {
                    Init_TreeViewMenu();
                }
                else
                {
                    MessageBox.Show("操作失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        #endregion

    }
}
