namespace SaleOrder
{
    partial class Frmcompany
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnaddedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.lblcountbranch = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbselecttypecom = new System.Windows.Forms.ComboBox();
            this.dtgbranch = new System.Windows.Forms.DataGridView();
            this.idbranchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tumbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zipcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdbranch = new System.Windows.Forms.BindingSource(this.components);
            this.dtssaleorder = new SaleOrder.dtssaleorder();
            this.dtgcompany = new System.Windows.Forms.DataGridView();
            this.idcomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdcompany = new System.Windows.Forms.BindingSource(this.components);
            this.lblinformation2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblinformation1 = new System.Windows.Forms.Label();
            this.cbaddbranch = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnoption = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbaddcom = new System.Windows.Forms.CheckBox();
            this.lblcountcom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdbranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgcompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdcompany)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(48, 38);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(222, 24);
            this.txtsearch.TabIndex = 15;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "ค้นหา:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnaddedit);
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 642);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 26);
            this.panel3.TabIndex = 64;
            // 
            // btnaddedit
            // 
            this.btnaddedit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnaddedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnaddedit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnaddedit.Location = new System.Drawing.Point(559, 0);
            this.btnaddedit.Name = "btnaddedit";
            this.btnaddedit.Size = new System.Drawing.Size(83, 26);
            this.btnaddedit.TabIndex = 11;
            this.btnaddedit.Text = "บันทึกข้อมูล";
            this.btnaddedit.UseVisualStyleBackColor = true;
            this.btnaddedit.Click += new System.EventHandler(this.btnaddedit_Click);
            // 
            // btnexit
            // 
            this.btnexit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnexit.ForeColor = System.Drawing.Color.Red;
            this.btnexit.Location = new System.Drawing.Point(642, 0);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(83, 26);
            this.btnexit.TabIndex = 12;
            this.btnexit.Text = "ปิด";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click_1);
            // 
            // lblcountbranch
            // 
            this.lblcountbranch.AutoSize = true;
            this.lblcountbranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountbranch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblcountbranch.Location = new System.Drawing.Point(623, 6);
            this.lblcountbranch.Name = "lblcountbranch";
            this.lblcountbranch.Size = new System.Drawing.Size(37, 15);
            this.lblcountbranch.TabIndex = 79;
            this.lblcountbranch.Text = "Items";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 70;
            this.label6.Text = "ประเภทบริษัท:";
            // 
            // cbselecttypecom
            // 
            this.cbselecttypecom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbselecttypecom.FormattingEnabled = true;
            this.cbselecttypecom.Location = new System.Drawing.Point(94, 6);
            this.cbselecttypecom.Name = "cbselecttypecom";
            this.cbselecttypecom.Size = new System.Drawing.Size(176, 26);
            this.cbselecttypecom.TabIndex = 71;
            this.cbselecttypecom.SelectedIndexChanged += new System.EventHandler(this.cbselecttypecom_SelectedIndexChanged);
            // 
            // dtgbranch
            // 
            this.dtgbranch.AllowUserToAddRows = false;
            this.dtgbranch.AllowUserToDeleteRows = false;
            this.dtgbranch.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgbranch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgbranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idbranchDataGridViewTextBoxColumn,
            this.bnameDataGridViewTextBoxColumn1,
            this.baddressDataGridViewTextBoxColumn,
            this.rdDataGridViewTextBoxColumn,
            this.tumbDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.proviceDataGridViewTextBoxColumn,
            this.zipcodeDataGridViewTextBoxColumn,
            this.telDataGridViewTextBoxColumn,
            this.faxDataGridViewTextBoxColumn,
            this.contactDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn3});
            this.dtgbranch.DataSource = this.bdbranch;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgbranch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgbranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgbranch.Location = new System.Drawing.Point(0, 26);
            this.dtgbranch.Name = "dtgbranch";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgbranch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgbranch.RowHeadersWidth = 10;
            this.dtgbranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgbranch.Size = new System.Drawing.Size(725, 192);
            this.dtgbranch.TabIndex = 72;
            this.dtgbranch.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbranch_CellEndEdit);
            this.dtgbranch.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgbranch_CellMouseClick);
            // 
            // idbranchDataGridViewTextBoxColumn
            // 
            this.idbranchDataGridViewTextBoxColumn.DataPropertyName = "idbranch";
            this.idbranchDataGridViewTextBoxColumn.HeaderText = "เลขที่";
            this.idbranchDataGridViewTextBoxColumn.Name = "idbranchDataGridViewTextBoxColumn";
            this.idbranchDataGridViewTextBoxColumn.Width = 80;
            // 
            // bnameDataGridViewTextBoxColumn1
            // 
            this.bnameDataGridViewTextBoxColumn1.DataPropertyName = "bname";
            this.bnameDataGridViewTextBoxColumn1.HeaderText = "ชื่อสาขา";
            this.bnameDataGridViewTextBoxColumn1.Name = "bnameDataGridViewTextBoxColumn1";
            this.bnameDataGridViewTextBoxColumn1.Width = 150;
            // 
            // baddressDataGridViewTextBoxColumn
            // 
            this.baddressDataGridViewTextBoxColumn.DataPropertyName = "baddress";
            this.baddressDataGridViewTextBoxColumn.HeaderText = "เลขที่";
            this.baddressDataGridViewTextBoxColumn.Name = "baddressDataGridViewTextBoxColumn";
            this.baddressDataGridViewTextBoxColumn.Width = 80;
            // 
            // rdDataGridViewTextBoxColumn
            // 
            this.rdDataGridViewTextBoxColumn.DataPropertyName = "rd";
            this.rdDataGridViewTextBoxColumn.HeaderText = "ถนน";
            this.rdDataGridViewTextBoxColumn.Name = "rdDataGridViewTextBoxColumn";
            // 
            // tumbDataGridViewTextBoxColumn
            // 
            this.tumbDataGridViewTextBoxColumn.DataPropertyName = "tumb";
            this.tumbDataGridViewTextBoxColumn.HeaderText = "ตำบล/แขวง";
            this.tumbDataGridViewTextBoxColumn.Name = "tumbDataGridViewTextBoxColumn";
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "อำเภอ/เขต";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // proviceDataGridViewTextBoxColumn
            // 
            this.proviceDataGridViewTextBoxColumn.DataPropertyName = "provice";
            this.proviceDataGridViewTextBoxColumn.HeaderText = "จังหวัด";
            this.proviceDataGridViewTextBoxColumn.Name = "proviceDataGridViewTextBoxColumn";
            // 
            // zipcodeDataGridViewTextBoxColumn
            // 
            this.zipcodeDataGridViewTextBoxColumn.DataPropertyName = "zipcode";
            this.zipcodeDataGridViewTextBoxColumn.HeaderText = "รหัสไปรษณีย์";
            this.zipcodeDataGridViewTextBoxColumn.Name = "zipcodeDataGridViewTextBoxColumn";
            // 
            // telDataGridViewTextBoxColumn
            // 
            this.telDataGridViewTextBoxColumn.DataPropertyName = "tel";
            this.telDataGridViewTextBoxColumn.HeaderText = "เบอร์โทร";
            this.telDataGridViewTextBoxColumn.Name = "telDataGridViewTextBoxColumn";
            // 
            // faxDataGridViewTextBoxColumn
            // 
            this.faxDataGridViewTextBoxColumn.DataPropertyName = "fax";
            this.faxDataGridViewTextBoxColumn.HeaderText = "แฟ็กซ์";
            this.faxDataGridViewTextBoxColumn.Name = "faxDataGridViewTextBoxColumn";
            // 
            // contactDataGridViewTextBoxColumn
            // 
            this.contactDataGridViewTextBoxColumn.DataPropertyName = "contact";
            this.contactDataGridViewTextBoxColumn.HeaderText = "ผู้ติดต่อ";
            this.contactDataGridViewTextBoxColumn.Name = "contactDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn3
            // 
            this.remarkDataGridViewTextBoxColumn3.DataPropertyName = "remark";
            this.remarkDataGridViewTextBoxColumn3.HeaderText = "หมายเหตุ";
            this.remarkDataGridViewTextBoxColumn3.Name = "remarkDataGridViewTextBoxColumn3";
            this.remarkDataGridViewTextBoxColumn3.Width = 120;
            // 
            // bdbranch
            // 
            this.bdbranch.DataMember = "tbbranch";
            this.bdbranch.DataSource = this.dtssaleorder;
            // 
            // dtssaleorder
            // 
            this.dtssaleorder.DataSetName = "dtssaleorder";
            this.dtssaleorder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtgcompany
            // 
            this.dtgcompany.AllowUserToAddRows = false;
            this.dtgcompany.AllowUserToDeleteRows = false;
            this.dtgcompany.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgcompany.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgcompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgcompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcomDataGridViewTextBoxColumn,
            this.cnameDataGridViewTextBoxColumn1,
            this.cremarkDataGridViewTextBoxColumn});
            this.dtgcompany.DataSource = this.bdcompany;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgcompany.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgcompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgcompany.Location = new System.Drawing.Point(0, 26);
            this.dtgcompany.Name = "dtgcompany";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgcompany.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgcompany.RowHeadersWidth = 10;
            this.dtgcompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgcompany.Size = new System.Drawing.Size(725, 328);
            this.dtgcompany.TabIndex = 74;
            this.dtgcompany.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgcompany_CellEndEdit);
            this.dtgcompany.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgcompany_CellMouseClick);
            // 
            // idcomDataGridViewTextBoxColumn
            // 
            this.idcomDataGridViewTextBoxColumn.DataPropertyName = "idcom";
            this.idcomDataGridViewTextBoxColumn.HeaderText = "เลขที่";
            this.idcomDataGridViewTextBoxColumn.Name = "idcomDataGridViewTextBoxColumn";
            this.idcomDataGridViewTextBoxColumn.Width = 80;
            // 
            // cnameDataGridViewTextBoxColumn1
            // 
            this.cnameDataGridViewTextBoxColumn1.DataPropertyName = "cname";
            this.cnameDataGridViewTextBoxColumn1.HeaderText = "ชื่อบริษัท";
            this.cnameDataGridViewTextBoxColumn1.Name = "cnameDataGridViewTextBoxColumn1";
            this.cnameDataGridViewTextBoxColumn1.Width = 380;
            // 
            // cremarkDataGridViewTextBoxColumn
            // 
            this.cremarkDataGridViewTextBoxColumn.DataPropertyName = "cremark";
            this.cremarkDataGridViewTextBoxColumn.HeaderText = "หมายเหตุ";
            this.cremarkDataGridViewTextBoxColumn.Name = "cremarkDataGridViewTextBoxColumn";
            this.cremarkDataGridViewTextBoxColumn.Width = 250;
            // 
            // bdcompany
            // 
            this.bdcompany.DataMember = "dtcompany";
            this.bdcompany.DataSource = this.dtssaleorder;
            // 
            // lblinformation2
            // 
            this.lblinformation2.AutoSize = true;
            this.lblinformation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinformation2.Location = new System.Drawing.Point(276, 41);
            this.lblinformation2.Name = "lblinformation2";
            this.lblinformation2.Size = new System.Drawing.Size(196, 18);
            this.lblinformation2.TabIndex = 77;
            this.lblinformation2.Text = "(พิมพ์อย่างน้อย 2 ตัวอักษรขึ้นไป)";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblinformation1);
            this.panel4.Controls.Add(this.lblinformation2);
            this.panel4.Controls.Add(this.cbselecttypecom);
            this.panel4.Controls.Add(this.txtsearch);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(725, 70);
            this.panel4.TabIndex = 78;
            // 
            // lblinformation1
            // 
            this.lblinformation1.AutoSize = true;
            this.lblinformation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinformation1.Location = new System.Drawing.Point(276, 9);
            this.lblinformation1.Name = "lblinformation1";
            this.lblinformation1.Size = new System.Drawing.Size(74, 18);
            this.lblinformation1.TabIndex = 78;
            this.lblinformation1.Text = "Messager";
            // 
            // cbaddbranch
            // 
            this.cbaddbranch.AutoSize = true;
            this.cbaddbranch.Location = new System.Drawing.Point(87, 6);
            this.cbaddbranch.Name = "cbaddbranch";
            this.cbaddbranch.Size = new System.Drawing.Size(88, 17);
            this.cbaddbranch.TabIndex = 78;
            this.cbaddbranch.Text = "เพิ่มสาขาใหม่";
            this.cbaddbranch.UseVisualStyleBackColor = true;
            this.cbaddbranch.CheckedChanged += new System.EventHandler(this.cbaddbranch_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgbranch);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 218);
            this.panel1.TabIndex = 73;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnoption);
            this.panel2.Controls.Add(this.lblcountbranch);
            this.panel2.Controls.Add(this.cbaddbranch);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 26);
            this.panel2.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(247, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 15);
            this.label5.TabIndex = 82;
            this.label5.Text = "* เลขที่ต้องระบุ ให้ระุบุชื่อสาขาเป็นอย่างน้อย";
            this.label5.Visible = false;
            // 
            // btnoption
            // 
            this.btnoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnoption.ForeColor = System.Drawing.Color.Purple;
            this.btnoption.Location = new System.Drawing.Point(181, 0);
            this.btnoption.Name = "btnoption";
            this.btnoption.Size = new System.Drawing.Size(61, 26);
            this.btnoption.TabIndex = 74;
            this.btnoption.Text = "option";
            this.btnoption.UseVisualStyleBackColor = true;
            this.btnoption.Click += new System.EventHandler(this.btnoption_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 79;
            this.label4.Text = "ข้อมูลสาขา";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtgcompany);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 70);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(725, 354);
            this.panel6.TabIndex = 80;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cbaddcom);
            this.panel5.Controls.Add(this.lblcountcom);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(725, 26);
            this.panel5.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(188, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 15);
            this.label2.TabIndex = 81;
            this.label2.Text = "*เลขที่ไม่ต้องระบุ ให้ระบุชื่อบริษัทเป็นอย่างน้อย";
            this.label2.Visible = false;
            // 
            // cbaddcom
            // 
            this.cbaddcom.AutoSize = true;
            this.cbaddcom.Location = new System.Drawing.Point(93, 6);
            this.cbaddcom.Name = "cbaddcom";
            this.cbaddcom.Size = new System.Drawing.Size(94, 17);
            this.cbaddcom.TabIndex = 79;
            this.cbaddcom.Text = "เพิ่มบริษัทใหม่";
            this.cbaddcom.UseVisualStyleBackColor = true;
            this.cbaddcom.CheckedChanged += new System.EventHandler(this.cbaddcom_CheckedChanged);
            // 
            // lblcountcom
            // 
            this.lblcountcom.AutoSize = true;
            this.lblcountcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountcom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblcountcom.Location = new System.Drawing.Point(623, 5);
            this.lblcountcom.Name = "lblcountcom";
            this.lblcountcom.Size = new System.Drawing.Size(37, 15);
            this.lblcountcom.TabIndex = 80;
            this.lblcountcom.Text = "Items";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "ข้อมูลบริษัท";
            // 
            // Frmcompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmcompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลบริษัท ผู้ผลิต ลูกค้าและขนส่ง";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmcompany_FormClosed);
            this.Load += new System.EventHandler(this.Frmcompany_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdbranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgcompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdcompany)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnaddedit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbselecttypecom;
        private dtssaleorder dtssaleorder;
        private System.Windows.Forms.BindingSource bdbranch;
        private System.Windows.Forms.DataGridView dtgbranch;
        private System.Windows.Forms.BindingSource bdcompany;
        private System.Windows.Forms.DataGridView dtgcompany;
        private System.Windows.Forms.Label lblinformation2;
        private System.Windows.Forms.Label lblcountbranch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblcountcom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbaddbranch;
        private System.Windows.Forms.CheckBox cbaddcom;
        private System.Windows.Forms.Label lblinformation1;
        private System.Windows.Forms.Button btnoption;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbranchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn baddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tumbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}