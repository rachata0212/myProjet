namespace Truck_Analytics
{
    partial class F_Lab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Lab));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.rdo_manualkey = new System.Windows.Forms.RadioButton();
            this.rdo_importfile = new System.Windows.Forms.RadioButton();
            this.txt_qrcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtg_keymanual = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_login = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_datetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_DBName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_quae = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_trucktype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_truckno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_product = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_simplecode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtg_valuelab = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_keymanual)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_valuelab)).BeginInit();
            this.panel8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orchid;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1148, 41);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(474, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "บันทึกผลวิเคราะห์";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_close);
            this.groupBox1.Controls.Add(this.rdo_manualkey);
            this.groupBox1.Controls.Add(this.rdo_importfile);
            this.groupBox1.Controls.Add(this.txt_qrcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 162);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เลือกรูปแบบการบันทึกไฟล์";
            // 
            // btn_save
            // 
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_save.ForeColor = System.Drawing.Color.Navy;
            this.btn_save.Image = global::Truck_Analytics.Properties.Resources.post;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(274, 111);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(104, 35);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "บันทึก";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(143, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "ฟื้นฟู";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(12, 110);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(104, 35);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "ปิด";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // rdo_manualkey
            // 
            this.rdo_manualkey.AutoSize = true;
            this.rdo_manualkey.Checked = true;
            this.rdo_manualkey.Enabled = false;
            this.rdo_manualkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_manualkey.Location = new System.Drawing.Point(33, 25);
            this.rdo_manualkey.Name = "rdo_manualkey";
            this.rdo_manualkey.Size = new System.Drawing.Size(140, 24);
            this.rdo_manualkey.TabIndex = 0;
            this.rdo_manualkey.TabStop = true;
            this.rdo_manualkey.Text = "บันทึกผลด้วยคีย์มือ";
            this.rdo_manualkey.UseVisualStyleBackColor = true;
            this.rdo_manualkey.CheckedChanged += new System.EventHandler(this.rdo_manualkey_CheckedChanged);
            // 
            // rdo_importfile
            // 
            this.rdo_importfile.AutoSize = true;
            this.rdo_importfile.Enabled = false;
            this.rdo_importfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_importfile.Location = new System.Drawing.Point(186, 25);
            this.rdo_importfile.Name = "rdo_importfile";
            this.rdo_importfile.Size = new System.Drawing.Size(190, 24);
            this.rdo_importfile.TabIndex = 1;
            this.rdo_importfile.Text = "บันทึกผลจากแหล่งข้อมูลอื่น";
            this.rdo_importfile.UseVisualStyleBackColor = true;
            this.rdo_importfile.CheckedChanged += new System.EventHandler(this.rdo_importfile_CheckedChanged);
            // 
            // txt_qrcode
            // 
            this.txt_qrcode.Enabled = false;
            this.txt_qrcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_qrcode.Location = new System.Drawing.Point(99, 57);
            this.txt_qrcode.Name = "txt_qrcode";
            this.txt_qrcode.Size = new System.Drawing.Size(277, 35);
            this.txt_qrcode.TabIndex = 1;
            this.txt_qrcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_qrcode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_qrcode_MouseClick);
            this.txt_qrcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_qrcode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(10, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QR-Code :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 169);
            this.panel4.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtg_keymanual);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(0, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1148, 437);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "บันทึก/แก้ไขผลวิเคราะห์";
            // 
            // dtg_keymanual
            // 
            this.dtg_keymanual.AllowUserToAddRows = false;
            this.dtg_keymanual.AllowUserToDeleteRows = false;
            this.dtg_keymanual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_keymanual.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_keymanual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_keymanual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_keymanual.Enabled = false;
            this.dtg_keymanual.Location = new System.Drawing.Point(3, 22);
            this.dtg_keymanual.Name = "dtg_keymanual";
            this.dtg_keymanual.ReadOnly = true;
            this.dtg_keymanual.RowHeadersWidth = 11;
            this.dtg_keymanual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_keymanual.Size = new System.Drawing.Size(1142, 412);
            this.dtg_keymanual.TabIndex = 0;
            this.dtg_keymanual.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_keymanual_CellMouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_login,
            this.tool_datetime,
            this.tool_DBName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1148, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_login
            // 
            this.tool_login.Name = "tool_login";
            this.tool_login.Size = new System.Drawing.Size(75, 17);
            this.tool_login.Text = "Login Name:";
            // 
            // tool_datetime
            // 
            this.tool_datetime.Name = "tool_datetime";
            this.tool_datetime.Size = new System.Drawing.Size(67, 17);
            this.tool_datetime.Text = "Login Date:";
            // 
            // tool_DBName
            // 
            this.tool_DBName.Name = "tool_DBName";
            this.tool_DBName.Size = new System.Drawing.Size(93, 17);
            this.tool_DBName.Text = "Database Name:";
            // 
            // lbl_quae
            // 
            this.lbl_quae.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_quae.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_quae.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_quae.Location = new System.Drawing.Point(87, 29);
            this.lbl_quae.Name = "lbl_quae";
            this.lbl_quae.Size = new System.Drawing.Size(93, 42);
            this.lbl_quae.TabIndex = 0;
            this.lbl_quae.Text = "-";
            this.lbl_quae.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(12, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 37);
            this.label5.TabIndex = 1;
            this.label5.Text = "คิวที่";
            // 
            // txt_trucktype
            // 
            this.txt_trucktype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_trucktype.Location = new System.Drawing.Point(270, 53);
            this.txt_trucktype.Name = "txt_trucktype";
            this.txt_trucktype.ReadOnly = true;
            this.txt_trucktype.Size = new System.Drawing.Size(97, 26);
            this.txt_trucktype.TabIndex = 8;
            this.txt_trucktype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "เลขที่ตัวอย่าง:";
            // 
            // txt_truckno
            // 
            this.txt_truckno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_truckno.Location = new System.Drawing.Point(270, 19);
            this.txt_truckno.Name = "txt_truckno";
            this.txt_truckno.ReadOnly = true;
            this.txt_truckno.Size = new System.Drawing.Size(97, 26);
            this.txt_truckno.TabIndex = 7;
            this.txt_truckno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(58, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "สินค้า:";
            // 
            // txt_product
            // 
            this.txt_product.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_product.Location = new System.Drawing.Point(110, 129);
            this.txt_product.Name = "txt_product";
            this.txt_product.ReadOnly = true;
            this.txt_product.Size = new System.Drawing.Size(258, 26);
            this.txt_product.TabIndex = 6;
            this.txt_product.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(186, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "ทะเบียนรถ:";
            // 
            // txt_simplecode
            // 
            this.txt_simplecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_simplecode.Location = new System.Drawing.Point(110, 92);
            this.txt_simplecode.Name = "txt_simplecode";
            this.txt_simplecode.ReadOnly = true;
            this.txt_simplecode.Size = new System.Drawing.Size(258, 26);
            this.txt_simplecode.TabIndex = 1;
            this.txt_simplecode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(190, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "ประเภทรถ:";
            // 
            // dtg_valuelab
            // 
            this.dtg_valuelab.AllowUserToAddRows = false;
            this.dtg_valuelab.AllowUserToDeleteRows = false;
            this.dtg_valuelab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_valuelab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_valuelab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_valuelab.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_valuelab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_valuelab.Location = new System.Drawing.Point(0, 0);
            this.dtg_valuelab.Name = "dtg_valuelab";
            this.dtg_valuelab.ReadOnly = true;
            this.dtg_valuelab.RowHeadersWidth = 11;
            this.dtg_valuelab.Size = new System.Drawing.Size(380, 169);
            this.dtg_valuelab.TabIndex = 12;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dtg_valuelab);
            this.panel8.Controls.Add(this.groupBox3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(393, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(755, 169);
            this.panel8.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.lbl_quae);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_trucktype);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_product);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txt_simplecode);
            this.groupBox3.Controls.Add(this.txt_truckno);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox3.Location = new System.Drawing.Point(380, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 169);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ข้อมูลชั่ง";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Silver;
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 41);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1148, 169);
            this.panel9.TabIndex = 14;
            // 
            // F_Lab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(1148, 669);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Lab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab Manual";
            this.Load += new System.EventHandler(this.F_Lab_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_keymanual)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_valuelab)).EndInit();
            this.panel8.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_qrcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdo_importfile;
        private System.Windows.Forms.RadioButton rdo_manualkey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtg_keymanual;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tool_login;
        private System.Windows.Forms.ToolStripStatusLabel tool_datetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbl_quae;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_trucktype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_truckno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_product;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_simplecode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dtg_valuelab;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripStatusLabel tool_DBName;
    }
}