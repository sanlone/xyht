namespace NWR.UI.UserControls
{
    partial class UC_MenuTypeManage
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
            this.dataGridView_MenuType = new System.Windows.Forms.DataGridView();
            this.MenuTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.label_Description = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_MenuTypeName = new System.Windows.Forms.Label();
            this.textBox_MenuTypeName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MenuType)).BeginInit();
            this.panel_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_MenuType
            // 
            this.dataGridView_MenuType.AllowUserToAddRows = false;
            this.dataGridView_MenuType.AllowUserToDeleteRows = false;
            this.dataGridView_MenuType.AllowUserToResizeRows = false;
            this.dataGridView_MenuType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_MenuType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_MenuType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MenuType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuTypeID,
            this.ID,
            this.MenuTypeName,
            this.Description});
            this.dataGridView_MenuType.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_MenuType.Name = "dataGridView_MenuType";
            this.dataGridView_MenuType.ReadOnly = true;
            this.dataGridView_MenuType.RowHeadersVisible = false;
            this.dataGridView_MenuType.RowTemplate.Height = 23;
            this.dataGridView_MenuType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MenuType.Size = new System.Drawing.Size(574, 277);
            this.dataGridView_MenuType.TabIndex = 0;
            this.dataGridView_MenuType.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_MenuType_CellFormatting);
            this.dataGridView_MenuType.SelectionChanged += new System.EventHandler(this.dataGridView_MenuType_SelectionChanged);
            // 
            // MenuTypeID
            // 
            this.MenuTypeID.DataPropertyName = "MenuTypeID";
            this.MenuTypeID.HeaderText = "编号";
            this.MenuTypeID.Name = "MenuTypeID";
            this.MenuTypeID.ReadOnly = true;
            this.MenuTypeID.Visible = false;
            // 
            // ID
            // 
            this.ID.FillWeight = 10F;
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // MenuTypeName
            // 
            this.MenuTypeName.DataPropertyName = "MenuTypeName";
            this.MenuTypeName.FillWeight = 35F;
            this.MenuTypeName.HeaderText = "系统名称";
            this.MenuTypeName.Name = "MenuTypeName";
            this.MenuTypeName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 55F;
            this.Description.HeaderText = "说明";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // panel_Info
            // 
            this.panel_Info.Controls.Add(this.label_Description);
            this.panel_Info.Controls.Add(this.textBox_Description);
            this.panel_Info.Controls.Add(this.button_Delete);
            this.panel_Info.Controls.Add(this.button_Edit);
            this.panel_Info.Controls.Add(this.button_Add);
            this.panel_Info.Controls.Add(this.label_MenuTypeName);
            this.panel_Info.Controls.Add(this.textBox_MenuTypeName);
            this.panel_Info.Location = new System.Drawing.Point(3, 286);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(574, 191);
            this.panel_Info.TabIndex = 1;
            // 
            // label_Description
            // 
            this.label_Description.AutoEllipsis = true;
            this.label_Description.Location = new System.Drawing.Point(28, 52);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(75, 14);
            this.label_Description.TabIndex = 6;
            this.label_Description.Text = "系统说明：";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(111, 49);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(120, 67);
            this.textBox_Description.TabIndex = 5;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(179, 145);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(60, 30);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.Text = "删除";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(111, 145);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(60, 30);
            this.button_Edit.TabIndex = 3;
            this.button_Edit.Text = "修改";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(43, 145);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(60, 30);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "添加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_MenuTypeName
            // 
            this.label_MenuTypeName.AutoEllipsis = true;
            this.label_MenuTypeName.Location = new System.Drawing.Point(28, 25);
            this.label_MenuTypeName.Name = "label_MenuTypeName";
            this.label_MenuTypeName.Size = new System.Drawing.Size(75, 14);
            this.label_MenuTypeName.TabIndex = 1;
            this.label_MenuTypeName.Text = "系统名称：";
            // 
            // textBox_MenuTypeName
            // 
            this.textBox_MenuTypeName.Location = new System.Drawing.Point(111, 22);
            this.textBox_MenuTypeName.Name = "textBox_MenuTypeName";
            this.textBox_MenuTypeName.Size = new System.Drawing.Size(120, 21);
            this.textBox_MenuTypeName.TabIndex = 0;
            // 
            // UC_MenuTypeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Info);
            this.Controls.Add(this.dataGridView_MenuType);
            this.Name = "UC_MenuTypeManage";
            this.Size = new System.Drawing.Size(580, 480);
            this.Load += new System.EventHandler(this.UC_MenuTypeManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MenuType)).EndInit();
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_MenuType;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label_MenuTypeName;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.TextBox textBox_MenuTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}
