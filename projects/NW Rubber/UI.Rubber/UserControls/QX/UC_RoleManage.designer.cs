namespace NWR.UI.UserControls
{
    partial class UC_RoleManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_RoleManage));
            this.panel_Tree = new System.Windows.Forms.Panel();
            this.toolStrip_Top = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Up = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Down = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.treeView_Roles = new System.Windows.Forms.TreeView();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.label__MenuTypeName = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label_Description = new System.Windows.Forms.Label();
            this.button_ReSet = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.label_RoleName = new System.Windows.Forms.Label();
            this.textBox_MenuTypeName = new System.Windows.Forms.TextBox();
            this.textBox_RoleName = new System.Windows.Forms.TextBox();
            this.panel_Tree.SuspendLayout();
            this.toolStrip_Top.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.groupBox_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Tree
            // 
            this.panel_Tree.Controls.Add(this.toolStrip_Top);
            this.panel_Tree.Controls.Add(this.treeView_Roles);
            this.panel_Tree.Location = new System.Drawing.Point(3, 4);
            this.panel_Tree.Name = "panel_Tree";
            this.panel_Tree.Size = new System.Drawing.Size(257, 473);
            this.panel_Tree.TabIndex = 21;
            // 
            // toolStrip_Top
            // 
            this.toolStrip_Top.AutoSize = false;
            this.toolStrip_Top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Up,
            this.toolStripButton_Down,
            this.toolStripButton_Delete});
            this.toolStrip_Top.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Top.Name = "toolStrip_Top";
            this.toolStrip_Top.Size = new System.Drawing.Size(257, 44);
            this.toolStrip_Top.TabIndex = 1;
            this.toolStrip_Top.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Add.Image")));
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(52, 41);
            this.toolStripButton_Add.Text = "添加";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Up
            // 
            this.toolStripButton_Up.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Up.Image")));
            this.toolStripButton_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Up.Name = "toolStripButton_Up";
            this.toolStripButton_Up.Size = new System.Drawing.Size(52, 41);
            this.toolStripButton_Up.Text = "上移";
            this.toolStripButton_Up.Click += new System.EventHandler(this.toolStripButton_Up_Click);
            // 
            // toolStripButton_Down
            // 
            this.toolStripButton_Down.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Down.Image")));
            this.toolStripButton_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Down.Name = "toolStripButton_Down";
            this.toolStripButton_Down.Size = new System.Drawing.Size(52, 41);
            this.toolStripButton_Down.Text = "下移";
            this.toolStripButton_Down.Click += new System.EventHandler(this.toolStripButton_Down_Click);
            // 
            // toolStripButton_Delete
            // 
            this.toolStripButton_Delete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Delete.Image")));
            this.toolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Delete.Name = "toolStripButton_Delete";
            this.toolStripButton_Delete.Size = new System.Drawing.Size(52, 41);
            this.toolStripButton_Delete.Text = "删除";
            this.toolStripButton_Delete.Click += new System.EventHandler(this.toolStripButton_Delete_Click);
            // 
            // treeView_Roles
            // 
            this.treeView_Roles.Location = new System.Drawing.Point(3, 47);
            this.treeView_Roles.Name = "treeView_Roles";
            this.treeView_Roles.Size = new System.Drawing.Size(251, 423);
            this.treeView_Roles.TabIndex = 0;
            this.treeView_Roles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Role_AfterSelect);
            // 
            // panel_Info
            // 
            this.panel_Info.Controls.Add(this.groupBox_Info);
            this.panel_Info.Location = new System.Drawing.Point(266, 3);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(311, 474);
            this.panel_Info.TabIndex = 20;
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Controls.Add(this.label__MenuTypeName);
            this.groupBox_Info.Controls.Add(this.textBox_Description);
            this.groupBox_Info.Controls.Add(this.label_Description);
            this.groupBox_Info.Controls.Add(this.button_ReSet);
            this.groupBox_Info.Controls.Add(this.button_Edit);
            this.groupBox_Info.Controls.Add(this.label_RoleName);
            this.groupBox_Info.Controls.Add(this.textBox_MenuTypeName);
            this.groupBox_Info.Controls.Add(this.textBox_RoleName);
            this.groupBox_Info.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(305, 468);
            this.groupBox_Info.TabIndex = 27;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "菜单信息";
            // 
            // label__MenuTypeName
            // 
            this.label__MenuTypeName.AutoEllipsis = true;
            this.label__MenuTypeName.Enabled = false;
            this.label__MenuTypeName.Location = new System.Drawing.Point(26, 45);
            this.label__MenuTypeName.Name = "label__MenuTypeName";
            this.label__MenuTypeName.Size = new System.Drawing.Size(80, 14);
            this.label__MenuTypeName.TabIndex = 17;
            this.label__MenuTypeName.Text = "所属系统：";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(114, 116);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(159, 47);
            this.textBox_Description.TabIndex = 14;
            // 
            // label_Description
            // 
            this.label_Description.AutoEllipsis = true;
            this.label_Description.Location = new System.Drawing.Point(26, 119);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(80, 14);
            this.label_Description.TabIndex = 15;
            this.label_Description.Text = "菜单说明：";
            // 
            // button_ReSet
            // 
            this.button_ReSet.Location = new System.Drawing.Point(195, 194);
            this.button_ReSet.Name = "button_ReSet";
            this.button_ReSet.Size = new System.Drawing.Size(65, 30);
            this.button_ReSet.TabIndex = 20;
            this.button_ReSet.Text = "重置";
            this.button_ReSet.UseVisualStyleBackColor = true;
            this.button_ReSet.Click += new System.EventHandler(this.button_ReSet_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(114, 194);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(65, 30);
            this.button_Edit.TabIndex = 4;
            this.button_Edit.Text = "修改";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // label_RoleName
            // 
            this.label_RoleName.AutoEllipsis = true;
            this.label_RoleName.Location = new System.Drawing.Point(26, 83);
            this.label_RoleName.Name = "label_RoleName";
            this.label_RoleName.Size = new System.Drawing.Size(80, 14);
            this.label_RoleName.TabIndex = 2;
            this.label_RoleName.Text = "角色名称：";
            // 
            // textBox_MenuTypeName
            // 
            this.textBox_MenuTypeName.Enabled = false;
            this.textBox_MenuTypeName.Location = new System.Drawing.Point(114, 42);
            this.textBox_MenuTypeName.Name = "textBox_MenuTypeName";
            this.textBox_MenuTypeName.Size = new System.Drawing.Size(120, 21);
            this.textBox_MenuTypeName.TabIndex = 16;
            // 
            // textBox_RoleName
            // 
            this.textBox_RoleName.Location = new System.Drawing.Point(114, 80);
            this.textBox_RoleName.Name = "textBox_RoleName";
            this.textBox_RoleName.Size = new System.Drawing.Size(120, 21);
            this.textBox_RoleName.TabIndex = 1;
            // 
            // UC_RoleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Tree);
            this.Controls.Add(this.panel_Info);
            this.Name = "UC_RoleManage";
            this.Size = new System.Drawing.Size(580, 480);
            this.Load += new System.EventHandler(this.UC_RoleManager_Load);
            this.panel_Tree.ResumeLayout(false);
            this.toolStrip_Top.ResumeLayout(false);
            this.toolStrip_Top.PerformLayout();
            this.panel_Info.ResumeLayout(false);
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Tree;
        private System.Windows.Forms.ToolStrip toolStrip_Top;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Up;
        private System.Windows.Forms.ToolStripButton toolStripButton_Down;
        private System.Windows.Forms.ToolStripButton toolStripButton_Delete;
        private System.Windows.Forms.TreeView treeView_Roles;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Label label__MenuTypeName;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Button button_ReSet;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Label label_RoleName;
        private System.Windows.Forms.TextBox textBox_MenuTypeName;
        private System.Windows.Forms.TextBox textBox_RoleName;
    }
}
