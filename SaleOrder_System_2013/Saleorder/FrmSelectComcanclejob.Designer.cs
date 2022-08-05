namespace SaleOrder
{
    partial class FrmSelectComcanclejob
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.bdtranreplyTc = new System.Windows.Forms.BindingSource(this.components);
            this.dtssaleorder = new SaleOrder.dtssaleorder();
            this.bdpurordertran = new System.Windows.Forms.BindingSource(this.components);
            this.bdordertran = new System.Windows.Forms.BindingSource(this.components);
            this.dtgsaletranstatus = new System.Windows.Forms.DataGridView();
            this.idorderDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carnameDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pronameDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgpurtranstatus = new System.Windows.Forms.DataGridView();
            this.idpurDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datepurDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comsupDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comtranDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carnameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telcontactDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serailcarDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pronameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdtranreplyTc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpurordertran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdordertran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsaletranstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgpurtranstatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtcount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 29);
            this.panel1.TabIndex = 66;
            // 
            // txtcount
            // 
            this.txtcount.BackColor = System.Drawing.SystemColors.Control;
            this.txtcount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtcount.Location = new System.Drawing.Point(44, 7);
            this.txtcount.Multiline = true;
            this.txtcount.Name = "txtcount";
            this.txtcount.Size = new System.Drawing.Size(51, 15);
            this.txtcount.TabIndex = 69;
            this.txtcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(676, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(3, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 16);
            this.label19.TabIndex = 68;
            this.label19.Text = "จำนวน";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(94, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 16);
            this.label20.TabIndex = 67;
            this.label20.Text = "ข้อมูล";
            // 
            // bdtranreplyTc
            // 
            this.bdtranreplyTc.DataMember = "dttranreplyTc";
            this.bdtranreplyTc.DataSource = this.dtssaleorder;
            // 
            // dtssaleorder
            // 
            this.dtssaleorder.DataSetName = "dtssaleorder";
            this.dtssaleorder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdpurordertran
            // 
            this.bdpurordertran.DataMember = "dtpurordertran";
            this.bdpurordertran.DataSource = this.dtssaleorder;
            // 
            // bdordertran
            // 
            this.bdordertran.DataMember = "dtsaleordertran";
            this.bdordertran.DataSource = this.dtssaleorder;
            // 
            // dtgsaletranstatus
            // 
            this.dtgsaletranstatus.AllowUserToAddRows = false;
            this.dtgsaletranstatus.AllowUserToDeleteRows = false;
            this.dtgsaletranstatus.AutoGenerateColumns = false;
            this.dtgsaletranstatus.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgsaletranstatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgsaletranstatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgsaletranstatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idorderDataGridViewTextBoxColumn1,
            this.orderdateDataGridViewTextBoxColumn1,
            this.comcusDataGridViewTextBoxColumn1,
            this.carnameDataGridViewTextBoxColumn4,
            this.pronameDataGridViewTextBoxColumn4,
            this.remarkDataGridViewTextBoxColumn2});
            this.dtgsaletranstatus.DataSource = this.bdordertran;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgsaletranstatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgsaletranstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgsaletranstatus.Location = new System.Drawing.Point(0, 0);
            this.dtgsaletranstatus.Name = "dtgsaletranstatus";
            this.dtgsaletranstatus.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgsaletranstatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgsaletranstatus.RowHeadersWidth = 10;
            this.dtgsaletranstatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgsaletranstatus.Size = new System.Drawing.Size(743, 404);
            this.dtgsaletranstatus.TabIndex = 67;
            this.dtgsaletranstatus.Visible = false;
            this.dtgsaletranstatus.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgsaletranstatus_CellMouseDoubleClick);
            this.dtgsaletranstatus.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgsaletranstatus_CellMouseClick);
            // 
            // idorderDataGridViewTextBoxColumn1
            // 
            this.idorderDataGridViewTextBoxColumn1.DataPropertyName = "idorder";
            this.idorderDataGridViewTextBoxColumn1.HeaderText = "เลขที่ขาย";
            this.idorderDataGridViewTextBoxColumn1.Name = "idorderDataGridViewTextBoxColumn1";
            this.idorderDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idorderDataGridViewTextBoxColumn1.Width = 80;
            // 
            // orderdateDataGridViewTextBoxColumn1
            // 
            this.orderdateDataGridViewTextBoxColumn1.DataPropertyName = "orderdate";
            this.orderdateDataGridViewTextBoxColumn1.HeaderText = "วันที่";
            this.orderdateDataGridViewTextBoxColumn1.Name = "orderdateDataGridViewTextBoxColumn1";
            this.orderdateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.orderdateDataGridViewTextBoxColumn1.Width = 80;
            // 
            // comcusDataGridViewTextBoxColumn1
            // 
            this.comcusDataGridViewTextBoxColumn1.DataPropertyName = "comcus";
            this.comcusDataGridViewTextBoxColumn1.HeaderText = "บริษัทลูกค้า";
            this.comcusDataGridViewTextBoxColumn1.Name = "comcusDataGridViewTextBoxColumn1";
            this.comcusDataGridViewTextBoxColumn1.ReadOnly = true;
            this.comcusDataGridViewTextBoxColumn1.Width = 200;
            // 
            // carnameDataGridViewTextBoxColumn4
            // 
            this.carnameDataGridViewTextBoxColumn4.DataPropertyName = "carname";
            this.carnameDataGridViewTextBoxColumn4.HeaderText = "ประเภทรถ";
            this.carnameDataGridViewTextBoxColumn4.Name = "carnameDataGridViewTextBoxColumn4";
            this.carnameDataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // pronameDataGridViewTextBoxColumn4
            // 
            this.pronameDataGridViewTextBoxColumn4.DataPropertyName = "proname";
            this.pronameDataGridViewTextBoxColumn4.HeaderText = "ประเภทสินค้า";
            this.pronameDataGridViewTextBoxColumn4.Name = "pronameDataGridViewTextBoxColumn4";
            this.pronameDataGridViewTextBoxColumn4.ReadOnly = true;
            this.pronameDataGridViewTextBoxColumn4.Width = 120;
            // 
            // remarkDataGridViewTextBoxColumn2
            // 
            this.remarkDataGridViewTextBoxColumn2.DataPropertyName = "remark";
            this.remarkDataGridViewTextBoxColumn2.HeaderText = "หมายเหตุ";
            this.remarkDataGridViewTextBoxColumn2.Name = "remarkDataGridViewTextBoxColumn2";
            this.remarkDataGridViewTextBoxColumn2.ReadOnly = true;
            this.remarkDataGridViewTextBoxColumn2.Width = 150;
            // 
            // dtgpurtranstatus
            // 
            this.dtgpurtranstatus.AllowUserToAddRows = false;
            this.dtgpurtranstatus.AllowUserToDeleteRows = false;
            this.dtgpurtranstatus.AutoGenerateColumns = false;
            this.dtgpurtranstatus.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpurtranstatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgpurtranstatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgpurtranstatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpurDataGridViewTextBoxColumn1,
            this.datepurDataGridViewTextBoxColumn1,
            this.comsupDataGridViewTextBoxColumn1,
            this.comtranDataGridViewTextBoxColumn2,
            this.carnameDataGridViewTextBoxColumn3,
            this.telcontactDataGridViewTextBoxColumn1,
            this.serailcarDataGridViewTextBoxColumn1,
            this.pronameDataGridViewTextBoxColumn3});
            this.dtgpurtranstatus.DataSource = this.bdpurordertran;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgpurtranstatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgpurtranstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgpurtranstatus.Location = new System.Drawing.Point(0, 0);
            this.dtgpurtranstatus.Name = "dtgpurtranstatus";
            this.dtgpurtranstatus.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpurtranstatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgpurtranstatus.RowHeadersWidth = 10;
            this.dtgpurtranstatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgpurtranstatus.Size = new System.Drawing.Size(743, 404);
            this.dtgpurtranstatus.TabIndex = 68;
            this.dtgpurtranstatus.Visible = false;
            this.dtgpurtranstatus.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgpurtranstatus_CellMouseDoubleClick);
            this.dtgpurtranstatus.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgpurtranstatus_CellMouseClick);
            // 
            // idpurDataGridViewTextBoxColumn1
            // 
            this.idpurDataGridViewTextBoxColumn1.DataPropertyName = "idpur";
            this.idpurDataGridViewTextBoxColumn1.HeaderText = "เลขที่ซื้อ";
            this.idpurDataGridViewTextBoxColumn1.Name = "idpurDataGridViewTextBoxColumn1";
            this.idpurDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idpurDataGridViewTextBoxColumn1.Width = 75;
            // 
            // datepurDataGridViewTextBoxColumn1
            // 
            this.datepurDataGridViewTextBoxColumn1.DataPropertyName = "datepur";
            this.datepurDataGridViewTextBoxColumn1.HeaderText = "ประจำวัน";
            this.datepurDataGridViewTextBoxColumn1.Name = "datepurDataGridViewTextBoxColumn1";
            this.datepurDataGridViewTextBoxColumn1.ReadOnly = true;
            this.datepurDataGridViewTextBoxColumn1.Width = 80;
            // 
            // comsupDataGridViewTextBoxColumn1
            // 
            this.comsupDataGridViewTextBoxColumn1.DataPropertyName = "comsup";
            this.comsupDataGridViewTextBoxColumn1.HeaderText = "บริษัทขาย";
            this.comsupDataGridViewTextBoxColumn1.Name = "comsupDataGridViewTextBoxColumn1";
            this.comsupDataGridViewTextBoxColumn1.ReadOnly = true;
            this.comsupDataGridViewTextBoxColumn1.Width = 200;
            // 
            // comtranDataGridViewTextBoxColumn2
            // 
            this.comtranDataGridViewTextBoxColumn2.DataPropertyName = "comtran";
            this.comtranDataGridViewTextBoxColumn2.HeaderText = "บริษัทขนส่ง";
            this.comtranDataGridViewTextBoxColumn2.Name = "comtranDataGridViewTextBoxColumn2";
            this.comtranDataGridViewTextBoxColumn2.ReadOnly = true;
            this.comtranDataGridViewTextBoxColumn2.Width = 200;
            // 
            // carnameDataGridViewTextBoxColumn3
            // 
            this.carnameDataGridViewTextBoxColumn3.DataPropertyName = "carname";
            this.carnameDataGridViewTextBoxColumn3.HeaderText = "ประเภท/ชนิดรถ";
            this.carnameDataGridViewTextBoxColumn3.Name = "carnameDataGridViewTextBoxColumn3";
            this.carnameDataGridViewTextBoxColumn3.ReadOnly = true;
            this.carnameDataGridViewTextBoxColumn3.Width = 150;
            // 
            // telcontactDataGridViewTextBoxColumn1
            // 
            this.telcontactDataGridViewTextBoxColumn1.DataPropertyName = "telcontact";
            this.telcontactDataGridViewTextBoxColumn1.HeaderText = "เบอร์ติดต่อ";
            this.telcontactDataGridViewTextBoxColumn1.Name = "telcontactDataGridViewTextBoxColumn1";
            this.telcontactDataGridViewTextBoxColumn1.ReadOnly = true;
            this.telcontactDataGridViewTextBoxColumn1.Width = 90;
            // 
            // serailcarDataGridViewTextBoxColumn1
            // 
            this.serailcarDataGridViewTextBoxColumn1.DataPropertyName = "serailcar";
            this.serailcarDataGridViewTextBoxColumn1.HeaderText = "ทะเบียนรถ";
            this.serailcarDataGridViewTextBoxColumn1.Name = "serailcarDataGridViewTextBoxColumn1";
            this.serailcarDataGridViewTextBoxColumn1.ReadOnly = true;
            this.serailcarDataGridViewTextBoxColumn1.Width = 90;
            // 
            // pronameDataGridViewTextBoxColumn3
            // 
            this.pronameDataGridViewTextBoxColumn3.DataPropertyName = "proname";
            this.pronameDataGridViewTextBoxColumn3.HeaderText = "สินค้า";
            this.pronameDataGridViewTextBoxColumn3.Name = "pronameDataGridViewTextBoxColumn3";
            this.pronameDataGridViewTextBoxColumn3.ReadOnly = true;
            this.pronameDataGridViewTextBoxColumn3.Width = 120;
            // 
            // FrmSelectComcanclejob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 433);
            this.Controls.Add(this.dtgpurtranstatus);
            this.Controls.Add(this.dtgsaletranstatus);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectComcanclejob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Company";
            this.Load += new System.EventHandler(this.FrmSelectComcanclejob_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdtranreplyTc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpurordertran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdordertran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsaletranstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgpurtranstatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtcount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.BindingSource bdtranreplyTc;
        private System.Windows.Forms.BindingSource bdpurordertran;
        private dtssaleorder dtssaleorder;
        private System.Windows.Forms.BindingSource bdordertran;
        private System.Windows.Forms.DataGridView dtgsaletranstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorderDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comcusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn carnameDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn pronameDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dtgpurtranstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpurDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn datepurDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comsupDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comtranDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn carnameDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn telcontactDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serailcarDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pronameDataGridViewTextBoxColumn3;
    }
}