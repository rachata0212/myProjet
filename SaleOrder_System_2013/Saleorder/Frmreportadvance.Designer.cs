namespace SaleOrder
{
    partial class Frmreportadvance
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.rdostdate = new System.Windows.Forms.RadioButton();
            this.rdeddate = new System.Windows.Forms.RadioButton();
            this.lblstdate = new System.Windows.Forms.Label();
            this.lbleddate = new System.Windows.Forms.Label();
            this.cbratereport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(16, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "รายงานซื้อ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(16, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "รายงานขาย";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbtype
            // 
            this.cbtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "ต่อสัปดาห์",
            "ต่อเดือน",
            "ต่อไตรมาส"});
            this.cbtype.Location = new System.Drawing.Point(6, 38);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(121, 24);
            this.cbtype.TabIndex = 2;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.button3);
            this.gb1.Controls.Add(this.button1);
            this.gb1.Controls.Add(this.button2);
            this.gb1.Location = new System.Drawing.Point(347, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(200, 276);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            this.gb1.Text = "เลือกรายงาน";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.label2);
            this.gb2.Controls.Add(this.label1);
            this.gb2.Controls.Add(this.cbratereport);
            this.gb2.Controls.Add(this.cbtype);
            this.gb2.Location = new System.Drawing.Point(12, 12);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(144, 276);
            this.gb2.TabIndex = 4;
            this.gb2.TabStop = false;
            this.gb2.Text = "เลือกรายงานแบบ";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button3.Location = new System.Drawing.Point(16, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "รายงานซื้อเทียบขาย";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbleddate);
            this.groupBox1.Controls.Add(this.lblstdate);
            this.groupBox1.Controls.Add(this.rdeddate);
            this.groupBox1.Controls.Add(this.rdostdate);
            this.groupBox1.Controls.Add(this.dtpdate);
            this.groupBox1.Location = new System.Drawing.Point(162, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 276);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เลือกระยะเวลา";
            // 
            // dtpdate
            // 
            this.dtpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(17, 23);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(103, 22);
            this.dtpdate.TabIndex = 0;
            this.dtpdate.ValueChanged += new System.EventHandler(this.dtpdate_ValueChanged);
            // 
            // rdostdate
            // 
            this.rdostdate.AutoSize = true;
            this.rdostdate.Location = new System.Drawing.Point(17, 52);
            this.rdostdate.Name = "rdostdate";
            this.rdostdate.Size = new System.Drawing.Size(73, 17);
            this.rdostdate.TabIndex = 1;
            this.rdostdate.TabStop = true;
            this.rdostdate.Text = "ตั้งแต่วันที่";
            this.rdostdate.UseVisualStyleBackColor = true;
            // 
            // rdeddate
            // 
            this.rdeddate.AutoSize = true;
            this.rdeddate.Location = new System.Drawing.Point(106, 52);
            this.rdeddate.Name = "rdeddate";
            this.rdeddate.Size = new System.Drawing.Size(58, 17);
            this.rdeddate.TabIndex = 2;
            this.rdeddate.TabStop = true;
            this.rdeddate.Text = "ถึงวันที่";
            this.rdeddate.UseVisualStyleBackColor = true;
            // 
            // lblstdate
            // 
            this.lblstdate.AutoSize = true;
            this.lblstdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblstdate.Location = new System.Drawing.Point(14, 79);
            this.lblstdate.Name = "lblstdate";
            this.lblstdate.Size = new System.Drawing.Size(45, 16);
            this.lblstdate.TabIndex = 3;
            this.lblstdate.Text = "label1";
            // 
            // lbleddate
            // 
            this.lbleddate.AutoSize = true;
            this.lbleddate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbleddate.Location = new System.Drawing.Point(14, 102);
            this.lbleddate.Name = "lbleddate";
            this.lbleddate.Size = new System.Drawing.Size(45, 16);
            this.lbleddate.TabIndex = 4;
            this.lbleddate.Text = "label2";
            // 
            // cbratereport
            // 
            this.cbratereport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbratereport.FormattingEnabled = true;
            this.cbratereport.Items.AddRange(new object[] {
            "  5 อันดับแรก",
            "10 อันดับแรก",
            "15 อันดับแรก",
            "20 อันดับแรก"});
            this.cbratereport.Location = new System.Drawing.Point(6, 89);
            this.cbratereport.Name = "cbratereport";
            this.cbratereport.Size = new System.Drawing.Size(121, 24);
            this.cbratereport.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "ต่อสัปดาห์,เดือน,ไตรมาส";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "จำนวนอันดับ";
            // 
            // Frmreportadvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Name = "Frmreportadvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report advance";
            this.gb1.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbleddate;
        private System.Windows.Forms.Label lblstdate;
        private System.Windows.Forms.RadioButton rdeddate;
        private System.Windows.Forms.RadioButton rdostdate;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbratereport;
    }
}