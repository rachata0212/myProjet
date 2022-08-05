namespace Gui_PI
{
    partial class F_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Setting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_savePermission = new System.Windows.Forms.Button();
            this.txt_name_surname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_userAD = new System.Windows.Forms.TextBox();
            this.btn_findUserAD = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtg_user = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_user)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(307, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "ตั้งค่าการเข้าใช้โปรแกรม";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_savePermission);
            this.groupBox1.Controls.Add(this.txt_name_surname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_userAD);
            this.groupBox1.Controls.Add(this.btn_findUserAD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(0, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 111);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหาไอทีพนักงานในบริษัทฯ";
            // 
            // btn_savePermission
            // 
            this.btn_savePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_savePermission.Image = ((System.Drawing.Image)(resources.GetObject("btn_savePermission.Image")));
            this.btn_savePermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_savePermission.Location = new System.Drawing.Point(593, 65);
            this.btn_savePermission.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_savePermission.Name = "btn_savePermission";
            this.btn_savePermission.Size = new System.Drawing.Size(79, 32);
            this.btn_savePermission.TabIndex = 42;
            this.btn_savePermission.Text = "Add";
            this.btn_savePermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_savePermission.UseVisualStyleBackColor = true;
            this.btn_savePermission.Click += new System.EventHandler(this.btn_savePermission_Click);
            // 
            // txt_name_surname
            // 
            this.txt_name_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_name_surname.Location = new System.Drawing.Point(109, 68);
            this.txt_name_surname.Margin = new System.Windows.Forms.Padding(4);
            this.txt_name_surname.Name = "txt_name_surname";
            this.txt_name_surname.Size = new System.Drawing.Size(473, 26);
            this.txt_name_surname.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "ID-Windows:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "ชื่อ-นามสกุล:";
            // 
            // txt_userAD
            // 
            this.txt_userAD.Location = new System.Drawing.Point(179, 31);
            this.txt_userAD.Margin = new System.Windows.Forms.Padding(4);
            this.txt_userAD.Name = "txt_userAD";
            this.txt_userAD.ReadOnly = true;
            this.txt_userAD.Size = new System.Drawing.Size(493, 26);
            this.txt_userAD.TabIndex = 42;
            // 
            // btn_findUserAD
            // 
            this.btn_findUserAD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_findUserAD.BackgroundImage")));
            this.btn_findUserAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_findUserAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_findUserAD.Location = new System.Drawing.Point(121, 26);
            this.btn_findUserAD.Margin = new System.Windows.Forms.Padding(4);
            this.btn_findUserAD.Name = "btn_findUserAD";
            this.btn_findUserAD.Size = new System.Drawing.Size(50, 34);
            this.btn_findUserAD.TabIndex = 43;
            this.btn_findUserAD.UseVisualStyleBackColor = true;
            this.btn_findUserAD.Click += new System.EventHandler(this.btn_findUserAD_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 72);
            this.panel1.TabIndex = 11;
            // 
            // dtg_user
            // 
            this.dtg_user.AllowUserToAddRows = false;
            this.dtg_user.AllowUserToDeleteRows = false;
            this.dtg_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_user.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_user.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_user.Location = new System.Drawing.Point(0, 183);
            this.dtg_user.Name = "dtg_user";
            this.dtg_user.RowHeadersWidth = 11;
            this.dtg_user.Size = new System.Drawing.Size(924, 577);
            this.dtg_user.TabIndex = 12;
            this.dtg_user.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_user_CellEndEdit);
            // 
            // F_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 760);
            this.Controls.Add(this.dtg_user);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "F_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Setup";
            this.Load += new System.EventHandler(this.F_Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_userAD;
        private System.Windows.Forms.Button btn_findUserAD;
        private System.Windows.Forms.Button btn_savePermission;
        private System.Windows.Forms.TextBox txt_name_surname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtg_user;
    }
}