namespace Gui_PI
{
    partial class F_InputData
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtg_Rectime = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtp_history = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chk_detail = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbo_PLC = new System.Windows.Forms.ComboBox();
            this.txt_RecCratedate = new System.Windows.Forms.TextBox();
            this.btn_RecordSave = new System.Windows.Forms.Button();
            this.btn_SaveTag = new System.Windows.Forms.Panel();
            this.lbl_header = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Rectime)).BeginInit();
            this.panel6.SuspendLayout();
            this.btn_SaveTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtg_Rectime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(0, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1206, 416);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table record time:";
            // 
            // dtg_Rectime
            // 
            this.dtg_Rectime.AllowUserToAddRows = false;
            this.dtg_Rectime.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_Rectime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_Rectime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Rectime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_Rectime.Location = new System.Drawing.Point(3, 22);
            this.dtg_Rectime.Name = "dtg_Rectime";
            this.dtg_Rectime.RowHeadersWidth = 11;
            this.dtg_Rectime.Size = new System.Drawing.Size(1200, 391);
            this.dtg_Rectime.TabIndex = 31;
            this.dtg_Rectime.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_Rectime_CellEndEdit);
            this.dtg_Rectime.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_Rectime_CellMouseClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtp_history);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.textBox2);
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.chk_detail);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.cbo_PLC);
            this.panel6.Controls.Add(this.txt_RecCratedate);
            this.panel6.Controls.Add(this.btn_RecordSave);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.panel6.Location = new System.Drawing.Point(0, 87);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1206, 36);
            this.panel6.TabIndex = 34;
            // 
            // dtp_history
            // 
            this.dtp_history.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_history.Location = new System.Drawing.Point(811, 5);
            this.dtp_history.Name = "dtp_history";
            this.dtp_history.Size = new System.Drawing.Size(105, 26);
            this.dtp_history.TabIndex = 29;
            this.dtp_history.ValueChanged += new System.EventHandler(this.dtp_history_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1016, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Confirm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(940, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Save";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(923, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(17, 26);
            this.textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGreen;
            this.textBox1.ForeColor = System.Drawing.Color.LightGreen;
            this.textBox1.Location = new System.Drawing.Point(996, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(17, 26);
            this.textBox1.TabIndex = 25;
            // 
            // chk_detail
            // 
            this.chk_detail.AutoSize = true;
            this.chk_detail.Location = new System.Drawing.Point(333, 6);
            this.chk_detail.Name = "chk_detail";
            this.chk_detail.Size = new System.Drawing.Size(106, 24);
            this.chk_detail.TabIndex = 24;
            this.chk_detail.Text = "Hide Detail";
            this.chk_detail.UseVisualStyleBackColor = true;
            this.chk_detail.CheckedChanged += new System.EventHandler(this.chk_detail_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "PLC Name:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(447, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 20);
            this.label21.TabIndex = 18;
            this.label21.Text = "Date && Time Update:";
            // 
            // cbo_PLC
            // 
            this.cbo_PLC.FormattingEnabled = true;
            this.cbo_PLC.Location = new System.Drawing.Point(107, 4);
            this.cbo_PLC.Name = "cbo_PLC";
            this.cbo_PLC.Size = new System.Drawing.Size(220, 28);
            this.cbo_PLC.TabIndex = 23;
            this.cbo_PLC.SelectedIndexChanged += new System.EventHandler(this.cbo_PLC_SelectedIndexChanged);
            // 
            // txt_RecCratedate
            // 
            this.txt_RecCratedate.Location = new System.Drawing.Point(611, 5);
            this.txt_RecCratedate.Name = "txt_RecCratedate";
            this.txt_RecCratedate.ReadOnly = true;
            this.txt_RecCratedate.Size = new System.Drawing.Size(194, 26);
            this.txt_RecCratedate.TabIndex = 19;
            // 
            // btn_RecordSave
            // 
            this.btn_RecordSave.BackColor = System.Drawing.Color.DarkGray;
            this.btn_RecordSave.Enabled = false;
            this.btn_RecordSave.Location = new System.Drawing.Point(1082, 2);
            this.btn_RecordSave.Name = "btn_RecordSave";
            this.btn_RecordSave.Size = new System.Drawing.Size(99, 32);
            this.btn_RecordSave.TabIndex = 20;
            this.btn_RecordSave.Text = "Confirm";
            this.btn_RecordSave.UseVisualStyleBackColor = false;
            this.btn_RecordSave.Click += new System.EventHandler(this.btn_RecordSave_Click);
            // 
            // btn_SaveTag
            // 
            this.btn_SaveTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_SaveTag.Controls.Add(this.lbl_header);
            this.btn_SaveTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SaveTag.Location = new System.Drawing.Point(0, 24);
            this.btn_SaveTag.Name = "btn_SaveTag";
            this.btn_SaveTag.Size = new System.Drawing.Size(1206, 63);
            this.btn_SaveTag.TabIndex = 35;
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_header.Location = new System.Drawing.Point(449, 20);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(742, 31);
            this.lbl_header.TabIndex = 1;
            this.lbl_header.Text = "Operational data log sheet to PIant Information Systems";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1206, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // F_InputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btn_SaveTag);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "F_InputData";
            this.Text = "InputData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_InputData_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Rectime)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.btn_SaveTag.ResumeLayout(false);
            this.btn_SaveTag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtg_Rectime;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbo_PLC;
        private System.Windows.Forms.TextBox txt_RecCratedate;
        private System.Windows.Forms.Button btn_RecordSave;
        private System.Windows.Forms.Panel btn_SaveTag;
        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chk_detail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtp_history;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}