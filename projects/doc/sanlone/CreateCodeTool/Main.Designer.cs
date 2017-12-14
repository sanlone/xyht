namespace CreateCodeTool
{
    partial class Main
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTabelName = new System.Windows.Forms.TextBox();
            this.chkselected = new System.Windows.Forms.CheckBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtCreateFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.txtDBNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDALNameSpace = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbSysType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDBName = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(37, 825);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(116, 18);
            this.lblMsg.TabIndex = 23;
            this.lblMsg.Text = "代码生成 -_-";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtTabelName);
            this.groupBox4.Controls.Add(this.chkselected);
            this.groupBox4.Controls.Add(this.txtColumnName);
            this.groupBox4.Location = new System.Drawing.Point(29, 629);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox4.Size = new System.Drawing.Size(1064, 138);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(235, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 18);
            this.label10.TabIndex = 10;
            this.label10.Text = "字段";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "表名";
            // 
            // txtTabelName
            // 
            this.txtTabelName.Location = new System.Drawing.Point(51, 33);
            this.txtTabelName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTabelName.Multiline = true;
            this.txtTabelName.Name = "txtTabelName";
            this.txtTabelName.Size = new System.Drawing.Size(177, 92);
            this.txtTabelName.TabIndex = 2;
            this.txtTabelName.Text = "offline_nav";
            // 
            // chkselected
            // 
            this.chkselected.AutoSize = true;
            this.chkselected.Checked = true;
            this.chkselected.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkselected.Location = new System.Drawing.Point(0, 0);
            this.chkselected.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkselected.Name = "chkselected";
            this.chkselected.Size = new System.Drawing.Size(583, 22);
            this.chkselected.TabIndex = 1;
            this.chkselected.Text = "简单生成 select update del sql语句 格式 表名：字段1,字段2....";
            this.chkselected.UseVisualStyleBackColor = true;
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(280, 33);
            this.txtColumnName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtColumnName.Multiline = true;
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(769, 92);
            this.txtColumnName.TabIndex = 0;
            this.txtColumnName.Text = "ID,PID,ID_type,code,name";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(557, 776);
            this.btnSelectPath.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(141, 38);
            this.btnSelectPath.TabIndex = 21;
            this.btnSelectPath.Text = "生成路径...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtCreateFilePath
            // 
            this.txtCreateFilePath.Location = new System.Drawing.Point(282, 780);
            this.txtCreateFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCreateFilePath.Name = "txtCreateFilePath";
            this.txtCreateFilePath.Size = new System.Drawing.Size(268, 28);
            this.txtCreateFilePath.TabIndex = 19;
            this.txtCreateFilePath.Text = "C:\\CreateCode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 783);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "生成路经";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Controls.Add(this.cmbSysType);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(24, 360);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1077, 259);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配置信息";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(480, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 228);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNamespace);
            this.tabPage1.Controls.Add(this.txtDBNameSpace);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtDALNameSpace);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(580, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(162, 18);
            this.txtNamespace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(268, 28);
            this.txtNamespace.TabIndex = 7;
            this.txtNamespace.Text = "ZM.Entity";
            // 
            // txtDBNameSpace
            // 
            this.txtDBNameSpace.Location = new System.Drawing.Point(162, 138);
            this.txtDBNameSpace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDBNameSpace.Name = "txtDBNameSpace";
            this.txtDBNameSpace.Size = new System.Drawing.Size(268, 28);
            this.txtDBNameSpace.TabIndex = 13;
            this.txtDBNameSpace.Text = "ZM.DB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "实体层命名空间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "业务逻辑层";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "DAL层命名空间";
            // 
            // txtDALNameSpace
            // 
            this.txtDALNameSpace.Location = new System.Drawing.Point(162, 74);
            this.txtDALNameSpace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDALNameSpace.Name = "txtDALNameSpace";
            this.txtDALNameSpace.Size = new System.Drawing.Size(268, 28);
            this.txtDALNameSpace.TabIndex = 11;
            this.txtDALNameSpace.Text = "ZM.DAL";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(465, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbSysType
            // 
            this.cmbSysType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSysType.FormattingEnabled = true;
            this.cmbSysType.Items.AddRange(new object[] {
            "XYHT定制",
            "简单三层",
            "数据工厂"});
            this.cmbSysType.Location = new System.Drawing.Point(139, 114);
            this.cmbSysType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbSysType.Name = "cmbSysType";
            this.cmbSysType.Size = new System.Drawing.Size(215, 26);
            this.cmbSysType.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "生成架构";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAll);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Location = new System.Drawing.Point(540, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(561, 342);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选表";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(17, 32);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(81, 38);
            this.btnAll.TabIndex = 7;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(17, 85);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(535, 234);
            this.checkedListBox1.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(874, 776);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 42);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDBName);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtPWD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(488, 342);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据库";
            // 
            // cmbDBName
            // 
            this.cmbDBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBName.FormattingEnabled = true;
            this.cmbDBName.Location = new System.Drawing.Point(120, 264);
            this.cmbDBName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbDBName.Name = "cmbDBName";
            this.cmbDBName.Size = new System.Drawing.Size(215, 26);
            this.cmbDBName.TabIndex = 6;
            this.cmbDBName.SelectedIndexChanged += new System.EventHandler(this.cmbDBName_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(365, 256);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 42);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "连接";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(120, 171);
            this.txtPWD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(332, 28);
            this.txtPWD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(120, 115);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(332, 28);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 58);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(332, 28);
            this.txtName.TabIndex = 1;
            this.txtName.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务名称";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(992, 776);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 42);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 861);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtCreateFilePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTabelName;
        private System.Windows.Forms.CheckBox chkselected;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtCreateFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.TextBox txtDBNameSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDALNameSpace;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbSysType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDBName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}