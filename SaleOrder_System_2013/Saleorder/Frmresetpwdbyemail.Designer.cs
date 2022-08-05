namespace SaleOrder
{
    partial class Frmresetpwdbyemail
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
            this.btncancle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtemailadmin = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.makemail = new System.Windows.Forms.MaskedTextBox();
            this.maketel = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncancle
            // 
            this.btncancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncancle.ForeColor = System.Drawing.Color.Red;
            this.btncancle.Location = new System.Drawing.Point(151, 145);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(88, 25);
            this.btncancle.TabIndex = 11;
            this.btncancle.Text = "ยกเลิก";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "อีเมล์ในการตอบกลับของผู้ร้องขอ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "อีเมล์ผู้ดูแลระบบ:";
            // 
            // txtemailadmin
            // 
            this.txtemailadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtemailadmin.Location = new System.Drawing.Point(114, 15);
            this.txtemailadmin.Name = "txtemailadmin";
            this.txtemailadmin.ReadOnly = true;
            this.txtemailadmin.Size = new System.Drawing.Size(176, 22);
            this.txtemailadmin.TabIndex = 7;
            this.txtemailadmin.Text = "admin@hybridenergy.co.th";
            // 
            // btnsend
            // 
            this.btnsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnsend.Location = new System.Drawing.Point(52, 145);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(93, 25);
            this.btnsend.TabIndex = 6;
            this.btnsend.Text = "ส่งคำร้องขอ";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // makemail
            // 
            this.makemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.makemail.Location = new System.Drawing.Point(16, 68);
            this.makemail.Name = "makemail";
            this.makemail.Size = new System.Drawing.Size(277, 22);
            this.makemail.TabIndex = 12;
            // 
            // maketel
            // 
            this.maketel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.maketel.Location = new System.Drawing.Point(16, 114);
            this.maketel.Name = "maketel";
            this.maketel.Size = new System.Drawing.Size(277, 22);
            this.maketel.TabIndex = 14;
            this.maketel.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "เบอร์โทรเพื่อติดต่อกลับ:";
            // 
            // Frmresetpwdbyemail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 183);
            this.Controls.Add(this.maketel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.makemail);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtemailadmin);
            this.Controls.Add(this.btnsend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frmresetpwdbyemail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmresetpwdbyemail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtemailadmin;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.MaskedTextBox makemail;
        private System.Windows.Forms.MaskedTextBox maketel;
        private System.Windows.Forms.Label label3;
    }
}