namespace Truck_Analytics
{
    partial class F_RecheckData
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_normal = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_sale = new System.Windows.Forms.RadioButton();
            this.chk_auto = new System.Windows.Forms.CheckBox();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.rdo_pur = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_refreshTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_recheck = new System.Windows.Forms.RadioButton();
            this.rdo_follow = new System.Windows.Forms.RadioButton();
            this.dtg_recheck = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_recheck)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1241, 48);
            this.panel2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1241, 47);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "ตรวจสอบข้อมูล/ติดตามกระบวนการทำงาน";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 77);
            this.panel1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_normal);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rdo_sale);
            this.groupBox2.Controls.Add(this.chk_auto);
            this.groupBox2.Controls.Add(this.dtp_date);
            this.groupBox2.Controls.Add(this.rdo_pur);
            this.groupBox2.Location = new System.Drawing.Point(423, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 62);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เงื่อนไขการค้นหางาน";
            // 
            // chk_normal
            // 
            this.chk_normal.AutoSize = true;
            this.chk_normal.ForeColor = System.Drawing.Color.MediumBlue;
            this.chk_normal.Location = new System.Drawing.Point(22, 27);
            this.chk_normal.Name = "chk_normal";
            this.chk_normal.Size = new System.Drawing.Size(94, 24);
            this.chk_normal.TabIndex = 11;
            this.chk_normal.Text = "งานชั่งปกติ";
            this.chk_normal.UseVisualStyleBackColor = true;
            this.chk_normal.CheckedChanged += new System.EventHandler(this.chk_normal_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "วันที่:";
            // 
            // rdo_sale
            // 
            this.rdo_sale.AutoSize = true;
            this.rdo_sale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdo_sale.Location = new System.Drawing.Point(336, 27);
            this.rdo_sale.Name = "rdo_sale";
            this.rdo_sale.Size = new System.Drawing.Size(74, 24);
            this.rdo_sale.TabIndex = 7;
            this.rdo_sale.TabStop = true;
            this.rdo_sale.Text = "งานขาย";
            this.rdo_sale.UseVisualStyleBackColor = true;
            this.rdo_sale.CheckedChanged += new System.EventHandler(this.rdo_sale_CheckedChanged);
            // 
            // chk_auto
            // 
            this.chk_auto.AutoSize = true;
            this.chk_auto.ForeColor = System.Drawing.Color.MediumBlue;
            this.chk_auto.Location = new System.Drawing.Point(122, 27);
            this.chk_auto.Name = "chk_auto";
            this.chk_auto.Size = new System.Drawing.Size(119, 24);
            this.chk_auto.TabIndex = 12;
            this.chk_auto.Text = "งานชั่งอัตโนมัติ";
            this.chk_auto.UseVisualStyleBackColor = true;
            this.chk_auto.CheckedChanged += new System.EventHandler(this.chk_auto_CheckedChanged);
            // 
            // dtp_date
            // 
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date.Location = new System.Drawing.Point(468, 26);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(116, 26);
            this.dtp_date.TabIndex = 2;
            this.dtp_date.ValueChanged += new System.EventHandler(this.dtp_date_ValueChanged);
            // 
            // rdo_pur
            // 
            this.rdo_pur.AutoSize = true;
            this.rdo_pur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdo_pur.Location = new System.Drawing.Point(263, 27);
            this.rdo_pur.Name = "rdo_pur";
            this.rdo_pur.Size = new System.Drawing.Size(67, 24);
            this.rdo_pur.TabIndex = 6;
            this.rdo_pur.TabStop = true;
            this.rdo_pur.Text = "งานซื้อ";
            this.rdo_pur.UseVisualStyleBackColor = true;
            this.rdo_pur.CheckedChanged += new System.EventHandler(this.rdo_pur_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_refresh);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1036, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(205, 77);
            this.panel3.TabIndex = 14;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Enabled = false;
            this.btn_refresh.Location = new System.Drawing.Point(108, 10);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(87, 31);
            this.btn_refresh.TabIndex = 0;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lbl_refreshTime);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 45);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(205, 32);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(32, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Refresh data in";
            // 
            // lbl_refreshTime
            // 
            this.lbl_refreshTime.AutoSize = true;
            this.lbl_refreshTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_refreshTime.ForeColor = System.Drawing.Color.Red;
            this.lbl_refreshTime.Location = new System.Drawing.Point(150, 0);
            this.lbl_refreshTime.Name = "lbl_refreshTime";
            this.lbl_refreshTime.Size = new System.Drawing.Size(55, 20);
            this.lbl_refreshTime.TabIndex = 1;
            this.lbl_refreshTime.Text = "xx Sec";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_recheck);
            this.groupBox1.Controls.Add(this.rdo_follow);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ประเภทการติดตามงาน";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdo_recheck
            // 
            this.rdo_recheck.AutoSize = true;
            this.rdo_recheck.Location = new System.Drawing.Point(223, 27);
            this.rdo_recheck.Name = "rdo_recheck";
            this.rdo_recheck.Size = new System.Drawing.Size(146, 24);
            this.rdo_recheck.TabIndex = 14;
            this.rdo_recheck.TabStop = true;
            this.rdo_recheck.Text = "ตรวจสอบสถานะงาน";
            this.rdo_recheck.UseVisualStyleBackColor = true;
            this.rdo_recheck.CheckedChanged += new System.EventHandler(this.rdo_recheck_CheckedChanged);
            // 
            // rdo_follow
            // 
            this.rdo_follow.AutoSize = true;
            this.rdo_follow.Location = new System.Drawing.Point(23, 27);
            this.rdo_follow.Name = "rdo_follow";
            this.rdo_follow.Size = new System.Drawing.Size(194, 24);
            this.rdo_follow.TabIndex = 13;
            this.rdo_follow.TabStop = true;
            this.rdo_follow.Text = "ตรวจสอบกระบวนการทำงาน";
            this.rdo_follow.UseVisualStyleBackColor = true;
            this.rdo_follow.CheckedChanged += new System.EventHandler(this.rdo_follow_CheckedChanged);
            // 
            // dtg_recheck
            // 
            this.dtg_recheck.AllowUserToAddRows = false;
            this.dtg_recheck.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_recheck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_recheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_recheck.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_recheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_recheck.Location = new System.Drawing.Point(0, 125);
            this.dtg_recheck.Name = "dtg_recheck";
            this.dtg_recheck.ReadOnly = true;
            this.dtg_recheck.RowHeadersWidth = 11;
            this.dtg_recheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_recheck.Size = new System.Drawing.Size(1241, 413);
            this.dtg_recheck.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // F_RecheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 538);
            this.Controls.Add(this.dtg_recheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "F_RecheckData";
            this.Text = "Recheck Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_RecheckData_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_recheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtg_recheck;
        private System.Windows.Forms.RadioButton rdo_sale;
        private System.Windows.Forms.RadioButton rdo_pur;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_refreshTime;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chk_auto;
        private System.Windows.Forms.CheckBox chk_normal;
        private System.Windows.Forms.RadioButton rdo_follow;
        private System.Windows.Forms.RadioButton rdo_recheck;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}