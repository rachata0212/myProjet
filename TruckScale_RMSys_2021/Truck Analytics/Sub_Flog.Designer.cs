namespace Truck_Analytics
{
    partial class Sub_Flog
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.cb_historyUser = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.cb_histryDate = new System.Windows.Forms.ComboBox();
            this.dtg_History = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtg_online = new System.Windows.Forms.DataGridView();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_History)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_online)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label51);
            this.panel9.Controls.Add(this.cb_historyUser);
            this.panel9.Controls.Add(this.label47);
            this.panel9.Controls.Add(this.cb_histryDate);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1186, 35);
            this.panel9.TabIndex = 1;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(278, 6);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(55, 20);
            this.label51.TabIndex = 45;
            this.label51.Text = "ชื่อผู้ใช้:";
            // 
            // cb_historyUser
            // 
            this.cb_historyUser.FormattingEnabled = true;
            this.cb_historyUser.Location = new System.Drawing.Point(334, 2);
            this.cb_historyUser.Name = "cb_historyUser";
            this.cb_historyUser.Size = new System.Drawing.Size(186, 28);
            this.cb_historyUser.TabIndex = 44;
            this.cb_historyUser.SelectedIndexChanged += new System.EventHandler(this.cb_historyUser_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(7, 6);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(39, 20);
            this.label47.TabIndex = 43;
            this.label47.Text = "วันที่:";
            // 
            // cb_histryDate
            // 
            this.cb_histryDate.FormattingEnabled = true;
            this.cb_histryDate.Location = new System.Drawing.Point(52, 2);
            this.cb_histryDate.Name = "cb_histryDate";
            this.cb_histryDate.Size = new System.Drawing.Size(186, 28);
            this.cb_histryDate.TabIndex = 42;
            this.cb_histryDate.SelectedIndexChanged += new System.EventHandler(this.cb_histryDate_SelectedIndexChanged);
            // 
            // dtg_History
            // 
            this.dtg_History.AllowUserToAddRows = false;
            this.dtg_History.AllowUserToDeleteRows = false;
            this.dtg_History.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_History.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_History.Location = new System.Drawing.Point(3, 38);
            this.dtg_History.Name = "dtg_History";
            this.dtg_History.ReadOnly = true;
            this.dtg_History.RowHeadersWidth = 11;
            this.dtg_History.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_History.Size = new System.Drawing.Size(1186, 598);
            this.dtg_History.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 20);
            this.panel1.TabIndex = 38;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 672);
            this.tabControl1.TabIndex = 38;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtg_History);
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 639);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ประวัติการทำงาน";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtg_online);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 639);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "สถานะการทำงาน";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtg_online
            // 
            this.dtg_online.AllowUserToAddRows = false;
            this.dtg_online.AllowUserToDeleteRows = false;
            this.dtg_online.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_online.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_online.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_online.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_online.Location = new System.Drawing.Point(3, 3);
            this.dtg_online.Name = "dtg_online";
            this.dtg_online.ReadOnly = true;
            this.dtg_online.RowHeadersWidth = 11;
            this.dtg_online.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_online.Size = new System.Drawing.Size(1186, 633);
            this.dtg_online.TabIndex = 38;
            // 
            // Sub_Flog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Sub_Flog";
            this.Text = "Sub_Flog";
            this.Load += new System.EventHandler(this.Sub_Flog_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_History)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_online)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ComboBox cb_historyUser;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox cb_histryDate;
        private System.Windows.Forms.DataGridView dtg_History;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtg_online;
    }
}