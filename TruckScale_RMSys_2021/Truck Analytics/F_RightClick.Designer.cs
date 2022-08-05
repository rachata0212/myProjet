namespace Truck_Analytics
{
    partial class F_RightClick
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_sumorder = new System.Windows.Forms.Label();
            this.dtg_SPvendorDetail = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_groupName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_group = new System.Windows.Forms.ComboBox();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SPvendorDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_sumorder
            // 
            this.lbl_sumorder.AutoSize = true;
            this.lbl_sumorder.Font = new System.Drawing.Font("FreesiaUPC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_sumorder.Location = new System.Drawing.Point(278, 22);
            this.lbl_sumorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sumorder.Name = "lbl_sumorder";
            this.lbl_sumorder.Size = new System.Drawing.Size(363, 41);
            this.lbl_sumorder.TabIndex = 29;
            this.lbl_sumorder.Text = "เปลี่ยนกลุ่มราคาในการรับซื้อวัตถุดิบ";
            // 
            // dtg_SPvendorDetail
            // 
            this.dtg_SPvendorDetail.AllowUserToAddRows = false;
            this.dtg_SPvendorDetail.AllowUserToDeleteRows = false;
            this.dtg_SPvendorDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_SPvendorDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_SPvendorDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SPvendorDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtg_SPvendorDetail.Location = new System.Drawing.Point(4, 67);
            this.dtg_SPvendorDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtg_SPvendorDetail.Name = "dtg_SPvendorDetail";
            this.dtg_SPvendorDetail.ReadOnly = true;
            this.dtg_SPvendorDetail.RowHeadersWidth = 11;
            this.dtg_SPvendorDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_SPvendorDetail.Size = new System.Drawing.Size(825, 197);
            this.dtg_SPvendorDetail.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtg_SPvendorDetail);
            this.groupBox1.Controls.Add(this.lbl_groupName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_group);
            this.groupBox1.Location = new System.Drawing.Point(10, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(833, 269);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลกลุ่ม";
            // 
            // lbl_groupName
            // 
            this.lbl_groupName.AutoSize = true;
            this.lbl_groupName.Location = new System.Drawing.Point(332, 39);
            this.lbl_groupName.Name = "lbl_groupName";
            this.lbl_groupName.Size = new System.Drawing.Size(21, 20);
            this.lbl_groupName.TabIndex = 36;
            this.lbl_groupName.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "เลือกกลุ่ม:";
            // 
            // cbo_group
            // 
            this.cbo_group.FormattingEnabled = true;
            this.cbo_group.Location = new System.Drawing.Point(84, 31);
            this.cbo_group.Name = "cbo_group";
            this.cbo_group.Size = new System.Drawing.Size(242, 28);
            this.cbo_group.TabIndex = 34;
            this.cbo_group.SelectedIndexChanged += new System.EventHandler(this.cbo_group_SelectedIndexChanged);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_close.Image = global::Truck_Analytics.Properties.Resources.exit1;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(757, 345);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(82, 28);
            this.btn_close.TabIndex = 33;
            this.btn_close.Text = "ปิด";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // F_RightClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 389);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_sumorder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_RightClick";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เปลี่ยนแปลงราคากลุ่ม";
            this.Load += new System.EventHandler(this.F_rightClice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SPvendorDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_sumorder;
        private System.Windows.Forms.DataGridView dtg_SPvendorDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_group;
        private System.Windows.Forms.Label lbl_groupName;
        private System.Windows.Forms.Button btn_close;
    }
}