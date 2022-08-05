namespace IMP_PI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_dateNext = new System.Windows.Forms.TextBox();
            this.txt_dateNow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.btn_setup = new System.Windows.Forms.Button();
            this.dtg_log = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_5 = new System.Windows.Forms.TextBox();
            this.txt_4 = new System.Windows.Forms.TextBox();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_log)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_dateNext);
            this.panel1.Controls.Add(this.txt_dateNow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 152);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(377, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(597, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sync Rawmatrial to PI System.";
            // 
            // txt_dateNext
            // 
            this.txt_dateNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_dateNext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dateNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_dateNext.Location = new System.Drawing.Point(897, 107);
            this.txt_dateNext.Name = "txt_dateNext";
            this.txt_dateNext.Size = new System.Drawing.Size(301, 39);
            this.txt_dateNext.TabIndex = 5;
            this.txt_dateNext.Text = "dd/mm/yyyy hh:mm:ss";
            this.txt_dateNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_dateNow
            // 
            this.txt_dateNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_dateNow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dateNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_dateNow.Location = new System.Drawing.Point(241, 107);
            this.txt_dateNow.Name = "txt_dateNow";
            this.txt_dateNow.Size = new System.Drawing.Size(317, 39);
            this.txt_dateNow.TabIndex = 4;
            this.txt_dateNow.Text = "dd/mm/yyyy  hh:mm:ss";
            this.txt_dateNow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(44, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current time:";
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_1.Location = new System.Drawing.Point(580, 104);
            this.lbl_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(386, 46);
            this.lbl_1.TabIndex = 1;
            this.lbl_1.Text = "-> Next Update time:";
            // 
            // btn_setup
            // 
            this.btn_setup.BackColor = System.Drawing.Color.Black;
            this.btn_setup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_setup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_setup.ForeColor = System.Drawing.Color.White;
            this.btn_setup.Location = new System.Drawing.Point(1173, 0);
            this.btn_setup.Name = "btn_setup";
            this.btn_setup.Size = new System.Drawing.Size(75, 31);
            this.btn_setup.TabIndex = 1;
            this.btn_setup.Text = "Setup";
            this.btn_setup.UseVisualStyleBackColor = false;
            this.btn_setup.Click += new System.EventHandler(this.btn_setup_Click);
            // 
            // dtg_log
            // 
            this.dtg_log.AllowUserToAddRows = false;
            this.dtg_log.AllowUserToDeleteRows = false;
            this.dtg_log.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_log.Location = new System.Drawing.Point(0, 183);
            this.dtg_log.Name = "dtg_log";
            this.dtg_log.Size = new System.Drawing.Size(1248, 378);
            this.dtg_log.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Log....";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_4);
            this.panel2.Controls.Add(this.btn_setup);
            this.panel2.Controls.Add(this.txt_3);
            this.panel2.Controls.Add(this.txt_1);
            this.panel2.Controls.Add(this.txt_2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1248, 31);
            this.panel2.TabIndex = 4;
            // 
            // txt_5
            // 
            this.txt_5.BackColor = System.Drawing.Color.White;
            this.txt_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_5.Location = new System.Drawing.Point(241, 4);
            this.txt_5.Name = "txt_5";
            this.txt_5.ReadOnly = true;
            this.txt_5.Size = new System.Drawing.Size(27, 26);
            this.txt_5.TabIndex = 10;
            // 
            // txt_4
            // 
            this.txt_4.BackColor = System.Drawing.Color.White;
            this.txt_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_4.Location = new System.Drawing.Point(198, 4);
            this.txt_4.Name = "txt_4";
            this.txt_4.ReadOnly = true;
            this.txt_4.Size = new System.Drawing.Size(27, 26);
            this.txt_4.TabIndex = 9;
            // 
            // txt_3
            // 
            this.txt_3.BackColor = System.Drawing.Color.White;
            this.txt_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_3.Location = new System.Drawing.Point(155, 4);
            this.txt_3.Name = "txt_3";
            this.txt_3.ReadOnly = true;
            this.txt_3.Size = new System.Drawing.Size(27, 26);
            this.txt_3.TabIndex = 8;
            // 
            // txt_1
            // 
            this.txt_1.BackColor = System.Drawing.Color.White;
            this.txt_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_1.Location = new System.Drawing.Point(69, 4);
            this.txt_1.Name = "txt_1";
            this.txt_1.ReadOnly = true;
            this.txt_1.Size = new System.Drawing.Size(27, 26);
            this.txt_1.TabIndex = 6;
            // 
            // txt_2
            // 
            this.txt_2.BackColor = System.Drawing.Color.White;
            this.txt_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_2.Location = new System.Drawing.Point(112, 4);
            this.txt_2.Name = "txt_2";
            this.txt_2.ReadOnly = true;
            this.txt_2.Size = new System.Drawing.Size(27, 26);
            this.txt_2.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Sync DB to PI";
            this.notifyIcon1.BalloonTipTitle = "Sync Rawmat to PI Systmes";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sync Rawmat to PI Systmes";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 561);
            this.Controls.Add(this.dtg_log);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Sync Data to PI Systems.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_log)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_setup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.DataGridView dtg_log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_dateNext;
        private System.Windows.Forms.TextBox txt_dateNow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_5;
        private System.Windows.Forms.TextBox txt_4;
        private System.Windows.Forms.TextBox txt_3;
        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.TextBox txt_2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

