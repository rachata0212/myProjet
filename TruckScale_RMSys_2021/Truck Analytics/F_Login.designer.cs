namespace Truck_Analytics
{
    partial class F_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_showpwd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_warning = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_dbName = new System.Windows.Forms.TextBox();
            this.tg_btn = new Truck_Analytics.ToggleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.btn_showpwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.btnEnter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(110, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ระบุชื่อและ รหัสผ่าน (เหมือนวิโดว์)";
            // 
            // btn_showpwd
            // 
            this.btn_showpwd.BackColor = System.Drawing.Color.White;
            this.btn_showpwd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_showpwd.BackgroundImage")));
            this.btn_showpwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showpwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showpwd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_showpwd.Location = new System.Drawing.Point(321, 74);
            this.btn_showpwd.Name = "btn_showpwd";
            this.btn_showpwd.Size = new System.Drawing.Size(25, 18);
            this.btn_showpwd.TabIndex = 11;
            this.btn_showpwd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_showpwd.UseVisualStyleBackColor = false;
            this.btn_showpwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_showpwd_MouseDown);
            this.btn_showpwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_showpwd_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "รหัสผ่าน:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Location = new System.Drawing.Point(195, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(100, 35);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(215, 27);
            this.tbxUserName.TabIndex = 1;
            this.tbxUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUserName_KeyPress);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.White;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEnter.Location = new System.Drawing.Point(100, 112);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(81, 30);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "ตกลง";
            this.btnEnter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อผู้ใช้:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(100, 69);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(215, 27);
            this.tbxPassword.TabIndex = 3;
            this.tbxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPassword_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(9, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "© 2015 Software And Scale Engineering Co., Ltd.  and its licensors.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(13, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "All rights reserved";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Build. 15.2.2.9";
            // 
            // lbl_warning
            // 
            this.lbl_warning.AutoSize = true;
            this.lbl_warning.ForeColor = System.Drawing.Color.Red;
            this.lbl_warning.Location = new System.Drawing.Point(384, 151);
            this.lbl_warning.Name = "lbl_warning";
            this.lbl_warning.Size = new System.Drawing.Size(0, 13);
            this.lbl_warning.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txt_dbName
            // 
            this.txt_dbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_dbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dbName.Location = new System.Drawing.Point(463, 318);
            this.txt_dbName.Multiline = true;
            this.txt_dbName.Name = "txt_dbName";
            this.txt_dbName.ReadOnly = true;
            this.txt_dbName.Size = new System.Drawing.Size(97, 20);
            this.txt_dbName.TabIndex = 12;
            this.txt_dbName.Text = "Database : Go Live";
            this.txt_dbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tg_btn
            // 
            this.tg_btn.AutoSize = true;
            this.tg_btn.Checked = true;
            this.tg_btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tg_btn.Location = new System.Drawing.Point(489, 293);
            this.tg_btn.MinimumSize = new System.Drawing.Size(45, 20);
            this.tg_btn.Name = "tg_btn";
            this.tg_btn.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tg_btn.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tg_btn.OnBackColor = System.Drawing.Color.LimeGreen;
            this.tg_btn.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tg_btn.Size = new System.Drawing.Size(45, 20);
            this.tg_btn.TabIndex = 11;
            this.tg_btn.UseVisualStyleBackColor = true;
            this.tg_btn.CheckedChanged += new System.EventHandler(this.tg_btn_CheckedChanged);
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(581, 351);
            this.Controls.Add(this.txt_dbName);
            this.Controls.Add(this.tg_btn);
            this.Controls.Add(this.lbl_warning);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_showpwd;
        private System.Windows.Forms.Label lbl_warning;
        private ToggleButton tg_btn;
        private System.Windows.Forms.TextBox txt_dbName;
    }
}