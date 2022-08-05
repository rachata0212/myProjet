namespace SaleOrder
{
    partial class Frmchangdate
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.rdost = new System.Windows.Forms.RadioButton();
            this.rdoen = new System.Windows.Forms.RadioButton();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "เปลี่ยนแปลงวันที่";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(28, 105);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(66, 23);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "เปลี่ยน";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(104, 105);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(66, 23);
            this.btnclose.TabIndex = 2;
            this.btnclose.Text = "ยกเลิก";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // rdost
            // 
            this.rdost.AutoSize = true;
            this.rdost.Location = new System.Drawing.Point(13, 41);
            this.rdost.Name = "rdost";
            this.rdost.Size = new System.Drawing.Size(93, 17);
            this.rdost.TabIndex = 4;
            this.rdost.TabStop = true;
            this.rdost.Text = "เปลี่ยนวันที่ขึ้น";
            this.rdost.UseVisualStyleBackColor = true;
            // 
            // rdoen
            // 
            this.rdoen.AutoSize = true;
            this.rdoen.Location = new System.Drawing.Point(112, 41);
            this.rdoen.Name = "rdoen";
            this.rdoen.Size = new System.Drawing.Size(90, 17);
            this.rdoen.TabIndex = 5;
            this.rdoen.TabStop = true;
            this.rdoen.Text = "เปลี่ยนวันที่ลง";
            this.rdoen.UseVisualStyleBackColor = true;
            // 
            // dtpdate
            // 
            this.dtpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(32, 70);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(138, 29);
            this.dtpdate.TabIndex = 6;
            // 
            // Frmchangdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 143);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.rdoen);
            this.Controls.Add(this.rdost);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmchangdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Date";
            this.Load += new System.EventHandler(this.Frmchangdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.RadioButton rdost;
        private System.Windows.Forms.RadioButton rdoen;
        private System.Windows.Forms.DateTimePicker dtpdate;
    }
}