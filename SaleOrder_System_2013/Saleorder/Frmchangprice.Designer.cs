namespace SaleOrder
{
    partial class Frmchangprice
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblstatus = new System.Windows.Forms.Label();
            this.txtidcus = new System.Windows.Forms.TextBox();
            this.txtcomname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnserchcus = new System.Windows.Forms.Button();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtproname = new System.Windows.Forms.TextBox();
            this.txtoldprice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnewprice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnewremark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtoldremark = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Controls.Add(this.btnclose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 238);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 27);
            this.panel3.TabIndex = 59;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(345, 0);
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
            this.btnclose.Location = new System.Drawing.Point(428, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(83, 27);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.lblstatus);
            this.panel1.Controls.Add(this.txtidcus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 32);
            this.panel1.TabIndex = 58;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblstatus.Location = new System.Drawing.Point(3, 5);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(202, 24);
            this.lblstatus.TabIndex = 48;
            this.lblstatus.Text = "บันทึกการเปลี่ยนแปลงราคา";
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
            // txtcomname
            // 
            this.txtcomname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomname.Location = new System.Drawing.Point(75, 70);
            this.txtcomname.Name = "txtcomname";
            this.txtcomname.ReadOnly = true;
            this.txtcomname.Size = new System.Drawing.Size(422, 24);
            this.txtcomname.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 60;
            this.label5.Text = "ชื่อลูกค้า:";
            // 
            // btnserchcus
            // 
            this.btnserchcus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnserchcus.Location = new System.Drawing.Point(444, 37);
            this.btnserchcus.Name = "btnserchcus";
            this.btnserchcus.Size = new System.Drawing.Size(55, 27);
            this.btnserchcus.TabIndex = 62;
            this.btnserchcus.Text = ".......";
            this.btnserchcus.UseVisualStyleBackColor = true;
            this.btnserchcus.Click += new System.EventHandler(this.btnserchcus_Click);
            // 
            // txtdate
            // 
            this.txtdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.Location = new System.Drawing.Point(145, 38);
            this.txtdate.Name = "txtdate";
            this.txtdate.ReadOnly = true;
            this.txtdate.Size = new System.Drawing.Size(130, 24);
            this.txtdate.TabIndex = 85;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 18);
            this.label19.TabIndex = 84;
            this.label19.Text = "วันที่เปลี่ยนแปลงข้อมูล:";
            // 
            // txtproname
            // 
            this.txtproname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproname.Location = new System.Drawing.Point(75, 99);
            this.txtproname.Name = "txtproname";
            this.txtproname.ReadOnly = true;
            this.txtproname.Size = new System.Drawing.Size(141, 24);
            this.txtproname.TabIndex = 90;
            // 
            // txtoldprice
            // 
            this.txtoldprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoldprice.Location = new System.Drawing.Point(355, 99);
            this.txtoldprice.Name = "txtoldprice";
            this.txtoldprice.ReadOnly = true;
            this.txtoldprice.Size = new System.Drawing.Size(69, 24);
            this.txtoldprice.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 87;
            this.label1.Text = "ชื่อสินค้า:";
            // 
            // txtnewprice
            // 
            this.txtnewprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewprice.Location = new System.Drawing.Point(310, 161);
            this.txtnewprice.Name = "txtnewprice";
            this.txtnewprice.Size = new System.Drawing.Size(115, 24);
            this.txtnewprice.TabIndex = 92;
            this.txtnewprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnewprice_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 18);
            this.label2.TabIndex = 91;
            this.label2.Text = "จำนวนราคาที่มีการเปลี่ยนแปลง (ราคาต่อหน่วย กก.):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(431, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 18);
            this.label3.TabIndex = 93;
            this.label3.Text = "บาท";
            // 
            // txtnewremark
            // 
            this.txtnewremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewremark.Location = new System.Drawing.Point(15, 208);
            this.txtnewremark.Name = "txtnewremark";
            this.txtnewremark.Size = new System.Drawing.Size(482, 24);
            this.txtnewremark.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 95;
            this.label4.Text = "หมายเหตุ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(222, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 18);
            this.label6.TabIndex = 96;
            this.label6.Text = "ราคาเปลี่ยนแปลงล่าสุด:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(423, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 97;
            this.label7.Text = "บาท/กิโลกรัม";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 99;
            this.label8.Text = "หมายเหตุ:";
            // 
            // txtoldremark
            // 
            this.txtoldremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoldremark.Location = new System.Drawing.Point(75, 131);
            this.txtoldremark.Name = "txtoldremark";
            this.txtoldremark.ReadOnly = true;
            this.txtoldremark.Size = new System.Drawing.Size(423, 24);
            this.txtoldremark.TabIndex = 98;
            // 
            // Frmchangprice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 265);
            this.Controls.Add(this.txtoldremark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnewremark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnewprice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtproname);
            this.Controls.Add(this.txtoldprice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtcomname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnserchcus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmchangprice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บันทึกการเปลี่ยนแปลงราคา";
            this.Load += new System.EventHandler(this.Frmchangprice_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.TextBox txtidcus;
        private System.Windows.Forms.TextBox txtcomname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnserchcus;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtproname;
        private System.Windows.Forms.TextBox txtoldprice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnewprice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnewremark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtoldremark;
    }
}