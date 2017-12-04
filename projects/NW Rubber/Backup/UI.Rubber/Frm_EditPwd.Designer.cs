namespace NWR.UI
{
    partial class Frm_EditPwd
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
            this.label_UserAccount = new System.Windows.Forms.Label();
            this.label_Pwd_Old = new System.Windows.Forms.Label();
            this.label_Pwd_New = new System.Windows.Forms.Label();
            this.label_Pwd_New2 = new System.Windows.Forms.Label();
            this.textBox_Pwd_Old = new System.Windows.Forms.TextBox();
            this.textBox_Pwd_New = new System.Windows.Forms.TextBox();
            this.textBox_Pwd_New2 = new System.Windows.Forms.TextBox();
            this.textBox_UserAccount = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Err_Pwd_New = new System.Windows.Forms.Label();
            this.label_Err_Pwd_New2 = new System.Windows.Forms.Label();
            this.label_Err_Pwd_Old = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_UserAccount
            // 
            this.label_UserAccount.Location = new System.Drawing.Point(75, 35);
            this.label_UserAccount.Name = "label_UserAccount";
            this.label_UserAccount.Size = new System.Drawing.Size(68, 14);
            this.label_UserAccount.TabIndex = 0;
            this.label_UserAccount.Text = "用户名：";
            // 
            // label_Pwd_Old
            // 
            this.label_Pwd_Old.Location = new System.Drawing.Point(75, 69);
            this.label_Pwd_Old.Name = "label_Pwd_Old";
            this.label_Pwd_Old.Size = new System.Drawing.Size(68, 14);
            this.label_Pwd_Old.TabIndex = 1;
            this.label_Pwd_Old.Text = "原密码：";
            // 
            // label_Pwd_New
            // 
            this.label_Pwd_New.Location = new System.Drawing.Point(75, 103);
            this.label_Pwd_New.Name = "label_Pwd_New";
            this.label_Pwd_New.Size = new System.Drawing.Size(68, 14);
            this.label_Pwd_New.TabIndex = 2;
            this.label_Pwd_New.Text = "新密码：";
            // 
            // label_Pwd_New2
            // 
            this.label_Pwd_New2.Location = new System.Drawing.Point(75, 137);
            this.label_Pwd_New2.Name = "label_Pwd_New2";
            this.label_Pwd_New2.Size = new System.Drawing.Size(68, 14);
            this.label_Pwd_New2.TabIndex = 3;
            this.label_Pwd_New2.Text = "确认密码：";
            // 
            // textBox_Pwd_Old
            // 
            this.textBox_Pwd_Old.Location = new System.Drawing.Point(143, 66);
            this.textBox_Pwd_Old.Name = "textBox_Pwd_Old";
            this.textBox_Pwd_Old.PasswordChar = '*';
            this.textBox_Pwd_Old.Size = new System.Drawing.Size(120, 21);
            this.textBox_Pwd_Old.TabIndex = 5;
            // 
            // textBox_Pwd_New
            // 
            this.textBox_Pwd_New.Location = new System.Drawing.Point(143, 100);
            this.textBox_Pwd_New.Name = "textBox_Pwd_New";
            this.textBox_Pwd_New.PasswordChar = '*';
            this.textBox_Pwd_New.Size = new System.Drawing.Size(120, 21);
            this.textBox_Pwd_New.TabIndex = 6;
            // 
            // textBox_Pwd_New2
            // 
            this.textBox_Pwd_New2.Location = new System.Drawing.Point(143, 134);
            this.textBox_Pwd_New2.Name = "textBox_Pwd_New2";
            this.textBox_Pwd_New2.PasswordChar = '*';
            this.textBox_Pwd_New2.Size = new System.Drawing.Size(120, 21);
            this.textBox_Pwd_New2.TabIndex = 7;
            // 
            // textBox_UserAccount
            // 
            this.textBox_UserAccount.Location = new System.Drawing.Point(143, 32);
            this.textBox_UserAccount.Name = "textBox_UserAccount";
            this.textBox_UserAccount.ReadOnly = true;
            this.textBox_UserAccount.Size = new System.Drawing.Size(120, 21);
            this.textBox_UserAccount.TabIndex = 4;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(143, 176);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 8;
            this.button_Save.Text = "确认修改";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_Err_Pwd_New
            // 
            this.label_Err_Pwd_New.AutoEllipsis = true;
            this.label_Err_Pwd_New.ForeColor = System.Drawing.Color.Red;
            this.label_Err_Pwd_New.Location = new System.Drawing.Point(263, 103);
            this.label_Err_Pwd_New.Name = "label_Err_Pwd_New";
            this.label_Err_Pwd_New.Size = new System.Drawing.Size(100, 14);
            this.label_Err_Pwd_New.TabIndex = 16;
            // 
            // label_Err_Pwd_New2
            // 
            this.label_Err_Pwd_New2.AutoEllipsis = true;
            this.label_Err_Pwd_New2.ForeColor = System.Drawing.Color.Red;
            this.label_Err_Pwd_New2.Location = new System.Drawing.Point(263, 137);
            this.label_Err_Pwd_New2.Name = "label_Err_Pwd_New2";
            this.label_Err_Pwd_New2.Size = new System.Drawing.Size(100, 14);
            this.label_Err_Pwd_New2.TabIndex = 17;
            // 
            // label_Err_Pwd_Old
            // 
            this.label_Err_Pwd_Old.AutoEllipsis = true;
            this.label_Err_Pwd_Old.ForeColor = System.Drawing.Color.Red;
            this.label_Err_Pwd_Old.Location = new System.Drawing.Point(263, 69);
            this.label_Err_Pwd_Old.Name = "label_Err_Pwd_Old";
            this.label_Err_Pwd_Old.Size = new System.Drawing.Size(100, 14);
            this.label_Err_Pwd_Old.TabIndex = 18;
            // 
            // Frm_EditPwd
            // 
            this.AcceptButton = this.button_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 223);
            this.Controls.Add(this.label_Err_Pwd_Old);
            this.Controls.Add(this.label_Err_Pwd_New2);
            this.Controls.Add(this.label_Err_Pwd_New);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.textBox_Pwd_New2);
            this.Controls.Add(this.textBox_Pwd_New);
            this.Controls.Add(this.textBox_Pwd_Old);
            this.Controls.Add(this.textBox_UserAccount);
            this.Controls.Add(this.label_Pwd_New2);
            this.Controls.Add(this.label_Pwd_New);
            this.Controls.Add(this.label_Pwd_Old);
            this.Controls.Add(this.label_UserAccount);
            this.Name = "Frm_EditPwd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改登录密码";
            this.Load += new System.EventHandler(this.Frm_EditPwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_UserAccount;
        private System.Windows.Forms.Label label_Pwd_Old;
        private System.Windows.Forms.Label label_Pwd_New;
        private System.Windows.Forms.Label label_Pwd_New2;
        private System.Windows.Forms.TextBox textBox_Pwd_Old;
        private System.Windows.Forms.TextBox textBox_Pwd_New;
        private System.Windows.Forms.TextBox textBox_Pwd_New2;
        private System.Windows.Forms.TextBox textBox_UserAccount;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_Err_Pwd_New;
        private System.Windows.Forms.Label label_Err_Pwd_New2;
        private System.Windows.Forms.Label label_Err_Pwd_Old;
    }
}