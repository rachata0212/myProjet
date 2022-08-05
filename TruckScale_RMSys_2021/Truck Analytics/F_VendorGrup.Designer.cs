namespace Truck_Analytics
{
    partial class F_VendorGrup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_VendorGrup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_1 = new System.Windows.Forms.Panel();
            this.chk_addNew = new System.Windows.Forms.CheckBox();
            this.chk_STSacctive = new System.Windows.Forms.CheckBox();
            this.lbl_vendorName = new System.Windows.Forms.Label();
            this.btn_vendorFind = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cb_vendorGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_findName = new System.Windows.Forms.TextBox();
            this.txt_idvendor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.chk_newRecord = new System.Windows.Forms.Button();
            this.dtg_vendor = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_countItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnl_1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vendor)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_1
            // 
            this.pnl_1.BackColor = System.Drawing.Color.Orchid;
            this.pnl_1.Controls.Add(this.chk_addNew);
            this.pnl_1.Controls.Add(this.chk_STSacctive);
            this.pnl_1.Controls.Add(this.lbl_vendorName);
            this.pnl_1.Controls.Add(this.btn_vendorFind);
            this.pnl_1.Controls.Add(this.label20);
            this.pnl_1.Controls.Add(this.cb_vendorGroup);
            this.pnl_1.Controls.Add(this.label2);
            this.pnl_1.Controls.Add(this.txt_findName);
            this.pnl_1.Controls.Add(this.txt_idvendor);
            this.pnl_1.Controls.Add(this.label1);
            this.pnl_1.Controls.Add(this.panel1);
            this.pnl_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_1.Location = new System.Drawing.Point(0, 0);
            this.pnl_1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_1.Name = "pnl_1";
            this.pnl_1.Size = new System.Drawing.Size(1416, 86);
            this.pnl_1.TabIndex = 0;
            // 
            // chk_addNew
            // 
            this.chk_addNew.AutoSize = true;
            this.chk_addNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chk_addNew.Location = new System.Drawing.Point(17, 9);
            this.chk_addNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_addNew.Name = "chk_addNew";
            this.chk_addNew.Size = new System.Drawing.Size(97, 29);
            this.chk_addNew.TabIndex = 57;
            this.chk_addNew.Text = "สร้างใหม่";
            this.chk_addNew.UseVisualStyleBackColor = true;
            this.chk_addNew.CheckedChanged += new System.EventHandler(this.chk_addNew_CheckedChanged);
            // 
            // chk_STSacctive
            // 
            this.chk_STSacctive.AutoSize = true;
            this.chk_STSacctive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chk_STSacctive.Location = new System.Drawing.Point(1135, 49);
            this.chk_STSacctive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_STSacctive.Name = "chk_STSacctive";
            this.chk_STSacctive.Size = new System.Drawing.Size(108, 29);
            this.chk_STSacctive.TabIndex = 56;
            this.chk_STSacctive.Text = "เปิดใช้งาน";
            this.chk_STSacctive.UseVisualStyleBackColor = true;
            // 
            // lbl_vendorName
            // 
            this.lbl_vendorName.AutoSize = true;
            this.lbl_vendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_vendorName.Location = new System.Drawing.Point(260, 52);
            this.lbl_vendorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_vendorName.Name = "lbl_vendorName";
            this.lbl_vendorName.Size = new System.Drawing.Size(27, 25);
            this.lbl_vendorName.TabIndex = 51;
            this.lbl_vendorName.Text = "...";
            // 
            // btn_vendorFind
            // 
            this.btn_vendorFind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_vendorFind.BackgroundImage")));
            this.btn_vendorFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_vendorFind.Enabled = false;
            this.btn_vendorFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_vendorFind.Location = new System.Drawing.Point(191, 48);
            this.btn_vendorFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_vendorFind.Name = "btn_vendorFind";
            this.btn_vendorFind.Size = new System.Drawing.Size(53, 32);
            this.btn_vendorFind.TabIndex = 50;
            this.btn_vendorFind.UseVisualStyleBackColor = true;
            this.btn_vendorFind.Click += new System.EventHandler(this.btn_vendorFind_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(639, 52);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 25);
            this.label20.TabIndex = 34;
            this.label20.Text = "กลุ่มผู้ขาย:";
            // 
            // cb_vendorGroup
            // 
            this.cb_vendorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_vendorGroup.FormattingEnabled = true;
            this.cb_vendorGroup.Location = new System.Drawing.Point(737, 47);
            this.cb_vendorGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_vendorGroup.Name = "cb_vendorGroup";
            this.cb_vendorGroup.Size = new System.Drawing.Size(390, 33);
            this.cb_vendorGroup.TabIndex = 35;
            this.cb_vendorGroup.SelectedIndexChanged += new System.EventHandler(this.cb_vendorGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(153, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "ค้นหา (ชื่อ):";
            // 
            // txt_findName
            // 
            this.txt_findName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_findName.Location = new System.Drawing.Point(265, 7);
            this.txt_findName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_findName.Name = "txt_findName";
            this.txt_findName.Size = new System.Drawing.Size(372, 30);
            this.txt_findName.TabIndex = 3;
            this.txt_findName.TextChanged += new System.EventHandler(this.txt_findName_TextChanged);
            // 
            // txt_idvendor
            // 
            this.txt_idvendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_idvendor.Location = new System.Drawing.Point(60, 48);
            this.txt_idvendor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_idvendor.Name = "txt_idvendor";
            this.txt_idvendor.ReadOnly = true;
            this.txt_idvendor.Size = new System.Drawing.Size(121, 30);
            this.txt_idvendor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัส:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.chk_newRecord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1292, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 86);
            this.panel1.TabIndex = 58;
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(0, 43);
            this.btn_save.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(124, 43);
            this.btn_save.TabIndex = 36;
            this.btn_save.Text = "Save";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // chk_newRecord
            // 
            this.chk_newRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.chk_newRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chk_newRecord.Location = new System.Drawing.Point(0, 0);
            this.chk_newRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_newRecord.Name = "chk_newRecord";
            this.chk_newRecord.Size = new System.Drawing.Size(124, 43);
            this.chk_newRecord.TabIndex = 44;
            this.chk_newRecord.Text = "เพิ่มกลุ่ม";
            this.chk_newRecord.UseVisualStyleBackColor = true;
            this.chk_newRecord.Click += new System.EventHandler(this.btn_Addgroup_Click);
            // 
            // dtg_vendor
            // 
            this.dtg_vendor.AllowUserToAddRows = false;
            this.dtg_vendor.AllowUserToDeleteRows = false;
            this.dtg_vendor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_vendor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_vendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_vendor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_vendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_vendor.Location = new System.Drawing.Point(0, 86);
            this.dtg_vendor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtg_vendor.Name = "dtg_vendor";
            this.dtg_vendor.ReadOnly = true;
            this.dtg_vendor.RowHeadersWidth = 11;
            this.dtg_vendor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_vendor.Size = new System.Drawing.Size(1416, 468);
            this.dtg_vendor.TabIndex = 1;
            this.dtg_vendor.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_vendor_CellMouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_countItem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1416, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_countItem
            // 
            this.tool_countItem.Name = "tool_countItem";
            this.tool_countItem.Size = new System.Drawing.Size(86, 20);
            this.tool_countItem.Text = "count Items";
            // 
            // F_VendorGrup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 554);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtg_vendor);
            this.Controls.Add(this.pnl_1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_VendorGrup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "จัดการกลุ่มผู้จำหน่าย";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_VendorGrup_Load);
            this.pnl_1.ResumeLayout(false);
            this.pnl_1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vendor)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_1;
        private System.Windows.Forms.TextBox txt_idvendor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtg_vendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_findName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cb_vendorGroup;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button chk_newRecord;
        private System.Windows.Forms.Button btn_vendorFind;
        private System.Windows.Forms.Label lbl_vendorName;
        private System.Windows.Forms.CheckBox chk_STSacctive;
        private System.Windows.Forms.CheckBox chk_addNew;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tool_countItem;
        private System.Windows.Forms.Panel panel1;
    }
}