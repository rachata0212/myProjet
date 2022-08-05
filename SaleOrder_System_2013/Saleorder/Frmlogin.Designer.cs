namespace SaleOrder
{
    partial class Frmlogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmlogin));
            this.btnlogin = new System.Windows.Forms.Button();
            this.btncancle = new System.Windows.Forms.Button();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bthchangpwd = new System.Windows.Forms.Button();
            this.btnlostpwd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnlogin.Location = new System.Drawing.Point(250, 118);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(86, 28);
            this.btnlogin.TabIndex = 0;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btncancle
            // 
            this.btncancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancle.ForeColor = System.Drawing.Color.Red;
            this.btncancle.Location = new System.Drawing.Point(342, 118);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(86, 28);
            this.btncancle.TabIndex = 1;
            this.btncancle.Text = "Cancle";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(241, 58);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(192, 22);
            this.txtuser.TabIndex = 2;
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress);
            // 
            // txtpwd
            // 
            this.txtpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpwd.Location = new System.Drawing.Point(241, 87);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(192, 22);
            this.txtpwd.TabIndex = 3;
            this.txtpwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpwd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "User name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Authentication";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnreset
            // 
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnreset.Location = new System.Drawing.Point(2, 3);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(25, 20);
            this.btnreset.TabIndex = 9;
            this.btnreset.Text = "R";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            this.btnreset.MouseHover += new System.EventHandler(this.btnreset_MouseHover);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 164);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(461, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bthchangpwd
            // 
            this.bthchangpwd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bthchangpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthchangpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bthchangpwd.Location = new System.Drawing.Point(26, 3);
            this.bthchangpwd.Name = "bthchangpwd";
            this.bthchangpwd.Size = new System.Drawing.Size(25, 20);
            this.bthchangpwd.TabIndex = 11;
            this.bthchangpwd.Text = "C";
            this.bthchangpwd.UseVisualStyleBackColor = true;
            this.bthchangpwd.Click += new System.EventHandler(this.bthchangpwd_Click);
            this.bthchangpwd.MouseHover += new System.EventHandler(this.bthchangpwd_MouseHover);
            // 
            // btnlostpwd
            // 
            this.btnlostpwd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlostpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlostpwd.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnlostpwd.Location = new System.Drawing.Point(50, 3);
            this.btnlostpwd.Name = "btnlostpwd";
            this.btnlostpwd.Size = new System.Drawing.Size(25, 20);
            this.btnlostpwd.TabIndex = 12;
            this.btnlostpwd.Text = "L";
            this.btnlostpwd.UseVisualStyleBackColor = true;
            this.btnlostpwd.Click += new System.EventHandler(this.btnlostpwd_Click);
            this.btnlostpwd.MouseEnter += new System.EventHandler(this.btnlostpwd_MouseEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(158, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sale order System";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(164, 111);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 186);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnlostpwd);
            this.Controls.Add(this.bthchangpwd);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnlogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmlogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Frmlogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button bthchangpwd;
        private System.Windows.Forms.Button btnlostpwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

