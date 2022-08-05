namespace SaleOrder
{
    partial class Frmcostsetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnstd = new System.Windows.Forms.Button();
            this.txtstd = new System.Windows.Forms.TextBox();
            this.txted = new System.Windows.Forms.TextBox();
            this.btned = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsaveedit = new System.Windows.Forms.Button();
            this.lblcount = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtkilomete = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgviewsdata = new System.Windows.Forms.DataGridView();
            this.bdviewcost = new System.Windows.Forms.BindingSource(this.components);
            this.dTrat = new SaleOrder.DTrat();
            this.cbnew = new System.Windows.Forms.CheckBox();
            this.cbtruckrate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgtruckrate = new System.Windows.Forms.DataGridView();
            this.bdtrpetruckrate = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbtypetruckrate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbfrom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idratecostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratecostkmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDFROMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewsdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdviewcost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgtruckrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdtrpetruckrate)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "การตั้งค่าระยะทาง";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ระยะทางเริ่มต้น:";
            // 
            // btnstd
            // 
            this.btnstd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnstd.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnstd.Location = new System.Drawing.Point(336, 55);
            this.btnstd.Name = "btnstd";
            this.btnstd.Size = new System.Drawing.Size(49, 23);
            this.btnstd.TabIndex = 2;
            this.btnstd.Text = ".....";
            this.btnstd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnstd.UseVisualStyleBackColor = true;
            this.btnstd.Click += new System.EventHandler(this.btnstd_Click);
            // 
            // txtstd
            // 
            this.txtstd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtstd.Location = new System.Drawing.Point(96, 55);
            this.txtstd.Name = "txtstd";
            this.txtstd.ReadOnly = true;
            this.txtstd.Size = new System.Drawing.Size(234, 22);
            this.txtstd.TabIndex = 3;
            // 
            // txted
            // 
            this.txted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txted.Location = new System.Drawing.Point(544, 55);
            this.txted.Name = "txted";
            this.txted.ReadOnly = true;
            this.txted.Size = new System.Drawing.Size(238, 22);
            this.txted.TabIndex = 6;
            // 
            // btned
            // 
            this.btned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btned.Location = new System.Drawing.Point(787, 55);
            this.btned.Name = "btned";
            this.btned.Size = new System.Drawing.Size(49, 23);
            this.btned.TabIndex = 5;
            this.btned.Text = ".....";
            this.btned.UseVisualStyleBackColor = true;
            this.btned.Click += new System.EventHandler(this.btned_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(459, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "ระยะทางสิ้นสุด:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnsaveedit);
            this.panel1.Controls.Add(this.lblcount);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 27);
            this.panel1.TabIndex = 34;
            // 
            // btnsaveedit
            // 
            this.btnsaveedit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnsaveedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsaveedit.ForeColor = System.Drawing.Color.Green;
            this.btnsaveedit.Location = new System.Drawing.Point(0, 0);
            this.btnsaveedit.Name = "btnsaveedit";
            this.btnsaveedit.Size = new System.Drawing.Size(96, 27);
            this.btnsaveedit.TabIndex = 36;
            this.btnsaveedit.Text = "บันทึก/แก้ไข";
            this.btnsaveedit.UseVisualStyleBackColor = true;
            this.btnsaveedit.Click += new System.EventHandler(this.btnsaveedit_Click);
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblcount.Location = new System.Drawing.Point(610, 6);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(0, 16);
            this.lblcount.TabIndex = 39;
            this.lblcount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Location = new System.Drawing.Point(770, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(72, 27);
            this.btnclose.TabIndex = 11;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtkilomete
            // 
            this.txtkilomete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtkilomete.Location = new System.Drawing.Point(97, 86);
            this.txtkilomete.Name = "txtkilomete";
            this.txtkilomete.ReadOnly = true;
            this.txtkilomete.Size = new System.Drawing.Size(89, 22);
            this.txtkilomete.TabIndex = 37;
            this.txtkilomete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkilomete_KeyPress);
            this.txtkilomete.TextChanged += new System.EventHandler(this.txtkilomete_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "ระยะทาง (กม.):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgviewsdata);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 392);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // dtgviewsdata
            // 
            this.dtgviewsdata.AllowUserToAddRows = false;
            this.dtgviewsdata.AllowUserToDeleteRows = false;
            this.dtgviewsdata.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgviewsdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgviewsdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewsdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDNODataGridViewTextBoxColumn,
            this.iDFROMDataGridViewTextBoxColumn,
            this.Branch,
            this.companyFromDataGridViewTextBoxColumn,
            this.iDTODataGridViewTextBoxColumn,
            this.companyTODataGridViewTextBoxColumn,
            this.distanceDataGridViewTextBoxColumn});
            this.dtgviewsdata.DataSource = this.bdviewcost;
            this.dtgviewsdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgviewsdata.Location = new System.Drawing.Point(3, 16);
            this.dtgviewsdata.Name = "dtgviewsdata";
            this.dtgviewsdata.RowHeadersWidth = 11;
            this.dtgviewsdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgviewsdata.Size = new System.Drawing.Size(836, 373);
            this.dtgviewsdata.TabIndex = 33;
            this.dtgviewsdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgviewsdata_CellEndEdit);
            this.dtgviewsdata.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgviewsdata_CellMouseClick);
            // 
            // bdviewcost
            // 
            this.bdviewcost.DataMember = "dtgcostrate";
            this.bdviewcost.DataSource = this.dTrat;
            // 
            // dTrat
            // 
            this.dTrat.DataSetName = "DTrat";
            this.dTrat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbnew
            // 
            this.cbnew.AutoSize = true;
            this.cbnew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbnew.Location = new System.Drawing.Point(787, 32);
            this.cbnew.Name = "cbnew";
            this.cbnew.Size = new System.Drawing.Size(48, 17);
            this.cbnew.TabIndex = 40;
            this.cbnew.Text = "New";
            this.cbnew.UseVisualStyleBackColor = true;
            this.cbnew.CheckedChanged += new System.EventHandler(this.cbnew_CheckedChanged);
            // 
            // cbtruckrate
            // 
            this.cbtruckrate.AutoSize = true;
            this.cbtruckrate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbtruckrate.Location = new System.Drawing.Point(759, 9);
            this.cbtruckrate.Name = "cbtruckrate";
            this.cbtruckrate.Size = new System.Drawing.Size(77, 17);
            this.cbtruckrate.TabIndex = 41;
            this.cbtruckrate.Text = "TruckRate";
            this.cbtruckrate.UseVisualStyleBackColor = true;
            this.cbtruckrate.CheckedChanged += new System.EventHandler(this.cbtruckrate_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgtruckrate);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(421, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 311);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Truck Setting";
            this.groupBox2.Visible = false;
            // 
            // dtgtruckrate
            // 
            this.dtgtruckrate.AllowUserToAddRows = false;
            this.dtgtruckrate.AllowUserToDeleteRows = false;
            this.dtgtruckrate.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgtruckrate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgtruckrate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgtruckrate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idratecostDataGridViewTextBoxColumn,
            this.ratecostkmDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dtgtruckrate.DataSource = this.bdtrpetruckrate;
            this.dtgtruckrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgtruckrate.Location = new System.Drawing.Point(3, 40);
            this.dtgtruckrate.Name = "dtgtruckrate";
            this.dtgtruckrate.RowHeadersWidth = 11;
            this.dtgtruckrate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgtruckrate.Size = new System.Drawing.Size(326, 268);
            this.dtgtruckrate.TabIndex = 34;
            this.dtgtruckrate.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgtruckrate_CellEndEdit);
            // 
            // bdtrpetruckrate
            // 
            this.bdtrpetruckrate.DataMember = "dttruckrate";
            this.bdtrpetruckrate.DataSource = this.dTrat;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbtypetruckrate);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 24);
            this.panel2.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(206, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Operator >=";
            // 
            // cbtypetruckrate
            // 
            this.cbtypetruckrate.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbtypetruckrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbtypetruckrate.FormattingEnabled = true;
            this.cbtypetruckrate.Location = new System.Drawing.Point(54, 0);
            this.cbtypetruckrate.Name = "cbtypetruckrate";
            this.cbtypetruckrate.Size = new System.Drawing.Size(152, 24);
            this.cbtypetruckrate.TabIndex = 37;
            this.cbtypetruckrate.SelectedIndexChanged += new System.EventHandler(this.cbtypetruckrate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "กลุ่มรถวิ่ง:";
            // 
            // cbfrom
            // 
            this.cbfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbfrom.FormattingEnabled = true;
            this.cbfrom.Location = new System.Drawing.Point(595, 86);
            this.cbfrom.Name = "cbfrom";
            this.cbfrom.Size = new System.Drawing.Size(241, 24);
            this.cbfrom.TabIndex = 44;
            this.cbfrom.SelectedIndexChanged += new System.EventHandler(this.cbfrom_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(541, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "ค้นหาจาก:";
            // 
            // idratecostDataGridViewTextBoxColumn
            // 
            this.idratecostDataGridViewTextBoxColumn.DataPropertyName = "idratecost";
            this.idratecostDataGridViewTextBoxColumn.HeaderText = "IDNO";
            this.idratecostDataGridViewTextBoxColumn.Name = "idratecostDataGridViewTextBoxColumn";
            this.idratecostDataGridViewTextBoxColumn.ToolTipText = "ลำดับที่";
            this.idratecostDataGridViewTextBoxColumn.Width = 60;
            // 
            // ratecostkmDataGridViewTextBoxColumn
            // 
            this.ratecostkmDataGridViewTextBoxColumn.DataPropertyName = "ratecostkm";
            this.ratecostkmDataGridViewTextBoxColumn.HeaderText = "Distance (KM)";
            this.ratecostkmDataGridViewTextBoxColumn.Name = "ratecostkmDataGridViewTextBoxColumn";
            this.ratecostkmDataGridViewTextBoxColumn.ToolTipText = "ระยะทาง (กม.)";
            this.ratecostkmDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price (Baht)";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ToolTipText = "ค่าตอบแทนที่ได้";
            this.priceDataGridViewTextBoxColumn.Width = 120;
            // 
            // iDNODataGridViewTextBoxColumn
            // 
            this.iDNODataGridViewTextBoxColumn.DataPropertyName = "IDNO";
            this.iDNODataGridViewTextBoxColumn.HeaderText = "IDNO";
            this.iDNODataGridViewTextBoxColumn.Name = "iDNODataGridViewTextBoxColumn";
            this.iDNODataGridViewTextBoxColumn.ToolTipText = "ลำดับที่";
            this.iDNODataGridViewTextBoxColumn.Width = 50;
            // 
            // iDFROMDataGridViewTextBoxColumn
            // 
            this.iDFROMDataGridViewTextBoxColumn.DataPropertyName = "IDFROM";
            this.iDFROMDataGridViewTextBoxColumn.HeaderText = "IDFROM";
            this.iDFROMDataGridViewTextBoxColumn.Name = "iDFROMDataGridViewTextBoxColumn";
            this.iDFROMDataGridViewTextBoxColumn.ToolTipText = "เลขที่ต้นทาง";
            this.iDFROMDataGridViewTextBoxColumn.Width = 60;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "Branch";
            this.Branch.HeaderText = "Branch";
            this.Branch.Name = "Branch";
            this.Branch.ToolTipText = "สาขาต้นทาง";
            // 
            // companyFromDataGridViewTextBoxColumn
            // 
            this.companyFromDataGridViewTextBoxColumn.DataPropertyName = "CompanyFrom";
            this.companyFromDataGridViewTextBoxColumn.HeaderText = "CompanyFrom";
            this.companyFromDataGridViewTextBoxColumn.Name = "companyFromDataGridViewTextBoxColumn";
            this.companyFromDataGridViewTextBoxColumn.ToolTipText = "บริษัทต้นทาง";
            this.companyFromDataGridViewTextBoxColumn.Width = 180;
            // 
            // iDTODataGridViewTextBoxColumn
            // 
            this.iDTODataGridViewTextBoxColumn.DataPropertyName = "IDTO";
            this.iDTODataGridViewTextBoxColumn.HeaderText = "IDTO";
            this.iDTODataGridViewTextBoxColumn.Name = "iDTODataGridViewTextBoxColumn";
            this.iDTODataGridViewTextBoxColumn.ToolTipText = "เลขที่ปลายทาง";
            this.iDTODataGridViewTextBoxColumn.Width = 60;
            // 
            // companyTODataGridViewTextBoxColumn
            // 
            this.companyTODataGridViewTextBoxColumn.DataPropertyName = "CompanyTO";
            this.companyTODataGridViewTextBoxColumn.HeaderText = "CompanyTO";
            this.companyTODataGridViewTextBoxColumn.Name = "companyTODataGridViewTextBoxColumn";
            this.companyTODataGridViewTextBoxColumn.ToolTipText = "บริษัทปลายทาง";
            this.companyTODataGridViewTextBoxColumn.Width = 250;
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            this.distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            this.distanceDataGridViewTextBoxColumn.HeaderText = "Distance (KM)";
            this.distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            this.distanceDataGridViewTextBoxColumn.ToolTipText = "ระยะทาง (กิโลเมตร)";
            // 
            // Frmcostsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 528);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbfrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbtruckrate);
            this.Controls.Add(this.cbnew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtkilomete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txted);
            this.Controls.Add(this.btned);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtstd);
            this.Controls.Add(this.btnstd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmcostsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cost Setting";
            this.Load += new System.EventHandler(this.Frmcostsetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewsdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdviewcost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgtruckrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdtrpetruckrate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnstd;
        private System.Windows.Forms.TextBox txtstd;
        private System.Windows.Forms.TextBox txted;
        private System.Windows.Forms.Button btned;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnsaveedit;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtkilomete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource bdviewcost;
        private DTrat dTrat;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.CheckBox cbnew;
        private System.Windows.Forms.CheckBox cbtruckrate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbtypetruckrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtgtruckrate;
        private System.Windows.Forms.BindingSource bdtrpetruckrate;
        private System.Windows.Forms.DataGridView dtgviewsdata;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFROMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idratecostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratecostkmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}