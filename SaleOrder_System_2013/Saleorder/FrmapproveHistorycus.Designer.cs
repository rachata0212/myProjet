namespace SaleOrder
{
    partial class FrmapproveHistorycus
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblstatus = new System.Windows.Forms.Label();
            this.txtidcus = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidqua = new System.Windows.Forms.TextBox();
            this.rdonoapprove = new System.Windows.Forms.RadioButton();
            this.rdoapprove = new System.Windows.Forms.RadioButton();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.cbtypevat = new System.Windows.Forms.ComboBox();
            this.txtcreditmoney = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblstatus);
            this.panel1.Controls.Add(this.txtidcus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 32);
            this.panel1.TabIndex = 56;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblstatus.Location = new System.Drawing.Point(12, 3);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 24);
            this.lblstatus.TabIndex = 48;
            // 
            // txtidcus
            // 
            this.txtidcus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidcus.Location = new System.Drawing.Point(685, 5);
            this.txtidcus.Name = "txtidcus";
            this.txtidcus.ReadOnly = true;
            this.txtidcus.Size = new System.Drawing.Size(107, 24);
            this.txtidcus.TabIndex = 52;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnclose);
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 27);
            this.panel3.TabIndex = 57;
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.Location = new System.Drawing.Point(174, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(83, 26);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(79, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(83, 26);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "บันทึกข้อมูล";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(18, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 58;
            this.label1.Text = "บันทึกประวัติเลขที่";
            // 
            // txtidqua
            // 
            this.txtidqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidqua.Location = new System.Drawing.Point(160, 41);
            this.txtidqua.Name = "txtidqua";
            this.txtidqua.ReadOnly = true;
            this.txtidqua.Size = new System.Drawing.Size(186, 29);
            this.txtidqua.TabIndex = 61;
            this.txtidqua.Text = "QYYMMDDXX";
            this.txtidqua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdonoapprove
            // 
            this.rdonoapprove.AutoSize = true;
            this.rdonoapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdonoapprove.Location = new System.Drawing.Point(18, 116);
            this.rdonoapprove.Name = "rdonoapprove";
            this.rdonoapprove.Size = new System.Drawing.Size(14, 13);
            this.rdonoapprove.TabIndex = 62;
            this.rdonoapprove.UseVisualStyleBackColor = true;
            this.rdonoapprove.CheckedChanged += new System.EventHandler(this.rdonoapprove_CheckedChanged);
            // 
            // rdoapprove
            // 
            this.rdoapprove.AutoSize = true;
            this.rdoapprove.Checked = true;
            this.rdoapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoapprove.Location = new System.Drawing.Point(18, 87);
            this.rdoapprove.Name = "rdoapprove";
            this.rdoapprove.Size = new System.Drawing.Size(14, 13);
            this.rdoapprove.TabIndex = 63;
            this.rdoapprove.TabStop = true;
            this.rdoapprove.UseVisualStyleBackColor = true;
            this.rdoapprove.CheckedChanged += new System.EventHandler(this.rdoapprove_CheckedChanged);
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.Location = new System.Drawing.Point(18, 142);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.ReadOnly = true;
            this.txtremark.Size = new System.Drawing.Size(328, 52);
            this.txtremark.TabIndex = 64;
            // 
            // cbtypevat
            // 
            this.cbtypevat.BackColor = System.Drawing.Color.DarkSalmon;
            this.cbtypevat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbtypevat.FormattingEnabled = true;
            this.cbtypevat.Items.AddRange(new object[] {
            "VAT",
            "Non VAT",
            "EEP"});
            this.cbtypevat.Location = new System.Drawing.Point(204, 85);
            this.cbtypevat.Name = "cbtypevat";
            this.cbtypevat.Size = new System.Drawing.Size(122, 24);
            this.cbtypevat.TabIndex = 178;
            this.cbtypevat.Visible = false;
            this.cbtypevat.SelectedIndexChanged += new System.EventHandler(this.cbtypevat_SelectedIndexChanged);
            // 
            // txtcreditmoney
            // 
            this.txtcreditmoney.BackColor = System.Drawing.Color.DarkSalmon;
            this.txtcreditmoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcreditmoney.Location = new System.Drawing.Point(204, 85);
            this.txtcreditmoney.Name = "txtcreditmoney";
            this.txtcreditmoney.Size = new System.Drawing.Size(142, 29);
            this.txtcreditmoney.TabIndex = 179;
            this.txtcreditmoney.Text = "000,000,000.00";
            this.txtcreditmoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtcreditmoney.Visible = false;
            this.txtcreditmoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcreditmoney_KeyPress);
            // 
            // FrmapproveHistorycus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 231);
            this.Controls.Add(this.txtcreditmoney);
            this.Controls.Add(this.cbtypevat);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.rdoapprove);
            this.Controls.Add(this.rdonoapprove);
            this.Controls.Add(this.txtidqua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmapproveHistorycus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approve History Custory";
            this.Load += new System.EventHandler(this.FrmapproveQuatation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.TextBox txtidcus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidqua;
        private System.Windows.Forms.RadioButton rdonoapprove;
        private System.Windows.Forms.RadioButton rdoapprove;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.ComboBox cbtypevat;
        private System.Windows.Forms.TextBox txtcreditmoney;
    }
}