namespace SaleOrder
{
    partial class FrmSelectMoveJob
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbranch = new System.Windows.Forms.ComboBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btncancle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtserailcar = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbcomtran = new System.Windows.Forms.ComboBox();
            this.txtidtran = new System.Windows.Forms.TextBox();
            this.txtdatetime = new System.Windows.Forms.TextBox();
            this.txtoldid = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.gblistbox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbpassweight = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbnamedrive = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gblistbox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "สาขาส่ง:";
            // 
            // cbbranch
            // 
            this.cbbranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbbranch.FormattingEnabled = true;
            this.cbbranch.Location = new System.Drawing.Point(81, 37);
            this.cbbranch.Name = "cbbranch";
            this.cbbranch.Size = new System.Drawing.Size(207, 26);
            this.cbbranch.TabIndex = 1;
            this.cbbranch.SelectedIndexChanged += new System.EventHandler(this.cbbranch_SelectedIndexChanged);
            // 
            // btnok
            // 
            this.btnok.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnok.Location = new System.Drawing.Point(0, 0);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(99, 24);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "ตกลง";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancle
            // 
            this.btncancle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btncancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncancle.Location = new System.Drawing.Point(215, 0);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(82, 24);
            this.btncancle.TabIndex = 3;
            this.btncancle.Text = "ยกเลิก";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(22, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "ทะเบียน:";
            // 
            // txtserailcar
            // 
            this.txtserailcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtserailcar.FormattingEnabled = true;
            this.txtserailcar.Items.AddRange(new object[] {
            "83-3457",
            "83-3523",
            "83-2025",
            "83-4809",
            "83-1641",
            "83-3523/3524",
            "83-2025/3495",
            "83-4809/2617",
            "83-1641/1642"});
            this.txtserailcar.Location = new System.Drawing.Point(82, 101);
            this.txtserailcar.Name = "txtserailcar";
            this.txtserailcar.Size = new System.Drawing.Size(206, 26);
            this.txtserailcar.TabIndex = 26;
            this.txtserailcar.SelectedIndexChanged += new System.EventHandler(this.txtserailcar_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "บริษัทขนส่ง:";
            // 
            // cbcomtran
            // 
            this.cbcomtran.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbcomtran.FormattingEnabled = true;
            this.cbcomtran.Location = new System.Drawing.Point(81, 69);
            this.cbcomtran.Name = "cbcomtran";
            this.cbcomtran.Size = new System.Drawing.Size(206, 26);
            this.cbcomtran.TabIndex = 29;
            this.cbcomtran.SelectedIndexChanged += new System.EventHandler(this.cbcomtran_SelectedIndexChanged);
            // 
            // txtidtran
            // 
            this.txtidtran.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidtran.Location = new System.Drawing.Point(9, 19);
            this.txtidtran.Name = "txtidtran";
            this.txtidtran.Size = new System.Drawing.Size(74, 24);
            this.txtidtran.TabIndex = 23;
            this.txtidtran.Text = "idtran";
            this.txtidtran.Visible = false;
            // 
            // txtdatetime
            // 
            this.txtdatetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdatetime.Location = new System.Drawing.Point(9, 49);
            this.txtdatetime.Name = "txtdatetime";
            this.txtdatetime.Size = new System.Drawing.Size(74, 24);
            this.txtdatetime.TabIndex = 22;
            this.txtdatetime.Text = "datetime";
            this.txtdatetime.Visible = false;
            // 
            // txtoldid
            // 
            this.txtoldid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoldid.Location = new System.Drawing.Point(9, 82);
            this.txtoldid.Name = "txtoldid";
            this.txtoldid.Size = new System.Drawing.Size(74, 24);
            this.txtoldid.TabIndex = 21;
            this.txtoldid.Text = "oldid";
            this.txtoldid.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.Location = new System.Drawing.Point(114, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(23, 20);
            this.textBox1.TabIndex = 32;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox2.Location = new System.Drawing.Point(89, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(23, 20);
            this.textBox2.TabIndex = 33;
            this.textBox2.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox4.Location = new System.Drawing.Point(89, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(20, 20);
            this.textBox4.TabIndex = 35;
            this.textBox4.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox3.Location = new System.Drawing.Point(89, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(23, 20);
            this.textBox3.TabIndex = 34;
            this.textBox3.Visible = false;
            // 
            // gblistbox
            // 
            this.gblistbox.Controls.Add(this.textBox3);
            this.gblistbox.Controls.Add(this.textBox4);
            this.gblistbox.Controls.Add(this.textBox2);
            this.gblistbox.Controls.Add(this.textBox1);
            this.gblistbox.Controls.Add(this.txtoldid);
            this.gblistbox.Controls.Add(this.txtdatetime);
            this.gblistbox.Controls.Add(this.txtidtran);
            this.gblistbox.Location = new System.Drawing.Point(7, 257);
            this.gblistbox.Name = "gblistbox";
            this.gblistbox.Size = new System.Drawing.Size(270, 116);
            this.gblistbox.TabIndex = 69;
            this.gblistbox.TabStop = false;
            this.gblistbox.Text = "Get Data trunk && Run NO weigth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 25);
            this.label3.TabIndex = 70;
            this.label3.Text = "จ่ายงานให้กับสาขา:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btncancle);
            this.panel1.Controls.Add(this.btnok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 24);
            this.panel1.TabIndex = 71;
            // 
            // cbpassweight
            // 
            this.cbpassweight.AutoSize = true;
            this.cbpassweight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbpassweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbpassweight.ForeColor = System.Drawing.Color.Red;
            this.cbpassweight.Location = new System.Drawing.Point(201, 14);
            this.cbpassweight.Name = "cbpassweight";
            this.cbpassweight.Size = new System.Drawing.Size(86, 17);
            this.cbpassweight.TabIndex = 72;
            this.cbpassweight.Text = "ไม่รอน้ำหนัก";
            this.cbpassweight.UseVisualStyleBackColor = true;
            this.cbpassweight.CheckedChanged += new System.EventHandler(this.cbpassweight_CheckedChanged);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox5.Location = new System.Drawing.Point(346, 104);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(115, 21);
            this.textBox5.TabIndex = 79;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(300, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 80;
            this.label5.Text = "N-IDW:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(300, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 78;
            this.label10.Text = "O-IDW:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(298, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 15);
            this.label11.TabIndex = 77;
            this.label11.Text = "C-Date:";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox6.Location = new System.Drawing.Point(346, 79);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(115, 21);
            this.textBox6.TabIndex = 76;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox7.Location = new System.Drawing.Point(346, 53);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(115, 21);
            this.textBox7.TabIndex = 75;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(364, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker1.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(300, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 82;
            this.label6.Text = "วันที่ขึ้น:";
            // 
            // cbnamedrive
            // 
            this.cbnamedrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbnamedrive.FormattingEnabled = true;
            this.cbnamedrive.Location = new System.Drawing.Point(109, 133);
            this.cbnamedrive.Name = "cbnamedrive";
            this.cbnamedrive.Size = new System.Drawing.Size(178, 26);
            this.cbnamedrive.TabIndex = 84;
            this.cbnamedrive.SelectedIndexChanged += new System.EventHandler(this.cbnamedrive_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(21, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 83;
            this.label7.Text = "พนักงานขับรถ:";
            // 
            // FrmSelectMoveJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 193);
            this.Controls.Add(this.cbnamedrive);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbpassweight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbcomtran);
            this.Controls.Add(this.txtserailcar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gblistbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSelectMoveJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move to Branch";
            this.Load += new System.EventHandler(this.FrmSelectMoveJob_Load);
            this.gblistbox.ResumeLayout(false);
            this.gblistbox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbranch;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtserailcar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbcomtran;
        private System.Windows.Forms.TextBox txtidtran;
        private System.Windows.Forms.TextBox txtdatetime;
        private System.Windows.Forms.TextBox txtoldid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox gblistbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbpassweight;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbnamedrive;
        private System.Windows.Forms.Label label7;
    }
}