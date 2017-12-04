namespace NWR.UI
{
    partial class Frm_Login
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
            this.label_PwdErr = new System.Windows.Forms.Label();
            this.label_AccountErr = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.label_PassWord = new System.Windows.Forms.Label();
            this.textBox_PassWord = new System.Windows.Forms.TextBox();
            this.label_Account = new System.Windows.Forms.Label();
            this.textBox_Account = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_PwdErr
            // 
            this.label_PwdErr.AutoEllipsis = true;
            this.label_PwdErr.ForeColor = System.Drawing.Color.Red;
            this.label_PwdErr.Location = new System.Drawing.Point(307, 151);
            this.label_PwdErr.Name = "label_PwdErr";
            this.label_PwdErr.Size = new System.Drawing.Size(100, 14);
            this.label_PwdErr.TabIndex = 15;
            // 
            // label_AccountErr
            // 
            this.label_AccountErr.AutoEllipsis = true;
            this.label_AccountErr.ForeColor = System.Drawing.Color.Red;
            this.label_AccountErr.Location = new System.Drawing.Point(307, 107);
            this.label_AccountErr.Name = "label_AccountErr";
            this.label_AccountErr.Size = new System.Drawing.Size(100, 14);
            this.label_AccountErr.TabIndex = 14;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(192, 196);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 35);
            this.button_Login.TabIndex = 12;
            this.button_Login.Text = "登录";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label_PassWord
            // 
            this.label_PassWord.AutoEllipsis = true;
            this.label_PassWord.Location = new System.Drawing.Point(113, 152);
            this.label_PassWord.Name = "label_PassWord";
            this.label_PassWord.Size = new System.Drawing.Size(41, 12);
            this.label_PassWord.TabIndex = 11;
            this.label_PassWord.Text = "密码：";
            // 
            // textBox_PassWord
            // 
            this.textBox_PassWord.Location = new System.Drawing.Point(170, 148);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.PasswordChar = '*';
            this.textBox_PassWord.Size = new System.Drawing.Size(130, 21);
            this.textBox_PassWord.TabIndex = 10;
            // 
            // label_Account
            // 
            this.label_Account.AutoEllipsis = true;
            this.label_Account.Location = new System.Drawing.Point(113, 108);
            this.label_Account.Name = "label_Account";
            this.label_Account.Size = new System.Drawing.Size(41, 12);
            this.label_Account.TabIndex = 9;
            this.label_Account.Text = "账号：";
            // 
            // textBox_Account
            // 
            this.textBox_Account.Location = new System.Drawing.Point(170, 104);
            this.textBox_Account.Name = "textBox_Account";
            this.textBox_Account.Size = new System.Drawing.Size(130, 21);
            this.textBox_Account.TabIndex = 8;
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.button_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 282);
            this.Controls.Add(this.label_PwdErr);
            this.Controls.Add(this.label_AccountErr);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label_PassWord);
            this.Controls.Add(this.textBox_PassWord);
            this.Controls.Add(this.label_Account);
            this.Controls.Add(this.textBox_Account);
            this.Name = "Frm_Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Login";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_PwdErr;
        private System.Windows.Forms.Label label_AccountErr;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label_PassWord;
        private System.Windows.Forms.TextBox textBox_PassWord;
        private System.Windows.Forms.Label label_Account;
        private System.Windows.Forms.TextBox textBox_Account;
    }
}