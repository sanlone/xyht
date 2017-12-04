namespace NWR.UI.UserControls
{
    partial class UC_UserManage
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
            this.textBox_SelectWhere = new System.Windows.Forms.TextBox();
            this.comboBox_SelectType = new System.Windows.Forms.ComboBox();
            this.button_Select = new System.Windows.Forms.Button();
            this.label_EntryTime = new System.Windows.Forms.Label();
            this.label_And = new System.Windows.Forms.Label();
            this.label_Sore = new System.Windows.Forms.Label();
            this.comboBox_Sore = new System.Windows.Forms.ComboBox();
            this.label_Where = new System.Windows.Forms.Label();
            this.dataGridView_Users = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_SelectWhere
            // 
            this.textBox_SelectWhere.Location = new System.Drawing.Point(161, 19);
            this.textBox_SelectWhere.MaxLength = 50;
            this.textBox_SelectWhere.Name = "textBox_SelectWhere";
            this.textBox_SelectWhere.Size = new System.Drawing.Size(100, 21);
            this.textBox_SelectWhere.TabIndex = 0;
            // 
            // comboBox_SelectType
            // 
            this.comboBox_SelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectType.FormattingEnabled = true;
            this.comboBox_SelectType.Items.AddRange(new object[] {
            "姓名",
            "编号"});
            this.comboBox_SelectType.Location = new System.Drawing.Point(88, 19);
            this.comboBox_SelectType.Name = "comboBox_SelectType";
            this.comboBox_SelectType.Size = new System.Drawing.Size(65, 20);
            this.comboBox_SelectType.TabIndex = 2;
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(469, 19);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(79, 40);
            this.button_Select.TabIndex = 3;
            this.button_Select.Text = "查询";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // label_EntryTime
            // 
            this.label_EntryTime.AutoEllipsis = true;
            this.label_EntryTime.Location = new System.Drawing.Point(15, 52);
            this.label_EntryTime.Name = "label_EntryTime";
            this.label_EntryTime.Size = new System.Drawing.Size(65, 14);
            this.label_EntryTime.TabIndex = 4;
            this.label_EntryTime.Text = "入职日期：";
            // 
            // label_And
            // 
            this.label_And.AutoEllipsis = true;
            this.label_And.Location = new System.Drawing.Point(196, 54);
            this.label_And.Name = "label_And";
            this.label_And.Size = new System.Drawing.Size(16, 10);
            this.label_And.TabIndex = 6;
            this.label_And.Text = "~";
            // 
            // label_Sore
            // 
            this.label_Sore.AutoEllipsis = true;
            this.label_Sore.Location = new System.Drawing.Point(275, 22);
            this.label_Sore.Name = "label_Sore";
            this.label_Sore.Size = new System.Drawing.Size(45, 14);
            this.label_Sore.TabIndex = 9;
            this.label_Sore.Text = "排序：";
            // 
            // comboBox_Sore
            // 
            this.comboBox_Sore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sore.FormattingEnabled = true;
            this.comboBox_Sore.Items.AddRange(new object[] {
            "默认正序",
            "默认倒序",
            "年龄最大",
            "年龄最小",
            "入职最早",
            "入职最晚",
            "在职最长",
            "在职最短"});
            this.comboBox_Sore.Location = new System.Drawing.Point(328, 19);
            this.comboBox_Sore.Name = "comboBox_Sore";
            this.comboBox_Sore.Size = new System.Drawing.Size(75, 20);
            this.comboBox_Sore.TabIndex = 10;
            // 
            // label_Where
            // 
            this.label_Where.AutoEllipsis = true;
            this.label_Where.Location = new System.Drawing.Point(15, 22);
            this.label_Where.Name = "label_Where";
            this.label_Where.Size = new System.Drawing.Size(65, 14);
            this.label_Where.TabIndex = 11;
            this.label_Where.Text = "查询类型：";
            // 
            // dataGridView_Users
            // 
            this.dataGridView_Users.AllowUserToAddRows = false;
            this.dataGridView_Users.AllowUserToDeleteRows = false;
            this.dataGridView_Users.AllowUserToResizeRows = false;
            this.dataGridView_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserName,
            this.UserID,
            this.UserAccount,
            this.Sex,
            this.Birthday,
            this.Phone,
            this.Email,
            this.DepartmentID,
            this.DepartmentName,
            this.EntryDate,
            this.UserType,
            this.UserTypeName,
            this.Remark,
            this.DeleteDate,
            this.DeleteReason,
            this.DeleteUserName,
            this.EmployeeID});
            this.dataGridView_Users.Location = new System.Drawing.Point(3, 86);
            this.dataGridView_Users.Name = "dataGridView_Users";
            this.dataGridView_Users.ReadOnly = true;
            this.dataGridView_Users.RowHeadersVisible = false;
            this.dataGridView_Users.RowTemplate.Height = 23;
            this.dataGridView_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Users.Size = new System.Drawing.Size(574, 391);
            this.dataGridView_Users.TabIndex = 12;
            this.dataGridView_Users.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_Users_CellFormatting);
            this.dataGridView_Users.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Users_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(220, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 14;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 60;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.Frozen = true;
            this.UserName.HeaderText = "用户姓名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // UserAccount
            // 
            this.UserAccount.DataPropertyName = "UserAccount";
            this.UserAccount.HeaderText = "用户账号";
            this.UserAccount.Name = "UserAccount";
            this.UserAccount.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.HeaderText = "用户性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            this.Birthday.HeaderText = "出生年月";
            this.Birthday.Name = "Birthday";
            this.Birthday.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "联系电话";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "邮箱";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // DepartmentID
            // 
            this.DepartmentID.DataPropertyName = "DepartmentID";
            this.DepartmentID.HeaderText = "DepartmentID";
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.ReadOnly = true;
            this.DepartmentID.Visible = false;
            // 
            // DepartmentName
            // 
            this.DepartmentName.DataPropertyName = "DepartmentID";
            this.DepartmentName.HeaderText = "部门名称";
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.ReadOnly = true;
            // 
            // EntryDate
            // 
            this.EntryDate.DataPropertyName = "EntryDate";
            this.EntryDate.HeaderText = "入职时间";
            this.EntryDate.Name = "EntryDate";
            this.EntryDate.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.DataPropertyName = "UserType";
            this.UserType.HeaderText = "UserType";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.Visible = false;
            // 
            // UserTypeName
            // 
            this.UserTypeName.DataPropertyName = "UserType";
            this.UserTypeName.HeaderText = "用户状态";
            this.UserTypeName.Name = "UserTypeName";
            this.UserTypeName.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // DeleteDate
            // 
            this.DeleteDate.DataPropertyName = "DeleteDate";
            this.DeleteDate.HeaderText = "删除日期";
            this.DeleteDate.Name = "DeleteDate";
            this.DeleteDate.ReadOnly = true;
            // 
            // DeleteReason
            // 
            this.DeleteReason.DataPropertyName = "DeleteReason";
            this.DeleteReason.HeaderText = "删除原因";
            this.DeleteReason.Name = "DeleteReason";
            this.DeleteReason.ReadOnly = true;
            // 
            // DeleteUserName
            // 
            this.DeleteUserName.DataPropertyName = "DeleteUserName";
            this.DeleteUserName.HeaderText = "删除人";
            this.DeleteUserName.Name = "DeleteUserName";
            this.DeleteUserName.ReadOnly = true;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "用户编号";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            // 
            // UC_UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView_Users);
            this.Controls.Add(this.label_Where);
            this.Controls.Add(this.comboBox_Sore);
            this.Controls.Add(this.label_Sore);
            this.Controls.Add(this.label_And);
            this.Controls.Add(this.label_EntryTime);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.comboBox_SelectType);
            this.Controls.Add(this.textBox_SelectWhere);
            this.Name = "UC_UserManager";
            this.Size = new System.Drawing.Size(580, 480);
            this.Load += new System.EventHandler(this.UC_UserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_SelectWhere;
        private System.Windows.Forms.ComboBox comboBox_SelectType;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Label label_EntryTime;
        private System.Windows.Forms.Label label_And;
        private System.Windows.Forms.Label label_Sore;
        private System.Windows.Forms.ComboBox comboBox_Sore;
        private System.Windows.Forms.Label label_Where;
        private System.Windows.Forms.DataGridView dataGridView_Users;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
    }
}
