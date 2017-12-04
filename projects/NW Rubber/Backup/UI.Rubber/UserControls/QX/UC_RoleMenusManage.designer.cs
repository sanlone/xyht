namespace NWR.UI.UserControls
{
    partial class UC_RoleMenusManage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView_Roles = new System.Windows.Forms.TreeView();
            this.treeView_Menus = new System.Windows.Forms.TreeView();
            this.button_Save = new System.Windows.Forms.Button();
            this.imageList_None = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView_Menus = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MenuID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AddColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UpdateColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Menus)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_Roles
            // 
            this.treeView_Roles.HideSelection = false;
            this.treeView_Roles.Location = new System.Drawing.Point(3, 21);
            this.treeView_Roles.Name = "treeView_Roles";
            this.treeView_Roles.Size = new System.Drawing.Size(180, 381);
            this.treeView_Roles.TabIndex = 0;
            this.treeView_Roles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Roles_AfterSelect);
            // 
            // treeView_Menus
            // 
            this.treeView_Menus.CheckBoxes = true;
            this.treeView_Menus.HideSelection = false;
            this.treeView_Menus.Location = new System.Drawing.Point(189, 21);
            this.treeView_Menus.Name = "treeView_Menus";
            this.treeView_Menus.Size = new System.Drawing.Size(180, 381);
            this.treeView_Menus.TabIndex = 1;
            this.treeView_Menus.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Menus_AfterCheck);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(625, 413);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(78, 36);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // imageList_None
            // 
            this.imageList_None.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_None.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_None.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dataGridView_Menus
            // 
            this.dataGridView_Menus.AllowUserToAddRows = false;
            this.dataGridView_Menus.AllowUserToDeleteRows = false;
            this.dataGridView_Menus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Menus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuID,
            this.MenuName,
            this.SelectColumn,
            this.AddColumn,
            this.UpdateColumn,
            this.DeleteColumn});
            this.dataGridView_Menus.Location = new System.Drawing.Point(377, 21);
            this.dataGridView_Menus.Name = "dataGridView_Menus";
            this.dataGridView_Menus.ReadOnly = true;
            this.dataGridView_Menus.RowHeadersVisible = false;
            this.dataGridView_Menus.RowTemplate.Height = 23;
            this.dataGridView_Menus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Menus.Size = new System.Drawing.Size(364, 381);
            this.dataGridView_Menus.TabIndex = 7;
            this.dataGridView_Menus.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_Menus_CellFormatting);
            this.dataGridView_Menus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Menus_CellClick);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "角色列表";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(189, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "权限列表";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(375, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "权限设置";
            // 
            // MenuID
            // 
            this.MenuID.HeaderText = "权限编号";
            this.MenuID.Name = "MenuID";
            this.MenuID.ReadOnly = true;
            this.MenuID.Visible = false;
            // 
            // MenuName
            // 
            this.MenuName.HeaderText = "权限名称";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            this.MenuName.Width = 200;
            // 
            // SelectColumn
            // 
            this.SelectColumn.HeaderText = "查看";
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.ReadOnly = true;
            this.SelectColumn.Width = 40;
            // 
            // AddColumn
            // 
            this.AddColumn.HeaderText = "添加";
            this.AddColumn.Name = "AddColumn";
            this.AddColumn.ReadOnly = true;
            this.AddColumn.Width = 40;
            // 
            // UpdateColumn
            // 
            this.UpdateColumn.HeaderText = "修改";
            this.UpdateColumn.Name = "UpdateColumn";
            this.UpdateColumn.ReadOnly = true;
            this.UpdateColumn.Width = 40;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "删除";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            this.DeleteColumn.Width = 40;
            // 
            // UC_RoleMenusManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Menus);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.treeView_Menus);
            this.Controls.Add(this.treeView_Roles);
            this.Name = "UC_RoleMenusManager";
            this.Size = new System.Drawing.Size(745, 460);
            this.Load += new System.EventHandler(this.UC_RoleMenusManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Menus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Roles;
        private System.Windows.Forms.TreeView treeView_Menus;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ImageList imageList_None;
        private System.Windows.Forms.DataGridView dataGridView_Menus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AddColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UpdateColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeleteColumn;
    }
}
