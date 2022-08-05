namespace SaleOrder
{
    partial class FrmAutokey
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
            this.dtgautokey = new System.Windows.Forms.DataGridView();
            this.idautoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkatbranchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdautokey = new System.Windows.Forms.BindingSource(this.components);
            this.dtssaleorder = new SaleOrder.dtssaleorder();
            this.btnserchbranch = new System.Windows.Forms.Button();
            this.txtnamebranch = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtkey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgautokey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdautokey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgautokey
            // 
            this.dtgautokey.AllowUserToAddRows = false;
            this.dtgautokey.AllowUserToDeleteRows = false;
            this.dtgautokey.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgautokey.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgautokey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgautokey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idautoDataGridViewTextBoxColumn,
            this.charnameDataGridViewTextBoxColumn,
            this.bnameDataGridViewTextBoxColumn2,
            this.remarkatbranchDataGridViewTextBoxColumn});
            this.dtgautokey.DataSource = this.bdautokey;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgautokey.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgautokey.Location = new System.Drawing.Point(12, 76);
            this.dtgautokey.Name = "dtgautokey";
            this.dtgautokey.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgautokey.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgautokey.RowHeadersWidth = 10;
            this.dtgautokey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgautokey.Size = new System.Drawing.Size(445, 195);
            this.dtgautokey.TabIndex = 41;
            // 
            // idautoDataGridViewTextBoxColumn
            // 
            this.idautoDataGridViewTextBoxColumn.DataPropertyName = "idauto";
            this.idautoDataGridViewTextBoxColumn.HeaderText = "ID-Auto";
            this.idautoDataGridViewTextBoxColumn.Name = "idautoDataGridViewTextBoxColumn";
            this.idautoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idautoDataGridViewTextBoxColumn.Width = 70;
            // 
            // charnameDataGridViewTextBoxColumn
            // 
            this.charnameDataGridViewTextBoxColumn.DataPropertyName = "charname";
            this.charnameDataGridViewTextBoxColumn.HeaderText = "อักษร";
            this.charnameDataGridViewTextBoxColumn.Name = "charnameDataGridViewTextBoxColumn";
            this.charnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.charnameDataGridViewTextBoxColumn.Width = 60;
            // 
            // bnameDataGridViewTextBoxColumn2
            // 
            this.bnameDataGridViewTextBoxColumn2.DataPropertyName = "bname";
            this.bnameDataGridViewTextBoxColumn2.HeaderText = "คำอธิบาย";
            this.bnameDataGridViewTextBoxColumn2.Name = "bnameDataGridViewTextBoxColumn2";
            this.bnameDataGridViewTextBoxColumn2.ReadOnly = true;
            this.bnameDataGridViewTextBoxColumn2.Width = 150;
            // 
            // remarkatbranchDataGridViewTextBoxColumn
            // 
            this.remarkatbranchDataGridViewTextBoxColumn.DataPropertyName = "remarkatbranch";
            this.remarkatbranchDataGridViewTextBoxColumn.HeaderText = "หมายเหตุ";
            this.remarkatbranchDataGridViewTextBoxColumn.Name = "remarkatbranchDataGridViewTextBoxColumn";
            this.remarkatbranchDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarkatbranchDataGridViewTextBoxColumn.Width = 150;
            // 
            // bdautokey
            // 
            this.bdautokey.DataMember = "dtgautokey";
            this.bdautokey.DataSource = this.dtssaleorder;
            // 
            // dtssaleorder
            // 
            this.dtssaleorder.DataSetName = "dtssaleorder";
            this.dtssaleorder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnserchbranch
            // 
            this.btnserchbranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnserchbranch.Location = new System.Drawing.Point(406, 11);
            this.btnserchbranch.Name = "btnserchbranch";
            this.btnserchbranch.Size = new System.Drawing.Size(51, 27);
            this.btnserchbranch.TabIndex = 51;
            this.btnserchbranch.Text = "...";
            this.btnserchbranch.UseVisualStyleBackColor = true;
            this.btnserchbranch.Click += new System.EventHandler(this.btnserchbranch_Click);
            // 
            // txtnamebranch
            // 
            this.txtnamebranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnamebranch.Location = new System.Drawing.Point(162, 12);
            this.txtnamebranch.Name = "txtnamebranch";
            this.txtnamebranch.Size = new System.Drawing.Size(238, 24);
            this.txtnamebranch.TabIndex = 50;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(54, 12);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(105, 24);
            this.txtid.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "สาขา:";
            // 
            // txtkey
            // 
            this.txtkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkey.Location = new System.Drawing.Point(68, 43);
            this.txtkey.Name = "txtkey";
            this.txtkey.Size = new System.Drawing.Size(96, 24);
            this.txtkey.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "อักษรนำ:";
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.Location = new System.Drawing.Point(235, 43);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(223, 24);
            this.txtremark.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(171, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 57;
            this.label2.Text = "หมายเหตุ:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 285);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 27);
            this.panel3.TabIndex = 61;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(304, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(83, 27);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "บันทึกข้อมูล";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(387, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 27);
            this.button2.TabIndex = 12;
            this.button2.Text = "ปิด";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmAutokey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 312);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnserchbranch);
            this.Controls.Add(this.txtnamebranch);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgautokey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutokey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAutokey";
            this.Load += new System.EventHandler(this.FrmAutokey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgautokey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdautokey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bdautokey;
        private dtssaleorder dtssaleorder;
        private System.Windows.Forms.DataGridView dtgautokey;
        private System.Windows.Forms.DataGridViewTextBoxColumn idautoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bnameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkatbranchDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnserchbranch;
        private System.Windows.Forms.TextBox txtnamebranch;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtkey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button button2;
    }
}