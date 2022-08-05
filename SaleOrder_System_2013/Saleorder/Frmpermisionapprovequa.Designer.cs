namespace SaleOrder
{
    partial class Frmpermisionapprovequa
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.dtgpermisionqua = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgpermisionqua)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Controls.Add(this.btnclose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 383);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(534, 27);
            this.panel3.TabIndex = 74;
            // 
            // btnsave
            // 
            this.btnsave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.Location = new System.Drawing.Point(368, 0);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(83, 27);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "บันทึกข้อมูล";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.Location = new System.Drawing.Point(451, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(83, 27);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            // 
            // dtgpermisionqua
            // 
            this.dtgpermisionqua.AllowUserToAddRows = false;
            this.dtgpermisionqua.AllowUserToDeleteRows = false;
            this.dtgpermisionqua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgpermisionqua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dtgpermisionqua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgpermisionqua.Location = new System.Drawing.Point(0, 27);
            this.dtgpermisionqua.Name = "dtgpermisionqua";
            this.dtgpermisionqua.ReadOnly = true;
            this.dtgpermisionqua.RowHeadersWidth = 10;
            this.dtgpermisionqua.Size = new System.Drawing.Size(534, 356);
            this.dtgpermisionqua.TabIndex = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnbrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 27);
            this.panel1.TabIndex = 76;
            // 
            // btnbrowse
            // 
            this.btnbrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnbrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnbrowse.Location = new System.Drawing.Point(451, 0);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(83, 27);
            this.btnbrowse.TabIndex = 12;
            this.btnbrowse.Text = "Browse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idemp";
            this.Column1.HeaderText = "IDemp";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "empname";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "depname";
            this.Column3.HeaderText = "Department";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "positionname";
            this.Column4.HeaderText = "Position";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "nameappqua";
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Frmpermisionapprovequa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 410);
            this.Controls.Add(this.dtgpermisionqua);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Frmpermisionapprovequa";
            this.Text = "Approve Permision Quation";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgpermisionqua)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DataGridView dtgpermisionqua;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}