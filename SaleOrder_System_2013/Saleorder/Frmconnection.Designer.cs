namespace SaleOrder
{
    partial class Frmconnection
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
            this.label5 = new System.Windows.Forms.Label();
            this.btncancle = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtdatabasename = new System.Windows.Forms.TextBox();
            this.txtdatasource = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Create New Connection to Database !";
            // 
            // btncancle
            // 
            this.btncancle.Location = new System.Drawing.Point(131, 143);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(89, 23);
            this.btncancle.TabIndex = 33;
            this.btncancle.Text = "Cancle";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(36, 143);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(89, 23);
            this.btnok.TabIndex = 32;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Database Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Database Source";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(104, 110);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(135, 20);
            this.txtpassword.TabIndex = 27;
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(104, 84);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(135, 20);
            this.txtusername.TabIndex = 26;
            // 
            // txtdatabasename
            // 
            this.txtdatabasename.Location = new System.Drawing.Point(104, 58);
            this.txtdatabasename.Name = "txtdatabasename";
            this.txtdatabasename.Size = new System.Drawing.Size(135, 20);
            this.txtdatabasename.TabIndex = 25;
            // 
            // txtdatasource
            // 
            this.txtdatasource.Location = new System.Drawing.Point(104, 32);
            this.txtdatasource.Name = "txtdatasource";
            this.txtdatasource.Size = new System.Drawing.Size(135, 20);
            this.txtdatasource.TabIndex = 24;
            // 
            // Frmconnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 174);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.txtdatabasename);
            this.Controls.Add(this.txtdatasource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmconnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection to Database";
            this.Load += new System.EventHandler(this.Frmconnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtdatabasename;
        private System.Windows.Forms.TextBox txtdatasource;
    }
}