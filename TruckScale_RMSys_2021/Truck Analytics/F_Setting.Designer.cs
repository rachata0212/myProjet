namespace Truck_Analytics
{
    partial class F_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Setting));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn_warehouse = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.btn_approved = new System.Windows.Forms.Button();
            this.btn_payment = new System.Windows.Forms.Button();
            this.btn_lab = new System.Windows.Forms.Button();
            this.btn_truckScale = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_link = new System.Windows.Forms.Button();
            this.btn_security = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel33 = new System.Windows.Forms.Panel();
            this.lbl_menu = new System.Windows.Forms.Label();
            this.pn_mainform = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel33.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(214, 740);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1326, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.txt_value);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(214, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 50);
            this.panel1.TabIndex = 1;
            // 
            // txt_value
            // 
            this.txt_value.BackColor = System.Drawing.Color.Navy;
            this.txt_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_value.ForeColor = System.Drawing.Color.White;
            this.txt_value.Location = new System.Drawing.Point(0, 0);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(1326, 47);
            this.txt_value.TabIndex = 8;
            this.txt_value.Text = "การตั้งค่าโปรแกรม";
            this.txt_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_value.TextChanged += new System.EventHandler(this.txt_value_TextChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Navy;
            this.panel8.Controls.Add(this.btn_warehouse);
            this.panel8.Controls.Add(this.btn_log);
            this.panel8.Controls.Add(this.btn_approved);
            this.panel8.Controls.Add(this.btn_payment);
            this.panel8.Controls.Add(this.btn_lab);
            this.panel8.Controls.Add(this.btn_truckScale);
            this.panel8.Controls.Add(this.btn_register);
            this.panel8.Controls.Add(this.btn_link);
            this.panel8.Controls.Add(this.btn_security);
            this.panel8.Controls.Add(this.pictureBox7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(214, 762);
            this.panel8.TabIndex = 2;
            // 
            // btn_warehouse
            // 
            this.btn_warehouse.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_warehouse.Enabled = false;
            this.btn_warehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_warehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_warehouse.Image = ((System.Drawing.Image)(resources.GetObject("btn_warehouse.Image")));
            this.btn_warehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_warehouse.Location = new System.Drawing.Point(12, 346);
            this.btn_warehouse.Name = "btn_warehouse";
            this.btn_warehouse.Size = new System.Drawing.Size(188, 50);
            this.btn_warehouse.TabIndex = 12;
            this.btn_warehouse.Text = "ตั้งค่างานคลังสินค้า";
            this.btn_warehouse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_warehouse.UseVisualStyleBackColor = false;
            this.btn_warehouse.Click += new System.EventHandler(this.btn_warehouse_Click);
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.Color.LightGray;
            this.btn_log.Enabled = false;
            this.btn_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_log.Image = ((System.Drawing.Image)(resources.GetObject("btn_log.Image")));
            this.btn_log.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_log.Location = new System.Drawing.Point(12, 590);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(188, 50);
            this.btn_log.TabIndex = 11;
            this.btn_log.Text = "ประวัติการใช้งาน";
            this.btn_log.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btn_approved
            // 
            this.btn_approved.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_approved.Enabled = false;
            this.btn_approved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_approved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_approved.Image = ((System.Drawing.Image)(resources.GetObject("btn_approved.Image")));
            this.btn_approved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_approved.Location = new System.Drawing.Point(12, 529);
            this.btn_approved.Name = "btn_approved";
            this.btn_approved.Size = new System.Drawing.Size(188, 50);
            this.btn_approved.TabIndex = 10;
            this.btn_approved.Text = "อนุมัติ/แจ้งเตือน";
            this.btn_approved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_approved.UseVisualStyleBackColor = false;
            this.btn_approved.Click += new System.EventHandler(this.btn_approved_Click);
            // 
            // btn_payment
            // 
            this.btn_payment.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_payment.Enabled = false;
            this.btn_payment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_payment.Image = ((System.Drawing.Image)(resources.GetObject("btn_payment.Image")));
            this.btn_payment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_payment.Location = new System.Drawing.Point(12, 468);
            this.btn_payment.Name = "btn_payment";
            this.btn_payment.Size = new System.Drawing.Size(188, 50);
            this.btn_payment.TabIndex = 9;
            this.btn_payment.Text = "ตั้งค่างานซื้อ/จ่าย";
            this.btn_payment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_payment.UseVisualStyleBackColor = false;
            this.btn_payment.Click += new System.EventHandler(this.btn_payment_Click);
            // 
            // btn_lab
            // 
            this.btn_lab.BackColor = System.Drawing.Color.Plum;
            this.btn_lab.Enabled = false;
            this.btn_lab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_lab.Image = ((System.Drawing.Image)(resources.GetObject("btn_lab.Image")));
            this.btn_lab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_lab.Location = new System.Drawing.Point(12, 407);
            this.btn_lab.Name = "btn_lab";
            this.btn_lab.Size = new System.Drawing.Size(188, 50);
            this.btn_lab.TabIndex = 8;
            this.btn_lab.Text = "ตั้งค่าผลวิเคราะห์";
            this.btn_lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_lab.UseVisualStyleBackColor = false;
            this.btn_lab.Click += new System.EventHandler(this.btn_lab_Click);
            // 
            // btn_truckScale
            // 
            this.btn_truckScale.BackColor = System.Drawing.Color.Pink;
            this.btn_truckScale.Enabled = false;
            this.btn_truckScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_truckScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_truckScale.Image = ((System.Drawing.Image)(resources.GetObject("btn_truckScale.Image")));
            this.btn_truckScale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_truckScale.Location = new System.Drawing.Point(12, 285);
            this.btn_truckScale.Name = "btn_truckScale";
            this.btn_truckScale.Size = new System.Drawing.Size(188, 50);
            this.btn_truckScale.TabIndex = 7;
            this.btn_truckScale.Text = "ตั้งค่างานชั่งสินค้า";
            this.btn_truckScale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_truckScale.UseVisualStyleBackColor = false;
            this.btn_truckScale.Click += new System.EventHandler(this.btn_truckScale_Click);
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_register.Enabled = false;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_register.Image = ((System.Drawing.Image)(resources.GetObject("btn_register.Image")));
            this.btn_register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_register.Location = new System.Drawing.Point(12, 224);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(188, 50);
            this.btn_register.TabIndex = 6;
            this.btn_register.Text = "ตั้งค่างานลงทะเบียน";
            this.btn_register.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_link
            // 
            this.btn_link.BackColor = System.Drawing.Color.PapayaWhip;
            this.btn_link.Enabled = false;
            this.btn_link.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_link.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_link.Image = ((System.Drawing.Image)(resources.GetObject("btn_link.Image")));
            this.btn_link.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_link.Location = new System.Drawing.Point(12, 163);
            this.btn_link.Name = "btn_link";
            this.btn_link.Size = new System.Drawing.Size(188, 50);
            this.btn_link.TabIndex = 5;
            this.btn_link.Text = "ตั้งค่าเชื่อมต่อข้อมูล";
            this.btn_link.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_link.UseVisualStyleBackColor = false;
            this.btn_link.Click += new System.EventHandler(this.btn_link_Click);
            // 
            // btn_security
            // 
            this.btn_security.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_security.Enabled = false;
            this.btn_security.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_security.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_security.Image = ((System.Drawing.Image)(resources.GetObject("btn_security.Image")));
            this.btn_security.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_security.Location = new System.Drawing.Point(12, 102);
            this.btn_security.Name = "btn_security";
            this.btn_security.Size = new System.Drawing.Size(188, 50);
            this.btn_security.TabIndex = 4;
            this.btn_security.Text = "ตั้งค่าความปลอดภัย";
            this.btn_security.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_security.UseVisualStyleBackColor = false;
            this.btn_security.Click += new System.EventHandler(this.btn_security_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(214, 92);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.White;
            this.panel33.Controls.Add(this.lbl_menu);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(214, 50);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(1326, 40);
            this.panel33.TabIndex = 4;
            // 
            // lbl_menu
            // 
            this.lbl_menu.AutoSize = true;
            this.lbl_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_menu.Location = new System.Drawing.Point(6, 5);
            this.lbl_menu.Name = "lbl_menu";
            this.lbl_menu.Size = new System.Drawing.Size(31, 29);
            this.lbl_menu.TabIndex = 0;
            this.lbl_menu.Text = "...";
            // 
            // pn_mainform
            // 
            this.pn_mainform.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pn_mainform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_mainform.Location = new System.Drawing.Point(214, 90);
            this.pn_mainform.Name = "pn_mainform";
            this.pn_mainform.Size = new System.Drawing.Size(1326, 650);
            this.pn_mainform.TabIndex = 5;
            // 
            // F_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 762);
            this.Controls.Add(this.pn_mainform);
            this.Controls.Add(this.panel33);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel8);
            this.MinimizeBox = false;
            this.Name = "F_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Truck Analytics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Setting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btn_link;
        private System.Windows.Forms.Button btn_security;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Button btn_approved;
        private System.Windows.Forms.Button btn_payment;
        private System.Windows.Forms.Button btn_lab;
        private System.Windows.Forms.Button btn_truckScale;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Label lbl_menu;
        private System.Windows.Forms.Button btn_warehouse;
        private System.Windows.Forms.Panel pn_mainform;
    }
}