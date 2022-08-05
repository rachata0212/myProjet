namespace SaleOrder
{
    partial class FrmPurpaysetting
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
            this.btnclose = new System.Windows.Forms.Button();
            this.dtgpriceplam = new System.Windows.Forms.DataGridView();
            this.rfspo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbocompany = new System.Windows.Forms.ComboBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.cbmenu = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgpricetran = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.idpaytranDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromcomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromproviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tocomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toproviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricetranDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weigthacceptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdpricetran = new System.Windows.Forms.BindingSource(this.components);
            this.dTrat = new SaleOrder.DTrat();
            this.idpricepurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBsupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nBsupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proviceBsupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCpurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCpurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proviceCpurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricepurDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quatadicountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uptodateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areanameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdpriceplam = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgpriceplam)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgpricetran)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdpricetran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpriceplam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnclose.Location = new System.Drawing.Point(725, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(68, 27);
            this.btnclose.TabIndex = 20;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // dtgpriceplam
            // 
            this.dtgpriceplam.AllowUserToAddRows = false;
            this.dtgpriceplam.AllowUserToDeleteRows = false;
            this.dtgpriceplam.AllowUserToOrderColumns = true;
            this.dtgpriceplam.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpriceplam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgpriceplam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgpriceplam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpricepurDataGridViewTextBoxColumn,
            this.idBsupDataGridViewTextBoxColumn,
            this.nBsupDataGridViewTextBoxColumn,
            this.proviceBsupDataGridViewTextBoxColumn,
            this.idCpurDataGridViewTextBoxColumn,
            this.nCpurDataGridViewTextBoxColumn,
            this.proviceCpurDataGridViewTextBoxColumn,
            this.pricepurDataGridViewTextBoxColumn,
            this.quatadicountDataGridViewTextBoxColumn,
            this.uptodateDataGridViewTextBoxColumn,
            this.rfspo,
            this.areanameDataGridViewTextBoxColumn});
            this.dtgpriceplam.DataSource = this.bdpriceplam;
            this.dtgpriceplam.Location = new System.Drawing.Point(12, 142);
            this.dtgpriceplam.Name = "dtgpriceplam";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpriceplam.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgpriceplam.RowHeadersWidth = 11;
            this.dtgpriceplam.Size = new System.Drawing.Size(113, 68);
            this.dtgpriceplam.TabIndex = 21;
            this.dtgpriceplam.Visible = false;
            this.dtgpriceplam.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgpriceplam_CellMouseClick);
            this.dtgpriceplam.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgpriceplam_CellMouseDoubleClick);
            // 
            // rfspo
            // 
            this.rfspo.DataPropertyName = "rfspo";
            this.rfspo.HeaderText = "อิงใบซื้อเลขที่";
            this.rfspo.Name = "rfspo";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbocompany);
            this.groupBox4.Controls.Add(this.btndelete);
            this.groupBox4.Controls.Add(this.btnsave);
            this.groupBox4.Controls.Add(this.cbmenu);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(793, 45);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "เลือกประเภทการตั้งค่า";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(251, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "เลือกบริษัท:";
            // 
            // cbocompany
            // 
            this.cbocompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbocompany.FormattingEnabled = true;
            this.cbocompany.Items.AddRange(new object[] {
            "ราคาซื้อปาล์ม",
            "ราคาขนส่ง"});
            this.cbocompany.Location = new System.Drawing.Point(313, 14);
            this.cbocompany.Name = "cbocompany";
            this.cbocompany.Size = new System.Drawing.Size(307, 24);
            this.cbocompany.TabIndex = 33;
            this.cbocompany.SelectedIndexChanged += new System.EventHandler(this.cbocompany_SelectedIndexChanged);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btndelete.ForeColor = System.Drawing.Color.DarkGray;
            this.btndelete.Location = new System.Drawing.Point(731, 13);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(59, 26);
            this.btndelete.TabIndex = 32;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnsave.Location = new System.Drawing.Point(667, 13);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(59, 26);
            this.btnsave.TabIndex = 31;
            this.btnsave.Text = "* New";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // cbmenu
            // 
            this.cbmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbmenu.FormattingEnabled = true;
            this.cbmenu.Items.AddRange(new object[] {
            "ราคาซื้อปาล์ม",
            "ราคาขนส่ง"});
            this.cbmenu.Location = new System.Drawing.Point(73, 14);
            this.cbmenu.Name = "cbmenu";
            this.cbmenu.Size = new System.Drawing.Size(172, 24);
            this.cbmenu.TabIndex = 23;
            this.cbmenu.SelectedIndexChanged += new System.EventHandler(this.cbmenu_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(7, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "เลือกประเภท:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgpricetran);
            this.panel1.Controls.Add(this.dtgpriceplam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 390);
            this.panel1.TabIndex = 31;
            // 
            // dtgpricetran
            // 
            this.dtgpricetran.AllowUserToAddRows = false;
            this.dtgpricetran.AllowUserToDeleteRows = false;
            this.dtgpricetran.AllowUserToOrderColumns = true;
            this.dtgpricetran.AutoGenerateColumns = false;
            this.dtgpricetran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgpricetran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpaytranDataGridViewTextBoxColumn,
            this.fromcomDataGridViewTextBoxColumn,
            this.fromproviceDataGridViewTextBoxColumn,
            this.tocomDataGridViewTextBoxColumn,
            this.toproviceDataGridViewTextBoxColumn,
            this.pricetranDataGridViewTextBoxColumn,
            this.weigthacceptDataGridViewTextBoxColumn});
            this.dtgpricetran.DataSource = this.bdpricetran;
            this.dtgpricetran.Location = new System.Drawing.Point(154, 6);
            this.dtgpricetran.Name = "dtgpricetran";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpricetran.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgpricetran.RowHeadersWidth = 11;
            this.dtgpricetran.Size = new System.Drawing.Size(128, 68);
            this.dtgpricetran.TabIndex = 23;
            this.dtgpricetran.Visible = false;
            this.dtgpricetran.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgpricetran_CellMouseClick);
            this.dtgpricetran.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgpricetran_CellMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 27);
            this.panel2.TabIndex = 32;
            // 
            // idpaytranDataGridViewTextBoxColumn
            // 
            this.idpaytranDataGridViewTextBoxColumn.DataPropertyName = "idpaytran";
            this.idpaytranDataGridViewTextBoxColumn.HeaderText = "รหัสขนส่ง";
            this.idpaytranDataGridViewTextBoxColumn.Name = "idpaytranDataGridViewTextBoxColumn";
            this.idpaytranDataGridViewTextBoxColumn.Width = 80;
            // 
            // fromcomDataGridViewTextBoxColumn
            // 
            this.fromcomDataGridViewTextBoxColumn.DataPropertyName = "fromcom";
            this.fromcomDataGridViewTextBoxColumn.HeaderText = "จากต้นทาง";
            this.fromcomDataGridViewTextBoxColumn.Name = "fromcomDataGridViewTextBoxColumn";
            this.fromcomDataGridViewTextBoxColumn.Width = 150;
            // 
            // fromproviceDataGridViewTextBoxColumn
            // 
            this.fromproviceDataGridViewTextBoxColumn.DataPropertyName = "fromprovice";
            this.fromproviceDataGridViewTextBoxColumn.HeaderText = "จังหวัด";
            this.fromproviceDataGridViewTextBoxColumn.Name = "fromproviceDataGridViewTextBoxColumn";
            // 
            // tocomDataGridViewTextBoxColumn
            // 
            this.tocomDataGridViewTextBoxColumn.DataPropertyName = "tocom";
            this.tocomDataGridViewTextBoxColumn.HeaderText = "ถึงปลายทาง";
            this.tocomDataGridViewTextBoxColumn.Name = "tocomDataGridViewTextBoxColumn";
            this.tocomDataGridViewTextBoxColumn.Width = 150;
            // 
            // toproviceDataGridViewTextBoxColumn
            // 
            this.toproviceDataGridViewTextBoxColumn.DataPropertyName = "toprovice";
            this.toproviceDataGridViewTextBoxColumn.HeaderText = "จังหวัด";
            this.toproviceDataGridViewTextBoxColumn.Name = "toproviceDataGridViewTextBoxColumn";
            // 
            // pricetranDataGridViewTextBoxColumn
            // 
            this.pricetranDataGridViewTextBoxColumn.DataPropertyName = "pricetran";
            this.pricetranDataGridViewTextBoxColumn.HeaderText = "ราคาจ้าง/ตัน";
            this.pricetranDataGridViewTextBoxColumn.Name = "pricetranDataGridViewTextBoxColumn";
            this.pricetranDataGridViewTextBoxColumn.Width = 90;
            // 
            // weigthacceptDataGridViewTextBoxColumn
            // 
            this.weigthacceptDataGridViewTextBoxColumn.DataPropertyName = "weigthaccept";
            this.weigthacceptDataGridViewTextBoxColumn.HeaderText = "นน.ส่วนต่าง/กก.";
            this.weigthacceptDataGridViewTextBoxColumn.Name = "weigthacceptDataGridViewTextBoxColumn";
            this.weigthacceptDataGridViewTextBoxColumn.Width = 110;
            // 
            // bdpricetran
            // 
            this.bdpricetran.DataMember = "dtpricetran";
            this.bdpricetran.DataSource = this.dTrat;
            // 
            // dTrat
            // 
            this.dTrat.DataSetName = "DTrat";
            this.dTrat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // idpricepurDataGridViewTextBoxColumn
            // 
            this.idpricepurDataGridViewTextBoxColumn.DataPropertyName = "idpricepur";
            this.idpricepurDataGridViewTextBoxColumn.HeaderText = "เลขที่ซื้อ";
            this.idpricepurDataGridViewTextBoxColumn.Name = "idpricepurDataGridViewTextBoxColumn";
            this.idpricepurDataGridViewTextBoxColumn.Width = 75;
            // 
            // idBsupDataGridViewTextBoxColumn
            // 
            this.idBsupDataGridViewTextBoxColumn.DataPropertyName = "idBsup";
            this.idBsupDataGridViewTextBoxColumn.HeaderText = "รหัสผู้ขาย";
            this.idBsupDataGridViewTextBoxColumn.Name = "idBsupDataGridViewTextBoxColumn";
            this.idBsupDataGridViewTextBoxColumn.Width = 80;
            // 
            // nBsupDataGridViewTextBoxColumn
            // 
            this.nBsupDataGridViewTextBoxColumn.DataPropertyName = "NBsup";
            this.nBsupDataGridViewTextBoxColumn.HeaderText = "ชื้อผู้ขาย";
            this.nBsupDataGridViewTextBoxColumn.Name = "nBsupDataGridViewTextBoxColumn";
            this.nBsupDataGridViewTextBoxColumn.Width = 200;
            // 
            // proviceBsupDataGridViewTextBoxColumn
            // 
            this.proviceBsupDataGridViewTextBoxColumn.DataPropertyName = "ProviceBsup";
            this.proviceBsupDataGridViewTextBoxColumn.HeaderText = "จังหวัด";
            this.proviceBsupDataGridViewTextBoxColumn.Name = "proviceBsupDataGridViewTextBoxColumn";
            // 
            // idCpurDataGridViewTextBoxColumn
            // 
            this.idCpurDataGridViewTextBoxColumn.DataPropertyName = "idCpur";
            this.idCpurDataGridViewTextBoxColumn.HeaderText = "รหัสผู้ซื้อ";
            this.idCpurDataGridViewTextBoxColumn.Name = "idCpurDataGridViewTextBoxColumn";
            this.idCpurDataGridViewTextBoxColumn.Width = 80;
            // 
            // nCpurDataGridViewTextBoxColumn
            // 
            this.nCpurDataGridViewTextBoxColumn.DataPropertyName = "NCpur";
            this.nCpurDataGridViewTextBoxColumn.HeaderText = "ชื้อผู้ซื้อ";
            this.nCpurDataGridViewTextBoxColumn.Name = "nCpurDataGridViewTextBoxColumn";
            this.nCpurDataGridViewTextBoxColumn.Width = 200;
            // 
            // proviceCpurDataGridViewTextBoxColumn
            // 
            this.proviceCpurDataGridViewTextBoxColumn.DataPropertyName = "ProviceCpur";
            this.proviceCpurDataGridViewTextBoxColumn.HeaderText = "จังหวัด";
            this.proviceCpurDataGridViewTextBoxColumn.Name = "proviceCpurDataGridViewTextBoxColumn";
            // 
            // pricepurDataGridViewTextBoxColumn
            // 
            this.pricepurDataGridViewTextBoxColumn.DataPropertyName = "pricepur";
            this.pricepurDataGridViewTextBoxColumn.HeaderText = "ราคาซื้อ";
            this.pricepurDataGridViewTextBoxColumn.Name = "pricepurDataGridViewTextBoxColumn";
            // 
            // quatadicountDataGridViewTextBoxColumn
            // 
            this.quatadicountDataGridViewTextBoxColumn.DataPropertyName = "quatadicount";
            this.quatadicountDataGridViewTextBoxColumn.HeaderText = "มัดจำคงเหลือ";
            this.quatadicountDataGridViewTextBoxColumn.Name = "quatadicountDataGridViewTextBoxColumn";
            // 
            // uptodateDataGridViewTextBoxColumn
            // 
            this.uptodateDataGridViewTextBoxColumn.DataPropertyName = "uptodate";
            this.uptodateDataGridViewTextBoxColumn.HeaderText = "วันที่ปรับราคา";
            this.uptodateDataGridViewTextBoxColumn.Name = "uptodateDataGridViewTextBoxColumn";
            // 
            // areanameDataGridViewTextBoxColumn
            // 
            this.areanameDataGridViewTextBoxColumn.DataPropertyName = "areaname";
            this.areanameDataGridViewTextBoxColumn.HeaderText = "โซนพื้นที่";
            this.areanameDataGridViewTextBoxColumn.Name = "areanameDataGridViewTextBoxColumn";
            this.areanameDataGridViewTextBoxColumn.Width = 75;
            // 
            // bdpriceplam
            // 
            this.bdpriceplam.DataMember = "dtpriceplam";
            this.bdpriceplam.DataSource = this.dTrat;
            // 
            // FrmPurpaysetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPurpaysetting";
            this.Text = "Rate Purchase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPurpaysetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgpriceplam)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgpricetran)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdpricetran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpriceplam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DataGridView dtgpriceplam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbmenu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgpricetran;
        private System.Windows.Forms.BindingSource bdpriceplam;
        private DTrat dTrat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.BindingSource bdpricetran;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpaytranDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromcomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromproviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tocomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toproviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricetranDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weigthacceptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpricepurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBsupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nBsupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proviceBsupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCpurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCpurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proviceCpurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricepurDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quatadicountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uptodateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfspo;
        private System.Windows.Forms.DataGridViewTextBoxColumn areanameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbocompany;
    }
}