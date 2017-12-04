namespace NWR.UI.UserControls
{
    partial class UC_UserRoles
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
            this.treeView_Roles = new System.Windows.Forms.TreeView();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox_User = new System.Windows.Forms.GroupBox();
            this.label_UserType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.label_DepartmentName = new System.Windows.Forms.Label();
            this.label_Sex = new System.Windows.Forms.Label();
            this.label_EmployeeID = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_User.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_Roles
            // 
            this.treeView_Roles.CheckBoxes = true;
            this.treeView_Roles.Location = new System.Drawing.Point(280, 3);
            this.treeView_Roles.Name = "treeView_Roles";
            this.treeView_Roles.Size = new System.Drawing.Size(261, 413);
            this.treeView_Roles.TabIndex = 1;
            this.treeView_Roles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Roles_AfterCheck);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(351, 422);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(57, 33);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // groupBox_User
            // 
            this.groupBox_User.Controls.Add(this.label_UserType);
            this.groupBox_User.Controls.Add(this.label5);
            this.groupBox_User.Controls.Add(this.pictureBox_Image);
            this.groupBox_User.Controls.Add(this.label_DepartmentName);
            this.groupBox_User.Controls.Add(this.label_Sex);
            this.groupBox_User.Controls.Add(this.label_EmployeeID);
            this.groupBox_User.Controls.Add(this.label_UserName);
            this.groupBox_User.Controls.Add(this.label4);
            this.groupBox_User.Controls.Add(this.label3);
            this.groupBox_User.Controls.Add(this.label2);
            this.groupBox_User.Controls.Add(this.label1);
            this.groupBox_User.Location = new System.Drawing.Point(3, 3);
            this.groupBox_User.Name = "groupBox_User";
            this.groupBox_User.Size = new System.Drawing.Size(261, 431);
            this.groupBox_User.TabIndex = 3;
            this.groupBox_User.TabStop = false;
            this.groupBox_User.Text = "用户信息";
            // 
            // label_UserType
            // 
            this.label_UserType.AutoEllipsis = true;
            this.label_UserType.Location = new System.Drawing.Point(108, 315);
            this.label_UserType.Name = "label_UserType";
            this.label_UserType.Size = new System.Drawing.Size(116, 14);
            this.label_UserType.TabIndex = 10;
            this.label_UserType.Text = "用户类型";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.Location = new System.Drawing.Point(49, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "用户类型：";
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.Location = new System.Drawing.Point(68, 45);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(83, 111);
            this.pictureBox_Image.TabIndex = 8;
            this.pictureBox_Image.TabStop = false;
            // 
            // label_DepartmentName
            // 
            this.label_DepartmentName.AutoEllipsis = true;
            this.label_DepartmentName.Location = new System.Drawing.Point(108, 287);
            this.label_DepartmentName.Name = "label_DepartmentName";
            this.label_DepartmentName.Size = new System.Drawing.Size(116, 14);
            this.label_DepartmentName.TabIndex = 7;
            this.label_DepartmentName.Text = "所在部门";
            // 
            // label_Sex
            // 
            this.label_Sex.AutoEllipsis = true;
            this.label_Sex.Location = new System.Drawing.Point(108, 257);
            this.label_Sex.Name = "label_Sex";
            this.label_Sex.Size = new System.Drawing.Size(116, 14);
            this.label_Sex.TabIndex = 6;
            this.label_Sex.Text = "用户性别";
            // 
            // label_EmployeeID
            // 
            this.label_EmployeeID.AutoEllipsis = true;
            this.label_EmployeeID.Location = new System.Drawing.Point(108, 227);
            this.label_EmployeeID.Name = "label_EmployeeID";
            this.label_EmployeeID.Size = new System.Drawing.Size(116, 14);
            this.label_EmployeeID.TabIndex = 5;
            this.label_EmployeeID.Text = "用户编号";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoEllipsis = true;
            this.label_UserName.Location = new System.Drawing.Point(108, 197);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(116, 14);
            this.label_UserName.TabIndex = 4;
            this.label_UserName.Text = "用户姓名";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Location = new System.Drawing.Point(49, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "用户编号：";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(49, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "性别：";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(49, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "部门：";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(49, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(434, 422);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(57, 33);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "返回";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // UC_UserRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.groupBox_User);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.treeView_Roles);
            this.Name = "UC_UserRoles";
            this.Size = new System.Drawing.Size(580, 480);
            this.Load += new System.EventHandler(this.UC_UserRoles_Load);
            this.groupBox_User.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Roles;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox groupBox_User;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label_DepartmentName;
        private System.Windows.Forms.Label label_Sex;
        private System.Windows.Forms.Label label_EmployeeID;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_UserType;
        private System.Windows.Forms.Label label5;
    }
}
