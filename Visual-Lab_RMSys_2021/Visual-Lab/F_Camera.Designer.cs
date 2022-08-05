namespace Visual_Lab
{
    partial class F_Camera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Camera));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.cb_camera = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_resolution = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.chk_edit = new System.Windows.Forms.CheckBox();
            this.btn_imag4 = new System.Windows.Forms.Button();
            this.btn_imag1 = new System.Windows.Forms.Button();
            this.btn_imag3 = new System.Windows.Forms.Button();
            this.btn_imag2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chk_edit);
            this.panel1.Controls.Add(this.btn_imag4);
            this.panel1.Controls.Add(this.btn_imag1);
            this.panel1.Controls.Add(this.btn_imag3);
            this.panel1.Controls.Add(this.btn_imag2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 51);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.cb_camera);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cb_resolution);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(360, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 51);
            this.panel2.TabIndex = 30;
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(687, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(97, 51);
            this.btn_Close.TabIndex = 25;
            this.btn_Close.Text = "ปิดหน้าต่าง";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // cb_camera
            // 
            this.cb_camera.Enabled = false;
            this.cb_camera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_camera.FormattingEnabled = true;
            this.cb_camera.Location = new System.Drawing.Point(89, 11);
            this.cb_camera.Name = "cb_camera";
            this.cb_camera.Size = new System.Drawing.Size(165, 28);
            this.cb_camera.TabIndex = 20;
            this.cb_camera.SelectedIndexChanged += new System.EventHandler(this.cb_camera_SelectedIndexChanged);
            this.cb_camera.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_camera_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(9, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "กล้องที่เลือก:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(278, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "ความละเอียด:";
            // 
            // cb_resolution
            // 
            this.cb_resolution.Enabled = false;
            this.cb_resolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_resolution.FormattingEnabled = true;
            this.cb_resolution.Location = new System.Drawing.Point(360, 11);
            this.cb_resolution.Name = "cb_resolution";
            this.cb_resolution.Size = new System.Drawing.Size(232, 28);
            this.cb_resolution.TabIndex = 21;
            this.cb_resolution.SelectedIndexChanged += new System.EventHandler(this.cb_resolution_SelectedIndexChanged);
            this.cb_resolution.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_resolution_KeyDown);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_save.ForeColor = System.Drawing.Color.Blue;
            this.btn_save.Location = new System.Drawing.Point(597, 11);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(85, 28);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // chk_edit
            // 
            this.chk_edit.AutoSize = true;
            this.chk_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chk_edit.Location = new System.Drawing.Point(300, 14);
            this.chk_edit.Name = "chk_edit";
            this.chk_edit.Size = new System.Drawing.Size(62, 24);
            this.chk_edit.TabIndex = 29;
            this.chk_edit.Text = "แก้ไข";
            this.chk_edit.UseVisualStyleBackColor = true;
            // 
            // btn_imag4
            // 
            this.btn_imag4.BackColor = System.Drawing.Color.Silver;
            this.btn_imag4.Enabled = false;
            this.btn_imag4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imag4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_imag4.Location = new System.Drawing.Point(224, 6);
            this.btn_imag4.Margin = new System.Windows.Forms.Padding(4);
            this.btn_imag4.Name = "btn_imag4";
            this.btn_imag4.Size = new System.Drawing.Size(64, 38);
            this.btn_imag4.TabIndex = 28;
            this.btn_imag4.Text = "รูปที่ 4";
            this.btn_imag4.UseVisualStyleBackColor = false;
            this.btn_imag4.Click += new System.EventHandler(this.btn_imag4_Click);
            // 
            // btn_imag1
            // 
            this.btn_imag1.BackColor = System.Drawing.Color.Silver;
            this.btn_imag1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_imag1.Location = new System.Drawing.Point(8, 6);
            this.btn_imag1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_imag1.Name = "btn_imag1";
            this.btn_imag1.Size = new System.Drawing.Size(64, 38);
            this.btn_imag1.TabIndex = 25;
            this.btn_imag1.Text = "รูปที่ 1";
            this.btn_imag1.UseVisualStyleBackColor = false;
            this.btn_imag1.Click += new System.EventHandler(this.btn_imag1_Click);
            // 
            // btn_imag3
            // 
            this.btn_imag3.BackColor = System.Drawing.Color.Silver;
            this.btn_imag3.Enabled = false;
            this.btn_imag3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imag3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_imag3.Location = new System.Drawing.Point(152, 6);
            this.btn_imag3.Margin = new System.Windows.Forms.Padding(4);
            this.btn_imag3.Name = "btn_imag3";
            this.btn_imag3.Size = new System.Drawing.Size(64, 38);
            this.btn_imag3.TabIndex = 27;
            this.btn_imag3.Text = "รูปที่ 3";
            this.btn_imag3.UseVisualStyleBackColor = false;
            this.btn_imag3.Click += new System.EventHandler(this.btn_imag3_Click);
            // 
            // btn_imag2
            // 
            this.btn_imag2.BackColor = System.Drawing.Color.Silver;
            this.btn_imag2.Enabled = false;
            this.btn_imag2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_imag2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_imag2.Location = new System.Drawing.Point(80, 6);
            this.btn_imag2.Margin = new System.Windows.Forms.Padding(4);
            this.btn_imag2.Name = "btn_imag2";
            this.btn_imag2.Size = new System.Drawing.Size(64, 38);
            this.btn_imag2.TabIndex = 26;
            this.btn_imag2.Text = "รูปที่ 2";
            this.btn_imag2.UseVisualStyleBackColor = false;
            this.btn_imag2.Click += new System.EventHandler(this.btn_imag2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1144, 636);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(0, 671);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // F_Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 687);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Camera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ตัวอย่างภาพที่ต้องการถ่าย";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Camera_FormClosing);
            this.Load += new System.EventHandler(this.F_Camera_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F_Camera_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_resolution;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_camera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_imag4;
        private System.Windows.Forms.Button btn_imag1;
        private System.Windows.Forms.Button btn_imag3;
        private System.Windows.Forms.Button btn_imag2;
        private System.Windows.Forms.CheckBox chk_edit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Close;
    }
}