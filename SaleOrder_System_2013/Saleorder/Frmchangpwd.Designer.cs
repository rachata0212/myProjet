namespace SaleOrder
{
    partial class Frmchangpwd
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
            this.btnsave = new System.Windows.Forms.Button();
            this.txtnewpwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtconfirmpwd = new System.Windows.Forms.TextBox();
            this.btncancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnsave.Location = new System.Drawing.Point(38, 68);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 33);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtnewpwd
            // 
            this.txtnewpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnewpwd.Location = new System.Drawing.Point(127, 6);
            this.txtnewpwd.Name = "txtnewpwd";
            this.txtnewpwd.PasswordChar = '$';
            this.txtnewpwd.Size = new System.Drawing.Size(104, 22);
            this.txtnewpwd.TabIndex = 1;
            this.txtnewpwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnewpwd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัสผ่านใหม่:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "ยืนยันรหัสผ่านใหม่:";
            // 
            // txtconfirmpwd
            // 
            this.txtconfirmpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtconfirmpwd.Location = new System.Drawing.Point(127, 34);
            this.txtconfirmpwd.Name = "txtconfirmpwd";
            this.txtconfirmpwd.PasswordChar = '$';
            this.txtconfirmpwd.Size = new System.Drawing.Size(104, 22);
            this.txtconfirmpwd.TabIndex = 3;
            this.txtconfirmpwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtconfirmpwd_KeyPress);
            // 
            // btncancle
            // 
            this.btncancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncancle.ForeColor = System.Drawing.Color.Red;
            this.btncancle.Location = new System.Drawing.Point(130, 68);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(75, 33);
            this.btncancle.TabIndex = 5;
            this.btncancle.Text = "Cancle";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // Frmchangpwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 113);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtconfirmpwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnewpwd);
            this.Controls.Add(this.btnsave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frmchangpwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmchangpwd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtnewpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtconfirmpwd;
        private System.Windows.Forms.Button btncancle;
    }
}