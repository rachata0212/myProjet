namespace SaleOrder
{
    partial class FrmInsertweigth
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
            this.txtranno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtweigthdf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtweigthaf = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtweigthbf = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtweigthselect = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rdostart = new System.Windows.Forms.RadioButton();
            this.rdoend = new System.Windows.Forms.RadioButton();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtrfinvoice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtranno
            // 
            this.txtranno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtranno.Location = new System.Drawing.Point(454, 9);
            this.txtranno.Name = "txtranno";
            this.txtranno.ReadOnly = true;
            this.txtranno.Size = new System.Drawing.Size(139, 24);
            this.txtranno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(391, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "ลำดับที่ส่ง";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "บันทึกน้ำหนักในการส่งสินค้า";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(7, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "ผลต่าง นน.";
            // 
            // txtweigthdf
            // 
            this.txtweigthdf.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtweigthdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthdf.Location = new System.Drawing.Point(88, 72);
            this.txtweigthdf.Name = "txtweigthdf";
            this.txtweigthdf.ReadOnly = true;
            this.txtweigthdf.Size = new System.Drawing.Size(139, 24);
            this.txtweigthdf.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(7, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "นน.ปลายทาง:";
            // 
            // txtweigthaf
            // 
            this.txtweigthaf.BackColor = System.Drawing.Color.DarkKhaki;
            this.txtweigthaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthaf.Location = new System.Drawing.Point(88, 42);
            this.txtweigthaf.Name = "txtweigthaf";
            this.txtweigthaf.Size = new System.Drawing.Size(139, 24);
            this.txtweigthaf.TabIndex = 13;
            this.txtweigthaf.Text = "xxxx";
            this.txtweigthaf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtweigthaf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtweigthaf_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(7, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "นน.ต้นทาง:";
            // 
            // txtweigthbf
            // 
            this.txtweigthbf.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtweigthbf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthbf.Location = new System.Drawing.Point(88, 13);
            this.txtweigthbf.Name = "txtweigthbf";
            this.txtweigthbf.Size = new System.Drawing.Size(139, 24);
            this.txtweigthbf.TabIndex = 11;
            this.txtweigthbf.Text = "xxxx";
            this.txtweigthbf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtweigthbf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtweigthbf_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(16, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "นน.ที่เลือก:";
            // 
            // txtweigthselect
            // 
            this.txtweigthselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthselect.Location = new System.Drawing.Point(86, 48);
            this.txtweigthselect.Name = "txtweigthselect";
            this.txtweigthselect.ReadOnly = true;
            this.txtweigthselect.Size = new System.Drawing.Size(189, 26);
            this.txtweigthselect.TabIndex = 17;
            this.txtweigthselect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtweigthaf);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtweigthdf);
            this.groupBox1.Controls.Add(this.txtweigthbf);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(5, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 112);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลน้ำหนัก";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(233, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 18);
            this.label12.TabIndex = 22;
            this.label12.Text = "(กก.)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(233, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 18);
            this.label11.TabIndex = 21;
            this.label11.Text = "(กก.)";
            // 
            // rdostart
            // 
            this.rdostart.AutoSize = true;
            this.rdostart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdostart.Location = new System.Drawing.Point(17, 19);
            this.rdostart.Name = "rdostart";
            this.rdostart.Size = new System.Drawing.Size(117, 22);
            this.rdostart.TabIndex = 24;
            this.rdostart.TabStop = true;
            this.rdostart.Text = "เลือก นน.ต้นทาง";
            this.rdostart.UseVisualStyleBackColor = true;
            this.rdostart.CheckedChanged += new System.EventHandler(this.rdostart_CheckedChanged);
            // 
            // rdoend
            // 
            this.rdoend.AutoSize = true;
            this.rdoend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoend.Location = new System.Drawing.Point(147, 19);
            this.rdoend.Name = "rdoend";
            this.rdoend.Size = new System.Drawing.Size(130, 22);
            this.rdoend.TabIndex = 23;
            this.rdoend.TabStop = true;
            this.rdoend.Text = "เลือก นน.ปลายทาง";
            this.rdoend.UseVisualStyleBackColor = true;
            this.rdoend.CheckedChanged += new System.EventHandler(this.tdoend_CheckedChanged);
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.ForeColor = System.Drawing.Color.Blue;
            this.btnsave.Location = new System.Drawing.Point(469, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(67, 26);
            this.btnsave.TabIndex = 26;
            this.btnsave.Text = "บันทึก";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Location = new System.Drawing.Point(536, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(67, 26);
            this.btnclose.TabIndex = 25;
            this.btnclose.Text = "Exit";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 26);
            this.panel1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "หมายเหตุ : ถ้ามีการเลือกน้ำหนักแล้วบันทึกแล้วนั่น หมายุถึง \"ปิดงานแล้ว\"";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtrfinvoice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rdostart);
            this.groupBox2.Controls.Add(this.rdoend);
            this.groupBox2.Controls.Add(this.txtweigthselect);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(300, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 112);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เลือกน้ำหนัก";
            // 
            // txtrfinvoice
            // 
            this.txtrfinvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtrfinvoice.ForeColor = System.Drawing.Color.Red;
            this.txtrfinvoice.Location = new System.Drawing.Point(124, 80);
            this.txtrfinvoice.Name = "txtrfinvoice";
            this.txtrfinvoice.Size = new System.Drawing.Size(151, 26);
            this.txtrfinvoice.TabIndex = 25;
            this.txtrfinvoice.Text = "-";
            this.txtrfinvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(16, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "อ้างอิง Invoice ที่:";
            // 
            // FrmInsertweigth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 177);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtranno);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInsertweigth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบุน้ำหนัก";
            this.Load += new System.EventHandler(this.FrmInsertweigth_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtranno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtweigthdf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtweigthaf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtweigthbf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtweigthselect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdostart;
        private System.Windows.Forms.RadioButton rdoend;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtrfinvoice;
        private System.Windows.Forms.Label label4;
    }
}