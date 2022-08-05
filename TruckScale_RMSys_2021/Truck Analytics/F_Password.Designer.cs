namespace Truck_Analytics
{
    partial class F_Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Password));
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_showpwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_name.Location = new System.Drawing.Point(71, 35);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(287, 24);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "รหัสผ่านในการยืนยันการอนุมัติงาน";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_ok.Location = new System.Drawing.Point(95, 131);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(93, 29);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "ยืนยัน";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_pwd.Location = new System.Drawing.Point(95, 84);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(207, 29);
            this.txt_pwd.TabIndex = 2;
            this.txt_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_pwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pwd_KeyPress);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_cancel.Location = new System.Drawing.Point(214, 131);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(93, 29);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "ยกเลิก";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_showpwd
            // 
            this.btn_showpwd.BackColor = System.Drawing.Color.White;
            this.btn_showpwd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_showpwd.BackgroundImage")));
            this.btn_showpwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showpwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showpwd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_showpwd.Location = new System.Drawing.Point(308, 86);
            this.btn_showpwd.Name = "btn_showpwd";
            this.btn_showpwd.Size = new System.Drawing.Size(35, 24);
            this.btn_showpwd.TabIndex = 12;
            this.btn_showpwd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_showpwd.UseVisualStyleBackColor = false;
            this.btn_showpwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_showpwd_MouseDown);
            this.btn_showpwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_showpwd_MouseUp);
            // 
            // F_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(416, 205);
            this.Controls.Add(this.btn_showpwd);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ยืนยันระบบงาน";
            this.Load += new System.EventHandler(this.F_Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_showpwd;
    }
}