namespace Truck_Analytics
{
    partial class F_Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdo_findId = new System.Windows.Forms.RadioButton();
            this.txt_findName = new System.Windows.Forms.TextBox();
            this.rdo_findName = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo_sale = new System.Windows.Forms.RadioButton();
            this.rdo_purchase = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtg_data = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_selectitem = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtp_date);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox4.Location = new System.Drawing.Point(237, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 62);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ช่วงระยะเวลา";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "วันที่:";
            // 
            // dtp_date
            // 
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date.Location = new System.Drawing.Point(56, 24);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(132, 26);
            this.dtp_date.TabIndex = 6;
            this.dtp_date.ValueChanged += new System.EventHandler(this.dtp_date_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdo_findId);
            this.groupBox3.Controls.Add(this.txt_findName);
            this.groupBox3.Controls.Add(this.rdo_findName);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox3.Location = new System.Drawing.Point(439, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(514, 62);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ประเภทการค้นหา";
            // 
            // rdo_findId
            // 
            this.rdo_findId.AutoSize = true;
            this.rdo_findId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_findId.Location = new System.Drawing.Point(12, 26);
            this.rdo_findId.Name = "rdo_findId";
            this.rdo_findId.Size = new System.Drawing.Size(85, 24);
            this.rdo_findId.TabIndex = 0;
            this.rdo_findId.TabStop = true;
            this.rdo_findId.Text = "ค้นหารหัส";
            this.rdo_findId.UseVisualStyleBackColor = true;
            // 
            // txt_findName
            // 
            this.txt_findName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_findName.Location = new System.Drawing.Point(183, 25);
            this.txt_findName.Name = "txt_findName";
            this.txt_findName.Size = new System.Drawing.Size(319, 26);
            this.txt_findName.TabIndex = 1;
            this.txt_findName.TextChanged += new System.EventHandler(this.txt_findName_TextChanged);
            // 
            // rdo_findName
            // 
            this.rdo_findName.AutoSize = true;
            this.rdo_findName.Checked = true;
            this.rdo_findName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_findName.Location = new System.Drawing.Point(102, 26);
            this.rdo_findName.Name = "rdo_findName";
            this.rdo_findName.Size = new System.Drawing.Size(78, 24);
            this.rdo_findName.TabIndex = 2;
            this.rdo_findName.TabStop = true;
            this.rdo_findName.Text = "ค้นหาชื่อ";
            this.rdo_findName.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo_sale);
            this.groupBox2.Controls.Add(this.rdo_purchase);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 62);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ประเภทงาน";
            // 
            // rdo_sale
            // 
            this.rdo_sale.AutoSize = true;
            this.rdo_sale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_sale.Location = new System.Drawing.Point(123, 26);
            this.rdo_sale.Name = "rdo_sale";
            this.rdo_sale.Size = new System.Drawing.Size(107, 24);
            this.rdo_sale.TabIndex = 4;
            this.rdo_sale.Text = "งานขายสินค้า";
            this.rdo_sale.UseVisualStyleBackColor = true;
            this.rdo_sale.CheckedChanged += new System.EventHandler(this.rdo_sale_CheckedChanged);
            // 
            // rdo_purchase
            // 
            this.rdo_purchase.AutoSize = true;
            this.rdo_purchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_purchase.Location = new System.Drawing.Point(17, 26);
            this.rdo_purchase.Name = "rdo_purchase";
            this.rdo_purchase.Size = new System.Drawing.Size(100, 24);
            this.rdo_purchase.TabIndex = 3;
            this.rdo_purchase.Text = "งานซื้อสินค้า";
            this.rdo_purchase.UseVisualStyleBackColor = true;
            this.rdo_purchase.CheckedChanged += new System.EventHandler(this.rdo_purchase_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox5.Controls.Add(this.dtg_data);
            this.groupBox5.Controls.Add(this.statusStrip1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox5.Location = new System.Drawing.Point(0, 66);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(957, 470);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "แสดงข้อมูล";
            // 
            // dtg_data
            // 
            this.dtg_data.AllowUserToAddRows = false;
            this.dtg_data.AllowUserToDeleteRows = false;
            this.dtg_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_data.Location = new System.Drawing.Point(3, 22);
            this.dtg_data.Name = "dtg_data";
            this.dtg_data.ReadOnly = true;
            this.dtg_data.RowHeadersWidth = 11;
            this.dtg_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_data.Size = new System.Drawing.Size(951, 423);
            this.dtg_data.TabIndex = 0;
            this.dtg_data.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_data_CellMouseClick);
            this.dtg_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_data_CellMouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_count,
            this.tool_selectitem});
            this.statusStrip1.Location = new System.Drawing.Point(3, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(951, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_count
            // 
            this.tool_count.Name = "tool_count";
            this.tool_count.Size = new System.Drawing.Size(16, 17);
            this.tool_count.Text = "...";
            // 
            // tool_selectitem
            // 
            this.tool_selectitem.ForeColor = System.Drawing.Color.Red;
            this.tool_selectitem.Name = "tool_selectitem";
            this.tool_selectitem.Size = new System.Drawing.Size(83, 17);
            this.tool_selectitem.Text = "กรุณาเลือกข้อมูล";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 66);
            this.panel1.TabIndex = 12;
            // 
            // F_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 536);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ค้นหาข้อมูล";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Search_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.RadioButton rdo_findName;
        private System.Windows.Forms.TextBox txt_findName;
        private System.Windows.Forms.RadioButton rdo_findId;
        private System.Windows.Forms.RadioButton rdo_sale;
        private System.Windows.Forms.RadioButton rdo_purchase;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtg_data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tool_count;
        private System.Windows.Forms.ToolStripStatusLabel tool_selectitem;
    }
}