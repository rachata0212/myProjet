namespace Truck_Analytics
{
    partial class F_Approval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_totalItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdo_appnow = new System.Windows.Forms.RadioButton();
            this.dgv_datatruck = new System.Windows.Forms.DataGridView();
            this.gb_lab = new System.Windows.Forms.GroupBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tool_countlab = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_datalab = new System.Windows.Forms.DataGridView();
            this.gb_visual = new System.Windows.Forms.GroupBox();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.tool_countvisual = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_datavisual = new System.Windows.Forms.DataGridView();
            this.ยืนยัน = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_approved = new System.Windows.Forms.Button();
            this.btn_reject = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datatruck)).BeginInit();
            this.gb_lab.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datalab)).BeginInit();
            this.gb_visual.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datavisual)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_totalItems});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1364, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_totalItems
            // 
            this.tool_totalItems.Name = "tool_totalItems";
            this.tool_totalItems.Size = new System.Drawing.Size(63, 17);
            this.tool_totalItems.Text = "total items";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_reject);
            this.panel1.Controls.Add(this.btn_approved);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.rdo_appnow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 122);
            this.panel1.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(168, 87);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(125, 24);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "ประวัติการอนุมัติ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdo_appnow
            // 
            this.rdo_appnow.AutoSize = true;
            this.rdo_appnow.Checked = true;
            this.rdo_appnow.Location = new System.Drawing.Point(12, 87);
            this.rdo_appnow.Name = "rdo_appnow";
            this.rdo_appnow.Size = new System.Drawing.Size(133, 24);
            this.rdo_appnow.TabIndex = 3;
            this.rdo_appnow.TabStop = true;
            this.rdo_appnow.Text = "รายการที่รออนุมัติ";
            this.rdo_appnow.UseVisualStyleBackColor = true;
            this.rdo_appnow.CheckedChanged += new System.EventHandler(this.rdo_appnow_CheckedChanged);
            // 
            // dgv_datatruck
            // 
            this.dgv_datatruck.AllowUserToAddRows = false;
            this.dgv_datatruck.AllowUserToDeleteRows = false;
            this.dgv_datatruck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_datatruck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_datatruck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datatruck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ยืนยัน});
            this.dgv_datatruck.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_datatruck.Location = new System.Drawing.Point(0, 122);
            this.dgv_datatruck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_datatruck.Name = "dgv_datatruck";
            this.dgv_datatruck.RowHeadersWidth = 11;
            this.dgv_datatruck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_datatruck.Size = new System.Drawing.Size(758, 605);
            this.dgv_datatruck.TabIndex = 4;
            this.dgv_datatruck.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_datatruck_CellMouseClick);
            // 
            // gb_lab
            // 
            this.gb_lab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.gb_lab.Controls.Add(this.statusStrip2);
            this.gb_lab.Controls.Add(this.dgv_datalab);
            this.gb_lab.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gb_lab.Location = new System.Drawing.Point(758, 122);
            this.gb_lab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_lab.Name = "gb_lab";
            this.gb_lab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_lab.Size = new System.Drawing.Size(606, 342);
            this.gb_lab.TabIndex = 11;
            this.gb_lab.TabStop = false;
            this.gb_lab.Text = "ผลวิเคราะห์ทางเครื่องมือ (LAB)";
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_countlab});
            this.statusStrip2.Location = new System.Drawing.Point(4, 315);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip2.Size = new System.Drawing.Size(598, 22);
            this.statusStrip2.TabIndex = 4;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tool_countlab
            // 
            this.tool_countlab.Name = "tool_countlab";
            this.tool_countlab.Size = new System.Drawing.Size(37, 17);
            this.tool_countlab.Text = "จำนวน";
            // 
            // dgv_datalab
            // 
            this.dgv_datalab.AllowUserToAddRows = false;
            this.dgv_datalab.AllowUserToDeleteRows = false;
            this.dgv_datalab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_datalab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_datalab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datalab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_datalab.Location = new System.Drawing.Point(4, 20);
            this.dgv_datalab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_datalab.Name = "dgv_datalab";
            this.dgv_datalab.RowHeadersWidth = 11;
            this.dgv_datalab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_datalab.Size = new System.Drawing.Size(598, 317);
            this.dgv_datalab.TabIndex = 3;
            // 
            // gb_visual
            // 
            this.gb_visual.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.gb_visual.Controls.Add(this.statusStrip3);
            this.gb_visual.Controls.Add(this.dgv_datavisual);
            this.gb_visual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_visual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gb_visual.Location = new System.Drawing.Point(758, 464);
            this.gb_visual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_visual.Name = "gb_visual";
            this.gb_visual.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_visual.Size = new System.Drawing.Size(606, 263);
            this.gb_visual.TabIndex = 12;
            this.gb_visual.TabStop = false;
            this.gb_visual.Text = "ผลวิเคราะห์ทางกายภาพ (Visual)";
            // 
            // statusStrip3
            // 
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_countvisual});
            this.statusStrip3.Location = new System.Drawing.Point(4, 236);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip3.Size = new System.Drawing.Size(598, 22);
            this.statusStrip3.TabIndex = 13;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // tool_countvisual
            // 
            this.tool_countvisual.Name = "tool_countvisual";
            this.tool_countvisual.Size = new System.Drawing.Size(37, 17);
            this.tool_countvisual.Text = "จำนวน";
            // 
            // dgv_datavisual
            // 
            this.dgv_datavisual.AllowUserToAddRows = false;
            this.dgv_datavisual.AllowUserToDeleteRows = false;
            this.dgv_datavisual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_datavisual.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_datavisual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datavisual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_datavisual.Location = new System.Drawing.Point(4, 20);
            this.dgv_datavisual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_datavisual.Name = "dgv_datavisual";
            this.dgv_datavisual.RowHeadersWidth = 11;
            this.dgv_datavisual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_datavisual.Size = new System.Drawing.Size(598, 238);
            this.dgv_datavisual.TabIndex = 3;
            // 
            // ยืนยัน
            // 
            this.ยืนยัน.HeaderText = "อนุมัติ";
            this.ยืนยัน.Name = "ยืนยัน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(436, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "ระบบอนุมัติของผลวิเคราะห์ที่ไม่ผ่านเกณฑ์";
            // 
            // btn_approved
            // 
            this.btn_approved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_approved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_approved.Location = new System.Drawing.Point(314, 84);
            this.btn_approved.Name = "btn_approved";
            this.btn_approved.Size = new System.Drawing.Size(134, 30);
            this.btn_approved.TabIndex = 6;
            this.btn_approved.Text = "อนุมัติ-รับสินค้า";
            this.btn_approved.UseVisualStyleBackColor = true;
            this.btn_approved.Click += new System.EventHandler(this.btn_approved_Click);
            // 
            // btn_reject
            // 
            this.btn_reject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_reject.ForeColor = System.Drawing.Color.Red;
            this.btn_reject.Location = new System.Drawing.Point(466, 84);
            this.btn_reject.Name = "btn_reject";
            this.btn_reject.Size = new System.Drawing.Size(134, 30);
            this.btn_reject.TabIndex = 7;
            this.btn_reject.Text = "ไม่อนุมัติ-รับสินค้า";
            this.btn_reject.UseVisualStyleBackColor = true;
            this.btn_reject.Click += new System.EventHandler(this.btn_reject_Click);
            // 
            // F_Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.gb_visual);
            this.Controls.Add(this.gb_lab);
            this.Controls.Add(this.dgv_datatruck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "F_Approval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "การอนุมัติระบบงานตาชั่ง";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Approval_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datatruck)).EndInit();
            this.gb_lab.ResumeLayout(false);
            this.gb_lab.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datalab)).EndInit();
            this.gb_visual.ResumeLayout(false);
            this.gb_visual.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datavisual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tool_totalItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdo_appnow;
        private System.Windows.Forms.DataGridView dgv_datatruck;
        private System.Windows.Forms.GroupBox gb_lab;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tool_countlab;
        private System.Windows.Forms.DataGridView dgv_datalab;
        private System.Windows.Forms.GroupBox gb_visual;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel tool_countvisual;
        private System.Windows.Forms.DataGridView dgv_datavisual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ยืนยัน;
        private System.Windows.Forms.Button btn_reject;
        private System.Windows.Forms.Button btn_approved;
        private System.Windows.Forms.Label label1;
    }
}