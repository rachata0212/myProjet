namespace SaleOrder
{
    partial class Frmconfirmpwdchagedata
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
            this.btnok = new System.Windows.Forms.Button();
            this.btncancle = new System.Windows.Forms.Button();
            this.txtconfirmpwd = new System.Windows.Forms.TextBox();
            this.lblidcancle = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cborthercase = new System.Windows.Forms.CheckBox();
            this.cboremark = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnok.Location = new System.Drawing.Point(41, 208);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(86, 25);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "Save";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancle
            // 
            this.btncancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncancle.Location = new System.Drawing.Point(136, 208);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(86, 25);
            this.btncancle.TabIndex = 1;
            this.btncancle.Text = "Cancle";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // txtconfirmpwd
            // 
            this.txtconfirmpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtconfirmpwd.Location = new System.Drawing.Point(5, 44);
            this.txtconfirmpwd.Name = "txtconfirmpwd";
            this.txtconfirmpwd.PasswordChar = '*';
            this.txtconfirmpwd.Size = new System.Drawing.Size(279, 22);
            this.txtconfirmpwd.TabIndex = 2;
            // 
            // lblidcancle
            // 
            this.lblidcancle.AutoSize = true;
            this.lblidcancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblidcancle.Location = new System.Drawing.Point(2, 9);
            this.lblidcancle.Name = "lblidcancle";
            this.lblidcancle.Size = new System.Drawing.Size(90, 16);
            this.lblidcancle.TabIndex = 7;
            this.lblidcancle.Text = "TXXXXXXXX";
            this.lblidcancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtremark.Location = new System.Drawing.Point(5, 130);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.ReadOnly = true;
            this.txtremark.Size = new System.Drawing.Size(279, 72);
            this.txtremark.TabIndex = 6;
            this.txtremark.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(2, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select By Case";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(2, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Comfirm Password";
            // 
            // cborthercase
            // 
            this.cborthercase.AutoSize = true;
            this.cborthercase.Location = new System.Drawing.Point(202, 108);
            this.cborthercase.Name = "cborthercase";
            this.cborthercase.Size = new System.Drawing.Size(82, 17);
            this.cborthercase.TabIndex = 9;
            this.cborthercase.Text = "Orther Case";
            this.cborthercase.UseVisualStyleBackColor = true;
            this.cborthercase.CheckedChanged += new System.EventHandler(this.cborthercase_CheckedChanged);
            // 
            // cboremark
            // 
            this.cboremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboremark.FormattingEnabled = true;
            this.cboremark.Location = new System.Drawing.Point(5, 99);
            this.cboremark.Name = "cboremark";
            this.cboremark.Size = new System.Drawing.Size(191, 24);
            this.cboremark.TabIndex = 10;
            // 
            // Frmconfirmpwdcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 239);
            this.Controls.Add(this.cboremark);
            this.Controls.Add(this.cborthercase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblidcancle);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtconfirmpwd);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmconfirmpwdcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ขอรหัสยืนยันการเปลี่ยนแปลงข้อมูล";
            this.Load += new System.EventHandler(this.Frmconfirmpwdcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.TextBox txtconfirmpwd;
        private System.Windows.Forms.Label lblidcancle;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cborthercase;
        private System.Windows.Forms.ComboBox cboremark;
    }
}