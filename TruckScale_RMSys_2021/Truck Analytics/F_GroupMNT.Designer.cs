namespace Truck_Analytics
{
    partial class F_GroupMNT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_GroupMNT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_save = new System.Windows.Forms.Button();
            this.dtg_group = new System.Windows.Forms.DataGridView();
            this.txt_namGroupt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_addNew = new System.Windows.Forms.CheckBox();
            this.txt_idGroup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_Sts = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cb_Payproduct_True = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_group)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(923, 38);
            this.btn_save.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(93, 38);
            this.btn_save.TabIndex = 37;
            this.btn_save.Text = "Save";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dtg_group
            // 
            this.dtg_group.AllowUserToAddRows = false;
            this.dtg_group.AllowUserToDeleteRows = false;
            this.dtg_group.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_group.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_group.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_group.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtg_group.Location = new System.Drawing.Point(0, 77);
            this.dtg_group.Name = "dtg_group";
            this.dtg_group.ReadOnly = true;
            this.dtg_group.RowHeadersWidth = 11;
            this.dtg_group.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_group.Size = new System.Drawing.Size(1090, 400);
            this.dtg_group.TabIndex = 38;
            this.dtg_group.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_group_CellMouseClick);
            // 
            // txt_namGroupt
            // 
            this.txt_namGroupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_namGroupt.Location = new System.Drawing.Point(530, 44);
            this.txt_namGroupt.Name = "txt_namGroupt";
            this.txt_namGroupt.Size = new System.Drawing.Size(290, 26);
            this.txt_namGroupt.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(467, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "ชื่อกลุ่ม:";
            // 
            // cb_addNew
            // 
            this.cb_addNew.AutoSize = true;
            this.cb_addNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_addNew.Location = new System.Drawing.Point(12, 11);
            this.cb_addNew.Name = "cb_addNew";
            this.cb_addNew.Size = new System.Drawing.Size(80, 24);
            this.cb_addNew.TabIndex = 46;
            this.cb_addNew.Text = "เพิ่มใหม่";
            this.cb_addNew.UseVisualStyleBackColor = true;
            this.cb_addNew.CheckedChanged += new System.EventHandler(this.cb_addNew_CheckedChanged);
            // 
            // txt_idGroup
            // 
            this.txt_idGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_idGroup.Location = new System.Drawing.Point(338, 44);
            this.txt_idGroup.Name = "txt_idGroup";
            this.txt_idGroup.Size = new System.Drawing.Size(113, 26);
            this.txt_idGroup.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(273, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "รหัสกลุ่ม:";
            // 
            // chk_Sts
            // 
            this.chk_Sts.AutoSize = true;
            this.chk_Sts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chk_Sts.Location = new System.Drawing.Point(826, 45);
            this.chk_Sts.Name = "chk_Sts";
            this.chk_Sts.Size = new System.Drawing.Size(91, 24);
            this.chk_Sts.TabIndex = 49;
            this.chk_Sts.Text = "เปิดใช้งาน";
            this.chk_Sts.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(12, 47);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label19.Size = new System.Drawing.Size(46, 20);
            this.label19.TabIndex = 50;
            this.label19.Text = "สินค้า:";
            // 
            // cb_Payproduct_True
            // 
            this.cb_Payproduct_True.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_Payproduct_True.FormattingEnabled = true;
            this.cb_Payproduct_True.Location = new System.Drawing.Point(64, 43);
            this.cb_Payproduct_True.Name = "cb_Payproduct_True";
            this.cb_Payproduct_True.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cb_Payproduct_True.Size = new System.Drawing.Size(203, 28);
            this.cb_Payproduct_True.TabIndex = 51;
            // 
            // F_GroupMNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 477);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cb_Payproduct_True);
            this.Controls.Add(this.chk_Sts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_idGroup);
            this.Controls.Add(this.cb_addNew);
            this.Controls.Add(this.txt_namGroupt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtg_group);
            this.Controls.Add(this.btn_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_GroupMNT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "กลุ่ม/ประเภทผู้ขาย";
            this.Load += new System.EventHandler(this.F_GroupMNT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_group)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dtg_group;
        private System.Windows.Forms.TextBox txt_namGroupt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_addNew;
        private System.Windows.Forms.TextBox txt_idGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_Sts;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cb_Payproduct_True;
    }
}