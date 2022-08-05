namespace Interface_Lab
{
    partial class F_Monitor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_datetime = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txt_plateNo = new System.Windows.Forms.TextBox();
            this.txt_ticketNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_vendorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtg_detail = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnl_center = new System.Windows.Forms.Panel();
            this.txt_truckType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_right = new System.Windows.Forms.Panel();
            this.pnl_left = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_detail)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnl_center.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1028, 77);
            this.panel5.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1028, 77);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "ระบบรายงานข้อมูลเปอร์เซ็นต์แป้งมันสด";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_datetime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 49);
            this.panel1.TabIndex = 17;
            // 
            // txt_datetime
            // 
            this.txt_datetime.BackColor = System.Drawing.Color.Black;
            this.txt_datetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_datetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_datetime.ForeColor = System.Drawing.Color.White;
            this.txt_datetime.Location = new System.Drawing.Point(0, 0);
            this.txt_datetime.Multiline = true;
            this.txt_datetime.Name = "txt_datetime";
            this.txt_datetime.Size = new System.Drawing.Size(1028, 49);
            this.txt_datetime.TabIndex = 11;
            this.txt_datetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(362, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 31);
            this.label10.TabIndex = 19;
            this.label10.Text = "ทะเบียนรถ:";
            // 
            // txt_plateNo
            // 
            this.txt_plateNo.BackColor = System.Drawing.Color.LightGreen;
            this.txt_plateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_plateNo.ForeColor = System.Drawing.Color.Blue;
            this.txt_plateNo.Location = new System.Drawing.Point(501, 178);
            this.txt_plateNo.Name = "txt_plateNo";
            this.txt_plateNo.Size = new System.Drawing.Size(222, 47);
            this.txt_plateNo.TabIndex = 18;
            this.txt_plateNo.Text = "-";
            // 
            // txt_ticketNo
            // 
            this.txt_ticketNo.BackColor = System.Drawing.SystemColors.Info;
            this.txt_ticketNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_ticketNo.ForeColor = System.Drawing.Color.Red;
            this.txt_ticketNo.Location = new System.Drawing.Point(157, 41);
            this.txt_ticketNo.Name = "txt_ticketNo";
            this.txt_ticketNo.Size = new System.Drawing.Size(566, 47);
            this.txt_ticketNo.TabIndex = 20;
            this.txt_ticketNo.Text = "-";
            this.txt_ticketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(24, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 31);
            this.label1.TabIndex = 21;
            this.label1.Text = "เลขที่ตั๋ว:";
            // 
            // txt_vendorName
            // 
            this.txt_vendorName.BackColor = System.Drawing.Color.LightGreen;
            this.txt_vendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_vendorName.ForeColor = System.Drawing.Color.Blue;
            this.txt_vendorName.Location = new System.Drawing.Point(161, 109);
            this.txt_vendorName.Name = "txt_vendorName";
            this.txt_vendorName.Size = new System.Drawing.Size(562, 47);
            this.txt_vendorName.TabIndex = 22;
            this.txt_vendorName.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(20, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "ชื่อผู้ขาย:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtg_detail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 339);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 148);
            this.panel2.TabIndex = 24;
            // 
            // dtg_detail
            // 
            this.dtg_detail.AllowUserToAddRows = false;
            this.dtg_detail.AllowUserToDeleteRows = false;
            this.dtg_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_detail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_detail.Enabled = false;
            this.dtg_detail.Location = new System.Drawing.Point(0, 0);
            this.dtg_detail.Name = "dtg_detail";
            this.dtg_detail.ReadOnly = true;
            this.dtg_detail.RowHeadersWidth = 11;
            this.dtg_detail.Size = new System.Drawing.Size(1028, 148);
            this.dtg_detail.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnl_center);
            this.panel3.Controls.Add(this.pnl_right);
            this.panel3.Controls.Add(this.pnl_left);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 262);
            this.panel3.TabIndex = 25;
            // 
            // pnl_center
            // 
            this.pnl_center.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_center.Controls.Add(this.label1);
            this.pnl_center.Controls.Add(this.txt_vendorName);
            this.pnl_center.Controls.Add(this.label10);
            this.pnl_center.Controls.Add(this.txt_truckType);
            this.pnl_center.Controls.Add(this.label2);
            this.pnl_center.Controls.Add(this.label3);
            this.pnl_center.Controls.Add(this.txt_plateNo);
            this.pnl_center.Controls.Add(this.txt_ticketNo);
            this.pnl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_center.Location = new System.Drawing.Point(146, 0);
            this.pnl_center.Name = "pnl_center";
            this.pnl_center.Size = new System.Drawing.Size(751, 262);
            this.pnl_center.TabIndex = 28;
            // 
            // txt_truckType
            // 
            this.txt_truckType.BackColor = System.Drawing.Color.LightGreen;
            this.txt_truckType.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_truckType.ForeColor = System.Drawing.Color.Blue;
            this.txt_truckType.Location = new System.Drawing.Point(161, 178);
            this.txt_truckType.Name = "txt_truckType";
            this.txt_truckType.Size = new System.Drawing.Size(195, 47);
            this.txt_truckType.TabIndex = 25;
            this.txt_truckType.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(20, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "ประเภทรถ:";
            // 
            // pnl_right
            // 
            this.pnl_right.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_right.Location = new System.Drawing.Point(897, 0);
            this.pnl_right.Name = "pnl_right";
            this.pnl_right.Size = new System.Drawing.Size(131, 262);
            this.pnl_right.TabIndex = 26;
            // 
            // pnl_left
            // 
            this.pnl_left.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(146, 262);
            this.pnl_left.TabIndex = 27;
            // 
            // F_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 536);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Monitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starch Monitoring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Monitor_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_detail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnl_center.ResumeLayout(false);
            this.pnl_center.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_datetime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_plateNo;
        private System.Windows.Forms.TextBox txt_ticketNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_vendorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtg_detail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_truckType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_center;
        private System.Windows.Forms.Panel pnl_right;
        private System.Windows.Forms.Panel pnl_left;
    }
}