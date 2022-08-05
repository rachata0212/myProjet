namespace SaleOrder
{
    partial class FrmapproveQua
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
            this.lblstatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.rdoapprove = new System.Windows.Forms.RadioButton();
            this.rdonoapprove = new System.Windows.Forms.RadioButton();
            this.txtidqua = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblstatus.Location = new System.Drawing.Point(4, 2);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(24, 24);
            this.lblstatus.TabIndex = 48;
            this.lblstatus.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 24);
            this.label1.TabIndex = 74;
            this.label1.Text = "Quatation NO.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblstatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 26);
            this.panel1.TabIndex = 72;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Controls.Add(this.btnclose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 27);
            this.panel3.TabIndex = 73;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(114, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(83, 27);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "บันทึกข้อมูล";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.Location = new System.Drawing.Point(197, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(83, 27);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.Location = new System.Drawing.Point(9, 109);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.ReadOnly = true;
            this.txtremark.Size = new System.Drawing.Size(264, 42);
            this.txtremark.TabIndex = 78;
            // 
            // rdoapprove
            // 
            this.rdoapprove.AutoSize = true;
            this.rdoapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoapprove.Location = new System.Drawing.Point(14, 64);
            this.rdoapprove.Name = "rdoapprove";
            this.rdoapprove.Size = new System.Drawing.Size(117, 20);
            this.rdoapprove.TabIndex = 77;
            this.rdoapprove.TabStop = true;
            this.rdoapprove.Text = "ยืนยันใบเสนอราคานี้";
            this.rdoapprove.UseVisualStyleBackColor = true;
            this.rdoapprove.CheckedChanged += new System.EventHandler(this.rdoapprove_CheckedChanged);
            // 
            // rdonoapprove
            // 
            this.rdonoapprove.AutoSize = true;
            this.rdonoapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdonoapprove.Location = new System.Drawing.Point(139, 64);
            this.rdonoapprove.Name = "rdonoapprove";
            this.rdonoapprove.Size = new System.Drawing.Size(129, 20);
            this.rdonoapprove.TabIndex = 76;
            this.rdonoapprove.TabStop = true;
            this.rdonoapprove.Text = "ไม่ยืนยันใบเสนอราคานี้";
            this.rdonoapprove.UseVisualStyleBackColor = true;
            this.rdonoapprove.CheckedChanged += new System.EventHandler(this.rdonoapprove_CheckedChanged);
            // 
            // txtidqua
            // 
            this.txtidqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidqua.Location = new System.Drawing.Point(138, 29);
            this.txtidqua.Name = "txtidqua";
            this.txtidqua.ReadOnly = true;
            this.txtidqua.Size = new System.Drawing.Size(135, 29);
            this.txtidqua.TabIndex = 75;
            this.txtidqua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 79;
            this.label2.Text = "Remark";
            // 
            // FrmapproveQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 187);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtidqua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.rdoapprove);
            this.Controls.Add(this.rdonoapprove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmapproveQua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approve Quatation";
            this.Load += new System.EventHandler(this.FrmapproveQua_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.RadioButton rdoapprove;
        private System.Windows.Forms.RadioButton rdonoapprove;
        private System.Windows.Forms.TextBox txtidqua;
        private System.Windows.Forms.Label label2;
    }
}