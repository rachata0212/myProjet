namespace SaleOrder
{
    partial class Frmrateoilsetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbtyperate = new System.Windows.Forms.ComboBox();
            this.btnsearchemp = new System.Windows.Forms.Button();
            this.txtremarktruck = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtempname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtserailcar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.dtpdateexprie = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblcount = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnremoveItem = new System.Windows.Forms.Button();
            this.btninsertItem = new System.Windows.Forms.Button();
            this.txtremarkwarning = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbnamewarning = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbdaywarning = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgwarning = new System.Windows.Forms.DataGridView();
            this.idtypewarningDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nametypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datewarningDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daywaringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daydicountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdwarning = new System.Windows.Forms.BindingSource(this.components);
            this.dTrat = new SaleOrder.DTrat();
            this.label5 = new System.Windows.Forms.Label();
            this.txtrateoil = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgwarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdwarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "บันทึกค่าเริ่มต้นของรถในการใช้งาน";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtrateoil);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbtyperate);
            this.groupBox1.Controls.Add(this.btnsearchemp);
            this.groupBox1.Controls.Add(this.txtremarktruck);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtempname);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtserailcar);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(1, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 112);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // cbtyperate
            // 
            this.cbtyperate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbtyperate.FormattingEnabled = true;
            this.cbtyperate.Location = new System.Drawing.Point(487, 55);
            this.cbtyperate.Name = "cbtyperate";
            this.cbtyperate.Size = new System.Drawing.Size(142, 24);
            this.cbtyperate.TabIndex = 40;
            // 
            // btnsearchemp
            // 
            this.btnsearchemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsearchemp.ForeColor = System.Drawing.Color.Red;
            this.btnsearchemp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnsearchemp.Location = new System.Drawing.Point(300, 53);
            this.btnsearchemp.Name = "btnsearchemp";
            this.btnsearchemp.Size = new System.Drawing.Size(43, 25);
            this.btnsearchemp.TabIndex = 39;
            this.btnsearchemp.Text = "....";
            this.btnsearchemp.UseVisualStyleBackColor = true;
            this.btnsearchemp.Click += new System.EventHandler(this.btnsearchemp_Click_1);
            // 
            // txtremarktruck
            // 
            this.txtremarktruck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtremarktruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtremarktruck.Location = new System.Drawing.Point(75, 84);
            this.txtremarktruck.Name = "txtremarktruck";
            this.txtremarktruck.Size = new System.Drawing.Size(285, 22);
            this.txtremarktruck.TabIndex = 37;
            this.txtremarktruck.Text = "- ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.Location = new System.Drawing.Point(13, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 18);
            this.label18.TabIndex = 38;
            this.label18.Text = "หมายเหตุ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.Location = new System.Drawing.Point(356, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 18);
            this.label17.TabIndex = 35;
            this.label17.Text = "ประเภทการคิดเรทรถ:";
            // 
            // txtempname
            // 
            this.txtempname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtempname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtempname.Location = new System.Drawing.Point(107, 53);
            this.txtempname.Name = "txtempname";
            this.txtempname.ReadOnly = true;
            this.txtempname.Size = new System.Drawing.Size(187, 22);
            this.txtempname.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(11, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "พนักงานขับรถ:";
            // 
            // txtserailcar
            // 
            this.txtserailcar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtserailcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtserailcar.Location = new System.Drawing.Point(434, 20);
            this.txtserailcar.Name = "txtserailcar";
            this.txtserailcar.Size = new System.Drawing.Size(195, 29);
            this.txtserailcar.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(297, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = "ทะเบียน/เบอร์รถ:";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbldate.Location = new System.Drawing.Point(474, 22);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(63, 18);
            this.lbldate.TabIndex = 43;
            this.lbldate.Text = "วันที่หมด:";
            // 
            // dtpdateexprie
            // 
            this.dtpdateexprie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpdateexprie.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdateexprie.Location = new System.Drawing.Point(535, 22);
            this.dtpdateexprie.Name = "dtpdateexprie";
            this.dtpdateexprie.Size = new System.Drawing.Size(95, 22);
            this.dtpdateexprie.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblcount);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 27);
            this.panel1.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(384, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 17);
            this.textBox1.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(412, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "หมายถึง: เตรียมทำการต่ออายุ";
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblcount.Location = new System.Drawing.Point(5, 5);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(0, 18);
            this.lblcount.TabIndex = 62;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(556, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(91, 27);
            this.btnsave.TabIndex = 13;
            this.btnsave.Text = "บันทึก/ปิด";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnremoveItem);
            this.groupBox2.Controls.Add(this.btninsertItem);
            this.groupBox2.Controls.Add(this.txtremarkwarning);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbnamewarning);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbdaywarning);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtpdateexprie);
            this.groupBox2.Controls.Add(this.lbldate);
            this.groupBox2.Location = new System.Drawing.Point(1, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 77);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "การแจ้งเตือน";
            // 
            // btnremoveItem
            // 
            this.btnremoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnremoveItem.ForeColor = System.Drawing.Color.Red;
            this.btnremoveItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnremoveItem.Location = new System.Drawing.Point(592, 49);
            this.btnremoveItem.Name = "btnremoveItem";
            this.btnremoveItem.Size = new System.Drawing.Size(37, 25);
            this.btnremoveItem.TabIndex = 42;
            this.btnremoveItem.Text = "X";
            this.btnremoveItem.UseVisualStyleBackColor = true;
            this.btnremoveItem.Click += new System.EventHandler(this.btnremoveItem_Click);
            // 
            // btninsertItem
            // 
            this.btninsertItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btninsertItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btninsertItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btninsertItem.Location = new System.Drawing.Point(553, 49);
            this.btninsertItem.Name = "btninsertItem";
            this.btninsertItem.Size = new System.Drawing.Size(37, 25);
            this.btninsertItem.TabIndex = 41;
            this.btninsertItem.Text = "V";
            this.btninsertItem.UseVisualStyleBackColor = true;
            this.btninsertItem.Click += new System.EventHandler(this.btninsertItem_Click);
            // 
            // txtremarkwarning
            // 
            this.txtremarkwarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtremarkwarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtremarkwarning.Location = new System.Drawing.Point(75, 50);
            this.txtremarkwarning.Name = "txtremarkwarning";
            this.txtremarkwarning.Size = new System.Drawing.Size(472, 22);
            this.txtremarkwarning.TabIndex = 41;
            this.txtremarkwarning.Text = "- ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 42;
            this.label3.Text = "หมายเหตุ";
            // 
            // cbnamewarning
            // 
            this.cbnamewarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbnamewarning.FormattingEnabled = true;
            this.cbnamewarning.Location = new System.Drawing.Point(99, 19);
            this.cbnamewarning.Name = "cbnamewarning";
            this.cbnamewarning.Size = new System.Drawing.Size(169, 24);
            this.cbnamewarning.TabIndex = 60;
            this.cbnamewarning.Text = "ประกันภัยภาคบังคับ (พรบ.)";
            this.cbnamewarning.SelectedIndexChanged += new System.EventHandler(this.cbnamewarning_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 61;
            this.label2.Text = "รายการติดตาม:";
            // 
            // cbdaywarning
            // 
            this.cbdaywarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbdaywarning.FormattingEnabled = true;
            this.cbdaywarning.Items.AddRange(new object[] {
            "15",
            "20",
            "25",
            "30",
            "45",
            "60",
            "90"});
            this.cbdaywarning.Location = new System.Drawing.Point(408, 19);
            this.cbdaywarning.Name = "cbdaywarning";
            this.cbdaywarning.Size = new System.Drawing.Size(58, 24);
            this.cbdaywarning.TabIndex = 59;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(278, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 18);
            this.label12.TabIndex = 58;
            this.label12.Text = "จำนวนวัน ที่แจ้งเตือน:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgwarning);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 218);
            this.panel2.TabIndex = 22;
            // 
            // dtgwarning
            // 
            this.dtgwarning.AllowUserToAddRows = false;
            this.dtgwarning.AllowUserToDeleteRows = false;
            this.dtgwarning.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgwarning.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgwarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgwarning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtypewarningDataGridViewTextBoxColumn,
            this.nametypeDataGridViewTextBoxColumn,
            this.datewarningDataGridViewTextBoxColumn,
            this.daywaringDataGridViewTextBoxColumn,
            this.daydicountDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.dtgwarning.DataSource = this.bdwarning;
            this.dtgwarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgwarning.Location = new System.Drawing.Point(0, 0);
            this.dtgwarning.Name = "dtgwarning";
            this.dtgwarning.ReadOnly = true;
            this.dtgwarning.RowHeadersWidth = 11;
            this.dtgwarning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgwarning.Size = new System.Drawing.Size(647, 218);
            this.dtgwarning.TabIndex = 0;
            this.dtgwarning.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgwarning_CellMouseClick);
            // 
            // idtypewarningDataGridViewTextBoxColumn
            // 
            this.idtypewarningDataGridViewTextBoxColumn.DataPropertyName = "idtypewarning";
            this.idtypewarningDataGridViewTextBoxColumn.HeaderText = "iDNo";
            this.idtypewarningDataGridViewTextBoxColumn.Name = "idtypewarningDataGridViewTextBoxColumn";
            this.idtypewarningDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtypewarningDataGridViewTextBoxColumn.Width = 50;
            // 
            // nametypeDataGridViewTextBoxColumn
            // 
            this.nametypeDataGridViewTextBoxColumn.DataPropertyName = "nametype";
            this.nametypeDataGridViewTextBoxColumn.HeaderText = "เรื่องที่ให้เตือน";
            this.nametypeDataGridViewTextBoxColumn.Name = "nametypeDataGridViewTextBoxColumn";
            this.nametypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nametypeDataGridViewTextBoxColumn.Width = 192;
            // 
            // datewarningDataGridViewTextBoxColumn
            // 
            this.datewarningDataGridViewTextBoxColumn.DataPropertyName = "datewarning";
            this.datewarningDataGridViewTextBoxColumn.HeaderText = "วันที่หมดอายุ";
            this.datewarningDataGridViewTextBoxColumn.Name = "datewarningDataGridViewTextBoxColumn";
            this.datewarningDataGridViewTextBoxColumn.ReadOnly = true;
            this.datewarningDataGridViewTextBoxColumn.Width = 90;
            // 
            // daywaringDataGridViewTextBoxColumn
            // 
            this.daywaringDataGridViewTextBoxColumn.DataPropertyName = "daywaring";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.daywaringDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.daywaringDataGridViewTextBoxColumn.HeaderText = "จนว.เตือน";
            this.daywaringDataGridViewTextBoxColumn.Name = "daywaringDataGridViewTextBoxColumn";
            this.daywaringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // daydicountDataGridViewTextBoxColumn
            // 
            this.daydicountDataGridViewTextBoxColumn.DataPropertyName = "daydicount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.daydicountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.daydicountDataGridViewTextBoxColumn.HeaderText = "วันคงเหลือ";
            this.daydicountDataGridViewTextBoxColumn.Name = "daydicountDataGridViewTextBoxColumn";
            this.daydicountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "หมายเหตุ";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bdwarning
            // 
            this.bdwarning.DataMember = "dtwarningtruck";
            this.bdwarning.DataSource = this.dTrat;
            // 
            // dTrat
            // 
            this.dTrat.DataSetName = "DTrat";
            this.dTrat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(366, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "เรทที่ใช้ กม.,ชม./ลิตร:";
            // 
            // txtrateoil
            // 
            this.txtrateoil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrateoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtrateoil.Location = new System.Drawing.Point(503, 84);
            this.txtrateoil.Name = "txtrateoil";
            this.txtrateoil.Size = new System.Drawing.Size(125, 22);
            this.txtrateoil.TabIndex = 42;
            this.txtrateoil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrateoil_KeyPress);
            // 
            // Frmrateoilsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 485);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmrateoilsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rate-Setting";
            this.Load += new System.EventHandler(this.Frmrateoilsetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgwarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdwarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtremarktruck;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtempname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtserailcar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbtyperate;
        private System.Windows.Forms.Button btnsearchemp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.DateTimePicker dtpdateexprie;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbdaywarning;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbnamewarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgwarning;
        private System.Windows.Forms.BindingSource bdwarning;
        private DTrat dTrat;
        private System.Windows.Forms.Button btninsertItem;
        private System.Windows.Forms.Button btnremoveItem;
        private System.Windows.Forms.TextBox txtremarkwarning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtypewarningDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nametypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datewarningDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daywaringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daydicountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtrateoil;
        private System.Windows.Forms.Label label5;
    }
}