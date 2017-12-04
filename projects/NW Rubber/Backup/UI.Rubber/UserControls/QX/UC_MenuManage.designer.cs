namespace NWR.UI.UserControls
{
    partial class UC_MenuManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MenuManage));
            this.treeView_Menus = new System.Windows.Forms.TreeView();
            this.textBox_MenuName = new System.Windows.Forms.TextBox();
            this.label_MenuType = new System.Windows.Forms.Label();
            this.button_Edit = new System.Windows.Forms.Button();
            this.label_MenuName = new System.Windows.Forms.Label();
            this.textBox_MenuPath = new System.Windows.Forms.TextBox();
            this.label_ImagePath = new System.Windows.Forms.Label();
            this.textBox_ImagePath = new System.Windows.Forms.TextBox();
            this.label_Description = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label__ParentName = new System.Windows.Forms.Label();
            this.textBox_ParentName = new System.Windows.Forms.TextBox();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.button_ReSet = new System.Windows.Forms.Button();
            this.panel_Tree = new System.Windows.Forms.Panel();
            this.toolStrip_Top = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Up = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Down = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.panel_Info.SuspendLayout();
            this.groupBox_Info.SuspendLayout();
            this.panel_Tree.SuspendLayout();
            this.toolStrip_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_Menus
            // 
            this.treeView_Menus.Location = new System.Drawing.Point(3, 47);
            this.treeView_Menus.Name = "treeView_Menus";
            this.treeView_Menus.Size = new System.Drawing.Size(251, 423);
            this.treeView_Menus.TabIndex = 0;
            this.treeView_Menus.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Menus_AfterSelect);
            // 
            // textBox_MenuName
            // 
            this.textBox_MenuName.Location = new System.Drawing.Point(115, 84);
            this.textBox_MenuName.Name = "textBox_MenuName";
            this.textBox_MenuName.Size = new System.Drawing.Size(145, 21);
            this.textBox_MenuName.TabIndex = 1;
            // 
            // label_MenuType
            // 
            this.label_MenuType.AutoEllipsis = true;
            this.label_MenuType.Location = new System.Drawing.Point(27, 87);
            this.label_MenuType.Name = "label_MenuType";
            this.label_MenuType.Size = new System.Drawing.Size(80, 14);
            this.label_MenuType.TabIndex = 2;
            this.label_MenuType.Text = "菜单名称：";
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(114, 325);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(65, 30);
            this.button_Edit.TabIndex = 4;
            this.button_Edit.Text = "修改";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // label_MenuName
            // 
            this.label_MenuName.AutoEllipsis = true;
            this.label_MenuName.Location = new System.Drawing.Point(27, 124);
            this.label_MenuName.Name = "label_MenuName";
            this.label_MenuName.Size = new System.Drawing.Size(80, 14);
            this.label_MenuName.TabIndex = 9;
            this.label_MenuName.Text = "窗口名称：";
            // 
            // textBox_MenuPath
            // 
            this.textBox_MenuPath.Location = new System.Drawing.Point(115, 121);
            this.textBox_MenuPath.Name = "textBox_MenuPath";
            this.textBox_MenuPath.Size = new System.Drawing.Size(145, 21);
            this.textBox_MenuPath.TabIndex = 8;
            // 
            // label_ImagePath
            // 
            this.label_ImagePath.AutoEllipsis = true;
            this.label_ImagePath.Location = new System.Drawing.Point(27, 161);
            this.label_ImagePath.Name = "label_ImagePath";
            this.label_ImagePath.Size = new System.Drawing.Size(80, 14);
            this.label_ImagePath.TabIndex = 13;
            this.label_ImagePath.Text = "图片路径：";
            // 
            // textBox_ImagePath
            // 
            this.textBox_ImagePath.Location = new System.Drawing.Point(115, 158);
            this.textBox_ImagePath.Name = "textBox_ImagePath";
            this.textBox_ImagePath.Size = new System.Drawing.Size(145, 21);
            this.textBox_ImagePath.TabIndex = 12;
            // 
            // label_Description
            // 
            this.label_Description.AutoEllipsis = true;
            this.label_Description.Location = new System.Drawing.Point(27, 199);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(80, 14);
            this.label_Description.TabIndex = 15;
            this.label_Description.Text = "菜单说明：";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(115, 195);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(145, 60);
            this.textBox_Description.TabIndex = 14;
            // 
            // label__ParentName
            // 
            this.label__ParentName.AutoEllipsis = true;
            this.label__ParentName.Enabled = false;
            this.label__ParentName.Location = new System.Drawing.Point(27, 50);
            this.label__ParentName.Name = "label__ParentName";
            this.label__ParentName.Size = new System.Drawing.Size(80, 14);
            this.label__ParentName.TabIndex = 17;
            this.label__ParentName.Text = "上级菜单：";
            // 
            // textBox_ParentName
            // 
            this.textBox_ParentName.Enabled = false;
            this.textBox_ParentName.Location = new System.Drawing.Point(115, 47);
            this.textBox_ParentName.Name = "textBox_ParentName";
            this.textBox_ParentName.Size = new System.Drawing.Size(145, 21);
            this.textBox_ParentName.TabIndex = 16;
            // 
            // panel_Info
            // 
            this.panel_Info.Controls.Add(this.groupBox_Info);
            this.panel_Info.Location = new System.Drawing.Point(266, 3);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(311, 474);
            this.panel_Info.TabIndex = 18;
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Controls.Add(this.label__ParentName);
            this.groupBox_Info.Controls.Add(this.textBox_ImagePath);
            this.groupBox_Info.Controls.Add(this.label_ImagePath);
            this.groupBox_Info.Controls.Add(this.textBox_Description);
            this.groupBox_Info.Controls.Add(this.label_Description);
            this.groupBox_Info.Controls.Add(this.label_MenuName);
            this.groupBox_Info.Controls.Add(this.button_ReSet);
            this.groupBox_Info.Controls.Add(this.textBox_MenuPath);
            this.groupBox_Info.Controls.Add(this.button_Edit);
            this.groupBox_Info.Controls.Add(this.label_MenuType);
            this.groupBox_Info.Controls.Add(this.textBox_ParentName);
            this.groupBox_Info.Controls.Add(this.textBox_MenuName);
            this.groupBox_Info.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(305, 468);
            this.groupBox_Info.TabIndex = 27;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "菜单信息";
            // 
            // button_ReSet
            // 
            this.button_ReSet.Location = new System.Drawing.Point(195, 325);
            this.button_ReSet.Name = "button_ReSet";
            this.button_ReSet.Size = new System.Drawing.Size(65, 30);
            this.button_ReSet.TabIndex = 20;
            this.button_ReSet.Text = "重置";
            this.button_ReSet.UseVisualStyleBackColor = true;
            this.button_ReSet.Click += new System.EventHandler(this.button_ReSet_Click);
            // 
            // panel_Tree
            // 
            this.panel_Tree.Controls.Add(this.toolStrip_Top);
            this.panel_Tree.Controls.Add(this.treeView_Menus);
            this.panel_Tree.Location = new System.Drawing.Point(3, 4);
            this.panel_Tree.Name = "panel_Tree";
            this.panel_Tree.Size = new System.Drawing.Size(257, 473);
            this.panel_Tree.TabIndex = 19;
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
            // UC_MenuManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Tree);
            this.Controls.Add(this.panel_Info);
            this.Name = "UC_MenuManage";
            this.Size = new System.Drawing.Size(580, 480);
            this.Load += new System.EventHandler(this.UC_MenuManager_Load);
            this.panel_Info.ResumeLayout(false);
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.panel_Tree.ResumeLayout(false);
            this.toolStrip_Top.ResumeLayout(false);
            this.toolStrip_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Menus;
        private System.Windows.Forms.TextBox textBox_MenuName;
        private System.Windows.Forms.Label label_MenuType;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Label label_MenuName;
        private System.Windows.Forms.TextBox textBox_MenuPath;
        private System.Windows.Forms.Label label_ImagePath;
        private System.Windows.Forms.TextBox textBox_ImagePath;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label__ParentName;
        private System.Windows.Forms.TextBox textBox_ParentName;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.Button button_ReSet;
        private System.Windows.Forms.Panel panel_Tree;
        private System.Windows.Forms.ToolStrip toolStrip_Top;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Delete;
        private System.Windows.Forms.ToolStripButton toolStripButton_Up;
        private System.Windows.Forms.ToolStripButton toolStripButton_Down;
        private System.Windows.Forms.GroupBox groupBox_Info;
    }
}
