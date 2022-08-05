namespace SaleOrder
{
    partial class Frmcar
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
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtidcar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsizecar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnaddedit = new System.Windows.Forms.Button();
            this.txtnamecar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.Location = new System.Drawing.Point(90, 111);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(342, 73);
            this.txtremark.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "คำอธิบาย:";
            // 
            // txtidcar
            // 
            this.txtidcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidcar.Location = new System.Drawing.Point(328, 14);
            this.txtidcar.Name = "txtidcar";
            this.txtidcar.ReadOnly = true;
            this.txtidcar.Size = new System.Drawing.Size(104, 24);
            this.txtidcar.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "รหัสรถ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 37;
            this.label1.Text = "ข้อมูลรถขนส่ง";
            // 
            // txtsizecar
            // 
            this.txtsizecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsizecar.Location = new System.Drawing.Point(169, 81);
            this.txtsizecar.Name = "txtsizecar";
            this.txtsizecar.Size = new System.Drawing.Size(263, 24);
            this.txtsizecar.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "ประเภท/ขนาด/จำนวนล้อ:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.btnaddedit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 33);
            this.panel3.TabIndex = 46;
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnexit.Location = new System.Drawing.Point(92, 4);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(83, 26);
            this.btnexit.TabIndex = 12;
            this.btnexit.Text = "ปิด";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnaddedit
            // 
            this.btnaddedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnaddedit.Location = new System.Drawing.Point(3, 4);
            this.btnaddedit.Name = "btnaddedit";
            this.btnaddedit.Size = new System.Drawing.Size(83, 26);
            this.btnaddedit.TabIndex = 11;
            this.btnaddedit.Text = "เพิ่ม/แก้ไข";
            this.btnaddedit.UseVisualStyleBackColor = true;
            this.btnaddedit.Click += new System.EventHandler(this.btnaddedit_Click);
            // 
            // txtnamecar
            // 
            this.txtnamecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnamecar.Location = new System.Drawing.Point(108, 52);
            this.txtnamecar.Name = "txtnamecar";
            this.txtnamecar.Size = new System.Drawing.Size(324, 24);
            this.txtnamecar.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "ชื่อประเภทรถ:";
            // 
            // Frmcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 225);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtsizecar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnamecar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtidcar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmcar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลรถขนส่ง";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmcar_FormClosed);
            this.Load += new System.EventHandler(this.Frmcar_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtidcar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsizecar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnaddedit;
        private System.Windows.Forms.TextBox txtnamecar;
        private System.Windows.Forms.Label label3;
    }
}