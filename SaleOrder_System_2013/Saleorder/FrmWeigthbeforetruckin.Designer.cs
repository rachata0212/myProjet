namespace SaleOrder
{
    partial class FrmWeigthbeforetruckin
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
            this.txtweigthin = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtidtran = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dtpdatetime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtweigthnet = new System.Windows.Forms.TextBox();
            this.txtweigthaf = new System.Windows.Forms.TextBox();
            this.txtweigthbf = new System.Windows.Forms.TextBox();
            this.txtserailcar = new System.Windows.Forms.TextBox();
            this.txtproduct = new System.Windows.Forms.TextBox();
            this.txtcustomer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtmoisture = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 27;
            // 
            // txtweigthin
            // 
            this.txtweigthin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthin.Location = new System.Drawing.Point(130, 336);
            this.txtweigthin.Name = "txtweigthin";
            this.txtweigthin.Size = new System.Drawing.Size(132, 31);
            this.txtweigthin.TabIndex = 31;
            this.txtweigthin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtweigthin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtweigthin_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Location = new System.Drawing.Point(268, 336);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(145, 31);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "บันทึก";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtidtran
            // 
            this.txtidtran.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidtran.Location = new System.Drawing.Point(298, 16);
            this.txtidtran.Name = "txtidtran";
            this.txtidtran.ReadOnly = true;
            this.txtidtran.Size = new System.Drawing.Size(120, 29);
            this.txtidtran.TabIndex = 34;
            this.txtidtran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(437, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dtpdatetime
            // 
            this.dtpdatetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpdatetime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdatetime.Location = new System.Drawing.Point(130, 265);
            this.dtpdatetime.Name = "dtpdatetime";
            this.dtpdatetime.Size = new System.Drawing.Size(107, 24);
            this.dtpdatetime.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtweigthnet);
            this.groupBox1.Controls.Add(this.txtweigthaf);
            this.groupBox1.Controls.Add(this.txtweigthbf);
            this.groupBox1.Controls.Add(this.txtserailcar);
            this.groupBox1.Controls.Add(this.txtproduct);
            this.groupBox1.Controls.Add(this.txtcustomer);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(17, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 209);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดการส่ง";
            // 
            // txtweigthnet
            // 
            this.txtweigthnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthnet.Location = new System.Drawing.Point(100, 173);
            this.txtweigthnet.Name = "txtweigthnet";
            this.txtweigthnet.ReadOnly = true;
            this.txtweigthnet.Size = new System.Drawing.Size(295, 26);
            this.txtweigthnet.TabIndex = 51;
            this.txtweigthnet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtweigthaf
            // 
            this.txtweigthaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthaf.Location = new System.Drawing.Point(100, 143);
            this.txtweigthaf.Name = "txtweigthaf";
            this.txtweigthaf.ReadOnly = true;
            this.txtweigthaf.Size = new System.Drawing.Size(295, 26);
            this.txtweigthaf.TabIndex = 50;
            this.txtweigthaf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtweigthbf
            // 
            this.txtweigthbf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtweigthbf.Location = new System.Drawing.Point(100, 113);
            this.txtweigthbf.Name = "txtweigthbf";
            this.txtweigthbf.ReadOnly = true;
            this.txtweigthbf.Size = new System.Drawing.Size(295, 26);
            this.txtweigthbf.TabIndex = 49;
            this.txtweigthbf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtserailcar
            // 
            this.txtserailcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtserailcar.Location = new System.Drawing.Point(100, 83);
            this.txtserailcar.Name = "txtserailcar";
            this.txtserailcar.ReadOnly = true;
            this.txtserailcar.Size = new System.Drawing.Size(295, 26);
            this.txtserailcar.TabIndex = 48;
            this.txtserailcar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtproduct
            // 
            this.txtproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtproduct.Location = new System.Drawing.Point(127, 52);
            this.txtproduct.Name = "txtproduct";
            this.txtproduct.ReadOnly = true;
            this.txtproduct.Size = new System.Drawing.Size(268, 26);
            this.txtproduct.TabIndex = 47;
            this.txtproduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcustomer
            // 
            this.txtcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtcustomer.Location = new System.Drawing.Point(127, 22);
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.ReadOnly = true;
            this.txtcustomer.Size = new System.Drawing.Size(268, 26);
            this.txtcustomer.TabIndex = 40;
            this.txtcustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(6, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "ทะเบียนรถ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(6, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "น้ำหนักสุทธิ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "น้ำหนักรถหนัก:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "ชื่อสินค้า:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(6, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "น้ำหนักรถเบา:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "ชื่อลูกค้า/โรงปาล์ม:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(246, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "เลขที่:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(12, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 20);
            this.label10.TabIndex = 54;
            this.label10.Text = "วันที่รับชั่ง:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(13, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 20);
            this.label11.TabIndex = 55;
            this.label11.Text = "น้ำหนักสุทธิลูกค้า:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(13, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 57;
            this.label8.Text = "ค่าความชื้น:";
            // 
            // txtmoisture
            // 
            this.txtmoisture.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtmoisture.Location = new System.Drawing.Point(130, 296);
            this.txtmoisture.Name = "txtmoisture";
            this.txtmoisture.Size = new System.Drawing.Size(132, 31);
            this.txtmoisture.TabIndex = 56;
            this.txtmoisture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtmoisture.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmoisture_KeyPress);
            // 
            // FrmWeigthbeforetruckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 415);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtmoisture);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtidtran);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpdatetime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtweigthin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeigthbeforetruckin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บันทึกน้ำหนัก";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWeigthbeforetruckin_FormClosed);
            this.Load += new System.EventHandler(this.FrmWeigthbeforetruckin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtweigthin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtidtran;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DateTimePicker dtpdatetime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtweigthnet;
        private System.Windows.Forms.TextBox txtweigthaf;
        private System.Windows.Forms.TextBox txtweigthbf;
        private System.Windows.Forms.TextBox txtserailcar;
        private System.Windows.Forms.TextBox txtproduct;
        private System.Windows.Forms.TextBox txtcustomer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtmoisture;
    }
}