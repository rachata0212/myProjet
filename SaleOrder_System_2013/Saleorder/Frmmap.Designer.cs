namespace SaleOrder
{
    partial class Frmmap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnview = new System.Windows.Forms.Button();
            this.txtprovice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcompanyname = new System.Windows.Forms.TextBox();
            this.btnsearchcom = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.btnsearchfile = new System.Windows.Forms.Button();
            this.cbnew = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgviewfile = new System.Windows.Forms.DataGridView();
            this.idautoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filestype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdmaps = new System.Windows.Forms.BindingSource(this.components);
            this.dtssaleorder = new SaleOrder.dtssaleorder();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdmaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnview);
            this.panel1.Controls.Add(this.txtprovice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtcompanyname);
            this.panel1.Controls.Add(this.btnsearchcom);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtpath);
            this.panel1.Controls.Add(this.btnsearchfile);
            this.panel1.Controls.Add(this.cbnew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 116);
            this.panel1.TabIndex = 0;
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnview.Location = new System.Drawing.Point(573, 26);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(51, 24);
            this.btnview.TabIndex = 14;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // txtprovice
            // 
            this.txtprovice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtprovice.Location = new System.Drawing.Point(118, 85);
            this.txtprovice.Name = "txtprovice";
            this.txtprovice.Size = new System.Drawing.Size(408, 22);
            this.txtprovice.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(9, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Provice:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(9, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Company Name:";
            // 
            // txtcompanyname
            // 
            this.txtcompanyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtcompanyname.Location = new System.Drawing.Point(118, 55);
            this.txtcompanyname.Name = "txtcompanyname";
            this.txtcompanyname.Size = new System.Drawing.Size(454, 22);
            this.txtcompanyname.TabIndex = 7;
            // 
            // btnsearchcom
            // 
            this.btnsearchcom.Enabled = false;
            this.btnsearchcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsearchcom.Location = new System.Drawing.Point(573, 53);
            this.btnsearchcom.Name = "btnsearchcom";
            this.btnsearchcom.Size = new System.Drawing.Size(51, 24);
            this.btnsearchcom.TabIndex = 6;
            this.btnsearchcom.Text = ".....";
            this.btnsearchcom.UseVisualStyleBackColor = true;
            this.btnsearchcom.Click += new System.EventHandler(this.btnsearchcom_Click);
            // 
            // btnsave
            // 
            this.btnsave.Enabled = false;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnsave.Location = new System.Drawing.Point(532, 84);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(92, 25);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save Files";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select File path:";
            // 
            // txtpath
            // 
            this.txtpath.Enabled = false;
            this.txtpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtpath.Location = new System.Drawing.Point(80, 27);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(449, 22);
            this.txtpath.TabIndex = 1;
            // 
            // btnsearchfile
            // 
            this.btnsearchfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsearchfile.Location = new System.Drawing.Point(535, 26);
            this.btnsearchfile.Name = "btnsearchfile";
            this.btnsearchfile.Size = new System.Drawing.Size(37, 24);
            this.btnsearchfile.TabIndex = 0;
            this.btnsearchfile.Text = ".....";
            this.btnsearchfile.UseVisualStyleBackColor = true;
            this.btnsearchfile.Click += new System.EventHandler(this.btnsearchfile_Click);
            // 
            // cbnew
            // 
            this.cbnew.AutoSize = true;
            this.cbnew.Checked = true;
            this.cbnew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbnew.Location = new System.Drawing.Point(12, 30);
            this.cbnew.Name = "cbnew";
            this.cbnew.Size = new System.Drawing.Size(69, 17);
            this.cbnew.TabIndex = 15;
            this.cbnew.Text = "NewMap";
            this.cbnew.UseVisualStyleBackColor = true;
            this.cbnew.CheckedChanged += new System.EventHandler(this.cbnew_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtsearch);
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 517);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 29);
            this.panel2.TabIndex = 2;
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtsearch.Location = new System.Drawing.Point(91, 3);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(457, 24);
            this.txtsearch.TabIndex = 3;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Location = new System.Drawing.Point(554, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(70, 25);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(-3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "SearchMaps:";
            // 
            // dtgviewfile
            // 
            this.dtgviewfile.AllowUserToAddRows = false;
            this.dtgviewfile.AllowUserToDeleteRows = false;
            this.dtgviewfile.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgviewfile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgviewfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idautoDataGridViewTextBoxColumn,
            this.bnameDataGridViewTextBoxColumn,
            this.cnameDataGridViewTextBoxColumn,
            this.proviceDataGridViewTextBoxColumn,
            this.filestype});
            this.dtgviewfile.DataSource = this.bdmaps;
            this.dtgviewfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgviewfile.Location = new System.Drawing.Point(0, 116);
            this.dtgviewfile.Name = "dtgviewfile";
            this.dtgviewfile.ReadOnly = true;
            this.dtgviewfile.RowHeadersWidth = 11;
            this.dtgviewfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgviewfile.Size = new System.Drawing.Size(627, 401);
            this.dtgviewfile.TabIndex = 3;
            this.dtgviewfile.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgviewfile_CellMouseDoubleClick);
            this.dtgviewfile.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgviewfile_CellMouseClick);
            // 
            // idautoDataGridViewTextBoxColumn
            // 
            this.idautoDataGridViewTextBoxColumn.DataPropertyName = "idauto";
            this.idautoDataGridViewTextBoxColumn.HeaderText = "NO";
            this.idautoDataGridViewTextBoxColumn.Name = "idautoDataGridViewTextBoxColumn";
            this.idautoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idautoDataGridViewTextBoxColumn.Width = 50;
            // 
            // bnameDataGridViewTextBoxColumn
            // 
            this.bnameDataGridViewTextBoxColumn.DataPropertyName = "bname";
            this.bnameDataGridViewTextBoxColumn.HeaderText = "Branch";
            this.bnameDataGridViewTextBoxColumn.Name = "bnameDataGridViewTextBoxColumn";
            this.bnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cnameDataGridViewTextBoxColumn
            // 
            this.cnameDataGridViewTextBoxColumn.DataPropertyName = "cname";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cnameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cnameDataGridViewTextBoxColumn.HeaderText = "Company";
            this.cnameDataGridViewTextBoxColumn.Name = "cnameDataGridViewTextBoxColumn";
            this.cnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cnameDataGridViewTextBoxColumn.Width = 290;
            // 
            // proviceDataGridViewTextBoxColumn
            // 
            this.proviceDataGridViewTextBoxColumn.DataPropertyName = "provice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.proviceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.proviceDataGridViewTextBoxColumn.HeaderText = "Provice";
            this.proviceDataGridViewTextBoxColumn.Name = "proviceDataGridViewTextBoxColumn";
            this.proviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // filestype
            // 
            this.filestype.DataPropertyName = "filestype";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.filestype.DefaultCellStyle = dataGridViewCellStyle4;
            this.filestype.HeaderText = "filestype";
            this.filestype.Name = "filestype";
            this.filestype.ReadOnly = true;
            this.filestype.Width = 70;
            // 
            // bdmaps
            // 
            this.bdmaps.DataMember = "dtgmaps";
            this.bdmaps.DataSource = this.dtssaleorder;
            // 
            // dtssaleorder
            // 
            this.dtssaleorder.DataSetName = "dtssaleorder";
            this.dtssaleorder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frmmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 546);
            this.Controls.Add(this.dtgviewfile);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmmap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maps Store";
            this.Load += new System.EventHandler(this.Frmmap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdmaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button btnsearchfile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dtgviewfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcompanyname;
        private System.Windows.Forms.Button btnsearchcom;
        private System.Windows.Forms.BindingSource bdmaps;
        private dtssaleorder dtssaleorder;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtprovice;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.DataGridViewTextBoxColumn idautoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filestype;
        private System.Windows.Forms.CheckBox cbnew;
    }
}