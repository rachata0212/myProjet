namespace Truck_Analytics
{
    partial class Sub_Fsecurity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sub_Fsecurity));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label58 = new System.Windows.Forms.Label();
            this.cb_menu = new System.Windows.Forms.ComboBox();
            this.btn_savePermission = new System.Windows.Forms.Button();
            this.btn_addUser = new System.Windows.Forms.Button();
            this.dtg_menu = new System.Windows.Forms.DataGridView();
            this.cbo_user = new System.Windows.Forms.ComboBox();
            this.tb_menuType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtg_setting = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dtg_subsetting = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtg_process = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dtg_report = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_add = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_new = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_menutype = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_menu)).BeginInit();
            this.tb_menuType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_setting)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_subsetting)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_process)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_report)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_new.SuspendLayout();
            this.SuspendLayout();
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(18, 71);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(38, 20);
            this.label58.TabIndex = 44;
            this.label58.Text = "เมนู:";
            // 
            // cb_menu
            // 
            this.cb_menu.FormattingEnabled = true;
            this.cb_menu.Location = new System.Drawing.Point(70, 67);
            this.cb_menu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_menu.Name = "cb_menu";
            this.cb_menu.Size = new System.Drawing.Size(338, 28);
            this.cb_menu.TabIndex = 43;
            this.cb_menu.SelectedIndexChanged += new System.EventHandler(this.cb_menu_SelectedIndexChanged);
            // 
            // btn_savePermission
            // 
            this.btn_savePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_savePermission.Image = ((System.Drawing.Image)(resources.GetObject("btn_savePermission.Image")));
            this.btn_savePermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_savePermission.Location = new System.Drawing.Point(420, 62);
            this.btn_savePermission.Margin = new System.Windows.Forms.Padding(8);
            this.btn_savePermission.Name = "btn_savePermission";
            this.btn_savePermission.Size = new System.Drawing.Size(116, 39);
            this.btn_savePermission.TabIndex = 41;
            this.btn_savePermission.Text = "เพิ่มตาราง";
            this.btn_savePermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_savePermission.UseVisualStyleBackColor = true;
            this.btn_savePermission.Click += new System.EventHandler(this.btn_savePermission_Click);
            // 
            // btn_addUser
            // 
            this.btn_addUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_addUser.Image = ((System.Drawing.Image)(resources.GetObject("btn_addUser.Image")));
            this.btn_addUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addUser.Location = new System.Drawing.Point(420, 19);
            this.btn_addUser.Margin = new System.Windows.Forms.Padding(8);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(116, 39);
            this.btn_addUser.TabIndex = 42;
            this.btn_addUser.Text = "ดึง AD";
            this.btn_addUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_addUser.UseVisualStyleBackColor = true;
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // dtg_menu
            // 
            this.dtg_menu.AllowUserToAddRows = false;
            this.dtg_menu.AllowUserToDeleteRows = false;
            this.dtg_menu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_menu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_menu.Location = new System.Drawing.Point(3, 3);
            this.dtg_menu.Name = "dtg_menu";
            this.dtg_menu.RowHeadersWidth = 11;
            this.dtg_menu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_menu.Size = new System.Drawing.Size(1123, 394);
            this.dtg_menu.TabIndex = 45;
            this.dtg_menu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_menu_CellMouseClick);
            this.dtg_menu.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_menu_CellValueChanged);
            // 
            // cbo_user
            // 
            this.cbo_user.FormattingEnabled = true;
            this.cbo_user.Location = new System.Drawing.Point(57, 35);
            this.cbo_user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_user.Name = "cbo_user";
            this.cbo_user.Size = new System.Drawing.Size(336, 28);
            this.cbo_user.TabIndex = 54;
            this.cbo_user.SelectedIndexChanged += new System.EventHandler(this.cbo_user_SelectedIndexChanged);
            // 
            // tb_menuType
            // 
            this.tb_menuType.Controls.Add(this.tabPage1);
            this.tb_menuType.Controls.Add(this.tabPage2);
            this.tb_menuType.Controls.Add(this.tabPage5);
            this.tb_menuType.Controls.Add(this.tabPage3);
            this.tb_menuType.Controls.Add(this.tabPage4);
            this.tb_menuType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_menuType.Location = new System.Drawing.Point(0, 138);
            this.tb_menuType.Name = "tb_menuType";
            this.tb_menuType.SelectedIndex = 0;
            this.tb_menuType.Size = new System.Drawing.Size(1137, 433);
            this.tb_menuType.TabIndex = 55;
            this.tb_menuType.SelectedIndexChanged += new System.EventHandler(this.tb_menuType_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtg_menu);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1129, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  เมนูใช้งาน";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtg_setting);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1129, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " หน้างานตั้งค่าหลัก";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtg_setting
            // 
            this.dtg_setting.AllowUserToAddRows = false;
            this.dtg_setting.AllowUserToDeleteRows = false;
            this.dtg_setting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_setting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_setting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_setting.Location = new System.Drawing.Point(3, 3);
            this.dtg_setting.Name = "dtg_setting";
            this.dtg_setting.RowHeadersWidth = 11;
            this.dtg_setting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_setting.Size = new System.Drawing.Size(1123, 394);
            this.dtg_setting.TabIndex = 46;
            this.dtg_setting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_setting_CellValueChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dtg_subsetting);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1129, 400);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = " หน้างานตั้งค่าย่อย";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dtg_subsetting
            // 
            this.dtg_subsetting.AllowUserToAddRows = false;
            this.dtg_subsetting.AllowUserToDeleteRows = false;
            this.dtg_subsetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_subsetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_subsetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_subsetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_subsetting.Location = new System.Drawing.Point(0, 0);
            this.dtg_subsetting.Name = "dtg_subsetting";
            this.dtg_subsetting.RowHeadersWidth = 11;
            this.dtg_subsetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_subsetting.Size = new System.Drawing.Size(1129, 400);
            this.dtg_subsetting.TabIndex = 47;
            this.dtg_subsetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_subsetting_CellValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtg_process);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1129, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " ขั้นตอนการทำงาน ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtg_process
            // 
            this.dtg_process.AllowUserToAddRows = false;
            this.dtg_process.AllowUserToDeleteRows = false;
            this.dtg_process.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_process.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_process.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_process.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_process.Location = new System.Drawing.Point(3, 3);
            this.dtg_process.Name = "dtg_process";
            this.dtg_process.RowHeadersWidth = 11;
            this.dtg_process.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_process.Size = new System.Drawing.Size(1123, 394);
            this.dtg_process.TabIndex = 46;
            this.dtg_process.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_process_CellValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dtg_report);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1129, 400);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = " รายงานต่าง ๆ ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dtg_report
            // 
            this.dtg_report.AllowUserToAddRows = false;
            this.dtg_report.AllowUserToDeleteRows = false;
            this.dtg_report.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_report.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtg_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_report.Location = new System.Drawing.Point(3, 3);
            this.dtg_report.Name = "dtg_report";
            this.dtg_report.RowHeadersWidth = 11;
            this.dtg_report.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_report.Size = new System.Drawing.Size(1123, 394);
            this.dtg_report.TabIndex = 46;
            this.dtg_report.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_report_CellValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_add);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gb_new);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 118);
            this.panel1.TabIndex = 56;
            // 
            // chk_add
            // 
            this.chk_add.AutoSize = true;
            this.chk_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chk_add.Image = ((System.Drawing.Image)(resources.GetObject("chk_add.Image")));
            this.chk_add.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chk_add.Location = new System.Drawing.Point(435, 4);
            this.chk_add.Name = "chk_add";
            this.chk_add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_add.Size = new System.Drawing.Size(40, 24);
            this.chk_add.TabIndex = 57;
            this.chk_add.Text = "   ";
            this.chk_add.UseVisualStyleBackColor = true;
            this.chk_add.CheckedChanged += new System.EventHandler(this.chk_add_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cbo_user);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 110);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา/เลือกพนักงาน:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // gb_new
            // 
            this.gb_new.Controls.Add(this.label1);
            this.gb_new.Controls.Add(this.cb_menutype);
            this.gb_new.Controls.Add(this.btn_savePermission);
            this.gb_new.Controls.Add(this.btn_addUser);
            this.gb_new.Controls.Add(this.cb_menu);
            this.gb_new.Controls.Add(this.label58);
            this.gb_new.Enabled = false;
            this.gb_new.Location = new System.Drawing.Point(431, 5);
            this.gb_new.Name = "gb_new";
            this.gb_new.Size = new System.Drawing.Size(552, 110);
            this.gb_new.TabIndex = 58;
            this.gb_new.TabStop = false;
            this.gb_new.Text = "          New";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "หมวด:";
            // 
            // cb_menutype
            // 
            this.cb_menutype.FormattingEnabled = true;
            this.cb_menutype.Location = new System.Drawing.Point(70, 24);
            this.cb_menutype.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_menutype.Name = "cb_menutype";
            this.cb_menutype.Size = new System.Drawing.Size(338, 28);
            this.cb_menutype.TabIndex = 55;
            this.cb_menutype.SelectedIndexChanged += new System.EventHandler(this.cb_menutype_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1137, 20);
            this.panel2.TabIndex = 57;
            // 
            // Sub_Fsecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 571);
            this.Controls.Add(this.tb_menuType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Sub_Fsecurity";
            this.Text = "Sub_Fsecurity";
            this.Load += new System.EventHandler(this.Sub_Fsecurity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_menu)).EndInit();
            this.tb_menuType.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_setting)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_subsetting)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_process)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_report)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_new.ResumeLayout(false);
            this.gb_new.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ComboBox cb_menu;
        private System.Windows.Forms.Button btn_savePermission;
        private System.Windows.Forms.Button btn_addUser;
        private System.Windows.Forms.DataGridView dtg_menu;
        private System.Windows.Forms.ComboBox cbo_user;
        private System.Windows.Forms.TabControl tb_menuType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtg_setting;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dtg_process;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dtg_report;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_menutype;
        private System.Windows.Forms.GroupBox gb_new;
        private System.Windows.Forms.CheckBox chk_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dtg_subsetting;
    }
}