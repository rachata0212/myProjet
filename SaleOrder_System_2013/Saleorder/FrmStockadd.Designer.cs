namespace SaleOrder
{
    partial class FrmStockadd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.txtton = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtnamepro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnserchpro = new System.Windows.Forms.Button();
            this.dtgstock = new System.Windows.Forms.DataGridView();
            this.bdstock = new System.Windows.Forms.BindingSource(this.components);
            this.dtssaleorder = new SaleOrder.dtssaleorder();
            this.label6 = new System.Windows.Forms.Label();
            this.cbnew = new System.Windows.Forms.CheckBox();
            this.btnaddtype = new System.Windows.Forms.Button();
            this.txtkk = new System.Windows.Forms.TextBox();
            this.cbbranch = new System.Windows.Forms.ComboBox();
            this.tbnaddjust = new System.Windows.Forms.Button();
            this.idbistockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pronameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namesupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitstockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgstock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdstock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Controls.Add(this.btnclose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 474);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 27);
            this.panel3.TabIndex = 60;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(614, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(83, 27);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "บันทึกข้อมูล";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.Location = new System.Drawing.Point(697, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(83, 27);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(400, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 110;
            this.label4.Text = "หมายเหตุ";
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.Location = new System.Drawing.Point(460, 79);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(311, 24);
            this.txtremark.TabIndex = 109;
            // 
            // txtton
            // 
            this.txtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtton.Location = new System.Drawing.Point(422, 46);
            this.txtton.Name = "txtton";
            this.txtton.Size = new System.Drawing.Size(113, 24);
            this.txtton.TabIndex = 107;
            this.txtton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtweigth_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 106;
            this.label2.Text = "ปริมาณสินค้า (ตัน):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 102;
            this.label1.Text = "คลัง/สาขา:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 25);
            this.label19.TabIndex = 99;
            this.label19.Text = "ข้อมูลสินค้า";
            // 
            // txtnamepro
            // 
            this.txtnamepro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnamepro.Location = new System.Drawing.Point(79, 46);
            this.txtnamepro.Name = "txtnamepro";
            this.txtnamepro.ReadOnly = true;
            this.txtnamepro.Size = new System.Drawing.Size(165, 24);
            this.txtnamepro.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 96;
            this.label5.Text = "สินค้าย่อย:";
            // 
            // btnserchpro
            // 
            this.btnserchpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnserchpro.Location = new System.Drawing.Point(250, 45);
            this.btnserchpro.Name = "btnserchpro";
            this.btnserchpro.Size = new System.Drawing.Size(51, 27);
            this.btnserchpro.TabIndex = 98;
            this.btnserchpro.Text = "...";
            this.btnserchpro.UseVisualStyleBackColor = true;
            this.btnserchpro.Click += new System.EventHandler(this.btnserchpro_Click);
            // 
            // dtgstock
            // 
            this.dtgstock.AllowUserToAddRows = false;
            this.dtgstock.AllowUserToDeleteRows = false;
            this.dtgstock.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgstock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgstock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idbistockDataGridViewTextBoxColumn,
            this.pronameDataGridViewTextBoxColumn,
            this.namesupDataGridViewTextBoxColumn,
            this.unitstockDataGridViewTextBoxColumn,
            this.charnameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.dtgstock.DataSource = this.bdstock;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgstock.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgstock.Location = new System.Drawing.Point(12, 129);
            this.dtgstock.Name = "dtgstock";
            this.dtgstock.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgstock.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgstock.RowHeadersWidth = 10;
            this.dtgstock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgstock.Size = new System.Drawing.Size(759, 333);
            this.dtgstock.TabIndex = 111;
            this.dtgstock.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgstock_CellMouseClick);
            // 
            // bdstock
            // 
            this.bdstock.DataMember = "dtproductsotck";
            this.bdstock.DataSource = this.dtssaleorder;
            // 
            // dtssaleorder
            // 
            this.dtssaleorder.DataSetName = "dtssaleorder";
            this.dtssaleorder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 112;
            this.label6.Text = "ปริมาณสินค้าคงเหลือ";
            // 
            // cbnew
            // 
            this.cbnew.AutoSize = true;
            this.cbnew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbnew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbnew.Location = new System.Drawing.Point(575, 17);
            this.cbnew.Name = "cbnew";
            this.cbnew.Size = new System.Drawing.Size(117, 17);
            this.cbnew.TabIndex = 113;
            this.cbnew.Text = "NewSubProduct";
            this.cbnew.UseVisualStyleBackColor = true;
            this.cbnew.CheckedChanged += new System.EventHandler(this.cbnew_CheckedChanged);
            // 
            // btnaddtype
            // 
            this.btnaddtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddtype.Location = new System.Drawing.Point(697, 12);
            this.btnaddtype.Name = "btnaddtype";
            this.btnaddtype.Size = new System.Drawing.Size(74, 27);
            this.btnaddtype.TabIndex = 114;
            this.btnaddtype.Text = "NewStock";
            this.btnaddtype.UseVisualStyleBackColor = true;
            this.btnaddtype.Click += new System.EventHandler(this.btnaddtype_Click);
            // 
            // txtkk
            // 
            this.txtkk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkk.Location = new System.Drawing.Point(539, 46);
            this.txtkk.Name = "txtkk";
            this.txtkk.ReadOnly = true;
            this.txtkk.Size = new System.Drawing.Size(156, 24);
            this.txtkk.TabIndex = 115;
            // 
            // cbbranch
            // 
            this.cbbranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbbranch.FormattingEnabled = true;
            this.cbbranch.Location = new System.Drawing.Point(79, 78);
            this.cbbranch.Name = "cbbranch";
            this.cbbranch.Size = new System.Drawing.Size(315, 26);
            this.cbbranch.TabIndex = 116;
            this.cbbranch.SelectedIndexChanged += new System.EventHandler(this.cbbranch_SelectedIndexChanged);
            // 
            // tbnaddjust
            // 
            this.tbnaddjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnaddjust.Location = new System.Drawing.Point(697, 45);
            this.tbnaddjust.Name = "tbnaddjust";
            this.tbnaddjust.Size = new System.Drawing.Size(74, 27);
            this.tbnaddjust.TabIndex = 117;
            this.tbnaddjust.Text = "Addjust";
            this.tbnaddjust.UseVisualStyleBackColor = true;
            this.tbnaddjust.Click += new System.EventHandler(this.tbnaddjust_Click);
            // 
            // idbistockDataGridViewTextBoxColumn
            // 
            this.idbistockDataGridViewTextBoxColumn.DataPropertyName = "idbistock";
            this.idbistockDataGridViewTextBoxColumn.HeaderText = "ID-Sup";
            this.idbistockDataGridViewTextBoxColumn.Name = "idbistockDataGridViewTextBoxColumn";
            this.idbistockDataGridViewTextBoxColumn.ReadOnly = true;
            this.idbistockDataGridViewTextBoxColumn.Width = 75;
            // 
            // pronameDataGridViewTextBoxColumn
            // 
            this.pronameDataGridViewTextBoxColumn.DataPropertyName = "proname";
            this.pronameDataGridViewTextBoxColumn.HeaderText = "หมวดหลัก";
            this.pronameDataGridViewTextBoxColumn.Name = "pronameDataGridViewTextBoxColumn";
            this.pronameDataGridViewTextBoxColumn.ReadOnly = true;
            this.pronameDataGridViewTextBoxColumn.Width = 120;
            // 
            // namesupDataGridViewTextBoxColumn
            // 
            this.namesupDataGridViewTextBoxColumn.DataPropertyName = "namesup";
            this.namesupDataGridViewTextBoxColumn.HeaderText = "หมวดย่อย";
            this.namesupDataGridViewTextBoxColumn.Name = "namesupDataGridViewTextBoxColumn";
            this.namesupDataGridViewTextBoxColumn.ReadOnly = true;
            this.namesupDataGridViewTextBoxColumn.Width = 150;
            // 
            // unitstockDataGridViewTextBoxColumn
            // 
            this.unitstockDataGridViewTextBoxColumn.DataPropertyName = "unitstock";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.unitstockDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.unitstockDataGridViewTextBoxColumn.HeaderText = "จำนวนสินค้าคงเหลือ";
            this.unitstockDataGridViewTextBoxColumn.Name = "unitstockDataGridViewTextBoxColumn";
            this.unitstockDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitstockDataGridViewTextBoxColumn.Width = 140;
            // 
            // charnameDataGridViewTextBoxColumn
            // 
            this.charnameDataGridViewTextBoxColumn.DataPropertyName = "charname";
            this.charnameDataGridViewTextBoxColumn.HeaderText = "อักษรย่อ";
            this.charnameDataGridViewTextBoxColumn.Name = "charnameDataGridViewTextBoxColumn";
            this.charnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.charnameDataGridViewTextBoxColumn.Width = 75;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "หมายเหตุ";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarkDataGridViewTextBoxColumn.Width = 185;
            // 
            // FrmStockadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 501);
            this.Controls.Add(this.tbnaddjust);
            this.Controls.Add(this.cbbranch);
            this.Controls.Add(this.txtkk);
            this.Controls.Add(this.btnaddtype);
            this.Controls.Add(this.cbnew);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtgstock);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtnamepro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnserchpro);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStockadd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "คลังสินค้าเข้าสต๊อก";
            this.Load += new System.EventHandler(this.FrmStockadd_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgstock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdstock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.TextBox txtton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtnamepro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnserchpro;
        private System.Windows.Forms.DataGridView dtgstock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbnew;
        private System.Windows.Forms.Button btnaddtype;
        private System.Windows.Forms.BindingSource bdstock;
        private dtssaleorder dtssaleorder;
        private System.Windows.Forms.TextBox txtkk;
        private System.Windows.Forms.ComboBox cbbranch;
        private System.Windows.Forms.Button tbnaddjust;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbistockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pronameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namesupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitstockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
    }
}