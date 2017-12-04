namespace NWR.UI
{
    partial class Frm_Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.label_Role = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.linkLabel_Logout = new System.Windows.Forms.LinkLabel();
            this.linkLabel_Edit = new System.Windows.Forms.LinkLabel();
            this.splitContainer_Child = new System.Windows.Forms.SplitContainer();
            this.treeView_Menu = new System.Windows.Forms.TreeView();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.splitContainer_Child.Panel1.SuspendLayout();
            this.splitContainer_Child.Panel2.SuspendLayout();
            this.splitContainer_Child.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.label_Role);
            this.splitContainer_Main.Panel1.Controls.Add(this.label_UserName);
            this.splitContainer_Main.Panel1.Controls.Add(this.linkLabel_Logout);
            this.splitContainer_Main.Panel1.Controls.Add(this.linkLabel_Edit);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.splitContainer_Child);
            this.splitContainer_Main.Size = new System.Drawing.Size(784, 562);
            this.splitContainer_Main.SplitterDistance = 72;
            this.splitContainer_Main.TabIndex = 0;
            // 
            // label_Role
            // 
            this.label_Role.Location = new System.Drawing.Point(13, 42);
            this.label_Role.Name = "label_Role";
            this.label_Role.Size = new System.Drawing.Size(100, 14);
            this.label_Role.TabIndex = 3;
            this.label_Role.Text = "职位:";
            // 
            // label_UserName
            // 
            this.label_UserName.Location = new System.Drawing.Point(13, 13);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(100, 14);
            this.label_UserName.TabIndex = 2;
            this.label_UserName.Text = "姓名:";
            // 
            // linkLabel_Logout
            // 
            this.linkLabel_Logout.AutoSize = true;
            this.linkLabel_Logout.Location = new System.Drawing.Point(707, 9);
            this.linkLabel_Logout.Name = "linkLabel_Logout";
            this.linkLabel_Logout.Size = new System.Drawing.Size(53, 12);
            this.linkLabel_Logout.TabIndex = 1;
            this.linkLabel_Logout.TabStop = true;
            this.linkLabel_Logout.Text = "退出登录";
            this.linkLabel_Logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Logout_LinkClicked);
            // 
            // linkLabel_Edit
            // 
            this.linkLabel_Edit.AutoSize = true;
            this.linkLabel_Edit.Location = new System.Drawing.Point(636, 9);
            this.linkLabel_Edit.Name = "linkLabel_Edit";
            this.linkLabel_Edit.Size = new System.Drawing.Size(53, 12);
            this.linkLabel_Edit.TabIndex = 0;
            this.linkLabel_Edit.TabStop = true;
            this.linkLabel_Edit.Text = "修改密码";
            this.linkLabel_Edit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Edit_LinkClicked);
            // 
            // splitContainer_Child
            // 
            this.splitContainer_Child.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Child.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Child.Name = "splitContainer_Child";
            // 
            // splitContainer_Child.Panel1
            // 
            this.splitContainer_Child.Panel1.Controls.Add(this.treeView_Menu);
            // 
            // splitContainer_Child.Panel2
            // 
            this.splitContainer_Child.Panel2.AutoScroll = true;
            this.splitContainer_Child.Panel2.Controls.Add(this.panel_Main);
            this.splitContainer_Child.Size = new System.Drawing.Size(784, 486);
            this.splitContainer_Child.SplitterDistance = 199;
            this.splitContainer_Child.TabIndex = 0;
            // 
            // treeView_Menu
            // 
            this.treeView_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Menu.Location = new System.Drawing.Point(0, 0);
            this.treeView_Menu.Name = "treeView_Menu";
            this.treeView_Menu.Size = new System.Drawing.Size(199, 486);
            this.treeView_Menu.TabIndex = 0;
            this.treeView_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Menu_AfterSelect);
            // 
            // panel_Main
            // 
            this.panel_Main.AutoScroll = true;
            this.panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(581, 486);
            this.panel_Main.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer_Main);
            this.Name = "Frm_Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Main";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel1.PerformLayout();
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            this.splitContainer_Main.ResumeLayout(false);
            this.splitContainer_Child.Panel1.ResumeLayout(false);
            this.splitContainer_Child.Panel2.ResumeLayout(false);
            this.splitContainer_Child.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.SplitContainer splitContainer_Child;
        private System.Windows.Forms.TreeView treeView_Menu;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.LinkLabel linkLabel_Logout;
        private System.Windows.Forms.LinkLabel linkLabel_Edit;
        private System.Windows.Forms.Label label_Role;
        private System.Windows.Forms.Label label_UserName;
    }
}