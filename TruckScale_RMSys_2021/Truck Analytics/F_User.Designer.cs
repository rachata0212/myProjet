namespace Truck_Analytics
{
    partial class F_User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_User));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pn_addPermission = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_dept = new System.Windows.Forms.ComboBox();
            this.chk_addDatapermission = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_leadApproved = new System.Windows.Forms.ComboBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name_surname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btn_savePermission = new System.Windows.Forms.Button();
            this.txt_userAD = new System.Windows.Forms.TextBox();
            this.btn_findUserAD = new System.Windows.Forms.Button();
            this.dtg_User = new System.Windows.Forms.DataGridView();
            this.btn_finduserADpermission = new System.Windows.Forms.Button();
            this.chk_Status_Active = new System.Windows.Forms.CheckBox();
            this.pn_addPermission.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_User)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_addPermission
            // 
            this.pn_addPermission.Controls.Add(this.chk_Status_Active);
            this.pn_addPermission.Controls.Add(this.label5);
            this.pn_addPermission.Controls.Add(this.cb_dept);
            this.pn_addPermission.Controls.Add(this.chk_addDatapermission);
            this.pn_addPermission.Controls.Add(this.label1);
            this.pn_addPermission.Controls.Add(this.cb_leadApproved);
            this.pn_addPermission.Controls.Add(this.txt_email);
            this.pn_addPermission.Controls.Add(this.label2);
            this.pn_addPermission.Controls.Add(this.txt_name_surname);
            this.pn_addPermission.Controls.Add(this.label3);
            this.pn_addPermission.Controls.Add(this.label4);
            this.pn_addPermission.Controls.Add(this.panel10);
            this.pn_addPermission.Controls.Add(this.txt_userAD);
            this.pn_addPermission.Controls.Add(this.btn_findUserAD);
            this.pn_addPermission.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_addPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pn_addPermission.Location = new System.Drawing.Point(0, 0);
            this.pn_addPermission.Name = "pn_addPermission";
            this.pn_addPermission.Size = new System.Drawing.Size(1036, 102);
            this.pn_addPermission.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 59;
            this.label5.Text = "แผนก/ฝ่าย:";
            // 
            // cb_dept
            // 
            this.cb_dept.FormattingEnabled = true;
            this.cb_dept.Location = new System.Drawing.Point(741, 28);
            this.cb_dept.Name = "cb_dept";
            this.cb_dept.Size = new System.Drawing.Size(193, 28);
            this.cb_dept.TabIndex = 58;
            // 
            // chk_addDatapermission
            // 
            this.chk_addDatapermission.AutoSize = true;
            this.chk_addDatapermission.Location = new System.Drawing.Point(416, 30);
            this.chk_addDatapermission.Name = "chk_addDatapermission";
            this.chk_addDatapermission.Size = new System.Drawing.Size(89, 24);
            this.chk_addDatapermission.TabIndex = 57;
            this.chk_addDatapermission.Text = "เพิ่มข้อมูล";
            this.chk_addDatapermission.UseVisualStyleBackColor = true;
            this.chk_addDatapermission.CheckedChanged += new System.EventHandler(this.chk_addDatapermission_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(649, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "หัวหน้าอนุมัติ:";
            // 
            // cb_leadApproved
            // 
            this.cb_leadApproved.FormattingEnabled = true;
            this.cb_leadApproved.Location = new System.Drawing.Point(741, 65);
            this.cb_leadApproved.Name = "cb_leadApproved";
            this.cb_leadApproved.Size = new System.Drawing.Size(193, 28);
            this.cb_leadApproved.TabIndex = 55;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(416, 66);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(227, 26);
            this.txt_email.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "อีเมล์:";
            // 
            // txt_name_surname
            // 
            this.txt_name_surname.Location = new System.Drawing.Point(102, 66);
            this.txt_name_surname.Name = "txt_name_surname";
            this.txt_name_surname.Size = new System.Drawing.Size(257, 26);
            this.txt_name_surname.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "ชื่อ-นามสกุล:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "รายชื่อผู้ใช้งานในระบบบริษัท:";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btn_savePermission);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(942, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(94, 102);
            this.panel10.TabIndex = 42;
            // 
            // btn_savePermission
            // 
            this.btn_savePermission.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_savePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_savePermission.Image = ((System.Drawing.Image)(resources.GetObject("btn_savePermission.Image")));
            this.btn_savePermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_savePermission.Location = new System.Drawing.Point(0, 0);
            this.btn_savePermission.Margin = new System.Windows.Forms.Padding(5);
            this.btn_savePermission.Name = "btn_savePermission";
            this.btn_savePermission.Size = new System.Drawing.Size(94, 37);
            this.btn_savePermission.TabIndex = 41;
            this.btn_savePermission.Text = "Save";
            this.btn_savePermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_savePermission.UseVisualStyleBackColor = true;
            this.btn_savePermission.Click += new System.EventHandler(this.btn_savePermission_Click);
            // 
            // txt_userAD
            // 
            this.txt_userAD.Location = new System.Drawing.Point(55, 30);
            this.txt_userAD.Name = "txt_userAD";
            this.txt_userAD.ReadOnly = true;
            this.txt_userAD.Size = new System.Drawing.Size(304, 26);
            this.txt_userAD.TabIndex = 39;
            // 
            // btn_findUserAD
            // 
            this.btn_findUserAD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_findUserAD.BackgroundImage")));
            this.btn_findUserAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_findUserAD.Enabled = false;
            this.btn_findUserAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_findUserAD.Location = new System.Drawing.Point(9, 30);
            this.btn_findUserAD.Name = "btn_findUserAD";
            this.btn_findUserAD.Size = new System.Drawing.Size(40, 26);
            this.btn_findUserAD.TabIndex = 41;
            this.btn_findUserAD.UseVisualStyleBackColor = true;
            this.btn_findUserAD.Click += new System.EventHandler(this.btn_findUserAD_Click);
            // 
            // dtg_User
            // 
            this.dtg_User.AllowUserToAddRows = false;
            this.dtg_User.AllowUserToDeleteRows = false;
            this.dtg_User.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_User.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_User.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_User.Location = new System.Drawing.Point(0, 102);
            this.dtg_User.Name = "dtg_User";
            this.dtg_User.ReadOnly = true;
            this.dtg_User.RowHeadersWidth = 11;
            this.dtg_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_User.Size = new System.Drawing.Size(1036, 567);
            this.dtg_User.TabIndex = 67;
            this.dtg_User.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_User_CellMouseClick);
            // 
            // btn_finduserADpermission
            // 
            this.btn_finduserADpermission.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_finduserADpermission.BackgroundImage")));
            this.btn_finduserADpermission.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_finduserADpermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_finduserADpermission.Location = new System.Drawing.Point(-180, 268);
            this.btn_finduserADpermission.Name = "btn_finduserADpermission";
            this.btn_finduserADpermission.Size = new System.Drawing.Size(40, 26);
            this.btn_finduserADpermission.TabIndex = 59;
            this.btn_finduserADpermission.UseVisualStyleBackColor = true;
            // 
            // chk_Status_Active
            // 
            this.chk_Status_Active.AutoSize = true;
            this.chk_Status_Active.Location = new System.Drawing.Point(554, 31);
            this.chk_Status_Active.Name = "chk_Status_Active";
            this.chk_Status_Active.Size = new System.Drawing.Size(68, 24);
            this.chk_Status_Active.TabIndex = 60;
            this.chk_Status_Active.Text = "สถานะ";
            this.chk_Status_Active.UseVisualStyleBackColor = true;
            // 
            // F_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 669);
            this.Controls.Add(this.dtg_User);
            this.Controls.Add(this.pn_addPermission);
            this.Controls.Add(this.btn_finduserADpermission);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_User";
            this.Load += new System.EventHandler(this.F_User_Load);
            this.pn_addPermission.ResumeLayout(false);
            this.pn_addPermission.PerformLayout();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_finduserADpermission;
        private System.Windows.Forms.Panel pn_addPermission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_leadApproved;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_name_surname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btn_savePermission;
        private System.Windows.Forms.TextBox txt_userAD;
        private System.Windows.Forms.Button btn_findUserAD;
        private System.Windows.Forms.CheckBox chk_addDatapermission;
        private System.Windows.Forms.DataGridView dtg_User;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_dept;
        private System.Windows.Forms.CheckBox chk_Status_Active;
    }
}